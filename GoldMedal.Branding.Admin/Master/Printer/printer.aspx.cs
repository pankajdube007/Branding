using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.Printer;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Master.Printer
{
    public partial class printer : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private DataTable dts = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int row = 0;
        private int totval = 0;
        private string strFileTypeVC = string.Empty;
        private string FileNameVC = string.Empty;
        private string FolderName = string.Empty;
        public string party = string.Empty;

        PrinterDataAccess da = new PrinterDataAccess();

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "tbl_printer";
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
            // totval = gvSchemeChild.Rows.Count;

            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    LoadArea();
                    BindBranch();
                    LoadUnit();
                    Loadmaterial();
                    loadareadetail();
                    BindSuppliers();
                    ASPxGridView1.DataBind();

                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    cmbSupplier.ReadOnly = false;
                    lbslno.Text = "0";
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
            // createSessionData();
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


        protected void BindBranch()
        {
            Core.Fabricator.IFabricator objselectsingle = new Core.Fabricator.Fabricator();
            DataTable dt = objselectsingle.GetBranchAll();

            lbBranch.Items.Clear();
            lbBranch.Value = null;
            lbBranch.DataSource = dt;
            lbBranch.TextField = "locnm";
            lbBranch.ValueField = "slno";
            lbBranch.DataBind();
        }

        protected void LoadArea()
        {
            Core.Fabricator.IFabricator objselectsingle = new Core.Fabricator.Fabricator();
            DataTable dt = objselectsingle.GetAreaAll();

            cmbArea.Items.Clear();
            cmbArea.Value = null;
            cmbArea.Items.Clear();
            cmbArea.Value = null;
            cmbArea.DataSource = dt;
            cmbArea.TextField = "areanm";
            cmbArea.ValueField = "slno";
            //cmbArea.SelectedIndex = 0;
            cmbArea.DataBind();

            cmbArea.Items.Insert(0, new ListEditItem("Select"));
            cmbArea.SelectedIndex = 0;
        }

        protected void LoadUnit()
        {
            Core.Unit.Unit objselectsingle = new Core.Unit.Unit();
            DataTable dt = objselectsingle.GetUnitAll();
            cmbunit.Items.Clear();
            cmbunit.Value = null;
            cmbunit.Items.Clear();
            cmbunit.Value = null;
            cmbunit.DataSource = dt;
            cmbunit.TextField = "name";
            cmbunit.ValueField = "slno";
            cmbunit.SelectedIndex = -1;
            cmbunit.DataBind();
        }

        protected void Loadmaterial()
        {
            Core.SubSubJobType.SubSubJobType objselectsingle = new Core.SubSubJobType.SubSubJobType();
            DataTable dt = objselectsingle.GetSubSubJobTypeAll();
            cmbMaterial.DataSource = dt;
            cmbMaterial.TextField = "name";
            cmbMaterial.ValueField = "slno";
            cmbMaterial.SelectedIndex = 0;
            cmbMaterial.DataBind();
        }

        /// <summary>
        /// Show details of area like country state and city
        /// </summary>
        protected void loadareadetail()
        {
            if (cmbArea.SelectedIndex != 0)
            {

                Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle = new Data.Fabricator.FabricatorModel.FabricatorInsert();
                dtsingle.area = Convert.ToInt32(cmbArea.Value);
                Core.Fabricator.Fabricator objselectsingle = new Core.Fabricator.Fabricator();
                DataTable dt = objselectsingle.AreaDetail(dtsingle);
                if (dt.Rows.Count > 0)
                {
                    lblCountry.Text = Convert.ToString(dt.Rows[0]["countrynm"]);
                    lblState.Text = Convert.ToString(dt.Rows[0]["statenm"]);
                    lblCity.Text = Convert.ToString(dt.Rows[0]["citynm"]);
                }
            }
            else
            {
                lblCountry.Text = string.Empty;
                lblState.Text = string.Empty;
                lblCity.Text = string.Empty;
            }
        }




        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            chkstatus.Checked = false;
            lblCity.Text = string.Empty;
            lblCountry.Text = string.Empty;
            lblState.Text = string.Empty;
            txtcode.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtmobno.Text = string.Empty;
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtcontactperson.Text = string.Empty;
            lblgstno.Text = string.Empty;
            txtpincode.Text = string.Empty;
            cmbArea.Items.Clear();
            cmbMaterial.SelectedIndex = 0;
            cmbunit.SelectedIndex = -1;
            txtrate.Text = "0.00";

            // lblAddress.Text = "";
            txtAddress.Text = "";
            txtcontactperson.Text = "";
            lblEmail.Text = "";
            lblContactNo.Text = "";

            cmbArea.Items.Clear();
            lbBranch.Items.Clear();
            cmbSupplier.SelectedIndex = -1;
            cmbSupplier.Items.Clear();
            cmbSupplier.ReadOnly = false;
            LoadArea();
            BindBranch();
            BindSuppliers();
            loadareadetail();

            dts.Clear();
            // gvSchemeChild.DataBind();
        }

        protected void childclean()
        {
            txtrate.Text = "0.00";
            cmbunit.SelectedIndex = -1;
            cmbMaterial.SelectedIndex = -1;
        }

        /// <summary>
        /// Set the file name for the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_Printer_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[4].Visible = false;
            //   ASPxGridView1.Columns[5].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[4].Visible = true;
            // ASPxGridView1.Columns[5].Visible = true;
        }

        /// <summary>
        /// returns the datatable which contains the all Printer records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt4 = objselectall.GetPrinterAll();
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
            int errorresulr = 0;
            bool status;
            string error = string.Empty;
            Data.Printer.PrinterModel.PrinterInsert dst = new Data.Printer.PrinterModel.PrinterInsert();
            // var code = HttpUtility.HtmlEncode(txtcode.Text.Trim());
            // var name = HttpUtility.HtmlEncode(txtname.Text.Trim());
            var name = HttpUtility.HtmlEncode(cmbSupplier.SelectedItem.Text);
            var area = HttpUtility.HtmlEncode(cmbArea.Value);

            var branch = "";



            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branch += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branch = branch.TrimEnd(',');
            if (chkstatus.Checked == true)
            {
                status = Convert.ToBoolean(1);
            }
            else
            {
                status = Convert.ToBoolean(0);
            }

            var email = HttpUtility.HtmlEncode(txtemail.Text.Trim());
            var contact = HttpUtility.HtmlEncode(txtcontact.Text.Trim());
            var mobile = HttpUtility.HtmlEncode(txtmobno.Text.Trim());

            var username = HttpUtility.HtmlEncode(txtUserName.Text.Trim());
            var pwd = HttpUtility.HtmlEncode(txtPassword.Text.Trim());

            var supplier = cmbSupplier.SelectedItem == null || cmbSupplier.SelectedItem.Value == null ? 0 : Convert.ToInt32(cmbSupplier.SelectedItem.Value);
            var Address = HttpUtility.HtmlEncode(txtAddress.Text.Trim());
            var ContactPerson = HttpUtility.HtmlEncode(txtcontactperson.Text.Trim());
            var Pincode = HttpUtility.HtmlEncode(txtpincode.Text.Trim());
            var Gstno = HttpUtility.HtmlEncode(lblgstno.Text.Trim());

            if (supplier == 0)
            {
                error += "Please select supplier.!</br>";
            }
            if (cmbArea.SelectedIndex == 0)
            {
                error += "Area Should not be empty.!</br>";
            }
            if (branch == "")
            {
                error += "Select atleast one branch.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(name)))
            {
                error += "Name Should not be empty.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(Address)))
            {
                error += "Address Should not be empty.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(Pincode)))
            {
                error += "Pincode Should not be empty.!</br>";
            }
            //if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(Gstno)))
            //{
            //    error += "Gst No Should not be empty.!</br>";
            //}
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(mobile)))
            {
                error += "Mobile Should not be empty.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(email)))
            {
                error += "Email Should not be empty or Invalid.!</br>";
            }

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(username)))
            {
                error += "Username Should not be empty.!</br>";
            }

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(pwd)))
            {
                error += "Password Should not be empty.!</br>";
            }

            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
                //dst.Code = ValidateDataType.EnsureMaximumLength(code, 100);

                if (Convert.ToInt32(lbslno.Text) == 0)
                {
                    dst.usernm = "pri_" + username;
                }
                else
                {

                    if (!username.Contains("pri_"))
                    {
                        dst.usernm = "pri_" + username;
                    }
                    else
                    {
                        dst.usernm = username;
                    }
                }
                dst.Status = status;
                dst.password = pwd;
                dst.Name = ValidateDataType.EnsureMaximumLength(name, 100);
                dst.area = Convert.ToInt32(area);
                dst.branch = branch;
                dst.Address = Address;
                dst.Pincode = Pincode;
                dst.Gstno = Gstno;
                dst.contactno = contact;
                dst.mobile = mobile;
                dst.emailid = email;
                dst.ContactPerson = ContactPerson;
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.pagename = HttpContext.Current.Request.Url.ToString();
                dst.slno = Convert.ToInt32(lbslno.Text);
                dst.SupplierID = Convert.ToInt32(supplier);
                dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                Core.Printer.Printer objinsert = new Core.Printer.Printer();
                result = objinsert.PrinterInsertMethod(dst);
                if (result == -2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Printer already exists !','warning',3);", true);
                    ResetFunc();
                    clean();
                }
                else if (result == -1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                    ResetFunc();
                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                }
                else if ((result != -1) && (result != -2) && (gvSchemeChild.Rows.Count > 0 || totval > 0))
                {
                    Data.Printer.PrinterModel.PrinterInsert dstt = new Data.Printer.PrinterModel.PrinterInsert();
                    foreach (GridViewRow row in gvSchemeChild.Rows)
                    {
                        int materialid = Convert.ToInt32(((HiddenField)row.FindControl("materialid")).Value);
                        int unitid = Convert.ToInt32(((HiddenField)row.FindControl("unitid")).Value);
                        int childslno = Convert.ToInt32(((HiddenField)row.FindControl("hfchildslno")).Value);
                        decimal RatePerJob = Convert.ToDecimal(row.Cells[2].Text);

                        dstt.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        dstt.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        dstt.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                        dstt.refid = result;
                        dstt.pagename = HttpContext.Current.Request.Url.ToString();
                        dstt.materialid = materialid;
                        dstt.slno = Convert.ToInt32(lbslno.Text);
                        dstt.childslno = childslno;
                        dstt.RatePerJOb = RatePerJob;
                        dstt.unitid = unitid;
                        result2 = objinsert.printermaterialSubmitupdate(dstt);
                        if (result2 == -1)
                        {
                            Data.Printer.PrinterModel.PrinterDelete del = new Data.Printer.PrinterModel.PrinterDelete();
                            del.slno = Convert.ToInt32(result);
                            errorresulr = objinsert.PermanentDeletepr(del);
                            ResetFunc();
                            clean();

                            break;
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                        }
                        else if (result2 == 2)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer and material details added successfully !','success',3);", true);
                        }
                        else if (result2 == 3)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer and material details updated successfully  !','success',3);", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Some error occured in adding items !','error',3);", true);
                        }

                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Printer and its material added successfully!','success',3);", true);
                    }
                    ResetFunc();
                    clean();
                    ASPxGridView1.DataBind();
                }
                else
                {
                    if (lbslno.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','No Materials added only Printer added successfully !','success',3);", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','No Materials updated only Printer updated successfully !','success',3);", true);
                    }
                    ResetFunc();
                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
            }
        }

        /// <summary>
        /// After edit or delete action this function reset editmode column which indicates that the value is editable,deleteble  or not
        /// </summary>
        ///
        protected void ResetFunc()
        {
            if (lbslno.Text != "0")
            {
                Data.CheckEdit.CheckEditModel.CheckEditInsert dstreset = new Data.CheckEdit.CheckEditModel.CheckEditInsert();
                dstreset.slno = ValidateDataType.EnsureMaximumLength(lbslno.Text, 100);
                dstreset.TableNm = ValidateDataType.EnsureMaximumLength(TableNm, 100);
                Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
                string resetSts = objselectall.ResetEditStatus(dstreset);
            }
        }

        /// <summary>
        /// Used in delete and edit action for tarcking data is editable,deletable or not
        /// </summary>
        protected void CheckEditBlock(string param, int id)
        {
            string str = string.Empty;
            overwriteStr = string.Empty;
            string overtime = string.Empty, maxtime = string.Empty;
            Data.CheckTime.CheckTimeModel.CheckTimeInsert dttime = new Data.CheckTime.CheckTimeModel.CheckTimeInsert();
            dttime.Node = Node;
            Core.CheckTime.CheckTime dttimee = new Core.CheckTime.CheckTime();

            DataTable time = dttimee.GetCheckTimeForNode(dttime);
            if (time.Rows.Count > 0)
            {
                overtime = Convert.ToString(time.Rows[0]["overwrite"]);
                maxtime = Convert.ToString(time.Rows[0]["maxtime"]);
            }
            DataTable dtEditChk = new DataTable();
            Data.CheckEdit.CheckEditModel.CheckEditInsert dst = new Data.CheckEdit.CheckEditModel.CheckEditInsert();
            dst.slno = ValidateDataType.EnsureMaximumLength(lbslno.Text, 100);
            dst.TableNm = ValidateDataType.EnsureMaximumLength(TableNm, 100);
            dst.adminid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dst.PageNm = HttpContext.Current.Request.Url.ToString();
            dst.usercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
            dst.overwritetime = Convert.ToInt32(overtime);
            dst.maxtime = Convert.ToInt32(maxtime);
            Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
            dtEditChk = objselectall.GetCheckEditAll(dst);
            if (dtEditChk.Rows.Count > 0)
            {
                if (dtEditChk.Rows[0]["PStatus"] != null && (dtEditChk.Rows[0]["PStatus"].ToString() == "InActive" || dtEditChk.Rows[0]["PStatus"].ToString() == "Unchecked"))
                {
                    if (param == "Delete")
                    {
                        #region Delete Block

                        Data.Printer.PrinterModel.PrinterDelete ddel = new Data.Printer.PrinterModel.PrinterDelete();
                        ddel.slno = Convert.ToInt32(lbslno.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.Printer.Printer objdelete = new Core.Printer.Printer();
                        rows = objdelete.PrinterDeleteMethod(ddel);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull !','success',3);", true);
                            ASPxGridView1.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit !','warning',3);", true);
                            clean();
                        }

                        #endregion Delete Block
                    }
                    else
                    {
                        #region Edit Block

                        Data.Printer.PrinterModel.PrinterInsert dtsingle = new Data.Printer.PrinterModel.PrinterInsert();
                        dtsingle.slno = Convert.ToInt32(lbslno.Text);
                        Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
                        DataTable dt = objselectsingle.GetPrinterSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                txtname.Text = Convert.ToString(dt.Rows[0]["name"]);
                                txtcode.Text = Convert.ToString(dt.Rows[0]["code"]);
                                lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                                txtcontact.Text = Convert.ToString(dt.Rows[0]["contact"]);
                                txtmobno.Text = Convert.ToString(dt.Rows[0]["mobile"]);
                                txtemail.Text = Convert.ToString(dt.Rows[0]["emailid"]);
                                lblCountry.Text = Convert.ToString(dt.Rows[0]["countrynm"]);
                                lblState.Text = Convert.ToString(dt.Rows[0]["statenm"]);
                                lblCity.Text = Convert.ToString(dt.Rows[0]["citynm"]);
                                cmbArea.Text = Convert.ToString(dt.Rows[0]["areanm"]);
                                if (Convert.ToString(dt.Rows[0]["ActiveStatus"]) == "False")
                                {
                                    chkstatus.Checked = false;
                                }
                                else
                                {
                                    chkstatus.Checked = true;
                                }

                                foreach (var item in Convert.ToString(Convert.ToString(dt.Rows[0]["branch"])).Split(','))
                                {
                                    if (item != "")
                                    {
                                        lbBranch.Items.FindByValue(item).Selected = true;
                                    }
                                }


                                cmbSupplier.SelectedItem = cmbSupplier.Items.FindByValue(Convert.ToString(dt.Rows[0]["SupplierID"]));


                                String ValueSupplier = "";
                                if (cmbSupplier.Items.FindByValue(Convert.ToString(dt.Rows[0]["SupplierID"])) != null)
                                {
                                    ValueSupplier = cmbSupplier.Items.FindByValue(Convert.ToString(dt.Rows[0]["SupplierID"])).ToString();
                                    cmbSupplier_SelectedIndexChanged(null, null);
                                }


                                if (dt.Rows[0]["SupplierID"].ToString().Trim() != "")
                                {
                                    if (dt.Rows[0]["SupplierID"].ToString().Trim() != "0")
                                    {
                                        if (ValueSupplier != "")
                                        {
                                            cmbSupplier.ReadOnly = true;
                                        }
                                    }
                                }



                                //if (cmbSupplier.SelectedItem != null)
                                //{
                                //    GetSupplierDetails(Convert.ToInt32(cmbSupplier.SelectedItem.Value));
                                //}
                                txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                                txtcontactperson.Text = Convert.ToString(dt.Rows[0]["ContactPerson"]);
                                txtpincode.Text = Convert.ToString(dt.Rows[0]["Pincode"]);
                                lblgstno.Text = Convert.ToString(dt.Rows[0]["Gstno"]);


                                txtPassword.Text = Convert.ToString(dt.Rows[0]["password"]);


                                if (dt.Rows[0]["usernm"].ToString() != "")
                                {
                                    string uname = Convert.ToString(dt.Rows[0]["usernm"]).Substring(0, 4);
                                    if (uname.Contains("pri_"))
                                    {
                                        txtUserName.Text = Convert.ToString(dt.Rows[0]["usernm"]).Remove(0, 4);
                                    }
                                    else
                                    {
                                        txtUserName.Text = Convert.ToString(dt.Rows[0]["usernm"]);
                                    }
                                }



                                // loadchild();
                            }
                        }
                        else
                        {
                            #region Edit Block - Code

                            ResetFunc();

                            #endregion Edit Block - Code

                            lbslno.Text = "0";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
                        }

                        ASPxPageControl1.ActiveTabIndex = 0;

                        #endregion Edit Block
                    }
                }
                else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Active")
                {
                    #region Build HTML

                    if (dtEditChk.Rows[0]["usercat"] != null && dtEditChk.Rows[0]["usercat"].ToString() != string.Empty)
                    {
                        html += "<div>Name : " + dtEditChk.Rows[0]["usercat"].ToString() + "</div>";
                    }
                    if (dtEditChk.Rows[0]["BranchNm"] != null && dtEditChk.Rows[0]["BranchNm"].ToString() != string.Empty)
                    {
                        html += "<div>Branch : " + dtEditChk.Rows[0]["BranchNm"].ToString() + "</div>";
                    }
                    if (dtEditChk.Rows[0]["Designation"] != null && dtEditChk.Rows[0]["Designation"].ToString() != string.Empty)
                    {
                        html += "<div>Designation : " + dtEditChk.Rows[0]["Designation"].ToString() + "</div>";
                    }

                    if (dtEditChk.Rows[0]["offContactNo"] != null && dtEditChk.Rows[0]["offContactNo"].ToString() != string.Empty)
                    {
                        html += "<div>Contact No : " + dtEditChk.Rows[0]["offContactNo"].ToString() + "</div>";
                    }
                    else if (dtEditChk.Rows[0]["offphone1"] != null && dtEditChk.Rows[0]["offphone1"].ToString() != string.Empty)
                    {
                        html += "<div>Contact No : " + dtEditChk.Rows[0]["offphone1"].ToString() + "</div>";
                    }

                    #endregion Build HTML

                    if (dtEditChk.Rows[0]["viewoverwrite"] != null && dtEditChk.Rows[0]["viewoverwrite"].ToString() == "No")
                    {
                        lbslno.Text = "0";
                        str = @"<div><div>Another user is already working on the page.</div></br>" + html + "</div>";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + str + "','warning');", true);
                    }
                    else if (dtEditChk.Rows[0]["viewoverwrite"] != null && dtEditChk.Rows[0]["viewoverwrite"].ToString() == "Yes")
                    {
                        if (param != "Delete")
                        {
                            overwriteStr = @"<br><div ow-lf>Do you wish to overwrite current session ?</div><div ow-css ow-yes>Yes</div><div ow-css ow-no>No</div></div>";
                        }

                        str = @"<div><div>Another user is already working on the page.</div></br><div>" + html + string.Empty + overwriteStr + "</div>";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + str + "','warning');", true);
                    }
                    else
                    {
                        lbslno.Text = "0";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
                    }
                }
                else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Error")
                {
                    lbslno.Text = "0";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Error occurred, please refresh and try again.','error',3);", true);
                }
            }
            else
            {
                lbslno.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
            }
        }

        private string[] Validationchild()
        {
            string[] results = new string[2];
            if (cmbMaterial.SelectedIndex == -1 || Convert.ToDecimal(txtrate.Text) <= 0 || cmbunit.SelectedIndex == -1)
            {
                results[0] = "true";
                results[1] = "some error occured";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Material or Rate or Unit is Empty ! ','warning',3);", true);
            }
            else
            {
                results[0] = "false";
                results[1] = string.Empty;
            }
            return results;
        }

        protected void bindgvSchemeChild()
        {
            gvSchemeChild.DataSource = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
            gvSchemeChild.DataBind();
        }

        protected void createSessionData()
        {
            if (Session[ViewState["_PageID"].ToString() + "Scheme"] != null)
            {
                dts = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
            }
            else
            {
                dts = new DataTable();
                DataColumn pk = dts.Columns.Add("Slno", typeof(System.Int32));
                pk.AllowDBNull = false;
                pk.Unique = true;
                pk.AutoIncrement = true;
                pk.AutoIncrementSeed = 1;
                pk.AutoIncrementStep = 1;
                dts.Columns.Add("childslno", typeof(System.Int32));
                dts.Columns.Add("materialid", typeof(System.Int32));
                dts.Columns.Add("Material", typeof(System.String));
                dts.Columns.Add("RatePeJob", typeof(System.Decimal));
                dts.Columns.Add("unit", typeof(System.String));
                dts.Columns.Add("unitid", typeof(System.Int32));
            }
        }

        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.Printer.PrinterModel.PrinterInsert dchildlist = new Data.Printer.PrinterModel.PrinterInsert();
            dchildlist.slno = Convert.ToInt32(lbslno.Text);
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt6 = objselectall.GetDetailOfMaterialListForPrinter(dchildlist);
            Session[ViewState["_PageID"].ToString() + "Scheme"] = dt6;
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
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
        /// Used for export the grid in pdf format
        /// </summary>
        protected void btnPdfExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToPdf(ASPxGridViewExporter1, FileName, true);
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
        /// Used for export the grid in rtf format
        /// </summary>
        protected void btnRtfExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToRtf(ASPxGridViewExporter1, FileName, true);
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


        private void BindSuppliers()
        {
            DataTable suppliers = da.AllSupplierListDA();
            if (suppliers.Rows.Count > 0)
            {
                cmbSupplier.DataSource = suppliers;
                cmbSupplier.DataBind();
                cmbSupplier.Items.Insert(0, new ListEditItem("Select", null));
                cmbSupplier.SelectedIndex = 0;
            }
        }

        protected void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lblAddress.Text = "";
            txtAddress.Text = "";
            txtcontactperson.Text = "";
            lblEmail.Text = "";
            lblContactNo.Text = "";

            if (cmbSupplier.SelectedItem != null)
            {
                if (cmbSupplier.SelectedItem.Value != null && cmbSupplier.SelectedItem.Value.ToString() != "0")
                {
                    GetSupplierDetails(Convert.ToInt32(cmbSupplier.SelectedItem.Value));
                }
            }
        }

        private void GetSupplierDetails(int SupplierID)
        {
            DataTable supplier = da.GetSupplierDetails(SupplierID);
            if (supplier.Rows.Count > 0)
            {
                // lblAddress.Text = Convert.ToString(supplier.Rows[0]["addline1"]);
                txtAddress.Text = Convert.ToString(supplier.Rows[0]["addline1"]);
                txtpincode.Text = Convert.ToString(supplier.Rows[0]["pinno"]);
                lblgstno.Text = Convert.ToString(supplier.Rows[0]["gstno"]);
                txtemail.Text = Convert.ToString(supplier.Rows[0]["email"]);
                txtcontact.Text = Convert.ToString(supplier.Rows[0]["offph1"]);
                txtmobno.Text = Convert.ToString(supplier.Rows[0]["mobile"]);
                cmbArea.Value = Convert.ToString(supplier.Rows[0]["areaid"]);
                lblCity.Text = Convert.ToString(supplier.Rows[0]["citynm"]);
                lblState.Text = Convert.ToString(supplier.Rows[0]["statenm"]);
                lblCountry.Text = Convert.ToString(supplier.Rows[0]["Countrynm"]);
                lblEmail.Text = Convert.ToString(supplier.Rows[0]["email"]);
                lblContactNo.Text = Convert.ToString(supplier.Rows[0]["mobile"]);
                txtcontactperson.Text = Convert.ToString(supplier.Rows[0]["ConcernedPerson"]);
            }
            else
            {
                // lblAddress.Text = "";
                txtAddress.Text = "";
                txtpincode.Text = "";
                lblgstno.Text = "";
                txtemail.Text = "";
                txtcontact.Text = "";
                txtmobno.Text = "";
                cmbArea.Value = "";
                lblCity.Text = "";
                lblState.Text = "";
                lblCountry.Text = "";
                lblEmail.Text = "";
                lblContactNo.Text = "";
                txtcontactperson.Text = "";
            }
        }


        /// <summary>
        /// Used for edit the record
        /// </summary>
        protected void CmdEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Edit", Convert.ToInt32(lbslno.Text));

            #endregion Edit Block - Code
        }

        /// <summary>
        /// Used for delete the record
        /// </summary>
        protected void CmdDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Delete", FieldTripID);

            #endregion Edit Block - Code

            ResetFunc();
            clean();
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

        /// <summary>
        /// Event perform submit and update action using DataInsert method
        /// </summary>
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
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
        protected void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadareadetail();


        }


        /// <summary>
        ///Used  In the case of overwrite during edit or delete
        /// </summary>
        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
            Data.CheckEdit.CheckEditModel.CheckEditInsert dstupdateeditstatus = new Data.CheckEdit.CheckEditModel.CheckEditInsert();
            dstupdateeditstatus.slno = ValidateDataType.EnsureMaximumLength(lbslno.Text, 100);
            dstupdateeditstatus.TableNm = ValidateDataType.EnsureMaximumLength(TableNm, 100);
            dstupdateeditstatus.adminid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dstupdateeditstatus.usercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
            dstupdateeditstatus.PageNm = HttpContext.Current.Request.Url.ToString();
            Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
            string status = objselectall.updateeditstatus(dstupdateeditstatus);

            #region Edit Block

            Data.Printer.PrinterModel.PrinterInsert dtsingle = new Data.Printer.PrinterModel.PrinterInsert();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            DataTable dt = objselectsingle.GetPrinterSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                txtname.Text = Convert.ToString(dt.Rows[0]["name"]);
                txtcode.Text = Convert.ToString(dt.Rows[0]["code"]);
                lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                txtcontact.Text = Convert.ToString(dt.Rows[0]["contact"]);
                txtmobno.Text = Convert.ToString(dt.Rows[0]["mobile"]);
                txtemail.Text = Convert.ToString(dt.Rows[0]["emailid"]);
                lblCountry.Text = Convert.ToString(dt.Rows[0]["countrynm"]);
                lblState.Text = Convert.ToString(dt.Rows[0]["statenm"]);
                lblCity.Text = Convert.ToString(dt.Rows[0]["citynm"]);
                cmbArea.Text = Convert.ToString(dt.Rows[0]["areanm"]);
                if (Convert.ToString(dt.Rows[0]["ActiveStatus"]) == "false")
                {
                    chkstatus.Checked = false;
                }
                else
                {
                    chkstatus.Checked = true;
                }
            }
            else
            {
                #region Edit Block - Code

                ResetFunc();

                #endregion Edit Block - Code

                lbslno.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
            }

            ASPxPageControl1.ActiveTabIndex = 0;

            #endregion Edit Block
        }

        protected void gvSchemeChild_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rows = 0;
            int index = Convert.ToInt32(e.RowIndex);
            Data.Printer.PrinterModel.PrinterDelete param1 = new Data.Printer.PrinterModel.PrinterDelete();
            //child srno
            param1.slno = Convert.ToInt32(((HiddenField)gvSchemeChild.Rows[index].FindControl("hfchildslno")).Value);
            Core.Printer.Printer objdelete = new Core.Printer.Printer();
            rows = objdelete.Deleteprintermaterial(param1);
            if (rows == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Item Deleted successfully !','success',3);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
            }

            DataTable dts = Session[ViewState["_PageID"].ToString() + "Scheme"] as DataTable;

            dts.Rows[index].Delete();
            dts.AcceptChanges();
            Session[ViewState["_PageID"].ToString() + "Scheme"] = dts;

            bindgvSchemeChild();
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            childclean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void btnaddmaterial_Click1(object sender, EventArgs e)
        {
            if (Validationchild()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validationchild()[1] + "','warning',3);", true);
            }
            else
            {
                Boolean matchdata = false;

                if (txtrate.Text != string.Empty && cmbunit.Value != string.Empty && cmbMaterial.Value != string.Empty)
                {
                    DataRow row = dts.NewRow();

                    if (Session[ViewState["_PageID"].ToString() + "Scheme"] != null)
                    {
                        DataTable dt1 = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            if (Convert.ToString(dt1.Rows[i]["Material"]) == cmbMaterial.Text)
                            {
                                matchdata = true;
                                lblMsg2.Text = "Opps! duplicate value";
                                lblMsg2.Style.Add("color", "red");
                                break;
                            }
                        }
                    }

                    if (matchdata == false)
                    {
                        row["childslno"] = "0";
                        row["materialid"] = cmbMaterial.Value;
                        row["Material"] = cmbMaterial.Text;
                        row["RatePeJob"] = Convert.ToDouble(txtrate.Text);
                        row["unitid"] = cmbunit.Value;
                        row["unit"] = cmbunit.Text;
                        dts.Rows.Add(row);
                        dts.AcceptChanges();
                        Session[ViewState["_PageID"].ToString() + "Scheme"] = dts;
                        bindgvSchemeChild();
                    }
                }
                else
                {
                    lblMsg2.Text = "Please enter every mandatory details";
                    lblMsg2.Style.Add("color", "red");
                }

                childclean();
            }
        }

        protected void gvSchemeChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (gvSchemeChild.Rows.Count > 0)
                {
                    gvSchemeChild.Rows[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                }

                int lastCellIndex = e.Row.Cells.Count - 1;
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[lastCellIndex].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete Item Name: " + item + "?')){ return false; };";
                    }
                }
            }
        }

        #endregion Event
    }
}