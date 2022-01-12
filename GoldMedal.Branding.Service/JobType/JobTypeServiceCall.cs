using GoldMedal.Branding.Data.JobType;
using System.Data;

namespace GoldMedal.Branding.Service.JobTypeService
{
    public static class JobTypeServiceCall
    {
        public static int JobTypeInsertServiceMethod(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeInsert dti, string DatabaseType)
        {
            int recid = 0;

            JobTypeDataAccess objinsert = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateJobTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int JobTypeDeleteServiceMethod(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeDelete dti, string DatabaseType)
        {
            int recid = 0;
            JobTypeDataAccess objdelete = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteJobTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllJobTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objselectall = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllJobTypeDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobTypeActiveImageServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objselectall = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.JobTypeActiveImageDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobTypeInactiveImageServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objselectall = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.JobTypeInactiveImageDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleJobTypeServiceMethod(GoldMedal.Branding.Data.JobType.JobTypeModel.JobTypeInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objsingleJobtype = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleJobtype.SingleJobTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllPrinterLocationServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objselectall = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPrinterLocationDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllFabricatorLocationServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objselectall = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllFabricatorLocationDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllUnitServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobTypeDataAccess objselectall = new JobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllUnitDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        
    }
}