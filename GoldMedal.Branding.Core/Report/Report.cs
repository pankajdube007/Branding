using GoldMedal.Branding.Service.Report;
using System.Data;

namespace GoldMedal.Branding.Core.Report
{
    public class Report : IReport
    {      
        public DataTable GetJobRequestAgingReport(string BranchIDs, string FromDate, string ToDate)
        {
            DataTable recid = new DataTable();
            recid =ReportServiceCall.JobRequestAgingReportServiceMethod("MSSQLSERVER", BranchIDs, FromDate, ToDate);
            return recid;
        }
    }
}