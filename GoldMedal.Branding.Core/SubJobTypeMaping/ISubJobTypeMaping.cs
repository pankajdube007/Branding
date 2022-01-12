using System.Data;

namespace GoldMedal.Branding.Core.SubJobTypeMaping
{
    public interface ISubJobTypeMaping
    {
        int SubJobTypeMapingInsertMethod(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dti);

        bool SubJobTypeMapingDelete(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingDelete dti);

        DataTable GetSubJobTypeMapingAll();

        DataTable GetAllSubSubJobTypeForSubJobType(GoldMedal.Branding.Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dtsingle);
    }
}