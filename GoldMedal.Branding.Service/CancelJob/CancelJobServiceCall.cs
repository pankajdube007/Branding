using GoldMedal.Branding.Data.CancelJob;
using System.Data;

namespace GoldMedal.Branding.Service.CancelJob
{
   public class CancelJobServiceCall
    {
        public static DataTable ListOfJobForCancelServiceMethod(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            CancelJobDataAccess objselectall = new CancelJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetJobdetailforthejobcancel();
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable DetailsOfJobForJobCloserServiceMethod(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            CancelJobDataAccess objselectall = new CancelJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetDetailsOfJobForJobcancel(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int JobCancelServiceMethod(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dti, string DatabaseType)
        {
            int recid = 0;
            CancelJobDataAccess objinsert = new CancelJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobCancel(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable ListOfJobForCancelServiceMethodDateWise(string Fromdate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            CancelJobDataAccess objselectall = new CancelJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetJobdetailforthejobcancelDateWise(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}
