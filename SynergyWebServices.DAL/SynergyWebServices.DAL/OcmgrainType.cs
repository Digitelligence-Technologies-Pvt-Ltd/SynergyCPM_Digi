using System;

namespace SynergyWebServices.DAL;

public class OcmgrainType
{
	public int GrainTypeId { get; set; }

	public string GrainName { get; set; }

	public string GrainShortName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
