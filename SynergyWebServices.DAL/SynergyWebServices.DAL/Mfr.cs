using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class Mfr
{
	public int Mfrid { get; set; }

	public string OrderNum { get; set; }

	public string MfrTo { get; set; }

	public string MfrDate { get; set; }

	public bool MacBreakDown { get; set; }

	public bool MacOperatTemp { get; set; }

	public string MacSlNo { get; set; }

	public string CommissionedBy { get; set; }

	public string CommissionedDate { get; set; }

	public string Fault { get; set; }

	public string Ask1 { get; set; }

	public string Ask2 { get; set; }

	public string Ask3 { get; set; }

	public string Ask4 { get; set; }

	public string Ask5 { get; set; }

	public string Remedial { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int Cpid { get; set; }

	public string MfrEnteredBy { get; set; }

	public string MfrModelNo { get; set; }

	public int IsMfr { get; set; }

	public string Mfrnumber { get; set; }

	public int Mdbid { get; set; }

	public int ApprovalStatus { get; set; }

	public string Mfrcomment { get; set; }

	public int IsSpareTakenFromExistingCpstock { get; set; }

	public int IsSpareNeededFromBban { get; set; }

	public string ContactPerson { get; set; }

	public string ContactNo { get; set; }

	public virtual MdbgeneralData Mdb { get; set; }

	public virtual ICollection<Mfrparts> Mfrparts { get; set; }

	public Mfr()
	{
		Mfrparts = new HashSet<Mfrparts>();
	}
}
