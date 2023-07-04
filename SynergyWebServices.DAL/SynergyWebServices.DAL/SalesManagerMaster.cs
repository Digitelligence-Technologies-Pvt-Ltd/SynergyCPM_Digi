using System;

namespace SynergyWebServices.DAL;

public class SalesManagerMaster
{
	public int ManagerId { get; set; }

	public string ManagerName { get; set; }

	public string ManagerEmailId { get; set; }

	public string ManagerPhoneNumber { get; set; }

	public string CpIds { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public int? ModifiedBy { get; set; }

	public string UniqueId { get; set; }
}
