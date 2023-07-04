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

public class SMBLL : ISM
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(SMBLL));

	private readonly AppSettings appSettings;

	public SMBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponse AddAndEditSM(SMEntity.SMCustom data, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			SalesManagerMaster res = db.SalesManagerMaster.Where((SalesManagerMaster m) => m.ManagerId == data.managerId).FirstOrDefault();
			if (res == null)
			{
				try
				{
					SalesManagerMaster item = new SalesManagerMaster();
					item.ManagerName = data.managerName;
					item.ManagerEmailId = data.managerEmailId;
					item.ManagerPhoneNumber = data.managerPhoneNumber;
					item.UniqueId = data.uniqueId;
					item.CpIds = data.cpIds;
					item.IsDeleted = false;
					item.IsActive = true;
					db.SalesManagerMaster.Add(item);
					db.SaveChanges();
					obj.response = ResourceResponse.AddedSucessfully;
					obj.isStatus = true;
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
				res.ManagerName = data.managerName;
				res.ManagerEmailId = data.managerEmailId;
				res.ManagerPhoneNumber = data.managerPhoneNumber;
				res.UniqueId = data.uniqueId;
				res.CpIds = data.cpIds;
				res.ModifiedOn = DateTime.Now;
				db.SaveChanges();
				obj.response = ResourceResponse.UpdatedSucessfully;
				obj.isStatus = true;
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

	public CommonEntity.CommonResponse ViewMultipleSM()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.SalesManagerMaster
				where wf.IsDeleted == (bool?)false
				select new
				{
					managerId = wf.ManagerId,
					managerName = wf.ManagerName,
					managerPhoneNumber = wf.ManagerPhoneNumber,
					managerEmailId = wf.ManagerEmailId,
					uniqueId = wf.UniqueId,
					cpIds = wf.CpIds
				}).ToList();
			List<SMEntity.SMCPDetails> smcpDetails = new List<SMEntity.SMCPDetails>();
			foreach (var item in result)
			{
				SMEntity.SMCPDetails smcpDetail = new SMEntity.SMCPDetails();
				smcpDetail.managerId = item.managerId;
				smcpDetail.managerName = item.managerName;
				smcpDetail.managerPhoneNumber = item.managerPhoneNumber;
				smcpDetail.managerEmailId = item.managerEmailId;
				smcpDetail.uniqueId = item.uniqueId;
				smcpDetail.cpIds = item.cpIds;
				if (item.cpIds != null)
				{
					smcpDetail.cpId = (from x in item.cpIds.Split(new char[1] { ',' })
						select int.Parse(x.Trim())).ToList();
					List<SMEntity.CPDetails> cpDetails = new List<SMEntity.CPDetails>();
					foreach (int cp in smcpDetail.cpId)
					{
						SMEntity.CPDetails cpDetail = new SMEntity.CPDetails();
						cpDetail.cpId = cp;
						ChannelPartners cpD = db.ChannelPartners.Where((ChannelPartners m) => m.Cpid == cp).FirstOrDefault();
						cpDetail.cpName = cpD.Cpname;
						cpDetail.cpUniqueId = cpD.CpuniqueId;
						cpDetails.Add(cpDetail);
					}
					smcpDetail.cpDetails = cpDetails;
				}
				smcpDetails.Add(smcpDetail);
			}
			if (result.Count() != 0)
			{
				obj.response = smcpDetails;
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

	public CommonEntity.CommonResponse ViewSMById(int managerId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var item = (from wf in db.SalesManagerMaster
				where wf.IsDeleted == (bool?)false && wf.ManagerId == managerId
				select new
				{
					managerId = wf.ManagerId,
					managerName = wf.ManagerName,
					managerPhoneNumber = wf.ManagerPhoneNumber,
					managerEmailId = wf.ManagerEmailId,
					uniqueId = wf.UniqueId,
					cpIds = wf.CpIds
				}).FirstOrDefault();
			if (item != null)
			{
				SMEntity.SMCPDetails smcpDetail = new SMEntity.SMCPDetails();
				smcpDetail.managerId = item.managerId;
				smcpDetail.managerName = item.managerName;
				smcpDetail.managerPhoneNumber = item.managerPhoneNumber;
				smcpDetail.managerEmailId = item.managerEmailId;
				smcpDetail.uniqueId = item.uniqueId;
				smcpDetail.cpIds = item.cpIds;
				if (item.cpIds != null)
				{
					smcpDetail.cpId = (from x in item.cpIds.Split(new char[1] { ',' })
						select int.Parse(x.Trim())).ToList();
					List<SMEntity.CPDetails> cpDetails = new List<SMEntity.CPDetails>();
					foreach (int cp in smcpDetail.cpId)
					{
						SMEntity.CPDetails cpDetail = new SMEntity.CPDetails();
						cpDetail.cpId = cp;
						ChannelPartners cpD = db.ChannelPartners.Where((ChannelPartners m) => m.Cpid == cp).FirstOrDefault();
						cpDetail.cpName = cpD.Cpname;
						cpDetail.cpUniqueId = cpD.CpuniqueId;
						cpDetails.Add(cpDetail);
					}
					smcpDetail.cpDetails = cpDetails;
				}
				obj.response = smcpDetail;
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

	public CommonEntity.CommonResponse ViewSMByCPId(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			Guid userIdGuid = commonFunction.ConvertToGuid(userId);
			string stringToCheck = (from m in db.UserLogins
				where m.UserId == userIdGuid
				select m.Cpid).FirstOrDefault().ToString();
			var result = (from wf in db.SalesManagerMaster
				where wf.IsDeleted == (bool?)false && wf.CpIds.Contains(stringToCheck)
				select new
				{
					managerId = wf.ManagerId,
					managerName = wf.ManagerName,
					managerPhoneNumber = wf.ManagerPhoneNumber,
					managerEmailId = wf.ManagerEmailId,
					uniqueId = wf.UniqueId,
					cpIds = wf.CpIds
				}).ToList();
			List<SMEntity.SMCPDetails> smcpDetails = new List<SMEntity.SMCPDetails>();
			foreach (var item in result)
			{
				SMEntity.SMCPDetails smcpDetail = new SMEntity.SMCPDetails();
				smcpDetail.managerId = item.managerId;
				smcpDetail.managerName = item.managerName;
				smcpDetail.managerPhoneNumber = item.managerPhoneNumber;
				smcpDetail.managerEmailId = item.managerEmailId;
				smcpDetail.uniqueId = item.uniqueId;
				smcpDetail.cpIds = item.cpIds;
				if (item.cpIds != null)
				{
					smcpDetail.cpId = (from x in item.cpIds.Split(new char[1] { ',' })
						select int.Parse(x.Trim())).ToList();
					List<SMEntity.CPDetails> cpDetails = new List<SMEntity.CPDetails>();
					foreach (int cp in smcpDetail.cpId)
					{
						SMEntity.CPDetails cpDetail = new SMEntity.CPDetails();
						cpDetail.cpId = cp;
						ChannelPartners cpD = db.ChannelPartners.Where((ChannelPartners m) => m.Cpid == cp).FirstOrDefault();
						cpDetail.cpName = cpD.Cpname;
						cpDetail.cpUniqueId = cpD.CpuniqueId;
						cpDetails.Add(cpDetail);
					}
					smcpDetail.cpDetails = cpDetails;
				}
				smcpDetails.Add(smcpDetail);
			}
			if (result.Count() != 0)
			{
				obj.response = smcpDetails;
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

	public CommonEntity.CommonResponse DeleteSM(int managerId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			SalesManagerMaster res = db.SalesManagerMaster.Where((SalesManagerMaster m) => m.ManagerId == managerId).FirstOrDefault();
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

	public CommonEntity.CommonResponse ArchiveSM(int managerId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			SalesManagerMaster result = db.SalesManagerMaster.Where((SalesManagerMaster m) => m.ManagerId == managerId).FirstOrDefault();
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
}
