using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.SubJobTypeMaping
{
    public class SubJobTypeMapingDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateJobTypeMapingDA(SubJobTypeMapingModel.SubJobTypeMapingInsert ObjSubJobTypeMappingInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@subjobtypeid", ObjSubJobTypeMappingInput.subjobtypeid);
            objParameter[1] = new SqlParameter("@subsubjobtypeid", ObjSubJobTypeMappingInput.subsubjobtypeid);
            objParameter[2] = new SqlParameter("@Createuid", ObjSubJobTypeMappingInput.createuid);
            objParameter[3] = new SqlParameter("@Createlogno", ObjSubJobTypeMappingInput.createlogno);
            objParameter[4] = new SqlParameter("@pagename", ObjSubJobTypeMappingInput.pagename);
            objParameter[5] = new SqlParameter("@slno", ObjSubJobTypeMappingInput.slno);
            objParameter[6] = new SqlParameter("@editusercat", ObjSubJobTypeMappingInput.editusercat);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubJobSubSubJobTypeMappingAddUpdate", objParameter));
        }

        public int DeleteSubJobTypeMapingDA(SubJobTypeMapingModel.SubJobTypeMapingDelete ObjSubJobTypeMappingInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjSubJobTypeMappingInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjSubJobTypeMappingInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjSubJobTypeMappingInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubJobSubSubJobTypeMappingDelete", objParameter));
        }

        public DataTable AllSubJobTypeMappingDA()
        {
            return (objDataAccess.ReturnDataTable("SubJobTypeMapingList"));
        }

        public DataTable AllSubSubJobForSubJobTypeDA(SubJobTypeMapingModel.SubJobTypeMapingInsert ObjJobTypeMappingsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Subjobtypeid", ObjJobTypeMappingsingle.subjobtypeid);
            return (objDataAccess.ReturnDataTableWithParameters("listofsubsubjobbysubjobtyype", objParameter));
        }
    }
}