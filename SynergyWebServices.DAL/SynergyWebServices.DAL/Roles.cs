using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class Roles
{
	public Guid RoleId { get; set; }

	public Guid ApplicationId { get; set; }

	public string RoleName { get; set; }

	public string Description { get; set; }

	public virtual Applications Application { get; set; }

	public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }

	public Roles()
	{
		UsersInRoles = new HashSet<UsersInRoles>();
	}
}
