using System;

namespace SynergyWebServices.DAL;

public class Ocmpassname
{
	public int PassNameId { get; set; }

	public string PassName { get; set; }

	public string PassShortName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
