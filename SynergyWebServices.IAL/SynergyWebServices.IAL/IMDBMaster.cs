using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IMDBMaster
{
	CommonEntity.CommonResponse AddAndEditMDBMaster(MDBMasterEntity.MDBMasterEntityCustom data);

	CommonEntity.CommonResponseCount ViewMultipleMDBMaster(MDBMasterEntity.MDBMultiple data);

	CommonEntity.CommonResponse ViewMDBMasterById(int mdbId);

	CommonEntity.CommonResponse CheckMDBMaster(string phoneNumber);

	CommonEntity.CommonResponse DeleteMDBMaster(int mdbId, long userId = 0L);

	CommonEntity.CommonResponse ArchiveMDBMaster(int mdbId, long userId = 0L);

	CommonEntity.CommonResponse ViewMultipleStates();

	CommonEntity.CommonResponse ViewMultipleDistricts(int stateId);

	CommonEntity.CommonResponse ViewMultiplePinCode(string district);

	CommonEntity.CommonResponseCount ViewMultipleMDBMasterBySearchItem(string searchTerm, string userId);
}
