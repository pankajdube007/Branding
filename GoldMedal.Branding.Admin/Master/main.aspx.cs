using System;
using System.Data;

namespace GoldMedal.Branding.Admin.Master
{
    public partial class main : System.Web.UI.Page
    {
        int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid")) == 132)
                {
                    divBranchwiseJobsCount.Visible = true;
                    ASPxPivotGrid5.DataBind();
                }
                if (CheckUserRightsForMaster(userID))
                {
                    divdispatchdashboard.Visible = true;
                    ASPxPivotGrid1.DataBind();
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
        protected void ASPxPivotGrid5_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid5.DataSource = GetTable5();
        }
        private DataTable GetTable5()
        {
            
            DataTable dt = new DataTable();
            
            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

      
          
                dt = objdata.GetBranchwiseJobDashboardCountDACore(userid);
            
            
            return dt;
        }

        protected void ASPxPivotGrid1_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid1.DataSource = GetTable();
        }

        private DataTable GetTable()
        {

            DataTable dt = new DataTable();

            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();



            dt = objdata.GetBranchwiseDispatchJobDashboardCountDACore(userid);


            return dt;
        }
    }
}