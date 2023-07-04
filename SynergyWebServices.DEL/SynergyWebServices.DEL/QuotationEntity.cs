using System.Collections.Generic;
using SynergyWebServices.DAL;

namespace SynergyWebServices.DEL;

public class QuotationEntity
{
	public class QuotationCustom
	{
		public string quotationNumber { get; set; }

		public string cpQuotationNumber { get; set; }

		public string companyUniqueId { get; set; }

		public string kindAttention { get; set; }

		public string subjectInfo { get; set; }

		public string salesName { get; set; }

		public string comments { get; set; }

		public string riceMillType { get; set; }

		public int? mdbId { get; set; }

		public string userId { get; set; }

		public int? visitHistoryId { get; set; }

		public string grandTotal { get; set; }

		public string paymentTerms { get; set; }

		public string delivery { get; set; }

		public string dateOfDispatch { get; set; }

		public string modeOfTransport { get; set; }

		public string freight { get; set; }

		public string CST { get; set; }

		public string transitInsurance { get; set; }

		public string commodity { get; set; }

		public string validity { get; set; }

		public List<ProductModel> productModels { get; set; }
	}

	public class ProductModel
	{
		public int qgtbid { get; set; }

		public int qgid { get; set; }

		public string modelNum { get; set; }

		public int quantity { get; set; }

		public string unitPrice { get; set; }

		public string totalPrice { get; set; }

		public string exclusion { get; set; }

		public int productModelId { get; set; }

		public string modelDesc { get; set; }

		public int productId { get; set; }

		public int masterProductId { get; set; }

		public string masterProductName { get; set; }

		public string productName { get; set; }

		public string typeRice { get; set; }

		public string paddySize { get; set; }

		public string pass { get; set; }

		public string capacity { get; set; }

		public string polishRequirement { get; set; }

		public string motorQ { get; set; }

		public string motorType { get; set; }

		public string motorRating { get; set; }

		public int isSotstatus { get; set; }
	}

	public class GetQuotationData
	{
		public string contactPersonName { get; set; }

		public string dear { get; set; }

		public string quotationNumber { get; set; }

		public int mdbId { get; set; }

		public string organizationName { get; set; }

		public string addressLine1 { get; set; }

		public string addressLine2 { get; set; }

		public string addressLine3 { get; set; }

		public string city { get; set; }

		public string pincode { get; set; }

		public string state { get; set; }

		public string companyUniqueId { get; set; }

		public string cpName { get; set; }

		public string salesManagerName { get; set; }

		public List<QgequipTableData> qgequipTableDatas { get; set; }

		public List<QgspareTableData> qgspareTableDatas { get; set; }
	}

	public class SpareQuotationCustom
	{
		public int? mdbId { get; set; }

		public string userId { get; set; }

		public string quotationNumber { get; set; }

		public string cpQuotationNumber { get; set; }

		public string companyUniqueId { get; set; }

		public string kindAttention { get; set; }

		public string subjectInfo { get; set; }

		public string salesName { get; set; }

		public string comments { get; set; }

		public int? visitHistoryId { get; set; }

		public string grandTotal { get; set; }

		public string paymentTerms { get; set; }

		public string delivery { get; set; }

		public string dateOfDispatch { get; set; }

		public string modeOfTransport { get; set; }

		public string freight { get; set; }

		public string CST { get; set; }

		public string transitInsurance { get; set; }

		public string commodity { get; set; }

		public string validity { get; set; }

		public List<QGSpareTableDataCustom> productModels { get; set; }
	}

	public class QGSpareTableDataCustom
	{
		public int qgtbId { get; set; }

		public int qgId { get; set; }

		public int quantity { get; set; }

		public string unitPrice { get; set; }

		public string totalPrice { get; set; }

		public string description { get; set; }

		public int productModelSparesId { get; set; }
	}

	public class QuotationNumberCustom
	{
		public int mdbId { get; set; }

		public string userId { get; set; }

		public string quotationType { get; set; }

		public int visitId { get; set; }
	}
}
