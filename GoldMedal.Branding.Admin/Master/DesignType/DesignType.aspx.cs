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
    public partial class DesignType : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_DesignType";
        private string Node = "Master";
        private int rows = 0;

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
                if (CheckUserRightsForMaster(userID))
                {
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 0;
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
                }
        }

        #endregion PageEvent

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
        /// perform the action of submit or update  and called by CmdSubmit_Click event
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            Data.DesignType.DesignTypeModel.DesignTypeInsert dst = new Data.DesignType.DesignTypeModel.DesignTypeInsert();
            var name = HttpUtility.HtmlEncode(txtdesigntype.Text.Trim());
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(name)))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Name Should not be empty.!','warning',3);", true);
            }
            else
            {
                dst.Name = ValidateDataType.EnsureMaximumLength(name, 100);
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.pagename = HttpContext.Current.Request.Url.ToString();
                dst.slno = Convert.ToInt16(lbslno.Text);
                dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                if (lbslno.Text == "0")
                {
                    Core.Design.DesignType objinsert = new Core.Design.DesignType();
                    result = objinsert.DesignTypeInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Material already exists !','warning',3);", true);
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Material added successfully !','success',3);", true);
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
                    Core.Design.DesignType objinsert = new Core.Design.DesignType();
                    result = objinsert.DesignTypeInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Material already exists  !','warning',3);", true);
                        ResetFunc();
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Material Updated successfully !','success',3);", true);
                        ResetFunc();
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
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_Fabrication_Material_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            txtdesigntype.Text = string.Empty;
        }

        /// <summary>
        /// returns the datatable which contains the all design type records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.Design.DesignType objselectall = new Core.Design.DesignType();
            dt4 = objselectall.GetDesignTypeAll();
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

                        Data.DesignType.DesignTypeModel.DesignTypeDelete ddel = new Data.DesignType.DesignTypeModel.DesignTypeDelete();
                        ddel.slno = Convert.ToInt32(lbslno.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.Design.DesignType objdelete = new Core.Design.DesignType();
                        rows = objdelete.DesignTypeDeleteMethod(ddel);
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

                        Data.DesignType.DesignTypeModel.DesignTypeInsert dtsingle = new Data.DesignType.DesignTypeModel.DesignTypeInsert();
                        dtsingle.slno = Int32.Parse(lbslno.Text);
                        Core.Design.DesignType objselectsingle = new Core.Design.DesignType();
                        DataTable dt = objselectsingle.GetDesignTypeSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            txtdesigntype.Text = Convert.ToString(dt.Rows[0]["name"]);
                            lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                        }
                        else
                        {
                            #region Reset Block - Code

                            ResetFunc();

                            #endregion Reset Block - Code

                            lbslno.Text = "0";

                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
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
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[1].Visible = false;
            ASPxGridView1.Columns[2].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[1].Visible = true;
            ASPxGridView1.Columns[2].Visible = true;
        }

        #endregion Method

        #region Event

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

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
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

            Data.DesignType.DesignTypeModel.DesignTypeInsert dtsingle = new Data.DesignType.DesignTypeModel.DesignTypeInsert();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.Design.DesignType objselectsingle = new Core.Design.DesignType();
            DataTable dt = objselectsingle.GetDesignTypeSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                txtdesigntype.Text = Convert.ToString(dt.Rows[0]["name"]);
                lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
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

        #endregion Event

        #region Export

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

        #endregion Export
    }
}