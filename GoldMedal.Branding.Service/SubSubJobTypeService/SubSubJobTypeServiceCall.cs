using GoldMedal.Branding.Data.SubSubJobType;
using System.Data;

namespace GoldMedal.Branding.Service.SubSubJobTypeService
{
    public static class SubSubJobTypeServiceCall
    {
        public static int SubSubJobTypeInsertServiceMethod(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeInsert dti, string DatabaseType)
        {
            int recid = 0;

            SubSubJobTypeDataAccess objinsert = new SubSubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateSubSubJobTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int SubSubJobTypeDeleteServiceMethod(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeDelete dti, string DatabaseType)
        {
            int recid = 0;
            SubSubJobTypeDataAccess objdelete = new SubSubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteSubSubJobTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllSubSubJobTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            SubSubJobTypeDataAccess objselectall = new SubSubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubSubJobTypeDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleSubSubJobTypeServiceMethod(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            SubSubJobTypeDataAccess objsingleJobtype = new SubSubJobTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleJobtype.SingleSubSubJobTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}