namespace SynergyWebServices.DAL;

public class QgspareTableData
{
	public int Qgtbid { get; set; }

	public int Qgid { get; set; }

	public int Quantity { get; set; }

	public string UnitPrice { get; set; }

	public string TotalPrice { get; set; }

	public string Description { get; set; }

	public int ProductModelSparesId { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }

	public virtual QgspareGeneralData Qg { get; set; }
}
