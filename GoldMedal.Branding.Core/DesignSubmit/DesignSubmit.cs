using GoldMedal.Branding.Service.DesignSubmit;
using System;
using System.Data;
using System.Net.Mail;

namespace GoldMedal.Branding.Core.DesignSubmit
{
    public class DesignSubmit : IDesignSubmit
    {
        public DataTable GetAssignedJobForUserAll(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllAssignedJobForUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAssignedJobForUserSingle(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.SingleAssignedJobForUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable PrinterWorkStatus(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable result = new DataTable();
            result = DesignSubmitServiceCall.PrinterWorkStatus(dtsingle, "MSSQLSERVER");
            return result;
        }
        public DataTable JobDetailsForParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.JobDetailsForParty(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllDesignSubmitByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignSubmitByUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllDesignSubmitByUserforapprovel(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignSubmitByUserforapprovelServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllDesignSubmitWallSizeJobsByUserforapprovel(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignSubmitByUserforWallsizejobsapprovelServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllSubmitedDesignApprovedByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllSubmitedDesignApprovedByUserlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllSubmitedDesignDisapprovedByParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable(); 
            recid = DesignSubmitServiceCall.AllSubmitedDesignDisApprovedByPartylServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetAllDesignDisapprovedByParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignDisApprovedByPartylServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetAllDesignApprovedByParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignApprovedByPartylServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPartyApprovalPendingJobs(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.GetPartyApprovalPendingJobsServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllSubmitedDesignApprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        { 
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllSubmitedDesignApprovedByMgmlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetDesignerwiseSubmitedDesignApprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.GetDesignerwiseSubmitedDesignApprovedByMgmServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetBranchwiseSubmitedDesignApprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.GetBranchwiseSubmitedDesignApprovedByMgmServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetAllSubmitedDesignDisapprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllSubmitedDesignDisapprovedByMgmlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetDesignerwiseSubmitedDesignDisapprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.GetDesignerwiseSubmitedDesignDisapprovedByMgmlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetBranchwiseSubmitedDesignDisapprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.GetBranchwiseSubmitedDesignDisapprovedByMgmlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllDesignApprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignApprovedByMgmlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllDesignAcceptedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignAcceptedByMgmlServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllDesignSubmitByUserforapprovelmanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllDesignSubmitByUserforapprovelmanagementServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfDesignSubmitByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.DetailOfDesignSubmitByUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfDesignSubmitWallSizeByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.DetailOfDesignSubmitWallSizeByUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfItemListForDesignSubmit(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.DetailOfItemListForDesignSubmitServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfSizeListForDesignSubmit(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.DetailOfSizeListForDesignSubmitServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetItemDivisonAll()
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllItemDivisonServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetItemTypeAll(int DivisionID)
        {
            DataTable recid = new DataTable();
            recid = DesignSubmitServiceCall.AllItemTypeServiceMethod("MSSQLSERVER", DivisionID);
            return recid;
        }

        public int DesignSubmitInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.DesignSubmitInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int DesignSubmitUpdateMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.DesignSubmitUpdateServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int UpdateReopenSendForPrintMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.UpdateReopenSendForPrintServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int ItemDesignSubmitInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.ItemDesignSubmitInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int SizeDesignSubmitInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.SizeDesignSubmitInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int DesignSubmitTrackInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.AddDesignSubmitTracknsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int PermanentDeleteDesignSubmitCore(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata)
        {
            int result = DesignSubmitServiceCall.PermanentDeleteDesignSubmitServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int DeleteItemForDesignSubmitCore(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata)
        {
            int result = DesignSubmitServiceCall.DeleteItemForDesignSubmitServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int DeleteSizeForDesignSubmitCore(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata)
        {
            int result = DesignSubmitServiceCall.DeleteSizeForDesignSubmitServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public string sendmail(string toeamilid, string emailbody, string emailsubject, string displayname, string file_name)
        {
            string error = "0";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("noreply.goldmedal@goldmedalindia.com", "Goldmedal9867");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            try
            {
                mail.From = new MailAddress("noreply.goldmedal@goldmedalindia.com", displayname);
                mail.To.Add(new MailAddress(toeamilid));
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                mail.Body = emailbody;
                mail.Subject = emailsubject;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                //error= ex.Message.ToString();
                error = "-1";
            }
            return error;
        }

        public int UpdateEmail(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.UpdateEmail(dti, "MSSQLSERVER");
            return recid;
        }

        public int UpdateFinalApr(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.UpdateFinalApr(dti, "MSSQLSERVER");
            return recid;
        }

        public int UpdateEmailbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.UpdateEmailbymanagement(dti, "MSSQLSERVER");
            return recid;
        }
        public int LiveProductjobsReopenbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.LiveProductjobsReopenbymanagementService(dti, "MSSQLSERVER");
            return recid;
        }

        public int LiveProductjobsAcceptbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.LiveProductjobsAcceptbymanagementService(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateDisapprovalbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.UpdateDisapprovalbymanagement(dti, "MSSQLSERVER");
            return recid;
        }

        public int ApproveByParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti)
        {
            int recid = 0;

            recid = DesignSubmitServiceCall.ApproveByParty(dti, "MSSQLSERVER");
            return recid;
        }
    }
}