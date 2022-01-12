using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Master.SubJobType
{
    public partial class SubJobType : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private const string FILE_DIRECTORY_NAME = "master/subjobtypeimage";
        private string TableNm = "Tbl_SubJobType";
        private string Node = "Master";
        private readonly IGoldMedia _goldMedia;
        private int rows = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Edit Block - Variable

        #region Page Event
        public SubJobType()
        {
            _goldMedia = new GoldMedia();

        }
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

        #endregion Page Event

        #region Methods
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

            #region FileUpload
            string FileName = "";
            string strFileType = "";

            string error = string.Empty;
            if (txtName.Text == "")
            {
                error += "Name Should not be empty.!</br>";
            }
            //if (txtfrmdate.Text == "")
            //{
            //    error += "Image Valid From Date Should not be empty.!</br>";
            //}
            //if (txttodate.Text == "")
            //{
            //    error += "Image Valid To Date Should not be empty.!</br>";
            //}

            bool active;
            if (chkactive.Checked == true)
            {
                active = Convert.ToBoolean(1);
            }
            else
            {
                active = Convert.ToBoolean(0);
            }


            foreach (var file in fuPhoto.PostedFiles)
            {
                if (file.FileName != "")
                {
                    bool rtnVallpost = false;
                    string uploadedFileName = "";

                    SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME);
                    if (rtnVallpost)
                    {

                        strFileType = Path.GetExtension(file.FileName).ToLower();
                        if (FileName == "")
                        {
                            FileName = uploadedFileName;
                        }
                        else
                        {
                            FileName = FileName + ',' + uploadedFileName;
                        }
                    }
                }
            }
            if (lbslno.Text == "0")
            {
                FileName = FileName.TrimEnd(',');
            }
            else
            {
                FileName = FileName.TrimEnd(',');// + ',' + hfReferSheet.Text;
            }
            #endregion
            if (FileName.Trim(',') != "" && (txtfrmdate.Text == "" || txtfrmdate.Text == "01-01-1900"))
            {
                error += "Image Valid From Date Should not be empty.!</br>";
            }
            //if (FileName.Trim(',') == "")
            //{
            //    error += "Image Should not be empty.!</br>";
            //}




            Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dst = new Data.SubJobType.SubJobTypeModel.SubJobTypeInsert();
            var name = HttpUtility.HtmlEncode(txtName.Text.Trim());
            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
                string Fdt = string.Empty;
                if (txtfrmdate.Text == "")
                {
                    txtfrmdate.Text = "01-01-1900";
                }

               // string[] st1 = txtfrmdate.Text.Split('-');
                 string[] st1 = txtfrmdate.Text.Split('/'); 
                if (st1.Length > 2)
                {
                    Fdt = st1[1] + "/" + st1[0] + "/" + st1[2];
                }
                DateTime FromDate = Convert.ToDateTime(Fdt);

                //string Tdt = string.Empty;

                //string[] st2 = txttodate.Text.Split('-');
                //// string[] st2 = txttodate.Text.Split('/');
                //if (st2.Length > 2)
                //{
                //    Tdt = st2[1] + "/" + st2[0] + "/" + st2[2];
                //}
                //DateTime ToDate = Convert.ToDateTime(Tdt);

                dst.Name = ValidateDataType.EnsureMaximumLength(name, 100);
                dst.ISActive = active;
                var submitimg = FileName;
                dst.SubJobtypeimage = submitimg;
                dst.ImageValidFromDate = FromDate;
                //dst.ImageValidToDate = ToDate;
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.pagename = HttpContext.Current.Request.Url.ToString();
                dst.slno = Convert.ToInt32(lbslno.Text);
                dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                if (lbslno.Text == "0")
                {
                    Core.SubJobType.SubJobType objinsert = new Core.SubJobType.SubJobType();
                    result = objinsert.SubJobTypeInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','SubJob Type already exists !','warning',3);", true);
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','SubJob Type added successfully !','success',3);", true);
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
                    Core.SubJobType.SubJobType objinsert = new Core.SubJobType.SubJobType();
                    result = objinsert.SubJobTypeInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','SubJob Type already exists !','warning',3);", true);

                        ResetFunc();
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','SubJob Type Updated successfully !','success',3);", true);
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

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            txtName.Text = string.Empty;
            txtfrmdate.Text = string.Empty;
            chkactive.Checked = false;
            //  txttodate.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            hfReferSheet.Text = "";
            hfReferSheetDelete.Text = "";
            hfReferSheetDelete.Text = string.Empty;
        }

        /// <summary>
        /// returns the datatable which contains the all Sub Job type records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.SubJobType.SubJobType objselectall = new Core.SubJobType.SubJobType();
            dt4 = objselectall.GetSubJobTypeAll();
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

                        Data.SubJobType.SubJobTypeModel.SubJobTypeDelete ddel = new Data.SubJobType.SubJobTypeModel.SubJobTypeDelete();
                        ddel.slno = Convert.ToInt32(lbslno.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.SubJobType.SubJobType objdelete = new Core.SubJobType.SubJobType();
                        rows = objdelete.SubJobTypeDeleteMethod(ddel);
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

                        Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dtsingle = new Data.SubJobType.SubJobTypeModel.SubJobTypeInsert();
                        dtsingle.slno = Convert.ToInt32(lbslno.Text);
                        Core.SubJobType.SubJobType objselectsingle = new Core.SubJobType.SubJobType();
                        DataTable dt = objselectsingle.GetSubJobTypeSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
                            lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                            if (Convert.ToString(dt.Rows[0]["ISActive"]) == "False")
                            {
                                chkactive.Checked = false;
                            }
                            else
                            {
                                chkactive.Checked = true;
                            }
                            if (Convert.ToString(dt.Rows[0]["ImageValidFromDate"]) != "" && Convert.ToDateTime(dt.Rows[0]["ImageValidFromDate"]).ToString("dd/MM/yyyy") != "01-01-0000")
                            {
                                txtfrmdate.Text = Convert.ToDateTime(dt.Rows[0]["ImageValidFromDate"]).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                txtfrmdate.Text = string.Empty;
                            }

                            //if (Convert.ToString(dt.Rows[0]["ImageValidToDate"]) != "" && Convert.ToDateTime(dt.Rows[0]["ImageValidToDate"]).ToString("dd/MM/yyyy") != "01-01-0000")
                            //{
                            //    txttodate.Text = Convert.ToDateTime(dt.Rows[0]["ImageValidToDate"]).ToString("dd/MM/yyyy");
                            //}
                            //else
                            //{
                            //    txttodate.Text = string.Empty;
                            //}


                            hfReferSheet.Text = Convert.ToString(dt.Rows[0]["SubJobTypeImage"]);
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
        /// Set the file name for the export
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_SubJobType_{0}", DateTime.Now.ToString());
        }

        #endregion Methods

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
        /// Event  performs clean method
        /// </summary>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
            ASPxPageControl1.ActiveTabIndex = 1;
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
            checkViewFile();
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

            Data.SubJobType.SubJobTypeModel.SubJobTypeInsert dtsingle = new Data.SubJobType.SubJobTypeModel.SubJobTypeInsert();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.SubJobType.SubJobType objselectsingle = new Core.SubJobType.SubJobType();
            DataTable dt = objselectsingle.GetSubJobTypeSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
                lbslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
                if (Convert.ToString(dt.Rows[0]["ISActive"]) == "false")
                {
                    chkactive.Checked = false;
                }
                else
                {
                    chkactive.Checked = true;
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

            ASPxPageControl1.ActiveTabIndex = 1;

            #endregion Edit Block
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

        protected void lnkFiles_Click(object sender, EventArgs e)
        {
            // lnkvisible.Text = "2";
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 18);
            this.mpeImage.Show();
        }

        protected void GetUploadedJobRequestFiles(int slno, int flag)
        {


            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();
            a = lbslno.Text;
            param.slno = Convert.ToInt32(a);
            param.flag = flag;
            Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            DataTable dtResult = objData.JobRequestChildFilesDACore(param);
            if (dtResult.Rows.Count > 0)
            {
                rptImages.DataSource = dtResult;
                rptImages.DataBind();
                hdNoRecord.Visible = false;
                lblfilename.Text = dtResult.Rows[0][0].ToString();
            }
            else
            {
                rptImages.DataSource = null;
                rptImages.DataBind();
                hdNoRecord.Visible = true;
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
        private string SavePostedFile(out bool rtnVal, HttpPostedFile file, out string uploadedFileName, string FILE_DIRECTORY_NAME)
        {
            rtnVal = false;
            long size = 0;
            string result = string.Empty, contentType = string.Empty, oldFileName = string.Empty, oldFileExtension = string.Empty; uploadedFileName = string.Empty;
            oldFileName = Path.GetFileNameWithoutExtension(file.FileName);
            oldFileExtension = Path.GetExtension(file.FileName);
            var mineTypeAllowed = new MimeType[]
            {

            MimeType.Png,
            MimeType.Jpeg,
            MimeType.Jpg,
            MimeType.Pdf

            };
            #region Validation
            if (String.IsNullOrWhiteSpace(file.FileName))
                return string.Empty;
            if (!GoldMimeType.IsMimeTypeAllowed(oldFileExtension, mineTypeAllowed, out contentType))
            {
                result = string.Format("{0} : Oops!! This type of file upload not allowed.", oldFileName);
                return result;
            }
            if (!GoldMimeType.IsFileSizeAllowed(file.ContentLength, out size, 2000 * 2000 * 10))
            {
                result = string.Format("{0} : Oops!! Max File Size allowed : {1} MB", oldFileName, size / (1024.0 * 1024.0));
                return result;
            }
            #endregion
            var retStr = _goldMedia.GoldMediaUpload(oldFileName, FILE_DIRECTORY_NAME, oldFileExtension, file.InputStream, contentType, true, true);
            if (retStr.Keys.FirstOrDefault())
            {
                var uploadedFilePath = retStr.Values.FirstOrDefault();//save this file path to database
                uploadedFileName = uploadedFilePath.Split('/').Last();
                result = string.Format("Successfully uploaded the file {0} ~ {1}", oldFileName, uploadedFileName);
                string path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, uploadedFileName);

                rtnVal = true;
            }
            else
            {
                result = string.Format("{0} : {1}", oldFileName, retStr.Values.FirstOrDefault());
            }
            return result;
        }


        protected void rptImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
            if (e.CommandName == "cmdRemove")
            {
                hfReferSheet.Text = hfReferSheet.Text.Trim().Replace(hfImgIName.Value, "");
                hfReferSheetDelete.Text = hfReferSheetDelete.Text + ',' + hfImgIName.Value;
                e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                this.mpeImage.Show();
            }
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 8);
            }
        }
        protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
            hfvisible.Value = "false";
            //if (lnkvisible.Text == "2")
            //{
            //    hfvisible.Value = "true";
            //}
            if (hfvisible.Value == "true")
            {
                lnkDelete.Visible = true;
            }
            else
            {
                lnkDelete.Visible = false;
            }
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

        }

        protected void checkViewFile()
        {
            lnkFiles.Text = "";
            string hfimf1 = hfReferSheet.Text.Replace(",", "");
            if (!string.IsNullOrEmpty(hfimf1))
            {
                lnkFiles.Text = "View Files";
            }
        }
    }
}