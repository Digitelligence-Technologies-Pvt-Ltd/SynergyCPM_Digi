using System;

namespace SynergyWebServices.DAL;

public class UserLogins
{
	public Guid UserId { get; set; }

	public string FirstName { get; set; }

	public string MiddleName { get; set; }

	public string LastName { get; set; }

	public string Isd1 { get; set; }

	public string Std1 { get; set; }

	public string PhoneNo { get; set; }

	public int Cpid { get; set; }

	public string Answer { get; set; }

	public string Designation { get; set; }

	public string Username { get; set; }

	public string Email { get; set; }

	public int IsDeactivate { get; set; }

	public int ZoneId { get; set; }

	public int IsZoneManager { get; set; }
}
