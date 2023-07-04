namespace SynergyWebServices.DAL;

public class QgequipPayment
{
	public int Qgp { get; set; }

	public int Qgid { get; set; }

	public string PaymentTerms { get; set; }

	public string Delivery { get; set; }

	public string DateofDispatch { get; set; }

	public string Transport { get; set; }

	public string Freight { get; set; }

	public string Cst { get; set; }

	public string TransitInsu { get; set; }

	public string Commodity { get; set; }

	public string Validity { get; set; }

	public string Annexure { get; set; }

	public string Overallprice { get; set; }

	public virtual QgequipGeneralData Qg { get; set; }
}
