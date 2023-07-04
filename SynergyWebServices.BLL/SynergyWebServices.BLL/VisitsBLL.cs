using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.App_Start;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.BLL;

public class VisitsBLL : IVisits
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(VisitsBLL));

	private readonly AppSettings appSettings;

	public VisitsBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponseWithIds AddAndEditVisits(VisitsEntity.VisitsCustom data, long userId = 0L)
	{
		CommonEntity.CommonResponseWithIds obj = new CommonEntity.CommonResponseWithIds();
		try
		{
			VisitHistory res = db.VisitHistory.Where((VisitHistory m) => m.VisitHistoryId == data.visitHistoryId).FirstOrDefault();
			if (res == null)
			{
				try
				{
					VisitHistory item = new VisitHistory();
					item.UserId = data.userId;
					item.CompanyUniqueId = data.companyUniqueId;
					item.VisitPurpose = data.visitPurpose;
					try
					{
						item.VisitDateTime = Convert.ToDateTime(data.visitDateTime);
					}
					catch (Exception)
					{
					}
					item.VisitStatus = data.visitStatus;
					item.ProductModelId = data.productModelId;
					item.BuId = data.buId;
					item.MasterProducts = data.masterProducts;
					item.SalesManagerId = data.salesManagerId;
					item.IsCall = data.isCall;
					item.VisitType = data.visitType;
					item.IsDeleted = false;
					item.IsActive = true;
					item.CreatedOn = DateTime.Now;
					item.Comments = data.comments;
					try
					{
						item.NextVisitDate = Convert.ToDateTime(data.nextVisitDate);
					}
					catch (Exception)
					{
					}
					item.CpEnginneerId = data.cpEnginneerId;
					db.VisitHistory.Add(item);
					db.SaveChanges();
					obj.response = ResourceResponse.AddedSucessfully;
					obj.isStatus = true;
					obj.id = item.VisitHistoryId;
					return obj;
				}
				catch (Exception ex3)
				{
					log.Error(ex3);
					if (ex3.InnerException != null)
					{
						log.Error(ex3.InnerException.ToString());
					}
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
					return obj;
				}
			}
			try
			{
				res.UserId = data.userId;
				res.CompanyUniqueId = data.companyUniqueId;
				res.VisitPurpose = data.visitPurpose;
				try
				{
					res.VisitDateTime = Convert.ToDateTime(data.visitDateTime);
				}
				catch (Exception)
				{
				}
				try
				{
					res.NextVisitDate = Convert.ToDateTime(data.nextVisitDate);
				}
				catch (Exception)
				{
				}
				res.CpEnginneerId = data.cpEnginneerId;
				res.BuId = data.buId;
				res.VisitStatus = data.visitStatus;
				res.ProductModelId = data.productModelId;
				res.Comments = data.comments;
				res.SalesManagerId = data.salesManagerId;
				res.MasterProducts = data.masterProducts;
				res.IsCall = data.isCall;
				res.VisitType = data.visitType;
				res.ModifiedOn = DateTime.Now;
				db.SaveChanges();
				obj.response = ResourceResponse.UpdatedSucessfully;
				obj.isStatus = true;
				obj.id = res.VisitHistoryId;
				return obj;
			}
			catch (Exception ex2)
			{
				log.Error(ex2);
				if (ex2.InnerException != null)
				{
					log.Error(ex2.InnerException.ToString());
				}
				obj.response = ResourceResponse.ExceptionMessage;
				obj.isStatus = false;
				return obj;
			}
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse ViewMultipleVisits()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var list = (from wf in db.VisitHistory
				where wf.IsDeleted == (bool?)false
				select new
				{
					visitHistoryId = wf.VisitHistoryId,
					companyUniqueId = wf.CompanyUniqueId,
					companyUniqueName = (from m in db.MdbgeneralData
						where m.CompanyUniqueId == wf.CompanyUniqueId
						select m.OrganizationName).FirstOrDefault(),
					visitPurpose = wf.VisitPurpose,
					visitDateTime = wf.VisitDateTime,
					nextVisitDate = wf.NextVisitDate,
					cpEnginneerId = wf.CpEnginneerId,
					cpName = (from m in db.ChannelPartnersEngineer
						where (int?)m.ChannelPartnersEngineerId == wf.CpEnginneerId
						select m.Name).FirstOrDefault(),
					visitStatus = wf.VisitStatus,
					buId = wf.BuId,
					salesManagerId = wf.SalesManagerId,
					salesManagerName = (from m in db.SalesManagerMaster
						where (int?)m.ManagerId == wf.SalesManagerId
						select m.ManagerName).FirstOrDefault(),
					productModelId = wf.ProductModelId,
					masterProducts = wf.MasterProducts,
					isCall = wf.IsCall,
					visitType = wf.VisitType,
					userId = wf.UserId
				}).ToList();
			List<VisitsEntity.VisitsViewCustom> visitHistoryList = new List<VisitsEntity.VisitsViewCustom>();
			foreach (var wf2 in list)
			{
				VisitsEntity.VisitsViewCustom visitsViewCustom = new VisitsEntity.VisitsViewCustom();
				visitsViewCustom.visitHistoryId = wf2.visitHistoryId;
				visitsViewCustom.userId = wf2.userId;
				visitsViewCustom.companyUniqueId = wf2.companyUniqueId;
				visitsViewCustom.companyUniqueName = wf2.companyUniqueName;
				visitsViewCustom.visitPurpose = wf2.visitPurpose;
				visitsViewCustom.displayVisitDateTime = wf2.visitDateTime.ToString();
				visitsViewCustom.displayNextVisitDate = wf2.nextVisitDate.ToString();
				visitsViewCustom.cpEnginneerId = wf2.cpEnginneerId;
				visitsViewCustom.cpName = wf2.cpName;
				visitsViewCustom.visitStatus = wf2.visitStatus;
				visitsViewCustom.salesManagerId = wf2.salesManagerId;
				visitsViewCustom.salesManagerName = wf2.salesManagerName;
				visitsViewCustom.productModelId = wf2.productModelId;
				visitsViewCustom.buId = wf2.buId;
				string buids = wf2.buId;
				List<long> buIds = buids.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string buName = (visitsViewCustom.buName = string.Join(",", (from m in db.BusinessUnit
					where buIds.Contains(m.BuId)
					select m.BuName).ToList()));
				visitsViewCustom.masterProducts = wf2.masterProducts;
				string masterproducts = wf2.masterProducts;
				List<long> masterProducts = masterproducts.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string masterProductsName = (visitsViewCustom.masterProductsName = string.Join(",", (from m in db.MasterProducts
					where masterProducts.Contains(m.MasterProductId)
					select m.MasterProductName).ToList()));
				string productModelids = wf2.productModelId;
				List<long> productModelIds = productModelids.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string productModelName = (visitsViewCustom.productModelName = string.Join(",", (from m in db.ProductModel
					where productModelIds.Contains(m.ProductModelId)
					select m.ProductModelName).ToList()));
				visitsViewCustom.visitType = wf2.visitType;
				visitsViewCustom.isCall = wf2.isCall;
				visitHistoryList.Add(visitsViewCustom);
			}
			if (visitHistoryList.Count() != 0)
			{
				obj.response = visitHistoryList;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse ViewMultipleVisitsBasedOnUserId(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = commonFunction.GetRoleName(userId);
			var list = (from wf in db.VisitHistory
				where wf.IsDeleted == (bool?)false
				select new
				{
					visitHistoryId = wf.VisitHistoryId,
					companyUniqueId = wf.CompanyUniqueId,
					companyUniqueName = (from m in db.MdbgeneralData
						where m.CompanyUniqueId == wf.CompanyUniqueId
						select m.OrganizationName).FirstOrDefault(),
					visitPurpose = wf.VisitPurpose,
					visitDateTime = wf.VisitDateTime,
					nextVisitDate = wf.NextVisitDate,
					cpEnginneerId = wf.CpEnginneerId,
					cpName = (from m in db.ChannelPartnersEngineer
						where (int?)m.ChannelPartnersEngineerId == wf.CpEnginneerId
						select m.Name).FirstOrDefault(),
					visitStatus = wf.VisitStatus,
					buId = wf.BuId,
					salesManagerId = wf.SalesManagerId,
					salesManagerName = (from m in db.SalesManagerMaster
						where (int?)m.ManagerId == wf.SalesManagerId
						select m.ManagerName).FirstOrDefault(),
					productModelId = wf.ProductModelId,
					masterProducts = wf.MasterProducts,
					isCall = wf.IsCall,
					visitType = wf.VisitType,
					userId = wf.UserId,
					comments = wf.Comments
				} into m
				orderby m.visitHistoryId descending
				select m).ToList();
			List<VisitsEntity.VisitsViewCustom> visitHistoryList = new List<VisitsEntity.VisitsViewCustom>();
			foreach (var wf2 in list)
			{
				VisitsEntity.VisitsViewCustom visitsViewCustom = new VisitsEntity.VisitsViewCustom();
				visitsViewCustom.visitHistoryId = wf2.visitHistoryId;
				visitsViewCustom.userId = wf2.userId;
				visitsViewCustom.companyUniqueId = wf2.companyUniqueId;
				visitsViewCustom.companyUniqueName = wf2.companyUniqueName;
				visitsViewCustom.visitPurpose = wf2.visitPurpose;
				visitsViewCustom.displayVisitDateTime = Convert.ToDateTime(wf2.visitDateTime).ToString("dd-MM-yyyy");
				visitsViewCustom.displayNextVisitDate = Convert.ToDateTime(wf2.nextVisitDate).ToString("dd-MM-yyyy");
				visitsViewCustom.nextVisitDate = Convert.ToDateTime(wf2.nextVisitDate);
				visitsViewCustom.visitDateTime = Convert.ToDateTime(wf2.visitDateTime);
				visitsViewCustom.cpEnginneerId = wf2.cpEnginneerId;
				visitsViewCustom.cpName = wf2.cpName;
				visitsViewCustom.visitStatus = wf2.visitStatus;
				visitsViewCustom.salesManagerId = wf2.salesManagerId;
				visitsViewCustom.salesManagerName = wf2.salesManagerName;
				visitsViewCustom.comments = wf2.comments;
				if (wf2.buId != null)
				{
					string[] array = wf2.buId.Split(new char[1] { ',' });
					List<VisitsEntity.BuNameList> buNameLists = new List<VisitsEntity.BuNameList>();
					string[] array2 = array;
					foreach (string item in array2)
					{
						string buName = (from m in db.BusinessUnit
							where m.BuId == Convert.ToInt32(item)
							select m.BuName).FirstOrDefault();
						if (buName != null)
						{
							VisitsEntity.BuNameList buNameList = new VisitsEntity.BuNameList();
							buNameList.buId = Convert.ToInt32(item);
							buNameList.buName = buName;
							buNameLists.Add(buNameList);
						}
					}
					visitsViewCustom.buNameLists = buNameLists;
				}
				if (wf2.masterProducts != null)
				{
					string[] array3 = wf2.masterProducts.Split(new char[1] { ',' });
					List<VisitsEntity.MasterProductList> masterProductLists = new List<VisitsEntity.MasterProductList>();
					string[] array2 = array3;
					foreach (string items in array2)
					{
						string masterProductName = (from m in db.Products
							where m.ProductId == Convert.ToInt32(items)
							select m.ProductName).FirstOrDefault();
						if (masterProductName != null)
						{
							VisitsEntity.MasterProductList masterProductList = new VisitsEntity.MasterProductList();
							masterProductList.productId = Convert.ToInt32(items);
							masterProductList.productName = masterProductName;
							masterProductLists.Add(masterProductList);
						}
					}
					visitsViewCustom.masterProductLists = masterProductLists;
				}
				if (wf2.productModelId != null)
				{
					string[] array4 = wf2.productModelId.Split(new char[1] { ',' });
					List<VisitsEntity.ProductModelList> productModelLists = new List<VisitsEntity.ProductModelList>();
					string[] array2 = array4;
					foreach (string items2 in array2)
					{
						string productModelName = (from m in db.ProductModel
							where m.ProductModelId == Convert.ToInt32(items2)
							select m.ProductModelName).FirstOrDefault();
						if (productModelName != null)
						{
							VisitsEntity.ProductModelList productModelList = new VisitsEntity.ProductModelList();
							productModelList.productModelId = Convert.ToInt32(items2);
							productModelList.productModelName = productModelName;
							productModelLists.Add(productModelList);
						}
					}
					visitsViewCustom.productModelLists = productModelLists;
				}
				visitsViewCustom.visitType = wf2.visitType;
				visitsViewCustom.isCall = wf2.isCall;
				visitHistoryList.Add(visitsViewCustom);
			}
			if (roleName != "Administrator")
			{
				visitHistoryList = visitHistoryList.Where((VisitsEntity.VisitsViewCustom wf) => wf.userId == userId).ToList();
			}
			if (visitHistoryList.Count() != 0)
			{
				obj.response = visitHistoryList;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse ViewMultipleVisitsBasedOnUserAndCustomerId(string userId, string companyUniqueId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var list = (from wf in db.VisitHistory
				where wf.IsDeleted == (bool?)false && wf.UserId == userId && wf.CompanyUniqueId == companyUniqueId
				select new
				{
					visitHistoryId = wf.VisitHistoryId,
					companyUniqueId = wf.CompanyUniqueId,
					companyUniqueName = (from m in db.MdbgeneralData
						where m.CompanyUniqueId == wf.CompanyUniqueId
						select m.OrganizationName).FirstOrDefault(),
					visitPurpose = wf.VisitPurpose,
					visitDateTime = wf.VisitDateTime,
					nextVisitDate = wf.NextVisitDate,
					cpEnginneerId = wf.CpEnginneerId,
					cpName = (from m in db.ChannelPartnersEngineer
						where (int?)m.ChannelPartnersEngineerId == wf.CpEnginneerId
						select m.Name).FirstOrDefault(),
					visitStatus = wf.VisitStatus,
					buId = wf.BuId,
					salesManagerId = wf.SalesManagerId,
					salesManagerName = (from m in db.SalesManagerMaster
						where (int?)m.ManagerId == wf.SalesManagerId
						select m.ManagerName).FirstOrDefault(),
					productModelId = wf.ProductModelId,
					masterProducts = wf.MasterProducts,
					isCall = wf.IsCall,
					visitType = wf.VisitType,
					userId = wf.UserId
				}).ToList();
			List<VisitsEntity.VisitsViewCustom> visitHistoryList = new List<VisitsEntity.VisitsViewCustom>();
			foreach (var wf2 in list)
			{
				VisitsEntity.VisitsViewCustom visitsViewCustom = new VisitsEntity.VisitsViewCustom();
				visitsViewCustom.visitHistoryId = wf2.visitHistoryId;
				visitsViewCustom.userId = wf2.userId;
				visitsViewCustom.companyUniqueId = wf2.companyUniqueId;
				visitsViewCustom.companyUniqueName = wf2.companyUniqueName;
				visitsViewCustom.visitPurpose = wf2.visitPurpose;
				visitsViewCustom.displayVisitDateTime = wf2.visitDateTime.ToString();
				visitsViewCustom.displayNextVisitDate = wf2.nextVisitDate.ToString();
				visitsViewCustom.cpEnginneerId = wf2.cpEnginneerId;
				visitsViewCustom.cpName = wf2.cpName;
				visitsViewCustom.visitStatus = wf2.visitStatus;
				visitsViewCustom.salesManagerId = wf2.salesManagerId;
				visitsViewCustom.salesManagerName = wf2.salesManagerName;
				visitsViewCustom.productModelId = wf2.productModelId;
				visitsViewCustom.buId = wf2.buId;
				string buids = wf2.buId;
				List<long> buIds = buids.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string buName = (visitsViewCustom.buName = string.Join(",", (from m in db.BusinessUnit
					where buIds.Contains(m.BuId)
					select m.BuName).ToList()));
				visitsViewCustom.masterProducts = wf2.masterProducts;
				string masterproducts = wf2.masterProducts;
				List<long> masterProducts = masterproducts.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string masterProductsName = (visitsViewCustom.masterProductsName = string.Join(",", (from m in db.MasterProducts
					where masterProducts.Contains(m.MasterProductId)
					select m.MasterProductName).ToList()));
				string productModelids = wf2.productModelId;
				List<long> productModelIds = productModelids.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string productModelName = (visitsViewCustom.productModelName = string.Join(",", (from m in db.ProductModel
					where productModelIds.Contains(m.ProductModelId)
					select m.ProductModelName).ToList()));
				visitsViewCustom.visitType = wf2.visitType;
				visitsViewCustom.isCall = wf2.isCall;
				visitHistoryList.Add(visitsViewCustom);
			}
			if (visitHistoryList.Count() != 0)
			{
				obj.response = visitHistoryList;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse ViewVisitsById(int visitHistoryId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.VisitHistory
				where wf.IsDeleted == (bool?)false && wf.VisitHistoryId == (long)visitHistoryId
				select new
				{
					visitHistoryId = wf.VisitHistoryId,
					companyUniqueId = wf.CompanyUniqueId,
					companyUniqueName = (from m in db.MdbgeneralData
						where m.CompanyUniqueId == wf.CompanyUniqueId
						select m.OrganizationName).FirstOrDefault(),
					visitPurpose = wf.VisitPurpose,
					visitDateTime = wf.VisitDateTime,
					nextVisitDate = wf.NextVisitDate,
					cpEnginneerId = wf.CpEnginneerId,
					cpName = (from m in db.ChannelPartnersEngineer
						where (int?)m.ChannelPartnersEngineerId == wf.CpEnginneerId
						select m.Name).FirstOrDefault(),
					visitStatus = wf.VisitStatus,
					buId = wf.BuId,
					salesManagerId = wf.SalesManagerId,
					salesManagerName = (from m in db.SalesManagerMaster
						where (int?)m.ManagerId == wf.SalesManagerId
						select m.ManagerName).FirstOrDefault(),
					productModelId = wf.ProductModelId,
					masterProducts = wf.MasterProducts,
					isCall = wf.IsCall,
					visitType = wf.VisitType
				}).FirstOrDefault();
			if (result != null)
			{
				VisitsEntity.VisitsViewCustom visitsViewCustom = new VisitsEntity.VisitsViewCustom();
				visitsViewCustom.visitHistoryId = result.visitHistoryId;
				visitsViewCustom.companyUniqueId = result.companyUniqueId;
				visitsViewCustom.companyUniqueName = result.companyUniqueName;
				visitsViewCustom.visitPurpose = result.visitPurpose;
				visitsViewCustom.displayVisitDateTime = result.visitDateTime.ToString();
				visitsViewCustom.displayNextVisitDate = result.nextVisitDate.ToString();
				visitsViewCustom.cpEnginneerId = result.cpEnginneerId;
				visitsViewCustom.cpName = result.cpName;
				visitsViewCustom.visitStatus = result.visitStatus;
				visitsViewCustom.salesManagerId = result.salesManagerId;
				visitsViewCustom.salesManagerName = result.salesManagerName;
				visitsViewCustom.productModelId = result.productModelId;
				visitsViewCustom.buId = result.buId;
				string buids = result.buId;
				List<long> buIds = buids.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string buName = (visitsViewCustom.buName = string.Join(",", (from m in db.BusinessUnit
					where buIds.Contains(m.BuId)
					select m.BuName).ToList()));
				visitsViewCustom.masterProducts = result.masterProducts;
				string masterproducts = result.masterProducts;
				List<long> masterProducts = masterproducts.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string masterProductsName = (visitsViewCustom.masterProductsName = string.Join(",", (from m in db.MasterProducts
					where masterProducts.Contains(m.MasterProductId)
					select m.MasterProductName).ToList()));
				string productModelids = result.productModelId;
				List<long> productModelIds = productModelids.Split(new char[1] { ',' }).Select(long.Parse).ToList();
				string productModelName = (visitsViewCustom.productModelName = string.Join(",", (from m in db.ProductModel
					where productModelIds.Contains(m.ProductModelId)
					select m.ProductModelName).ToList()));
				visitsViewCustom.visitType = result.visitType;
				visitsViewCustom.isCall = result.isCall;
				obj.response = visitsViewCustom;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse DeleteVisits(int visitHistoryId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			VisitHistory res = db.VisitHistory.Where((VisitHistory m) => m.VisitHistoryId == (long)visitHistoryId).FirstOrDefault();
			if (res != null)
			{
				res.IsDeleted = true;
				res.ModifiedOn = DateTime.Now;
				db.SaveChanges();
				obj.response = ResourceResponse.DeletedSucessfully;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.FailureMessage;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse ArchiveVisits(int visitHistoryId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			VisitHistory result = db.VisitHistory.Where((VisitHistory m) => m.VisitHistoryId == (long)visitHistoryId).FirstOrDefault();
			if (result != null)
			{
				result.IsActive = false;
				result.ModifiedOn = DateTime.Now;
				db.SaveChanges();
				obj.response = ResourceResponse.DeletedSucessfully;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.FailureMessage;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse GetAllCustomerForVisit(string customerName, string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			Guid userIdGuid = commonFunction.ConvertToGuid(userId);
			Guid userid = (from m in db.Memberships
				where m.UserId == userIdGuid
				select m.UserId).FirstOrDefault();
			var loginname = (from m in db.UserLogins
				where m.UserId == userid
				select new { m.Cpid }).SingleOrDefault();
			if (loginname.Cpid != 0)
			{
				var result2 = (from r in db.MdbgeneralData
					where r.OrganizationName.ToLower().Contains(customerName.ToLower()) && r.Cpid == loginname.Cpid && r.IsDeleted == 0
					select new
					{
						OrganizationName = r.OrganizationName,
						CompanyUniqueId = r.CompanyUniqueId,
						custname = r.Mdbid
					}).Distinct().ToList();
				if (result2.Count > 0)
				{
					obj.response = result2;
					obj.isStatus = true;
					return obj;
				}
				return obj;
			}
			var result = (from r in db.MdbgeneralData
				where r.OrganizationName.ToLower().Contains(customerName.ToLower()) && r.IsDeleted == 0
				select new
				{
					OrganizationName = r.OrganizationName,
					CompanyUniqueId = r.CompanyUniqueId,
					custname = r.Mdbid
				}).Distinct().ToList();
			if (result.Count > 0)
			{
				obj.response = result;
				obj.isStatus = true;
				return obj;
			}
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse GetAllVisitsPurpose(long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.VisitPurpose
				where wf.IsDeleted == (bool?)false
				select new
				{
					visitPurposeId = wf.VisitPurposeId,
					visitPurpose = wf.VisitPurpose1,
					description = wf.Description
				}).ToList();
			if (result.Count > 0)
			{
				obj.response = result;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse GetAllVisitsEquipments(string masterproductIds, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			List<long> masterProducts = masterproductIds.Split(new char[1] { ',' }).Select(long.Parse).ToList();
			var result = (from m in db.ProductModel
				where masterProducts.Contains(m.ProductId) && m.IsDeleted == 0
				select new { m.ProductModelName, m.ProductModelId }).ToList();
			if (result != null)
			{
				obj.response = result;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse GetAllVisitsMasterProducts(long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from m in db.Products
				where m.IsDeleted == 0
				select new { m.ProductName, m.ProductId }).ToList();
			if (result != null)
			{
				obj.response = result;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
			}
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}
}
