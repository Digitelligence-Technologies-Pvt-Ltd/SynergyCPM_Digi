namespace SynergyWebServices.DEL;

public class MDBMasterEntity
{
	public class MDBMasterEntityCustom
	{
		public int mdbId { get; set; }

		public string companyUniqueId { get; set; }

		public string relationshipTypeOthers { get; set; }

		public string organizationName { get; set; }

		public string organizationType { get; set; }

		public string organizationTypeOthers { get; set; }

		public string searchTerm { get; set; }

		public string addressLine1 { get; set; }

		public string addressLine2 { get; set; }

		public string addressLine3 { get; set; }

		public string addressLine4 { get; set; }

		public string city { get; set; }

		public string pincode { get; set; }

		public string state { get; set; }

		public string country { get; set; }

		public string isd1 { get; set; }

		public string std1 { get; set; }

		public string phoneLl1 { get; set; }

		public string isd2 { get; set; }

		public string std2 { get; set; }

		public string contactNumLl2 { get; set; }

		public string isdf { get; set; }

		public string stdf { get; set; }

		public string fax { get; set; }

		public string emailId { get; set; }

		public string emailId2 { get; set; }

		public string website { get; set; }

		public string postalCourier { get; set; }

		public string contactName { get; set; }

		public string latitude { get; set; }

		public string longitude { get; set; }

		public string billingAddress { get; set; }

		public string deliveryAddress { get; set; }

		public string prefix { get; set; }

		public string ownerName { get; set; }

		public string mobNo { get; set; }

		public string userId { get; set; }
	}

	public class MDBMultiple
	{
		public string userId { get; set; }

		public int take { get; set; }

		public int skip { get; set; }
	}
}
