using System;

namespace SynergyWebServices.DAL;

public class Ocmprocessname
{
	public int ProcessNameId { get; set; }

	public string ProcessName { get; set; }

	public string ProcessShortName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
