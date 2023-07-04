namespace SynergyWebServices.DAL;

public class MdbstatutoryNumber
{
	public int Mdbsnid { get; set; }

	public int Mdbid { get; set; }

	public string CompanyPan { get; set; }

	public string Tin { get; set; }

	public string RegistrationNumber { get; set; }

	public string ServiceTaxNumber { get; set; }

	public string ImporterExporterCode { get; set; }

	public string Cstnumber { get; set; }

	public string TaxDeductionAccountNumber { get; set; }

	public string Others { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }
}
