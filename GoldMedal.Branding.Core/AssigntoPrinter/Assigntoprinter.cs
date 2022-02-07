using GoldMedal.Branding.Service.AssigntoPrinter;
using System;
using System.Data;
using System.Net.Mail;

namespace GoldMedal.Branding.Core.AssigntoPrinter
{
    public class Assigntoprinter : IAssigntoprinter
    {
        public DataTable DetailOfJobToPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.DetailOfJobToPrinterForUserServiceMethod(dtsingle, "MSSQLSERVER"); 
            return recid;
        }

        public DataTable DetailOfJobToReopenPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.DetailOfJobToReopenPrinterForUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int GeneratePrinterPOInsertMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO dti)
        {
            int recid = 0;

            recid = AssignToPrinterServiceCall.GeneratePrinterPOInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int CancelPrinterPoMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO dti)
        {
            int recid = 0;

            recid = AssignToPrinterServiceCall.CancelPrinterPoServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetGenaratePrinterPO(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetGenaratePrinterPOServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetOtherBranchGenaratePrinterPO(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetOtherBranchGenaratePrinterPOServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetGenaratePrinterForCancelListPO(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetGenaratePrinterForCancelListPOServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterPOwithValueAuditReport(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetPrinterPOwithValueAuditReportServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterPOwithoutValueHoReport(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetPrinterPOwithoutValueHoReportServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterPOAgingReport(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetPrinterPOAgingReportServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable DetailOfJobToReassignPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.DetailOfJobToReassignPrinterForUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetApprovalDetailOfJobToPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.GetApprovalDetailOfJobToPrinterForUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable ApprovalDetailOfJobToPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.ApprovalDetailOfJobToPrinterForUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable DetailOfJobDoneByPrinterForApproval(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.DetailOfJobDoneByPrinterForApprovalUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable AllApprovedJobsOfPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.AllApprovedJobsOfPrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetJobSentByPrinterToReceive(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.JobSentByPrinterToReceiveServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterCreditDebitJobsToApprove1(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.PrinterCreditDebitJobsToApprove1ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterCreditDebitJobsToApprove2(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToPrinterServiceCall.PrinterCreditDebitJobsToApprove2ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int AssignPrinterInsertMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti, out string PrinterEmail, out string PrinterMobile)
        {
            int recid = 0;
            recid = AssignToPrinterServiceCall.AddAssignPrinterInsertServiceMethod(dti, "MSSQLSERVER", out string PrEmail, out string PrMobile);
            PrinterEmail = PrEmail;
            PrinterMobile = PrMobile;
            return recid;
        }

        public int ReAssignPrinterInsertMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti, out string PrinterEmail, out string PrinterMobile)
        {
            int recid = 0;
            recid = AssignToPrinterServiceCall.ReAssignPrinterInsertServiceMethod(dti, "MSSQLSERVER", out string PrEmail, out string PrMobile);
            PrinterEmail = PrEmail;
            PrinterMobile = PrMobile;
            return recid;
        }

        public int ApproveDesignSubmitByPrinterMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti)
        {
            int recid = 0;

            recid = AssignToPrinterServiceCall.ApproveDesignSubmitByPrinterServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int AssignedPrinterForJobDeleteMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti)
        {
            int recid = 0;

            recid = AssignToPrinterServiceCall.AssignedPrinterForJobDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable AllAssignedPrinterForJobDACore()
        {
            DataTable result = new DataTable();
            result = AssignToPrinterServiceCall.AllAssignedPrinterForJobDAServiceMethod("MSSQLSERVER");
            return result;
        }
        public DataTable AllAssignedPrinterForJobDACoreUser(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty alldata)
        {
            DataTable result = new DataTable();
           // result = AssignToPrinterServiceCall.AllAssignedPrinterForJobDAServiceMethod("MSSQLSERVER");
           result = AssignToPrinterServiceCall.AllAssignedPrinterForJobDAServiceMethodUser(alldata,"MSSQLSERVER");
            return result;
        }
        public DataTable PriReqnoCore(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty alldata)
        {
            DataTable result = new DataTable();
            result = AssignToPrinterServiceCall.PriReqnoServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public string sendmail(string ToEmail, string Body, string Subject, string DisplayName, string FileName)
        {
            string error = "0";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("noreply.goldmedal@goldmedalindia.com", "Goldmedal9867");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            try
            {
                mail.From = new MailAddress("noreply.goldmedal@goldmedalindia.com", DisplayName);
                mail.To.Add(new MailAddress(ToEmail));
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                mail.Body = Body;
                mail.Subject = Subject;

                smtpClient.Send(mail);
                error = "1";
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                error = msg;
                error = "-1";
            }
            return error;
        }
    }
}