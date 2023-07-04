using System;

namespace SynergyWebServices.DAL;

public class VisitHistory
{
	public long VisitHistoryId { get; set; }

	public string UserId { get; set; }

	public string CompanyUniqueId { get; set; }

	public long? VisitPurpose { get; set; }

	public DateTime? VisitDateTime { get; set; }

	public string VisitStatus { get; set; }

	public string ProductModelId { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public long? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public long? ModifiedBy { get; set; }

	public string Comments { get; set; }

	public DateTime? NextVisitDate { get; set; }

	public int? CpEnginneerId { get; set; }

	public string BuId { get; set; }

	public int? SalesManagerId { get; set; }

	public string MasterProducts { get; set; }

	public bool? IsCall { get; set; }

	public string VisitType { get; set; }
}
