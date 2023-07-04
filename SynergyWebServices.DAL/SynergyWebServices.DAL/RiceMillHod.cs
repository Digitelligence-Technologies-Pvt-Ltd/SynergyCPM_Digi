using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class RiceMillHod
{
	public int Rmhodid { get; set; }

	public string Roaid { get; set; }

	public DateTime? Hoddate { get; set; }

	public string RemarkDetails { get; set; }

	public int Cpid { get; set; }

	public int Mdbid { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsStatus { get; set; }

	public virtual ChannelPartners Cp { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual ICollection<RiceOaequipGeneralData> RiceOaequipGeneralData { get; set; }

	public RiceMillHod()
	{
		RiceOaequipGeneralData = new HashSet<RiceOaequipGeneralData>();
	}
}
