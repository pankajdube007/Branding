using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoldMedal.Branding.Data.Printer;

namespace GoldMedal.Branding.Admin.Master.Printer
{
    public partial class PrinterFabricatorMapping : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private DataTable dts = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int row = 0;
        private const string FILE_DIRECTORY_NAME = "printer/quotation";

        PrinterDataAccess printerda = new PrinterDataAccess();


        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "";
        private string Node = "Master";
        private int rows = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Edit Block - Variable
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {

                    LoadPrinter();

                LoadFabricator();
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
        protected void LoadPrinter()
        {
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            DataTable dt = objselectall.GetPrinterForMappingAll();

            cmbPrinter.Items.Clear();
            cmbPrinter.Value = null;

            cmbPrinter.DataSource = dt;
            cmbPrinter.TextField = "name";
            cmbPrinter.ValueField = "slno";

            cmbPrinter.DataBind();

            cmbPrinter.Items.Insert(0, new ListEditItem("Select", "0"));
            cmbPrinter.SelectedIndex = 0;
        }
        protected void LoadFabricator()
        {
            Core.Fabricator.Fabricator objselectall = new Core.Fabricator.Fabricator();
            DataTable dt = objselectall.GetFabricatorForMappingAll();

            cmbFabricator.Items.Clear();
            cmbFabricator.Value = null;

            cmbFabricator.DataSource = dt;
            cmbFabricator.TextField = "name";
            cmbFabricator.ValueField = "slno";

            cmbFabricator.DataBind();

            cmbFabricator.Items.Insert(0, new ListEditItem("Select", "0"));
            cmbFabricator.SelectedIndex = 0;
        }
        protected void clean()
        {
            lbslno.Text = "0";
            lbPrinterID.Text = "0";
            lbPQslno.Text = "0";
            cmbPrinter.SelectedIndex = 0;
            cmbFabricator.SelectedIndex = 0;

            ASPxGridView1.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        #region Export

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
        /// Set the file name for the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_PrinterFabricatorMapping_{0}", DateTime.Now.ToString());
        }
        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[4].Visible = false;
            //ASPxGridView1.Columns[3].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[4].Visible = true;
            //ASPxGridView1.Columns[3].Visible = true;
        }
        #endregion Export

        /// <summary>
        /// Event perform submit and update action using DataInsert method
        /// </summary>
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
        }
        /// <summary>
        /// perform the action of submit or update  and called by CmdSubmit_Click event
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            

            string error = string.Empty;

            Core.Printer.Printer objinsert = new Core.Printer.Printer();

            if (cmbPrinter.SelectedItem.Value.ToString() == "0" || cmbFabricator.SelectedItem.Value.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select Printer and Fabricator first !','warning',3);", true);
            }
           else
            {
                Data.Printer.PrinterModel.PrinterFabricatorMappingInsert objpp = new Data.Printer.PrinterModel.PrinterFabricatorMappingInsert();

                var PrinterId = cmbPrinter.SelectedItem == null || cmbPrinter.SelectedItem.Value == null ? 0 : Convert.ToInt32(cmbPrinter.SelectedItem.Value);

                var FabricatorId = cmbFabricator.SelectedItem == null || cmbFabricator.SelectedItem.Value == null ? 0 : Convert.ToInt32(cmbFabricator.SelectedItem.Value);

                objpp.PrinterId = PrinterId;
                objpp.FabricatorId = FabricatorId;
                objpp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");


                result = objinsert.PrinterFabricatorMappingAddUpdate(objpp);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer Mapped successfully !','success',3);", true);
                }
               else if (result == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Printer or Fabricator Mapping Already Exists!','warning',3);", true);
                    clean();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Some error occured in printer mapping !','error',3);", true);
                }

                clean();
            }
        }
        /// <summary>
        /// Event  performs clean method
        /// </summary>
        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
           

            if (e.Tab.Index == 0)
            {
                LoadPrinter();
                LoadFabricator();
            }
            else if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void CmdDelete_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            
            int Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select printer  first!','warning',3);", true);
            }
            else
            {
                int result = printerda.DeletePrinterFabricatorMappingDA(Convert.ToInt64(lbslno.Text), Createuid);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mapping deleted successfully !','success',3);", true);
                    clean();
                }
               
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Some error occured  !','error',3);", true);
                }
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }

        /// <summary>
        /// returns the datatable which contains the all Printer records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt4 = objselectall.GetPrinterFabricatorMappingAll();
            return dt4;
        }
        
    }
}