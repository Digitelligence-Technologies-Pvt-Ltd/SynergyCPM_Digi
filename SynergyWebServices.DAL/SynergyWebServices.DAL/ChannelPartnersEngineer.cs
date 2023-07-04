using System;

namespace SynergyWebServices.DAL;

public class ChannelPartnersEngineer
{
	public int ChannelPartnersEngineerId { get; set; }

	public int? Cpid { get; set; }

	public string Name { get; set; }

	public string PhoneNumber { get; set; }

	public string EmaiId { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public int? ModifiedBy { get; set; }

	public string EscalationMails { get; set; }
}
