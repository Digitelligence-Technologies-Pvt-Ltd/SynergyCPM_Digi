using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class MdbgeneralData
{
	public int Mdbid { get; set; }

	public string CompanyUniqueId { get; set; }

	public string RelationshipTypeothers { get; set; }

	public string OrganizationName { get; set; }

	public string OrganizationType { get; set; }

	public string OrganizationTypeothers { get; set; }

	public string SearchTerm { get; set; }

	public string AddressLine1 { get; set; }

	public string AddressLine2 { get; set; }

	public string AddressLine3 { get; set; }

	public string AddressLine4 { get; set; }

	public string City { get; set; }

	public string Pincode { get; set; }

	public string State { get; set; }

	public string Country { get; set; }

	public string Isd1 { get; set; }

	public string Std1 { get; set; }

	public string PhoneLl1 { get; set; }

	public string Isd2 { get; set; }

	public string Std2 { get; set; }

	public string ContactNumLl2 { get; set; }

	public string Isdf { get; set; }

	public string Stdf { get; set; }

	public string Fax { get; set; }

	public string EmailId { get; set; }

	public string EmailId2 { get; set; }

	public string Website { get; set; }

	public string PostalCourier { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Cpid { get; set; }

	public int IsDeleted { get; set; }

	public string ContactName { get; set; }

	public string Latitude { get; set; }

	public string Longitude { get; set; }

	public string BillingAddress { get; set; }

	public string DeleveryAddress { get; set; }

	public virtual ICollection<Handover> Handover { get; set; }

	public virtual ICollection<MachineDispatch> MachineDispatch { get; set; }

	public virtual ICollection<MdbbankDetail> MdbbankDetail { get; set; }

	public virtual ICollection<MdbcontactPersonData> MdbcontactPersonData { get; set; }

	public virtual ICollection<MdbstatutoryNumber> MdbstatutoryNumber { get; set; }

	public virtual ICollection<Mfr> Mfr { get; set; }

	public virtual ICollection<OaequipGeneralData> OaequipGeneralData { get; set; }

	public virtual ICollection<QgequipGeneralData> QgequipGeneralData { get; set; }

	public virtual ICollection<QgspareGeneralData> QgspareGeneralData { get; set; }

	public virtual ICollection<RiceMillHod> RiceMillHod { get; set; }

	public virtual ICollection<RiceOaequipGeneralData> RiceOaequipGeneralData { get; set; }

	public MdbgeneralData()
	{
		Handover = new HashSet<Handover>();
		MachineDispatch = new HashSet<MachineDispatch>();
		MdbbankDetail = new HashSet<MdbbankDetail>();
		MdbcontactPersonData = new HashSet<MdbcontactPersonData>();
		MdbstatutoryNumber = new HashSet<MdbstatutoryNumber>();
		Mfr = new HashSet<Mfr>();
		OaequipGeneralData = new HashSet<OaequipGeneralData>();
		QgequipGeneralData = new HashSet<QgequipGeneralData>();
		QgspareGeneralData = new HashSet<QgspareGeneralData>();
		RiceMillHod = new HashSet<RiceMillHod>();
		RiceOaequipGeneralData = new HashSet<RiceOaequipGeneralData>();
	}
}
