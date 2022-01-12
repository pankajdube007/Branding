using GoldMedal.Branding.Service.SubJobTypeMaping;
using System.Data;

namespace GoldMedal.Branding.Core.SubJobTypeMaping
{
    public class SubJobTypeMaping : ISubJobTypeMaping
    {
        public int SubJobTypeMapingInsertMethod(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dti)
        {
            int recid = 0;

            recid = SubJobTypeMapingServiceCall.SubJobTypeMapingInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int SubJobTypeMapingDeleteMethod(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingDelete dti)
        {
            int recid = 0;

            recid = SubJobTypeMapingServiceCall.SubJobTypeMapingDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool SubJobTypeMapingDelete(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetSubJobTypeMapingAll()
        {
            DataTable recid = new DataTable();
            recid = SubJobTypeMapingServiceCall.AllSubJobTypeMapingServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllSubSubJobTypeForSubJobType(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = SubJobTypeMapingServiceCall.AllSubSubJobForJobTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}