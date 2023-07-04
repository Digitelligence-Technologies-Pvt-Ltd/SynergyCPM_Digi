using System;

namespace SynergyWebServices.DAL;

public class TestTable
{
	public int TestTableId { get; set; }

	public string TestName1 { get; set; }

	public string TestName2 { get; set; }

	public string TestName3 { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsDrop { get; set; }
}
