using GoldMedal.Branding.Service.DesignTypeSubCatService;
using System.Data;

namespace GoldMedal.Branding.Core.DesignTypeSubCat
{
    public class DesignTypeSubCat : IDesignTypeSubCat
    {
        public int DesignTypeSubCatInsertMethod(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dti)
        {
            int recid = 0;

            recid = DesignTypeSubCatServiceCall.DesignTypeSubCatInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int DesignTypeSubCatDeleteMethod(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatDelete dti)
        {
            int recid = 0;

            recid = DesignTypeSubCatServiceCall.DesignTypeSubCatDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool DesignTypeSubCatDelete(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetDesignTypeSubCatAll()
        {
            DataTable recid = new DataTable();
            recid = DesignTypeSubCatServiceCall.AllDesignTypeSubCatServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetDesignTypeSubCatSingle(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignTypeSubCatServiceCall.SingleDesignTypeSubCatServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}