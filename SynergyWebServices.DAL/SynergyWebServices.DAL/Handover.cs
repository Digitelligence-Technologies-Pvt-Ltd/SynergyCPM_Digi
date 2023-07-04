using System;

namespace SynergyWebServices.DAL;

public class Handover
{
	public int Hid { get; set; }

	public string Oanum { get; set; }

	public string Custpurorderno { get; set; }

	public string Buhlercustorderno { get; set; }

	public string Project { get; set; }

	public string Buhlerrep { get; set; }

	public string Custrep { get; set; }

	public bool Handing { get; set; }

	public bool Commis { get; set; }

	public bool Termi { get; set; }

	public bool Erection { get; set; }

	public bool Trail { get; set; }

	public bool Wimaterial { get; set; }

	public bool Womaterial { get; set; }

	public bool Wcarr { get; set; }

	public bool Wnotcarr { get; set; }

	public bool Completionerection { get; set; }

	public bool Capacity { get; set; }

	public bool Reached { get; set; }

	public bool Notreached { get; set; }

	public bool Machinehanded { get; set; }

	public DateTime? Handeddate { get; set; }

	public bool Buyer { get; set; }

	public bool Followcomm { get; set; }

	public bool Seperate { get; set; }

	public string Comments { get; set; }

	public bool Yes { get; set; }

	public bool No { get; set; }

	public string MacSlNo { get; set; }

	public string Modelno { get; set; }

	public int Quantity { get; set; }

	public int Cpid { get; set; }

	public string Hodnumber { get; set; }

	public int Mdbid { get; set; }

	public virtual ChannelPartners Cp { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }
}
