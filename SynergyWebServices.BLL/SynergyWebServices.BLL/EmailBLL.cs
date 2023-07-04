using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using log4net;
using Microsoft.Extensions.Options;
using SynergyWebServices.BLL.Resource;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;

namespace SynergyWebServices.BLL;

public class EmailBLL : IEmail
{
	private SRKSSynergyContext db = new SRKSSynergyContext();

	private static readonly ILog log = LogManager.GetLogger(typeof(EmailBLL));

	private readonly EmailEntity.SmptSettings appSettings;

	public EmailBLL(SRKSSynergyContext _db, IOptions<EmailEntity.SmptSettings> _appSettings)
	{
		db = _db;
		appSettings = _appSettings.Value;
	}

	public CommonEntity.CommonResponse SendMailToViewNextFollowUpDates()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			string fDate = DateTime.Now.ToString("2020-12-22");
			DateTime fromD = Convert.ToDateTime(fDate);
			string tDate = DateTime.Now.AddDays(7.0).ToString("2021-01-04");
			DateTime toD = Convert.ToDateTime(tDate);
			CommonEntity.MailSender mailSender = new CommonEntity.MailSender();
			string to = " ";
			List<string> cc = new List<string>();
			foreach (var item in (from wf in db.VisitHistory
				where wf.NextVisitDate >= fromD && wf.NextVisitDate <= toD
				select new { wf.CpEnginneerId }).Distinct().ToList())
			{
				List<VisitHistory> visitData = db.VisitHistory.Where((VisitHistory m) => m.CpEnginneerId == item.CpEnginneerId && m.NextVisitDate >= fromD && m.NextVisitDate <= toD).ToList();
				to = (from m in db.ChannelPartnersEngineer
					where (int?)m.ChannelPartnersEngineerId == item.CpEnginneerId
					select m.EmaiId).FirstOrDefault();
				string cpOwner = (from m in db.ChannelPartnersEngineer
					where (int?)m.ChannelPartnersEngineerId == item.CpEnginneerId
					select m.EscalationMails).FirstOrDefault();
				if (cpOwner != null)
				{
					string[] array = cpOwner.Split(new char[1] { ',' });
					List<string> cpOwnerList = new List<string>();
					string[] array2 = array;
					foreach (string i in array2)
					{
						cpOwnerList.Add(i);
					}
					cc = cpOwnerList;
				}
				string cpEngineerName = (from m in db.ChannelPartnersEngineer
					where (int?)m.ChannelPartnersEngineerId == item.CpEnginneerId
					select m.Name).FirstOrDefault();
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Dear " + cpEngineerName + ",");
				sb.Append("\r\n                   <html>\r\n                    <head></head>\r\n                    <body>\r\n                        <div class='header'><h3> Your up-coming visit is due for the following customer.</h3></div>\r\n                        <table align='center'>\r\n                            <tr style='background-color:#7FFFD4'>\r\n                                <th> Sl No.</th>\r\n                                <th> Customer Name </th>\r\n                                <th> Next Visit Date </th>\r\n                            </tr>");
				int SlNo = 1;
				foreach (VisitHistory visit in visitData)
				{
					string nextVisitD = Convert.ToDateTime(visit.NextVisitDate).ToString("dd-MM-yyyy");
					string customerName = (from m in db.MdbgeneralData
						where m.CompanyUniqueId == visit.CompanyUniqueId
						select m.OrganizationName).FirstOrDefault();
					sb.Append("<tr>");
					sb.Append("<td>" + SlNo++ + "</td>");
					sb.Append("<td>" + customerName + "</td>");
					sb.Append("<td>" + nextVisitD + "</td>");
					sb.Append("<td><ul>");
					sb.Append("</ul></td></tr>");
				}
				sb.Append("\r\n                        </table>\r\n                        <div>\r\n                        <p> With Best Regard </p>\r\n                        <p> System Admin </p>\r\n                        </div>\r\n                        </body>\r\n                        </html>");
				mailSender.emailContent = sb.ToString();
				List<CommonEntity.ToAddress> toAddressesList = new List<CommonEntity.ToAddress>();
				CommonEntity.ToAddress toAddress = new CommonEntity.ToAddress();
				toAddress.to = to;
				toAddressesList.Add(toAddress);
				List<CommonEntity.CCAddress> cCAddressesList = new List<CommonEntity.CCAddress>();
				foreach (string items in cc)
				{
					CommonEntity.CCAddress ccAddress = new CommonEntity.CCAddress();
					ccAddress.cc = items;
					cCAddressesList.Add(ccAddress);
				}
				mailSender.toRecipents = toAddressesList;
				mailSender.ccRecipents = cCAddressesList;
				mailSender.subject = "Visit Followup Email";
				if (SendEmail(mailSender))
				{
					obj.isStatus = true;
					obj.response = ResourceResponse.MailSentSuccessful;
				}
				else
				{
					obj.isStatus = false;
					obj.response = ResourceResponse.FailureMessage;
				}
			}
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
				return obj;
			}
			return obj;
		}
	}

	public bool SendEmail(CommonEntity.MailSender data)
	{
		bool flag = false;
		try
		{
			SmtpClient smtp = new SmtpClient(appSettings.Server);
			smtp.UseDefaultCredentials = false;
			smtp.Port = appSettings.Port;
			string SenderId = appSettings.SenderEmail;
			string Pass = appSettings.Password;
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential(SenderId, Pass);
			smtp.EnableSsl = appSettings.SSL;
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress(SenderId);
			if (data.toRecipents.Count > 0 && data.toRecipents != null)
			{
				foreach (CommonEntity.ToAddress item in data.toRecipents)
				{
					if (item.to != null)
					{
						mail.To.Add(new MailAddress(item.to));
					}
				}
			}
			if (data.ccRecipents.Count > 0 && data.ccRecipents != null)
			{
				foreach (CommonEntity.CCAddress items in data.ccRecipents)
				{
					if (items.cc != null)
					{
						mail.To.Add(new MailAddress(items.cc));
					}
				}
			}
			mail.Subject = data.subject;
			mail.Body = data.emailContent;
			mail.IsBodyHtml = true;
			smtp.Send(mail);
			flag = true;
			return flag;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
				return flag;
			}
			return flag;
		}
	}

	public CommonEntity.CommonResponse SendMailToViewDues()
	{
		CommonEntity.CommonResponse obj = new CommonEntity.CommonResponse();
		try
		{
			string fDate = DateTime.Now.ToString("yyyy-MM-dd");
			DateTime fromD = Convert.ToDateTime(fDate);
			string tDate = DateTime.Now.AddDays(-7.0).ToString("yyyy-MM-dd");
			DateTime toD = Convert.ToDateTime(tDate);
			CommonEntity.MailSender mailSender = new CommonEntity.MailSender();
			foreach (var items in (from wf in db.VisitHistory
				where wf.VisitDateTime < fromD && wf.VisitDateTime >= toD
				select new { wf.CpEnginneerId }).Distinct().ToList())
			{
				List<VisitHistory> visitData = db.VisitHistory.Where((VisitHistory m) => m.CpEnginneerId == items.CpEnginneerId && m.VisitDateTime < fromD && m.VisitDateTime >= toD).ToList();
				List<string> to = new List<string>();
				List<string> cc = new List<string>();
				string cpOwner = (from m in db.ChannelPartnersEngineer
					where (int?)m.ChannelPartnersEngineerId == items.CpEnginneerId
					select m.EscalationMails).FirstOrDefault();
				if (cpOwner != null)
				{
					string[] array = cpOwner.Split(new char[1] { ',' });
					List<string> cpOwnerList = new List<string>();
					string[] array2 = array;
					foreach (string i in array2)
					{
						cpOwnerList.Add(i);
					}
					to = cpOwnerList;
				}
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Dear ");
				sb.Append("\r\n                   <html>\r\n                    <head></head>\r\n                    <body>\r\n                        <div class='header'><p> Currently, some of your employees have not closed the visits which are overdue . We request you to ensure your employees complete the overdue visit within the time frame and clear the backlog.</p>\r\n                        <p>Please ensure that the following employee(s) complete their visits immediately. </p></div>\r\n                        <table align='center'>\r\n                            <tr style='background-color:#7FFFD4'>\r\n                                <th> Sl No.</th>\r\n                                <th> Employee Name </th>\r\n                                <th> Due Days </th>\r\n                            </tr>");
				int SlNo = 1;
				foreach (VisitHistory visit in visitData)
				{
					string managerMailId = (from m in db.SalesManagerMaster
						where (int?)m.ManagerId == visit.SalesManagerId
						select m.ManagerEmailId).FirstOrDefault();
					if (managerMailId != null)
					{
						cc.Add(managerMailId);
					}
					string cpEngineerName = (from m in db.ChannelPartnersEngineer
						where (int?)m.ChannelPartnersEngineerId == visit.CpEnginneerId
						select m.Name).FirstOrDefault();
					DateTime visitDateTime = Convert.ToDateTime(visit.VisitDateTime);
					int dueDays = (Convert.ToDateTime(visit.NextVisitDate) - visitDateTime).Days;
					if (dueDays > 0)
					{
						sb.Append("<tr>");
						sb.Append("<td>" + SlNo++ + "</td>");
						sb.Append("<td>" + cpEngineerName + "</td>");
						sb.Append("<td>" + dueDays + "</td>");
						sb.Append("<td><ul>");
						sb.Append("</ul></td></tr>");
					}
				}
				sb.Append("\r\n                        </table>\r\n                        <div>\r\n                        <p> Kind Regards,  </p>\r\n                        <p> System Admin </p>\r\n                        </div>\r\n                        </body>\r\n                        </html>");
				mailSender.emailContent = sb.ToString();
				List<CommonEntity.ToAddress> toAddressesList = new List<CommonEntity.ToAddress>();
				foreach (string items2 in to)
				{
					CommonEntity.ToAddress toAddress = new CommonEntity.ToAddress();
					toAddress.to = items2;
					toAddressesList.Add(toAddress);
				}
				List<CommonEntity.CCAddress> cCAddressesList = new List<CommonEntity.CCAddress>();
				foreach (string items3 in cc)
				{
					CommonEntity.CCAddress ccAddress = new CommonEntity.CCAddress();
					ccAddress.cc = items3;
					cCAddressesList.Add(ccAddress);
				}
				mailSender.toRecipents = toAddressesList;
				mailSender.ccRecipents = cCAddressesList;
				mailSender.subject = "Your Employees have Overdue Visits";
				if (SendEmail(mailSender))
				{
					obj.isStatus = true;
					obj.response = ResourceResponse.MailSentSuccessful;
				}
				else
				{
					obj.isStatus = false;
					obj.response = ResourceResponse.FailureMessage;
				}
			}
			return obj;
		}
		catch (Exception ex)
		{
			log.Error(ex);
			if (ex.InnerException != null)
			{
				log.Error(ex.InnerException.ToString());
				return obj;
			}
			return obj;
		}
	}
}
