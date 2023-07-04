using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
public class CPEngineerController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly ICPEngineer channelPartnersEngineerId;

	public CPEngineerController(IOptions<AppSettings> appSettings, ICPEngineer _channelPartnersEngineerId)
	{
		_appSettings = appSettings.Value;
		channelPartnersEngineerId = _channelPartnersEngineerId;
	}

	[HttpPost]
	[Route("CPEngineer/AddAndEditCPEngineer")]
	public async Task<IActionResult> AddAndEditCPEngineer(CPEngineerEntity.CPEngineerCustom data)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		long userId = Convert.ToInt32(id);
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = channelPartnersEngineerId.AddAndEditCPEngineer(data, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/ViewMultipleCPEngineer")]
	public async Task<IActionResult> ViewMultipleCPEngineer()
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewMultipleCPEngineer();
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/ViewMultipleCPEngineerBasedOnUserId")]
	public async Task<IActionResult> ViewMultipleCPEngineerBasedOnUserId(string userId)
	{
		if (base.HttpContext.User.Identity is ClaimsIdentity identity)
		{
			_ = identity.Claims;
			(from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewMultipleCPEngineerBasedOnUserId(userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/ViewMultipleCPEngineerBasedOnCPId")]
	public async Task<IActionResult> ViewMultipleCPEngineerBasedOnCPId(int cpId)
	{
		if (base.HttpContext.User.Identity is ClaimsIdentity identity)
		{
			_ = identity.Claims;
			(from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewMultipleCPEngineerBasedOnCPId(cpId);
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/ViewCPEngineerById")]
	public async Task<IActionResult> ViewCPEngineerById(int channelPartnersEngineerIdId)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewCPEngineerById(channelPartnersEngineerIdId);
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/DeleteCPEngineer")]
	public async Task<IActionResult> DeleteCPEngineer(int channelPartnersEngineerIdId)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		long userId = Convert.ToInt32(id);
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = channelPartnersEngineerId.DeleteCPEngineer(channelPartnersEngineerIdId, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/ArchiveCPEngineer")]
	public async Task<IActionResult> ArchiveCPEngineer(int channelPartnersEngineerIdId)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		long userId = Convert.ToInt32(id);
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ArchiveCPEngineer(channelPartnersEngineerIdId, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("CPEngineer/ViewMultipleCP")]
	public async Task<IActionResult> ViewMultipleCP()
	{
		if (base.HttpContext.User.Identity is ClaimsIdentity identity)
		{
			_ = identity.Claims;
			(from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewMultipleCP();
		return Ok(response);
	}
	[HttpGet]
    [Route("CPEngineer/ViewZone")]
    public async Task<IActionResult> ViewZone()
    {
        if (base.HttpContext.User.Identity is ClaimsIdentity identity)
        {
            _ = identity.Claims;
            (from m in identity.Claims
             where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
             select m.Value).FirstOrDefault();
            (from m in identity.Claims
             where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
             select m.Value).FirstOrDefault();
        }
        CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewZone();
        return Ok(response);
    }

    [HttpGet]
	[Route("CPEngineer/GetUserType")]
	public async Task<IActionResult> GetUserType(string userId)
	{
		if (base.HttpContext.User.Identity is ClaimsIdentity identity)
		{
			_ = identity.Claims;
			(from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		CommonEntity.CommonResponse response = channelPartnersEngineerId.GetUserType(userId);
		return Ok(response);
	}
}
