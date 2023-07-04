using System.Collections.Generic;

namespace SynergyWebServices.DEL;

public class SMEntity
{
	public class SMCustom
	{
		public int managerId { get; set; }

		public string managerName { get; set; }

		public string managerEmailId { get; set; }

		public string managerPhoneNumber { get; set; }

		public string cpIds { get; set; }

		public string uniqueId { get; set; }
	}

	public class SMCPDetails
	{
		public int managerId { get; set; }

		public string managerName { get; set; }

		public string managerPhoneNumber { get; set; }

		public string managerEmailId { get; set; }

		public string uniqueId { get; set; }

		public string cpIds { get; set; }

		public List<int> cpId { get; set; }

		public List<CPDetails> cpDetails { get; set; }
	}

	public class CPDetails
	{
		public int cpId { get; set; }

		public string cpName { get; set; }

		public string cpUniqueId { get; set; }
	}

	public class SMUploadCustom
	{
		public string SMUniqueId { get; set; }

		public string SMName { get; set; }

		public string SMEmailId { get; set; }

		public string SMPhoneNumber { get; set; }

		public int? CpId { get; set; }

		public string CpName { get; set; }
	}
}
