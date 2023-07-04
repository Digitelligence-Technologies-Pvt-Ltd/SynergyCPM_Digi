using System;

namespace SynergyWebServices.DAL;

public class LoginData
{
	public int UserLoginId { get; set; }

	public Guid UserId { get; set; }

	public string UserName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public DateTime? LoginDate { get; set; }

	public DateTime? LogOutDate { get; set; }

	public string LoginTime { get; set; }

	public string LogOutTime { get; set; }

	public string Duration { get; set; }

	public string Channelpartnerid { get; set; }

	public int IsStatus { get; set; }

	public long ValidityPeriodTicks { get; set; }

	public long VlidityPeriodTicks { get; set; }

	public long ValidityPeriodTicks1 { get; set; }

	public string ZoneId { get; set; }
}
