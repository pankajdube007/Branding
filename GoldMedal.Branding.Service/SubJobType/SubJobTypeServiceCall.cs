using GoldMedal.Branding.Data.SubJobType;
using System.Data;

namespace GoldMedal.Branding.Service.SubJobTypeService
{
    public static class SubJobTypeServiceCall
    {
        public static int SubJobTypeInsertServiceMethod(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dti, string DatabaseType)
        {
            int recid = 0;

            SubJobTypeDataAccess objinsert = new SubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateSubJobTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int SubJobTypeDeleteServiceMethod(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeDelete dti, string DatabaseType)
        {
            int recid = 0;
            SubJobTypeDataAccess objdelete = new SubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteSubJobTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllSubJobTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            SubJobTypeDataAccess objselectall = new SubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubJobTypeDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SubJobTypeImageServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            SubJobTypeDataAccess objselectall = new SubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SubJobTypeImageDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable SubJobTypeInactiveImageServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            SubJobTypeDataAccess objselectall = new SubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SubJobTypeInactiveImageDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleSubJobTypeServiceMethod(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            SubJobTypeDataAccess objsingleJobtype = new SubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleJobtype.SingleSubJobTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}