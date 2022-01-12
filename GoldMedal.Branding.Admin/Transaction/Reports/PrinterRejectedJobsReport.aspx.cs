using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GoldMedal.Branding.Admin.Transaction.Reports
{
    public partial class PrinterRejectedJobsReport : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "1")
                {
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                    
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            //dsp.printer = 4;
            dsp.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectall = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            dt4 = objselectall.GetRejectedAndShortJobsForPrinter(dsp);
            return dt4;
        }
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
        protected string GetFileName()
        {
            return string.Format("Printer_Rejected_Jobs_{0}", DateTime.Now.ToString());
        }
        #region Export
        /// <summary>
        /// Used for export the grid in csv format
        /// </summary>
        protected void btnCsvExport_Click(object sender, EventArgs e)
        {

            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);

        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {

            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);

        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {

            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, FileName, true);

        }

        #endregion Export
    }
}