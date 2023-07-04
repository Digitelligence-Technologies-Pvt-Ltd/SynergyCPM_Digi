using System;

namespace SynergyWebServices.DAL;

public class AvailSpareQuantity
{
	public int Asid { get; set; }

	public int Cpid { get; set; }

	public int Isold { get; set; }

	public int AvailableStock { get; set; }

	public string Month { get; set; }

	public string Week { get; set; }

	public int MinCpStock { get; set; }

	public int ProductModelSparesId { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }
}
