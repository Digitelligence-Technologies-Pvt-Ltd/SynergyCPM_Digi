using System;
using System.Linq;
using log4net;
using Microsoft.AspNetCore.Hosting;
using SynergyWebServices.DAL;

namespace SynergyWebServices.BLL.App_Start;

public class CommonFunction
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	public readonly IHostingEnvironment _hostingEnvironment;

	private static readonly ILog log = LogManager.GetLogger(typeof(CommonFunction));

	public Guid ConvertToGuid(string userId)
	{
		Guid userIdGuid = default(Guid);
		try
		{
			userIdGuid = new Guid(userId);
			return userIdGuid;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
				return userIdGuid;
			}
			return userIdGuid;
		}
	}

	public string GetRoleName(string userId)
	{
		string roleName = "";
		Guid userIdGuid = default(Guid);
		try
		{
			userIdGuid = new Guid(userId);
			Guid dbItem = (from m in db.UsersInRoles
				where m.UserId == userIdGuid
				select m.RoleId).FirstOrDefault();
			roleName = (from m in db.Roles
				where m.RoleId == dbItem
				select m.RoleName).FirstOrDefault();
			return roleName;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
				return roleName;
			}
			return roleName;
		}
	}

	public string QuotationNumber()
	{
		string year = DateTime.Now.Year.ToString().Substring(2, 2);
		IQueryable<QgequipGeneralData> quotmod = db.QgequipGeneralData.Select((QgequipGeneralData QuotationNumber) => QuotationNumber);
		quotmod = quotmod.OrderByDescending((QgequipGeneralData m) => m.QuotationNumber);
		if (quotmod.FirstOrDefault() == null)
		{
			return "QE-RC" + year + "-00001-00";
		}
		string[] split = quotmod.Select((QgequipGeneralData m) => m.QuotationNumber).First().Split(new char[1] { '-' });
		if (split[1].Substring(2, 2) == DateTime.Now.Year.ToString().Substring(2, 2))
		{
			int ad = Convert.ToInt32(split[2]) + 1;
			string cpik = null;
			string len = ad.ToString();
			cpik = ((len.Length == 1) ? ("0000" + ad) : ((len.Length == 2) ? ("000" + ad) : ((len.Length == 3) ? ("00" + ad) : ((len.Length != 4) ? ad.ToString() : ("0" + ad)))));
			return split[0] + "-RC" + year + "-" + cpik + "-00";
		}
		return "QE-RC" + year + "-00001-00";
	}

	public string QuotationNumberSpare()
	{
		string year = DateTime.Now.Year.ToString().Substring(2, 2);
		IQueryable<QgspareGeneralData> quotmod = db.QgspareGeneralData.Select((QgspareGeneralData QuotationNumber) => QuotationNumber);
		quotmod = quotmod.OrderByDescending((QgspareGeneralData m) => m.QuotationNumber);
		if (quotmod.FirstOrDefault() == null)
		{
			return "QS-RC" + year + "-00001-00";
		}
		string[] split = quotmod.Select((QgspareGeneralData m) => m.QuotationNumber).First().Split(new char[1] { '-' });
		if (split[1].Substring(2, 2) == DateTime.Now.Year.ToString().Substring(2, 2))
		{
			int ad = Convert.ToInt32(split[2]) + 1;
			string cpik = null;
			string len = ad.ToString();
			cpik = ((len.Length == 1) ? ("0000" + ad) : ((len.Length == 2) ? ("000" + ad) : ((len.Length == 3) ? ("00" + ad) : ((len.Length != 4) ? ad.ToString() : ("0" + ad)))));
			return split[0] + "-RC" + year + "-" + cpik + "-00";
		}
		return "QS-RC" + year + "-00001-00";
	}
}
