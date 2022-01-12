using System.Data;

namespace GoldMedal.Branding.Core.ProductType
{
    public interface IProductType
    {
        int ProductTypeInsertMethod(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeInsert dti);

        bool ProductTypeDelete(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeDelete dti);

        DataTable GetProductTypeAll();

        DataTable GetProductTypeSingle(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeInsert dtsingle);
    }
}