using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class Products
{
	public int ProductId { get; set; }

	public string ProductName { get; set; }

	public string ProductDescriptor { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int MasterProductId { get; set; }

	public virtual MasterProducts MasterProduct { get; set; }

	public virtual ICollection<ProductModel> ProductModel { get; set; }

	public virtual ICollection<RiceOaequipTableData> RiceOaequipTableData { get; set; }

	public virtual ICollection<Sotrm> Sotrm { get; set; }

	public Products()
	{
		ProductModel = new HashSet<ProductModel>();
		RiceOaequipTableData = new HashSet<RiceOaequipTableData>();
		Sotrm = new HashSet<Sotrm>();
	}
}
