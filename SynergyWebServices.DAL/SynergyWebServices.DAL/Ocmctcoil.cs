using System;

namespace SynergyWebServices.DAL;

public class Ocmctcoil
{
	public int CtcoilId { get; set; }

	public string CtcoilDescription { get; set; }

	public string PartNumber { get; set; }

	public int MasterProductId { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public virtual MasterProducts MasterProduct { get; set; }
}
