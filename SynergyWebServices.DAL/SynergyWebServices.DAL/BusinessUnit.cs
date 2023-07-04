using System;

namespace SynergyWebServices.DAL;

public class BusinessUnit
{
	public int BuId { get; set; }

	public string BuName { get; set; }

	public string Description { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public int? ModifiedBy { get; set; }
}
