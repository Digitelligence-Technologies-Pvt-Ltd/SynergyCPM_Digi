using System;

namespace SynergyWebServices.DAL;

public class OutwardSpare
{
	public int OutwardId { get; set; }

	public string OutwardMonth { get; set; }

	public string OrderNo { get; set; }

	public string CustomerName { get; set; }

	public int ProductModelSparesId { get; set; }

	public int Quantity { get; set; }

	public string TotalValue { get; set; }

	public string InvoiceNo { get; set; }

	public DateTime InvoiceDate { get; set; }

	public DateTime DispatchDate { get; set; }

	public string Remarks { get; set; }

	public int IsDeleted { get; set; }

	public int IsDispatch { get; set; }

	public int QuantityOrdered { get; set; }

	public int Cpid { get; set; }

	public int? OutMonthNo { get; set; }

	public virtual ChannelPartners Cp { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }
}
