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
    public partial class LiveProductJobStatusDesignerwiseReport : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit ";

        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/liveproductimage";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        private string FileNameVC = string.Empty;
        private string FileName = string.Empty;
        private IExport xpt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 132)
                {
                   
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                   
                    ASPxGridView2.DataBind();
                    ASPxGridView3.DataBind();
                   
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }
        

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetApprovedJobs();
        }
        private DataTable GetApprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetDesignerwiseSubmitedDesignApprovedByMgm(dsp);
            return dt4;
        }
        protected void ASPxGridView2_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void ASPxGridView3_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView3.DataSource = GetDispprovedJobs();
        }
        private DataTable GetDispprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetDesignerwiseSubmitedDesignDisapprovedByMgm(dsp);
            return dt4;
        }
        protected void ASPxGridView3_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            if (e.Tab.Index == 0)
            {
               // lbActiveTab.Text = "1";
                ASPxGridView2.DataBind();
            }
            else if (e.Tab.Index == 1)
            {
               // lbActiveTab.Text = "2";
                ASPxGridView3.DataBind();
            }

        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
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

        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        protected void btnXlsExport1_Click(object sender, EventArgs e)
        {
            columnhide1();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToXls(ASPxGridViewExporter2, FileName, true);
            columnshow1();
        }

        protected void btnXlsxExport1_Click(object sender, EventArgs e)
        {
            columnhide1();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter2, FileName, true);
            columnshow1();
        }

        protected void btnCsvExport1_Click(object sender, EventArgs e)
        {
            columnhide1();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter2, FileName, true);
            columnshow1();
        }
        protected void columnhide()
        {
           
            //ASPxGridView1.Columns[11].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
           
            //ASPxGridView1.Columns[0].Visible = true;
            //ASPxGridView1.Columns[11].Visible = true;
        }
        protected void columnhide1()
        {
           
            //ASPxGridView1.Columns[11].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow1()
        {
            
            //ASPxGridView1.Columns[0].Visible = true;
            //ASPxGridView1.Columns[11].Visible = true;
        }
        protected string GetFileName()
        {
            return string.Format("Live_Product_Approved_Jobs_{0}", DateTime.Now.ToString());
        }

        protected string GetFileName1()
        {
            return string.Format("Live_Product_Disapproved_Jobs_{0}", DateTime.Now.ToString());
        }
    }
}