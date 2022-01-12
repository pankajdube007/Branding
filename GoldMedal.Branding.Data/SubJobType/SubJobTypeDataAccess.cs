using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.SubJobType
{
    public class SubJobTypeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateSubJobTypeDA(SubJobTypeModel.SubJobTypeInsert ObjSubJobTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[10];
            objParameter[0] = new SqlParameter("@Name", ObjSubJobTypeInput.Name);
            objParameter[1] = new SqlParameter("@Createuid", ObjSubJobTypeInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjSubJobTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@pagename", ObjSubJobTypeInput.pagename);
            objParameter[4] = new SqlParameter("@slno", ObjSubJobTypeInput.slno);
            objParameter[5] = new SqlParameter("@editusercat", ObjSubJobTypeInput.editusercat);
            objParameter[6] = new SqlParameter("@SubJobtypeimage", ObjSubJobTypeInput.SubJobtypeimage);
            objParameter[7] = new SqlParameter("@ImageValidFromDate", ObjSubJobTypeInput.ImageValidFromDate);
            objParameter[8] = new SqlParameter("@ISActive", ObjSubJobTypeInput.ISActive);
            // objParameter[8] = new SqlParameter("@ImageValidToDate", ObjSubJobTypeInput.ImageValidToDate);
            objParameter[9] = new SqlParameter("@Out", SqlDbType.Int, 10); 
            objParameter[9].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubJobTypeAddUpdate", objParameter));
        }

        public int DeleteSubJobTypeDA(SubJobTypeModel.SubJobTypeDelete ObjSubJobTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjSubJobTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjSubJobTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjSubJobTypeInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubJobTypeDelete", objParameter));
        }

        public DataTable AllSubJobTypeDA()
        {
            return (objDataAccess.ReturnDataTable("SubJobTypeList"));
        }

        public DataTable SubJobTypeImageDA()
        {
            return (objDataAccess.ReturnDataTable("SubJobTypeActiveImageReport"));
        }

        public DataTable SubJobTypeInactiveImageDA()
        {
            return (objDataAccess.ReturnDataTable("SubJobTypeInactiveImageReport"));
        }

        public DataTable SingleSubJobTypeDA(SubJobTypeModel.SubJobTypeInsert ObjSubJobTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjSubJobTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SubJobTypeSelectParticuler", objParameter));
        }
    }
}