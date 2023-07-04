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

public class VisitPurposeBLL : IVisitPurpose
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(VisitPurposeBLL));

	private readonly AppSettings appSettings;

	public VisitPurposeBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponse AddAndEditVisitPurpose(VisitPurposeEntity.VisitPurposeCustom data, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			VisitPurpose res = db.VisitPurpose.Where((VisitPurpose m) => m.VisitPurposeId == data.visitPurposeId).FirstOrDefault();
			if (res == null)
			{
				try
				{
					VisitPurpose item = new VisitPurpose();
					item.VisitPurpose1 = data.visitPurpose;
					item.Description = data.description;
					item.IsDeleted = false;
					item.IsActive = true;
					db.VisitPurpose.Add(item);
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
				res.VisitPurpose1 = data.visitPurpose;
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

	public CommonEntity.CommonResponse ViewMultipleVisitPurpose()
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

	public CommonEntity.CommonResponse ViewVisitPurposeById(int visitPurposeId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.VisitPurpose
				where wf.IsDeleted == (bool?)false && wf.VisitPurposeId == (long)visitPurposeId
				select new
				{
					visitPurposeId = wf.VisitPurposeId,
					visitPurpose = wf.VisitPurpose1,
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

	public CommonEntity.CommonResponse DeleteVisitPurpose(int visitPurposeId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			VisitPurpose res = db.VisitPurpose.Where((VisitPurpose m) => m.VisitPurposeId == (long)visitPurposeId).FirstOrDefault();
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

	public CommonEntity.CommonResponse ArchiveVisitPurpose(int visitPurposeId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			VisitPurpose result = db.VisitPurpose.Where((VisitPurpose m) => m.VisitPurposeId == (long)visitPurposeId).FirstOrDefault();
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
