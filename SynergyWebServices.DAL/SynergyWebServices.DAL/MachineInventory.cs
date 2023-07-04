using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class MachineInventory
{
	public int MachineInventoryId { get; set; }

	public string MachineSerialNo { get; set; }

	public string Type { get; set; }

	public string PlaceStocked { get; set; }

	public string Remarks { get; set; }

	public string CustomerName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsDispatched { get; set; }

	public int Mdbid { get; set; }

	public int Cpid { get; set; }

	public int ProductModelId { get; set; }

	public virtual ProductModel ProductModel { get; set; }

	public virtual ICollection<MachineDispatch> MachineDispatch { get; set; }

	public MachineInventory()
	{
		MachineDispatch = new HashSet<MachineDispatch>();
	}
}
