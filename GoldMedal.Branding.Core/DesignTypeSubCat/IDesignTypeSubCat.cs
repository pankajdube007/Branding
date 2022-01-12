using System.Data;

namespace GoldMedal.Branding.Core.DesignTypeSubCat
{
    internal interface IDesignTypeSubCat
    {
        int DesignTypeSubCatInsertMethod(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dti);

        //  int DesignTypeUpdate(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dti);
        bool DesignTypeSubCatDelete(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatDelete dti);

        DataTable GetDesignTypeSubCatAll();

        DataTable GetDesignTypeSubCatSingle(GoldMedal.Branding.Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dtsingle);
    }
}