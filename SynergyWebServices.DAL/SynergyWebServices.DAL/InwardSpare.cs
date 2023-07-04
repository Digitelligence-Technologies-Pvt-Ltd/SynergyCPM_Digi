namespace SynergyWebServices.DAL;

public class InwardSpare
{
	public int InwardId { get; set; }

	public string InwardMonth { get; set; }

	public string InwardType { get; set; }

	public string Ponumber { get; set; }

	public int ProductModelSparesId { get; set; }

	public int QuantityOrdered { get; set; }

	public string TotalValue { get; set; }

	public int QuantityRemaining { get; set; }

	public int IsDeleted { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }
}
