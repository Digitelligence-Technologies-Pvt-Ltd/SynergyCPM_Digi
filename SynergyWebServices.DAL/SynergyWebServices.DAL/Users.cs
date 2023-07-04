using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class Users
{
	public Guid UserId { get; set; }

	public Guid ApplicationId { get; set; }

	public string UserName { get; set; }

	public bool IsAnonymous { get; set; }

	public DateTime LastActivityDate { get; set; }

	public virtual Applications Application { get; set; }

	public virtual Memberships Memberships { get; set; }

	public virtual Profiles Profiles { get; set; }

	public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }

	public Users()
	{
		UsersInRoles = new HashSet<UsersInRoles>();
	}
}
