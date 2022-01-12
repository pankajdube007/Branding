using System.Data;

namespace GoldMedal.Branding.Core.JobTypeMaping
{
    public interface IJobTypeMaping
    {
        int JobTypeMapingInsertMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dti);

        bool JobTypeMapingDelete(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingDelete dti);

        DataTable GetJobTypeMapingAll();

        DataTable GetJobTypeMapingSingle(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dtsingle);

        DataTable GetAllJobTypeForJobType(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dtsingle);

        DataTable GetAllBoardTypeForJobType(int JobTypeID);
    }
}