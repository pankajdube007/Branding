using GoldMedal.Branding.Data;
using System.Data;

namespace GoldMedal.Branding.Service.ProductTypeService
{
    public static class ProductTypeServiceCall
    {
        public static int ProductTypeInsertServiceMethod(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeInsert dti, string DatabaseType)
        {
            int recid = 0;
            ProductTypeDataAccess objinsert = new ProductTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateProductTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int ProductTypeDeleteServiceMethod(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeDelete dti, string DatabaseType)
        {
            int recid = 0;
            ProductTypeDataAccess objdelete = new ProductTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteProductTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllProductTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            ProductTypeDataAccess objselectall = new ProductTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllProductTypeDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleProductTypeServiceMethod(GoldMedal.Branding.Data.ProductType.ProductTypeModel.ProductTypeInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            ProductTypeDataAccess objsingleProducttype = new ProductTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleProducttype.SingleProductTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}