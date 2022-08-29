using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.RegionalLang
{
   public  class RegionalLangDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllJobTypeMappingDA()
        {
            return (objDataAccess.ReturnDataTable("RegionalLangList"));
        }
        public DataTable AllBranchDA()
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            return (objDataAccess.ReturnDataTable("BranchList"));
        }

        public DataTable AllSubJobTypeDA()
        {
            return (objDataAccess.ReturnDataTable("SubJobTypeList"));
        }

        public DataTable AllSubJobForJobTypeDA(RegionalLangModel.RegionalLangInsert ObjJobTypeMappingsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@jobtypeid", ObjJobTypeMappingsingle.jobtypeid);
            return (objDataAccess.ReturnDataTableWithParameters("listofsubjobbyjobtyype", objParameter));
        }
        public int AddUpdateRegionalLangDA(RegionalLangModel.RegionalLangInsert ObjJobTypeMappingInput)
        {
            SqlParameter[] objParameter = new SqlParameter[10];
            objParameter[0] = new SqlParameter("@jobtypeid", ObjJobTypeMappingInput.jobtypeid);
            objParameter[1] = new SqlParameter("@subjobtypeid", ObjJobTypeMappingInput.subjobtypeid);
            objParameter[2] = new SqlParameter("@branchId", ObjJobTypeMappingInput.BranchID);
            objParameter[3] = new SqlParameter("@isactive", ObjJobTypeMappingInput.isactive);
            objParameter[4] = new SqlParameter("@Createuid", ObjJobTypeMappingInput.createuid);
            objParameter[5] = new SqlParameter("@Createlogno", ObjJobTypeMappingInput.createlogno);
            objParameter[6] = new SqlParameter("@pagename", ObjJobTypeMappingInput.pagename);
            objParameter[7] = new SqlParameter("@slno", ObjJobTypeMappingInput.slno);
            objParameter[8] = new SqlParameter("@editusercat", ObjJobTypeMappingInput.editusercat);
            objParameter[9] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[9].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("RegionalLangAddUpdate", objParameter));
        }
        public int DeleteJobTypeMapingDA(RegionalLangModel.RegionalLangDelete ObjJobTypeMappingInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypeMappingInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjJobTypeMappingInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjJobTypeMappingInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("RegionalLangDelete", objParameter));
        }
        public DataTable RegionalLangTypeDA(RegionalLangModel.RegionalLangInsert ObjProductTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjProductTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("RegionalLangSelectParticuler", objParameter));
        }
    }
}
