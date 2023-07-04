using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
[Authorize]
public class MDBMasterController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly IMDBMaster mdb;

	public MDBMasterController(IOptions<AppSettings> appSettings, IMDBMaster _mdb)
	{
		_appSettings = appSettings.Value;
		mdb = _mdb;
	}

	[HttpPost]
	[Route("MDB/AddAndEditMDB")]
	public async Task<IActionResult> AddAndEditMDB(MDBMasterEntity.MDBMasterEntityCustom data)
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
		CommonEntity.CommonResponse response = mdb.AddAndEditMDBMaster(data);
		return Ok(response);
	}

	[HttpPost]
	[Route("MDB/ViewMultipleMDB")]
	public async Task<IActionResult> ViewMultipleMDB(MDBMasterEntity.MDBMultiple data)
	{
		var clm = User.Claims;
		if (base.HttpContext.User.Identity is ClaimsIdentity identity)
		{
			_ = identity.Claims;
		var user1 =	(from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
		var user2 =	(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		CommonEntity.CommonResponseCount response = mdb.ViewMultipleMDBMaster(data);
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/ViewMDBById")]
	public async Task<IActionResult> ViewMDBById(int mdbId)
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
		CommonEntity.CommonResponse response = mdb.ViewMDBMasterById(mdbId);
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/CheckMDBMaster")]
	public async Task<IActionResult> CheckMDBMaster(string phoneNumber)
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
		CommonEntity.CommonResponse response = mdb.CheckMDBMaster(phoneNumber);
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/DeleteMDB")]
	public async Task<IActionResult> DeleteMDB(int mdbId)
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
		CommonEntity.CommonResponse response = mdb.DeleteMDBMaster(mdbId, userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/ArchiveMDB")]
	public async Task<IActionResult> ArchiveMDB(int mdbId)
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
		CommonEntity.CommonResponse response = mdb.ArchiveMDBMaster(mdbId, userId);
		return Ok(response);
	}

	[HttpGet]
	
	[Route("MDB/ViewMultipleStates")]
	public async Task<IActionResult> ViewMultipleStates()
	{

		if (base.HttpContext.User.Identity is ClaimsIdentity identity)
		{
		var	user1 = HttpContext.User.Claims
				.Select(c => new {c.Type, c.Value}).FirstOrDefault();
			
			(from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
            var user2 = (from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		CommonEntity.CommonResponse response = mdb.ViewMultipleStates();
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/ViewMultipleDistricts")]
	public async Task<IActionResult> ViewMultipleDistricts(int stateId)
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
		CommonEntity.CommonResponse response = mdb.ViewMultipleDistricts(stateId);
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/ViewMultiplePinCode")]
	public async Task<IActionResult> ViewMultiplePinCode(string district)
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
		CommonEntity.CommonResponse response = mdb.ViewMultiplePinCode(district);
		return Ok(response);
	}

	[HttpGet]
	[Route("MDB/ViewMultipleMDBMasterBySearchItem")]
	public async Task<IActionResult> ViewMultipleMDBMasterBySearchItem(string searchTerm, string userId)
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
		CommonEntity.CommonResponseCount response = mdb.ViewMultipleMDBMasterBySearchItem(searchTerm, userId);
		return Ok(response);
	}
}
