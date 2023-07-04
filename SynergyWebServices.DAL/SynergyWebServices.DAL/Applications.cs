using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class Applications
{
	public Guid ApplicationId { get; set; }

	public string ApplicationName { get; set; }

	public string Description { get; set; }

	public virtual ICollection<Memberships> Memberships { get; set; }

	public virtual ICollection<Roles> Roles { get; set; }

	public virtual ICollection<Users> Users { get; set; }

	public Applications()
	{
		Memberships = new HashSet<Memberships>();
		Roles = new HashSet<Roles>();
		Users = new HashSet<Users>();
	}
}
