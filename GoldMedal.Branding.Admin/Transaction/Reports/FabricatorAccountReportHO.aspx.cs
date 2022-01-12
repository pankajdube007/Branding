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
    public partial class FabricatorAccountReportHO : System.Web.UI.Page
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
            dt4 = objselectall.GetFabricatorAccountReportHO(dsp);
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
            return string.Format("Fabricator_Account_Report_HO_{0}", DateTime.Now.ToString());
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