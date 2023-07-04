using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IReport
{
	CommonEntity.CommonResponse GetAllStoreProcedures();

	CommonEntity.CommonResponse GenerateReport(ReportEntity.ReportEngineMaster data);

	CommonEntity.CommonResponse MDBReport(ReportEntity.MdbReportCustom data);

	CommonEntity.CommonResponse QuotationReport(ReportEntity.QuotationReport data);
}
