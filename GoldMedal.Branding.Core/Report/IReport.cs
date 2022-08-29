using System.Data;

namespace GoldMedal.Branding.Core.Report
{
    public interface IReport
    {
        DataTable GetJobRequestAgingReport(string BranchIDs, string FromDate, string ToDate);
    }
}