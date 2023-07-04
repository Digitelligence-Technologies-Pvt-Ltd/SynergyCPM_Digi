using System;

namespace SynergyWebServices.DAL;

public class OverAllLeadStatus
{
	public int Olsid { get; set; }

	public int Leid { get; set; }

	public int Id { get; set; }

	public int IsIdStatus { get; set; }

	public DateTime? Date { get; set; }

	public DateTime? Time { get; set; }

	public int Cpid { get; set; }
}
