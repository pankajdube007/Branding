using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoldMedal.Branding.Data.Dashboard;

namespace GoldMedal.Branding.Admin.Master
{
    public partial class Helpdesk : System.Web.UI.Page
    {

        #region Initialization

        private DataTable dt = new DataTable();
        private int rows = 0;
        private int flag = 0;
        DashboardDataAccess da = new DashboardDataAccess();

        #endregion Initialization

        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    BindData();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
                }
        }
        private bool CheckUserRightsForMaster(int UserID)
        {
            bool success = false;

            Data.MasterMenu.MasterMenuModel.UserCheck dst = new Data.MasterMenu.MasterMenuModel.UserCheck();
            dst.UserID = UserID;
            Core.MasterMenu.MasterMenu objcheck = new Core.MasterMenu.MasterMenu();
            DataTable result = objcheck.UserCheckMethod(dst);

            if (Convert.ToInt32(result.Rows[0]["Status"]) == 1)
            {
                success = true;
            }

            return success;
        }
        private void BindData()
        {
            ASPxGridView1.DataSource = GetBrandingUsers();
            ASPxGridView1.DataBind();
        }

        private DataTable GetBrandingUsers()
        {
            return dt = da.GetBrandingUsers();
        }

        protected void ASPxCallback_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {

        }
    }
}