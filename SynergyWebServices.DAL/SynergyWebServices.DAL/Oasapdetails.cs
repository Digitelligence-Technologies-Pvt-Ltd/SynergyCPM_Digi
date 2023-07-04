using System;

namespace SynergyWebServices.DAL;

public class Oasapdetails
{
	public int Sapid { get; set; }

	public int OrderId { get; set; }

	public string CustId { get; set; }

	public string Sapno { get; set; }

	public DateTime? Sapdate { get; set; }

	public string Sapcomments { get; set; }

	public DateTime? Oadate { get; set; }

	public int Cpid { get; set; }

	public int IsRice { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public DateTime? DispatchedDate { get; set; }
}
