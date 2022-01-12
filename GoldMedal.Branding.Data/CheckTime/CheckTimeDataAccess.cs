using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.CheckTime
{
    public class CheckTimeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable GetTimeForNodeDA(CheckTimeModel.CheckTimeInsert ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Node", ObjDesignTypesingle.Node);
            return (objDataAccess.ReturnDataTableWithParameters("getchecktimebynode", objParameter));
        }
    }
}