using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using log4net;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.App_Start;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;
using static SynergyWebServices.DEL.DashboardDEL;

namespace SynergyWebServices.BLL;

public class DashboardBLL : IDashboard
{
	private readonly AppSettings appSettings;

	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(DashboardBLL));

	public DashboardBLL(IOptions<AppSettings> _appSettings, SRKSSynergyContext _db)
	{
		appSettings = _appSettings.Value;
		db = _db;
	}

	public CommonEntity.CommonResponse GetCPDetailsInDashboard(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		string roleName = new CommonFunction().GetRoleName(userId);
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
		try
		{
			if (roleName != "Administrator")
			{
				List<DashboardDEL.CPWiseVisitDetails> cPWiseVisitDetailsList2 = new List<DashboardDEL.CPWiseVisitDetails>();
				DashboardDEL.CPWiseVisitDetails cpWiseVisitDetails2 = new DashboardDEL.CPWiseVisitDetails();
				int dbCheck = db.VisitHistory.Where((VisitHistory m) => m.UserId == userId && m.IsDeleted == (bool?)false).ToList().Count();
				int totalMonthViseVisitCount = 0;
				SqlConnection SqlConnection3 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds3 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection3.Open();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCPWiseMonthVisitCount", SqlConnection3);
						sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
						sqlDataAdapter.Fill(ds3);
						SqlConnection3.Close();
					}
					if (ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
					{
						totalMonthViseVisitCount = Convert.ToInt32(ds3.Tables[0].Rows[0]["cpMonthVisitCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				cpWiseVisitDetails2.cpName = (from m in db.ChannelPartners
					where m.Cpid == cpId
					select m.Cpname).FirstOrDefault();
				cpWiseVisitDetails2.cpId = cpId;
				cpWiseVisitDetails2.monthVisitCount = totalMonthViseVisitCount;
				cpWiseVisitDetails2.totalVisitsCount = dbCheck;
				cPWiseVisitDetailsList2.Add(cpWiseVisitDetails2);
				var list2 = (from m in cPWiseVisitDetailsList2
					group m by m.cpId into m
					select new
					{
						cpId = m.Key,
						totalVisitCount = m.Sum((DashboardDEL.CPWiseVisitDetails s) => s.totalVisitsCount),
						cpName = m.First().cpName,
						monthVisitCount = m.Sum((DashboardDEL.CPWiseVisitDetails t) => t.monthVisitCount)
					}).ToList();
				obj.isStatus = true;
				obj.response = list2;
				return obj;
			}
			SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
			DataSet ds = new DataSet();
			try
			{
				using (new SqlConnection())
				{
					SqlConnection.Open();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetCPWiseVisitCount", SqlConnection);
					sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter2.Fill(ds);
					SqlConnection.Close();
				}
				if (ds != null)
				{
					if (ds.Tables.Count > 0)
					{
						if (ds.Tables[0].Rows.Count > 0)
						{
							List<DashboardDEL.CPWiseVisitDetails> cPWiseVisitDetailsList = new List<DashboardDEL.CPWiseVisitDetails>();
							for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
							{
								DashboardDEL.CPWiseVisitDetails cpWiseVisitDetails = new DashboardDEL.CPWiseVisitDetails();
								string userIds = ds.Tables[0].Rows[i]["userId"].ToString();
								Guid userIdGuid2 = new Guid(userIds);
								int item = (from m in db.UserLogins
									where m.UserId == userIdGuid2
									select m.Cpid).FirstOrDefault();
								cpWiseVisitDetails.cpId = item;
								if (item != 0)
								{
									cpWiseVisitDetails.cpName = (from m in db.ChannelPartners
										where m.Cpid == item
										select m.Cpname).FirstOrDefault();
								}
								cpWiseVisitDetails.totalVisitsCount = Convert.ToInt32(ds.Tables[0].Rows[i]["totalCount"]);
								SqlConnection SqlConnection2 = new SqlConnection(appSettings.DefaultConnection);
								DataSet ds2 = new DataSet();
								try
								{
									using (new SqlConnection())
									{
										SqlConnection2.Open();
										SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetCPWiseMonthVisitCount", SqlConnection2);
										sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
										sqlDataAdapter3.SelectCommand.Parameters.AddWithValue("@userId", userIds);
										sqlDataAdapter3.Fill(ds2);
										SqlConnection2.Close();
									}
									if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
									{
										cpWiseVisitDetails.monthVisitCount = Convert.ToInt32(ds2.Tables[0].Rows[0]["cpMonthVisitCount"]);
									}
								}
								catch (Exception)
								{
									obj.response = ResourceResponse.ExceptionMessage;
									obj.isStatus = false;
								}
								cPWiseVisitDetailsList.Add(cpWiseVisitDetails);
							}
							var list = (from m in cPWiseVisitDetailsList
								group m by m.cpId into m
								select new
								{
									cpId = m.Key,
									totalVisitCount = m.Sum((DashboardDEL.CPWiseVisitDetails s) => s.totalVisitsCount),
									cpName = m.First().cpName,
									monthVisitCount = m.Sum((DashboardDEL.CPWiseVisitDetails t) => t.monthVisitCount)
								}).ToList();
							obj.isStatus = true;
							obj.response = list;
							return obj;
						}
						return obj;
					}
					return obj;
				}
				return obj;
			}
			catch (Exception)
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

	public CommonEntity.CommonResponse GetCPDetailsInDashboardForQuotation(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = commonFunction.GetRoleName(userId);
			int cpIdBasedOnUserId = 0;
			Guid userIdGuid = new Guid(userId);
			try
			{
				cpIdBasedOnUserId = (from m in db.UserLogins
					where m.UserId == userIdGuid
					select m.Cpid).FirstOrDefault();
			}
			catch (Exception)
			{
			}
			if (roleName != "Administrator")
			{
				SqlConnection SqlConnection2 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds2 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection2.Open();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCPWiseQuotationCount", SqlConnection2);
						sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpIdBasedOnUserId);
						sqlDataAdapter.Fill(ds2);
						SqlConnection2.Close();
					}
					if (ds2 != null)
					{
						if (ds2.Tables.Count > 0)
						{
							if (ds2.Tables[0].Rows.Count > 0)
							{
								List<DashboardDEL.CPWiseQuotationDetails> cPWiseQuotationDetailsList2 = new List<DashboardDEL.CPWiseQuotationDetails>();
								for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
								{
									DashboardDEL.CPWiseQuotationDetails cPWiseQuotationDetails2 = new DashboardDEL.CPWiseQuotationDetails();
									int cpId2 = Convert.ToInt32(ds2.Tables[0].Rows[j]["CPID"]);
									cPWiseQuotationDetails2.cpName = (from m in db.ChannelPartners
										where m.Cpid == cpId2
										select m.Cpname).FirstOrDefault();
									cPWiseQuotationDetails2.cpId = cpId2;
									cPWiseQuotationDetails2.totalQuotationCount = Convert.ToInt32(ds2.Tables[0].Rows[j]["totalCount"]);
									SqlConnection SqlConnection4 = new SqlConnection(appSettings.DefaultConnection);
									DataSet ds4 = new DataSet();
									try
									{
										using (new SqlConnection())
										{
											SqlConnection4.Open();
											SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetCPWiseMonthQutationCount", SqlConnection4);
											sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
											sqlDataAdapter2.SelectCommand.Parameters.AddWithValue("@cpId", cpId2);
											sqlDataAdapter2.Fill(ds4);
											SqlConnection4.Close();
										}
										if (ds4 != null && ds4.Tables.Count > 0 && ds4.Tables[0].Rows.Count > 0)
										{
											cPWiseQuotationDetails2.monthQuotationCount = Convert.ToInt32(ds4.Tables[0].Rows[0]["cpMonthQuotationCount"]);
										}
									}
									catch (Exception)
									{
										obj.response = ResourceResponse.ExceptionMessage;
										obj.isStatus = false;
									}
									SqlConnection SqlConnection6 = new SqlConnection(appSettings.DefaultConnection);
									DataSet ds6 = new DataSet();
									try
									{
										using (new SqlConnection())
										{
											SqlConnection6.Open();
											SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetCPWiseQuotationTotalPrice", SqlConnection6);
											sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
											sqlDataAdapter3.SelectCommand.Parameters.AddWithValue("@cpId", cpId2);
											sqlDataAdapter3.Fill(ds6);
											SqlConnection6.Close();
										}
										if (ds6 != null && ds6.Tables.Count > 0 && ds6.Tables[0].Rows.Count > 0)
										{
											double totalPrice2 = 0.0;
											for (int l = 0; l < ds6.Tables[0].Rows.Count; l++)
											{
												double p2 = Convert.ToDouble(ds6.Tables[0].Rows[0]["overallprice"].ToString());
												totalPrice2 += p2;
											}
											cPWiseQuotationDetails2.totalPrice = totalPrice2;
										}
									}
									catch (Exception)
									{
										obj.response = ResourceResponse.ExceptionMessage;
										obj.isStatus = false;
									}
									cPWiseQuotationDetailsList2.Add(cPWiseQuotationDetails2);
								}
								var list2 = (from m in cPWiseQuotationDetailsList2
									group m by m.cpId into m
									select new
									{
										cpId = m.Key,
										totalQuotationCount = m.Sum((DashboardDEL.CPWiseQuotationDetails s) => s.totalQuotationCount),
										cpName = m.First().cpName,
										monthQuotationCount = m.Sum((DashboardDEL.CPWiseQuotationDetails t) => t.monthQuotationCount),
										totalPrice = m.Sum((DashboardDEL.CPWiseQuotationDetails u) => u.totalPrice)
									}).ToList();
								obj.isStatus = true;
								obj.response = list2;
								return obj;
							}
							return obj;
						}
						return obj;
					}
					return obj;
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
					return obj;
				}
			}
			SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
			DataSet ds = new DataSet();
			try
			{
				using (new SqlConnection())
				{
					SqlConnection.Open();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetCPWiseQuotationCount", SqlConnection);
					sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter4.Fill(ds);
					SqlConnection.Close();
				}
				if (ds != null)
				{
					if (ds.Tables.Count > 0)
					{
						if (ds.Tables[0].Rows.Count > 0)
						{
							List<DashboardDEL.CPWiseQuotationDetails> cPWiseQuotationDetailsList = new List<DashboardDEL.CPWiseQuotationDetails>();
							for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
							{
								DashboardDEL.CPWiseQuotationDetails cPWiseQuotationDetails = new DashboardDEL.CPWiseQuotationDetails();
								int cpId = Convert.ToInt32(ds.Tables[0].Rows[i]["CPID"]);
								if (cpId == 0)
								{
									cPWiseQuotationDetails.cpName = "Administrator";
								}
								else
								{
									cPWiseQuotationDetails.cpName = (from m in db.ChannelPartners
										where m.Cpid == cpId
										select m.Cpname).FirstOrDefault();
								}
								cPWiseQuotationDetails.cpId = cpId;
								cPWiseQuotationDetails.totalQuotationCount = Convert.ToInt32(ds.Tables[0].Rows[i]["totalCount"]);
								SqlConnection SqlConnection3 = new SqlConnection(appSettings.DefaultConnection);
								DataSet ds3 = new DataSet();
								try
								{
									using (new SqlConnection())
									{
										SqlConnection3.Open();
										SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("GetCPWiseMonthQutationCount", SqlConnection3);
										sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
										sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
										sqlDataAdapter5.Fill(ds3);
										SqlConnection3.Close();
									}
									if (ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
									{
										cPWiseQuotationDetails.monthQuotationCount = Convert.ToInt32(ds3.Tables[0].Rows[0]["cpMonthQuotationCount"]);
									}
								}
								catch (Exception)
								{
									obj.response = ResourceResponse.ExceptionMessage;
									obj.isStatus = false;
								}
								SqlConnection SqlConnection5 = new SqlConnection(appSettings.DefaultConnection);
								DataSet ds5 = new DataSet();
								try
								{
									using (new SqlConnection())
									{
										SqlConnection5.Open();
										SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter("GetCPWiseQuotationTotalPrice", SqlConnection5);
										sqlDataAdapter6.SelectCommand.CommandType = CommandType.StoredProcedure;
										sqlDataAdapter6.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
										sqlDataAdapter6.Fill(ds5);
										SqlConnection5.Close();
									}
									if (ds5 != null && ds5.Tables.Count > 0 && ds5.Tables[0].Rows.Count > 0)
									{
										double totalPrice = 0.0;
										for (int k = 0; k < ds5.Tables[0].Rows.Count; k++)
										{
											double p = Convert.ToDouble(ds5.Tables[0].Rows[0]["overallprice"].ToString());
											totalPrice += p;
										}
										cPWiseQuotationDetails.totalPrice = totalPrice;
									}
								}
								catch (Exception)
								{
									obj.response = ResourceResponse.ExceptionMessage;
									obj.isStatus = false;
								}
								cPWiseQuotationDetailsList.Add(cPWiseQuotationDetails);
							}
							var list = (from m in cPWiseQuotationDetailsList
								group m by m.cpId into m
								select new
								{
									cpId = m.Key,
									totalQuotationCount = m.Sum((DashboardDEL.CPWiseQuotationDetails s) => s.totalQuotationCount),
									cpName = m.First().cpName,
									monthQuotationCount = m.Sum((DashboardDEL.CPWiseQuotationDetails t) => t.monthQuotationCount),
									totalPrice = m.Sum((DashboardDEL.CPWiseQuotationDetails u) => u.totalPrice)
								}).ToList();
							obj.isStatus = true;
							obj.response = list;
							return obj;
						}
						return obj;
					}
					return obj;
				}
				return obj;
			}
			catch (Exception)
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

	public CommonEntity.CommonResponse GetDashboardDetails(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			DateTime.Now.Year.ToString();
			string roleName = commonFunction.GetRoleName(userId);
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

            decimal conv;
            conv = db.CHFValueConvs.FirstOrDefault().CurrentCHFValue * 1000000;
            List<DashboardDEL.DashboardCustom> dashboardCustomsList = new List<DashboardDEL.DashboardCustom>();
			DashboardDEL.DashboardCustom dashboardCustom = new DashboardDEL.DashboardCustom();
			if (roleName != "Administrator")
			{
				SqlConnection SqlConnection2 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds2 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection2.Open();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetYearWiseCPCounts", SqlConnection2);
						sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
						sqlDataAdapter.Fill(ds2);
						SqlConnection2.Close();
					}
					if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.totalVisitsCount = Convert.ToInt32(ds2.Tables[0].Rows[0]["TotalVisitCount"]);
					}
					if (ds2 != null && ds2.Tables[1].Rows.Count > 0)
					{
						dashboardCustom.totalQuotationCount = Convert.ToInt32(ds2.Tables[1].Rows[0]["TotalQuotationCount"]);
					}
					if (ds2 != null && ds2.Tables[2].Rows.Count > 0)
					{
						dashboardCustom.totalLeadsCount = Convert.ToInt32(ds2.Tables[2].Rows[0]["TotalLeadsCount"]);
					}
					if (ds2 != null && ds2.Tables[3].Rows.Count > 0)
					{
						dashboardCustom.totalOrdersCount = Convert.ToInt32(ds2.Tables[3].Rows[0]["TotalOrderCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection4 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds4 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection4.Open();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetMonthWiseVisitCount", SqlConnection4);
						sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter2.SelectCommand.Parameters.AddWithValue("@userId", userId);
						sqlDataAdapter2.Fill(ds4);
						SqlConnection4.Close();
					}
					if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthVisitsCount = Convert.ToInt32(ds4.Tables[0].Rows[0]["monthVisitCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection6 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds6 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection6.Open();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetMonthWiseLeadsCount", SqlConnection6);
						sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter3.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
						sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter3.Fill(ds4);
						SqlConnection6.Close();
					}
					if (ds6 != null && ds6.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthLeadsCount = Convert.ToInt32(ds6.Tables[0].Rows[0]["monthLeadsCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection8 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds8 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection8.Open();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetMonthWiseQuotationCount", SqlConnection8);
						sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter4.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
						sqlDataAdapter4.Fill(ds8);
						SqlConnection8.Close();
					}
					if (ds8 != null && ds8.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthQutationCount = Convert.ToInt32(ds8.Tables[0].Rows[0]["monthQuotationCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection10 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds10 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection10.Open();
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("GetMonthWiseOrderCount", SqlConnection10);
						sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
						sqlDataAdapter5.Fill(ds10);
						SqlConnection10.Close();
					}
					if (ds10 != null && ds10.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthOrdersCount = Convert.ToInt32(ds10.Tables[0].Rows[0]["monthOrderCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				//new Dashboard Creation from Digitelligence Technologies pvt ltd 2023
                SqlConnection SqlConnection20 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds20 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection20.Open();
                        SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter("HotlistOppurtunity", SqlConnection20);
                        sqlDataAdapter13.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter13.Fill(ds20);
                        SqlConnection20.Close();
                    }
                    if (ds20 != null && ds20.Tables[0].Rows.Count > 0)
                    {
                        decimal HotlistOppurtunityCount = 0;
                        for (int l = 0; l < ds20.Tables[0].Rows.Count; l++)
                        {
                            HotlistOppurtunityCount = Math.Round(Convert.ToDecimal(ds20.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                        }
                        dashboardCustom.monthHotlistCount = HotlistOppurtunityCount;
                        // dashboardCustom.monthHotlistCount = Convert.ToInt32(ds20.Tables[0].Rows[0]["totalquotation"]);//HotlistOpportunity//
                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
                SqlConnection SqlConnection17 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds17 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection17.Open();
                        SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter("LostOederCount", SqlConnection17);
                        sqlDataAdapter14.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter14.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter14.Fill(ds17);
                        SqlConnection17.Close();
                    }
                    if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                    {
                        dashboardCustom.monthOpportunitieslossCount = Convert.ToInt32(ds17.Tables[0].Rows[0]["quoteCount"]);
                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }


                SqlConnection SqlConnection7 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds7 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection7.Open();
                        SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("ActiveOppurtunityCount", SqlConnection7);
                        sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter5.Fill(ds7);
                        SqlConnection7.Close();
                    }
                    if (ds7 != null && ds7.Tables[0].Rows.Count > 0)
                    {
                        dashboardCustom.monthQutationCount = Convert.ToInt32(ds7.Tables[0].Rows[0]["quoteCount"]);
                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
                SqlConnection SqlConnection1 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds1 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection1.Open();
                        SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter("ActiveOppurtunityValue", SqlConnection1);
                        sqlDataAdapter9.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter9.Fill(ds1);
                        SqlConnection1.Close();
                    }
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        decimal monthActiveOpportunitiesCount = 0;
                        for (int l = 0; l < ds1.Tables[0].Rows.Count; l++)
                        {
                            monthActiveOpportunitiesCount = Math.Round(Convert.ToDecimal(ds1.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                        }
                        dashboardCustom.activeopportunity = monthActiveOpportunitiesCount;
                        // dashboardCustom.monthActiveOpportunitiesCount = Convert.ToInt32(ds1.Tables[0].Rows[0]["totalOpportunity"]);

                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection36 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityValue
                DataSet ds36 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection36.Open();
                        SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter("GetMonthWiseOppurtunityValue", SqlConnection36);
                        sqlDataAdapter10.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter10.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter10.Fill(ds36);
                        SqlConnection36.Close();
                    }
                    if (ds36 != null && ds36.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds36.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds36.Tables[0].Rows[l]["totalquotation"] is null))
                            {
                                monthWiseValues[m] = new MonthWiseValues();

                                monthWiseValues[m].Value = Math.Round(Convert.ToDecimal(ds36.Tables[0].Rows[l]["totalquotation"]) / (conv), 2);
                                monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds36.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds36.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthWiseValue = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
                SqlConnection SqlConnection37 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityCount
                DataSet ds37 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection37.Open();
                        SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetQuoteCountMonthWise", SqlConnection37);
                        sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter7.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter7.Fill(ds37);
                        SqlConnection37.Close();
                    }
                    if (ds37 != null && ds37.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds37.Tables[0].Rows.Count - 1; l++)
                        {
                            if (!((ds37.Tables[0].Rows[l][2] is null)))
                            {
                                monthWiseValues[m] = new MonthWiseValues();

                                monthWiseValues[m].Value = Convert.ToDecimal(ds37.Tables[0].Rows[l][2]);
                                monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds37.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds37.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthWiseCount = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection38 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityValue
                DataSet ds38 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection38.Open();
                        SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter("GetMonthCumOppurtunityValue", SqlConnection38);
                        sqlDataAdapter8.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter8.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter8.Fill(ds38);
                        SqlConnection38.Close();
                    }
                    if (ds38 != null && ds38.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds38.Tables[0].Rows.Count - 1; l++)
                        {
                            if (!(ds38.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds38.Tables[0].Rows[l][2]) / (conv), 2);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds38.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds38.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthCumValue = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
                SqlConnection SqlConnection39 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityCount
                DataSet ds39 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection39.Open();
                        SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter("GetMonthCumOppurtunityCount", SqlConnection39);
                        sqlDataAdapter9.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter9.Fill(ds39);
                        SqlConnection39.Close();
                    }
                    if (ds39 != null && ds39.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds39.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds39.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Convert.ToDecimal(ds39.Tables[0].Rows[l][2]);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds39.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds39.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthCumCount = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection40 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastCount
                DataSet ds40 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection40.Open();
                        SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter("OppurtunityForecastCount", SqlConnection40);
                        sqlDataAdapter11.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter11.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter11.Fill(ds40);
                        SqlConnection40.Close();
                    }
                    if (ds40 != null && ds40.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds40.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds40.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Convert.ToDecimal(ds40.Tables[0].Rows[l][2]);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds40.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds40.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.ForecastCount = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection31 = new SqlConnection(appSettings.DefaultConnection);  //GetOppurtunity Pipeline
                DataSet ds31 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection31.Open();
                        SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter("OppurtunityPipeline", SqlConnection31);
                        sqlDataAdapter13.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter13.Fill(ds31);
                        SqlConnection31.Close();
                    }
                    if (ds31 != null && ds31.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[3];
                        int HL = 0;
                        for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                        {

                            HL = HL + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);

                        }

                        for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                        {

                            switch (ds31.Tables[0].Rows[l]["BYJTChances"])
                            {
                                case > 60:

                                    monthWiseValues[2] = new MonthWiseValues();
                                    monthWiseValues[2].Value = monthWiseValues[2].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                    monthWiseValues[2].MMYY = "Hotlist";
                                    break;
                                case > 40 and < 61:
                                    monthWiseValues[1] = new MonthWiseValues();
                                    monthWiseValues[1].Value = monthWiseValues[1].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                    monthWiseValues[1].MMYY = "Potential";
                                    break;
                                default:
                                    monthWiseValues[0] = new MonthWiseValues();
                                    monthWiseValues[0].Value = monthWiseValues[0].Value + Convert.ToInt32(Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]));
                                    monthWiseValues[0].MMYY = "Pipeline";
                                    break;


                            }

                        }

                        dashboardCustom.OppurtunityPipeline = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection41 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                DataSet ds41 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection41.Open();
                        SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter("OppurtunityForecast", SqlConnection41);
                        sqlDataAdapter12.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter12.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter12.Fill(ds41);
                        SqlConnection41.Close();
                    }
                    if (ds41 != null && ds41.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds41.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds41.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds41.Tables[0].Rows[l][2]) / (conv), 2);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds41.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds41.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.ForecastValue = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection42 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                DataSet ds42 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection42.Open();
                        SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter("visitsAnnualbyMonth", SqlConnection42);
                        sqlDataAdapter14.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter14.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter14.Fill(ds42);
                  
                        SqlConnection42.Close();
                    }
                    if (ds40 != null && ds42.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds42.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds42.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Convert.ToDecimal(ds42.Tables[0].Rows[l][2]);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds42.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds42.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.AnnualVisitByMonth = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }


                SqlConnection SqlConnection35 = new SqlConnection(appSettings.DefaultConnection);  //ZoneWiseOppurtunities
                DataSet ds35 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection35.Open();

                        SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter("ZoneWiseOppurtunities", SqlConnection35);
                        sqlDataAdapter18.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter18.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                        sqlDataAdapter18.Fill(ds35);
                        SqlConnection35.Close();
                    }
                    if (ds35 != null && ds35.Tables[0].Rows.Count > 0)
                    {
                        decimal TotalZoneQuote = 0;
                        for (int l = 0; l < ds35.Tables[0].Rows.Count; l++)
                        {
                            TotalZoneQuote += Convert.ToDecimal(ds35.Tables[0].Rows[l]["totalquotation"]);

                        }
                        decimal[] ZonePcnt = new decimal[7];
                        for (int l = 0; l < ds35.Tables[0].Rows.Count; l++)
                        {
                            ZonePcnt[l] = (Convert.ToDecimal(ds35.Tables[0].Rows[l]["totalquotation"]) / TotalZoneQuote) * 100;

                        }

                        dashboardCustom.QuoteZonwise = ZonePcnt;

                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection12 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds12 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection12.Open();
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter("GetMonthWiseCPAllCounts", SqlConnection12);
						sqlDataAdapter6.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter6.SelectCommand.Parameters.AddWithValue("@userId", userId);
						sqlDataAdapter6.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
						sqlDataAdapter6.Fill(ds12);
						SqlConnection12.Close();
					}
					if (ds12 != null && ds12.Tables[0].Rows.Count > 0)
					{
						int[] visitMonthWiseCount2 = new int[12];
						for (int i4 = 0; i4 < ds12.Tables[0].Rows.Count; i4++)
						{
							switch (Convert.ToInt32(ds12.Tables[0].Rows[i4]["month"]))
							{
							case 1:
								visitMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 2:
								visitMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 3:
								visitMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 4:
								visitMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 5:
								visitMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 6:
								visitMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 7:
								visitMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 8:
								visitMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 9:
								visitMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 10:
								visitMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 11:
								visitMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							case 12:
								visitMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
								break;
							}
							dashboardCustom.visitMonthWiseCount = visitMonthWiseCount2;
						}
					}
					if (ds12 != null && ds12.Tables[1].Rows.Count > 0)
					{
						int[] leadsMonthWiseCount2 = new int[12];
						for (int i3 = 0; i3 < ds12.Tables[1].Rows.Count; i3++)
						{
							switch (Convert.ToInt32(ds12.Tables[1].Rows[i3]["month"]))
							{
							case 1:
								leadsMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 2:
								leadsMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 3:
								leadsMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 4:
								leadsMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 5:
								leadsMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 6:
								leadsMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 7:
								leadsMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 8:
								leadsMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 9:
								leadsMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 10:
								leadsMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 11:
								leadsMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							case 12:
								leadsMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
								break;
							}
							dashboardCustom.leadsMonthWiseCount = leadsMonthWiseCount2;
						}
					}
					if (ds12 != null && ds12.Tables[2].Rows.Count > 0)
					{
						int[] quotationMonthWiseCount2 = new int[12];
						for (int i2 = 0; i2 < ds12.Tables[2].Rows.Count; i2++)
						{
							switch (Convert.ToInt32(ds12.Tables[2].Rows[i2]["month"]))
							{
							case 1:
								quotationMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 2:
								quotationMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 3:
								quotationMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 4:
								quotationMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 5:
								quotationMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 6:
								quotationMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 7:
								quotationMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 8:
								quotationMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 9:
								quotationMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 10:
								quotationMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 11:
								quotationMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							case 12:
								quotationMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
								break;
							}
							dashboardCustom.quotationMonthWiseCount = quotationMonthWiseCount2;
						}
					}
					if (ds12 != null && ds12.Tables[3].Rows.Count > 0)
					{
						int[] orderMonthWiseCount2 = new int[12];
						for (int n = 0; n < ds12.Tables[0].Rows.Count; n++)
						{
							switch (Convert.ToInt32(ds12.Tables[3].Rows[n]["month"]))
							{
							case 1:
								orderMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 2:
								orderMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 3:
								orderMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 4:
								orderMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 5:
								orderMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 6:
								orderMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 7:
								orderMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 8:
								orderMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 9:
								orderMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 10:
								orderMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 11:
								orderMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							case 12:
								orderMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
								break;
							}
							dashboardCustom.orderMonthWiseCount = orderMonthWiseCount2;
						}
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
			}
			else
			{
				SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection.Open();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetYearWiseAllCounts", SqlConnection);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        sqlDataAdapter.Fill(ds);
                        SqlConnection.Close();
					}
					if (ds != null && ds.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.totalVisitsCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalVisitCount"]);
					}
					if (ds != null && ds.Tables[1].Rows.Count > 0)
					{
						dashboardCustom.totalQuotationCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalQuotationCount"]);
					}
					if (ds != null && ds.Tables[2].Rows.Count > 0)
					{
						dashboardCustom.totalLeadsCount = Convert.ToInt32(ds.Tables[2].Rows[0]["TotalLeadsCount"]);
					}
					if (ds != null && ds.Tables[3].Rows.Count > 0)
					{
						dashboardCustom.totalOrdersCount = Convert.ToInt32(ds.Tables[3].Rows[0]["TotalOrderCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection3 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds3 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection3.Open();
						new SqlDataAdapter("GetMonthWiseVisitCount", SqlConnection3).Fill(ds3);
						SqlConnection3.Close();
					}
					if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthVisitsCount = Convert.ToInt32(ds3.Tables[0].Rows[0]["monthVisitCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection5 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds5 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection5.Open();
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetMonthWiseLeadsCount", SqlConnection5);
						sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
						sqlDataAdapter7.Fill(ds5);
						SqlConnection5.Close();
					}
					if (ds5 != null && ds5.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthLeadsCount = Convert.ToInt32(ds5.Tables[0].Rows[0]["monthLeadsCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				SqlConnection SqlConnection7 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds7 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection7.Open();
                        new SqlDataAdapter("ActiveOppurtunityCount", SqlConnection7).Fill(ds7);//count of active opportunity//
                        SqlConnection7.Close();
					}
					if (ds7 != null && ds7.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthQutationCount = Convert.ToInt32(ds7.Tables[0].Rows[0]["quoteCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
                SqlConnection SqlConnection26 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds26 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection26.Open();
                        new SqlDataAdapter("OpportunitiesOB", SqlConnection26).Fill(ds26);//opportunities to ob
                        SqlConnection26.Close();
                    }
                    if (ds26 != null && ds26.Tables[0].Rows.Count > 0)
                    {

                        dashboardCustom.totalOpportunitiesOBCount = Convert.ToInt32(ds26.Tables[0].Rows[0]["totalorderCoverted"]);
                    }
                    if (ds26 != null && ds26.Tables[0].Rows.Count > 0)
                    {

                        dashboardCustom.monthOpportunitiesOBCount = Convert.ToInt32(ds26.Tables[0].Rows[0]["ConvertedPrice"]);
                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }


                SqlConnection SqlConnection9 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds9 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection9.Open();
						new SqlDataAdapter("GetMonthWiseOrderCount", SqlConnection9).Fill(ds9);
						SqlConnection9.Close();
					}
					if (ds9 != null && ds9.Tables[0].Rows.Count > 0)
					{
						dashboardCustom.monthOrdersCount = Convert.ToInt32(ds9.Tables[0].Rows[0]["monthOrderCount"]);
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}
				  


				SqlConnection SqlConnection11 = new SqlConnection(appSettings.DefaultConnection);
				DataSet ds11 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection11.Open();
						new SqlDataAdapter("GetMonthWiseAllCounts", SqlConnection11).Fill(ds11);
						SqlConnection11.Close();
					}
					if (ds11 != null && ds11.Tables[0].Rows.Count > 0)
					{
						int[] visitMonthWiseCount = new int[12];
						for (int l = 0; l < ds11.Tables[0].Rows.Count; l++)
						{
							switch (Convert.ToInt32(ds11.Tables[0].Rows[l]["month"]))
							{
							case 1:
								visitMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 2:
								visitMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 3:
								visitMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 4:
								visitMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 5:
								visitMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 6:
								visitMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 7:
								visitMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 8:
								visitMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 9:
								visitMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 10:
								visitMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 11:
								visitMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							case 12:
								visitMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
								break;
							}
							dashboardCustom.visitMonthWiseCount = visitMonthWiseCount;
						}
					}
					if (ds11 != null && ds11.Tables[1].Rows.Count > 0)
					{
						int[] leadsMonthWiseCount = new int[12];
						for (int k = 0; k < ds11.Tables[1].Rows.Count; k++)
						{
							switch (Convert.ToInt32(ds11.Tables[1].Rows[k]["month"]))
							{
							case 1:
								leadsMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 2:
								leadsMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 3:
								leadsMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 4:
								leadsMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 5:
								leadsMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 6:
								leadsMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 7:
								leadsMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 8:
								leadsMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 9:
								leadsMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 10:
								leadsMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 11:
								leadsMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							case 12:
								leadsMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
								break;
							}
							dashboardCustom.leadsMonthWiseCount = leadsMonthWiseCount;
						}
					}
					if (ds11 != null && ds11.Tables[2].Rows.Count > 0)
					{
						int[] quotationMonthWiseCount = new int[12];
						for (int j = 0; j < ds11.Tables[2].Rows.Count; j++)
						{
							switch (Convert.ToInt32(ds11.Tables[2].Rows[j]["month"]))
							{
							case 1:
								quotationMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 2:
								quotationMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 3:
								quotationMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 4:
								quotationMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 5:
								quotationMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 6:
								quotationMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 7:
								quotationMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 8:
								quotationMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 9:
								quotationMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 10:
								quotationMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 11:
								quotationMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							case 12:
								quotationMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
								break;
							}
							dashboardCustom.quotationMonthWiseCount = quotationMonthWiseCount;
						}
					}
					if (ds11 != null && ds11.Tables[3].Rows.Count > 0)
					{
						int[] orderMonthWiseCount = new int[12];
						for (int i = 0; i < ds11.Tables[0].Rows.Count; i++)
						{
							switch (Convert.ToInt32(ds11.Tables[3].Rows[i]["month"]))
							{
							case 1:
								orderMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 2:
								orderMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 3:
								orderMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 4:
								orderMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 5:
								orderMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 6:
								orderMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 7:
								orderMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 8:
								orderMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 9:
								orderMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 10:
								orderMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 11:
								orderMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							case 12:
								orderMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
								break;
							}
							dashboardCustom.orderMonthWiseCount = orderMonthWiseCount;
						}
					}
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
					obj.isStatus = false;
				}


				//New Dashboard Data Created 28-05-2023 Digitelligence


				SqlConnection SqlConnection35 = new SqlConnection(appSettings.DefaultConnection);  //ZoneWiseOppurtunities
                DataSet ds35 = new DataSet();
				try
				{
					using (new SqlConnection())
					{
						SqlConnection35.Open();
						new SqlDataAdapter("ZoneWiseOppurtunities", SqlConnection35).Fill(ds35);
						SqlConnection35.Close();
					}
					if (ds35 != null && ds35.Tables[0].Rows.Count > 0)
					{
						decimal TotalZoneQuote = 0;
						for (int l = 0; l < ds35.Tables[0].Rows.Count; l++)
						{
							TotalZoneQuote += Convert.ToDecimal( ds35.Tables[0].Rows[l]["totalquotation"]);

                        }
						decimal[] ZonePcnt = new decimal[7];
                        for (int l = 0; l < ds35.Tables[0].Rows.Count; l++)
                        {
                            ZonePcnt[l] = (Convert.ToDecimal(ds35.Tables[0].Rows[l]["totalquotation"])/ TotalZoneQuote)*100;

                        }

						dashboardCustom.QuoteZonwise = ZonePcnt;

                    }
				}
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
                SqlConnection SqlConnection31 = new SqlConnection(appSettings.DefaultConnection);  //GetOppurtunity Pipeline
                DataSet ds31 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection31.Open();
                        new SqlDataAdapter("OppurtunityPipeline", SqlConnection31).Fill(ds31);
                        SqlConnection31.Close();
                    }
                    if (ds31 != null && ds31.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[3];
                        int HL = 0;
                        for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                        {

                            HL = HL + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);

                        }

                        for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                        {

                            switch (ds31.Tables[0].Rows[l]["BYJTChances"])
                            {
                                case > 60:

                                    monthWiseValues[2] = new MonthWiseValues();
                                    monthWiseValues[2].Value = monthWiseValues[2].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                    monthWiseValues[2].MMYY = "Hotlist";
                                    break;
                                case > 40 and < 61:
                                    monthWiseValues[1] = new MonthWiseValues();
                                    monthWiseValues[1].Value = monthWiseValues[1].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                    monthWiseValues[1].MMYY = "Potential";
                                    break;
                                default:
                                    monthWiseValues[0] = new MonthWiseValues();
                                    monthWiseValues[0].Value = monthWiseValues[0].Value + Convert.ToInt32(Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]));
                                    monthWiseValues[0].MMYY = "Pipeline";
                                    break;


                            }

                        }
                       
                        dashboardCustom.OppurtunityPipeline = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }


                SqlConnection SqlConnection20 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds20 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection20.Open();
                        new SqlDataAdapter("HotlistOppurtunity", SqlConnection20).Fill(ds20);//hotlist opportunity
                        SqlConnection20.Close();
                    }
                    if (ds20 != null && ds20.Tables[0].Rows.Count > 0)
                    {
                        decimal HotlistOppurtunityCount = 0;
                        for (int l = 0; l < ds20.Tables[0].Rows.Count; l++)
                        {
                            HotlistOppurtunityCount = Math.Round(Convert.ToDecimal(ds20.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                        }
                        dashboardCustom.monthHotlistCount = HotlistOppurtunityCount;
                        // dashboardCustom.monthHotlistCount = Convert.ToInt32(ds20.Tables[0].Rows[0]["totalquotation"]);//HotlistOpportunity//
                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection1 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds1 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection1.Open();
                        //int conv = 2130;
                        // decimal result = db.CHFValueConvs.FirstOrDefault().CurrentCHFValue / 100m;
                        // string formatted = result.ToString("c");


                        new SqlDataAdapter("ActiveOppurtunityValue", SqlConnection1).Fill(ds1);//ActiveOpportunity in CHF
                        SqlConnection1.Close();
                    }
                    if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        decimal monthActiveOpportunitiesCount = 0;
                        for (int l = 0; l < ds1.Tables[0].Rows.Count; l++)
                        {
                            monthActiveOpportunitiesCount = Math.Round(Convert.ToDecimal(ds1.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                        }
                        dashboardCustom.activeopportunity = monthActiveOpportunitiesCount;
                        // dashboardCustom.monthActiveOpportunitiesCount = Convert.ToInt32(ds1.Tables[0].Rows[0]["totalOpportunity"]);

                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection17 = new SqlConnection(appSettings.DefaultConnection);
                DataSet ds17 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection17.Open();
                        new SqlDataAdapter("LostOederCount", SqlConnection17).Fill(ds17);
                        SqlConnection17.Close();
                    }
                    if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                    {
                        dashboardCustom.monthOpportunitieslossCount = Convert.ToInt32(ds17.Tables[0].Rows[0]["quoteCount"]);
                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection36 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityValue
                DataSet ds36 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection36.Open();
                        new SqlDataAdapter("GetMonthWiseOppurtunityValue", SqlConnection36).Fill(ds36);
                        SqlConnection36.Close();
                    }
                    if (ds36 != null && ds36.Tables[0].Rows.Count > 0)
                    {
						MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
						int m = 0;
                        for (int l = 0; l<= ds36.Tables[0].Rows.Count-1;l++)
						{

							if (!(ds36.Tables[0].Rows[l]["totalquotation"] is null))
							{ 
							monthWiseValues[m] = new MonthWiseValues();

                            monthWiseValues[m].Value =Math.Round(Convert.ToDecimal(ds36.Tables[0].Rows[l]["totalquotation"]) / (conv), 2);
                            monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds36.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds36.Tables[0].Rows[l]["year"]).Substring(2) ;
                           m++;
							}
                            
                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthWiseValue = monthWiseValues;
                        

                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection37 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityCount
                DataSet ds37 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection37.Open();
                        new SqlDataAdapter("GetQuoteCountMonthWise", SqlConnection36).Fill(ds37);
                        SqlConnection37.Close();
                    }
                    if (ds37 != null && ds37.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
						int m = 0;
                        for (int l = 0; l <= ds37.Tables[0].Rows.Count - 1; l++)
                        {
							if (!((ds37.Tables[0].Rows[l][2] is null)))
							{
								monthWiseValues[m] = new MonthWiseValues();

								monthWiseValues[m].Value = Convert.ToDecimal(ds37.Tables[0].Rows[l][2]);
								monthWiseValues[m].MMYY =  CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds37.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds37.Tables[0].Rows[l]["year"]).Substring(2) ;
								m++;
							}
                            
                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthWiseCount = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection38 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityValue
                DataSet ds38 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection38.Open();
                        new SqlDataAdapter("GetMonthCumOppurtunityValue", SqlConnection38).Fill(ds38);
                        SqlConnection38.Close();
                    }
                    if (ds38 != null && ds38.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
						int m = 0;
                        for (int l = 0; l <= ds38.Tables[0].Rows.Count - 1; l++)
                        {
							if (!(ds38.Tables[0].Rows[l][2] is null))
							{ 
                            monthWiseValues[l] = new MonthWiseValues();

                            monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds38.Tables[0].Rows[l][2]) / (conv), 2);
                            monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds38.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds38.Tables[0].Rows[l]["year"]).Substring(2) ;
								m++;
                            }
                            
                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthCumValue = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
                SqlConnection SqlConnection39 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityCount
                DataSet ds39 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection39.Open();
                        new SqlDataAdapter("GetMonthCumOppurtunityCount", SqlConnection39).Fill(ds39);
                        SqlConnection39.Close();
                    }
                    if (ds39 != null && ds39.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
						int m = 0;
                        for (int l = 0; l <= ds39.Tables[0].Rows.Count - 1; l++)
                        {

							if (!(ds39.Tables[0].Rows[l][2] is null))
							{ 
                            monthWiseValues[l] = new MonthWiseValues();

                            monthWiseValues[l].Value = Convert.ToDecimal(ds39.Tables[0].Rows[l][2]);
								monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds39.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds39.Tables[0].Rows[l]["year"]).Substring(2);  
								m++;
                            }
						
                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.OppurtunityMonthCumCount = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection40 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastCount
                DataSet ds40 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection40.Open();
                        new SqlDataAdapter("OppurtunityForecastCount", SqlConnection40).Fill(ds40);
                        SqlConnection40.Close();
                    }
                    if (ds40 != null && ds40.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds40.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds40.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Convert.ToDecimal(ds40.Tables[0].Rows[l][2]);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds40.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds40.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.ForecastCount = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection41 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                DataSet ds41 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection41.Open();
                        new SqlDataAdapter("OppurtunityForecast", SqlConnection41).Fill(ds41);
                        SqlConnection40.Close();
                    }
                    if (ds40 != null && ds41.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds41.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds41.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value =Math.Round(Convert.ToDecimal(ds41.Tables[0].Rows[l][2]) / (conv), 2);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds41.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds41.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.ForecastValue = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }

                SqlConnection SqlConnection42 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                DataSet ds42 = new DataSet();
                try
                {
                    using (new SqlConnection())
                    {
                        SqlConnection42.Open();
                        new SqlDataAdapter("visitsAnnualbyMonth", SqlConnection42).Fill(ds42);
                        SqlConnection40.Close();
                    }
                    if (ds40 != null && ds42.Tables[0].Rows.Count > 0)
                    {
                        MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                        int m = 0;
                        for (int l = 0; l <= ds42.Tables[0].Rows.Count - 1; l++)
                        {

                            if (!(ds42.Tables[0].Rows[l][2] is null))
                            {
                                monthWiseValues[l] = new MonthWiseValues();

                                monthWiseValues[l].Value = Convert.ToDecimal(ds42.Tables[0].Rows[l][2]);
                                monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds42.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds42.Tables[0].Rows[l]["year"]).Substring(2);
                                m++;
                            }

                        }
                        Array.Resize(ref monthWiseValues, m);
                        dashboardCustom.AnnualVisitByMonth = monthWiseValues;


                    }
                }
                catch (Exception)
                {
                    obj.response = ResourceResponse.ExceptionMessage;
                    obj.isStatus = false;
                }
            }
			dashboardCustomsList.Add(dashboardCustom);
			obj.isStatus = true;
			obj.response = dashboardCustomsList;
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

	public CommonEntity.CommonResponse GetCPDetailsInDashboardForLeads(string userId)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		CommonFunction commonFunction = new CommonFunction();
		try
		{
			string roleName = commonFunction.GetRoleName(userId);
			Guid userIdGuid = new Guid(userId);
			try
			{
				(from m in db.UserLogins
					where m.UserId == userIdGuid
					select m.Cpid).FirstOrDefault();
			}
			catch (Exception)
			{
			}
			_ = roleName != "Administrator";
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


    public CommonEntity.CommonResponse UpdateCHFValue(decimal CHFValue)  //UpdateCHFValue
    {
        CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
        CommonFunction commonFunction = new CommonFunction();
        try
        {

            CHFValueConvs chf = new CHFValueConvs();
            chf = db.CHFValueConvs.FirstOrDefault();
            //chf.id = 1;
            chf.CurrentCHFValue = CHFValue;

            // db.CHFValueConvs.Add(chf);
            db.SaveChanges();
            obj.response = "Success";
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

	public CommonEntity.CommonResponse GetDashboardFilter(string cpid, string zoneId, string buId, string userId)
	{
        
            CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
            CommonFunction commonFunction = new CommonFunction();
            try
            {
                DateTime.Now.Year.ToString();
                string roleName = commonFunction.GetRoleName(userId);
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

                decimal conv;
               conv = db.CHFValueConvs.FirstOrDefault().CurrentCHFValue * 1000000;
                List<DashboardDEL.DashboardCustom> dashboardCustomsList = new List<DashboardDEL.DashboardCustom>();
                DashboardDEL.DashboardCustom dashboardCustom = new DashboardDEL.DashboardCustom();
                if (roleName != "Administrator")
                {
                    SqlConnection SqlConnection2 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds2 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection2.Open();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetYearWiseCPCounts", SqlConnection2);
                            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
                            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter.Fill(ds2);
                            SqlConnection2.Close();
                        }
                        if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.totalVisitsCount = Convert.ToInt32(ds2.Tables[0].Rows[0]["TotalVisitCount"]);
                        }
                        if (ds2 != null && ds2.Tables[1].Rows.Count > 0)
                        {
                            dashboardCustom.totalQuotationCount = Convert.ToInt32(ds2.Tables[1].Rows[0]["TotalQuotationCount"]);
                        }
                        if (ds2 != null && ds2.Tables[2].Rows.Count > 0)
                        {
                            dashboardCustom.totalLeadsCount = Convert.ToInt32(ds2.Tables[2].Rows[0]["TotalLeadsCount"]);
                        }
                        if (ds2 != null && ds2.Tables[3].Rows.Count > 0)
                        {
                            dashboardCustom.totalOrdersCount = Convert.ToInt32(ds2.Tables[3].Rows[0]["TotalOrderCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection4 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds4 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection4.Open();
                            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("GetMonthWiseVisitCount", SqlConnection4);
                            sqlDataAdapter2.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter2.SelectCommand.Parameters.AddWithValue("@userId", userId);
                            sqlDataAdapter2.Fill(ds4);
                            SqlConnection4.Close();
                        }
                        if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthVisitsCount = Convert.ToInt32(ds4.Tables[0].Rows[0]["monthVisitCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection6 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds6 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection6.Open();
                            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("GetMonthWiseLeadsCount", SqlConnection6);
                            sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter3.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter3.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter3.Fill(ds4);
                            SqlConnection6.Close();
                        }
                        if (ds6 != null && ds6.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthLeadsCount = Convert.ToInt32(ds6.Tables[0].Rows[0]["monthLeadsCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection8 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds8 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection8.Open();
                            SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter("GetMonthWiseQuotationCount", SqlConnection8);
                            sqlDataAdapter4.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter4.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter4.Fill(ds8);
                            SqlConnection8.Close();
                        }
                        if (ds8 != null && ds8.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthQutationCount = Convert.ToInt32(ds8.Tables[0].Rows[0]["monthQuotationCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection10 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds10 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection10.Open();
                            SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("GetMonthWiseOrderCount", SqlConnection10);
                            sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter5.Fill(ds10);
                            SqlConnection10.Close();
                        }
                        if (ds10 != null && ds10.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthOrdersCount = Convert.ToInt32(ds10.Tables[0].Rows[0]["monthOrderCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    //new Dashboard Creation from Digitelligence Technologies pvt ltd 2023
                    SqlConnection SqlConnection20 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds20 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection20.Open();
                            SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter("HotlistOppurtunity", SqlConnection20);
                            sqlDataAdapter13.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter13.Fill(ds20);
                            SqlConnection20.Close();
                        }
                        if (ds20 != null && ds20.Tables[0].Rows.Count > 0)
                        {
                            decimal HotlistOppurtunityCount = 0;
                            for (int l = 0; l < ds20.Tables[0].Rows.Count; l++)
                            {
                                HotlistOppurtunityCount = Math.Round(Convert.ToDecimal(ds20.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                            }
                            dashboardCustom.monthHotlistCount = HotlistOppurtunityCount;
                            // dashboardCustom.monthHotlistCount = Convert.ToInt32(ds20.Tables[0].Rows[0]["totalquotation"]);//HotlistOpportunity//
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection17 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds17 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection17.Open();
                            SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter("LostOederCount", SqlConnection17);
                            sqlDataAdapter14.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter14.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter14.Fill(ds17);
                            SqlConnection17.Close();
                        }
                        if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthOpportunitieslossCount = Convert.ToInt32(ds17.Tables[0].Rows[0]["quoteCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }


                    SqlConnection SqlConnection7 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds7 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection7.Open();
                            SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter("ActiveOppurtunityCount", SqlConnection7);
                            sqlDataAdapter5.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter5.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter5.Fill(ds7);
                            SqlConnection7.Close();
                        }
                        if (ds7 != null && ds7.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthQutationCount = Convert.ToInt32(ds7.Tables[0].Rows[0]["quoteCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection1 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds1 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection1.Open();
                            SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter("ActiveOppurtunityValue", SqlConnection1);
                            sqlDataAdapter9.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@@zoneId", zoneId);
                            sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter9.Fill(ds1);
                            SqlConnection1.Close();
                        }
                        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                        {
                            decimal monthActiveOpportunitiesCount = 0;
                            for (int l = 0; l < ds1.Tables[0].Rows.Count; l++)
                            {
                                monthActiveOpportunitiesCount = Math.Round(Convert.ToDecimal(ds1.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                        }
                            dashboardCustom.activeopportunity = monthActiveOpportunitiesCount;
                            // dashboardCustom.monthActiveOpportunitiesCount = Convert.ToInt32(ds1.Tables[0].Rows[0]["totalOpportunity"]);

                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection36 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityValue
                    DataSet ds36 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection36.Open();
                            SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter("GetMonthWiseOppurtunityValue", SqlConnection36);
                            sqlDataAdapter10.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter10.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter10.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter10.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter10.Fill(ds36);
                            SqlConnection36.Close();
                        }
                        if (ds36 != null && ds36.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds36.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds36.Tables[0].Rows[l]["totalquotation"] is null))
                                {
                                    monthWiseValues[m] = new MonthWiseValues();

                                    monthWiseValues[m].Value = Math.Round(Convert.ToDecimal(ds36.Tables[0].Rows[l]["totalquotation"]) / (conv), 2);
                            monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds36.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds36.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthWiseValue = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection37 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityCount
                    DataSet ds37 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection37.Open();
                            SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetQuoteCountMonthWise", SqlConnection37);
                            sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter7.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter7.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter7.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter7.Fill(ds37);
                            SqlConnection37.Close();
                        }
                        if (ds37 != null && ds37.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds37.Tables[0].Rows.Count - 1; l++)
                            {
                                if (!((ds37.Tables[0].Rows[l][2] is null)))
                                {
                                    monthWiseValues[m] = new MonthWiseValues();

                                    monthWiseValues[m].Value = Convert.ToDecimal(ds37.Tables[0].Rows[l][2]);
                                    monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds37.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds37.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthWiseCount = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection38 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityValue
                    DataSet ds38 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection38.Open();
                            SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter("GetMonthCumOppurtunityValue", SqlConnection38);
                            sqlDataAdapter8.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter8.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter8.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter8.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter8.Fill(ds38);
                            SqlConnection38.Close();
                        }
                        if (ds38 != null && ds38.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds38.Tables[0].Rows.Count - 1; l++)
                            {
                                if (!(ds38.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds38.Tables[0].Rows[l][2]) / (conv), 2);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds38.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds38.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthCumValue = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection39 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityCount
                    DataSet ds39 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection39.Open();
                            SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter("GetMonthCumOppurtunityCount", SqlConnection39);
                            sqlDataAdapter9.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter9.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter9.Fill(ds39);
                            SqlConnection39.Close();
                        }
                        if (ds39 != null && ds39.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds39.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds39.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Convert.ToDecimal(ds39.Tables[0].Rows[l][2]);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds39.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds39.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthCumCount = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection40 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastCount
                    DataSet ds40 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection40.Open();
                            SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter("OppurtunityForecastCount", SqlConnection40);
                            sqlDataAdapter11.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter11.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter11.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter11.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter11.Fill(ds40);
                            SqlConnection40.Close();
                        }
                        if (ds40 != null && ds40.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds40.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds40.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Convert.ToDecimal(ds40.Tables[0].Rows[l][2]);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds40.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds40.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.ForecastCount = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection31 = new SqlConnection(appSettings.DefaultConnection);  //GetOppurtunity Pipeline
                    DataSet ds31 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection31.Open();
                            SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter("OppurtunityPipeline", SqlConnection31);
                            sqlDataAdapter13.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter13.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter13.Fill(ds31);
                            SqlConnection31.Close();
                        }
                        if (ds31 != null && ds31.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[3];
                            int HL = 0;
                            for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                            {

                                HL = HL + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);

                            }

                            for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                            {

                                switch (ds31.Tables[0].Rows[l]["BYJTChances"])
                                {
                                    case > 60:

                                        monthWiseValues[2] = new MonthWiseValues();
                                        monthWiseValues[2].Value = monthWiseValues[2].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                        monthWiseValues[2].MMYY = "Hotlist";
                                        break;
                                    case > 40 and < 61:
                                        monthWiseValues[1] = new MonthWiseValues();
                                        monthWiseValues[1].Value = monthWiseValues[1].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                        monthWiseValues[1].MMYY = "Potential";
                                        break;
                                    default:
                                        monthWiseValues[0] = new MonthWiseValues();
                                        monthWiseValues[0].Value = monthWiseValues[0].Value + Convert.ToInt32(Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]));
                                        monthWiseValues[0].MMYY = "Pipeline";
                                        break;


                                }

                            }

                            dashboardCustom.OppurtunityPipeline = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection41 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                    DataSet ds41 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection41.Open();
                            SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter("OppurtunityForecast", SqlConnection41);
                            sqlDataAdapter12.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter12.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter12.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                            sqlDataAdapter12.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                            sqlDataAdapter12.Fill(ds41);
                            SqlConnection41.Close();
                        }
                        if (ds41 != null && ds41.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds41.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds41.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds41.Tables[0].Rows[l][2]) / (conv), 2);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds41.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds41.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.ForecastValue = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }


                    SqlConnection SqlConnection12 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds12 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection12.Open();
                            SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter("GetMonthWiseCPAllCounts", SqlConnection12);
                            sqlDataAdapter6.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter6.SelectCommand.Parameters.AddWithValue("@userId", userId);
                            sqlDataAdapter6.SelectCommand.Parameters.AddWithValue("@cpId", cpId);
                            sqlDataAdapter6.Fill(ds12);
                            SqlConnection12.Close();
                        }
                        if (ds12 != null && ds12.Tables[0].Rows.Count > 0)
                        {
                            int[] visitMonthWiseCount2 = new int[12];
                            for (int i4 = 0; i4 < ds12.Tables[0].Rows.Count; i4++)
                            {
                                switch (Convert.ToInt32(ds12.Tables[0].Rows[i4]["month"]))
                                {
                                    case 1:
                                        visitMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 2:
                                        visitMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 3:
                                        visitMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 4:
                                        visitMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 5:
                                        visitMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 6:
                                        visitMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 7:
                                        visitMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 8:
                                        visitMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 9:
                                        visitMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 10:
                                        visitMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 11:
                                        visitMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                    case 12:
                                        visitMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[0].Rows[i4]["totalVisit"]);
                                        break;
                                }
                                dashboardCustom.visitMonthWiseCount = visitMonthWiseCount2;
                            }
                        }
                        if (ds12 != null && ds12.Tables[1].Rows.Count > 0)
                        {
                            int[] leadsMonthWiseCount2 = new int[12];
                            for (int i3 = 0; i3 < ds12.Tables[1].Rows.Count; i3++)
                            {
                                switch (Convert.ToInt32(ds12.Tables[1].Rows[i3]["month"]))
                                {
                                    case 1:
                                        leadsMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 2:
                                        leadsMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 3:
                                        leadsMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 4:
                                        leadsMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 5:
                                        leadsMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 6:
                                        leadsMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 7:
                                        leadsMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 8:
                                        leadsMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 9:
                                        leadsMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 10:
                                        leadsMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 11:
                                        leadsMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                    case 12:
                                        leadsMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[1].Rows[i3]["totalLeads"]);
                                        break;
                                }
                                dashboardCustom.leadsMonthWiseCount = leadsMonthWiseCount2;
                            }
                        }
                        if (ds12 != null && ds12.Tables[2].Rows.Count > 0)
                        {
                            int[] quotationMonthWiseCount2 = new int[12];
                            for (int i2 = 0; i2 < ds12.Tables[2].Rows.Count; i2++)
                            {
                                switch (Convert.ToInt32(ds12.Tables[2].Rows[i2]["month"]))
                                {
                                    case 1:
                                        quotationMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 2:
                                        quotationMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 3:
                                        quotationMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 4:
                                        quotationMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 5:
                                        quotationMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 6:
                                        quotationMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 7:
                                        quotationMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 8:
                                        quotationMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 9:
                                        quotationMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 10:
                                        quotationMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 11:
                                        quotationMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                    case 12:
                                        quotationMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[2].Rows[i2]["totalquotation"]);
                                        break;
                                }
                                dashboardCustom.quotationMonthWiseCount = quotationMonthWiseCount2;
                            }
                        }
                        if (ds12 != null && ds12.Tables[3].Rows.Count > 0)
                        {
                            int[] orderMonthWiseCount2 = new int[12];
                            for (int n = 0; n < ds12.Tables[0].Rows.Count; n++)
                            {
                                switch (Convert.ToInt32(ds12.Tables[3].Rows[n]["month"]))
                                {
                                    case 1:
                                        orderMonthWiseCount2[0] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 2:
                                        orderMonthWiseCount2[1] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 3:
                                        orderMonthWiseCount2[2] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 4:
                                        orderMonthWiseCount2[3] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 5:
                                        orderMonthWiseCount2[4] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 6:
                                        orderMonthWiseCount2[5] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 7:
                                        orderMonthWiseCount2[6] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 8:
                                        orderMonthWiseCount2[7] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 9:
                                        orderMonthWiseCount2[8] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 10:
                                        orderMonthWiseCount2[9] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 11:
                                        orderMonthWiseCount2[10] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                    case 12:
                                        orderMonthWiseCount2[11] = Convert.ToInt32(ds12.Tables[3].Rows[n]["totalOrder"]);
                                        break;
                                }
                                dashboardCustom.orderMonthWiseCount = orderMonthWiseCount2;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                }
                else
                {
                    SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection.Open();
                            new SqlDataAdapter("GetYearWiseAllCounts", SqlConnection).Fill(ds);
                            SqlConnection.Close();
                        }
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.totalVisitsCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalVisitCount"]);
                        }
                        if (ds != null && ds.Tables[1].Rows.Count > 0)
                        {
                            dashboardCustom.totalQuotationCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalQuotationCount"]);
                        }
                        if (ds != null && ds.Tables[2].Rows.Count > 0)
                        {
                            dashboardCustom.totalLeadsCount = Convert.ToInt32(ds.Tables[2].Rows[0]["TotalLeadsCount"]);
                        }
                        if (ds != null && ds.Tables[3].Rows.Count > 0)
                        {
                            dashboardCustom.totalOrdersCount = Convert.ToInt32(ds.Tables[3].Rows[0]["TotalOrderCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection3 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds3 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection3.Open();
                            new SqlDataAdapter("GetMonthWiseVisitCount", SqlConnection3).Fill(ds3);
                            SqlConnection3.Close();
                        }
                        if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthVisitsCount = Convert.ToInt32(ds3.Tables[0].Rows[0]["monthVisitCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection5 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds5 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection5.Open();
                            SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter("GetMonthWiseLeadsCount", SqlConnection5);
                            sqlDataAdapter7.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sqlDataAdapter7.Fill(ds5);
                            SqlConnection5.Close();
                        }
                        if (ds5 != null && ds5.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthLeadsCount = Convert.ToInt32(ds5.Tables[0].Rows[0]["monthLeadsCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection7 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds7 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection7.Open();
                            new SqlDataAdapter("ActiveOppurtunityCount", SqlConnection7).Fill(ds7);//count of active opportunity//
                            SqlConnection7.Close();
                        }
                        if (ds7 != null && ds7.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthQutationCount = Convert.ToInt32(ds7.Tables[0].Rows[0]["quoteCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection26 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds26 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection26.Open();
                            new SqlDataAdapter("OpportunitiesOB", SqlConnection26).Fill(ds26);//opportunities to ob
                            SqlConnection26.Close();
                        }
                        if (ds26 != null && ds26.Tables[0].Rows.Count > 0)
                        {

                            dashboardCustom.totalOpportunitiesOBCount = Convert.ToInt32(ds26.Tables[0].Rows[0]["totalorderCoverted"]);
                        }
                        if (ds26 != null && ds26.Tables[0].Rows.Count > 0)
                        {

                            dashboardCustom.monthOpportunitiesOBCount = Convert.ToInt32(ds26.Tables[0].Rows[0]["ConvertedPrice"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }


                    SqlConnection SqlConnection9 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds9 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection9.Open();
                            new SqlDataAdapter("GetMonthWiseOrderCount", SqlConnection9).Fill(ds9);
                            SqlConnection9.Close();
                        }
                        if (ds9 != null && ds9.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthOrdersCount = Convert.ToInt32(ds9.Tables[0].Rows[0]["monthOrderCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }



                    SqlConnection SqlConnection11 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds11 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection11.Open();
                            new SqlDataAdapter("GetMonthWiseAllCounts", SqlConnection11).Fill(ds11);
                            SqlConnection11.Close();
                        }
                        if (ds11 != null && ds11.Tables[0].Rows.Count > 0)
                        {
                            int[] visitMonthWiseCount = new int[12];
                            for (int l = 0; l < ds11.Tables[0].Rows.Count; l++)
                            {
                                switch (Convert.ToInt32(ds11.Tables[0].Rows[l]["month"]))
                                {
                                    case 1:
                                        visitMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 2:
                                        visitMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 3:
                                        visitMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 4:
                                        visitMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 5:
                                        visitMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 6:
                                        visitMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 7:
                                        visitMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 8:
                                        visitMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 9:
                                        visitMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 10:
                                        visitMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 11:
                                        visitMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                    case 12:
                                        visitMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[0].Rows[l]["totalVisit"]);
                                        break;
                                }
                                dashboardCustom.visitMonthWiseCount = visitMonthWiseCount;
                            }
                        }
                        if (ds11 != null && ds11.Tables[1].Rows.Count > 0)
                        {
                            int[] leadsMonthWiseCount = new int[12];
                            for (int k = 0; k < ds11.Tables[1].Rows.Count; k++)
                            {
                                switch (Convert.ToInt32(ds11.Tables[1].Rows[k]["month"]))
                                {
                                    case 1:
                                        leadsMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 2:
                                        leadsMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 3:
                                        leadsMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 4:
                                        leadsMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 5:
                                        leadsMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 6:
                                        leadsMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 7:
                                        leadsMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 8:
                                        leadsMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 9:
                                        leadsMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 10:
                                        leadsMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 11:
                                        leadsMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                    case 12:
                                        leadsMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[1].Rows[k]["totalLeads"]);
                                        break;
                                }
                                dashboardCustom.leadsMonthWiseCount = leadsMonthWiseCount;
                            }
                        }
                        if (ds11 != null && ds11.Tables[2].Rows.Count > 0)
                        {
                            int[] quotationMonthWiseCount = new int[12];
                            for (int j = 0; j < ds11.Tables[2].Rows.Count; j++)
                            {
                                switch (Convert.ToInt32(ds11.Tables[2].Rows[j]["month"]))
                                {
                                    case 1:
                                        quotationMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 2:
                                        quotationMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 3:
                                        quotationMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 4:
                                        quotationMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 5:
                                        quotationMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 6:
                                        quotationMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 7:
                                        quotationMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 8:
                                        quotationMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 9:
                                        quotationMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 10:
                                        quotationMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 11:
                                        quotationMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                    case 12:
                                        quotationMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[2].Rows[j]["totalquotation"]);
                                        break;
                                }
                                dashboardCustom.quotationMonthWiseCount = quotationMonthWiseCount;
                            }
                        }
                        if (ds11 != null && ds11.Tables[3].Rows.Count > 0)
                        {
                            int[] orderMonthWiseCount = new int[12];
                            for (int i = 0; i < ds11.Tables[0].Rows.Count; i++)
                            {
                                switch (Convert.ToInt32(ds11.Tables[3].Rows[i]["month"]))
                                {
                                    case 1:
                                        orderMonthWiseCount[0] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 2:
                                        orderMonthWiseCount[1] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 3:
                                        orderMonthWiseCount[2] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 4:
                                        orderMonthWiseCount[3] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 5:
                                        orderMonthWiseCount[4] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 6:
                                        orderMonthWiseCount[5] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 7:
                                        orderMonthWiseCount[6] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 8:
                                        orderMonthWiseCount[7] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 9:
                                        orderMonthWiseCount[8] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 10:
                                        orderMonthWiseCount[9] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 11:
                                        orderMonthWiseCount[10] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                    case 12:
                                        orderMonthWiseCount[11] = Convert.ToInt32(ds11.Tables[3].Rows[i]["totalOrder"]);
                                        break;
                                }
                                dashboardCustom.orderMonthWiseCount = orderMonthWiseCount;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }


                    //New Dashboard Data Created 28-05-2023 Digitelligence


                    SqlConnection SqlConnection35 = new SqlConnection(appSettings.DefaultConnection);  //ZoneWiseOppurtunities
                    DataSet ds35 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection35.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ZoneWiseOppurtunities", SqlConnection35) ;
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds35);
                        SqlConnection35.Close();
                        SqlConnection35.Close();
                        }
                        if (ds35 != null && ds35.Tables[0].Rows.Count > 0)
                        {
                            decimal TotalZoneQuote = 0;
                            for (int l = 0; l < ds35.Tables[0].Rows.Count; l++)
                            {
                                TotalZoneQuote += Convert.ToDecimal(ds35.Tables[0].Rows[l]["totalquotation"]);

                            }
                            decimal[] ZonePcnt = new decimal[7];
                            for (int l = 0; l < ds35.Tables[0].Rows.Count; l++)
                            {
                                ZonePcnt[l] = (Convert.ToDecimal(ds35.Tables[0].Rows[l]["totalquotation"]) / TotalZoneQuote) * 100;

                            }

                            dashboardCustom.QuoteZonwise = ZonePcnt;

                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection31 = new SqlConnection(appSettings.DefaultConnection);  //GetOppurtunity Pipeline
                    DataSet ds31 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection31.Open();
                        SqlDataAdapter sqlDataAdapter  =  new SqlDataAdapter("OppurtunityPipeline", SqlConnection31);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds31);


                        SqlConnection31.Close();
                        }
                        if (ds31 != null && ds31.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[3];
                            int HL = 0;
                            for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                            {

                                HL = HL + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);

                            }

                            for (int l = 0; l <= ds31.Tables[0].Rows.Count - 1; l++)
                            {

                                switch (ds31.Tables[0].Rows[l]["BYJTChances"])
                                {
                                    case > 60:

                                        monthWiseValues[2] = new MonthWiseValues();
                                        monthWiseValues[2].Value = monthWiseValues[2].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                        monthWiseValues[2].MMYY = "Hotlist";
                                        break;
                                    case > 40 and < 61:
                                        monthWiseValues[1] = new MonthWiseValues();
                                        monthWiseValues[1].Value = monthWiseValues[1].Value + Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]);
                                        monthWiseValues[1].MMYY = "Potential";
                                        break;
                                    default:
                                        monthWiseValues[0] = new MonthWiseValues();
                                        monthWiseValues[0].Value = monthWiseValues[0].Value + Convert.ToInt32(Convert.ToInt32(ds31.Tables[0].Rows[l]["QuoteChanceCount"]));
                                        monthWiseValues[0].MMYY = "Pipeline";
                                        break;


                                }

                            }

                            dashboardCustom.OppurtunityPipeline = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }


                    SqlConnection SqlConnection20 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds20 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection20.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("HotlistOppurtunity", SqlConnection20);//hotlist opportunity
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds20);
                        SqlConnection20.Close();
                        }
                        if (ds20 != null && ds20.Tables[0].Rows.Count > 0)
                        {
                            decimal HotlistOppurtunityCount = 0;
                            for (int l = 0; l < ds20.Tables[0].Rows.Count; l++)
                            {
                                HotlistOppurtunityCount = Math.Round(Convert.ToDecimal(ds20.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                            }
                            dashboardCustom.monthHotlistCount = HotlistOppurtunityCount;
                            // dashboardCustom.monthHotlistCount = Convert.ToInt32(ds20.Tables[0].Rows[0]["totalquotation"]);//HotlistOpportunity//
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection1 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds1 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection1.Open();
                        //int conv = 2130;
                        // decimal result = db.CHFValueConvs.FirstOrDefault().CurrentCHFValue / 100m;
                        // string formatted = result.ToString("c");


                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ActiveOppurtunityValue", SqlConnection1);//ActiveOpportunity in CHF
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds1);

                        SqlConnection1.Close();
                        }
                        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                        {
                            decimal monthActiveOpportunitiesCount = 0;
                            for (int l = 0; l < ds1.Tables[0].Rows.Count; l++)
                            {
                                monthActiveOpportunitiesCount = Math.Round(Convert.ToDecimal(ds1.Tables[0].Rows[0]["totalquotation"]) / (conv), 2);

                            }
                            dashboardCustom.activeopportunity = monthActiveOpportunitiesCount;
                            // dashboardCustom.monthActiveOpportunitiesCount = Convert.ToInt32(ds1.Tables[0].Rows[0]["totalOpportunity"]);

                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection17 = new SqlConnection(appSettings.DefaultConnection);
                    DataSet ds17 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection17.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("LostOederCount", SqlConnection17);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds17);
                        SqlConnection17.Close();
                        }
                        if (ds17 != null && ds17.Tables[0].Rows.Count > 0)
                        {
                            dashboardCustom.monthOpportunitieslossCount = Convert.ToInt32(ds17.Tables[0].Rows[0]["quoteCount"]);
                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection36 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityValue
                    DataSet ds36 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection36.Open();
                        SqlDataAdapter sqlDataAdapter =  new SqlDataAdapter("GetMonthWiseOppurtunityValue", SqlConnection36);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds36);
                        SqlConnection36.Close();
                        }
                        if (ds36 != null && ds36.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds36.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds36.Tables[0].Rows[l]["totalquotation"] is null))
                                {
                                    monthWiseValues[m] = new MonthWiseValues();

                                    monthWiseValues[m].Value = Math.Round(Convert.ToDecimal(ds36.Tables[0].Rows[l]["totalquotation"]) / (conv), 2);
                                    monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds36.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds36.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthWiseValue = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection37 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseOppurtunityCount
                    DataSet ds37 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection37.Open();
                        SqlDataAdapter sqlDataAdapter =  new SqlDataAdapter("GetQuoteCountMonthWise", SqlConnection37);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds37);
                        SqlConnection37.Close();
                        }
                        if (ds37 != null && ds37.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds37.Tables[0].Rows.Count - 1; l++)
                            {
                                if (!((ds37.Tables[0].Rows[l][2] is null)))
                                {
                                    monthWiseValues[m] = new MonthWiseValues();

                                    monthWiseValues[m].Value = Convert.ToDecimal(ds37.Tables[0].Rows[l][2]);
                                    monthWiseValues[m].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds37.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds37.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthWiseCount = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection38 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityValue
                    DataSet ds38 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection38.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetMonthCumOppurtunityValue", SqlConnection38);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds38);
                        SqlConnection38.Close();
                        }
                        if (ds38 != null && ds38.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds38.Tables[0].Rows.Count - 1; l++)
                            {
                                if (!(ds38.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds38.Tables[0].Rows[l][2]) / (conv), 2);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds38.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds38.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthCumValue = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                    SqlConnection SqlConnection39 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseCumulitiveOppurtunityCount
                    DataSet ds39 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection39.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetMonthCumOppurtunityCount", SqlConnection39);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds39);
                        SqlConnection39.Close();
                        }
                        if (ds39 != null && ds39.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds39.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds39.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Convert.ToDecimal(ds39.Tables[0].Rows[l][2]);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds39.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds39.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.OppurtunityMonthCumCount = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection40 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastCount
                    DataSet ds40 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection40.Open();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("OppurtunityForecastCount", SqlConnection40);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds40);
                        SqlConnection40.Close();
                        }
                        if (ds40 != null && ds40.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds40.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds40.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Convert.ToDecimal(ds40.Tables[0].Rows[l][2]);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds40.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds40.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.ForecastCount = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection41 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                    DataSet ds41 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection41.Open();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("OppurtunityForecast", SqlConnection41);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds41);
                        SqlConnection40.Close();
                        }
                        if (ds40 != null && ds41.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds41.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds41.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Math.Round(Convert.ToDecimal(ds41.Tables[0].Rows[l][2]) / (conv), 2);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds41.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds41.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.ForecastValue = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }

                    SqlConnection SqlConnection42 = new SqlConnection(appSettings.DefaultConnection);  //GetMonthWiseForecastValue
                    DataSet ds42 = new DataSet();
                    try
                    {
                        using (new SqlConnection())
                        {
                            SqlConnection42.Open();
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("visitsAnnualbyMonth", SqlConnection42);
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@zoneId", zoneId);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", cpid);
                        sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@buId ", buId);
                        sqlDataAdapter.Fill(ds42);
                        SqlConnection40.Close();
                        }
                        if (ds40 != null && ds42.Tables[0].Rows.Count > 0)
                        {
                            MonthWiseValues[] monthWiseValues = new MonthWiseValues[12];
                            int m = 0;
                            for (int l = 0; l <= ds42.Tables[0].Rows.Count - 1; l++)
                            {

                                if (!(ds42.Tables[0].Rows[l][2] is null))
                                {
                                    monthWiseValues[l] = new MonthWiseValues();

                                    monthWiseValues[l].Value = Convert.ToDecimal(ds42.Tables[0].Rows[l][2]);
                                    monthWiseValues[l].MMYY = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(ds42.Tables[0].Rows[l]["month"])) + " " + Convert.ToString(ds42.Tables[0].Rows[l]["year"]).Substring(2);
                                    m++;
                                }

                            }
                            Array.Resize(ref monthWiseValues, m);
                            dashboardCustom.AnnualVisitByMonth = monthWiseValues;


                        }
                    }
                    catch (Exception)
                    {
                        obj.response = ResourceResponse.ExceptionMessage;
                        obj.isStatus = false;
                    }
                }
                dashboardCustomsList.Add(dashboardCustom);
                obj.isStatus = true;
                obj.response = dashboardCustomsList;
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

      





