using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.Reports
{
    public partial class DisapprovedJobReport : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    txtFrmDate.Text = DateTime.Now.AddDays(-30).Date.ToString("dd/MM/yyyy");
                txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                BindBranch();
                lbActiveTab.Text = "1";
                gvDisapprovedJobs.DataBind();
                }
               
            }
            txtToDate.MaxDate = DateTime.Now;
            txtFrmDate.MaxDate = DateTime.Now.AddDays(-1);
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
        protected void BindBranch()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            DataSet dsaselect = objselectsingleselect.AllBranchSelected(param);

            lbBranch.Items.Clear();
            lbBranch.Value = null;
            lbBranch.DataSource = dsaselect.Tables[1];
            lbBranch.TextField = "locnm";
            lbBranch.ValueField = "branchid";
            lbBranch.DataBind();
            //lbBranch.Items.Insert(0, new ListEditItem("Select all", 0));

            if (dsaselect.Tables[0].Rows.Count > 0)
            {
                lbBranch.SelectedItem = lbBranch.Items.FindByValue(dsaselect.Tables[0].Rows[0]["homebranchid"].ToString());
            }
        }

        


       


        private DataTable GetTable1()
        {
            DataTable dt = new DataTable();
            //int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            if (frmDate == "0001-01-01")
            {
                frmDate = "";
            }
            string toDate = txtToDate.Date.ToString("yyyy-MM-dd");
            if (toDate == "0001-01-01")
            {
                toDate = "";
            }

            if (frmDate != "" && toDate != "")
            {
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                dt = objselectall.ListOfDisapprovedJobRequests(frmDate, toDate, branchIDs);
            }

            return dt;
        }

        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            if (e.Tab.Index == 0)
            {
                lbActiveTab.Text = "1";
                gvDisapprovedJobs.DataBind();
            }
        }

        protected void gvDisapprovedJobs_DataBinding(object sender, EventArgs e)
        {
            gvDisapprovedJobs.DataSource = GetTable1();
        }

        protected void CmdSearch_Click(object sender, EventArgs e)
        {
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

            if (branchIDs == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select atleast one branch !','warning',3);", true);
                return;
            }


            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            if (frmDate == "0001-01-01")
            {
                frmDate = "";
            }

            string toDate = txtToDate.Date.ToString("yyyy-MM-dd");
            if (toDate == "0001-01-01")
            {
                toDate = "";
            }

            if (frmDate != "" && toDate != "")
            {
                DateTime dtFrm = Convert.ToDateTime(txtFrmDate.Date.ToString("yyyy-MM-dd"));
                DateTime dtTo = Convert.ToDateTime(txtToDate.Date.ToString("yyyy-MM-dd"));

                if (dtFrm <= dtTo)
                {
                    if (lbActiveTab.Text == "1")
                    {
                        gvDisapprovedJobs.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('From Date should be less then To Date.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select both the dates.');", true);
            }
        }

        #region Export

        protected void columnhide()
        {
            //ASPxGridView1.Columns[0].Visible = false;
            //ASPxGridView1.Columns[11].Visible = false;
        }
        protected void columnshow()
        {
            //ASPxGridView1.Columns[0].Visible = true;
            //ASPxGridView1.Columns[11].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("DisapprovedJobs_{0}", DateTime.Now.ToString());
        }

        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        #endregion Export
    }
}