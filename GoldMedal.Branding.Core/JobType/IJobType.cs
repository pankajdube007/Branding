using System.Data;

namespace GoldMedal.Branding.Core.JobType
{
    public interface IJobType
    {
        int JobTypeInsertMethod(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeInsert dti);

        bool JobTypeDelete(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeDelete dti);

        DataTable GetJobTypeAll();

        DataTable GetJobTypeSingle(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeInsert dtsingle);

        DataTable GetPrinterLocation();
        DataTable GetFabricatorLocation();

        DataTable GetUnits();
    }
}