using System;

namespace SynergyWebServices.DAL;

public class StatesTbl
{
	public int StateId { get; set; }

	public string State { get; set; }

	public int IsDeleted { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int CreatedBy { get; set; }
}
