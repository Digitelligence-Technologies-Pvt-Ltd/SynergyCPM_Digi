using System;

namespace SynergyWebServices.DAL;

public class TargetSettingsLead
{
	public int Tsid { get; set; }

	public string MachineType { get; set; }

	public string TargetType { get; set; }

	public int Cpid { get; set; }

	public string Year { get; set; }

	public string Month { get; set; }

	public int MonthId { get; set; }

	public int Targets { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int Status { get; set; }
}
