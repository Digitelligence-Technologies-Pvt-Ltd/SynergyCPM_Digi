using System;

namespace SynergyWebServices.DAL;

public class MachineDispatch
{
	public int MachineDispatchId { get; set; }

	public int MachineInventoryId { get; set; }

	public int Oaid { get; set; }

	public string Oanumber { get; set; }

	public string InvoiceNumber { get; set; }

	public DateTime? InvoiceDate { get; set; }

	public string Lrnumber { get; set; }

	public DateTime? DispatchDate { get; set; }

	public DateTime? Oadate { get; set; }

	public DateTime? CommissionDate { get; set; }

	public string Transporter { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsDispatched { get; set; }

	public int Mdbid { get; set; }

	public int Cpid { get; set; }

	public int ProductModelId { get; set; }

	public virtual ChannelPartners Cp { get; set; }

	public virtual MachineInventory MachineInventory { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual OaequipGeneralData Oa { get; set; }
}
