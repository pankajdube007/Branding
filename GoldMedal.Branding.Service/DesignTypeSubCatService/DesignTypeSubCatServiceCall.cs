using GoldMedal.Branding.Data.DesignTypeSubCat;
using System.Data;

namespace GoldMedal.Branding.Service.DesignTypeSubCatService
{
    public static class DesignTypeSubCatServiceCall
    {
        public static int DesignTypeSubCatInsertServiceMethod(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dti, string DatabaseType)
        {
            int recid = 0;
            DesignTypeSubCatDataAccess objinsert = new DesignTypeSubCatDataAccess();

            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateDesignTypeSubCatDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DesignTypeSubCatDeleteServiceMethod(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatDelete dti, string DatabaseType)
        {
            int recid = 0;
            DesignTypeSubCatDataAccess objdelete = new DesignTypeSubCatDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteDesignTypeSubCatDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllDesignTypeSubCatServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            DesignTypeSubCatDataAccess objselectall = new DesignTypeSubCatDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignTypeSubCatDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleDesignTypeSubCatServiceMethod(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignTypeSubCatDataAccess objsingledesigntypeSubCat = new DesignTypeSubCatDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntypeSubCat.SingleDesignTypeSubCatDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}