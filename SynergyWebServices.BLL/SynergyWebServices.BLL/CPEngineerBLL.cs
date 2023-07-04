using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using log4net;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.App_Start;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;
using Zone = SynergyWebServices.DAL.Zone;

namespace SynergyWebServices.BLL;

public class CPEngineerBLL : ICPEngineer
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(CPEngineerBLL));

	private readonly AppSettings appSettings;

	public CPEngineerBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponse AddAndEditCPEngineer(CPEngineerEntity.CPEngineerCustom data, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			ChannelPartnersEngineer res = db.ChannelPartnersEngineer.Where((ChannelPartnersEngineer m) => m.ChannelPartnersEngineerId == data.channelPartnersEngineerId).FirstOrDefault();
			if (res == null)
			{
				try
				{
					ChannelPartnersEngineer item = new ChannelPartnersEngineer();
					item.Cpid = data.cpid;
					item.Name = data.name;
					item.PhoneNumber = data.phoneNumber;
					item.EmaiId = data.emaiId;
					item.IsActive = Convert.ToBoolean(data.status);
					item.EscalationMails = data.escalationMails;
					db.ChannelPartnersEngineer.Add(item);
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
				res.Cpid = data.cpid;
				res.Name = data.name;
				res.PhoneNumber = data.phoneNumber;
				res.EmaiId = data.emaiId;
				res.ModifiedOn = DateTime.Now;
				res.IsActive = Convert.ToBoolean(data.status);
				res.EscalationMails = data.escalationMails;
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

	public CommonEntity.CommonResponse ViewMultipleCPEngineer()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.ChannelPartnersEngineer
				where wf.IsDeleted == (bool?)false
				select new
				{
					channelPartnersEngineerId = wf.ChannelPartnersEngineerId,
					cpid = wf.Cpid,
					cpName = (from m in db.ChannelPartners
						where (int?)m.Cpid == wf.Cpid
						select m.Cpname).FirstOrDefault(),
					name = wf.Name,
					emaiId = wf.EmaiId,
					phoneNumber = wf.PhoneNumber,
					status = wf.IsActive,
					escalationMails = wf.EscalationMails
				}).ToList();
			if (result.Count() != 0)
			{
				List<CPEngineerEntity.CPEngineerDetails> cPEngineerDetailsList = new List<CPEngineerEntity.CPEngineerDetails>();
				foreach (var item in result)
				{
					CPEngineerEntity.CPEngineerDetails cPEngineerDetails = new CPEngineerEntity.CPEngineerDetails();
					cPEngineerDetails.channelPartnersEngineerId = item.channelPartnersEngineerId;
					cPEngineerDetails.cpid = item.cpid;
					cPEngineerDetails.cpName = item.cpName;
					cPEngineerDetails.name = item.name;
					cPEngineerDetails.emaiId = item.emaiId;
					cPEngineerDetails.phoneNumber = item.phoneNumber;
					cPEngineerDetails.status = item.status;
					if (item.escalationMails != null)
					{
						List<string> escalationList = new List<string>();
						string[] array = item.escalationMails.Split(new char[1] { ',' });
						foreach (string i in array)
						{
							escalationList.Add(i);
						}
						cPEngineerDetails.escalationMails = escalationList;
					}
					cPEngineerDetailsList.Add(cPEngineerDetails);
				}
				obj.isStatus = true;
				obj.response = cPEngineerDetailsList;
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

	public CommonEntity.CommonResponse ViewMultipleCPEngineerBasedOnUserId(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = commonFunction.GetRoleName(userId);
			var result = (from wf in db.ChannelPartnersEngineer
				where wf.IsDeleted == (bool?)false
				select new
				{
					channelPartnersEngineerId = wf.ChannelPartnersEngineerId,
					cpid = wf.Cpid,
					cpName = (from m in db.ChannelPartners
						where (int?)m.Cpid == wf.Cpid
						select m.Cpname).FirstOrDefault(),
					name = wf.Name,
					emaiId = wf.EmaiId,
					phoneNumber = wf.PhoneNumber,
					status = wf.IsActive
				}).ToList();
			if (roleName != "Administrator")
			{
				int cpId = 0;
				Guid userIdGuid = new Guid(userId);
				try
				{
					cpId = (from m in db.UserLogins
						where m.UserId == userIdGuid
						select m.Cpid).FirstOrDefault();
				}
				catch (Exception)
				{
				}
				result = result.Where(wf => wf.cpid == cpId && wf.status == true).ToList();
			}
			if (result.Count() != 0)
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

	public CommonEntity.CommonResponse ViewMultipleCPEngineerBasedOnCPId(int cpId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.ChannelPartnersEngineer
				where wf.IsDeleted == (bool?)false && wf.Cpid == (int?)cpId && wf.IsActive == (bool?)true
				select new
				{
					channelPartnersEngineerId = wf.ChannelPartnersEngineerId,
					cpid = wf.Cpid,
					cpName = (from m in db.ChannelPartners
						where (int?)m.Cpid == wf.Cpid
						select m.Cpname).FirstOrDefault(),
					name = wf.Name,
					emaiId = wf.EmaiId,
					phoneNumber = wf.PhoneNumber,
					status = wf.IsActive
				}).ToList();
			if (result.Count() != 0)
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

	public CommonEntity.CommonResponse ViewCPEngineerById(int channelPartnersEngineerId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.ChannelPartnersEngineer
				where wf.IsDeleted == (bool?)false && wf.ChannelPartnersEngineerId == channelPartnersEngineerId
				select new
				{
					channelPartnersEngineerId = wf.ChannelPartnersEngineerId,
					cpid = wf.Cpid,
					cpName = (from m in db.ChannelPartners
						where (int?)m.Cpid == wf.Cpid
						select m.Cpname).FirstOrDefault(),
					name = wf.Name,
					emaiId = wf.EmaiId,
					phoneNumber = wf.PhoneNumber,
					status = wf.IsActive
				}).FirstOrDefault();
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

	public CommonEntity.CommonResponse DeleteCPEngineer(int channelPartnersEngineerId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			ChannelPartnersEngineer res = db.ChannelPartnersEngineer.Where((ChannelPartnersEngineer m) => m.ChannelPartnersEngineerId == channelPartnersEngineerId).FirstOrDefault();
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

	public CommonEntity.CommonResponse ArchiveCPEngineer(int channelPartnersEngineerId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			ChannelPartnersEngineer result = db.ChannelPartnersEngineer.Where((ChannelPartnersEngineer m) => m.ChannelPartnersEngineerId == channelPartnersEngineerId).FirstOrDefault();
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

	public CommonEntity.CommonResponse ViewMultipleCP()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = db.ChannelPartners.Select((ChannelPartners wf) => new
			{
				cpid = wf.Cpid,
				cpName = wf.Cpname
			}).ToList();
			if (result.Count() != 0)
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

    public CommonEntity.CommonResponse ViewZone()
    {
        CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
        try
        {
            var result = db.Zone.ToList();
            if (result.Count() != 0)
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

    public CommonEntity.CommonResponse GetUserType(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = (obj.response = commonFunction.GetRoleName(userId));
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
}
