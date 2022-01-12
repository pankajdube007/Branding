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
    public partial class PartyApprovalPendingJobsReport : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        string childslno = string.Empty;
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
                    ASPxGridView1.DataBind();
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
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetPartyApprovalPendingJobs(dsp);
            return dt4;
        }
        protected string GetFileName()
        {
            return string.Format("Party_Approval_Pending_Jos_{0}", DateTime.Now.ToString());
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

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
    }
}