using GoldMedal.Branding.Data;
using System.Data;

namespace GoldMedal.Branding.Service.DesignTypeService
{
    public static class DesignTypeServiceCall
    {
        public static int DesignTypeInsertServiceMethod(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dti, string DatabaseType)
        {
            int recid = 0;
            DesignTypeDataAccess objinsert = new DesignTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateDesignTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DesignTypeDeleteServiceMethod(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeDelete dti, string DatabaseType)
        {
            int recid = 0;
            DesignTypeDataAccess objdelete = new DesignTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteDesignTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllDesignTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            DesignTypeDataAccess objselectall = new DesignTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignTypeDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleDesignTypeServiceMethod(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignTypeDataAccess objsingledesigntype = new DesignTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SingleDesignTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}