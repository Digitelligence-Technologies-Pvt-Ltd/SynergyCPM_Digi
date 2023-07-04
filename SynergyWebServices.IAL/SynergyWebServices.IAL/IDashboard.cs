using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IDashboard
{
	CommonEntity.CommonResponse GetDashboardDetails(string userId);

	CommonEntity.CommonResponse GetCPDetailsInDashboard(string userId);

	CommonEntity.CommonResponse GetCPDetailsInDashboardForQuotation(string userId);

    CommonEntity.CommonResponse UpdateCHFValue(decimal CHFValue);
	CommonEntity.CommonResponse GetDashboardFilter(string cpid, string zoneid, string buid,string userId); 
}
