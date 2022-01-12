using GoldMedal.Branding.Service.Dashboard;
using System;
using System.Data;

namespace GoldMedal.Branding.Core.Dashboard
{
    public class Dashboard : IDashboard
    {
        public string GetAllUserBranchDACore(int UserID)
        {
            string result = "0";
            result = DashboardServiceCall.GetAllUserBranchDAServiceMethod(UserID, "MSSQLSERVER");
            return result;
        }

        public DataTable GetBranchwiseJobCountDACore(string BranchIDs, string Fromdate, string ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetBranchwiseJobCountDAServiceMethod(BranchIDs, Fromdate, ToDate, "MSSQLSERVER");
            return result;
        }

        public DataTable GetBranchwiseApprovedJobCountDACore(string BranchIDs, string Fromdate, string ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetBranchwiseApprovedJobCountDAServiceMethod(BranchIDs, Fromdate, ToDate, "MSSQLSERVER");
            return result;
        }
        public DataTable GetBranchwiseLiveProductApprovalPendingJobCountCore(string BranchIDs, string Fromdate, string ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetBranchwiseLiveProductApprovalPendingJobCountServiceMethod(BranchIDs, Fromdate, ToDate, "MSSQLSERVER");
            return result;
        }

        public DataTable GetDesignerwiseJobCountDACore(string BranchIDs)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetDesignerwiseJobCountDAServiceMethod(BranchIDs, "MSSQLSERVER");
            return result;
        }

        public DataTable GetDesignerwiseApprovedPendingJobCountDACore(string BranchIDs, string Fromdate, string ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetDesignerwiseApprovedPendingJobCountDAServiceMethod(BranchIDs, Fromdate, ToDate, "MSSQLSERVER");
            return result; 
        }

        public DataTable GetDesignerwiseJobDashboardCountDACore(string BranchIDs, string Fromdate, string ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetDesignerwiseJobDashboardCountDAServiceMethod(BranchIDs, Fromdate, ToDate, "MSSQLSERVER");
            return result;
        }


        public DataTable GetBranchwiseJobDashboardCountDACore(int UserId) 
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetBranchwiseJobDashboardCountDAServiceMethod("MSSQLSERVER", UserId);
            return result;
        }
        public DataTable GetBranchwiseDispatchJobDashboardCountDACore(int UserId)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetBranchwiseDispatchJobDashboardCountDAServiceMethod("MSSQLSERVER", UserId);
            return result;
        }
        public DataTable GetDesignerwiseJobDashboardCountDACore(int UserId, DateTime Fromdate, DateTime ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetDesignerwiseJobFromDashboardCountDAServiceMethod("MSSQLSERVER", UserId, Fromdate, ToDate);
            return result;
        }

        public DataTable GetDesignerwiseJobCountDACore(int BranchId, DateTime Fromdate, DateTime ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetDesignerwiseJobCountDAServiceMethod(BranchId, Fromdate, ToDate,"MSSQLSERVER");
            return result;
        }
        public DataTable GetBranchwiseJobCountDACore(int BranchId, DateTime Fromdate, DateTime ToDate)
        {
            DataTable result = new DataTable();
            result = DashboardServiceCall.GetBranchwiseJobCountDAServiceMethod(BranchId, Fromdate, ToDate, "MSSQLSERVER");
            return result;
        }
    }
}