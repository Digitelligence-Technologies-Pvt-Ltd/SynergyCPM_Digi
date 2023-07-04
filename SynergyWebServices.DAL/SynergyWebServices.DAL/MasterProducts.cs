using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class MasterProducts
{
	public int MasterProductId { get; set; }

	public string MasterProductName { get; set; }

	public string MasterProductDescriptor { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public virtual ICollection<Ocmaccessories> Ocmaccessories { get; set; }

	public virtual ICollection<Ocmbrake> Ocmbrake { get; set; }

	public virtual ICollection<Ocmctcoil> Ocmctcoil { get; set; }

	public virtual ICollection<Ocmdrive> Ocmdrive { get; set; }

	public virtual ICollection<Ocmmotor> Ocmmotor { get; set; }

	public virtual ICollection<OcmpassageSticker> OcmpassageSticker { get; set; }

	public virtual ICollection<OcmreducerRing> OcmreducerRing { get; set; }

	public virtual ICollection<Ocmsieve> Ocmsieve { get; set; }

	public virtual ICollection<Ocmstone> Ocmstone { get; set; }

	public virtual ICollection<Products> Products { get; set; }

	public virtual ICollection<RiceOaequipTableData> RiceOaequipTableData { get; set; }

	public virtual ICollection<Sotrm> Sotrm { get; set; }

	public MasterProducts()
	{
		Ocmaccessories = new HashSet<Ocmaccessories>();
		Ocmbrake = new HashSet<Ocmbrake>();
		Ocmctcoil = new HashSet<Ocmctcoil>();
		Ocmdrive = new HashSet<Ocmdrive>();
		Ocmmotor = new HashSet<Ocmmotor>();
		OcmpassageSticker = new HashSet<OcmpassageSticker>();
		OcmreducerRing = new HashSet<OcmreducerRing>();
		Ocmsieve = new HashSet<Ocmsieve>();
		Ocmstone = new HashSet<Ocmstone>();
		Products = new HashSet<Products>();
		RiceOaequipTableData = new HashSet<RiceOaequipTableData>();
		Sotrm = new HashSet<Sotrm>();
	}
}
