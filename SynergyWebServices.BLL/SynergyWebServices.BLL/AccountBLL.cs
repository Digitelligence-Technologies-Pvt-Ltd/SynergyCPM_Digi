using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SynergyWebServices.BLL.App_Start;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Drawing.Imaging;
using OfficeOpenXml.FormulaParsing;
using Microsoft.IdentityModel.JsonWebTokens;

namespace SynergyWebServices.BLL;

    public class AccountBLL : IAccount
    {
    private SRKSSynergyContext db = new SRKSSynergyContext();
 


    private UserManager<ApplicationUser> _usermanager;
    private static readonly ILog log = LogManager.GetLogger(typeof(BUBLL));
    private readonly List<Users> _users;
    private readonly AppSettings appSettings;

    public AccountBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings, UserManager<ApplicationUser> usermanager)
    {
        db = _db;
        appSettings = _appSettings.Value;
        _users = db.Users.ToList();
        _usermanager = usermanager;
    }

    public async Task<CommonEntity.CommonResponse> Login(AccountsEntity.Login data)
    {
        CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
        try
        {
            var iduser = await _usermanager.FindByNameAsync(data.UserName);
            
            obj.response = "Invalid username or password";
            obj.isStatus = false;
            if (iduser == null) return obj;

            var hasher = new PasswordHasher<IdentityUser>();
            if (string.IsNullOrEmpty(iduser.PasswordHash)) iduser.PasswordHash = hasher.HashPassword(iduser, data.Password);

            if (await _usermanager.CheckPasswordAsync(iduser, data.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, iduser.Id)
            };

                var roles = await _usermanager.GetRolesAsync(iduser);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                obj.response = generateJwtToken(iduser, claims);
                obj.isStatus = true;
            }
            else
            {
                obj.isStatus = false;
                obj.response = "Invalid password";
            }
           
            return obj;
                
        }
        catch (Exception ex3)
        {
            log.Error(ex3);
            if (ex3.InnerException != null)
            {
                log.Error(ex3.InnerException.ToString());
            }
            obj.response = ResourceResponse.ExceptionMessage;
            obj.isStatus = false;
            return obj;
        }

    }

    public async Task<CommonEntity.CommonResponse> LoginUID(string data)
    {
        CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
        try
        { 
            if (!string.IsNullOrEmpty(data))
            {
                var iduser = await _usermanager.FindByIdAsync(data);
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, iduser.Id)
            };

                var roles = await _usermanager.GetRolesAsync(iduser);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                obj.response = generateJwtToken(iduser, claims);
                obj.isStatus = true;
            }
       
           
        }
        catch (Exception ex4)
        {
            log.Error(ex4);
        }
        return obj;
    }
    private string generateJwtToken(IdentityUser user, List<Claim> claims)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
       byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);



        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

   public async Task<CommonEntity.CommonResponse> ResetAllPasswords()
    {
        CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
        List<Memberships> memlist = new List<Memberships>();
        memlist = db.Memberships.ToList();
        foreach (Memberships mem in memlist)
        {
            string passwordnew = mem.User.UserName + "@123";
            mem.Password = EncryptPassword(passwordnew, 1, mem.PasswordSalt);
           await db.SaveChangesAsync();
        }
        obj.response = "Success";
           obj.isStatus = true;
        return obj;
    }

    private string EncryptPassword(string pass, int passwordFormat, string salt)
    {
        if (passwordFormat == 0) // MembershipPasswordFormat.Clear
            return pass;

        byte[] bIn = Encoding.Unicode.GetBytes(pass);
        byte[] bSalt = Convert.FromBase64String(salt);
        byte[] bRet = null;

        if (passwordFormat == 1)
        {
            // MembershipPasswordFormat.Hashed 
            string test = Convert.ToBase64String(KeyDerivation.Pbkdf2(pass, bSalt, KeyDerivationPrf.HMACSHA256, 100000, 256 / 8));

            HashAlgorithm hm = HashAlgorithm.Create("HMACSHA256");

            if (hm is KeyedHashAlgorithm)
            {
                KeyedHashAlgorithm kha = (KeyedHashAlgorithm)hm;
                if (kha.Key.Length == bSalt.Length)
                {
                    kha.Key = bSalt;
                }
                else if (kha.Key.Length < bSalt.Length)
                {
                    byte[] bKey = new byte[kha.Key.Length];
                    Buffer.BlockCopy(bSalt, 0, bKey, 0, bKey.Length);
                    kha.Key = bKey;
                }
                else
                {
                    byte[] bKey = new byte[kha.Key.Length];
                    for (int iter = 0; iter < bKey.Length;)
                    {
                        int len = Math.Min(bSalt.Length, bKey.Length - iter);
                        Buffer.BlockCopy(bSalt, 0, bKey, iter, len);
                        iter += len;
                    }
                    kha.Key = bKey;
                }
                bRet = kha.ComputeHash(bIn);
            }
            else
            {
                byte[] bAll = new byte[bSalt.Length + bIn.Length];
                Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
                Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
                bRet = hm.ComputeHash(bAll);
            }
        }

        return Convert.ToBase64String(bRet);
    }
}

