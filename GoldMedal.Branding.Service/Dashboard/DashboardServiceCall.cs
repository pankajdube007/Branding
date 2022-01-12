using GoldMedal.Branding.Data.Dashboard;
using System;
using System.Data;

namespace GoldMedal.Branding.Service.Dashboard
{
    public class DashboardServiceCall
    {
        public static string GetAllUserBranchDAServiceMethod(int UserID, string DatabaseType)
        {
            string recid = "0";
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetUserAllBranchDA(UserID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetBranchwiseJobCountDAServiceMethod(string BranchIDs, string Fromdate, string ToDate, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetBranchwiseJobCountDA(BranchIDs, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetBranchwiseApprovedJobCountDAServiceMethod(string BranchIDs, string Fromdate, string ToDate, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetBranchwiseApprovedJobCountDA(BranchIDs, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetBranchwiseLiveProductApprovalPendingJobCountServiceMethod(string BranchIDs, string Fromdate, string ToDate, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetBranchwiseLiveProductApprovalPendingJobCountDA(BranchIDs, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetDesignerwiseJobCountDAServiceMethod(string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetDesignerwiseJobCountDA(BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetDesignerwiseApprovedPendingJobCountDAServiceMethod(string BranchIDs, string Fromdate, string ToDate, string DatabaseType) 
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetDesignerwiseApprovedPendingJobCountDA(BranchIDs, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetDesignerwiseJobDashboardCountDAServiceMethod(string BranchIDs, string Fromdate, string ToDate, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetDesignerwiseJobCountDashboardDA(BranchIDs, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable GetBranchwiseJobDashboardCountDAServiceMethod( string DatabaseType, int UserId)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            { 
                recid = objdata.GetBranchwiseJobCountDA(UserId);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetBranchwiseDispatchJobDashboardCountDAServiceMethod(string DatabaseType, int UserId)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetBranchwiseDispatchJobCountDA(UserId);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetDesignerwiseJobFromDashboardCountDAServiceMethod(string DatabaseType, int UserId, DateTime Fromdate, DateTime ToDate)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetDesignerwiseJobCountFromDashboardDA(UserId, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetDesignerwiseJobCountDAServiceMethod(int BranchId , DateTime Fromdate, DateTime ToDate, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetDesignerwiseJobCount(BranchId, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetBranchwiseJobCountDAServiceMethod(int BranchId, DateTime Fromdate, DateTime ToDate, string DatabaseType)
        {
            DataTable recid = null;
            DashboardDataAccess objdata = new DashboardDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetBranchwiseJobCount(BranchId, Fromdate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

    }
}