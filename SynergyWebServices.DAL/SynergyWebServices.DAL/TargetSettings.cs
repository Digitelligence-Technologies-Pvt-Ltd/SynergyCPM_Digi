using System;

namespace SynergyWebServices.DAL;

public class TargetSettings
{
	public int Tsid { get; set; }

	public int Cpid { get; set; }

	public string TargetMonth { get; set; }

	public string TargetMonthId { get; set; }

	public int Targets { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Status { get; set; }
}
