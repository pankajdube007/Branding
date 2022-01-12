using GoldMedal.Branding.Service.DesignTypeService;
using System.Data;

namespace GoldMedal.Branding.Core.Design
{
    public class DesignType : IDesignType
    {
        public int DesignTypeInsertMethod(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dti)
        {
            int recid = 0;

            recid = DesignTypeServiceCall.DesignTypeInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int DesignTypeDeleteMethod(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeDelete dti)
        {
            int recid = 0;

            recid = DesignTypeServiceCall.DesignTypeDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool DesignTypeDelete(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetDesignTypeAll()
        {
            DataTable recid = new DataTable();
            recid = DesignTypeServiceCall.AllDesignTypeServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetDesignTypeSingle(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = DesignTypeServiceCall.SingleDesignTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}