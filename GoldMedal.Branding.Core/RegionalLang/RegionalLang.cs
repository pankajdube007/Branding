using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldMedal.Branding.Service.RegionalLang;
using System.Data;

namespace GoldMedal.Branding.Core.RegionalLang
{
    public class RegionalLang : IRegionalLang
    {
        public DataTable RegionalLangAll()
        {
            DataTable recid = new DataTable();
            recid = RegionalLangServiceCall.AllJobTypeMapingServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetBranchAll()
        {
            DataTable recid = new DataTable();
            recid = RegionalLangServiceCall.AllBranchServiceMethod("MSSQLSERVER");
            return recid;
        }
        public DataTable GetSubJobTypeAll()
        {
            DataTable recid = new DataTable();
            recid = RegionalLangServiceCall.AllSubJobTypeServiceMethod("MSSQLSERVER");
            return recid;
        }
        public DataTable GetAllJobTypeForJobType(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = RegionalLangServiceCall.AllSubJobForJobTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int RegionalLangInsertMethod(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangInsert dti)
        {
            int recid = 0;

            recid = RegionalLangServiceCall.RegionalLangInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int RegionalLangDeleteMethod(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangDelete dti)
        {
            int recid = 0;

            recid = RegionalLangServiceCall.RegionalLangDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public bool RegionalLangModelDelete(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangDelete dti)
        {
            bool recid = false;

            return recid;
        }
        public DataTable GetRegionalLangTypeSingle(GoldMedal.Branding.Data.RegionalLang.RegionalLangModel.RegionalLangInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = RegionalLangServiceCall.RegionalLangTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}
