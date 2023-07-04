namespace SynergyWebServices.DAL;

public class CpcontactPersonData
{
	public int Cpcpdid { get; set; }

	public int Cpid { get; set; }

	public string Title { get; set; }

	public string Titleothers { get; set; }

	public string FirstName { get; set; }

	public string MiddleName { get; set; }

	public string LastName { get; set; }

	public string Designation { get; set; }

	public string Department { get; set; }

	public string Isd1 { get; set; }

	public string Std1 { get; set; }

	public string PhoneLl1 { get; set; }

	public string Isd2 { get; set; }

	public string Std2 { get; set; }

	public string PhoneLl2 { get; set; }

	public string Isdm1 { get; set; }

	public string Mobile1 { get; set; }

	public string Isdm2 { get; set; }

	public string Mobile2 { get; set; }

	public string EmailId { get; set; }

	public string KeyActivity { get; set; }

	public string Comments { get; set; }

	public byte[] Photo { get; set; }

	public virtual ChannelPartners Cp { get; set; }
}
