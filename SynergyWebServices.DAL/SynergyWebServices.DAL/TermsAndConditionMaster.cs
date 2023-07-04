using System;

namespace SynergyWebServices.DAL;

public class TermsAndConditionMaster
{
	public int TermsAndConditionId { get; set; }

	public string TermsAndConditionFor { get; set; }

	public string PaymentTerms { get; set; }

	public string Delivery { get; set; }

	public string Dod { get; set; }

	public string ModeOfTransport { get; set; }

	public string Freight { get; set; }

	public string Gst { get; set; }

	public string TransitInsurance { get; set; }

	public string PackingAndForwarding { get; set; }

	public string Validity { get; set; }

	public string Comodity { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string ModifiedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }
}
