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
public class ReportController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly IReport report;

	public ReportController(IOptions<AppSettings> appSettings, IReport _report)
	{
		_appSettings = appSettings.Value;
		report = _report;
	}

	[HttpGet]
	[Route("Report/GetAllStoreProcedures")]
	public async Task<IActionResult> GetAllStoreProcedures()
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
		CommonEntity.CommonResponse response = report.GetAllStoreProcedures();
		return Ok(response);
	}

	[HttpPost]
	[Route("Report/GenerateReport")]
	public async Task<IActionResult> GenerateReport(ReportEntity.ReportEngineMaster data)
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
		CommonEntity.CommonResponse response = report.GenerateReport(data);
		return Ok(response);
	}

	[HttpPost]
	[Route("Report/MDBReport")]
	public async Task<IActionResult> MDBReport(ReportEntity.MdbReportCustom data)
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
		CommonEntity.CommonResponse response = report.MDBReport(data);
		return Ok(response);
	}

	[HttpPost]
	[Route("Report/QuotationReport")]
	public async Task<IActionResult> QuotationReport(ReportEntity.QuotationReport data)
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
		CommonEntity.CommonResponse response = report.QuotationReport(data);
		return Ok(response);
	}
}
