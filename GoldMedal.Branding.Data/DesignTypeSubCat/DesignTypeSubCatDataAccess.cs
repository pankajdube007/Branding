using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.DesignTypeSubCat
{
    public class DesignTypeSubCatDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateDesignTypeSubCatDA(DesignTypeSubCatModel.DesignTypeSubCatInsert ObjDesignTypeSubCatInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@designtype", ObjDesignTypeSubCatInput.designtype);
            objParameter[1] = new SqlParameter("@Name", ObjDesignTypeSubCatInput.Name);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeSubCatInput.createuid);
            objParameter[3] = new SqlParameter("@Createlogno", ObjDesignTypeSubCatInput.createlogno);
            objParameter[4] = new SqlParameter("@pagename", ObjDesignTypeSubCatInput.pagename);
            objParameter[5] = new SqlParameter("@slno", ObjDesignTypeSubCatInput.slno);
            objParameter[6] = new SqlParameter("@editusercat", ObjDesignTypeSubCatInput.editusercat);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DesignTypeSubCategoryAddUpdate", objParameter));
        }

        public int DeleteDesignTypeSubCatDA(DesignTypeSubCatModel.DesignTypeSubCatDelete ObjDesignTypeSubCatInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeSubCatInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDesignTypeSubCatInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeSubCatInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("[DesignTypeSubCategoryDelete]", objParameter));
        }

        public DataTable AllDesignTypeSubCatDA()
        {
            return (objDataAccess.ReturnDataTable("[DesignTypeSubCategoryList]"));
        }

        public DataTable SingleDesignTypeSubCatDA(DesignTypeSubCatModel.DesignTypeSubCatInsert ObjDesignTypeSubCatsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeSubCatsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("DesignTypeSubCategorySelectParticular", objParameter));
        }
    }
}