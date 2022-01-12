using GoldMedal.Branding.Service.SubSubJobTypeService;
using System.Data;

namespace GoldMedal.Branding.Core.SubSubJobType
{
    public class SubSubJobType : ISubSubJobType
    {
        public int SubSubJobTypeInsertMethod(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeInsert dti)
        {
            int recid = 0;

            recid = SubSubJobTypeServiceCall.SubSubJobTypeInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int SubSubJobTypeDeleteMethod(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeDelete dti)
        {
            int recid = 0;

            recid = SubSubJobTypeServiceCall.SubSubJobTypeDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool SubSubJobTypeDelete(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetSubSubJobTypeAll()
        {
            DataTable recid = new DataTable();
            recid = SubSubJobTypeServiceCall.AllSubSubJobTypeServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetSubSubJobTypeSingle(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = SubSubJobTypeServiceCall.SingleSubSubJobTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}