using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface ICPEngineer
{
	CommonEntity.CommonResponse AddAndEditCPEngineer(CPEngineerEntity.CPEngineerCustom data, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleCPEngineer();

	CommonEntity.CommonResponse ViewMultipleCPEngineerBasedOnUserId(string userId);

	CommonEntity.CommonResponse ViewMultipleCPEngineerBasedOnCPId(int cpId);

	CommonEntity.CommonResponse ViewCPEngineerById(int channelPartnersEngineerId);

	CommonEntity.CommonResponse DeleteCPEngineer(int channelPartnersEngineerId, long userId = 0L);

	CommonEntity.CommonResponse ArchiveCPEngineer(int channelPartnersEngineerId, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleCP();

	CommonEntity.CommonResponse GetUserType(string userId);
	CommonEntity.CommonResponse ViewZone();
}
