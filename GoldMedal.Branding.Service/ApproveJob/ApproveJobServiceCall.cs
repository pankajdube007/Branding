using GoldMedal.Branding.Data.ApproveJob;
using System.Data;

namespace GoldMedal.Branding.Service.ApproveJob
{
    public class ApproveJobServiceCall
    {
        public static DataTable AllJobRequestHeadForApproveDAServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            ApproveJobDataAccess objdata = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllJobRequestHeadForApproveDA(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllApprovedJobByUserServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            ApproveJobDataAccess objdata = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllApprovedJobByUserDA(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        

        public static DataTable JobRequestChildSelectParticularForApproveServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            ApproveJobDataAccess objdata = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestChildSelectForApproveParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static string AddApproveJobInsertServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti, string DatabaseType)
        { 
            string recid = "0";
            ApproveJobDataAccess objinsert = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddApproveJobeDA(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }
        public static string PartyApproveUpdateServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti, string DatabaseType)
        {
            string recid = "0";
            ApproveJobDataAccess objinsert = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PartyApproveUpdateJobeDA(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }

        public static string AddDisApproveJobInsertServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti, string DatabaseType)
        { 
            string recid = "0";
            ApproveJobDataAccess objinsert = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddDisApproveJobeDA(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }

        public static string ReopenJobInsertServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti, string DatabaseType)
        {
            string recid = "0";
            ApproveJobDataAccess objinsert = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ReopenJobeDA(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }

        public static int ApproveCount(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti, string DatabaseType)
        {
            int recid = 0;
            ApproveJobDataAccess objinsert = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ApproveCount(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static string CancelOverdueJobsServiceMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.OverdueJobsCancel dti, string DatabaseType)
        {
            string recid = "0";
            ApproveJobDataAccess objinsert = new ApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.CancelOverdueJobsDA(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }
    }
}