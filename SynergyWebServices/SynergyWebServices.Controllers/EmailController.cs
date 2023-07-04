using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
public class EmailController : ControllerBase
{
	private readonly EmailEntity.SmptSettings _appSettings;

	private readonly IEmail email;

	public EmailController(IOptions<EmailEntity.SmptSettings> appSettings, IEmail _email)
	{
		_appSettings = appSettings.Value;
		email = _email;
	}

	[HttpGet]
	[Route("Email/SendMailToViewNextFollowUpDates")]
	public async Task<IActionResult> SendMailToViewNextFollowUpDates()
	{
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = email.SendMailToViewNextFollowUpDates();
		return Ok(response);
	}

	[HttpGet]
	[Route("Email/SendMailToViewDues")]
	public async Task<IActionResult> SendMailToViewDues()
	{
		new CommonEntity.CommonResponse();
		CommonEntity.CommonResponse response = email.SendMailToViewDues();
		return Ok(response);
	}
}
