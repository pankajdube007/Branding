using System.Data;

namespace GoldMedal.Branding.Core.SubJobType
{
    public interface ISubJobType
    {
        int SubJobTypeInsertMethod(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dti);

        bool SubJobTypeDelete(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeDelete dti);

        DataTable GetSubJobTypeAll();

        DataTable GetSubJobTypeSingle(GoldMedal.Branding.Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dtsingle);
    }
}