using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using log4net.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;
[AllowAnonymous]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly AppSettings _appSettings;
    private readonly IAccount _account;
    public LoginController(IOptions<AppSettings> appSettings, IAccount account)
    {
        _appSettings = appSettings.Value;
        _account = account;
    }

    [AllowAnonymous]
    [HttpPost]
    
    [Route("Login")]
    public async Task<IActionResult> Login(AccountsEntity.Login data)
    {
        CommonEntity.CommonResponse response = await _account.Login(data);
        return Ok(response);

    }

    [AllowAnonymous]
    [HttpPost]
    [Route("LoginUID")]
    public async Task<IActionResult> LoginUID(string data)
    {
        CommonEntity.CommonResponse response = await _account.LoginUID( data);
        return Ok(response);
    }
}