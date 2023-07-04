namespace SynergyWebServices.DAL;

public class RiceOaequipTableData
{
	public int Roatbid { get; set; }

	public int Roaid { get; set; }

	public string ModelNum { get; set; }

	public int Quantity { get; set; }

	public string UnitPrice { get; set; }

	public string TotalPrice { get; set; }

	public string ModelDesc { get; set; }

	public string Exclusion { get; set; }

	public int ProductModelId { get; set; }

	public int ProductId { get; set; }

	public int MasterProductId { get; set; }

	public string MasterProductName { get; set; }

	public string ProductName { get; set; }

	public string Pass { get; set; }

	public string MotorType { get; set; }

	public string PolishRequirement { get; set; }

	public string TypeRice { get; set; }

	public string PaddySize { get; set; }

	public string Capacity { get; set; }

	public string MotorQ { get; set; }

	public string MotorRating { get; set; }

	public int IsSotstatus { get; set; }

	public virtual MasterProducts MasterProduct { get; set; }

	public virtual Products Product { get; set; }

	public virtual ProductModel ProductModel { get; set; }

	public virtual RiceOaequipGeneralData Roa { get; set; }
}
