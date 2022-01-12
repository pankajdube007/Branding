using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.UAParser;
using GoldMedal.Branding.Core.UAParser.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Http;

namespace GoldMedal.Branding.Admin
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void Application_Error(object sender, EventArgs e)
        {
            return;
            HttpException lastErrorWrapper = Server.GetLastError() as HttpException;
            //Server.ClearError();
            Exception lastError = lastErrorWrapper;
            if (lastErrorWrapper.InnerException != null)
                lastError = lastErrorWrapper.InnerException;

            string lastErrorTypeName = lastError.GetType().ToString();
            string lastErrorMessage = lastError.Message;
            string lastErrorStackTrace = lastError.StackTrace;
            string errorCode = lastErrorWrapper.ErrorCode.ToString();
            string help = lastError.HelpLink;
            string Subject = "Oops!! Error in " + Request.RawUrl;

            using (var mm = new MailMessage())
            {
                mm.From = new MailAddress("software.support@goldmedalindia.com", "GoldBranding: Alert(Error)");
                mm.ReplyToList.Add(new MailAddress("it@goldmedalindia.com"));
                mm.CC.Add(new MailAddress("it@goldmedalindia.com"));
                mm.CC.Add(new MailAddress("gaurav.goldmedalindia@gmail.com"));
                mm.Bcc.Add(new MailAddress("santanu.goldmedalindia@gmail.com"));
                mm.To.Add(new MailAddress("prasad.goldmedalindia@gmail.com"));

                mm.IsBodyHtml = true;
                mm.Priority = MailPriority.High;
                mm.Subject = Subject;
                mm.Body = string.Format(@"
                                    <html>
                                    <body>

                                        {0}<br /><br /><br />

                                      <table border=1>
                                      <tr>
                                      <th bgcolor=#FFB565>Raw Url</th>
                                      <td >{1}</td>
                                      </tr>
                                      <tr>
                                      <th bgcolor=#FFB565>Error Code</th>
                                      <td>{2}</td>
                                      </tr>
                                      <tr>
                                      <th bgcolor=#FFB565>Exception Type</th>
                                      <td>{3}</td>
                                      </tr>
                                      <tr>
                                      <th bgcolor=#FFB565>Message</th>
                                      <td >{4}</td>
                                      </tr>
                                      <tr>
                                      <th bgcolor=#FFB565>Help</th>
                                      <td >{5}</td>
                                      </tr>
                                      <tr>
                                      <th bgcolor=#FFB565>Stack Trace</th>
                                      <td>{6}</td>
                                      </tr>
                                      </table>
                                    </body>
                                    </html>",
                                        GetUserInfo(),
                                        Request.RawUrl,
                                        errorCode,
                                        lastErrorTypeName,
                                        lastErrorMessage,
                                        help,
                                        lastErrorStackTrace.Replace(Environment.NewLine, "<br />")
                    );
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("software.support@goldmedalindia.com", "8080772544");
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mm);
                }
            }
        }

        private string GetUserInfo()
        {
            var clientSource = ClientDetails.GetClientDetails().FirstOrDefault();
            var ip = clientSource.UserHostAddress;
            string uaString = Request.UserAgent;
            //var uaParser = Parser.GetDefault();
            var uaParser = Parser.FromYamlFile(Server.MapPath("~/App_Data/regexes.yaml"));
            ClientInfo c = uaParser.Parse(uaString);

            var uaFamily = c.UserAgent.Family; // => "Mobile Safari"
            var uaVerson = c.UserAgent.Major + "." + c.UserAgent.Minor;

            var osFamily = c.OS.Family;        // => "iOS"
            var osVerson = c.OS.Major + "." + c.OS.Minor;

            var devFamily = c.Device.Family;    // => "iPhone"
            var devFormFactor = c.Device.FormFactor;  // => Mobile
            var devBrand = c.Device.Brand;
            var devModel = c.Device.Model;
            var devbot = c.Device.IsSpider;

            var rtnStr = string.Format("<table border=1>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Application </th>" + "<td>Goldmedal Branding</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>User </th>" + "<td>{0}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>IP</th>" + "<td>{1}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Logno</th>" + "<td>{2}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>OS Family</th>" + "<td>{3}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>OS Version</th>" + "<td>{4}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Device Family</th>" + "<td>{5}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Device Formfactor</th>" + "<td>{6}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Brand</th>" + "<td>{7}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Model</th>" + "<td>{8}</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                      "<th bgcolor=#6FEAD9>Is Bot? </th>" + "<td>{9}</td>" +
                                      "</tr>" +
                                       "<tr>" +
                                      "<th bgcolor=#6FEAD9>UserAgent Family</th>" + "<td>{10}</td>" +
                                      "</tr>" +
                                       "<tr>" +
                                      "<th bgcolor=#6FEAD9>UserAgent Version</th>" + "<td>{11}</td>" +
                                      "</tr>" +
                                       "<tr>" +
                                      "<th bgcolor=#6FEAD9>Date Time</th>" + "<td>{12}</td>" +
                                      "</tr>" +
                                      "</table>"
                                      , ValidateDataType.GetCookieString("usernm", true)?.ToString() ?? "Not Found"
                                      , ip
                                      , ValidateDataType.GetCookieString("logno", true)?.ToString() ?? "Not Found"
                                      , osFamily
                                      , osVerson
                                      , devFamily
                                      , devFormFactor
                                      , devBrand
                                      , devModel
                                      , devbot
                                      , uaFamily
                                      , uaVerson
                                      , DateTime.Now
                                      );
            return rtnStr;
        }
    }
}