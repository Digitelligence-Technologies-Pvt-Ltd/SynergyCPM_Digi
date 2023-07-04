using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using log4net;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.BLL;

public class ReportBLL : IReport
{
	private readonly AppSettings appSettings;

	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(MDBMasterBLL));

	public ReportBLL(IOptions<AppSettings> _appSettings, SRKSSynergyContext _db)
	{
		appSettings = _appSettings.Value;
		db = _db;
	}

	public CommonEntity.CommonResponse GetAllStoreProcedures()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		SqlConnection sqlConnection = new SqlConnection(appSettings.DefaultConnection);
		try
		{
			DataSet ds = new DataSet();
			SqlCommand sqlCommand = new SqlCommand("GetAllSP", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			new SqlDataAdapter(sqlCommand).Fill(ds);
			List<ReportEntity.TableElements> tableElementsList = new List<ReportEntity.TableElements>();
			if (ds != null && ds.Tables.Count > 0)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						ReportEntity.TableElements tableElements = new ReportEntity.TableElements();
						string storeProcedureName = (tableElements.storeProcedureName = ds.Tables[0].Rows[i]["COLUMN_NAME"].ToString());
						tableElementsList.Add(tableElements);
					}
				}
				obj.response = tableElementsList;
				obj.isStatus = true;
				return obj;
			}
			obj.response = ResourceResponse.NoItemsFound;
			obj.isStatus = false;
			return obj;
		}
		catch (Exception)
		{
			obj.response = ResourceResponse.ExceptionMessage;
			obj.isStatus = false;
			return obj;
		}
	}

	public CommonEntity.CommonResponse GenerateReport(ReportEntity.ReportEngineMaster data)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			DateTime? fromDate = DateTime.Now;
			if (data.fromDate == " " || data.fromDate == null)
			{
				fromDate = null;
			}
			else
			{
				try
				{
					string[] dt = data.fromDate.Split(new char[1] { '/' });
					string frDate = dt[2] + "-" + dt[1] + "-" + dt[0];
					fromDate = Convert.ToDateTime(frDate);
				}
				catch
				{
					fromDate = Convert.ToDateTime(data.fromDate);
				}
			}
			DateTime? toDate = DateTime.Now;
			if (data.toDate == " " || data.toDate == null)
			{
				toDate = null;
			}
			else
			{
				try
				{
					string[] dt2 = data.toDate.Split(new char[1] { '/' });
					string torDate = dt2[2] + "-" + dt2[1] + "-" + dt2[0];
					toDate = Convert.ToDateTime(torDate);
				}
				catch
				{
					toDate = Convert.ToDateTime(data.toDate);
				}
			}
			if (data.fromDate != null)
			{
				_ = data.toDate;
			}
			string fileName = (from m in db.StoredProceduresMaster
				where m.IsDeleted == (bool?)false
				select m.StoredProcedureRefName).FirstOrDefault();
			ExcelWorksheet Templatews = new ExcelPackage(new FileInfo("C:\\Templates\\CommonTemplate.xlsx")).Workbook.Worksheets[0];
			string imageUrlSave = appSettings.ImageUrlSave;
			string ImageUrl = appSettings.ImageUrl;
			string FileDir = imageUrlSave + "\\VisitReport_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
			string retrivalPath = ImageUrl + "VisitReport_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
			FileInfo newFile = new FileInfo(FileDir);
			if (newFile.Exists)
			{
				try
				{
					newFile.Delete();
					newFile = new FileInfo(FileDir);
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
				}
			}
			ExcelPackage p = null;
			p = new ExcelPackage(newFile);
			ExcelWorksheet worksheet = null;
			try
			{
				worksheet = p.Workbook.Worksheets.Add(DateTime.Now.ToString("yyyy-MM-dd"), Templatews);
			}
			catch
			{
			}
			if (worksheet == null)
			{
				worksheet = p.Workbook.Worksheets.Add(DateTime.Now.ToString("yyyy-MM-dd") + "1", Templatews);
			}
			int sheetcount = p.Workbook.Worksheets.Count;
			p.Workbook.Worksheets.MoveToStart(sheetcount - 1);
			worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
			SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
			DataSet ds = new DataSet();
			try
			{
				using (new SqlConnection())
				{
					SqlConnection.Open();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(fileName, SqlConnection);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@visitPurpose", data.visitPurpose);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@visitType", data.visitType);
					sqlDataAdapter.Fill(ds);
					SqlConnection.Close();
				}
				int StartRow = 2;
				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						if (ds.Tables[0].Rows[i]["CPName"] != DBNull.Value)
						{
							worksheet.Cells["A" + StartRow].Value = ds.Tables[0].Rows[i]["CPName"].ToString();
						}
						if (ds.Tables[0].Rows[i]["OrganizationName"] != DBNull.Value)
						{
							worksheet.Cells["B" + StartRow].Value = ds.Tables[0].Rows[i]["OrganizationName"].ToString();
						}
						if (ds.Tables[0].Rows[i]["CompanyUniqueID"] != DBNull.Value)
						{
							worksheet.Cells["C" + StartRow].Value = ds.Tables[0].Rows[i]["CompanyUniqueID"].ToString();
						}
						if (ds.Tables[0].Rows[i]["City"] != DBNull.Value)
						{
							worksheet.Cells["D" + StartRow].Value = ds.Tables[0].Rows[i]["City"].ToString();
						}
						if (ds.Tables[0].Rows[i]["State"] != DBNull.Value)
						{
							string value = ds.Tables[0].Rows[i]["State"].ToString();
							if (value.All(char.IsDigit))
							{
								string stateName = (from m in db.StatesTbl
									where m.StateId == Convert.ToInt32(value)
									select m.State).FirstOrDefault();
								worksheet.Cells["E" + StartRow].Value = stateName;
							}
							else
							{
								worksheet.Cells["E" + StartRow].Value = value;
							}
						}
						if (ds.Tables[0].Rows[i]["visitPurpose"] != DBNull.Value)
						{
							worksheet.Cells["F" + StartRow].Value = ds.Tables[0].Rows[i]["visitPurpose"].ToString();
						}
						if (ds.Tables[0].Rows[i]["createdOn"] != DBNull.Value)
						{
							string createdOn1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["createdOn"]).ToString("dd-MM-yyyy");
							worksheet.Cells["G" + StartRow].Value = createdOn1;
						}
						if (ds.Tables[0].Rows[i]["nextVisitDate"] != DBNull.Value)
						{
							string nextVisitDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["nextVisitDate"]).ToString("dd-MM-yyyy");
							worksheet.Cells["H" + StartRow].Value = nextVisitDate;
						}
						if (ds.Tables[0].Rows[i]["visitStatus"] != DBNull.Value)
						{
							worksheet.Cells["I" + StartRow].Value = ds.Tables[0].Rows[i]["visitStatus"].ToString();
						}
						if (ds.Tables[0].Rows[i]["comments"] != DBNull.Value)
						{
							worksheet.Cells["J" + StartRow].Value = ds.Tables[0].Rows[i]["comments"].ToString();
						}
						if (ds.Tables[0].Rows[i]["productModelId"] != DBNull.Value)
						{
							string prodectModelIds = ds.Tables[0].Rows[i]["productModelId"].ToString();
							string productDescription = "";
							if (prodectModelIds != "")
							{
								string[] array = prodectModelIds.Split(new char[1] { ',' });
								List<string> productDescList = new List<string>();
								string[] array2 = array;
								foreach (string item2 in array2)
								{
									string productDesc = (from m in db.ProductModel
										where m.ProductModelId == Convert.ToInt32(item2)
										select m.ProductModelName).FirstOrDefault();
									productDescList.Add(productDesc);
								}
								productDescription = string.Join(",", productDescList);
							}
							worksheet.Cells["K" + StartRow].Value = productDescription;
						}
						if (ds.Tables[0].Rows[i]["visitDateTime"] != DBNull.Value)
						{
							string visitDateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["visitDateTime"]).ToString("dd-MM-yyyy");
							worksheet.Cells["L" + StartRow].Value = visitDateTime;
							
						}
						if (ds.Tables[0].Rows[i]["visitType"] != DBNull.Value)
						{
							string visitType = ds.Tables[0].Rows[i]["visitType"].ToString();
							if (visitType != null || visitType != "")
							{
								worksheet.Cells["M" + StartRow].Value = ds.Tables[0].Rows[i]["visitType"].ToString();
							}
						}
						if (ds.Tables[0].Rows[i]["buId"] != DBNull.Value)
						{
							string buIds = ds.Tables[0].Rows[i]["buId"].ToString();
							string buNames = "";
							if (buIds != "")
							{
								string[] array3 = buIds.Split(new char[1] { ',' });
								List<string> buNameList = new List<string>();
								string[] array2 = array3;
								foreach (string item in array2)
								{
									string buName = (from m in db.BusinessUnit
										where m.BuId == Convert.ToInt32(item)
										select m.BuName).FirstOrDefault();
									buNameList.Add(buName);
								}
								buNames = string.Join(",", buNameList);
							}
							worksheet.Cells["N" + StartRow].Value = buNames;
						}
						if (ds.Tables[0].Rows[i]["name"] != DBNull.Value)
						{
							worksheet.Cells["O" + StartRow].Value = ds.Tables[0].Rows[i]["name"].ToString();
						}
						StartRow++;
					}
				}
				p.Save();
				obj.isStatus = true;
				obj.response = retrivalPath;
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

	public CommonEntity.CommonResponse MDBReport(ReportEntity.MdbReportCustom data)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			DateTime? fromDate = DateTime.Now;
			if (data.fromDate == " " || data.fromDate == null)
			{
				fromDate = null;
			}
			else
			{
				try
				{
					string[] dt = data.fromDate.Split(new char[1] { '/' });
					string frDate = dt[2] + "-" + dt[1] + "-" + dt[0];
					fromDate = Convert.ToDateTime(frDate);
				}
				catch
				{
					fromDate = Convert.ToDateTime(data.fromDate);
				}
			}
			DateTime? toDate = DateTime.Now;
			if (data.toDate == " " || data.toDate == null)
			{
				toDate = null;
			}
			else
			{
				try
				{
					string[] dt2 = data.toDate.Split(new char[1] { '/' });
					string torDate = dt2[2] + "-" + dt2[1] + "-" + dt2[0];
					toDate = Convert.ToDateTime(torDate);
				}
				catch
				{
					toDate = Convert.ToDateTime(data.toDate);
				}
			}
			if (data.fromDate != null)
			{
				_ = data.toDate;
			}
			ExcelWorksheet Templatews = new ExcelPackage(new FileInfo("C:\\Templates\\MDBReportTemplate.xlsx")).Workbook.Worksheets[0];
			string imageUrlSave = appSettings.ImageUrlSave;
			string ImageUrl = appSettings.ImageUrl;
			string FileDir = imageUrlSave + "\\MDBReport_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
			string retrivalPath = ImageUrl + "MDBReport_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
			FileInfo newFile = new FileInfo(FileDir);
			if (newFile.Exists)
			{
				try
				{
					newFile.Delete();
					newFile = new FileInfo(FileDir);
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
				}
			}
			ExcelPackage p = null;
			p = new ExcelPackage(newFile);
			ExcelWorksheet worksheet = null;
			try
			{
				worksheet = p.Workbook.Worksheets.Add(DateTime.Now.ToString("dd-MM-yyyy"), Templatews);
			}
			catch
			{
			}
			if (worksheet == null)
			{
				worksheet = p.Workbook.Worksheets.Add(DateTime.Now.ToString("dd-MM-yyyy") + "1", Templatews);
			}
			int sheetcount = p.Workbook.Worksheets.Count;
			p.Workbook.Worksheets.MoveToStart(sheetcount - 1);
			worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
			SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
			DataSet ds = new DataSet();
			try
			{
				using (new SqlConnection())
				{
					SqlConnection.Open();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("MDBReport", SqlConnection);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
					sqlDataAdapter.Fill(ds);
					SqlConnection.Close();
				}
				int StartRow = 2;
				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						if (ds.Tables[0].Rows[i]["OrganizationName"] != DBNull.Value)
						{
							worksheet.Cells["A" + StartRow].Value = ds.Tables[0].Rows[i]["OrganizationName"].ToString();
						}
						if (ds.Tables[0].Rows[i]["CreatedOn"] != DBNull.Value)
						{
							string createdOn1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]).ToString("dd-MM-yyyy");
							worksheet.Cells["B" + StartRow].Formula = createdOn1;
							worksheet.Cells["B" + StartRow].Style.Numberformat.Format = "yyyy-mm-dd";

                        }
						int cpId = Convert.ToInt32(ds.Tables[0].Rows[i]["CPID"]);
						string cpName = "";
						if (cpId != 0)
						{
							cpName = (from m in db.ChannelPartners
								where m.Cpid == cpId
								select m.Cpname).FirstOrDefault();
							worksheet.Cells["C" + StartRow].Value = cpName;
						}
						else
						{
							worksheet.Cells["C" + StartRow].Value = "Administrator";
						}
						if (ds.Tables[0].Rows[i]["AddressLine1"] != DBNull.Value)
						{
							worksheet.Cells["D" + StartRow].Value = ds.Tables[0].Rows[i]["AddressLine1"].ToString();
						}
						if (ds.Tables[0].Rows[i]["AddressLine2"] != DBNull.Value)
						{
							worksheet.Cells["E" + StartRow].Value = ds.Tables[0].Rows[i]["AddressLine2"].ToString();
						}
						if (ds.Tables[0].Rows[i]["City"] != DBNull.Value)
						{
							worksheet.Cells["F" + StartRow].Value = ds.Tables[0].Rows[i]["City"].ToString();
						}
						if (ds.Tables[0].Rows[i]["Pincode"] != DBNull.Value)
						{
							worksheet.Cells["G" + StartRow].Value = ds.Tables[0].Rows[i]["Pincode"].ToString();
						}
						if (ds.Tables[0].Rows[i]["State"] != DBNull.Value)
						{
							worksheet.Cells["H" + StartRow].Value = ds.Tables[0].Rows[i]["State"].ToString();
						}
						if (ds.Tables[0].Rows[i]["Country"] != DBNull.Value)
						{
							worksheet.Cells["I" + StartRow].Value = ds.Tables[0].Rows[i]["Country"].ToString();
						}
						if (ds.Tables[0].Rows[i]["EmailID"] != DBNull.Value)
						{
							worksheet.Cells["J" + StartRow].Value = ds.Tables[0].Rows[i]["EmailID"].ToString();
						}
						if (ds.Tables[0].Rows[i]["Std1"] != DBNull.Value)
						{
							worksheet.Cells["K" + StartRow].Value = ds.Tables[0].Rows[i]["Std1"].ToString();
						}
						if (ds.Tables[0].Rows[i]["PhoneLL1"] != DBNull.Value)
						{
							worksheet.Cells["L" + StartRow].Value = ds.Tables[0].Rows[i]["PhoneLL1"].ToString();
						}
						if (ds.Tables[0].Rows[i]["Mobile1"] != DBNull.Value)
						{
							worksheet.Cells["M" + StartRow].Value = ds.Tables[0].Rows[i]["Mobile1"].ToString();
						}
						if (ds.Tables[0].Rows[i]["CompanyUniqueID"] != DBNull.Value)
						{
							worksheet.Cells["N" + StartRow].Value = ds.Tables[0].Rows[i]["CompanyUniqueID"].ToString();
						}
						StartRow++;
					}
				}
				p.Save();
				obj.isStatus = true;
				obj.response = retrivalPath;
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

	public CommonEntity.CommonResponse QuotationReport(ReportEntity.QuotationReport data)
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			DateTime? fromDate = DateTime.Now;
			if (data.fromDate == " " || data.fromDate == null)
			{
				fromDate = null;
			}
			else
			{
				try
				{
					string[] dt = data.fromDate.Split(new char[1] { '/' });
					string frDate = dt[2] + "-" + dt[1] + "-" + dt[0];
					fromDate = Convert.ToDateTime(frDate);
				}
				catch
				{
					fromDate = Convert.ToDateTime(data.fromDate);
				}
			}
			DateTime? toDate = DateTime.Now;
			if (data.toDate == " " || data.toDate == null)
			{
				toDate = null;
			}
			else
			{
				try
				{
					string[] dt2 = data.toDate.Split(new char[1] { '/' });
					string torDate = dt2[2] + "-" + dt2[1] + "-" + dt2[0];
					toDate = Convert.ToDateTime(torDate);
				}
				catch
				{
					toDate = Convert.ToDateTime(data.toDate);
				}
			}
			if (data.fromDate != null)
			{
				_ = data.toDate;
			}
			ExcelWorksheet Templatews = new ExcelPackage(new FileInfo("C:\\Templates\\QuotationReportTemplate.xlsx")).Workbook.Worksheets[0];
			string imageUrlSave = appSettings.ImageUrlSave;
			string ImageUrl = appSettings.ImageUrl;
			string FileDir = imageUrlSave + "\\QuotationReport_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
			string retrivalPath = ImageUrl + "QuotationReport_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
			FileInfo newFile = new FileInfo(FileDir);
			if (newFile.Exists)
			{
				try
				{
					newFile.Delete();
					newFile = new FileInfo(FileDir);
				}
				catch (Exception)
				{
					obj.response = ResourceResponse.ExceptionMessage;
				}
			}
			ExcelPackage p = null;
			p = new ExcelPackage(newFile);
			ExcelWorksheet worksheet = null;
			try
			{
				worksheet = p.Workbook.Worksheets.Add(DateTime.Now.ToString("dd-MM-yyyy"), Templatews);
			}
			catch
			{
			}
			if (worksheet == null)
			{
				worksheet = p.Workbook.Worksheets.Add(DateTime.Now.ToString("dd-MM-yyyy") + "1", Templatews);
			}
			int sheetcount = p.Workbook.Worksheets.Count;
			p.Workbook.Worksheets.MoveToStart(sheetcount - 1);
			worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
			SqlConnection SqlConnection = new SqlConnection(appSettings.DefaultConnection);
			DataSet ds = new DataSet();
			try
			{
				using (new SqlConnection())
				{
					SqlConnection.Open();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("QuotationReport", SqlConnection);
					sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@quotationNo", data.quotationNo);
					sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@cpId", data.cpId);
					sqlDataAdapter.Fill(ds);
					SqlConnection.Close();
				}
				int StartRow = 2;
				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						int cpId = Convert.ToInt32(ds.Tables[0].Rows[i]["CPID"]);
						string cpName = "";
						if (cpId != 0)
						{
							cpName = (from m in db.ChannelPartners
								where m.Cpid == cpId
								select m.Cpname).FirstOrDefault();
						}
						worksheet.Cells["A" + StartRow].Value = cpName;
						if (ds.Tables[0].Rows[i]["ProductModelID"] != DBNull.Value)
						{
							int prodectModelId = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductModelID"]);
							string productDesc = "";
							if (prodectModelId != 0)
							{
								productDesc = (from m in db.ProductModel
									where m.ProductModelId == prodectModelId
									select m.ProductModelName).FirstOrDefault();
								worksheet.Cells["B" + StartRow].Value = productDesc;
							}
						}
						if (ds.Tables[0].Rows[i]["ProductModelSparesID"] != DBNull.Value)
						{
							int productModelSparesID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductModelSparesID"]);
							string ProductModelSpareName = "";
							if (productModelSparesID != 0)
							{
								ProductModelSpareName = (from m in db.ProductModelSpare
									where m.ProductModelSparesId == productModelSparesID
									select m.ProductModelSparesName).FirstOrDefault();
								worksheet.Cells["B" + StartRow].Value = ProductModelSpareName;
							}
						}
						if (ds.Tables[0].Rows[i]["Quantity"] != DBNull.Value)
						{
							worksheet.Cells["C" + StartRow].Value = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
						}
						if (ds.Tables[0].Rows[i]["UnitPrice"] != DBNull.Value)
						{
							worksheet.Cells["D" + StartRow].Value = ds.Tables[0].Rows[i]["UnitPrice"].ToString();
						}
						if (ds.Tables[0].Rows[i]["TotalPrice"] != DBNull.Value)
						{
							worksheet.Cells["E" + StartRow].Value = ds.Tables[0].Rows[i]["TotalPrice"].ToString();
						}
						if (ds.Tables[0].Rows[i]["QuotationDate"] != DBNull.Value)
						{
							string quotationDate1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["QuotationDate"]).ToString("dd-MM-yyyy");
							worksheet.Cells["F" + StartRow].Value = quotationDate1;
						}
						if (ds.Tables[0].Rows[i]["QuotationNumber"] != DBNull.Value)
						{
							worksheet.Cells["G" + StartRow].Value = ds.Tables[0].Rows[i]["QuotationNumber"].ToString();
						}
						if (ds.Tables[0].Rows[i]["visitStatus"] != DBNull.Value)
						{
							worksheet.Cells["H" + StartRow].Value = ds.Tables[0].Rows[i]["visitStatus"].ToString();
						}
						if (ds.Tables[0].Rows[i]["buId"] != DBNull.Value)
						{
							string buIds = ds.Tables[0].Rows[i]["buId"].ToString();
							string buNames = "";
							if (buIds != "")
							{
								string[] array = buIds.Split(new char[1] { ',' });
								List<string> buNameList = new List<string>();
								string[] array2 = array;
								foreach (string item in array2)
								{
									string buName = (from m in db.BusinessUnit
										where m.BuId == Convert.ToInt32(item)
										select m.BuName).FirstOrDefault();
									buNameList.Add(buName);
								}
								buNames = string.Join(",", buNameList);
							}
							worksheet.Cells["I" + StartRow].Value = buNames;
						}
						if (ds.Tables[0].Rows[i]["CompanyUniqueID"] != DBNull.Value)
						{
							worksheet.Cells["J" + StartRow].Value = ds.Tables[0].Rows[i]["CompanyUniqueID"].ToString();
						}
						if (ds.Tables[0].Rows[i]["MDBID"] != DBNull.Value)
						{
							int mdbid = Convert.ToInt32(ds.Tables[0].Rows[i]["MDBID"]);
							string orgName = (from m in db.MdbgeneralData
								where m.Mdbid == mdbid
								select m.OrganizationName).FirstOrDefault();
							worksheet.Cells["K" + StartRow].Value = orgName;
						}
						StartRow++;
					}
				}
				p.Save();
				obj.isStatus = true;
				obj.response = retrivalPath;
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
}
