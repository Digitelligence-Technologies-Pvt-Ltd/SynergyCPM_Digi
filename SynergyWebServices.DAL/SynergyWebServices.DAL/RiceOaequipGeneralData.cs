using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class RiceOaequipGeneralData
{
	public int Roaid { get; set; }

	public int Rqgid { get; set; }

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

	public string OarejectComm { get; set; }

	public string Approvaldate { get; set; }

	public int Cpid { get; set; }

	public string TinNumber { get; set; }

	public string ProductVariety { get; set; }

	public string TypeRice { get; set; }

	public string PaddySize { get; set; }

	public int? QgequipGeneralDataQgid { get; set; }

	public int? QgequipTableDataQgtbid { get; set; }

	public int Oastatus { get; set; }

	public int ApprovalStatus { get; set; }

	public string Cpname { get; set; }

	public string Pass { get; set; }

	public string Capacity { get; set; }

	public string PolishRequirement { get; set; }

	public string MotorQ { get; set; }

	public string MotorType { get; set; }

	public string MotorRating { get; set; }

	public string PancardNo { get; set; }

	public int IsDispatch { get; set; }

	public string MailDetails { get; set; }

	public string MailDate { get; set; }

	public int? RiceMillHodRmhodid { get; set; }

	public string SalesManager { get; set; }

	public string Business { get; set; }

	public string BusinessArea { get; set; }

	public string BusinessUnit { get; set; }

	public string BusinessUnitForSap { get; set; }

	public string MarketSegment { get; set; }

	public string CustomerSapidNo { get; set; }

	public string PackingAndForwarding { get; set; }

	public string TransistInsurance { get; set; }

	public string Freight { get; set; }

	public string IncoTerms { get; set; }

	public string CommitedDelivery { get; set; }

	public string PaymentTerms { get; set; }

	public string CustomerSapidDelvryNo { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual QgequipGeneralData QgequipGeneralDataQg { get; set; }

	public virtual QgequipTableData QgequipTableDataQgtb { get; set; }

	public virtual RiceMillHod RiceMillHodRmhod { get; set; }

	public virtual ICollection<RiceOaequipPayment> RiceOaequipPayment { get; set; }

	public virtual ICollection<RiceOaequipTableData> RiceOaequipTableData { get; set; }

	public RiceOaequipGeneralData()
	{
		RiceOaequipPayment = new HashSet<RiceOaequipPayment>();
		RiceOaequipTableData = new HashSet<RiceOaequipTableData>();
	}
}
