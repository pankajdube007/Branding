using System.Data;

namespace GoldMedal.Branding.Core.Dashboard
{
    public interface IDashboard
    {
        string GetAllUserBranchDACore(int UserID);
        DataTable GetBranchwiseJobCountDACore(string BranchIDs, string Fromdate, string ToDate);

        DataTable GetBranchwiseApprovedJobCountDACore(string BranchIDs, string Fromdate, string ToDate);

        DataTable GetDesignerwiseJobCountDACore(string BranchIDs);

        DataTable GetDesignerwiseApprovedPendingJobCountDACore(string BranchIDs, string Fromdate, string ToDate);
    }
}
