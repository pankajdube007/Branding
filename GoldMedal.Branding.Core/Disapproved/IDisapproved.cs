using System.Data;

namespace GoldMedal.Branding.Core.Disapproved
{
    public interface IDisapproved
    {
        DataTable AllDisapproveJobRequestHeadForApproveDACore();

        DataTable AllDisapproveJobRequestHeadBranchForApproveOldDACore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata);

        int DeleteJobRequestHeaddisapprovedCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata);

        int DeleteDisapprovedJobRequestChildCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata);

        DataTable DisapprovedJobRequestHeadSelectParticularCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata);

        DataTable DisapprovedJobRequestChildSelectParticularCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata);

        int UpdateDisapprovedJobRequestChildDACore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata);
    }
}