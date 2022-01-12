using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Master
{
    public partial class DesignTypeSubCategory : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_DesignTypeSubCategory";
        private string Node = "Master";
        private int rows = 0;

        #endregion Edit Block - Variable

        #region PageEvent

        /// <summary>
        /// In the Page Lode lblslno is 0 by which program desides the process of submit button which can be submit the record or update the record and also lode the grid as well as combobox for the designtype using method FillDesignType.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    FillDesignType();
                lbslno.Text = "0";
                ASPxPageControl1.ActiveTabIndex = 1;
                ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }

        #endregion PageEvent

        #region Export
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
        /// Used for export the grid in pdf format
        /// </summary>
        ///
        protected void btnPdfExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToPdf(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

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

        #region Method

        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[2].Visible = false;
            ASPxGridView1.Columns[3].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[2].Visible = true;
            ASPxGridView1.Columns[3].Visible = true;
        }

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            txtName.Text = string.Empty;
            ASPxGridView1.DataBind();
        }

        /// <summary>
        /// perform the action of submit or update  and called by CmdSubmit_Click event
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            string error = string.Empty;
            Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dst = new Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert();
            var name = HttpUtility.HtmlEncode(txtName.Text.Trim());
            var designtype = HttpUtility.HtmlEncode(cmbDesignType.Value);
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(name)))
            {
                error += "Name Should not be empty.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(designtype)))
            {
                error += "Design Type is empty or invalid.!</br>";
            }

            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
                dst.Name = ValidateDataType.EnsureMaximumLength(name, 100);
                dst.designtype = Int32.Parse(designtype);
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.pagename = HttpContext.Current.Request.Url.ToString();
                dst.slno = Int32.Parse(lbslno.Text);
                dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                if (lbslno.Text == "0")
                {
                    Core.DesignTypeSubCat.DesignTypeSubCat objinsert = new Core.DesignTypeSubCat.DesignTypeSubCat();
                    result = objinsert.DesignTypeSubCatInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','DesignType Sub Category already exists !','warning',3);", true);
                        clean();
                        ASPxPageControl1.ActiveTabIndex = 1;
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','DesignType Sub Category added successfully!','success',3);", true);

                        clean();
                        ASPxPageControl1.ActiveTabIndex = 1;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                        ASPxPageControl1.ActiveTabIndex = 1;
                    }
                }
                else
                {
                    Core.DesignTypeSubCat.DesignTypeSubCat objinsert = new Core.DesignTypeSubCat.DesignTypeSubCat();
                    result = objinsert.DesignTypeSubCatInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','DesignType Sub Category already exists !','warning',3);", true);
                        ASPxPageControl1.ActiveTabIndex = 1;
                        ResetFunc();
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','DesignType Sub Category updated successfully!','success',3);", true);
                        ResetFunc();
                        clean();
                        ASPxPageControl1.ActiveTabIndex = 1;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        ResetFunc();
                        clean();
                        ASPxPageControl1.ActiveTabIndex = 1;
                    }
                    ResetFunc();
                }
            }
        }

        /// <summary>
        /// Show All The Design Type In the Combo Box
        /// </summary>
        public void FillDesignType()
        {
            DataTable DesignTypeDt = new DataTable();
            Core.Design.DesignType objselectall = new Core.Design.DesignType();
            DesignTypeDt = objselectall.GetDesignTypeAll();
            cmbDesignType.DataSource = DesignTypeDt;
            cmbDesignType.TextField = "name";
            cmbDesignType.ValueField = "slno";
            cmbDesignType.SelectedIndex = 0;
            cmbDesignType.DataBind();
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
        /// returns the datatable which contains the all design type category records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.DesignTypeSubCat.DesignTypeSubCat objselectall = new Core.DesignTypeSubCat.DesignTypeSubCat();
            dt4 = objselectall.GetDesignTypeSubCatAll();
            return dt4;
        }

        /// <summary>
        /// Set File name for the all the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_DesignTypeSubCategory_{0}", DateTime.Now.ToString());
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
            dst.overwritetime = Int32.Parse(overtime);
            dst.maxtime = Int32.Parse(maxtime);
            Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
            dtEditChk = objselectall.GetCheckEditAll(dst);
            if (dtEditChk.Rows.Count > 0)
            {
                if (dtEditChk.Rows[0]["PStatus"] != null && (dtEditChk.Rows[0]["PStatus"].ToString() == "InActive" || dtEditChk.Rows[0]["PStatus"].ToString() == "Unchecked"))
                {
                    if (param == "Delete")
                    {
                        #region Delete Block

                        Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatDelete ddel = new Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatDelete();
                        ddel.slno = Int32.Parse(lbslno.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.DesignTypeSubCat.DesignTypeSubCat objdelete = new Core.DesignTypeSubCat.DesignTypeSubCat();
                        rows = objdelete.DesignTypeSubCatDeleteMethod(ddel);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull !','success',3);", true);

                            ASPxGridView1.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit !','warning',3);", true);

                            ASPxGridView1.DataBind();
                        }

                        #endregion Delete Block
                    }
                    else
                    {
                        #region Edit Block

                        Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dtsingle = new Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert();
                        dtsingle.slno = Int32.Parse(lbslno.Text);
                        Core.DesignTypeSubCat.DesignTypeSubCat objselectsingle = new Core.DesignTypeSubCat.DesignTypeSubCat();
                        DataTable dt = objselectsingle.GetDesignTypeSubCatSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            txtName.Text = Convert.ToString(dt.Rows[0]["DesignTypeSubCategoryName"]);
                            lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                            cmbDesignType.Text = Convert.ToString(dt.Rows[0]["DesignTypeName"]);
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',3);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',3);", true);
            }
        }

        #endregion Method

        #region Event

        /// <summary>
        /// Event  performs clean method
        /// </summary>
        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }

        /// <summary>
        /// Event  performs clean method
        /// </summary>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
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
        /// Used for edit the record
        /// </summary>
        protected void CmdEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Edit", Int32.Parse(lbslno.Text));

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
        /// Event performs submit and update action using DataInsert method
        /// </summary>
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
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

            Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert dtsingle = new Data.DesignTypeSubCat.DesignTypeSubCatModel.DesignTypeSubCatInsert();
            dtsingle.slno = Int32.Parse(lbslno.Text);
            Core.DesignTypeSubCat.DesignTypeSubCat objselectsingle = new Core.DesignTypeSubCat.DesignTypeSubCat();
            DataTable dt = objselectsingle.GetDesignTypeSubCatSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dt.Rows[0]["DesignTypeSubCategoryName"]);
                lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                cmbDesignType.Text = Convert.ToString(dt.Rows[0]["DesignTypeName"]);
            }
            else
            {
                #region Edit Block - Code

                ResetFunc();

                #endregion Edit Block - Code

                lbslno.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',3);", true);
            }

            ASPxPageControl1.ActiveTabIndex = 0;

            #endregion Edit Block
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        #endregion Event
    }
}