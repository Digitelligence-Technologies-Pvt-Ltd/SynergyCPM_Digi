using System;

namespace SynergyWebServices.DAL;

public class LostOrderAnalysis
{
	public int Loid { get; set; }

	public int Qgid { get; set; }

	public DateTime? Loadate { get; set; }

	public string Competitor { get; set; }

	public string ReasonForLosing { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Cpid { get; set; }

	public string Comments { get; set; }

	public string EquipModel { get; set; }

	public int? ProductModelProductModelId { get; set; }

	public string Qty { get; set; }

	public int Tsotid { get; set; }
}
