namespace SynergyWebServices.DAL;

public class MdbcontactPersonData
{
	public int Mdbcpdid { get; set; }

	public int? Mdbid { get; set; }

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

	public virtual MdbgeneralData Mdb { get; set; }
}
