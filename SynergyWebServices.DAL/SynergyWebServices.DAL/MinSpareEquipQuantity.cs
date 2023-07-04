using System;

namespace SynergyWebServices.DAL;

public class MinSpareEquipQuantity
{
	public int Msid { get; set; }

	public int Minimumstock { get; set; }

	public int ProductModelSparesId { get; set; }

	public int ProductModelId { get; set; }

	public int IsOld { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public DateTime? MinDate { get; set; }

	public int PresentStock { get; set; }

	public int CpminStock { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }
}
