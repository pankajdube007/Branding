using GoldMedal.Branding.Data.ProductType;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data
{
    public class ProductTypeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateProductTypeDA(ProductTypeModel.ProductTypeInsert ObjProductTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@Name", ObjProductTypeInput.Name);
            objParameter[1] = new SqlParameter("@Createuid", ObjProductTypeInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjProductTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@pagename", ObjProductTypeInput.pagename);
            objParameter[4] = new SqlParameter("@slno", ObjProductTypeInput.slno);
            objParameter[5] = new SqlParameter("@editusercat", ObjProductTypeInput.editusercat);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ProductTypeAddUpdate", objParameter));
        }

        public int DeleteProductTypeDA(ProductTypeModel.ProductTypeDelete ObjProductTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjProductTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjProductTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjProductTypeInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ProductTypeDelete", objParameter));
        }

        public DataTable AllProductTypeDA()
        {
            return (objDataAccess.ReturnDataTable("ProductTypeList"));
        }

        public DataTable SingleProductTypeDA(ProductTypeModel.ProductTypeInsert ObjProductTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjProductTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("ProductTypeSelectPerticular", objParameter));
        }
    }
}