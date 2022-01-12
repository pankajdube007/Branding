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
    public partial class PrinterAccountReportAudit : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        string childslno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46)
                {
                    ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }

            }
        }
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            //dsp.printer = 4;
            dsp.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectall = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            dt4 = objselectall.GetPrinterAccountReportAudit(dsp);
            return dt4;
        }
        protected void columnhide()
        {

            // ASPxGridView1.Columns[7].Visible = false;
        }
        protected void columnshow()
        {

            // ASPxGridView1.Columns[7].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("Printer_Account_Report_Audit_{0}", DateTime.Now.ToString());
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
    }
}