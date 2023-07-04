using System;

namespace SynergyWebServices.DAL;

public class OverallReport
{
	public int Orid { get; set; }

	public int Slc { get; set; }

	public int Blc { get; set; }

	public int Cpid { get; set; }

	public DateTime? StartDate { get; set; }

	public DateTime? EndDate { get; set; }

	public int WeekNumber { get; set; }

	public int Month { get; set; }

	public int Year { get; set; }

	public int Sqs { get; set; }

	public int Bqs { get; set; }

	public int Sob { get; set; }

	public int Bob { get; set; }

	public int Bmd { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
