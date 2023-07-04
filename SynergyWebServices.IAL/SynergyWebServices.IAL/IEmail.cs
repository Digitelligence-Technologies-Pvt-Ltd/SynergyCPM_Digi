using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IEmail
{
	CommonEntity.CommonResponse SendMailToViewNextFollowUpDates();

	CommonEntity.CommonResponse SendMailToViewDues();
}
