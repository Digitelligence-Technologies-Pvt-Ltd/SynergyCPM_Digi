using System;
using System.Collections.Generic;

namespace SynergyWebServices.DEL;

public class VisitsEntity
{
	public class VisitsCustom
	{
		public string nextVisitDate { get; set; }

		public long visitHistoryId { get; set; }

		public string userId { get; set; }

		public string companyUniqueId { get; set; }

		public long? visitPurpose { get; set; }

		public string visitDateTime { get; set; }

		public string visitStatus { get; set; }

		public string comments { get; set; }

		public string productModelId { get; set; }

		public int? cpEnginneerId { get; set; }

		public string buId { get; set; }

		public int? salesManagerId { get; set; }

		public string masterProducts { get; set; }

		public bool? isCall { get; set; }

		public string visitType { get; set; }
	}

	public class VisitsViewCustom
	{
		public string displayNextVisitDate { get; set; }

		public DateTime nextVisitDate { get; set; }

		public long visitHistoryId { get; set; }

		public string userId { get; set; }

		public string companyUniqueId { get; set; }

		public string companyUniqueName { get; set; }

		public string cpName { get; set; }

		public string buName { get; set; }

		public string salesManagerName { get; set; }

		public string productModelName { get; set; }

		public long? visitPurpose { get; set; }

		public DateTime visitDateTime { get; set; }

		public string displayVisitDateTime { get; set; }

		public string visitStatus { get; set; }

		public string comments { get; set; }

		public string productModelId { get; set; }

		public int? cpEnginneerId { get; set; }

		public string buId { get; set; }

		public int? salesManagerId { get; set; }

		public string masterProducts { get; set; }

		public bool? isCall { get; set; }

		public string visitType { get; set; }

		public string masterProductsName { get; set; }

		public List<BuNameList> buNameLists { get; set; }

		public List<MasterProductList> masterProductLists { get; set; }

		public List<ProductModelList> productModelLists { get; set; }
	}

	public class BuNameList
	{
		public int buId { get; set; }

		public string buName { get; set; }
	}

	public class MasterProductList
	{
		public int productId { get; set; }

		public string productName { get; set; }
	}

	public class ProductModelList
	{
		public int productModelId { get; set; }

		public string productModelName { get; set; }
	}
}
