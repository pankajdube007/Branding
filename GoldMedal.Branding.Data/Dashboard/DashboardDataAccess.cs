using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.Dashboard
{
    public class DashboardDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public string GetUserAllBranchDA(int UserID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserID", UserID);
            return Convert.ToString(objDataAccess.ExecuteScalarWithParameters("GetUserAllBranch", objParameter));
        }

        public DataTable GetBranchwiseJobCountDA(string BranchIDs, string Fromdate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchwiseJobCountWeb", objParameter));
        }

        public DataTable GetBranchwiseApprovedJobCountDA(string BranchIDs, string Fromdate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchwiseApprovedJobCountWeb", objParameter));
        }

        public DataTable GetBranchwiseLiveProductApprovalPendingJobCountDA(string BranchIDs, string Fromdate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchwiseLiveProductManagementApprovalPendingJobCountWeb", objParameter));
        }

        public DataTable GetDesignerwiseJobCountDA(string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignerwiseJobCountWeb", objParameter));
        }

        public DataTable GetDesignerwiseApprovedPendingJobCountDA(string BranchIDs, string Fromdate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignerwiseApprovedPendingJobCountWeb", objParameter));
        }

        public DataTable GetDesignerwiseJobCountDashboardDA(string BranchIDs, string Fromdate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
           
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignerwiseJobCountDashboardWeb", objParameter));
        }
        public DataTable GetBranchwiseJobCountDA(int UserId)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            
            
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchwiseJobCountDashboardWeb", objParameter));
        }

        public DataTable GetBranchwiseDispatchJobCountDA(int UserId)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", UserId);


            return (objDataAccess.ReturnDataTableWithParameters("GetBranchwiseJobCountFinalAssembalyDispatchDashboardWeb", objParameter));
        }
        public DataTable GetDesignerwiseJobCountFromDashboardDA(int UserId, DateTime Fromdate, DateTime ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@UserId", UserId);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);

            return (objDataAccess.ReturnDataTableWithParameters("GetDesignerwiseJobCountFromDashboardWeb", objParameter));
        }

        public DataTable GetDesignerwiseJobCount(int BranchId, DateTime Fromdate, DateTime ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchId", BranchId);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);

            return (objDataAccess.ReturnDataTableWithParameters("GetBranchAndDesignerwiseJobCountDashboardWeb", objParameter));
        }

        public DataTable GetBranchwiseJobCount(int BranchId, DateTime Fromdate, DateTime ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchId", BranchId);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);

             // return (objDataAccess.ReturnDataTableWithParameters("GetBranchwisePendingApprovedJobsCountDashboardWeb", objParameter));
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchAndDesignerwiseJobCountDashboardWeb", objParameter));
        }

        public DataTable GetBrandingUsers()
        {
            return (objDataAccess.ReturnDataTable("GetBrandingUsers"));
        }
    }
}
