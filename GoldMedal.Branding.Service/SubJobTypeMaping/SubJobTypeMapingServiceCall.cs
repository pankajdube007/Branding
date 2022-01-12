using GoldMedal.Branding.Data.SubJobTypeMaping;
using System.Data;

namespace GoldMedal.Branding.Service.SubJobTypeMaping
{
    public static class SubJobTypeMapingServiceCall
    {
        public static int SubJobTypeMapingInsertServiceMethod(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dti, string DatabaseType)
        {
            int recid = 0;

            SubJobTypeMapingDataAccess objinsert = new SubJobTypeMapingDataAccess();
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

        public static int SubJobTypeMapingDeleteServiceMethod(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingDelete dti, string DatabaseType)
        {
            int recid = 0;
            SubJobTypeMapingDataAccess objdelete = new SubJobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteSubJobTypeMapingDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllSubJobTypeMapingServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            SubJobTypeMapingDataAccess objselectall = new SubJobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubJobTypeMappingDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubSubJobForJobTypeServiceMethod(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            SubJobTypeMapingDataAccess objAllSubJobForJobType = new SubJobTypeMapingDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objAllSubJobForJobType.AllSubSubJobForSubJobTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}