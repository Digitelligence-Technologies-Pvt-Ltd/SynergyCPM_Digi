using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.Controllers;

[ApiController]
public class QuotationController : ControllerBase
{
	private readonly AppSettings _appSettings;

	private readonly IQuotation quotation;

	public QuotationController(IOptions<AppSettings> appSettings, IQuotation _quotation)
	{
		_appSettings = appSettings.Value;
		quotation = _quotation;
	}

	[HttpPost]
	[Route("Quotation/AddAndEditSorterQuotation")]
	public async Task<IActionResult> AddAndEditSorterQuotation(QuotationEntity.QuotationCustom data)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		new CommonEntity.CommonResponseWithIds();
		CommonEntity.CommonResponseWithIds response = quotation.AddAndEditSorterQuotation(data);
		return Ok(response);
	}

	[HttpPost]
	[Route("Quotation/AddAndEditRiceMillQuotation")]
	public async Task<IActionResult> AddAndEditRiceMillQuotation(QuotationEntity.QuotationCustom data)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		new CommonEntity.CommonResponseWithIds();
		CommonEntity.CommonResponseWithIds response = quotation.AddAndEditRiceMillQuotation(data);
		return Ok(response);
	}

	[HttpPost]
	[Route("Quotation/AddAndEditSpareQuotation")]
	public async Task<IActionResult> AddAndEditSpareQuotation(QuotationEntity.SpareQuotationCustom data)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		new CommonEntity.CommonResponseWithIds();
		CommonEntity.CommonResponseWithIds response = quotation.AddAndEditSpareQuotation(data);
		return Ok(response);
	}

	[HttpPost]
	[Route("Quotation/GetCustomerAndQuotationNumber")]
	public async Task<IActionResult> GetCustomerAndQuotationNumber(QuotationEntity.QuotationNumberCustom data)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetCustomerAndQuotationNumber(data);
		return Ok(response);
	}

	[HttpGet]
	[Route("Quotation/GetAllMasterProducts")]
	public async Task<IActionResult> GetAllMasterProducts()
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetAllMasterProducts();
		return Ok(response);
	}

	[HttpGet]
	[Route("Quotation/GetAllProducts")]
	public async Task<IActionResult> GetAllProducts(int masterProductId)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetAllProducts(masterProductId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Quotation/GetAllProductModelSorter")]
	public async Task<IActionResult> GetAllProductModelSorter()
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetAllProductModelSorter();
		return Ok(response);
	}

	[HttpGet]
	[Route("Quotation/GetAllProductModelRiceMill")]
	public async Task<IActionResult> GetAllProductModelRiceMill(int productId)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetAllProductModelRiceMill(productId);
		return Ok(response);
	}

	[HttpGet]
	[Route("Quotation/GetAllProductModelSpare")]
	public async Task<IActionResult> GetAllProductModelSpare()
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetAllProductModelSpare();
		return Ok(response);
	}

	[HttpGet]
	[Route("Quotation/GetAllTermsAndCondition")]
	public async Task<IActionResult> GetAllTermsAndCondition(string termsAndConditionFor)
	{
		ClaimsIdentity identity = base.HttpContext.User.Identity as ClaimsIdentity;
		string id = "";
		if (identity != null)
		{
			_ = identity.Claims;
			id = (from m in identity.Claims
				where m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"
				select m.Value).FirstOrDefault();
			(from m in identity.Claims
				where m.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
				select m.Value).FirstOrDefault();
		}
		Convert.ToInt32(id);
		CommonEntity.CommonResponse response = quotation.GetAllTermsAndCondition(termsAndConditionFor);
		return Ok(response);
	}
}
