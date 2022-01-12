using GoldMedal.Branding.Data.JobTypeMaping;
using GoldMedal.Branding.Data.BoardType;
using System.Data;

namespace GoldMedal.Branding.Service.JobTypeMaping
{
    public static class JobTypeMapingServiceCall
    {
        public static int JobTypeMapingInsertServiceMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dti, string DatabaseType)
        {
            int recid = 0;

            JobTypeMapingDataAccess objinsert = new JobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateJobTypeMapingDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int JobTypeMapingDeleteServiceMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingDelete dti, string DatabaseType)
        {
            int recid = 0;
            JobTypeMapingDataAccess objdelete = new JobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteJobTypeMapingDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllJobTypeMapingServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeMapingDataAccess objselectall = new JobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllJobTypeMappingDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleJobTypeMapingServiceMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            JobTypeMapingDataAccess objsingleJobTypeMaping = new JobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleJobTypeMaping.SingleJobTypeMapingDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubJobForJobTypeServiceMethod(GoldMedal.Branding.Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            JobTypeMapingDataAccess objAllSubJobForJobType = new JobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objAllSubJobForJobType.AllSubJobForJobTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllBoardTypeForJobTypeServiceMethod(int JobTypeID, string DatabaseType)
        {
            DataTable recid = null;
            JobTypeMapingDataAccess objBoard = new JobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objBoard.AllBoardTypeForJobTypeDA(JobTypeID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        
    }
}