using System;

namespace SynergyWebServices.DAL;

public class MailSendCredentials
{
	public int Msid { get; set; }

	public string FromMail { get; set; }

	public string Password { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsStatus { get; set; }

	public int IsDrop { get; set; }
}
