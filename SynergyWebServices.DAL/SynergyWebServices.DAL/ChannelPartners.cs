using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class ChannelPartners
{
	public int Cpid { get; set; }

	public string CpuniqueId { get; set; }

	public string Cpname { get; set; }

	public string CporgType { get; set; }

	public string CporgTypeothers { get; set; }

	public string AddressLine1 { get; set; }

	public string AddressLine2 { get; set; }

	public string AddressLine3 { get; set; }

	public string City { get; set; }

	public string State { get; set; }

	public string PinCode { get; set; }

	public string Country { get; set; }

	public string Isd1 { get; set; }

	public string Std1 { get; set; }

	public string ContactNumLl1 { get; set; }

	public string Isd2 { get; set; }

	public string Std2 { get; set; }

	public string ContactNumLl2 { get; set; }

	public string Tin { get; set; }

	public string CompanyPan { get; set; }

	public string Cstnumber { get; set; }

	public string Others { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int? IsDeleted { get; set; }

	public string Logo { get; set; }

	public string Website { get; set; }

	public string Email { get; set; }

	public string Email2 { get; set; }

	public string Isdf { get; set; }

	public string Stdf { get; set; }

	public string Fax { get; set; }

	public string Postcour { get; set; }

	public int ZoneId { get; set; }

	public virtual Zone Zone { get; set; }

	public virtual ICollection<CpbankDetails> CpbankDetails { get; set; }

	public virtual ICollection<CpcontactPersonData> CpcontactPersonData { get; set; }

	public virtual ICollection<Handover> Handover { get; set; }

	public virtual ICollection<MachineDispatch> MachineDispatch { get; set; }

	public virtual ICollection<OaequipGeneralData> OaequipGeneralData { get; set; }

	public virtual ICollection<OutwardMfr> OutwardMfr { get; set; }

	public virtual ICollection<OutwardSpare> OutwardSpare { get; set; }

	public virtual ICollection<RiceMillHod> RiceMillHod { get; set; }

	public virtual ICollection<Sotrm> Sotrm { get; set; }

	public virtual ICollection<Warranty> Warranty { get; set; }

	public ChannelPartners()
	{
		CpbankDetails = new HashSet<CpbankDetails>();
		CpcontactPersonData = new HashSet<CpcontactPersonData>();
		Handover = new HashSet<Handover>();
		MachineDispatch = new HashSet<MachineDispatch>();
		OaequipGeneralData = new HashSet<OaequipGeneralData>();
		OutwardMfr = new HashSet<OutwardMfr>();
		OutwardSpare = new HashSet<OutwardSpare>();
		RiceMillHod = new HashSet<RiceMillHod>();
		Sotrm = new HashSet<Sotrm>();
		Warranty = new HashSet<Warranty>();
	}
}
