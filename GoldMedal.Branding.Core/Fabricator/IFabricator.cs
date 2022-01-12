using System.Data;

namespace GoldMedal.Branding.Core.Fabricator
{
    public interface IFabricator
    {
        int FabricatorInsertMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti);

        bool FabricatorDelete(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti);

        DataTable GetFabricatorAll();

        DataTable GetAreaAll();

        DataTable GetBranchAll();

        DataTable GetFabricatorSingle(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle);

        DataTable AreaDetail(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle);
        DataTable GetFabricatorByLocation(int LocationID);

        DataTable GetFabricatorPricingAll();

        DataTable GetDetailOfPricingListForFabricator(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle);

        int FabricatorPricingAddUpdate(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorPricingInsert dti);
    }
}