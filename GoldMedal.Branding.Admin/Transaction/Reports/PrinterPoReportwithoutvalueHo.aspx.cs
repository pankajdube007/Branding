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
    public partial class PrinterPoReportwithoutvalueHo : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        string childslno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {

                    ASPxGridView1.DataBind();
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
    protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        private DataTable GetTable1()
        {
            Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle = new Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO();
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.AssigntoPrinter.Assigntoprinter objselectsingle = new Core.AssigntoPrinter.Assigntoprinter();
            DataTable dt = objselectsingle.GetPrinterPOwithoutValueHoReport(dtsingle);

            return dt;
        }
        protected void columnhide()
        {

             ASPxGridView1.Columns[10].Visible = false;
        }
        protected void columnshow()
        {

              ASPxGridView1.Columns[10].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("PrinterPO_Report_Audit_{0}", DateTime.Now.ToString());
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

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }
    }
}