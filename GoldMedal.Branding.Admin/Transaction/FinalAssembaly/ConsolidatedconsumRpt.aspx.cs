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

namespace GoldMedal.Branding.Admin.Transaction.FinalAssembaly
{
    public partial class ConsolidatedconsumRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    txtFrmDate.Text = "01/04/" + DateTime.Now.ToString("yyyy");
                    txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    ASPxPageControl1.ActiveTabIndex = 0;
                    ASPxGridView1.DataBind();
                }

            }
            txtToDate.MaxDate = DateTime.Now;
            txtFrmDate.MaxDate = DateTime.Now.AddDays(-1);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            if (e.Tab.Index == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxCallback2_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void CmdSearch_Click(object sender, EventArgs e)
        {
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
                    ASPxGridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('From Date should be less than To Date.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select both the dates.');", true);
            }
        }



        private DataTable GetTable2()
        {
            DataTable dtConsumption = new DataTable();
            if (txtFrmDate.Date.ToString().Trim() != "" && txtToDate.Date.ToString().Trim() != "")
            {
                string frmDate = txtFrmDate.Date.ToString("dd-MMM-yyyy HH:mm:ss");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                string toDate = txtToDate.Date.ToString("dd-MMM-yyyy HH:mm:ss");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }

                if (frmDate != "" && toDate != "")
                {
                    Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                    dtConsumption = objselectall.ConsolidatedConsumptionRpt(frmDate, toDate);
                }
            }
            return dtConsumption;
        }

        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
            Export xpt = new Export();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, "ConsolidatedConsumptionReport", true);
        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            Export xpt = new Export();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, "ConsolidatedConsumptionReport", true);
        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            Export xpt = new Export();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, "ConsolidatedConsumptionReport", true);
        }


    }
}