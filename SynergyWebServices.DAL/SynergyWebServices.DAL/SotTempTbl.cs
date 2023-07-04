using System;

namespace SynergyWebServices.DAL;

public class SotTempTbl
{
	public int Tsotid { get; set; }

	public int Qgid { get; set; }

	public int Cpid { get; set; }

	public int? Byjtchances { get; set; }

	public string Topcompetitors { get; set; }

	public string AdditionalComments { get; set; }

	public string Equipment { get; set; }

	public int Islatestquo { get; set; }

	public int Quantity { get; set; }

	public string Orderactive { get; set; }

	public string Expectedorder { get; set; }

	public int Status { get; set; }

	public DateTime? Expecteddate { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int ProductId { get; set; }

	public int MasterProductId { get; set; }

	public int ProductModelId { get; set; }
}
