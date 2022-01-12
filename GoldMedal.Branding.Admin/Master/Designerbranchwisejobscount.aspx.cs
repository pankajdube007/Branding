using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Master
{
    public partial class Designerbranchwisejobscount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    int branch = 0;
                branch = Convert.ToInt32(Request.QueryString["branch"]);
                if(branch==0)
                {
                    ASPxPivotGrid5.DataBind();
                    Grid5.Visible = true;
                }
                 else if (branch == 1)
                {
                    ASPxPivotGrid1.DataBind();
                    Grid1.Visible = true;
                }
                else if (branch == 2)
                {
                    ASPxPivotGrid2.DataBind();
                    Grid2.Visible = true;
                }
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
        protected void ASPxPivotGrid5_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid5.DataSource = GetTable5();
        }
        private DataTable GetTable5()
        {

            DataTable dt = new DataTable();

            int userid = Convert.ToInt32(Request.QueryString["designerid"]);
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();
            DateTime FromDate = Convert.ToDateTime(Request.QueryString["Fromdate"]);
            DateTime Todate = Convert.ToDateTime(Request.QueryString["Todate"]);


            dt = objdata.GetDesignerwiseJobDashboardCountDACore(userid, FromDate, Todate);
            lblDesignerName.Text = dt.Rows[0]["DesignerName"].ToString();

            return dt;
        }

        protected void ASPxPivotGrid1_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid1.DataSource = GetTable1();
        }
        private DataTable GetTable1()
        {

            DataTable dt = new DataTable();

            int branchid = Convert.ToInt32(Request.QueryString["branchid"]);
            DateTime FromDate = Convert.ToDateTime(Request.QueryString["Fromdate"]);
            DateTime Todate = Convert.ToDateTime(Request.QueryString["Todate"]);
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();



            dt = objdata.GetDesignerwiseJobCountDACore(branchid, FromDate, Todate);
            lblbranchname.Text = dt.Rows[0]["BranchName"].ToString();

            return dt;
        }

        protected void ASPxPivotGrid2_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid2.DataSource = GetTable2();
        }
        private DataTable GetTable2()
        {

            DataTable dt = new DataTable();

            int branchid = Convert.ToInt32(Request.QueryString["branchid"]);
            DateTime FromDate = Convert.ToDateTime(Request.QueryString["Fromdate"]);
            DateTime Todate = Convert.ToDateTime(Request.QueryString["Todate"]);
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();



            dt = objdata.GetBranchwiseJobCountDACore(branchid, FromDate, Todate);
            lblbranchname1.Text = dt.Rows[0]["BranchName"].ToString();

            return dt;
        }
    }
}