using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.Unit
{
    public class UnitDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateUnitDA(UnitModel.UnitInsert ObjUnitInput)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@Name", ObjUnitInput.Name);
            objParameter[1] = new SqlParameter("@Createuid", ObjUnitInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjUnitInput.createlogno);
            objParameter[3] = new SqlParameter("@pagename", ObjUnitInput.pagename);
            objParameter[4] = new SqlParameter("@slno", ObjUnitInput.slno);
            objParameter[5] = new SqlParameter("@editusercat", ObjUnitInput.editusercat);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UnitAddUpdate", objParameter));
        }

        public int DeleteUnitDA(UnitModel.UnitDelete ObjUnitInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjUnitInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjUnitInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjUnitInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UnitDelete", objParameter));
        }

        public DataTable AllUnitDA()
        {
            return (objDataAccess.ReturnDataTable("UnitList"));
        }

        public DataTable SingleUnitDA(UnitModel.UnitInsert ObjUnitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjUnitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("UnitSelectParticuler", objParameter));
        }
    }
}