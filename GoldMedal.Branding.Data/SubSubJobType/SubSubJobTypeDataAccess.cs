using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.SubSubJobType
{
    public class SubSubJobTypeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateSubSubJobTypeDA(SubSubJobTypeModel.SubSubJobTypeInsert ObjSubSubJobTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@Name", ObjSubSubJobTypeInput.Name);
            objParameter[1] = new SqlParameter("@Createuid", ObjSubSubJobTypeInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjSubSubJobTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@pagename", ObjSubSubJobTypeInput.pagename);
            objParameter[4] = new SqlParameter("@slno", ObjSubSubJobTypeInput.slno);
            objParameter[5] = new SqlParameter("@editusercat", ObjSubSubJobTypeInput.editusercat);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubSubJobTypeAddUpdate", objParameter));
        }

        public int DeleteSubSubJobTypeDA(SubSubJobTypeModel.SubSubJobTypeDelete ObjSubSubJobTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjSubSubJobTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjSubSubJobTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjSubSubJobTypeInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubSubJobTypeDelete", objParameter));
        }

        public DataTable AllSubSubJobTypeDA()
        {
            return (objDataAccess.ReturnDataTable("SubSubJobTypeList"));
        }

        public DataTable SingleSubSubJobTypeDA(SubSubJobTypeModel.SubSubJobTypeInsert ObjSubSubJobTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjSubSubJobTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SubSubJobTypeSelectParticuler", objParameter));
        }
    }
}