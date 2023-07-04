using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IBU
{
	CommonEntity.CommonResponse AddAndEditBU(BUEntity.BUCustom data, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleBU();

	CommonEntity.CommonResponse ViewBUById(int buId);

	CommonEntity.CommonResponse DeleteBU(int buId, long userId = 0L);

	CommonEntity.CommonResponse ArchiveBU(int buId, long userId = 0L);
}
