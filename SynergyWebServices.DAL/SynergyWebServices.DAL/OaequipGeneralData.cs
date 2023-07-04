using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class OaequipGeneralData
{
	public int Oaid { get; set; }

	public int Qgid { get; set; }

	public string QuotationNumber { get; set; }

	public string Oanumber { get; set; }

	public string CpquotationNumber { get; set; }

	public string KindAttention { get; set; }

	public string Subjectinfo { get; set; }

	public string CompanyUniqueId { get; set; }

	public DateTime? QuotationDate { get; set; }

	public DateTime? Oadate { get; set; }

	public int Mdbid { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Islatest { get; set; }

	public int Cpid { get; set; }

	public int Oastatus { get; set; }

	public int ApprovalStatus { get; set; }

	public string Approvaldate { get; set; }

	public string OarejectComm { get; set; }

	public string TinNumber { get; set; }

	public int IsHod { get; set; }

	public int IsMacineDispatch { get; set; }

	public string Cpname { get; set; }

	public virtual ChannelPartners Cp { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual ICollection<MachineDispatch> MachineDispatch { get; set; }

	public virtual ICollection<OaequipPayment> OaequipPayment { get; set; }

	public virtual ICollection<OaequipTableData> OaequipTableData { get; set; }

	public OaequipGeneralData()
	{
		MachineDispatch = new HashSet<MachineDispatch>();
		OaequipPayment = new HashSet<OaequipPayment>();
		OaequipTableData = new HashSet<OaequipTableData>();
	}
}
