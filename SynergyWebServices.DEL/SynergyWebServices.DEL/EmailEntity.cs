using System.Collections.Generic;

namespace SynergyWebServices.DEL;

public class EmailEntity
{
	public class SmptSettings
	{
		public string Server { get; set; }

		public int Port { get; set; }

		public string SenderName { get; set; }

		public string SenderEmail { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public bool SSL { get; set; }
	}

	public class SendDueDetails
	{
		public string userName { get; set; }

		public string visitDateTime { get; set; }

		public double? dueDays { get; set; }
	}

	public class FollowUpDetails
	{
		public int? cpEngineerId { get; set; }

		public string cgEngineerMailId { get; set; }

		public List<string> cpOwnerMailId { get; set; }

		public string nextVisitDate { get; set; }

		public string companyUniqueId { get; set; }

		public string customerName { get; set; }
	}
}
