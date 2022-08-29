using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.Report;
using System;
using System.Data;
using System.Linq;
using System.Threading;

namespace GoldMedal.Branding.Admin.Transaction.Reports
{
    public partial class JobRequestAgingReport : System.Web.UI.Page
    {
        #region Initialization
        private string FileName = string.Empty;
        private DataTable dt = new DataTable();
        private IExport xpt = null;
        private readonly IGoldMedia _goldMedia;
        #endregion Initialization
        #region PageEvent
        public JobRequestAgingReport()
        {
            _goldMedia = new GoldMedia();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    DateTime fdt = new DateTime(DateTime.Now.Year, 4, 1);
                    if (DateTime.Now.Month > 3)
                    {
                        fdt = new DateTime(DateTime.Now.Year, 4, 1);
                    }
                    else
                    {
                        fdt = new DateTime(DateTime.Now.Year - 1, 4, 1);
                    }
                    txtFromDate.Text = fdt.ToString("dd/MM/yyyy");
                    txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 0;
                    LoadBranch();
                    ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }
        protected void LoadBranch()
        {
            Core.BillUpload.IBillUpload objselectsingle = new Core.BillUpload.BillUpload();
            DataTable dt = objselectsingle.GetBranchAll();
            cmbBranch.DataSource = dt;
            cmbBranch.TextField = "locnm";
            cmbBranch.ValueField = "slno";
            cmbBranch.DataBind();
        }
        #endregion PageEvent

        #region Event
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

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        #endregion Event

        #region Method

        protected void columnhide()
        {
            ASPxGridView1.Columns[7].Visible = false;
        }

        protected void columnshow()
        {
            ASPxGridView1.Columns[7].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("Transaction_BillUploadReport_{0}", DateTime.Now.ToString());
        }

        private DataTable GetTable()
        {
            DataTable dt4 = new DataTable();
            ReportModel.ReportInsert dtsingle = new ReportModel.ReportInsert();
            Core.Report.Report objselectsingle = new Core.Report.Report();
            string BranchIDs = "";
            for (int i = 0; i < cmbBranch.Items.Count; i++)
            {
                if (cmbBranch.Items[i].Selected == true)
                {
                    BranchIDs += cmbBranch.Items[i].Value.ToString() + ",";
                }
            }
            BranchIDs = BranchIDs.TrimEnd(',');

            string FromDate = string.Empty, ToDate = string.Empty;

            string[] st1 = txtFromDate.Text.Split('/');
            if (st1.Count() > 2)
            {
                FromDate = st1[1] + "/" + st1[0] + "/" + st1[2];
            }

            string[] st2 = txtToDate.Text.Split('/');

            if (st2.Count() > 2)
            {
                ToDate = st2[1] + "/" + st2[0] + "/" + st2[2];
            }

            dt4 = objselectsingle.GetJobRequestAgingReport(BranchIDs, FromDate, ToDate);
            return dt4;
        }
        protected void CmdSearch_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
       
        #endregion Method

        #region Export

        /// <summary>
        /// Used for export the grid in csv format
        /// </summary>
        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        /// <summary>
        /// Used for export the grid in pdf format
        /// </summary>
        protected void btnPdfExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToPdf(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        /// <summary>
        /// Used for export the grid in rtf format
        /// </summary>
        protected void btnRtfExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToRtf(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        #endregion Export

 
    }
}