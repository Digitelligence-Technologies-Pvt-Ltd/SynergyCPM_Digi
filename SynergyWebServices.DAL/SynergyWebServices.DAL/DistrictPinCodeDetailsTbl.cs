using System;

namespace SynergyWebServices.DAL;

public class DistrictPinCodeDetailsTbl
{
	public int Dpid { get; set; }

	public string State { get; set; }

	public string District { get; set; }

	public string PostalDivision { get; set; }

	public string PostalRegion { get; set; }

	public string PostalCircle { get; set; }

	public string Taluk { get; set; }

	public int Pincode { get; set; }

	public string OfficeName { get; set; }

	public string OfficeStatus { get; set; }

	public string TelePhone { get; set; }

	public int IsDeleted { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int CreatedBy { get; set; }

	public int StateId { get; set; }
}
