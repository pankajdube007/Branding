using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldMedal.Branding.Data.RegionalLang;
using GoldMedal.Branding.Data.BoardType;
using System.Data;

namespace GoldMedal.Branding.Service.RegionalLang
{
    public class RegionalLangServiceCall
    {
        public static DataTable AllJobTypeMapingServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            RegionalLangDataAccess objselectall = new RegionalLangDataAccess();
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
        public static DataTable AllBranchServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            RegionalLangDataAccess objselectall = new RegionalLangDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllBranchDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubJobTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            RegionalLangDataAccess objselectall = new RegionalLangDataAccess();
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
        public static DataTable AllSubJobForJobTypeServiceMethod(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            RegionalLangDataAccess objAllSubJobForJobType = new RegionalLangDataAccess();
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
        public static int RegionalLangInsertServiceMethod(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangInsert dti, string DatabaseType)
        {
            int recid = 0;

            RegionalLangDataAccess objinsert = new RegionalLangDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateRegionalLangDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int RegionalLangDeleteServiceMethod(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangDelete dti, string DatabaseType)
        {
            int recid = 0;
            RegionalLangDataAccess objdelete = new RegionalLangDataAccess();
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

        public static DataTable RegionalLangTypeServiceMethod(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            RegionalLangDataAccess objsingleProducttype = new RegionalLangDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleProducttype.RegionalLangTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}
