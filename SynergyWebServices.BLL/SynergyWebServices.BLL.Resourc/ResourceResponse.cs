using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SynergyWebServices.BLL.Resource;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class ResourceResponse
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("SynergyWebServices.BLL.Resource.ResourceResponse", typeof(ResourceResponse).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	public static string CustomerDataAlreadyExists => ResourceManager.GetString("CustomerDataAlreadyExists", resourceCulture);

	public static string PaymentSucessful => ResourceManager.GetString("PaymentSucessful", resourceCulture);

	public static string PaymentNotSucessful => ResourceManager.GetString("PaymentNotSucessful", resourceCulture);

	public static string AdLimtReached => ResourceManager.GetString("AdLimtReached", resourceCulture);

	public static string CouponAlreadyRedeemed => ResourceManager.GetString("CouponAlreadyRedeemed", resourceCulture);

	public static string SubmitedSucessfully => ResourceManager.GetString("SubmitedSucessfully", resourceCulture);

	public static string AddedSucessfully => ResourceManager.GetString("AddedSucessfully", resourceCulture);

	public static string ThisIsLastQuestion => ResourceManager.GetString("ThisIsLastQuestion", resourceCulture);

	public static string NotAuthorizedUser => ResourceManager.GetString("NotAuthorizedUser", resourceCulture);

	public static string TotalQuestionAlreadyFilled => ResourceManager.GetString("TotalQuestionAlreadyFilled", resourceCulture);

	public static string PasswordResetSuccessful => ResourceManager.GetString("PasswordResetSuccessful", resourceCulture);

	public static string AccountActivated => ResourceManager.GetString("AccountActivated", resourceCulture);

	public static string LinkTimedOut => ResourceManager.GetString("LinkTimedOut", resourceCulture);

	public static string LinkError => ResourceManager.GetString("LinkError", resourceCulture);

	public static string MailSentSuccessful => ResourceManager.GetString("MailSentSuccessful", resourceCulture);

	public static string ApprovedSucessfully => ResourceManager.GetString("ApprovedSucessfully", resourceCulture);

	public static string BarCodeAlreadyExists => ResourceManager.GetString("BarCodeAlreadyExists", resourceCulture);

	public static string BarcodeNotAssignedForThisActivity => ResourceManager.GetString("BarcodeNotAssignedForThisActivity", resourceCulture);

	public static string BarcodeNotFoundInAssetLibray => ResourceManager.GetString("BarcodeNotFoundInAssetLibray", resourceCulture);

	public static string CheckListCreatedSuccessfully => ResourceManager.GetString("CheckListCreatedSuccessfully", resourceCulture);

	public static string DeletedSucessfully => ResourceManager.GetString("DeletedSucessfully", resourceCulture);

	public static string ExceptionMessage => ResourceManager.GetString("ExceptionMessage", resourceCulture);

	public static string FailureMessage => ResourceManager.GetString("FailureMessage", resourceCulture);

	public static string FileUploaderFailure => ResourceManager.GetString("FileUploaderFailure", resourceCulture);

	public static string FileUploaderSuccess => ResourceManager.GetString("FileUploaderSuccess", resourceCulture);

	public static string JobClosedSuccessfully => ResourceManager.GetString("JobClosedSuccessfully", resourceCulture);

	public static string JobNotCompletelyCreated => ResourceManager.GetString("JobNotCompletelyCreated", resourceCulture);

	public static string JobNotYetCompleted => ResourceManager.GetString("JobNotYetCompleted", resourceCulture);

	public static string LoginUnSuccessful => ResourceManager.GetString("LoginUnSuccessful", resourceCulture);

	public static string MovedSuccessfully => ResourceManager.GetString("MovedSuccessfully", resourceCulture);

	public static string NoItemsFound => ResourceManager.GetString("NoItemsFound", resourceCulture);

	public static string NoJobsAssignedAdmin => ResourceManager.GetString("NoJobsAssignedAdmin", resourceCulture);

	public static string NoJobsAssignedSuperAdmin => ResourceManager.GetString("NoJobsAssignedSuperAdmin", resourceCulture);

	public static string NoSuggestionsFound => ResourceManager.GetString("NoSuggestionsFound", resourceCulture);

	public static string RejectedSucessfully => ResourceManager.GetString("RejectedSucessfully", resourceCulture);

	public static string UpdatedSucessfully => ResourceManager.GetString("UpdatedSucessfully", resourceCulture);

	public static string UserAlreadyExists => ResourceManager.GetString("UserAlreadyExists", resourceCulture);

	public static string UserDoesNotExists => ResourceManager.GetString("UserDoesNotExists", resourceCulture);

	internal ResourceResponse()
	{
	}
}
