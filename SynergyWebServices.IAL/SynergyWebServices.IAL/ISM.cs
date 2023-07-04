using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface ISM
{
	CommonEntity.CommonResponse AddAndEditSM(SMEntity.SMCustom data, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleSM();

	CommonEntity.CommonResponse ViewSMById(int managerId);

	CommonEntity.CommonResponse ViewSMByCPId(string userId);

	CommonEntity.CommonResponse DeleteSM(int managerId, long userId = 0L);

	CommonEntity.CommonResponse ArchiveSM(int managerId, long userId = 0L);
}
