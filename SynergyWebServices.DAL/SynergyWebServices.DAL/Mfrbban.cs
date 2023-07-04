using System;

namespace SynergyWebServices.DAL;

public class Mfrbban
{
	public int Mfrbbid { get; set; }

	public int Mfrid { get; set; }

	public int Cpid { get; set; }

	public string RecdOn { get; set; }

	public string MfrprocessedBy { get; set; }

	public string MfrnoYear { get; set; }

	public string TanoDat { get; set; }

	public string Code { get; set; }

	public string Aoddat { get; set; }

	public string DispatchDat { get; set; }

	public string MfrAdminDat { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }
}
