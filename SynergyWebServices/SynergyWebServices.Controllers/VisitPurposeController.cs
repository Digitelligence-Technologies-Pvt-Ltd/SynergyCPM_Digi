using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
public class VisitPurposeController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly IVisitPurpose channelPartnersEngineerId;

	public VisitPurposeController(IOptions<AppSettings> appSettings, IVisitPurpose _channelPartnersEngineerId)
	{
		_appSettings = appSettings.Value;
		channelPartnersEngineerId = _channelPartnersEngineerId;
	}

	[HttpPost]
	[Route("VisitPurpose/AddAndEditVisitPurpose")]
	public async Task<IActionResult> AddAndEditVisitPurpose(VisitPurposeEntity.VisitPurposeCustom data)
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
		CommonEntity.CommonResponse response = channelPartnersEngineerId.AddAndEditVisitPurpose(data, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("VisitPurpose/ViewMultipleVisitPurpose")]
	public async Task<IActionResult> ViewMultipleVisitPurpose()
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
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewMultipleVisitPurpose();
		return Ok(response);
	}

	[HttpGet]
	[Route("VisitPurpose/ViewVisitPurposeById")]
	public async Task<IActionResult> ViewVisitPurposeById(int visitPurposeId)
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
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ViewVisitPurposeById(visitPurposeId);
		return Ok(response);
	}

	[HttpGet]
	[Route("VisitPurpose/DeleteVisitPurpose")]
	public async Task<IActionResult> DeleteVisitPurpose(int visitPurposeId)
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
		CommonEntity.CommonResponse response = channelPartnersEngineerId.DeleteVisitPurpose(visitPurposeId, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("VisitPurpose/ArchiveVisitPurpose")]
	public async Task<IActionResult> ArchiveVisitPurpose(int visitPurposeId)
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
		CommonEntity.CommonResponse response = channelPartnersEngineerId.ArchiveVisitPurpose(visitPurposeId, userId);
		return Ok(response);
	}
}
