using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class QgequipTableData
{
	public int Qgtbid { get; set; }

	public int Qgid { get; set; }

	public string ModelNum { get; set; }

	public int Quantity { get; set; }

	public string UnitPrice { get; set; }

	public string TotalPrice { get; set; }

	public string Exclusion { get; set; }

	public int ProductModelId { get; set; }

	public string ModelDesc { get; set; }

	public int ProductId { get; set; }

	public int MasterProductId { get; set; }

	public string MasterProductName { get; set; }

	public string ProductName { get; set; }

	public string TypeRice { get; set; }

	public string PaddySize { get; set; }

	public string Pass { get; set; }

	public string Capacity { get; set; }

	public string PolishRequirement { get; set; }

	public string MotorQ { get; set; }

	public string MotorType { get; set; }

	public string MotorRating { get; set; }

	public int IsSotstatus { get; set; }

	public string ProductModelName { get; set; }

	public virtual ProductModel ProductModel { get; set; }

	public virtual QgequipGeneralData Qg { get; set; }

	public virtual ICollection<RiceOaequipGeneralData> RiceOaequipGeneralData { get; set; }

	public QgequipTableData()
	{
		RiceOaequipGeneralData = new HashSet<RiceOaequipGeneralData>();
	}
}
