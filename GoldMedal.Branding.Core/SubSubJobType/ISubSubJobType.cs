using System.Data;

namespace GoldMedal.Branding.Core.SubSubJobType
{
    public interface ISubSubJobType
    {
        int SubSubJobTypeInsertMethod(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeInsert dti);

        bool SubSubJobTypeDelete(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeDelete dti);

        DataTable GetSubSubJobTypeAll();

        DataTable GetSubSubJobTypeSingle(GoldMedal.Branding.Data.SubSubJobType.SubSubJobTypeModel.SubSubJobTypeInsert dtsingle);
    }
}