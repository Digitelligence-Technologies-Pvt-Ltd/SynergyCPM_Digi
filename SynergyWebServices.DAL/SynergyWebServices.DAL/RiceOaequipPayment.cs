namespace SynergyWebServices.DAL;

public class RiceOaequipPayment
{
	public int Roapid { get; set; }

	public int Roaid { get; set; }

	public string PaymentTerms { get; set; }

	public string Delivery { get; set; }

	public string DateofDispatch { get; set; }

	public string Transport { get; set; }

	public string Freight { get; set; }

	public string Cst { get; set; }

	public string TransitInsu { get; set; }

	public string Commodity { get; set; }

	public string Annexure { get; set; }

	public string Overallprice { get; set; }

	public string Validity { get; set; }

	public virtual RiceOaequipGeneralData Roa { get; set; }
}
