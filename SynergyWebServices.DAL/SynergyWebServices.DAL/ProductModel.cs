using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class ProductModel
{
	public int ProductModelId { get; set; }

	public string ProductModelName { get; set; }

	public string ProductModelDesc { get; set; }

	public string ProductModelExclusion { get; set; }

	public string UnitPrice { get; set; }

	public string QuoteVaildTill { get; set; }

	public string DeliveryTime { get; set; }

	public int ProductId { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public string Prmodeldesc { get; set; }

	public int MachineCount { get; set; }

	public int ApprovedCount { get; set; }

	public int Pr { get; set; }

	public virtual Products Product { get; set; }

	public virtual ICollection<MachineInventory> MachineInventory { get; set; }

	public virtual ICollection<OaequipTableData> OaequipTableData { get; set; }

	public virtual ICollection<QgequipTableData> QgequipTableData { get; set; }

	public virtual ICollection<RiceOaequipTableData> RiceOaequipTableData { get; set; }

	public ProductModel()
	{
		MachineInventory = new HashSet<MachineInventory>();
		OaequipTableData = new HashSet<OaequipTableData>();
		QgequipTableData = new HashSet<QgequipTableData>();
		RiceOaequipTableData = new HashSet<RiceOaequipTableData>();
	}
}
