using GoldMedal.Branding.Service.JobTypeMaping;
using System.Data;

namespace GoldMedal.Branding.Core.JobTypeMaping
{
    public class JobTypeMaping : IJobTypeMaping
    {
        public int JobTypeMapingInsertMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dti)
        {
            int recid = 0;

            recid = JobTypeMapingServiceCall.JobTypeMapingInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int JobTypeMapingDeleteMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingDelete dti)
        {
            int recid = 0;

            recid = JobTypeMapingServiceCall.JobTypeMapingDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool JobTypeMapingDelete(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetJobTypeMapingAll()
        {
            DataTable recid = new DataTable();
            recid = JobTypeMapingServiceCall.AllJobTypeMapingServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetJobTypeMapingSingle(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = JobTypeMapingServiceCall.SingleJobTypeMapingServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllJobTypeForJobType(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = JobTypeMapingServiceCall.AllSubJobForJobTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllBoardTypeForJobType(int JobTypeID)
        {
            DataTable recid = new DataTable();
            recid = JobTypeMapingServiceCall.AllBoardTypeForJobTypeServiceMethod(JobTypeID, "MSSQLSERVER");
            return recid;
        }
    }
}