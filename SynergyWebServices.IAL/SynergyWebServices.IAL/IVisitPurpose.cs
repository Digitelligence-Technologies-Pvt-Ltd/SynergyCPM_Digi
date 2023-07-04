using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IVisitPurpose
{
	CommonEntity.CommonResponse AddAndEditVisitPurpose(VisitPurposeEntity.VisitPurposeCustom data, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleVisitPurpose();

	CommonEntity.CommonResponse ViewVisitPurposeById(int visitPurposeId);

	CommonEntity.CommonResponse DeleteVisitPurpose(int visitPurposeId, long userId = 0L);

	CommonEntity.CommonResponse ArchiveVisitPurpose(int visitPurposeId, long userId = 0L);
}
