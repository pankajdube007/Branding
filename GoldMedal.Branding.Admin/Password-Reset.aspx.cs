using GoldMedal.Branding.Core.Common;
using System;
using System.Web;

namespace GoldMedal.Branding.Admin
{
    public partial class Password_Reset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mpeImage.Show();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            int result = 0;
            Data.ChangePassword.ChangePassword.ChangePasswordProperty dst = new Data.ChangePassword.ChangePassword.ChangePasswordProperty();
            var pass = HttpUtility.HtmlEncode(txtpassword.Text.Trim());
            var conpass = HttpUtility.HtmlEncode(txtconfirmpassword.Text.Trim());

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(pass)))
            {
                lbmsg.Text = "Password Should not be empty";
            }

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(conpass)))
            {
                lbmsg.Text = "Confirm Password Should not be empty";
            }
            dst.Password = ValidateDataType.EnsureMaximumLength(pass, 100);
            dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
            Core.ChangePassword.ChangePassword objinsert = new Core.ChangePassword.ChangePassword();
            result = objinsert.UpdateChangePassword(dst);
            if (result == 2)
            {
                lbmsg.Text = "Password Reset Successfully";
            }
            else
            {
                lbmsg.Text = "Something Wrong....";
            }
        }
    }
}