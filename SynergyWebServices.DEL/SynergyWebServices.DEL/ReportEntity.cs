namespace SynergyWebServices.DEL;

public class ReportEntity
{
	public class TableElements
	{
		public string storeProcedureName { get; set; }
	}

	public class ReportEngineMaster
	{
		public string fromDate { get; set; }

		public string toDate { get; set; }

		public int visitPurpose { get; set; }

		public string visitType { get; set; }
	}

	public class MdbReportCustom
	{
		public string fromDate { get; set; }

		public string toDate { get; set; }
	}

	public class QuotationReport
	{
		public string fromDate { get; set; }

		public string toDate { get; set; }

		public string quotationNo { get; set; }

		public int cpId { get; set; }
	}
}
