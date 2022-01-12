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
using GoldMedal.Branding.Data.PrinterQuotation;

namespace GoldMedal.Branding.Admin.Master.Printer
{
    public partial class PrinterPricingMaster : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private DataTable dts = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int row = 0;
        private const string FILE_DIRECTORY_NAME = "printer/quotation";

        PrinterDataAccess printerda = new PrinterDataAccess();
        PrinterQuotationDataAccess da = new PrinterQuotationDataAccess();

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_PrinterPricingMaster";
        private string Node = "Master";
        private int rows = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Edit Block - Variable

        #region Page Event

        /// <summary>
        /// In the Page Lode lblslno is 0 by which program deside the process of submit button which can be submit the record or update the record and also lode the grid and combobox of area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Session.Timeout = 7200;

            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    BindUnits();
                LoadPrinter();

                ViewState["_PageID"] = (new Random()).Next().ToString();

                lbslno.Text = "0";
                ASPxPageControl1.ActiveTabIndex = 1;
                ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
            createSessionData();
        }

        #endregion Page Event

        #region Method
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
        /// <summary>
        /// Fill combox box for the list of area
        /// </summary>

        protected void LoadPrinter()
        {
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            DataTable dt = objselectall.GetPrinterAll();

            cmbPrinter.Items.Clear();
            cmbPrinter.Value = null;

            cmbPrinter.DataSource = dt;
            cmbPrinter.TextField = "name";
            cmbPrinter.ValueField = "slno";

            cmbPrinter.DataBind();

            cmbPrinter.Items.Insert(0, new ListEditItem("Select","0"));
            cmbPrinter.SelectedIndex = 0;
        }

        protected void LoadPrinterQT(long PrinterID)
        {
            Core.PrinterQuotation.PrinterQuotation objselectsingle = new Core.PrinterQuotation.PrinterQuotation();
            DataTable dt = objselectsingle.GetPrinterQuotationForPrinter(PrinterID);

            cmbPrinterQT.Items.Clear();
            cmbPrinterQT.Value = null;

            cmbPrinterQT.DataSource = dt;
            cmbPrinterQT.TextField = "PrinterQuotationNumber";
            cmbPrinterQT.ValueField = "slno";

            cmbPrinterQT.DataBind();

            cmbPrinterQT.Items.Insert(0, new ListEditItem("Select", "0"));
            cmbPrinterQT.SelectedIndex = 0;
        }

        protected void LoadPrinterBranch(int PrinterID)
        {
            DataTable dt = da.GetBranchForPrinterDA(PrinterID);

            cmbBranch.Items.Clear();
            cmbBranch.Value = null;

            cmbBranch.DataSource = dt;
            cmbBranch.DataBind();

            cmbBranch.Items.Insert(0, new ListEditItem("Select", "0"));
            cmbBranch.SelectedIndex = 0;
        }

        protected void LoadUnit()
        {
            foreach (GridViewRow row in gvPricing.Rows)
            {
                DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable dtunit = db.GetUnits();

                ddlUnit.Items.Clear();

                ddlUnit.DataSource = dtunit;
                ddlUnit.DataBind();

                ddlUnit.Items.Insert(0, "Select");
            }
        }

        protected void BindUnits()
        {
            Core.JobType.JobType db = new Core.JobType.JobType();
            DataTable dtunit = db.GetUnits();

            cmbUnit.Items.Clear();
            cmbUnit.Value = null;

            cmbUnit.DataSource = dtunit;
            cmbUnit.DataBind();

            cmbUnit.Items.Insert(0, new ListEditItem("Select", "0"));
            cmbUnit.SelectedIndex = 0;
        }


        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            lbPrinterID.Text = "0";
            lbPQslno.Text = "0";
            cmbPrinter.SelectedIndex = 0;
            cmbPrinterQT.Items.Clear();
            cmbPrinterQT.SelectedIndex = -1;

            cmbBranch.SelectedIndex = -1;
            cmbBranch.Items.Clear();

            gvPricing.DataSource = null;
            gvPricing.DataBind();

            hfEMaterialID.Value = "0";
            hfEPrinterID.Value = "0";
            hfEBranchID.Value = "0";
            lblPrinter.Text = "";
            lblBranchName.Text = "";
            lblMaterial.Text = "";
            txtEffectiveFromDate.Text = "";
            txtRate.Text = "";
            cmbUnit.SelectedIndex = 0;

            ASPxGridView1.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void clean2()
        {
            lbslno.Text = "0";
            lbPrinterID.Text = "0";
            lbBranchID.Text = "0";
            cmbPrinter.SelectedIndex = 0;
            cmbBranch.Items.Clear();
            cmbBranch.SelectedIndex = 0;

            gvPricing.DataSource = null;
            gvPricing.DataBind();
        }

        /// <summary>
        /// Set the file name for the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_PrinterPricingMaster_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            //ASPxGridView1.Columns[2].Visible = false;
            //ASPxGridView1.Columns[3].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            //ASPxGridView1.Columns[2].Visible = true;
            //ASPxGridView1.Columns[3].Visible = true;
        }

        /// <summary>
        /// returns the datatable which contains the all Printer records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt4 = objselectall.GetPrinterPricingAll();
            return dt4;
        }

        /// <summary>
        /// perform the action of submit or update  and called by CmdSubmit_Click event
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            int result2 = 0;
          
            string error = string.Empty;

            Core.Printer.Printer objinsert = new Core.Printer.Printer();

            if (cmbPrinter.SelectedItem.Value.ToString() == "0" || cmbBranch.SelectedItem.Value.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select printer and branch first !','warning',3);", true);
            }
            else if (ValidatePricing()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + ValidatePricing()[1] + "','warning',3);", true);

                foreach (GridViewRow row in gvPricing.Rows)
                {
                    #region Unit Binding

                    DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");

                    Core.JobType.JobType dbUnit = new Core.JobType.JobType();
                    DataTable Unitdt = dbUnit.GetUnits();
                    ddlUnit.Items.Clear();
                    ddlUnit.DataSource = Unitdt;
                    ddlUnit.DataBind();
                    ddlUnit.Items.Insert(0, new ListItem("Select", "0"));

                    string lblUnit = (row.FindControl("hfUnit") as HiddenField).Value;

                    if (!string.IsNullOrEmpty(lblUnit))
                    {
                        ddlUnit.Items.FindByValue(lblUnit).Selected = true;
                    }
                    else
                    {
                        lblUnit = "0";
                    }

                    #endregion Unit Binding
                }
            }
            else
            {
                Data.Printer.PrinterModel.PrinterPricingInsert objpp = new Data.Printer.PrinterModel.PrinterPricingInsert();

                int a = gvPricing.PageIndex;

                for (int i = 0; i < gvPricing.PageCount; i++)
                {
                    gvPricing.SetPageIndex(i);

                    foreach (GridViewRow row in gvPricing.Rows)
                    {
                        HiddenField hfslno = (HiddenField)row.FindControl("hfslno");
                        HiddenField hfPrinterID = (HiddenField)row.FindControl("hfPrinterID");
                        HiddenField hfMaterialID = (HiddenField)row.FindControl("hfMaterialID");
                        HiddenField hfBranchID = (HiddenField)row.FindControl("hfBranchID");
                        DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");

                        TextBox txtRate = (TextBox)row.FindControl("txtRate");

                        ASPxDateEdit txtEffectiveFromDate = (ASPxDateEdit)row.FindControl("txtEffectiveFromDate");

                        string Material = row.Cells[1].Text;


                        if (ddlUnit.SelectedItem.Value != "0" && txtRate.Text != "" && txtEffectiveFromDate.Text != "")
                        {
                            objpp.slno = hfslno.Value == "" ? 0 :Convert.ToInt64(hfslno.Value);
                            objpp.PrinterID = Convert.ToInt64(cmbPrinter.SelectedItem.Value);
                            objpp.BranchID = Convert.ToInt32(cmbBranch.SelectedItem.Value);
                            objpp.MaterialID = Convert.ToInt64(hfMaterialID.Value);
                            objpp.UnitID = Convert.ToInt64(ddlUnit.SelectedItem.Value);
                            objpp.Rate = Convert.ToDecimal(txtRate.Text);
                            objpp.EffectiveFromDate = txtEffectiveFromDate.Text;

                            objpp.Createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                            objpp.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                            objpp.pagename = HttpContext.Current.Request.Url.ToString();

                            result2 = objinsert.PrinterPricingAddUpdate(objpp);

                            if (result2 == -1)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                                break;
                            }
                        }
                    }
                }

                gvPricing.SetPageIndex(a);

                if (result2 == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer pricing updated successfully !','success',3);", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Some error occured in adding pricing !','error',3);", true);
                }

                clean();
            }
        }

        protected void UpdatePrice()
        {
            int result = 0;

            Core.Printer.Printer objinsert = new Core.Printer.Printer();

            if (lbslno.Text == "0" || hfEPrinterID.Value == "0" || hfEBranchID.Value == "0" || hfEMaterialID.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select printer pricing first !','warning',3);", true);
            }
            else if (cmbUnit.SelectedItem.Value.ToString() == "0" || txtRate.Text == "" || txtRate.Text == "0" || txtEffectiveFromDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter all the values','warning',3);", true);
            }
            else
            {
                Data.Printer.PrinterModel.PrinterPricingInsert objpp = new Data.Printer.PrinterModel.PrinterPricingInsert();

                objpp.slno = Convert.ToInt64(lbslno.Text);
                objpp.PrinterID = Convert.ToInt64(hfEPrinterID.Value);
                objpp.BranchID = Convert.ToInt32(hfEBranchID.Value);
                objpp.MaterialID = Convert.ToInt64(hfEMaterialID.Value);
                objpp.UnitID = Convert.ToInt64(cmbUnit.SelectedItem.Value);
                objpp.Rate = Convert.ToDecimal(txtRate.Text);
                objpp.EffectiveFromDate = txtEffectiveFromDate.Text;

                objpp.Createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                objpp.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                objpp.pagename = HttpContext.Current.Request.Url.ToString();

                result = objinsert.PrinterPricingAddUpdate(objpp);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer pricing updated successfully !','success',3);", true);
                    this.mpeEdit.Hide();
                    clean();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Some error occured in adding pricing !','error',3);", true);
                }
            }
        }

        private string[] ValidatePricing()
        {
            string[] result = new string[2];

            int flag = 0;
            int flag2 = 0;
            int flag3 = 0;
            int flag4 = 0;

            int a = gvPricing.PageIndex;

            for (int i = 0; i < gvPricing.PageCount; i++)
            {
                gvPricing.SetPageIndex(i);

                foreach (GridViewRow row in gvPricing.Rows)
                {
                    if (result[1] == "Please check child validation.!")
                    {
                        break;
                    }

                    HiddenField hfslno = (HiddenField)row.FindControl("hfslno");
                    HiddenField hfPrinterID = (HiddenField)row.FindControl("hfPrinterID");
                    HiddenField hfBranchID = (HiddenField)row.FindControl("hfBranchID");
                    HiddenField hfMaterialID = (HiddenField)row.FindControl("hfMaterialID");

                    DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");

                    TextBox txtRate = (TextBox)row.FindControl("txtRate");

                    ASPxDateEdit txtEffectiveFromDate = (ASPxDateEdit)row.FindControl("txtEffectiveFromDate");

                    string Material = row.Cells[1].Text;


                    if (ddlUnit.SelectedItem.Value == "0" && txtRate.Text == "" && txtEffectiveFromDate.Text == "")
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;

                        flag2 = 1;

                        if (ddlUnit.SelectedItem.Value == "0" || txtRate.Text == "" || txtEffectiveFromDate.Text == "")
                        {
                            flag3 = 1;
                        }
                        else
                        {
                            flag4 = 1;
                        }
                    }
                }
            }

            gvPricing.SetPageIndex(a);

            if (flag == 1 && flag2 == 0)
            {
                result[0] = "true";
                result[1] = "Please enter pricing for atleast one material!";
                return result;
            }

            if (flag == 1 && flag3 == 1)
            {
                result[0] = "true";
                result[1] = "Please check pricing validation!";
            }

            if (flag == 0 && flag3 == 1 && flag4 == 1)
            {
                result[0] = "true";
                result[1] = "Please check pricing validation!";
            }

            return result;
        }

        private void LoadPricing()
        {
            DataTable dt6 = new DataTable();
            Data.Printer.PrinterModel.PrinterInsert dchildlist = new Data.Printer.PrinterModel.PrinterInsert();
            dchildlist.slno = Convert.ToInt32(cmbPrinter.SelectedItem.Value);
            dchildlist.BranchID = Convert.ToInt32(cmbBranch.SelectedItem.Value);
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt6 = objselectall.GetDetailOfPricingListForPrinter(dchildlist);
            Session[ViewState["_PageID"].ToString() + "Pricing"] = dt6;
            gvPricing.DataSource = dt6;
            gvPricing.DataBind();
        }

        protected void createSessionData()
        {
            if (Session[ViewState["_PageID"].ToString() + "Pricing"] != null)
            {
                dts = (DataTable)Session[ViewState["_PageID"].ToString() + "Pricing"];
            }
            else
            {
                dts = new DataTable();
                //DataColumn pk = dts.Columns.Add("slno", typeof(System.Int64));
                //pk.AllowDBNull = false;
                //pk.Unique = true;
                //pk.AutoIncrement = true;
                //pk.AutoIncrementSeed = 1;
                //pk.AutoIncrementStep = 1;
                dts.Columns.Add("slno", typeof(System.String));
                dts.Columns.Add("PrinterID", typeof(System.String));
                dts.Columns.Add("MaterialID", typeof(System.String));
                dts.Columns.Add("Rate", typeof(System.String));
                dts.Columns.Add("UnitID", typeof(System.String));
                dts.Columns.Add("EffectiveFromDate", typeof(System.String));
                dts.Columns.Add("BranchID", typeof(System.String));
            }
        }

        protected void GetUploadedJobRequestFiles(long slno, int flag)
        {
            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();
            param.slno = slno;
            param.flag = flag;
            Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            DataTable dtResult = objData.JobRequestChildFilesDACore(param);
            if (dtResult.Rows.Count > 0)
            {
                rptImages.DataSource = dtResult;
                rptImages.DataBind();
                hdNoRecord.Visible = false;
            }
            else
            {
                rptImages.DataSource = null;
                rptImages.DataBind();
                hdNoRecord.Visible = true;
            }
        }

        #endregion Method

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

        #endregion Export

        #region Event

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean2();

            if (e.Tab.Index == 0)
            {
                LoadPrinter();
            }
            else if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
        }

        /// <summary>
        /// Bind the grid viwe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }


        protected void CmdEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            long FieldTripID = Convert.ToInt64(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            CheckEditBlock(Convert.ToInt64(lbslno.Text));
        }

        /// <summary>
        /// Used for delete the record
        /// </summary>
        protected void CmdDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            long Createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
            int Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select printer pricing first!','warning',3);", true);
            }
            else
            {
                int result = printerda.DeletePrinterPriceDA(Convert.ToInt64(lbslno.Text), Createlogno, Createuid);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer pricing deleted successfully !','success',3);", true);
                    clean();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Some error occured in adding pricing !','error',3);", true);
                }
            }
        }

        protected void CheckEditBlock(long slno)
        {
            Data.Printer.PrinterModel.PrinterPricingInsert dtsingle = new Data.Printer.PrinterModel.PrinterPricingInsert();
            dtsingle.slno = slno;

            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();

            DataTable dt = objselectsingle.GetPrinterPriceSingle(dtsingle);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    hfEPrinterID.Value = Convert.ToString(dt.Rows[0]["PrinterID"]);
                    hfEMaterialID.Value = Convert.ToString(dt.Rows[0]["MaterialID"]);
                    hfEBranchID.Value = Convert.ToString(dt.Rows[0]["BranchID"]);
                    lblBranchName.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                    lblPrinter.Text = Convert.ToString(dt.Rows[0]["Printer"]);
                    lblMaterial.Text = Convert.ToString(dt.Rows[0]["Material"]);
                    cmbUnit.SelectedItem = cmbUnit.Items.FindByValue(Convert.ToString(dt.Rows[0]["UnitID"]));
                    txtRate.Text = Convert.ToString(dt.Rows[0]["Rate"]);
                    txtEffectiveFromDate.Date = Convert.ToDateTime(dt.Rows[0]["EffectiveFromDate"]);

                    this.mpeEdit.Show();
                }
            }
            else
            {
                clean();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
            }
        }

        /// <summary>
        /// Event perform submit and update action using DataInsert method
        /// </summary>
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        /// <summary>
        /// Event  performs clean method
        /// </summary>
        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }

        /// <summary>
        /// Show Details of area after selection of the area in the comobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPrinterQT.Items.Clear();
            cmbPrinterQT.SelectedIndex = -1;
            lbPQslno.Text = "0";
            lbPrinterID.Text = cmbPrinter.SelectedItem.Value.ToString();

            if (cmbPrinter.SelectedItem.Value.ToString() != "0")
            {
                LoadPrinterQT(Convert.ToInt64(cmbPrinter.SelectedItem.Value));
                LoadPrinterBranch(Convert.ToInt32(cmbPrinter.SelectedItem.Value));
            }
            else
            {
                cmbPrinterQT.Items.Clear();
                cmbBranch.Items.Clear();
            }
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPricing.PageIndex = 0;
            LoadPricing();
           
            lbBranchID.Text = cmbBranch.SelectedItem.Value.ToString();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbPQslno.Text), 8);
            this.mpeImage.Show();
        }

        protected void cmbPrinterQT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrinterQT.SelectedItem.Value.ToString() != "0")
            {
                lbPQslno.Text = cmbPrinterQT.SelectedItem.Value.ToString();
            }
            else
            {
                lbPQslno.Text = "0";
            }
        }

        protected void gvPricing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPricing.PageIndex = e.NewPageIndex;

            foreach (GridViewRow row1 in gvPricing.Rows)
            {
                HiddenField hfslno = (HiddenField)row1.FindControl("hfslno");
                HiddenField hfPrinterID = (HiddenField)row1.FindControl("hfPrinterID");
                HiddenField hfBranchID = (HiddenField)row1.FindControl("hfBranchID");
                HiddenField hfMaterialID = (HiddenField)row1.FindControl("hfMaterialID");

                DropDownList ddlUnit = (DropDownList)row1.FindControl("ddlUnit");

                TextBox txtRate = (TextBox)row1.FindControl("txtRate");

                ASPxDateEdit txtEffectiveFromDate = (ASPxDateEdit)row1.FindControl("txtEffectiveFromDate");

                string Material = row1.Cells[1].Text;


                foreach (DataRow dr in dts.Rows) // search whole table
                {
                    if (dr["MaterialID"].ToString() == hfMaterialID.Value) 
                    {
                        dr["PrinterID"] = lbPrinterID.Text;
                        dr["BranchID"] = lbBranchID.Text;
                        dr["Rate"] = txtRate.Text;
                        dr["UnitID"] = ddlUnit.SelectedItem.Value;
                        dr["EffectiveFromDate"] =  txtEffectiveFromDate.Text;
                    }
                }
            }

            dts.AcceptChanges();
            Session[ViewState["_PageID"].ToString() + "Pricing"] = dts;

            gvPricing.DataSource = (DataTable)Session[ViewState["_PageID"].ToString() + "Pricing"];
            gvPricing.DataBind();
        }

        protected void gvPricing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Unit
                DropDownList ddlUnit = (DropDownList)e.Row.FindControl("ddlUnit");

                HiddenField hfEffDate = (HiddenField)e.Row.FindControl("hfEffDate");

                ASPxDateEdit txtEffectiveFromDate = (ASPxDateEdit)e.Row.FindControl("txtEffectiveFromDate");

                if (hfEffDate.Value != "")
                {
                    txtEffectiveFromDate.Date = Convert.ToDateTime(hfEffDate.Value);
                }


                Core.JobType.JobType dbunit = new Core.JobType.JobType();
                DataTable Unitdt = dbunit.GetUnits();



                ddlUnit.Items.Clear();

                ddlUnit.DataSource = Unitdt;
                ddlUnit.DataBind();

                ddlUnit.Items.Insert(0, new ListItem("Select", "0"));

                string lblUnit = (e.Row.FindControl("hfUnit") as HiddenField).Value;

                if (!string.IsNullOrEmpty(lblUnit))
                {
                    ddlUnit.Items.FindByValue(lblUnit).Selected = true;
                }
                else
                {
                    lblUnit = "0";
                }
            }
        }

        protected void rptImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
           
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbPQslno.Text), 8);
            }
        }
        protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
            hfvisible.Value = "false";
            
            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
            }
            if (hfImgIName.Value.Contains(".pdf"))
            {
                imgDocs.ImageUrl = "~/images/pdf-icon.png";
                imgDocs.ToolTip = "Download Pdf";
                hyLink.NavigateUrl = FileIdPath;

            }
            if (hfImgIName.Value.Contains(".xlsx"))
            {
                imgDocs.ImageUrl = "~/images/excell-icon.png";
                imgDocs.ToolTip = "Download xlsx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfImgIName.Value.Contains(".xls"))
            {
                imgDocs.ImageUrl = "~/images/xls-icon.jpg";
                imgDocs.ToolTip = "Download xls";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfImgIName.Value.Contains(".docx"))
            {
                imgDocs.ImageUrl = "~/images/docx-icon.png";
                imgDocs.ToolTip = "Download docx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfImgIName.Value.Contains(".doc"))
            {
                imgDocs.ImageUrl = "~/images/doc-icon.jpg";
                imgDocs.ToolTip = "Download doc";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfImgIName.Value.Contains(".txt"))
            {
                imgDocs.ImageUrl = "~/images/txt-icon.jpg";
                imgDocs.ToolTip = "Download txt";
                hyLink.NavigateUrl = FileIdPath;
            }
        }

        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string EffectiveToDate = Convert.ToString(e.GetValue("EffectiveToDate"));

            LinkButton CmdEdit = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Edit"] as GridViewDataTextColumn, "CmdEdit") as LinkButton;

            if (EffectiveToDate != "")
            {
                CmdEdit.Visible = false;
            }
        }

        

        private void Download(string path, string fileName = "", ContentDispositionType _contentDispositionType = ContentDispositionType.Attachement)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = path.Split('/').Last();
            }
            var dispositionType = "";
            switch (_contentDispositionType)
            {
                case ContentDispositionType.Attachement:
                    dispositionType = "1";
                    break;
                default:
                    dispositionType = "0";
                    break;
            }
            string url = string.Format("../../Download/Download.aspx?path={0}&contentDispositionType={1}&filename={2}", path, dispositionType, fileName);
            var sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append(url);
            sb.Append("');");
            sb.Append("</script>");
            ScriptManager.RegisterStartupScript(this, GetType(), "script", sb.ToString(), false);
            sb.Clear();
        }

        #endregion Event
    }
}