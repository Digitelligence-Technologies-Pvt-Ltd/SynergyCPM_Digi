using System;
using System.Linq;
using log4net;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.BLL;

public class BUBLL : IBU
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(BUBLL));

	private readonly AppSettings appSettings;

	public BUBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponse AddAndEditBU(BUEntity.BUCustom data, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			BusinessUnit res = db.BusinessUnit.Where((BusinessUnit m) => m.BuId == data.buId).FirstOrDefault();
			if (res == null)
			{
				try
				{
					BusinessUnit item = new BusinessUnit();
					item.BuName = data.buName;
					item.Description = data.description;
					item.IsDeleted = false;
					item.IsActive = true;
					db.BusinessUnit.Add(item);
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
				res.BuName = data.buName;
				res.Description = data.description;
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

	public CommonEntity.CommonResponse ViewMultipleBU()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.BusinessUnit
				where wf.IsDeleted == (bool?)false
				select new
				{
					buId = wf.BuId,
					buName = wf.BuName,
					description = wf.Description
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

	public CommonEntity.CommonResponse ViewBUById(int buId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.BusinessUnit
				where wf.IsDeleted == (bool?)false && wf.BuId == buId
				select new
				{
					buId = wf.BuId,
					buName = wf.BuName,
					description = wf.Description
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

	public CommonEntity.CommonResponse DeleteBU(int buId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			BusinessUnit res = db.BusinessUnit.Where((BusinessUnit m) => m.BuId == buId).FirstOrDefault();
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

	public CommonEntity.CommonResponse ArchiveBU(int buId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			BusinessUnit result = db.BusinessUnit.Where((BusinessUnit m) => m.BuId == buId).FirstOrDefault();
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
