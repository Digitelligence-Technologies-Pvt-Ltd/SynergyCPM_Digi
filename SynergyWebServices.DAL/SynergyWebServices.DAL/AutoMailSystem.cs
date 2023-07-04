using System;

namespace SynergyWebServices.DAL;

public class AutoMailSystem
{
	public int Amsid { get; set; }

	public int Cpid { get; set; }

	public DateTime? MailSentDate { get; set; }

	public int IsSent { get; set; }
}
