using System;

namespace SynergyWebServices.DAL;

public class Warranty
{
	public int Wid { get; set; }

	public string CustomerNumber { get; set; }

	public string CustomerName { get; set; }

	public string OrderNumber { get; set; }

	public string BuhlerOrderConfirm { get; set; }

	public string Model { get; set; }

	public string MachineNummber { get; set; }

	public DateTime? HandoverDate { get; set; }

	public string WarrantyExpiry { get; set; }

	public int Cpid { get; set; }

	public virtual ChannelPartners Cp { get; set; }
}
