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
    public partial class FabricatorDcReportBranch : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        string childslno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
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
            Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dsp = new Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty();
            dsp.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FabricatorDesignSubmit.FabricatorDesignSubmit objselectall = new Core.FabricatorDesignSubmit.FabricatorDesignSubmit();
            dt4 = objselectall.GetFabricatorDCReportBranch(dsp);
            return dt4;
        }
        protected void columnhide()
        {

            ASPxGridView1.Columns[11].Visible = false;
        }
        protected void columnshow()
        {

            ASPxGridView1.Columns[11].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("FabricatorDC_Report_Branch_{0}", DateTime.Now.ToString());
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