using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
public class DashboardController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly IDashboard dashboardIAL;

	public DashboardController(IOptions<AppSettings> appSettings, IDashboard _dashboardIAL)
	{
		_appSettings = appSettings.Value;
		dashboardIAL = _dashboardIAL;
	}

	[HttpGet]
	[Route("Dashboard/GetDashboardDetails")]
	public async Task<IActionResult> GetDashboardDetails(string userId)
	{
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = dashboardIAL.GetDashboardDetails(userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Dashboard/GetCPDetailsInDashboard")]
	public async Task<IActionResult> GetCPDetailsInDashboard(string userId)
	{
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = dashboardIAL.GetCPDetailsInDashboard(userId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Dashboard/GetCPDetailsInDashboardForQuotation")]
	public async Task<IActionResult> GetCPDetailsInDashboardForQuotation(string userId)
	{
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = dashboardIAL.GetCPDetailsInDashboardForQuotation(userId);
		return Ok(response);
	}

    [HttpPost]
    [Route("Dashboard/UpdateCHFValue")]
    public async Task<IActionResult> UpdateCHFValue(string CHFValue)
    {
        new CommonEntity.CommonResponse();
        CommonEntity.CommonResponse response = dashboardIAL.UpdateCHFValue(Convert.ToDecimal(CHFValue));
        return Ok(response);
    }

	[HttpPost]
	[Route("Dashboard/GetDashboardFilter")]
	public async Task<IActionResult> GetDashboardFilter(string cpId, string zoneId, string buId, string userId)
	{
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = dashboardIAL.GetDashboardFilter(cpId, zoneId, buId, userId);
			return Ok(response);

    }
}
