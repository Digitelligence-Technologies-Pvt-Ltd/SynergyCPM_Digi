using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class QgspareGeneralData
{
	public int Qgid { get; set; }

	public string QuotationNumber { get; set; }

	public string CpquotationNumber { get; set; }

	public string KindAttention { get; set; }

	public string Subject { get; set; }

	public string CompanyUniqueId { get; set; }

	public DateTime? QuotationDate { get; set; }

	public int Mdbid { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Islatest { get; set; }

	public int Cpid { get; set; }

	public string SalesName { get; set; }

	public long? VisitHistoryId { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual ICollection<QgsparePayment> QgsparePayment { get; set; }

	public virtual ICollection<QgspareTableData> QgspareTableData { get; set; }

	public QgspareGeneralData()
	{
		QgsparePayment = new HashSet<QgsparePayment>();
		QgspareTableData = new HashSet<QgspareTableData>();
	}
}
