using System.Collections.Generic;

namespace SynergyWebServices.DEL;

public class CommonEntity
{
	public class CommonResponse
	{
		public bool isStatus { get; set; }

		public dynamic response { get; set; }
	}

	public class CommonResponseCount
	{
		public bool isStatus { get; set; }

		public dynamic response { get; set; }

		public int count { get; set; }
	}

	public class CommonResponseQuestion
	{
		public bool isStatus { get; set; }

		public bool isLastQuestion { get; set; }

		public dynamic response { get; set; }
	}

	public class CommonResponseTable
	{
		public bool isStatus { get; set; }

		public dynamic response { get; set; }

		public dynamic responseTable { get; set; }
	}

	public class CommonResponseResource
	{
		public bool isStatus { get; set; }

		public dynamic responsePrimary { get; set; }

		public dynamic responseSecondary { get; set; }
	}

	public class CommonResponseWithIds
	{
		public bool isStatus { get; set; }

		public dynamic response { get; set; }

		public dynamic id { get; set; }
	}

	public class CommonResponseWithIdsDoc
	{
		public bool isStatus { get; set; }

		public dynamic response { get; set; }

		public dynamic id { get; set; }

		public dynamic url { get; set; }
	}

	public class MailSender
	{
		public dynamic emailContent { get; set; }

		public List<ToAddress> toRecipents { get; set; }

		public List<CCAddress> ccRecipents { get; set; }

		public string subject { get; set; }
	}

	public class ToAddress
	{
		public string to { get; set; }
	}

	public class CCAddress
	{
		public string cc { get; set; }
	}

	public class BccAddress
	{
		public string bcc { get; set; }
	}

	public class SkipDetailsFunction
	{
		public int skipValue { get; set; }

		public int takeValue { get; set; }
	}

	public class MailTracker
	{
		public string from { get; set; }

		public string to { get; set; }

		public int moduleId { get; set; }

		public bool isExpiryExists { get; set; }

		public int expiryHours { get; set; }

		public dynamic emailContent { get; set; }

		public bool isMailSentStatus { get; set; }
	}

	public class CommonResponseLogin
	{
		public bool isStatus { get; set; }

		public dynamic response { get; set; }

		public dynamic token { get; set; }
	}

	public class DiscountItem
	{
		public decimal? discountPercentage { get; set; }

		public decimal? discountAmount { get; set; }
	}
}
