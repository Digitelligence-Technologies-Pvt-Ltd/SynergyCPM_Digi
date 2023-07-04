using System;

namespace SynergyWebServices.DAL;

public class LeadFollowUptbl
{
	public int Lfid { get; set; }

	public int Lerid { get; set; }

	public DateTime? FollowUpDate { get; set; }

	public string FollowUpType { get; set; }

	public string FollowUpDescription { get; set; }

	public int Cpid { get; set; }

	public int IsStatus { get; set; }

	public int IsDeleted { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int CreatedBy { get; set; }

	public string FollowUp { get; set; }

	public string TimeLine { get; set; }

	public virtual LeadEnquiryRevised Ler { get; set; }
}
