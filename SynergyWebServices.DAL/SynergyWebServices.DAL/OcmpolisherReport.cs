using System;

namespace SynergyWebServices.DAL;

public class OcmpolisherReport
{
	public int Prid { get; set; }

	public string FilledBy { get; set; }

	public string Branch { get; set; }

	public DateTime? Date { get; set; }

	public string CustomerName { get; set; }

	public string Location { get; set; }

	public string Country { get; set; }

	public int Quantity { get; set; }

	public string Product { get; set; }

	public string Capacity { get; set; }

	public string Process { get; set; }

	public string SievePlate { get; set; }

	public string ReducerRing { get; set; }

	public string Drive { get; set; }

	public string Motor { get; set; }

	public string Ctcoil { get; set; }

	public string Accessories { get; set; }

	public string SievePlatePartNo { get; set; }

	public string ReducerRingPartNo { get; set; }

	public string DrivePartNo { get; set; }

	public string MotorPartNo { get; set; }

	public string CtcoilPartNo { get; set; }

	public string AccessoriesPartNo { get; set; }

	public string ProductModel { get; set; }
}
