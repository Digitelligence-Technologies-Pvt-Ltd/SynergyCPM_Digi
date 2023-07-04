using System.Collections.Generic;

namespace SynergyWebServices.DEL;

public class CPEngineerEntity
{
	public class CPEngineerCustom
	{
		public int channelPartnersEngineerId { get; set; }

		public int cpid { get; set; }

		public string name { get; set; }

		public string phoneNumber { get; set; }

		public string emaiId { get; set; }

		public string status { get; set; }

		public string escalationMails { get; set; }
	}

	public class CPEngineerDetails
	{
		public int channelPartnersEngineerId { get; set; }

		public int? cpid { get; set; }

		public string cpName { get; set; }

		public string name { get; set; }

		public string phoneNumber { get; set; }

		public string emaiId { get; set; }

		public bool? status { get; set; }

		public List<string> escalationMails { get; set; }
	}
}
