using System;

namespace SynergyWebServices.DAL;

public class CpmailIdTo
{
	public int Ceid { get; set; }

	public string EmailId { get; set; }

	public string Designation { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int Cpid { get; set; }

	public int ZonalManagerId { get; set; }
}
