using System;

namespace SynergyWebServices.DAL;

public class UsersInRoles
{
	public Guid UserId { get; set; }

	public Guid RoleId { get; set; }

	public virtual Roles Role { get; set; }

	public virtual Users User { get; set; }
}
