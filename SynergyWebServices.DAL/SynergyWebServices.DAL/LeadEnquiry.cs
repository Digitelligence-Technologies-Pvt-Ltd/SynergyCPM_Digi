using System;

namespace SynergyWebServices.DAL;

public class LeadEnquiry
{
	public int Leid { get; set; }

	public string OrganizationName { get; set; }

	public string OrganizationType { get; set; }

	public string AddressLine1 { get; set; }

	public string AddressLine2 { get; set; }

	public string AddressLine3 { get; set; }

	public string City { get; set; }

	public string Pincode { get; set; }

	public string State { get; set; }

	public string Country { get; set; }

	public string Isd1 { get; set; }

	public string Std1 { get; set; }

	public string PhoneLl1 { get; set; }

	public string EmailId { get; set; }

	public string Prefix { get; set; }

	public string FirstName { get; set; }

	public string MiddleName { get; set; }

	public string LastName { get; set; }

	public string Isdc1 { get; set; }

	public string Stdc1 { get; set; }

	public string PhoneLlc1 { get; set; }

	public string Isdm1 { get; set; }

	public string Mobile1 { get; set; }

	public string EmailIdcontact { get; set; }

	public string SuggestedModel { get; set; }

	public DateTime? DateOfMeeting { get; set; }

	public string LeadSource { get; set; }

	public string MeetingDesc { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsStatus { get; set; }

	public int IsDrop { get; set; }

	public int Cpid { get; set; }

	public string LeadTime { get; set; }

	public int IsTime { get; set; }

	public int? IsCount { get; set; }

	public int? IsHod { get; set; }

	public DateTime? NotifyDate { get; set; }

	public string Latitude { get; set; }

	public string Longitude { get; set; }
}
