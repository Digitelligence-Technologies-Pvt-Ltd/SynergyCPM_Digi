using System;

namespace SynergyWebServices.DAL;

public class StoredProceduresMaster
{
	public int Id { get; set; }

	public string StoredProcedureDisplayName { get; set; }

	public string StoredProcedureDesc { get; set; }

	public string StoredProcedureRefName { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsActive { get; set; }
}
