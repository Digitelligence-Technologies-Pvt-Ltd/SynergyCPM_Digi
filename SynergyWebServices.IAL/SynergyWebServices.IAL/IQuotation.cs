using SynergyWebServices.DEL;

namespace SynergyWebServices.IAL;

public interface IQuotation
{
	CommonEntity.CommonResponseWithIds AddAndEditSorterQuotation(QuotationEntity.QuotationCustom data);

	CommonEntity.CommonResponseWithIds AddAndEditRiceMillQuotation(QuotationEntity.QuotationCustom data);

	CommonEntity.CommonResponseWithIds AddAndEditSpareQuotation(QuotationEntity.SpareQuotationCustom data);

	CommonEntity.CommonResponse GetCustomerAndQuotationNumber(QuotationEntity.QuotationNumberCustom data);

	CommonEntity.CommonResponse GetAllMasterProducts();

	CommonEntity.CommonResponse GetAllProducts(int masterProductId);

	CommonEntity.CommonResponse GetAllProductModelSorter();

	CommonEntity.CommonResponse GetAllProductModelRiceMill(int productId);

	CommonEntity.CommonResponse GetAllProductModelSpare();

	CommonEntity.CommonResponse GetAllTermsAndCondition(string termsAndConditionFor);
}
