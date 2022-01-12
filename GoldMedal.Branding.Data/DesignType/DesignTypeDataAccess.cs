using GoldMedal.Branding.Data.DesignType;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data
{
    public class DesignTypeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateDesignTypeDA(DesignTypeModel.DesignTypeInsert ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@Name", ObjDesignTypeInput.Name);
            objParameter[1] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[4] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[5] = new SqlParameter("@editusercat", ObjDesignTypeInput.editusercat);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DesignTypeAddUpdate", objParameter));
        }

        public int DeleteDesignTypeDA(DesignTypeModel.DesignTypeDelete ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DesignTypeDelete", objParameter));
        }

        public DataTable AllDesignTypeDA()
        {
            return (objDataAccess.ReturnDataTable("DesignTypeList"));
        }

        public DataTable SingleDesignTypeDA(DesignTypeModel.DesignTypeInsert ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("DesignTypeSelectParticuler", objParameter));
        }
    }
}