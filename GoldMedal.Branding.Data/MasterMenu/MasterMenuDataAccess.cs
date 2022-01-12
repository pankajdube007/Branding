using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.MasterMenu
{
    public class MasterMenuDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable UserCheckMasterMenuDA(MasterMenuModel.UserCheck ObjUserCheck)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserID", ObjUserCheck.UserID);
            return objDataAccess.ReturnDataTableWithParameters("UserCheckForMasterMenu", objParameter);
        }
    }
}