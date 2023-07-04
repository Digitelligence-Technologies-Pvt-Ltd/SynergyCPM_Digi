using System;

namespace SynergyWebServices.DAL;

public class MailMaster
{
	public long MailId { get; set; }

	public string UserType { get; set; }

	public string EmailId { get; set; }

	public Guid? UserId { get; set; }

	public string UserName { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public long? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public long? ModifiedBy { get; set; }
}
