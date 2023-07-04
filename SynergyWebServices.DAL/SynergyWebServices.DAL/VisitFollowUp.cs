using System;

namespace SynergyWebServices.DAL;

public class VisitFollowUp
{
	public int VisitFollowUpId { get; set; }

	public int? VisitId { get; set; }

	public int? VisitPurpose { get; set; }

	public string VisitComment { get; set; }

	public DateTime? NextVisitDate { get; set; }

	public bool? IsReminderSent { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int? CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public int? ModifiedBy { get; set; }
}
