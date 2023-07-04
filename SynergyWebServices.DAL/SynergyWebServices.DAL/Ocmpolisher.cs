using System;

namespace SynergyWebServices.DAL;

public class Ocmpolisher
{
	public int Opid { get; set; }

	public string ModelName { get; set; }

	public string GrainType { get; set; }

	public string Process { get; set; }

	public string Pass { get; set; }

	public string Capacity { get; set; }

	public string PolishRequirement { get; set; }

	public string MotorQ { get; set; }

	public string MotorType { get; set; }

	public string MotorRating { get; set; }

	public string Drive { get; set; }

	public string Motor { get; set; }

	public string Sieve { get; set; }

	public string ReducerRing { get; set; }

	public string Ctcoil { get; set; }

	public string Accessories1 { get; set; }

	public string Accessories2 { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public int ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
