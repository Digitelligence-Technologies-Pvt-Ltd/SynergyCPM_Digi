using System;

namespace SynergyWebServices.DAL;

public class AutoMailer
{
	public int Amid { get; set; }

	public int Otperiod { get; set; }

	public string Module { get; set; }

	public int NullPeriod { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsStatus { get; set; }
}
