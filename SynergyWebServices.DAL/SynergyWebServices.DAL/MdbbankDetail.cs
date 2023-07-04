namespace SynergyWebServices.DAL;

public class MdbbankDetail
{
	public int Mdbbdid { get; set; }

	public int Mdbid { get; set; }

	public string BankName { get; set; }

	public string BranchName { get; set; }

	public string Accounttype { get; set; }

	public string AccountNumber { get; set; }

	public string Ifsccode { get; set; }

	public string AddressLine1 { get; set; }

	public string AddressLine2 { get; set; }

	public string AddressLine3 { get; set; }

	public string City { get; set; }

	public string State { get; set; }

	public string PinCode { get; set; }

	public string Country { get; set; }

	public string Isd1 { get; set; }

	public string Std1 { get; set; }

	public string PhoneLl1 { get; set; }

	public string Isd2 { get; set; }

	public string Std2 { get; set; }

	public string PhoneLl2 { get; set; }

	public string Website { get; set; }

	public string Email { get; set; }

	public string Isdf { get; set; }

	public string Stdf { get; set; }

	public string Fax { get; set; }

	public string BankChequeinfavor { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }
}
