namespace SynergyWebServices.DAL;

public class OaequipTableData
{
	public int Oatbid { get; set; }

	public int Oaid { get; set; }

	public int Quantity { get; set; }

	public string UnitPrice { get; set; }

	public string TotalPrice { get; set; }

	public string ModelDesc { get; set; }

	public string Exclusion { get; set; }

	public int ProductModelId { get; set; }

	public int IsQuantity { get; set; }

	public int IsModelHod { get; set; }

	public virtual OaequipGeneralData Oa { get; set; }

	public virtual ProductModel ProductModel { get; set; }
}
