using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GoldMedal.Branding.Admin.Transaction.AssignJob
{
    public partial class JobAssign : System.Web.UI.Page
    {
        #region Page Event

        /// <summary>
        /// Loade all job heads which contains atleast one child is approved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    gvHead.DataBind();
                    ASPxPageControl1.ActiveTabIndex = 1;
                }
            }
        }
       
        #endregion Page Event

        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        public string party = string.Empty;
        private int rows = 0;
        private string flagImg = string.Empty;
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/visitingcard";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/refersheet";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/brandimage";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_JobRequestHead";
        private string Node = "Transaction";

        #endregion Edit Block - Variable
        public JobAssign()
        {
            _goldMedia = new GoldMedia();
            //  finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }
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

        #endregion Export

        #region Event

        

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
            show();
        }

        /// <summary>
        /// Load grid of job request head
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvHead_DataBinding(object sender, EventArgs e)
        {
            gvHead.DataSource = GetTableHead();
        }

        /// <summary>
        /// Assign the child to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        /// <summary>
        /// Clean the control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            ResetFunc();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        /// <summary>
        /// show the list of approved child for assigning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Edit", Convert.ToInt32(lbslno.Text));

            #endregion Edit Block - Code

            checkViewFile();
        }

        protected void CmdReopen_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
                lbslno.Text = FieldTripID.ToString();
            }
            ReOpenJob();
        }

        protected void ReOpenJob()
        {
            int result = 0;

            if (Convert.ToInt64(lbslno.Text) > 0)
            {
                Data.AssignJob.AssignJobModel.AssignProperties objreopen = new Data.AssignJob.AssignJobModel.AssignProperties();

                objreopen.jobrequestchildidP = Convert.ToInt64(lbslno.Text);
                objreopen.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                objreopen.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                objreopen.pagename = HttpContext.Current.Request.Url.ToString();
                objreopen.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(1));

                Core.AssignJob.AssignJob objinsertAssignJob = new Core.AssignJob.AssignJob();

                result = objinsertAssignJob.ReopenJobMethod(objreopen);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Reopened successfully !','success',3);", true);
                    ResetFunc();
                }
                else if (result == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Job already processed by another user!','error',3);", true);
                    ResetFunc();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Some error occurred.','error',3);", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please refresh page and try again.','error',3);", true);
            }

            ResetFunc();
            clean();
        }

        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 1);
            this.mpeAll.Show();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 2);
            this.mpeAll.Show();
        }

        protected void lnkShowImg_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 1);
            this.mpeAll.Show();
        }

        protected void CmdlnkImage3_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
                lblImageSlno.Text = FieldTripID.ToString();
            }
            GetUploadedJobRequestFiles(Convert.ToInt64(FieldTripID), 3);
            this.mpeAll.Show();
        }

        protected void gvHead_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string VisitingCardImg = e.GetValue("VisitingCardImg").ToString();

            LinkButton hlSubImg = gvHead.FindRowCellTemplateControl(e.VisibleIndex, gvHead.Columns["Visiting Card Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;

            if (VisitingCardImg == "")
            {
                hlSubImg.Visible = false;
            }
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 1)
            {
                gvHead.DataBind();
            }
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox hfImagename = (TextBox)e.Row.FindControl("hfImagename");
                LinkButton CmdlnkImage3 = (LinkButton)e.Row.FindControl("CmdlnkImage3");
                TextBox txtSizeInchHidden = (TextBox)e.Row.FindControl("txtSizeInchHidden");
                Label lblchkisapprov = (Label)e.Row.FindControl("lblchkisapprov");
                ASPxComboBox ddlAssignto = (ASPxComboBox)e.Row.FindControl("ddlAssignto");
                TextBox txtDeadLine = (TextBox)e.Row.FindControl("txtDeadLine");

                if (hfImagename.Text != string.Empty)
                {
                    CmdlnkImage3.Text = "View Files";
                    repType.Value = "3";
                }

                DataTable dt3 = LoadUserList();
                ddlAssignto.Items.Clear();
                ddlAssignto.DataSource = dt3;
                ddlAssignto.DataBind();

                if (lblDesignerID.Text != "0")
                {
                    ddlAssignto.Items.FindByValue(lblDesignerID.Text).Selected = true;
                }

                if (lblDeadline.Text != "0")
                {
                    txtDeadLine.Text = lblDeadline.Text;
                }
            }
        }   

        protected void assigntochanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            ASPxComboBox ddlAssignto = (ASPxComboBox)sender;
            string ddlAssigntoo = ddlAssignto.Value.ToString();
            Data.AssignJob.AssignJobModel.AssignProperties dt = new Data.AssignJob.AssignJobModel.AssignProperties();
            dt.slno = Convert.ToInt32(ddlAssigntoo);
            Core.AssignJob.AssignJob objdataHeadassign = new Core.AssignJob.AssignJob();
            DataTable dtChildassign = objdataHeadassign.UserWorkStatus(dt);
            gvdetail.DataSource = dtChildassign;
            gvdetail.DataBind();
            lblDesignerID.Text = ddlAssigntoo;

            if (gvDetails.Rows.Count > 1)
            {
                if (hfIsDesignerUpdated.Value == "0")
                {
                    BindJobChild();
                    hfIsDesignerUpdated.Value = "1";
                }
            }
            this.mpeImagee.Show();
        }

        protected void txtDeadLine_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDeadline = (TextBox)sender;
            lblDeadline.Text = txtDeadline.Text.ToString();

            if (gvDetails.Rows.Count > 1)
            {
                if (hfIsDesignerDaysUpdated.Value == "0")
                {
                    BindJobChild();
                    hfIsDesignerDaysUpdated.Value = "1";
                }
            }
        }

        protected void BindJobChild()
        {
            Data.AssignJob.AssignJobModel.AssignProperties paramHeadassign = new Data.AssignJob.AssignJobModel.AssignProperties();
            paramHeadassign.slno = Convert.ToInt32(lbslno.Text);

            Core.AssignJob.AssignJob objdataHeadassign = new Core.AssignJob.AssignJob();
            DataTable dtChildassign = objdataHeadassign.JobRequestChildSelectForAssignParticularCore(paramHeadassign);

            for (int i = dtChildassign.Rows.Count + 1; i <= dtChildassign.Rows.Count; i++)
            {
                DataRow row = dtChildassign.NewRow();
                row["slno"] = 0;
                dtChildassign.Rows.Add(row);
            }

            gvDetails.DataSource = dtChildassign;
            gvDetails.DataBind();
        }


        #endregion Event

        #region Method

        private DataTable GetTableHead()
        {

            Data.AssignJob.AssignJobModel.AssignProperties param = new Data.AssignJob.AssignJobModel.AssignProperties();
            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignJob.AssignJob objdata = new Core.AssignJob.AssignJob();
            DataTable dt = objdata.AllJobRequestHeadForAssignDACoreuser(param);
           // DataTable dt = objdata.AllJobRequestHeadForAssignDACore();
            return dt;


            //Core.AssignJob.AssignJob objdata = new Core.AssignJob.AssignJob();
            //DataTable dt = objdata.AllJobRequestHeadForAssignDACore();
            //return dt;
        }

        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            //gvHead.Columns[11].Visible = false;
            //gvHead.Columns[11].Visible = false;
            gvHead.Columns[18].Visible = false;
            gvHead.Columns[23].Visible = false;
            
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            //gvHead.Columns[11].Visible = true;
            //gvHead.Columns[11].Visible = true;
            gvHead.Columns[18].Visible = true;
            gvHead.Columns[23].Visible = true;
            
        }

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Transaction_JobRequest_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// create child grid
        /// </summary>
        private class DummyGrid
        {
            public string slno { get; set; }
            public string refid { get; set; }
            public string TaskID { get; set; }
            public string UnitID { get; set; }
            public string Priority { get; set; }
            public string BoardTypeID { get; set; }
            public string PrintLocation { get; set; }
            public string FabricatorLocation { get; set; }
            public string SizeInch { get; set; }
            public string SizeHeight { get; set; }
            public string JobType { get; set; }
            public string JobSubType { get; set; }
            public string Material { get; set; }
            public string Product { get; set; }
            public string Qty { get; set; }
            public string InstallAddress { get; set; }
            public string Remark { get; set; }
            public string NeedApproval { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string JobTypeId { get; set; }
            public string SubJobTypeId { get; set; }
            public string SubSubJobTypeId { get; set; }
            public string DesignTypeId { get; set; }
            public string ProductTypeId { get; set; }
            public string Image { get; set; }
            public string ChildStatus { get; set; }
        }

        protected void BindGridview()
        {
            DummyGrid test1 = new DummyGrid()
            {
                slno = string.Empty,
                refid = string.Empty,
                UnitID = string.Empty,
                Priority = string.Empty,
                TaskID = string.Empty,
                BoardTypeID = string.Empty,
                PrintLocation = string.Empty,
                FabricatorLocation = string.Empty,
                SizeInch = string.Empty,
                SizeHeight = string.Empty,
                JobType = string.Empty,
                JobSubType = string.Empty,
                Material = string.Empty,
                Product = string.Empty,
                Qty = string.Empty,
                InstallAddress = string.Empty,
                Remark = string.Empty,
                NeedApproval = "False",
            };
            List<DummyGrid> list = new List<DummyGrid>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(test1);
            }

            gvDetails.DataSource = list;
            gvDetails.DataBind();
        }

        protected void checkViewFile()
        {
            lnkFiles2.Text = string.Empty;
            if (!string.IsNullOrEmpty(hfVisitingImage.Text))
            {
                lnkFiles2.Text = "View Files";
            }
            lnkFiles3.Text = string.Empty;
            if (!string.IsNullOrEmpty(hfReferSheet.Text))
            {
                lnkFiles3.Text = "View Files";
            }
        }

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
            dst.usercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(1));
            dst.overwritetime = Convert.ToInt32(overtime);
            dst.maxtime = Convert.ToInt32(maxtime);
            Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
            dtEditChk = objselectall.GetCheckEditAll(dst);
            if (dtEditChk.Rows.Count > 0)
            {
                if (dtEditChk.Rows[0]["PStatus"] != null && (dtEditChk.Rows[0]["PStatus"].ToString() == "InActive" || dtEditChk.Rows[0]["PStatus"].ToString() == "Unchecked"))
                {
                    show();
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

        /// <summary>
        /// show child and head record of the job head selected.
        /// </summary>
        protected void show()
        {
            #region Edit Block

            Data.JobRequest.JobRequestModel.JobRequestProperties paramHead = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            paramHead.slno = Convert.ToInt32(lbslno.Text);

            Core.JobRequest.JobRequest objdataHead = new Core.JobRequest.JobRequest();
            DataTable dtHead = objdataHead.JobRequestHeadSelectParticularCore(paramHead);

            Data.AssignJob.AssignJobModel.AssignProperties paramHeadassign = new Data.AssignJob.AssignJobModel.AssignProperties();
            paramHeadassign.slno = Convert.ToInt32(lbslno.Text);

            if (dtHead.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dtHead.Rows[0]["reqno"]);

                lblNameType.Text = Convert.ToString(dtHead.Rows[0]["NameType"]);
                lblName.Text = Convert.ToString(dtHead.Rows[0]["AllName"]);
                lblAddress.Text = Convert.ToString(dtHead.Rows[0]["AllAddress"]);

                lblContact.Text = Convert.ToString(dtHead.Rows[0]["contactnumber"]);
                lblContactPerson.Text = Convert.ToString(dtHead.Rows[0]["ContactPerson"]);
                lblEmail.Text = Convert.ToString(dtHead.Rows[0]["Email"]);
                lblDate.Text = Convert.ToString(dtHead.Rows[0]["RequestDate"]);
                lblSubName.Text = Convert.ToString(dtHead.Rows[0]["name"]);
                lblSubAddress.Text = Convert.ToString(dtHead.Rows[0]["SubAddress"]);
                lblSubContact.Text = Convert.ToString(dtHead.Rows[0]["SubContact"]);
                lblGivenBy.Text = Convert.ToString(dtHead.Rows[0]["GivenByName"]);

                lblSubmittedBy.Text = Convert.ToString(dtHead.Rows[0]["submittedby"]);
                lblApprovedBy.Text = Convert.ToString(dtHead.Rows[0]["approvedby"]);

                hfVisitingImage.Text = Convert.ToString(dtHead.Rows[0]["VisitingCardImg"]);
                hfReferSheet.Text = Convert.ToString(dtHead.Rows[0]["ReferSheet"]);

                lblFirmName.Text = Convert.ToString(dtHead.Rows[0]["Subcompname"]);

                lblCinNo.Text = Convert.ToString(dtHead.Rows[0]["cinnum"]);
       

                Core.AssignJob.AssignJob objdataHeadassign = new Core.AssignJob.AssignJob();
                DataTable dtChildassign = objdataHeadassign.JobRequestChildSelectForAssignParticularCore(paramHeadassign);

                for (int i = dtChildassign.Rows.Count + 1; i <= dtChildassign.Rows.Count; i++)
                {
                    DataRow row = dtChildassign.NewRow();
                    row["slno"] = 0;
                    dtChildassign.Rows.Add(row);
                }

                gvDetails.DataSource = dtChildassign;
                gvDetails.DataBind();



                LblRequestNo.Focus();
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
        /// Show list of users
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadUserList()
        {
            Core.AssignJob.AssignJob db = new Core.AssignJob.AssignJob();
            DataTable dt = db.AllUsersDACore();
            return dt;
        }

        /// <summary>
        /// assign the child to a user.
        /// </summary>
        protected void Submit()
        {
            int result = 0;
            int errorrow = 1;
            string error = string.Empty;
            string selectedAssignto = "0";
            if (gvDetails.Rows.Count > 0)
            {
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
                    string txtDeadLine = ((TextBox)row.FindControl("txtDeadLine")).Text;
                    string lblwidth = ((Label)row.FindControl("lblwidth")).Text;
                    string hfslnochild = ((HiddenField)row.FindControl("hfslnochild")).Value;

                    ASPxComboBox ddlAssignto = (ASPxComboBox)row.FindControl("ddlAssignto");

                    if (ddlAssignto.Value == null)
                    {
                        selectedAssignto = "0";
                    }
                    else
                    {
                        selectedAssignto = ddlAssignto.Value.ToString();
                    }

                    if ((!string.IsNullOrEmpty(lblwidth)) && (selectedAssignto != "0"))
                    {
                        if ((string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(selectedAssignto))) || (string.IsNullOrEmpty(ValidateDataType.EnsureNotZero(selectedAssignto))) || (string.IsNullOrEmpty(ValidateDataType.EnsureNumericOnly(selectedAssignto))))
                        {
                            error += "Empty or some invalid data  in row no= " + errorrow + "   for assign type</br>";
                        }

                        if ((string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(txtDeadLine))) || (string.IsNullOrEmpty(ValidateDataType.EnsureNumericOnly(txtDeadLine))))
                        {
                            //error += "Empty or some invalid data  in row no=" + errorrow + "  for dead line</br>";
                            error += "Please define dead line</br>";
                        }

                        if ((string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(hfslnochild))) || (string.IsNullOrEmpty(ValidateDataType.EnsureNotZero(hfslnochild))) || (string.IsNullOrEmpty(ValidateDataType.EnsureNumericOnly(hfslnochild))))
                        {
                            error += "Empty or some invalid data  in row no=" + errorrow + "  for serial no'</br>";
                        }
                    }
                    errorrow = errorrow + 1;
                    ResetFunc();
                }
                if (error == string.Empty)
                {
                    Data.AssignJob.AssignJobModel.AssignProperties AssignDst = new Data.AssignJob.AssignJobModel.AssignProperties();
                    string success = string.Empty;
                    foreach (GridViewRow row in gvDetails.Rows)
                    {
                        string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
                        string txtDeadLine = ((TextBox)row.FindControl("txtDeadLine")).Text;
                        string lblwidth = ((Label)row.FindControl("lblwidth")).Text;
                        string hfslnochild = ((HiddenField)row.FindControl("hfslnochild")).Value;
                        ASPxComboBox ddlAssignto = (ASPxComboBox)row.FindControl("ddlAssignto");

                        if (ddlAssignto.Value == null)
                        {
                            selectedAssignto = "0";
                        }
                        else
                        {
                            selectedAssignto = ddlAssignto.Value.ToString();
                        }
                        if ((!string.IsNullOrEmpty(lblwidth)) && (selectedAssignto != "0"))
                        {
                            var childsno = HttpUtility.HtmlEncode(hfslnochild);
                            var Remark = HttpUtility.HtmlEncode(txtRemark);
                            var DeadLine = HttpUtility.HtmlEncode(txtDeadLine);
                            var Assignto = HttpUtility.HtmlEncode(selectedAssignto);
                            AssignDst.Assignto = Convert.ToInt64(Assignto);

                            AssignDst.Remark = ValidateDataType.EnsureMaximumLength(Remark, 8000);
                            AssignDst.deadline = Convert.ToInt16(DeadLine);
                            AssignDst.jobrequestchildidP = Convert.ToInt64(hfslnochild);
                            AssignDst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                            AssignDst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                            AssignDst.pagename = HttpContext.Current.Request.Url.ToString();
                            AssignDst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(1));
                            Core.AssignJob.AssignJob objinsertAssignJob = new Core.AssignJob.AssignJob();
                            AssignDst.reqno= HttpUtility.HtmlEncode(LblRequestNo.Text);
                            //getrequestno();
                            AssignDst.assignrequestno = lbassignrequestno.Text;
                            AssignDst.finyear = finYear;

                            result = objinsertAssignJob.AssignJobInsertMethod(AssignDst);
                            if (result == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Assigned successfully !','success',3);", true);
                                ResetFunc();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                                ResetFunc();
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','There is no job for assign.','error',3);", true);
            }
            ResetFunc();
            clean();
        }

        /// <summary>
        /// clean the record.
        /// </summary>
        protected void clean()
        {
            LblRequestNo.Text = string.Empty;

            lblNameType.Text = string.Empty;
            lblName.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblContact.Text = string.Empty;
            lblContactPerson.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblSubName.Text = string.Empty;
            lblSubAddress.Text = string.Empty;
            lblSubContact.Text = string.Empty;
            lblGivenBy.Text = string.Empty;
            lbassignrequestno.Text = string.Empty;

            lblSubmittedBy.Text = string.Empty;
            lblApprovedBy.Text = string.Empty;

            lblCinNo.Text = string.Empty;

            Data.AssignJob.AssignJobModel.AssignProperties paramHeadassign = new Data.AssignJob.AssignJobModel.AssignProperties();
            paramHeadassign.slno = Convert.ToInt32(lbslno.Text);
            Core.AssignJob.AssignJob objdataHeadassign = new Core.AssignJob.AssignJob();
            DataTable dtChildassign = objdataHeadassign.JobRequestChildSelectForAssignParticularCore(paramHeadassign);
            for (int i = dtChildassign.Rows.Count + 1; i <= dtChildassign.Rows.Count; i++)
            {
                DataRow row = dtChildassign.NewRow();
                row["slno"] = 0;
                dtChildassign.Rows.Add(row);
            }
            gvDetails.DataSource = dtChildassign;
            gvDetails.DataBind();
            hfVisitingImage.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            lbslno.Text = "0";
            hfIsDesignerUpdated.Value = "0";
            hfIsDesignerDaysUpdated.Value = "0";
            gvHead.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void getrequestno()
        {
            Data.AssignJob.AssignJobModel.AssignProperties getdtl = new Data.AssignJob.AssignJobModel.AssignProperties();
          
            Core.AssignJob.AssignJob objdataHead = new Core.AssignJob.AssignJob();
            DataTable dtreqno = objdataHead.AssReqnoCore(getdtl);
            if (dtreqno.Rows.Count > 0)
            {
                lbassignrequestno.Text = Convert.ToString(dtreqno.Rows[0]["reqno"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','SomeThingWrong.','error',2);", true);
            }

        }
        #endregion Method


        protected void GetUploadedJobRequestFiles(long slno, int flag)
        {
            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();

            hfPopupImageFlag.Value = flag.ToString();
            param.slno = slno;
            param.flag = flag;

            Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            DataTable dtResult = objData.JobRequestChildFilesDACore(param);
            if (dtResult.Rows.Count > 0)
            {
                rptAllImages.DataSource = dtResult;
                rptAllImages.DataBind();
                hdAllNoRecord.Visible = false;
            }
            else
            {
                rptAllImages.DataSource = null;
                rptAllImages.DataBind();
                hdAllNoRecord.Visible = true;
            }
        }

        protected void rptAllImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hfPImgName = (HiddenField)e.Item.FindControl("hfPImgName");

            var path = "";

            if (e.CommandName == "Down")
            {
                if (hfPopupImageFlag.Value == "1")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 1);
                }
                else if (hfPopupImageFlag.Value == "2")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 2);
                }
                else if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblImageSlno.Text), 3);
                }
            }
        }
        protected void rptAllImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Image imgDocs = (Image)e.Item.FindControl("imgDocs");
            HiddenField hfPImgName = (HiddenField)e.Item.FindControl("hfPImgName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");

            var PictureIDPath = "";
            var FileIdPath = "";

            if (hfPopupImageFlag.Value == "1")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "2")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "3")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
            }


            if (hfPImgName.Value.Contains(".jpg") || hfPImgName.Value.Contains(".png") || hfPImgName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
            }
            if (hfPImgName.Value.Contains(".pdf"))
            {
                imgDocs.ImageUrl = "~/images/pdf-icon.png";
                imgDocs.ToolTip = "Download Pdf";
                hyLink.NavigateUrl = FileIdPath;

            }
            if (hfPImgName.Value.Contains(".xlsx"))
            {
                imgDocs.ImageUrl = "~/images/excell-icon.png";
                imgDocs.ToolTip = "Download xlsx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".xls"))
            {
                imgDocs.ImageUrl = "~/images/xls-icon.jpg";
                imgDocs.ToolTip = "Download xls";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".docx"))
            {
                imgDocs.ImageUrl = "~/images/docx-icon.png";
                imgDocs.ToolTip = "Download docx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".doc"))
            {
                imgDocs.ImageUrl = "~/images/doc-icon.jpg";
                imgDocs.ToolTip = "Download doc";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".txt"))
            {
                imgDocs.ImageUrl = "~/images/txt-icon.jpg";
                imgDocs.ToolTip = "Download txt";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".pptx"))
            {
                imgDocs.ImageUrl = "~/images/ppt-icon.png";
                imgDocs.ToolTip = "Download pptx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".ppt"))
            {
                imgDocs.ImageUrl = "~/images/ppt-icon.png";
                imgDocs.ToolTip = "Download ppt";
                hyLink.NavigateUrl = FileIdPath;
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

    }
}