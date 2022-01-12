using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.JobTypeMaping
{
    public class JobTypeMapingDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateJobTypeMapingDA(JobTypeMapingModel.JobTypeMapingInsert ObjJobTypeMappingInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@jobtypeid", ObjJobTypeMappingInput.jobtypeid);
            objParameter[1] = new SqlParameter("@subjobtypeid", ObjJobTypeMappingInput.subjobtypeid);
            objParameter[2] = new SqlParameter("@Createuid", ObjJobTypeMappingInput.createuid);
            objParameter[3] = new SqlParameter("@Createlogno", ObjJobTypeMappingInput.createlogno);
            objParameter[4] = new SqlParameter("@pagename", ObjJobTypeMappingInput.pagename);
            objParameter[5] = new SqlParameter("@slno", ObjJobTypeMappingInput.slno);
            objParameter[6] = new SqlParameter("@editusercat", ObjJobTypeMappingInput.editusercat);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobSubJobTypeMappingAddUpdate", objParameter));
        }

        public int DeleteJobTypeMapingDA(JobTypeMapingModel.JobTypeMapingDelete ObjJobTypeMappingInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypeMappingInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjJobTypeMappingInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjJobTypeMappingInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobTypeMapingDelete", objParameter));
        }

        public DataTable AllJobTypeMappingDA()
        {
            return (objDataAccess.ReturnDataTable("JobTypeMapingList"));
        }

        public DataTable SingleJobTypeMapingDA(JobTypeMapingModel.JobTypeMapingInsert ObjJobTypeMappingsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypeMappingsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobTypeMapingSelectParticuler", objParameter));
        }

        public DataTable AllSubJobForJobTypeDA(JobTypeMapingModel.JobTypeMapingInsert ObjJobTypeMappingsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@jobtypeid", ObjJobTypeMappingsingle.jobtypeid);
            return (objDataAccess.ReturnDataTableWithParameters("listofsubjobbyjobtyype", objParameter));
        }

        public DataTable AllBoardTypeForJobTypeDA(int JobTypeID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@JobTypeID", JobTypeID);
            return (objDataAccess.ReturnDataTableWithParameters("GetListOfBoardTypesForJobType", objParameter));
        }
    }
}