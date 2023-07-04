namespace SynergyWebServices.BLL.Helpers;

public class AppSettings
{
	public string Secret { get; set; }

	public string CommonEmail { get; set; }

	public string DocumentEmail { get; set; }

	public string ActivateUser { get; set; }

	public string ImageUrl { get; set; }

	public string ImageUrlSave { get; set; }

	public string CandidateUploadURL { get; set; }

	public string BarCodeTemplate { get; set; }

	public string ToolIssueTemplate { get; set; }

	public string DefaultConnection { get; set; }

	public string AdminRole { get; set; }

	public string SuperAdminRole { get; set; }

	public string CustomerRole { get; set; }

	public string SmsKey { get; set; }

	public string SmsDetailsPost { get; set; }
}
