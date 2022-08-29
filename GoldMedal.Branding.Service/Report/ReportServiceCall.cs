using GoldMedal.Branding.Data.Report;
using System.Data;

namespace GoldMedal.Branding.Service.Report
{
    public static class ReportServiceCall
    {
        public static DataTable JobRequestAgingReportServiceMethod(string DatabaseType, string BranchIDs, string FromDate, string ToDate)
        {
            DataTable recid = null;
            ReportDataAccess objselectall = new ReportDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.JobRequestAgingReportDA(BranchIDs, FromDate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}