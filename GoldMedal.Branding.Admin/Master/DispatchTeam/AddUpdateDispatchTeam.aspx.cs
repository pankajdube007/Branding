using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;

using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace GoldMedal.Branding.Admin.Master.DispatchTeam
{
    public partial class AddUpdateDispatchTeam : System.Web.UI.Page
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

       

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "tbl_DispatchTeamUsers";
        private string Node = "Master";
        private int rows = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Edit Block - Variable
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Session.Timeout = 7200;
            // totval = gvSchemeChild.Rows.Count;

            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    
                    BindBranch();
                   
                    ASPxGridView1.DataBind();

                    ViewState["_PageID"] = (new Random()).Next().ToString();

                    lbslno.Text = "0";
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
            // createSessionData();
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
        protected void clean()
        {
            lbslno.Text = "0";
            chkstatus.Checked = false;
            
            txtmobno.Text = string.Empty;
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
           
           
            lbBranch.Items.Clear();
           
            BindBranch();
           

            dts.Clear();
            
        }

        /// <summary>
        /// Set the file name for the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_DispatchTeam_{0}", DateTime.Now.ToString());
        }
        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[5].Visible = false;
           
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[5].Visible = true;
            
        }

        /// <summary>
        /// returns the datatable which contains the all Printer records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt4 = objselectall.GetDispatchTeamUsers();
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
          //  Data.Printer.PrinterModel.PrinterInsert dst = new Data.Printer.PrinterModel.PrinterInsert();
            Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert dst = new Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert();

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
            var name = HttpUtility.HtmlEncode(txtname.Text.Trim());
            var email = HttpUtility.HtmlEncode(txtemail.Text.Trim());
            
            var mobile = HttpUtility.HtmlEncode(txtmobno.Text.Trim());

            var username = HttpUtility.HtmlEncode(txtUserName.Text.Trim());
            var pwd = HttpUtility.HtmlEncode(txtPassword.Text.Trim());

          

            if (branch == "")
            {
                error += "Select atleast one branch.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(name)))
            {
                error += "Name Should not be empty.!</br>";
            }
          
           
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

                if (Convert.ToInt32(lbslno.Text) == 0)
                {
                    dst.usernm = "disp_" + username;
                }
                else
                {

                    if (!username.Contains("disp_"))
                    {
                        dst.usernm = "disp_" + username;
                    }
                    else
                    {
                        dst.usernm = username;
                    }
                }
                dst.Status = status;
                dst.password = pwd;
                dst.Name = ValidateDataType.EnsureMaximumLength(name, 100);
               
                dst.branch = branch;
               
                dst.mobile = mobile;
                dst.emailid = email;
               
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
              
                dst.slno = Convert.ToInt32(lbslno.Text);
               
                
                Core.FinalAssembaly.FinalAssembly objinsert = new Core.FinalAssembaly.FinalAssembly();
                result = objinsert.AddDispatchTeam(dst);
                if (result == -2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','User already exists !','warning',3);", true);
                    
                    clean();
                }
                else if (result == -1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                   
                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                }
                else if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','User added successfully !','success',3);", true);

                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }

                else
                {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','User updated successfully !','success',3);", true);
                   
                   
                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
            }
        }

       

        /// <summary>
        /// Used in delete and edit action for tarcking data is editable,deletable or not
        /// </summary>
        protected void CheckEditBlock(string param, int id)
        {
            string str = string.Empty;
            overwriteStr = string.Empty;
           
                    if (param == "Delete")
                    {
                        #region Delete Block

                 
                      Data.FinalAssembaly.FinalAssembly.DispatchTeamDelete ddel = new Data.FinalAssembaly.FinalAssembly.DispatchTeamDelete();
                        ddel.slno = Convert.ToInt32(lbslno.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.FinalAssembaly.FinalAssembly objdelete = new Core.FinalAssembaly.FinalAssembly();
                        rows = objdelete.DispatchTeamUserDeleteMethod(ddel);
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

                        Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert dtsingle = new Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert();
                        dtsingle.slno = Convert.ToInt32(lbslno.Text);
                        Core.FinalAssembaly.FinalAssembly objselectsingle = new Core.FinalAssembaly.FinalAssembly();
                        DataTable dt = objselectsingle.GetDispatchTeamUserSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                txtname.Text = Convert.ToString(dt.Rows[0]["Name"]);
                                
                                lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                                
                                txtmobno.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                                txtemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                               
                                if (Convert.ToString(dt.Rows[0]["ActiveStatus"]) == "False")
                                {
                                    chkstatus.Checked = false;
                                }
                                else
                                {
                                    chkstatus.Checked = true;
                                }

                                foreach (var item in Convert.ToString(Convert.ToString(dt.Rows[0]["Branch"])).Split(','))
                                {
                                    if (item != "")
                                    {
                                        lbBranch.Items.FindByValue(item).Selected = true;
                                    }
                                }



                                txtPassword.Text = Convert.ToString(dt.Rows[0]["Password"]);


                                if (dt.Rows[0]["Usernm"].ToString() != "")
                                {
                                    string uname = Convert.ToString(dt.Rows[0]["Usernm"]).Substring(0, 5);
                                    if (uname.Contains("disp_"))
                                    {
                                        txtUserName.Text = Convert.ToString(dt.Rows[0]["Usernm"]).Remove(0, 5);
                                    }
                                    else
                                    {
                                        txtUserName.Text = Convert.ToString(dt.Rows[0]["Usernm"]);
                                    }
                                }



                                // loadchild();
                            }
                        }
                        else
                        {
                            #region Edit Block - Code

                        

                            #endregion Edit Block - Code

                            lbslno.Text = "0";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
                        }

                        ASPxPageControl1.ActiveTabIndex = 0;

                        #endregion Edit Block
                    }
               
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
        protected void ASPxPageControl1_TabClick(object source, DevExpress.Web.TabControlCancelEventArgs e)
        {
            clean();
            
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {

        }

        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}