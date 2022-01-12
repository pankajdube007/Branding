using GoldMedal.Branding.Data.ChangePassword;

namespace GoldMedal.Branding.Service.ChangePassword
{
    public class ChangePasswordServiceCall
    {
        public static int ChangePasswordServiceMethod(GoldMedal.Branding.Data.ChangePassword.ChangePassword.ChangePasswordProperty dti, string DatabaseType)
        {
            int recid = 0;
            ChangePasswordDataAccess objinsert = new ChangePasswordDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ChangePassword(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
    }
}