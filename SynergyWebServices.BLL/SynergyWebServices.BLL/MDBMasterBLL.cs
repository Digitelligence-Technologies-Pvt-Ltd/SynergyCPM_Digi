using System;
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

public class MDBMasterBLL : IMDBMaster
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(MDBMasterBLL));

	private readonly AppSettings appSettings;

	public MDBMasterBLL(SRKSSynergyContext _db, IOptions<AppSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponse AddAndEditMDBMaster(MDBMasterEntity.MDBMasterEntityCustom data)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			CommonFunction commonFunction = new CommonFunction();
			int cpId = 0;
			if (commonFunction.GetRoleName(data.userId) != "Administrator")
			{
				Guid userIdGuid = new Guid(data.userId);
				try
				{
					cpId = (from m in db.UserLogins
						where m.UserId == userIdGuid
						select m.Cpid).FirstOrDefault();
				}
				catch (Exception)
				{
				}
			}
			MdbgeneralData res = db.MdbgeneralData.Where((MdbgeneralData m) => m.OrganizationName == data.organizationName && m.City == data.city && m.Pincode == data.pincode && m.Cpid == cpId && m.IsDeleted == 0).FirstOrDefault();
			int mdbid2 = 0;
			if (res == null)
			{
				try
				{
					MdbgeneralData mdb = new MdbgeneralData();
					try
					{
						string mdbi2 = (from CompanyUniqueID in db.MdbgeneralData
							where CompanyUniqueID != null
							select CompanyUniqueID into m
							orderby m.Mdbid descending
							select m.CompanyUniqueId).First();
						string[] split2 = mdbi2.Split(new char[1] { '-' });
						int ad2 = Convert.ToInt32(split2[2]) + 1;
						string cpik2 = null;
						string len2 = ad2.ToString();
						cpik2 = ((len2.Length == 1) ? ("0000" + ad2) : ((len2.Length == 2) ? ("000" + ad2) : ((len2.Length == 3) ? ("00" + ad2) : ((len2.Length != 4) ? ad2.ToString() : ("0" + ad2)))));
						mdbi2 = (mdb.CompanyUniqueId = split2[0] + "-" + DateTime.Now.Year + "-" + cpik2);
						if (data.organizationName != null)
						{
							string millName2 = "";
							millName2 = data.organizationName;
							string[] array = new string[3] { "\\n", "\\t", "\\r\\n" };
							foreach (string special2 in array)
							{
								string cmp2 = "";
								cmp2 = special2 switch
								{
									"\\n" => "\n", 
									"\\t" => "\t", 
									"\\r" => "\r", 
									_ => "", 
								};
								if (millName2.Contains(cmp2) && cmp2 != "")
								{
									millName2 = millName2.Replace(cmp2, "");
								}
							}
							mdb.OrganizationName = millName2;
						}
						else
						{
							mdb.OrganizationName = "XXXXXXXX";
						}
						if (data.organizationType != null)
						{
							mdb.OrganizationType = data.organizationType;
						}
						else
						{
							mdb.OrganizationType = "XXXXXX";
						}
						if (data.addressLine1 != null)
						{
							mdb.AddressLine1 = data.addressLine1;
						}
						else
						{
							mdb.AddressLine1 = "ASDFGH";
						}
						if (data.addressLine2 != null)
						{
							mdb.AddressLine2 = data.addressLine2;
						}
						else
						{
							mdb.AddressLine2 = "ASDFGH";
						}
						if (data.city != null)
						{
							mdb.City = data.city;
						}
						try
						{
							if (data.pincode != null && data.pincode.Length > 5)
							{
								mdb.Pincode = data.pincode;
							}
						}
						catch
						{
							mdb.Pincode = "111111";
						}
						if (data.state != null)
						{
							mdb.State = data.state;
						}
						if (data.country != null)
						{
							mdb.Country = data.country;
						}
						else
						{
							mdb.Country = "INDIA";
						}
						if (data.latitude != null)
						{
							mdb.Latitude = data.latitude;
						}
						else
						{
							mdb.Latitude = "10101.101";
						}
						if (data.longitude != null)
						{
							mdb.Longitude = data.longitude;
						}
						else
						{
							mdb.Longitude = "10101.101";
						}
						if (data.isd1 != null)
						{
							mdb.Isd1 = data.isd1;
						}
						else
						{
							mdb.Isd1 = " ";
						}
						if (data.std1 != null)
						{
							mdb.Std1 = data.std1;
						}
						else
						{
							mdb.Std1 = " ";
						}
						if (data.phoneLl1 != null)
						{
							mdb.PhoneLl1 = data.phoneLl1;
						}
						else
						{
							mdb.PhoneLl1 = " ";
						}
						if (data.emailId != null)
						{
							mdb.EmailId = data.emailId;
						}
						else
						{
							mdb.EmailId = "aaaa@gmail.com";
						}
						mdb.Cpid = cpId;
						mdb.IsDeleted = 0;
						mdb.CreatedOn = DateTime.Now;
						mdb.CreatedBy = data.userId;
						db.MdbgeneralData.Add(mdb);
						db.SaveChanges();
					}
					catch (Exception ex8)
					{
						log.Error(ex8);
						if (ex8.InnerException != null)
						{
							log.Error(ex8.InnerException.ToString());
						}
					}
					try
					{
						mdbid2 = mdb.Mdbid;
						MdbcontactPersonData mdbcontact2 = new MdbcontactPersonData();
						mdbcontact2.Mdbid = mdbid2;
						if (data.prefix != null)
						{
							mdbcontact2.Title = data.prefix;
						}
						else
						{
							mdbcontact2.Title = "MM";
						}
						if (data.ownerName != null)
						{
							mdbcontact2.FirstName = data.ownerName;
						}
						else
						{
							mdbcontact2.FirstName = "AAABBBCCC";
						}
						if (data.mobNo != null)
						{
							mdbcontact2.Mobile1 = data.mobNo;
						}
						db.MdbcontactPersonData.Add(mdbcontact2);
						db.SaveChanges();
					}
					catch (Exception ex7)
					{
						log.Error(ex7);
						if (ex7.InnerException != null)
						{
							log.Error(ex7.InnerException.ToString());
						}
					}
					obj.response = ResourceResponse.AddedSucessfully;
					obj.isStatus = true;
					return obj;
				}
				catch (Exception ex6)
				{
					log.Error(ex6);
					if (ex6.InnerException != null)
					{
						log.Error(ex6.InnerException.ToString());
					}
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
					return obj;
				}
			}
			try
			{
				try
				{
					string mdbi = (from CompanyUniqueID in db.MdbgeneralData
						where CompanyUniqueID != null
						select CompanyUniqueID into m
						orderby m.Mdbid descending
						select m.CompanyUniqueId).First();
					string[] split = mdbi.Split(new char[1] { '-' });
					int ad = Convert.ToInt32(split[2]) + 1;
					string cpik = null;
					string len = ad.ToString();
					cpik = ((len.Length == 1) ? ("0000" + ad) : ((len.Length == 2) ? ("000" + ad) : ((len.Length == 3) ? ("00" + ad) : ((len.Length != 4) ? ad.ToString() : ("0" + ad)))));
					mdbi = (res.CompanyUniqueId = split[0] + "-" + DateTime.Now.Year + "-" + cpik);
					if (data.organizationName != null)
					{
						string millName = "";
						millName = data.organizationName;
						string[] array = new string[3] { "\\n", "\\t", "\\r\\n" };
						foreach (string special in array)
						{
							string cmp = "";
							cmp = special switch
							{
								"\\n" => "\n", 
								"\\t" => "\t", 
								"\\r" => "\r", 
								_ => "", 
							};
							if (millName.Contains(cmp) && cmp != "")
							{
								millName = millName.Replace(cmp, "");
							}
						}
						res.OrganizationName = millName;
					}
					else
					{
						res.OrganizationName = "XXXXXXXX";
					}
					if (data.organizationType != null)
					{
						res.OrganizationType = data.organizationType;
					}
					else
					{
						res.OrganizationType = "XXXXXX";
					}
					if (data.addressLine1 != null)
					{
						res.AddressLine1 = data.addressLine1;
					}
					else
					{
						res.AddressLine1 = "ASDFGH";
					}
					if (data.addressLine2 != null)
					{
						res.AddressLine2 = data.addressLine2;
					}
					else
					{
						res.AddressLine2 = "ASDFGH";
					}
					if (data.city != null)
					{
						res.City = data.city;
					}
					try
					{
						if (data.pincode != null && data.pincode.Length > 5)
						{
							res.Pincode = data.pincode;
						}
					}
					catch
					{
						res.Pincode = "111111";
					}
					if (data.state != null)
					{
						res.State = data.state;
					}
					if (data.country != null)
					{
						res.Country = data.country;
					}
					else
					{
						res.Country = "INDIA";
					}
					if (data.latitude != null)
					{
						res.Latitude = data.latitude;
					}
					else
					{
						res.Latitude = "10101.101";
					}
					if (data.longitude != null)
					{
						res.Longitude = data.longitude;
					}
					else
					{
						res.Longitude = "10101.101";
					}
					if (data.isd1 != null)
					{
						res.Isd1 = data.isd1;
					}
					else
					{
						res.Isd1 = " ";
					}
					if (data.std1 != null)
					{
						res.Std1 = data.std1;
					}
					else
					{
						res.Std1 = " ";
					}
					if (data.phoneLl1 != null)
					{
						res.PhoneLl1 = data.phoneLl1;
					}
					else
					{
						res.PhoneLl1 = " ";
					}
					if (data.emailId != null)
					{
						res.EmailId = data.emailId;
					}
					else
					{
						res.EmailId = "aaaa@gmail.com";
					}
					res.Cpid = cpId;
					res.ModifiedOn = DateTime.Now;
					res.ModifiedBy = data.userId;
					db.SaveChanges();
				}
				catch (Exception ex5)
				{
					log.Error(ex5);
					if (ex5.InnerException != null)
					{
						log.Error(ex5.InnerException.ToString());
					}
				}
				try
				{
					mdbid2 = res.Mdbid;
					MdbcontactPersonData mdbcontact = db.MdbcontactPersonData.Where((MdbcontactPersonData m) => m.Mdbid == (int?)mdbid2).FirstOrDefault();
					if (mdbcontact != null)
					{
						mdbcontact.Mdbid = mdbid2;
						if (data.prefix != null)
						{
							mdbcontact.Title = data.prefix;
						}
						else
						{
							mdbcontact.Title = "MM";
						}
						if (data.ownerName != null)
						{
							mdbcontact.FirstName = data.ownerName;
						}
						else
						{
							mdbcontact.FirstName = "AAABBBCCC";
						}
						if (data.mobNo != null)
						{
							mdbcontact.Mobile1 = data.mobNo;
						}
						db.MdbcontactPersonData.Add(mdbcontact);
						db.SaveChanges();
					}
					else
					{
						try
						{
							MdbcontactPersonData itMdb = new MdbcontactPersonData();
							itMdb.Mdbid = mdbid2;
							if (data.prefix != null)
							{
								itMdb.Title = data.prefix;
							}
							else
							{
								itMdb.Title = "MM";
							}
							if (data.ownerName != null)
							{
								itMdb.FirstName = data.ownerName;
							}
							else
							{
								itMdb.FirstName = "AAABBBCCC";
							}
							if (data.mobNo != null)
							{
								itMdb.Mobile1 = data.mobNo;
							}
							db.MdbcontactPersonData.Add(itMdb);
							db.SaveChanges();
						}
						catch (Exception ex4)
						{
							log.Error(ex4);
							if (ex4.InnerException != null)
							{
								log.Error(ex4.InnerException.ToString());
							}
						}
					}
				}
				catch (Exception ex3)
				{
					log.Error(ex3);
					if (ex3.InnerException != null)
					{
						log.Error(ex3.InnerException.ToString());
					}
				}
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

	public CommonEntity.CommonResponseCount ViewMultipleMDBMaster(MDBMasterEntity.MDBMultiple data)
	{
		CommonEntity.CommonResponseCount obj = new CommonEntity.CommonResponseCount();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = commonFunction.GetRoleName(data.userId);
			var result = (from wf in db.MdbgeneralData
				where wf.IsDeleted == 0
				select new
				{
					mdbId = wf.Mdbid,
					companyUniqueId = wf.CompanyUniqueId,
					organizationName = wf.OrganizationName,
					organizationType = wf.OrganizationType,
					addressLine1 = wf.AddressLine1,
					addressLine2 = wf.AddressLine2,
					city = wf.City,
					pincode = wf.Pincode,
					state = wf.State,
					stateId = (from wfs in db.StatesTbl
						where wfs.IsDeleted == 0 && wfs.State.Contains(wf.State)
						select wfs.StateId).FirstOrDefault(),
					country = wf.Country,
					latitude = wf.Latitude,
					longitude = wf.Longitude,
					isd1 = wf.Isd1,
					std1 = wf.Std1,
					phoneLl1 = wf.PhoneLl1,
					emailId = wf.EmailId,
					cpId = wf.Cpid,
					mdbcontact = (from wfs in db.MdbcontactPersonData
						where wfs.Mdbid == (int?)wf.Mdbid
						select new
						{
							prefix = wfs.Title,
							ownerName = wfs.FirstName,
							mobNo = wfs.Mobile1
						}).FirstOrDefault()
				}).ToList();
			if (roleName != "Administrator")
			{
				int cpId = 0;
				Guid userIdGuid = new Guid(data.userId);
				try
				{
					cpId = (from m in db.UserLogins
						where m.UserId == userIdGuid
						select m.Cpid).FirstOrDefault();
				}
				catch (Exception)
				{
				}
				result = result.Where(wf => wf.cpId == cpId).ToList();
				obj.count = result.Count;
				result = ((data.skip != 1) ? result.Skip((data.skip - 1) * data.take).Take(data.take).ToList() : result.Skip(0).Take(data.take).ToList());
			}
			if (result.Count() != 0)
			{
				obj.count = result.Count;
				result = (obj.response = ((data.skip != 1) ? result.Skip((data.skip - 1) * data.take).Take(data.take).ToList() : result.Skip(0).Take(data.take).ToList()));
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

	public CommonEntity.CommonResponse ViewMDBMasterById(int mdbId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			var result = (from wf in db.MdbgeneralData
				where wf.IsDeleted == 0 && wf.Mdbid == mdbId
				select new
				{
					mdbId = wf.Mdbid,
					companyUniqueId = wf.CompanyUniqueId,
					organizationName = wf.OrganizationName,
					organizationType = wf.OrganizationType,
					addressLine1 = wf.AddressLine1,
					addressLine2 = wf.AddressLine2,
					city = wf.City,
					pincode = wf.Pincode,
					state = wf.State,
					stateId = (from wfs in db.StatesTbl
						where wfs.IsDeleted == 0 && wfs.State.Contains(wf.State)
						select wfs.StateId).FirstOrDefault(),
					country = wf.Country,
					latitude = wf.Latitude,
					longitude = wf.Longitude,
					isd1 = wf.Isd1,
					std1 = wf.Std1,
					phoneLl1 = wf.PhoneLl1,
					emailId = wf.EmailId,
					mdbcontact = (from wfs in db.MdbcontactPersonData
						where wfs.Mdbid == (int?)wf.Mdbid
						select new
						{
							prefix = wfs.Title,
							ownerName = wfs.FirstName,
							mobNo = wfs.Mobile1
						}).FirstOrDefault()
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

	public CommonEntity.CommonResponse CheckMDBMaster(string phoneNumber)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			if ((from wf in db.MdbgeneralData
				join wfs in db.MdbcontactPersonData on wf.Mdbid equals wfs.Mdbid
				where wf.IsDeleted == 0 && wfs.Mobile1 == phoneNumber
				select wf).FirstOrDefault() != null)
			{
				obj.response = ResourceResponse.CustomerDataAlreadyExists;
				obj.isStatus = false;
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

	public CommonEntity.CommonResponse DeleteMDBMaster(int mdbId, long userId = 0L)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			MdbgeneralData res = db.MdbgeneralData.Where((MdbgeneralData m) => m.Mdbid == mdbId).FirstOrDefault();
			if (res != null)
			{
				res.IsDeleted = 0;
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

	public CommonEntity.CommonResponse ArchiveMDBMaster(int mdbId, long userId = 0L)
	{
		return new CommonEntity.CommonResponse();
	}

	public CommonEntity.CommonResponse ViewMultipleStates()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var result = (from wf in db.StatesTbl
				where wf.IsDeleted == 0
				select new
				{
					stateId = wf.StateId,
					state = wf.State
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

	public CommonEntity.CommonResponse ViewMultipleDistricts(int stateId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var result = (from wf in db.DistrictPinCodeDetailsTbl
				where wf.IsDeleted == 0 && wf.StateId == stateId
				select new
				{
					district = wf.District
				}).Distinct().ToList();
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

	public CommonEntity.CommonResponse ViewMultiplePinCode(string district)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		new CommonFunction();
		try
		{
			var result = (from wf in db.DistrictPinCodeDetailsTbl
				where wf.IsDeleted == 0 && wf.District == district
				select new
				{
					pincode = wf.Pincode
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

	public CommonEntity.CommonResponseCount ViewMultipleMDBMasterBySearchItem(string searchTerm, string userId)
	{
		CommonEntity.CommonResponseCount obj = new CommonEntity.CommonResponseCount();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = commonFunction.GetRoleName(userId);
			var result = (from wf in db.MdbgeneralData
				where wf.IsDeleted == 0 && wf.OrganizationName.Contains(searchTerm)
				select new
				{
					mdbId = wf.Mdbid,
					companyUniqueId = wf.CompanyUniqueId,
					organizationName = wf.OrganizationName,
					organizationType = wf.OrganizationType,
					addressLine1 = wf.AddressLine1,
					addressLine2 = wf.AddressLine2,
					city = wf.City,
					pincode = wf.Pincode,
					state = wf.State,
					stateId = (from wfs in db.StatesTbl
						where wfs.IsDeleted == 0 && wfs.State.Contains(wf.State)
						select wfs.StateId).FirstOrDefault(),
					country = wf.Country,
					latitude = wf.Latitude,
					longitude = wf.Longitude,
					isd1 = wf.Isd1,
					std1 = wf.Std1,
					phoneLl1 = wf.PhoneLl1,
					emailId = wf.EmailId,
					cpId = wf.Cpid,
					mdbcontact = (from wfs in db.MdbcontactPersonData
						where wfs.Mdbid == (int?)wf.Mdbid
						select new
						{
							prefix = wfs.Title,
							ownerName = wfs.FirstName,
							mobNo = wfs.Mobile1
						}).FirstOrDefault()
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
				result = result.Where(wf => wf.cpId == cpId).ToList();
				obj.count = result.Count;
			}
			if (result.Count() != 0)
			{
				obj.count = result.Count;
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
