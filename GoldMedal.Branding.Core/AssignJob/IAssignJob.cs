using System.Data;

namespace GoldMedal.Branding.Core.AssignJob
{
    public interface IAssignJob
    {
        DataTable AllJobRequestHeadForAssignDACore();

        DataTable AllAssignedJobDACore();

        bool AssignedJobDelete(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti);

        DataTable AllUsersDACore();

        DataTable JobRequestChildSelectForAssignParticularCore(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata);

        DataTable UserWorkStatus(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata);

        int AssignJobInsertMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti);

        int ReopenJobMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti);

        DataTable AssReqnoCore(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata);
    }
}