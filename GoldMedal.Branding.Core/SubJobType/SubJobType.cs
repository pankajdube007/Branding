using GoldMedal.Branding.Service.SubJobTypeService;
using System.Data;

namespace GoldMedal.Branding.Core.SubJobType
{
    public class SubJobType : ISubJobType
    {
        public int SubJobTypeInsertMethod(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dti)
        {
            int recid = 0;

            recid = SubJobTypeServiceCall.SubJobTypeInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int SubJobTypeDeleteMethod(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeDelete dti)
        {
            int recid = 0;

            recid = SubJobTypeServiceCall.SubJobTypeDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool SubJobTypeDelete(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetSubJobTypeAll()
        {
            DataTable recid = new DataTable();
            recid = SubJobTypeServiceCall.AllSubJobTypeServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetSubJobTypeImage()
        {
            DataTable recid = new DataTable();
            recid = SubJobTypeServiceCall.SubJobTypeImageServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetSubJobTypeInactiveImage()
        {
            DataTable recid = new DataTable();
            recid = SubJobTypeServiceCall.SubJobTypeInactiveImageServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetSubJobTypeSingle(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = SubJobTypeServiceCall.SingleSubJobTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}