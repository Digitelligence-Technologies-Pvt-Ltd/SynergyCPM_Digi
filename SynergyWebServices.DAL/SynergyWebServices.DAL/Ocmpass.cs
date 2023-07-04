using System;

namespace SynergyWebServices.DAL;

public class Ocmpass
{
	public int PassId { get; set; }

	public string PassName { get; set; }

	public string PassShortName { get; set; }

	public string PathName { get; set; }

	public int GrainTypeId { get; set; }

	public string GrainName { get; set; }

	public int ProcessId { get; set; }

	public string ProcessName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int ProductId { get; set; }

	public string ProductName { get; set; }
}
