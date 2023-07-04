using System;

namespace SynergyWebServices.DAL;

public class OcmaccessoriesNew
{
	public int AccessoriesId { get; set; }

	public string AccessoriesName { get; set; }

	public int PassId { get; set; }

	public string PassName { get; set; }

	public string PathName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
