using System.Data;

namespace GoldMedal.Branding.Core.FabricatorQuotation
{
    public interface IFabricatorQuotation
    {
        int FabricatorQuotationInsertMethod(GoldMedal.Branding.Data.FabricatorQuotation.FabricatorQuotation.FabricatorQuotationInsert dti);

        DataTable GetFabricatorQuotationSingle(GoldMedal.Branding.Data.FabricatorQuotation.FabricatorQuotation.FabricatorQuotationInsert dtsingle);

        DataTable GetFabricatorQuotationAll();

        DataTable GetFabricatorQuotationForFabricator(long FabricatorID);
    }
}