using GoldMedal.Branding.Service.JobTypeService;
using System.Data;

namespace GoldMedal.Branding.Core.JobType
{
    public class JobType : IJobType
    {
        public int JobTypeInsertMethod(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeInsert dti)
        {
            int recid = 0;

            recid = JobTypeServiceCall.JobTypeInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int JobTypeDeleteMethod(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeDelete dti)
        {
            int recid = 0;

            recid = JobTypeServiceCall.JobTypeDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool JobTypeDelete(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetJobTypeAll()
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.AllJobTypeServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetJobTypeActiveImage()
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.JobTypeActiveImageServiceMethod("MSSQLSERVER");
            return recid;
        }
        public DataTable GetJobTypeInactiveImage()
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.JobTypeInactiveImageServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetJobTypeSingle(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.SingleJobTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterLocation()
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.AllPrinterLocationServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorLocation()
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.AllFabricatorLocationServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetUnits()
        {
            DataTable recid = new DataTable();
            recid = JobTypeServiceCall.AllUnitServiceMethod("MSSQLSERVER");
            return recid;
        }
    }
}