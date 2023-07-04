using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class ProductModelSpare
{
	public int ProductModelSparesId { get; set; }

	public string ProductModelSparesName { get; set; }

	public string ProductModelSparesDesc { get; set; }

	public string QuoteVaildTill { get; set; }

	public string DeliveryTime { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public string AgentPrice { get; set; }

	public string CustomerPrice { get; set; }

	public string ProductSpareNameDesc { get; set; }

	public int BuhlerPresentStock { get; set; }

	public virtual ICollection<AvailSpareQuantity> AvailSpareQuantity { get; set; }

	public virtual ICollection<InwardSpare> InwardSpare { get; set; }

	public virtual ICollection<Mfrparts> Mfrparts { get; set; }

	public virtual ICollection<MinSpareEquipQuantity> MinSpareEquipQuantity { get; set; }

	public virtual ICollection<OutwardMfr> OutwardMfr { get; set; }

	public virtual ICollection<OutwardSpare> OutwardSpare { get; set; }

	public virtual ICollection<QgspareTableData> QgspareTableData { get; set; }

	public ProductModelSpare()
	{
		AvailSpareQuantity = new HashSet<AvailSpareQuantity>();
		InwardSpare = new HashSet<InwardSpare>();
		Mfrparts = new HashSet<Mfrparts>();
		MinSpareEquipQuantity = new HashSet<MinSpareEquipQuantity>();
		OutwardMfr = new HashSet<OutwardMfr>();
		OutwardSpare = new HashSet<OutwardSpare>();
		QgspareTableData = new HashSet<QgspareTableData>();
	}
}
