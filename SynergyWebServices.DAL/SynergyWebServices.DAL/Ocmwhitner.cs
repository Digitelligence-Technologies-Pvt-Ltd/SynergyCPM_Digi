using System;

namespace SynergyWebServices.DAL;

public class Ocmwhitner
{
	public int Owid { get; set; }

	public string ModelName { get; set; }

	public string GrainType { get; set; }

	public string Process { get; set; }

	public string Pass { get; set; }

	public string Capacity { get; set; }

	public string MotorQ { get; set; }

	public string MotorType { get; set; }

	public string MotorRating { get; set; }

	public string Drive { get; set; }

	public string Motor { get; set; }

	public string Stone { get; set; }

	public string Sieve { get; set; }

	public string Brake { get; set; }

	public string Ctcoil { get; set; }

	public string PassageSticker { get; set; }

	public string AccessoriesToolBox { get; set; }

	public DateTime? CreatedOn { get; set; }

	public int CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public int ModifiedBy { get; set; }

	public int IsDeleted { get; set; }
}
