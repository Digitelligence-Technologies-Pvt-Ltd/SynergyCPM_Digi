using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class QgequipGeneralData
{
	public int Qgid { get; set; }

	public string QuotationNumber { get; set; }

	public string CpquotationNumber { get; set; }

	public string KindAttention { get; set; }

	public string CompanyUniqueId { get; set; }

	public DateTime? QuotationDate { get; set; }

	public int Mdbid { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Islatest { get; set; }

	public int Cpid { get; set; }

	public string Subjectinfo { get; set; }

	public int Ordergenerated { get; set; }

	public int QuotStatus { get; set; }

	public string SalesName { get; set; }

	public int IsRiceMill { get; set; }

	public string ProductVariety { get; set; }

	public string TypeRice { get; set; }

	public string PaddySize { get; set; }

	public string LeadTime { get; set; }

	public int IsTime { get; set; }

	public string Pass { get; set; }

	public string Capacity { get; set; }

	public string PolishRequirement { get; set; }

	public string MotorQ { get; set; }

	public string MotorType { get; set; }

	public string MotorRating { get; set; }

	public long? VisitHistoryId { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual ICollection<QgequipPayment> QgequipPayment { get; set; }

	public virtual ICollection<QgequipTableData> QgequipTableData { get; set; }

	public virtual ICollection<RiceOaequipGeneralData> RiceOaequipGeneralData { get; set; }

	public virtual ICollection<Sotrm> Sotrm { get; set; }

	public virtual ICollection<Sots> Sots { get; set; }

	public QgequipGeneralData()
	{
		QgequipPayment = new HashSet<QgequipPayment>();
		QgequipTableData = new HashSet<QgequipTableData>();
		RiceOaequipGeneralData = new HashSet<RiceOaequipGeneralData>();
		Sotrm = new HashSet<Sotrm>();
		Sots = new HashSet<Sots>();
	}
}
