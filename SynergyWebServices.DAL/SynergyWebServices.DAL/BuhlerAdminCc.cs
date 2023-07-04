using System;

namespace SynergyWebServices.DAL;

public class BuhlerAdminCc
{
	public int Baid { get; set; }

	public string Name { get; set; }

	public string EmailId { get; set; }

	public string Designation { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public string Type { get; set; }

	public int ZonalManagerId { get; set; }
}
