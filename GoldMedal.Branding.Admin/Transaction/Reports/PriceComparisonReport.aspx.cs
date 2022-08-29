using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace GoldMedal.Branding.Admin.Transaction.Reports
{
    public partial class PriceComparisonReport : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        string childslno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46 || GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 44)
                {
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
            ASPxGridView1.Fields["Rate"].CellFormat.FormatString = "{0:N1}";
        }

        private DataTable GetTable2()
        {
            

            Core.Fabricator.Fabricator objsingle = new Core.Fabricator.Fabricator();

            DataTable dt = objsingle.GetPricingComparison();

            return dt;
        }
        protected string GetFileName()
        {
            return string.Format("Pricing_Comparison_For_Fabricator_{0}", DateTime.Now.ToString());
        }
        #region Export
        /// <summary>
        /// Used for export the grid in csv format
        /// </summary>
        protected void btnCsvExport_Click(object sender, EventArgs e)
        {

            //xpt = new Export();
            //FileName = GetFileName();
            //xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);

            ASPxPivotGridExporter1.ExportCsvToResponse("Pricing_Comparison_For_Fabricator_{0}", new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });

        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {

           // xpt = new Export();
           // FileName = GetFileName();
           // xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);
            ASPxPivotGridExporter1.ExportXlsToResponse("Pricing_Comparison_For_Fabricator_{0}", new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {

          //  xpt = new Export();
           // FileName = GetFileName();
           // xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, FileName, true);
            ASPxPivotGridExporter1.ExportXlsxToResponse("Pricing_Comparison_For_Fabricator_{0}", new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        #endregion Export

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
       
    }
}