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
public class VisitsController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly IVisits visits;

	public VisitsController(IOptions<AppSettings> appSettings, IVisits _visits)
	{
		_appSettings = appSettings.Value;
		visits = _visits;
	}

	[HttpPost]
	[Route("Visits/AddAndEditVisits")]
	public async Task<IActionResult> AddAndEditVisits(VisitsEntity.VisitsCustom data)
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
		new CommonEntity.CommonResponseWithIds();
		CommonEntity.CommonResponseWithIds response = visits.AddAndEditVisits(data, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/ViewMultipleVisits")]
	public async Task<IActionResult> ViewMultipleVisits()
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
		CommonEntity.CommonResponse response = visits.ViewMultipleVisits();
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/ViewMultipleVisitsBasedOnUserId")]
	public async Task<IActionResult> ViewMultipleVisitsBasedOnUserId(string userId)
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
		CommonEntity.CommonResponse response = visits.ViewMultipleVisitsBasedOnUserId(userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/ViewMultipleVisitsBasedOnUserAndCustomerId")]
	public async Task<IActionResult> ViewMultipleVisitsBasedOnUserAndCustomerId(string userId, string companyUniqueId)
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
		CommonEntity.CommonResponse response = visits.ViewMultipleVisitsBasedOnUserAndCustomerId(userId, companyUniqueId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/ViewVisitsById")]
	public async Task<IActionResult> ViewVisitsById(int visitsId)
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
		CommonEntity.CommonResponse response = visits.ViewVisitsById(visitsId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/DeleteVisits")]
	public async Task<IActionResult> DeleteVisits(int visitsId)
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
		CommonEntity.CommonResponse response = visits.DeleteVisits(visitsId, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/ArchiveVisits")]
	public async Task<IActionResult> ArchiveVisits(int visitsId)
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
		CommonEntity.CommonResponse response = visits.ArchiveVisits(visitsId, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/GetAllCustomerForVisit")]
	public async Task<IActionResult> GetAllCustomerForVisit(string customerName, string userId)
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
		CommonEntity.CommonResponse response = visits.GetAllCustomerForVisit(customerName, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/GetAllVisitsPurpose")]
	public async Task<IActionResult> GetAllVisitsPurpose()
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
		CommonEntity.CommonResponse response = visits.GetAllVisitsPurpose(0L);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/GetAllVisitsEquipments")]
	public async Task<IActionResult> GetAllVisitsEquipments(string masterproductIds)
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
		CommonEntity.CommonResponse response = visits.GetAllVisitsEquipments(masterproductIds, 0L);
		return Ok(response);
	}

	[HttpGet]
	[Route("Visits/GetAllVisitsMasterProducts")]
	public async Task<IActionResult> GetAllVisitsMasterProducts()
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
		CommonEntity.CommonResponse response = visits.GetAllVisitsMasterProducts(0L);
		return Ok(response);
	}
}
