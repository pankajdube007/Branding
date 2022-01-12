using GoldMedal.Branding.Data.Disapproved;
using System.Data;

namespace GoldMedal.Branding.Service.Disapproved
{
    public static class DisApproveJobServiceCall
    {
        public static DataTable AllDisapprovedJobRequestHeadDAServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllDisapprovedJobRequestHeadDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDisapprovedJobRequestHeadBranchDAServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
              //  recid = objdata.AllDisapprovedJobRequestHeadDA();
                recid = objdata.AllDisapprovedJobRequestHeadDABranch(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDisapprovedJobRequestHeadBranchOldDAServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                //  recid = objdata.AllDisapprovedJobRequestHeadDA();
                recid = objdata.AllDisapprovedJobRequestHeadOldDABranch(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static int DeleteDisapprovedJobRequestHeadServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            int recid = 0;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DeleteDisapprovedJobRequestHead(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DeleteDisapprovedJobRequestChildServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            int recid = 0;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DeleteDisapprovedJobRequestChild(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable DisapprovedJobRequestHeadSelectParticularServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DisapprovedJobRequestHeadSelectParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DisapprovedJobRequestChildSelectParticularServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DisapprovedJobRequestChildSelectParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int UpdateDisapprovedJobRequestChildDAServiceMethod(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata, string DatabaseType)
        {
            int recid = 0;
            DisApproveJobDataAccess objdata = new DisApproveJobDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.UpdateDisapprovedJobRequestChildDA(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
    }
}