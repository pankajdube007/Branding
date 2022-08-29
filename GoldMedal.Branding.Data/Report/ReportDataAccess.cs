using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.Report
{
    public class ReportDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();               
        public DataTable JobRequestAgingReportDA(string BranchIDs, string FromDate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@FromDate", FromDate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestAgingReport", objParameter));
        }
    }
}