using System;

namespace SynergyWebServices.DAL;

public class VisitPurpose
{
	public long VisitPurposeId { get; set; }

	public string VisitPurpose1 { get; set; }

	public string Description { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public long? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public long? Modifiedby { get; set; }
}
