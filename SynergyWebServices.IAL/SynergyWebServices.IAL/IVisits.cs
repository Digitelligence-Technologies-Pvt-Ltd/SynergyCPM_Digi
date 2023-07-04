using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IVisits
{
	CommonEntity.CommonResponseWithIds AddAndEditVisits(VisitsEntity.VisitsCustom data, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleVisits();

	CommonEntity.CommonResponse ViewMultipleVisitsBasedOnUserId(string userId);

	CommonEntity.CommonResponse ViewMultipleVisitsBasedOnUserAndCustomerId(string userId, string companyUniqueId);

	CommonEntity.CommonResponse ViewVisitsById(int visitsId);

	CommonEntity.CommonResponse DeleteVisits(int visitsId, long userId = 0L);

	CommonEntity.CommonResponse ArchiveVisits(int visitsId, long userId = 0L);

	CommonEntity.CommonResponse GetAllCustomerForVisit(string customerName, string userId);

	CommonEntity.CommonResponse GetAllVisitsPurpose(long userId = 0L);

	CommonEntity.CommonResponse GetAllVisitsEquipments(string masterproductIds, long userId = 0L);

	CommonEntity.CommonResponse GetAllVisitsMasterProducts(long userId = 0L);
}
