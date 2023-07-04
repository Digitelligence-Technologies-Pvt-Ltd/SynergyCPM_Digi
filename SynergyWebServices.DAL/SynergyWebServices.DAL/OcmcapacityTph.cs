using System;

namespace SynergyWebServices.DAL;

public class OcmcapacityTph
{
	public int CapacityTphid { get; set; }

	public string CapacityTphname { get; set; }

	public string CapacityTphshortName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
