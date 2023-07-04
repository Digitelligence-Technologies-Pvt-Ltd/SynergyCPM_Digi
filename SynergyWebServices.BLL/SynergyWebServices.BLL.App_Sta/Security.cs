using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SynergyWebServices.BLL.App_Start;

public class Security
{
	public static string CreatePasswordHash(string userhash1, string password)
	{
		return GetSwcSHA1(password + userhash1);
	}

	public static string GetSwcSHA1(string value)
	{
		byte[] data = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
		string sh1 = "";
		for (int i = 0; i < data.Length; i++)
		{
			sh1 += data[i].ToString("x2").ToUpperInvariant();
		}
		return sh1;
	}

	public string Encrypt(string clearText)
	{
		string encrpttext = null;
		string plaintext = clearText;
		string EncryptionKey = "MAKV2SPBNI99212";
		byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
		using Aes encryptor = Aes.Create();
		Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[13]
		{
			73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
			100, 101, 118
		});
		encryptor.Key = pdb.GetBytes(32);
		encryptor.IV = pdb.GetBytes(16);
		using (MemoryStream ms = new MemoryStream())
		{
			using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
			{
				cs.Write(clearBytes, 0, clearBytes.Length);
				cs.Close();
			}
			clearText = Convert.ToBase64String(ms.ToArray());
		}
		return CreatePasswordHash(clearText, plaintext);
	}

	public string Decrypt(string cipherText)
	{
		try
		{
			string EncryptionKey = "MAKV2SPBNI99212";
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			using Aes encryptor = Aes.Create();
			Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[13]
			{
				73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
				100, 101, 118
			});
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			using MemoryStream ms = new MemoryStream();
			using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
			{
				cs.Write(cipherBytes, 0, cipherBytes.Length);
			}
			cipherText = Encoding.Unicode.GetString(ms.ToArray());
			return cipherText;
		}
		catch (Exception)
		{
			return cipherText;
		}
	}
}
