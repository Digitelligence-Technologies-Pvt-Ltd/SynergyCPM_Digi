using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
public class SMController : ControllerBase
{
	private readonly ISM ism;

	public SMController(ISM _ism)
	{
		ism = _ism;
	}

	[Route("SM/AddAndEditSM")]
	[HttpPost]
	public async Task<IActionResult> AddAndEditSM(SMEntity.SMCustom data)
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
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = ism.AddAndEditSM(data, 0L);
		return Ok(response);
	}

	[Route("SM/ViewMultipleSM")]
	[HttpGet]
	public async Task<IActionResult> ViewMultipleSM()
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
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = ism.ViewMultipleSM();
		return Ok(response);
	}

	[Route("SM/ViewSMById")]
	[HttpGet]
	public async Task<IActionResult> ViewSMById(int managerId)
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
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = ism.ViewSMById(managerId);
		return Ok(response);
	}

	[Route("SM/ViewSMByCPId")]
	[HttpGet]
	public async Task<IActionResult> ViewSMByCPId(string userId)
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
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = ism.ViewSMByCPId(userId);
		return Ok(response);
	}

	[Route("SM/DeleteSM")]
	[HttpGet]
	public async Task<IActionResult> DeleteSM(int managerId)
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
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = ism.DeleteSM(managerId, 0L);
		return Ok(response);
	}

	[Route("SM/ArchiveSM")]
	[HttpGet]
	public async Task<IActionResult> ArchiveSM(int managerId)
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
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = ism.ArchiveSM(managerId, 0L);
		return Ok(response);
	}
}
