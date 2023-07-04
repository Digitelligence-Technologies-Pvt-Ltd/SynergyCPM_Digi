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

public class QuotationBLL : IQuotation
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(QuotationBLL));

	private readonly AppSettings appSettings;

	public QuotationBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponseWithIds AddAndEditSorterQuotation(QuotationEntity.QuotationCustom data)
	{
		CommonEntity.CommonResponseWithIds obj = new CommonEntity.CommonResponseWithIds();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			if (db.QgequipGeneralData.First(o => o.QuotationNumber == data.quotationNumber) is not null)
			{


				Guid userid = commonFunction.ConvertToGuid(data.userId);
				var loginname = (from m in db.UserLogins
								 where m.UserId == userid
								 select new { m.Cpid }).SingleOrDefault();
				QgequipGeneralData qgequipGeneralData = new QgequipGeneralData();
				var cpmdb = (from m in db.MdbcontactPersonData
							 where m.Mdbid == data.mdbId
							 orderby m.Mdbcpdid
							 select new { m.Title, m.FirstName, m.MiddleName, m.LastName }).First();
				_ = from s in db.QgequipGeneralData
					select (s) into m
					orderby m.Qgid descending
					select m;
				TimeSpan.Parse(Convert.ToString(DateTime.Now.TimeOfDay));
				qgequipGeneralData.QuotationNumber = data.quotationNumber;
				qgequipGeneralData.QuotationDate = DateTime.Now;
				qgequipGeneralData.CpquotationNumber = data.cpQuotationNumber;
				qgequipGeneralData.KindAttention = data.kindAttention;
				qgequipGeneralData.CompanyUniqueId = data.companyUniqueId;
				qgequipGeneralData.Subjectinfo = data.subjectInfo;
				qgequipGeneralData.Ordergenerated = 0;
				qgequipGeneralData.QuotStatus = 0;
				qgequipGeneralData.SalesName = data.salesName;
				qgequipGeneralData.IsRiceMill = 0;
				qgequipGeneralData.LeadTime = DateTime.Now.ToString();
				qgequipGeneralData.IsTime = 0;
				qgequipGeneralData.Cpid = loginname.Cpid;
				qgequipGeneralData.KindAttention = cpmdb.Title + "." + cpmdb.FirstName + " " + cpmdb.MiddleName + " " + cpmdb.LastName;
				qgequipGeneralData.Mdbid = data.mdbId.Value;
				qgequipGeneralData.VisitHistoryId = data.visitHistoryId;
				db.QgequipGeneralData.Add(qgequipGeneralData);
				db.SaveChanges();
				int qgid = qgequipGeneralData.Qgid;
				QgequipPayment qgequipPayment = new QgequipPayment();
				qgequipPayment.Qgid = qgid;
				qgequipPayment.PaymentTerms = data.paymentTerms;
				qgequipPayment.Delivery = data.delivery;
				qgequipPayment.DateofDispatch = data.dateOfDispatch;
				qgequipPayment.Transport = data.modeOfTransport;
				qgequipPayment.Freight = data.freight;
				qgequipPayment.Cst = data.CST;
				qgequipPayment.TransitInsu = data.transitInsurance;
				if (data.commodity != null)
				{
					qgequipPayment.Commodity = data.commodity;
				}
				else
				{
					qgequipPayment.Commodity = "";
				}
				qgequipPayment.Validity = data.validity;
				qgequipPayment.Overallprice = data.grandTotal;
				db.QgequipPayment.Add(qgequipPayment);
				db.SaveChanges();
				foreach (QuotationEntity.ProductModel item in data.productModels)
				{
					QgequipTableData qgequipTableData = new QgequipTableData();
					qgequipTableData.Qgid = qgid;
					qgequipTableData.Quantity = item.quantity;
					int mpid = item.masterProductId;
					int prdid = item.productId;
					MasterProducts mpnm = db.MasterProducts.Where((MasterProducts m) => m.MasterProductId == mpid).FirstOrDefault();
					Products prdnm = db.Products.Where((Products m) => m.ProductId == prdid).FirstOrDefault();
					ProductModel prdm = db.ProductModel.Where((ProductModel m) => m.ProductModelId == item.productModelId).FirstOrDefault();
					qgequipTableData.UnitPrice = item.unitPrice;
					qgequipTableData.TotalPrice = item.totalPrice;
					if (prdm != null)
					{
						qgequipTableData.Exclusion = prdm.ProductModelExclusion;
						qgequipTableData.ProductModelId = prdm.ProductModelId;
						qgequipTableData.ModelDesc = prdm.ProductModelDesc;
					}
					qgequipTableData.ProductId = item.productId;
					qgequipTableData.MasterProductId = item.masterProductId;
					if (mpnm != null)
					{
						qgequipTableData.MasterProductName = mpnm.MasterProductName;
					}
					if (prdnm != null)
					{
						qgequipTableData.ProductName = prdnm.ProductName;
					}
					qgequipTableData.IsSotstatus = 1;
					db.QgequipTableData.Add(qgequipTableData);
					db.SaveChanges();
				}
				var list = (from qet in db.QgequipTableData
							join qeg in db.QgequipGeneralData on qet.Qgid equals qeg.Qgid
							where qet.Qgid == qgid && qeg.Islatest == 0
							select new
							{
								qet.ProductModel.ProductModelName,
								qet.Quantity
							}).ToList();
				list.Count();
				foreach (var qg in list)
				{
					Sots sot = new Sots();
					sot.Qgid = qgid;
					sot.Cpid = loginname.Cpid;
					sot.Equipment = qg.ProductModelName;
					sot.Quantity = qg.Quantity;
					sot.CreatedOn = DateTime.Now;
					sot.ModifiedOn = DateTime.Now;
					db.Sots.Add(sot);
					db.SaveChanges();
				}
				string name = (from m in db.MdbgeneralData
							   where m.IsDeleted == 0
							   where (int?)m.Mdbid == data.mdbId
							   select m.OrganizationName).SingleOrDefault();
				int leridcount = (from m in db.LeadEnquiryRevised
								  where m.MillName == name
								  where m.IsDeleted == 0
								  select m.Lerid).Count();
				int lerid = 0;
				if (leridcount == 1)
				{
					lerid = (from m in db.LeadEnquiryRevised
							 where m.MillName == name
							 where m.IsDeleted == 0
							 select m.Lerid).SingleOrDefault();
				}
				else if (leridcount > 1)
				{
					lerid = (from m in db.LeadEnquiryRevised
							 where m.MillName == name
							 where m.IsDeleted == 0
							 select m.Lerid).First();
				}
				new LeadEnquiryRevised();
				if (lerid != 0)
				{
					LeadEnquiryRevised LeadEnquiryRevised = db.LeadEnquiryRevised.Find(lerid);
					int iscount = Convert.ToInt32((from m in db.LeadEnquiryRevised
												   where m.Lerid == lerid
												   select m.IsCount).SingleOrDefault());
					LeadEnquiryRevised.IsCount = iscount + 1;
					LeadEnquiryRevised.IsStatus = 3;
					LeadEnquiryRevised.NotifyDate = DateTime.Now;
					db.SaveChanges();
				}
				obj.response = ResourceResponse.AddedSucessfully;
				obj.isStatus = true;
				obj.id = qgid;
				return obj;
			}
			else
			{
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

	public CommonEntity.CommonResponseWithIds AddAndEditRiceMillQuotation(QuotationEntity.QuotationCustom data)
	{
		CommonEntity.CommonResponseWithIds obj = new CommonEntity.CommonResponseWithIds();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			Guid userid = commonFunction.ConvertToGuid(data.userId);
			var loginname = (from m in db.UserLogins
				where m.UserId == userid
				select new { m.Cpid }).SingleOrDefault();
			QgequipGeneralData qgequipGeneralData = new QgequipGeneralData();
			var cpmdb = (from m in db.MdbcontactPersonData
				where m.Mdbid == data.mdbId
				orderby m.Mdbcpdid
				select new { m.Title, m.FirstName, m.MiddleName, m.LastName }).First();
			_ = from s in db.QgequipGeneralData
				select (s) into m
				orderby m.Qgid descending
				select m;
			TimeSpan.Parse(Convert.ToString(DateTime.Now.TimeOfDay));
			qgequipGeneralData.QuotationNumber = data.quotationNumber;
			qgequipGeneralData.QuotationDate = DateTime.Now;
			qgequipGeneralData.CpquotationNumber = data.cpQuotationNumber;
			qgequipGeneralData.KindAttention = data.kindAttention;
			qgequipGeneralData.CompanyUniqueId = data.companyUniqueId;
			qgequipGeneralData.Subjectinfo = data.subjectInfo;
			qgequipGeneralData.Ordergenerated = 0;
			qgequipGeneralData.QuotStatus = 0;
			qgequipGeneralData.SalesName = data.salesName;
			qgequipGeneralData.IsRiceMill = 1;
			qgequipGeneralData.TypeRice = data.riceMillType;
			qgequipGeneralData.LeadTime = DateTime.Now.ToString();
			qgequipGeneralData.IsTime = 0;
			qgequipGeneralData.Cpid = loginname.Cpid;
			qgequipGeneralData.KindAttention = cpmdb.Title + "." + cpmdb.FirstName + " " + cpmdb.MiddleName + " " + cpmdb.LastName;
			qgequipGeneralData.Mdbid = data.mdbId.Value;
			qgequipGeneralData.IsRiceMill = 1;
			qgequipGeneralData.VisitHistoryId = data.visitHistoryId;
			db.QgequipGeneralData.Add(qgequipGeneralData);
			db.SaveChanges();
			int qgid = qgequipGeneralData.Qgid;
			QgequipPayment qgequipPayment = new QgequipPayment();
			qgequipPayment.Qgid = qgid;
			qgequipPayment.PaymentTerms = data.paymentTerms;
			qgequipPayment.Delivery = data.delivery;
			qgequipPayment.DateofDispatch = data.dateOfDispatch;
			qgequipPayment.Transport = data.modeOfTransport;
			qgequipPayment.Freight = data.freight;
			qgequipPayment.Cst = data.CST;
			qgequipPayment.TransitInsu = data.transitInsurance;
			if (data.commodity != null)
			{
				qgequipPayment.Commodity = data.commodity;
			}
			else
			{
				qgequipPayment.Commodity = "";
			}
			qgequipPayment.Validity = data.validity;
			qgequipPayment.Overallprice = data.grandTotal;
			db.QgequipPayment.Add(qgequipPayment);
			db.SaveChanges();
			foreach (QuotationEntity.ProductModel item in data.productModels)
			{
				QgequipTableData qgequipTableData = new QgequipTableData();
				qgequipTableData.Qgid = qgid;
				qgequipTableData.Quantity = item.quantity;
				int mpid = item.masterProductId;
				int prdid = item.productId;
				MasterProducts mpnm = db.MasterProducts.Where((MasterProducts m) => m.MasterProductId == mpid).FirstOrDefault();
				Products prdnm = db.Products.Where((Products m) => m.ProductId == prdid).FirstOrDefault();
				ProductModel prdm = db.ProductModel.Where((ProductModel m) => m.ProductModelId == item.productModelId).FirstOrDefault();
				qgequipTableData.UnitPrice = item.unitPrice;
				qgequipTableData.TotalPrice = item.totalPrice;
				if (prdm != null)
				{
					qgequipTableData.Exclusion = prdm.ProductModelExclusion;
					qgequipTableData.ProductModelId = prdm.ProductModelId;
					qgequipTableData.ModelDesc = prdm.ProductModelDesc;
				}
				qgequipTableData.ProductId = item.productId;
				qgequipTableData.MasterProductId = item.masterProductId;
				if (mpnm != null)
				{
					qgequipTableData.MasterProductName = mpnm.MasterProductName;
				}
				if (prdnm != null)
				{
					qgequipTableData.ProductName = prdnm.ProductName;
				}
				qgequipTableData.IsSotstatus = 0;
				db.QgequipTableData.Add(qgequipTableData);
				db.SaveChanges();
			}
			var list = (from qet in db.QgequipTableData
				join qeg in db.QgequipGeneralData on qet.Qgid equals qeg.Qgid
				where qet.Qgid == qgid && qeg.Islatest == 0
				select new
				{
					qet.ProductModel.ProductModelName,
					qet.Quantity,
					qet.MasterProductId,
					qet.ProductId
				}).ToList();
			list.Count();
			foreach (var qg in list)
			{
				Sotrm sotrm = new Sotrm();
				sotrm.Qgid = qgid;
				sotrm.Cpid = loginname.Cpid;
				sotrm.Equipment = qg.ProductModelName;
				sotrm.Quantity = qg.Quantity;
				sotrm.MasterProductId = qg.MasterProductId;
				sotrm.ProductId = qg.ProductId;
				db.Sotrm.Add(sotrm);
				db.SaveChanges();
			}
			obj.response = ResourceResponse.AddedSucessfully;
			obj.isStatus = true;
			obj.id = qgid;
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

	public CommonEntity.CommonResponseWithIds AddAndEditSpareQuotation(QuotationEntity.SpareQuotationCustom data)
	{
		CommonEntity.CommonResponseWithIds obj = new CommonEntity.CommonResponseWithIds();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			Guid userid = commonFunction.ConvertToGuid(data.userId);
			var loginname = (from m in db.UserLogins
				where m.UserId == userid
				select new { m.Cpid }).SingleOrDefault();
			QgspareGeneralData qgspareGeneralData = new QgspareGeneralData();
			qgspareGeneralData.QuotationNumber = data.quotationNumber;
			qgspareGeneralData.QuotationDate = DateTime.Now;
			qgspareGeneralData.CpquotationNumber = data.cpQuotationNumber;
			qgspareGeneralData.KindAttention = data.kindAttention;
			qgspareGeneralData.CompanyUniqueId = data.companyUniqueId;
			qgspareGeneralData.Subject = data.subjectInfo;
			qgspareGeneralData.Islatest = 0;
			qgspareGeneralData.SalesName = data.salesName;
			qgspareGeneralData.Cpid = loginname.Cpid;
			qgspareGeneralData.Mdbid = data.mdbId.Value;
			qgspareGeneralData.VisitHistoryId = data.visitHistoryId;
			db.QgspareGeneralData.Add(qgspareGeneralData);
			db.SaveChanges();
			int qgid = qgspareGeneralData.Qgid;
			_ = from s in db.QgspareGeneralData
				select (s) into m
				orderby m.Qgid descending
				select m;
			QgsparePayment qgsparePayment = new QgsparePayment();
			qgsparePayment.Qgid = qgid;
			qgsparePayment.PaymentTerms = data.paymentTerms;
			qgsparePayment.Delivery = data.delivery;
			qgsparePayment.DateofDispatch = data.dateOfDispatch;
			qgsparePayment.Transport = data.modeOfTransport;
			qgsparePayment.Freight = data.freight;
			qgsparePayment.Cst = data.CST;
			qgsparePayment.TransitInsu = data.transitInsurance;
			if (data.commodity != null)
			{
				qgsparePayment.Commodity = data.commodity;
			}
			else
			{
				qgsparePayment.Commodity = "";
			}
			qgsparePayment.Validity = data.validity;
			qgsparePayment.Overallprice = data.grandTotal;
			db.QgsparePayment.Add(qgsparePayment);
			db.SaveChanges();
			foreach (QuotationEntity.QGSpareTableDataCustom item in data.productModels)
			{
				QgspareTableData qgspareTableData = new QgspareTableData();
				qgspareTableData.Qgid = qgid;
				qgspareTableData.Quantity = item.quantity;
				qgspareTableData.UnitPrice = item.unitPrice;
				qgspareTableData.TotalPrice = item.totalPrice;
				qgspareTableData.Description = item.description;
				qgspareTableData.ProductModelSparesId = item.productModelSparesId;
				db.QgspareTableData.Add(qgspareTableData);
				db.SaveChanges();
			}
			obj.response = ResourceResponse.AddedSucessfully;
			obj.isStatus = true;
			obj.id = qgid;
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

	public CommonEntity.CommonResponse GetCustomerAndQuotationNumber(QuotationEntity.QuotationNumberCustom data)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		QuotationEntity.GetQuotationData getQuotationData = new QuotationEntity.GetQuotationData();
		try
		{
			Guid userid = commonFunction.ConvertToGuid(data.userId);
			var loginname = (from m in db.UserLogins
				where m.UserId == userid
				select new { m.FirstName, m.MiddleName, m.LastName, m.Designation, m.Cpid }).FirstOrDefault();
			MdbgeneralData mdid = db.MdbgeneralData.Where((MdbgeneralData m) => m.Mdbid == data.mdbId && m.Cpid == loginname.Cpid).FirstOrDefault();
			if (mdid != null)
			{
				if (db.MdbcontactPersonData.Where((MdbcontactPersonData m) => m.Mdbid == (int?)mdid.Mdbid).Count() == 0)
				{
					MdbcontactPersonData mdbcontact = new MdbcontactPersonData();
					mdbcontact.Mdbid = mdid.Mdbid;
					mdbcontact.Title = "Mr/Miss";
					mdbcontact.FirstName = "ASDFG";
					db.MdbcontactPersonData.Add(mdbcontact);
					db.SaveChanges();
					var cpmdb2 = (from m in db.MdbcontactPersonData
						where m.Mdbid == (int?)mdid.Mdbid
						orderby m.Mdbcpdid
						select new { m.Title, m.FirstName, m.MiddleName, m.LastName }).First();
					getQuotationData.contactPersonName = cpmdb2.Title + "." + cpmdb2.FirstName + " " + cpmdb2.MiddleName + " " + cpmdb2.LastName;
					if (cpmdb2.Title == "Miss" || cpmdb2.Title == "Mrs")
					{
						getQuotationData.dear = "Madam";
					}
					else
					{
						getQuotationData.dear = "Sir";
					}
				}
				else
				{
					var cpmdb = (from m in db.MdbcontactPersonData
						where m.Mdbid == (int?)mdid.Mdbid
						orderby m.Mdbcpdid
						select new { m.Title, m.FirstName, m.MiddleName, m.LastName }).First();
					if (cpmdb != null)
					{
						getQuotationData.contactPersonName = cpmdb.Title + "." + cpmdb.FirstName + " " + cpmdb.MiddleName + " " + cpmdb.LastName;
					}
					if (cpmdb.Title == "Miss" || cpmdb.Title == "Mrs")
					{
						getQuotationData.dear = "Madam";
					}
					else
					{
						getQuotationData.dear = "Sir";
					}
				}
				if (data.quotationType == "Spare")
				{
					getQuotationData.quotationNumber = commonFunction.QuotationNumberSpare();
				}
				else
				{
					getQuotationData.quotationNumber = commonFunction.QuotationNumber();
				}
				getQuotationData.mdbId = mdid.Mdbid;
				getQuotationData.organizationName = mdid.OrganizationName;
				getQuotationData.addressLine1 = mdid.AddressLine1;
				getQuotationData.addressLine2 = mdid.AddressLine2;
				getQuotationData.addressLine3 = mdid.AddressLine3;
				getQuotationData.city = mdid.City;
				getQuotationData.pincode = mdid.Pincode;
				getQuotationData.state = mdid.State;
				getQuotationData.companyUniqueId = mdid.CompanyUniqueId;
				var visit = (from wf in db.VisitHistory
					where wf.IsDeleted == (bool?)false && wf.VisitHistoryId == (long)data.visitId
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
				if (visit != null)
				{
					getQuotationData.cpName = visit.cpName;
					getQuotationData.salesManagerName = visit.salesManagerName;
					List<long> productList = visit.productModelId.Split(new char[1] { ',' }).Select(long.Parse).ToList();
					if (data.quotationType == "Spare")
					{
						List<QgspareTableData> qgspareTableDatas = new List<QgspareTableData>();
						foreach (long item2 in productList)
						{
							QgspareTableData qgspareTableData = new QgspareTableData();
							qgspareTableData.Quantity = 1;
							ProductModelSpare prdm2 = db.ProductModelSpare.Where((ProductModelSpare m) => (long)m.ProductModelSparesId == item2).FirstOrDefault();
							qgspareTableData.UnitPrice = prdm2.CustomerPrice;
							qgspareTableData.TotalPrice = prdm2.CustomerPrice;
							qgspareTableData.Description = prdm2.ProductModelSparesDesc;
							qgspareTableData.ProductModelSpares.ProductModelSparesName = prdm2.ProductModelSparesName;
							qgspareTableData.ProductModelSparesId = prdm2.ProductModelSparesId;
							qgspareTableDatas.Add(qgspareTableData);
						}
						getQuotationData.qgspareTableDatas = qgspareTableDatas;
					}
					else
					{
						List<QgequipTableData> qgequipTableDatas = new List<QgequipTableData>();
						foreach (long item in productList)
						{
							QgequipTableData qgequipTableData = new QgequipTableData();
							qgequipTableData.Quantity = 1;
							ProductModel prdm = db.ProductModel.Where((ProductModel m) => (long)m.ProductModelId == item).FirstOrDefault();
							int prdid = prdm.ProductId;
							Products prdnm = db.Products.Where((Products m) => m.ProductId == prdid).FirstOrDefault();
							qgequipTableData.UnitPrice = prdm.UnitPrice;
							qgequipTableData.TotalPrice = prdm.UnitPrice;
							if (prdm != null)
							{
								qgequipTableData.Exclusion = prdm.ProductModelExclusion;
								qgequipTableData.ProductModelId = prdm.ProductModelId;
								qgequipTableData.ModelDesc = prdm.ProductModelDesc;
								qgequipTableData.ProductModelName = prdm.ProductModelName;
							}
							qgequipTableData.ProductId = prdm.ProductId;
							int mpid = prdnm.MasterProductId;
							MasterProducts mpnm = db.MasterProducts.Where((MasterProducts m) => m.MasterProductId == mpid).FirstOrDefault();
							qgequipTableData.MasterProductId = prdnm.MasterProductId;
							if (mpnm != null)
							{
								qgequipTableData.MasterProductName = mpnm.MasterProductName;
							}
							if (prdnm != null)
							{
								qgequipTableData.ProductName = prdnm.ProductName;
							}
							qgequipTableData.IsSotstatus = 1;
							qgequipTableDatas.Add(qgequipTableData);
						}
						getQuotationData.qgequipTableDatas = qgequipTableDatas;
					}
				}
				obj.response = getQuotationData;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = true;
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

	public CommonEntity.CommonResponse GetAllMasterProducts()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var masterProducts = (from m in db.MasterProducts
				where m.IsDeleted == 0
				select new { m.MasterProductId, m.MasterProductName, m.IsDeleted }).ToList();
			if (masterProducts.Count() != 0)
			{
				obj.response = masterProducts;
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

	public CommonEntity.CommonResponse GetAllProducts(int masterProductId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var product = (from m in db.Products
				where m.IsDeleted == 0 && m.MasterProductId == masterProductId
				select new { m.ProductId, m.ProductName }).ToList();
			if (product.Count() != 0)
			{
				obj.response = product;
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

	public CommonEntity.CommonResponse GetAllProductModelSorter()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var productModel = (from m in db.ProductModel
				join mp in db.Products on m.ProductId equals mp.ProductId
				where m.IsDeleted == 0 && mp.ProductName == "BSOH Sorter"
				select new
				{
					productModelId = m.ProductModelId,
					productModelName = m.ProductModelName,
					unitPrice = m.UnitPrice,
					productModelDesc = m.ProductModelDesc,
					productModelExclusion = m.ProductModelExclusion
				}).ToList();
			if (productModel.Count() != 0)
			{
				obj.response = productModel;
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

	public CommonEntity.CommonResponse GetAllProductModelRiceMill(int productId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var productModel = (from m in db.ProductModel
				where m.IsDeleted == 0 && m.ProductId == productId
				select new
				{
					productModelId = m.ProductModelId,
					productModelName = m.ProductModelName,
					unitPrice = m.UnitPrice,
					productModelDesc = m.ProductModelDesc,
					productModelExclusion = m.ProductModelExclusion
				}).ToList();
			if (productModel.Count() != 0)
			{
				obj.response = productModel;
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

	public CommonEntity.CommonResponse GetAllProductModelSpare()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var productModel = (from m in db.ProductModelSpare
				where m.IsDeleted == 0
				select new
				{
					productModelSparesId = m.ProductModelSparesId,
					productModelSparesName = m.ProductModelSparesName,
					unitPrice = m.CustomerPrice,
					productModelDesc = m.ProductModelSparesDesc
				}).ToList();
			if (productModel.Count() != 0)
			{
				obj.response = productModel;
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

	public CommonEntity.CommonResponse GetAllTermsAndCondition(string termsAndConditionFor)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var productModel = (from m in db.TermsAndConditionMaster
				where m.IsDeleted == (bool?)false && m.TermsAndConditionFor == termsAndConditionFor
				select new
				{
					m.TermsAndConditionId, m.TermsAndConditionFor, m.PaymentTerms, m.Delivery, m.Dod, m.ModeOfTransport, m.Freight, m.Gst, m.TransitInsurance, m.PackingAndForwarding,
					m.Validity, m.Comodity
				}).ToList();
			if (productModel.Count() != 0)
			{
				obj.response = productModel;
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
