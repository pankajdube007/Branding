using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.ChangePassword
{
    public class ChangePasswordDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int ChangePassword(ChangePassword.ChangePasswordProperty ObjChangePasswordInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@createuid", ObjChangePasswordInput.createuid);
            objParameter[1] = new SqlParameter("@editusercat", ObjChangePasswordInput.editusercat);
            objParameter[2] = new SqlParameter("@Password", ObjChangePasswordInput.Password);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ResetDistPass", objParameter));
        }
    }
}