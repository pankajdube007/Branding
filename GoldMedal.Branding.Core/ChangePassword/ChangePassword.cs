using GoldMedal.Branding.Service.ChangePassword;

namespace GoldMedal.Branding.Core.ChangePassword
{
    public class ChangePassword
    {
        public int UpdateChangePassword(GoldMedal.Branding.Data.ChangePassword.ChangePassword.ChangePasswordProperty dti)
        {
            int recid = 0;

            recid = ChangePasswordServiceCall.ChangePasswordServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
    }
}