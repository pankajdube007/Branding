using GoldMedal.Branding.Service.ProductTypeService;
using System.Data;

namespace GoldMedal.Branding.Core.ProductType
{
    public class ProductType : IProductType
    {
        public int ProductTypeInsertMethod(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeInsert dti)
        {
            int recid = 0;

            recid = ProductTypeServiceCall.ProductTypeInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int ProductTypeDeleteMethod(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeDelete dti)
        {
            int recid = 0;
            recid = ProductTypeServiceCall.ProductTypeDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool ProductTypeDelete(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetProductTypeAll()
        {
            DataTable recid = new DataTable();
            recid = ProductTypeServiceCall.AllProductTypeServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetProductTypeSingle(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = ProductTypeServiceCall.SingleProductTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}