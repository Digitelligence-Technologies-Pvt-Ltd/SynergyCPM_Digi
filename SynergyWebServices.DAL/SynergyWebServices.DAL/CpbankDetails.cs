namespace SynergyWebServices.DAL;

public class CpbankDetails
{
	public int Cpbdid { get; set; }

	public int Cpid { get; set; }

	public string BankName { get; set; }

	public string BranchName { get; set; }

	public string Accounttype { get; set; }

	public string AccountNumber { get; set; }

	public string Ifsccode { get; set; }

	public string BankChequeinfavor { get; set; }

	public virtual ChannelPartners Cp { get; set; }
}
