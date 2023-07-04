using System;

namespace SynergyWebServices.DAL;

public class OutwardMfr
{
	public int Mfrid { get; set; }

	public string OutwardMonth { get; set; }

	public string Mfrno { get; set; }

	public string CustomerName { get; set; }

	public int ProductModelSparesId { get; set; }

	public int Quantity { get; set; }

	public string TotalValue { get; set; }

	public DateTime? DispatchDate { get; set; }

	public string Remarks { get; set; }

	public int IsDeleted { get; set; }

	public int IsDispatch { get; set; }

	public int Cpid { get; set; }

	public string Cpname { get; set; }

	public int QuantityOrdered { get; set; }

	public int? OutMonthNo { get; set; }

	public int IsSparesRecieved { get; set; }

	public DateTime? SparesRecievedDate { get; set; }

	public DateTime? MachineIssueDate { get; set; }

	public string MachineIssueDescription { get; set; }

	public int IsMachineIssueOpen { get; set; }

	public DateTime? FaultSpareDate { get; set; }

	public string FaultSpareDescription { get; set; }

	public DateTime? FaultSpareRecivedDateAdmin { get; set; }

	public virtual ChannelPartners Cp { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }
}
