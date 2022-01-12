using System.Data;

namespace GoldMedal.Branding.Core.ApproveJob
{
    public interface IApproveJob
    {
        DataTable AllJobRequestHeadForApproveDACore(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata);

        DataTable JobRequestChildSelectForApproveParticularCore(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata);

        string ApproveJobInsertMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata);

        string DisApproveJobInsertMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata);

        int ApproveCount(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata);

        DataTable AllApprovedJobByUserCore(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata);
    }
}