using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Master.BoardType
{
    public partial class BoardType : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int rows = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_BoardType";
        private string Node = "Master";

        #endregion Edit Block - Variable

        #region PageEvent

        /// <summary>
        /// In the Page Lode lblslno is 0 by which program deside the process of submit button which can be submit the record or update the record and also lode the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if(CheckUserRightsForMaster(userID))
                {
                    LoadJobTypes();
                    lbslno.Text = "0";
                    ASPxGridView1.DataBind();
                   
                    ASPxPageControl1.ActiveTabIndex = 1;
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
               
            }
        }

        #endregion PageEvent

        #region Event


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
        /// Event perform submit and update action using DataInsert method
        /// </summary>
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void chkIsFabricatorLocationReq_CheckedChanged(object sender, EventArgs e)
        {
            bool isfabloc = chkIsFabricatorLocationReq.Checked;

            if (isfabloc)
            {
                chkIsPrintLocationReq.Checked = true;
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

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
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

        /// <summary>
        /// Event  performs clean method
        /// </summary>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        #endregion Event

        #region Export

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


        public void LoadJobTypes()
        {
            Core.JobType.JobType db = new Core.JobType.JobType();
            DataTable jobdt = db.GetJobTypeAll();

            lbJobTypes.Items.Clear();

            lbJobTypes.DataSource = jobdt;
            lbJobTypes.DataBind();
        }

        /// <summary>
        /// perform the action of submit or update  and called by CmdSubmit_Click event
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            bool print;
            bool fabricator;

            Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dst = new Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate();

            var boardtype = HttpUtility.HtmlEncode(txtBoardType.Text.Trim());

            string jobtypes = "";

            for (int i = 0; i < lbJobTypes.Items.Count; i++)
            {
                if (lbJobTypes.Items[i].Selected == true)
                {
                    jobtypes += lbJobTypes.Items[i].Value.ToString() + ",";
                }
            }

            if (jobtypes != "")
            {
                jobtypes = jobtypes.Remove(jobtypes.Length - 1);
            }

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(boardtype)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Name Should not be empty.!','warning',3);", true);
            }
            else if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(jobtypes)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Select atleast one job type.!','warning',3);", true);
            }
            else if (chkIsFabricatorLocationReq.Checked == true && chkIsPrintLocationReq.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Printer location is required when fabricator location is selected!','warning',3);", true);
            }
            else
            {
                if (chkIsPrintLocationReq.Checked == true)
                {
                    print = Convert.ToBoolean(1);
                }
                else
                {
                    print = Convert.ToBoolean(0);
                }
                if (chkIsFabricatorLocationReq.Checked == true)
                {
                    fabricator = Convert.ToBoolean(1);
                }
                else
                {
                    fabricator = Convert.ToBoolean(0);
                }

                dst.BoardType = ValidateDataType.EnsureMaximumLength(boardtype, 200);
                dst.JobTypes = ValidateDataType.EnsureMaximumLength(jobtypes, 1000);
                dst.IsPrintLocationReq = print;
                dst.IsFabricatorLocationReq = fabricator;
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.pagename = HttpContext.Current.Request.Url.ToString();
                dst.slno = Convert.ToInt16(lbslno.Text);
                dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));

                if (lbslno.Text == "0")
                {
                    Core.BoardType.BoardType objinsert = new Core.BoardType.BoardType();
                    result = objinsert.BoardTypeInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Board Type already exists !','warning',3);", true);
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Board Type added successfully !','success',3);", true);
                        ASPxGridView1.DataBind();
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                    }
                }
                else
                {
                    Core.BoardType.BoardType objinsert = new Core.BoardType.BoardType();
                    result = objinsert.BoardTypeInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Board Type already exists !','warning',3);", true);

                        ResetFunc();
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Board Type updated successfully !','success',3);", true);
                        ResetFunc();
                        ASPxGridView1.DataBind();
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        ResetFunc();
                        clean();
                    }
                    ResetFunc();
                }
            }
        }

        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[4].Visible = false;
            ASPxGridView1.Columns[5].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[4].Visible = true;
            ASPxGridView1.Columns[5].Visible = true;
        }

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            txtBoardType.Text = string.Empty;

            for (int i = 0; i < lbJobTypes.Items.Count; i++)
            {
                lbJobTypes.Items[i].Selected = false;
            }

            chkIsPrintLocationReq.Checked = false;
            chkIsFabricatorLocationReq.Checked = false;

            ASPxPageControl1.ActiveTabIndex = 1;
        }

        /// <summary>
        /// returns the datatable which contains the all job type records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.BoardType.BoardType objselectall = new Core.BoardType.BoardType();
            dt4 = objselectall.GetBoardTypeAll();
            return dt4;
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

                        Data.BoardType.BoardTypeModel.BoardTypeDelete ddel = new Data.BoardType.BoardTypeModel.BoardTypeDelete();
                        ddel.slno = Convert.ToInt32(lbslno.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.BoardType.BoardType objdelete = new Core.BoardType.BoardType();
                        rows = objdelete.BoardTypeDelete(ddel);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull ! !','success',3);", true);
                            ASPxGridView1.DataBind();
                            clean();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit','warning',3);", true);
                            clean();
                        }

                        #endregion Delete Block
                    }
                    else
                    {
                        #region Edit Block
                        ASPxPageControl1.ActiveTabIndex = 0;
                        Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dtsingle = new Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate();
                        dtsingle.slno = Convert.ToInt32(lbslno.Text);
                        Core.BoardType.BoardType objselectsingle = new Core.BoardType.BoardType();
                        DataTable dt = objselectsingle.GetBoardTypeSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                            txtBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);

                            for (int i = 0; i < lbJobTypes.Items.Count; i++)
                            {
                                lbJobTypes.Items[i].Selected = false;
                            }

                            if (!string.IsNullOrEmpty(dt.Rows[0]["JobTypes"].ToString()))
                            {
                                foreach (var item in Convert.ToString(dt.Rows[0]["JobTypes"]).Split(','))
                                {
                                    if (item != "" && lbJobTypes.Items.FindByValue(item) != null)
                                    {
                                        lbJobTypes.Items.FindByValue(item).Selected = true;
                                    }
                                }
                            }

                            if (Convert.ToString(dt.Rows[0]["IsPrintLocationReq"]) == "False")
                            {
                                chkIsPrintLocationReq.Checked = false;
                            }
                            else
                            {
                                chkIsPrintLocationReq.Checked = true;
                            }
                            if (Convert.ToString(dt.Rows[0]["IsFabricatorLocationReq"]) == "False")
                            {
                                chkIsFabricatorLocationReq.Checked = false;
                            }
                            else
                            {
                                chkIsFabricatorLocationReq.Checked = true;
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

        

        /// <summary>
        /// set the name of page for the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_BoardType_{0}", DateTime.Now.ToString());
        }

        #endregion Method
    }
}