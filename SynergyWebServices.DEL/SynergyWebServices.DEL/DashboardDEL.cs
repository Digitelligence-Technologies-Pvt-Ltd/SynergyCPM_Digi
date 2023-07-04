namespace SynergyWebServices.DEL;

public class DashboardDEL
{
	public class DashboardCustom
	{
		public int totalOpportunitiesOBCount { get; set; }
		public int monthOpportunitiesOBCount { get; set; }

		public int monthOpportunitieslossCount { get; set; }

		public decimal activeopportunity { get; set; }

		public decimal monthHotlistCount { get; set; }

		public int totalVisitsCount { get; set; }

		public int monthVisitsCount { get; set; }

		public int totalLeadsCount { get; set; }

		public int monthLeadsCount { get; set; }

		public int totalOrdersCount { get; set; }

		public int monthOrdersCount { get; set; }

		public int totalQuotationCount { get; set; }

		public int monthQutationCount { get; set; }

		public int[] visitMonthWiseCount { get; set; }

		public int[] leadsMonthWiseCount { get; set; }

		public int[] quotationMonthWiseCount { get; set; }

		public int[] orderMonthWiseCount { get; set; }

		public decimal[] QuoteZonwise { get; set; }

        public decimal CHFValue { get; set; }

        public MonthWiseValues[] OppurtunityMonthWiseValue  { get; set;}

        public MonthWiseValues[] OppurtunityMonthWiseCount { get; set; }

        public MonthWiseValues[] OppurtunityMonthCumCount { get; set; }
        public MonthWiseValues[] OppurtunityMonthCumValue { get; set; }

        public MonthWiseValues[] ForecastValue { get; set; }

        public MonthWiseValues[] ForecastCount { get; set; }

        public MonthWiseValues[] AnnualVisitByMonth { get; set; }
		public MonthWiseValues[] OppurtunityPipeline { get; set; }
	}

public class MonthWiseValues
{
	public string MMYY { get; set; }
        public decimal Value { get; set; }

      
}

	public class CPWiseVisitDetails
	{
		public string cpEngineerName { get; set; }

		public int? cpEngineerId { get; set; }

		public string cpName { get; set; }

		public int? cpId { get; set; }

		public int totalVisitsCount { get; set; }

		public int monthVisitCount { get; set; }
	}

	public class CPWiseQuotationDetails
	{
		public string cpName { get; set; }

		public int? cpId { get; set; }

		public int totalQuotationCount { get; set; }

		public int monthQuotationCount { get; set; }

		public double totalPrice { get; set; }
	}
}
