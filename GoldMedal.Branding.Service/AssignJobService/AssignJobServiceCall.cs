using GoldMedal.Branding.Data.AssignJob;
using System.Data;

namespace GoldMedal.Branding.Service.AssignJobService
{
    public class AssignJobServiceCall
    {
        public static DataTable AllJobRequestHeadForAssignDAServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllJobRequestHeadForAssignDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllJobRequestHeadForAssignDAServiceMethodUser(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER")) 
            {
                  recid = objdata.AllJobRequestHeadForAssignDAUser(alldata);
               
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllJobRequestHeadForChangeAssignDAServiceMethodUser(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllJobRequestHeadForChangeAssignDAUser(alldata);

            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllAssignedJobDAServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllAssignedJobDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllAssignedJobDAServiceMethodUser(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
           
               recid = objdata.AllAssignedJobDAUser(alldata);
               
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllUsersDAServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllUsersDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobRequestChildSelectParticularForAssignServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestChildSelectForAssignParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobRequestChildSelectParticularForReAssignServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestChildSelectForReAssignParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable UserWorkStatus(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.UserWorkStatus(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int AddAssignJobInsertServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti, string DatabaseType)
        {
            int recid = 0;
            AssignJobDataAccess objinsert = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddAssignJobeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int ChangeAssignJobInsertServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti, string DatabaseType)
        {
            int recid = 0;
            AssignJobDataAccess objinsert = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ChangeAssignJobeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int ReopenJobServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti, string DatabaseType)
        {
            int recid = 0;
            AssignJobDataAccess objinsert = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ReopenJobDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int AssignedJobDeleteServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti, string DatabaseType)
        {
            int recid = 0;
            AssignJobDataAccess objdelete = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteAssignedJobDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AssReqnoServiceMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignJobDataAccess objdata = new AssignJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AssReqno(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}