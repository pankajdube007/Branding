using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
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

namespace GoldMedal.Branding.Admin.Transaction.Approvdisapprovdesignsubmit
{
    public partial class apdapdesignsubmit : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

        #region PageEvent

        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {

                if(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();

                }
               


            }
        }

        #endregion PageEvent

        #region Events

        /// <summary>
        /// Show the image which are added  in job request child.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
            this.mpeImage.Show();
        }

        /// <summary>
        /// Show the image which are added  in designsubmit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 4);
            this.mpeImage1.Show();
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
 
            if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                ASPxGridView2.DataBind();
            }
            else if (e.Tab.Index == 3)
            {
                ASPxGridView3.DataBind();
            }
        }

        /// <summary>
        /// track the location of the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     
        /// <summary>
        /// show the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show2();
        }

        protected void CmdEdit3_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show2();
        }

        protected void CmdEdit2_Command(object sender, CommandEventArgs e)
        {
            string[] commandData = e.CommandArgument.ToString().Split(':');

            int FieldTripID = Convert.ToInt32(commandData[0]);

            lbslno.Text = FieldTripID.ToString();
            txtPopupEmail.Text = commandData[1];

            lbluniquekey.Text = commandData[2];

            hfSlno.Value = FieldTripID.ToString();
            

            this.mpeImage2.Show();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetApprovedJobs();
        }

        protected void ASPxGridView3_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView3.DataSource = GetDisApprovedJobs();
        }

        /// <summary>
        /// Call Clean Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        /// <summary>
        /// Call the disapprove method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDisapprove_Click(object sender, EventArgs e)
        {
            DisApprove();
        }

        /// <summary>
        /// call the approve method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// call the disapprove method with cancel condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDisapprovecancel_Click(object sender, EventArgs e)
        {
            DisApproveandcancel();
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// List Of Assigned Job submited by the user.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllDesignSubmitByUserforapprovel(dsp);
            return dt4;
        }

        private DataTable GetApprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllSubmitedDesignApprovedByUser(dsp);
            return dt4;
        }

        private DataTable GetDisApprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllSubmitedDesignDisapprovedByParty(dsp);
            return dt4;
        }

        protected void ASPxGridView2_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string Approval = e.GetValue("needapproval").ToString();

            string producttype = e.GetValue("product").ToString();

            LinkButton lbSend = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Email Action"] as GridViewDataTextColumn, "CmdEdit") as LinkButton;

            if (producttype != "Live Product")
            {
                if (Convert.ToBoolean(Approval))
                {
                    lbSend.Visible = true;
                }
                else
                {
                    lbSend.Visible = false;
                }
            }
            else
            {
                lbSend.Visible = false;
            }
        }

        /// <summary>
        /// fill all the control of the selected submited design.
        /// </summary>
        protected void show2()
        {
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectsingle = new Core.DesignSubmit.DesignSubmit();
            DataTable dt = objselectsingle.GetDetailOfDesignSubmitByUser(dtsingle);
            if (dt.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]) + '(' + Convert.ToString(dt.Rows[0]["AssignRequestNo"]) + ')';
                lblDate.Text = Convert.ToString(dt.Rows[0]["jobrequestdate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["nametype"]);
                lblName.Text = Convert.ToString(dt.Rows[0]["Distributor"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["distaddress"]);
                lblContact.Text = Convert.ToString(dt.Rows[0]["distcontact"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["distcontactperson"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["distemail"]);
                lblsndemail.Text = Convert.ToString(dt.Rows[0]["sndemail"]);
                lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                lblSubAddress.Text = Convert.ToString(dt.Rows[0]["subaddress"]);
                lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                subjobtype.Text = Convert.ToString(dt.Rows[0]["subjob"]);
                subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjob"]);
                designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                product.Text = Convert.ToString(dt.Rows[0]["product"]);
                lbltotalamount.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["jobrequestchildid"]);
                lblassignto.Text = Convert.ToString(dt.Rows[0]["Assignto"]);
                lblneedapr.Text = Convert.ToString(dt.Rows[0]["needapproval"]);
                lbluniquekey.Text = Convert.ToString(dt.Rows[0]["uniquekey"]);
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);
                deslink.Text = Convert.ToString(dt.Rows[0]["designlink"]);
                deslink.NavigateUrl = Convert.ToString(dt.Rows[0]["designlink"]);
                lblBranchID.Text = Convert.ToString(dt.Rows[0]["branchid"]);

                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);

                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);

                partyremark.Style.Add("display", "block");
                lblPartyRemarks.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);


                loadsizechild(Convert.ToString(dt.Rows[0]["Height"]), Convert.ToString(dt.Rows[0]["Width"]));


                //lblHeadSlno.Text = Convert.ToString(dt.Rows[0]["HeadSlno"]);
                //lblPlaceSize.Text = Convert.ToString(dt.Rows[0]["isplacesize"]) == "False" ? "No" : "Yes";
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["AprrovalRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);
                lblDesignRemark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);



                //lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                //if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                //{
                //    lbVisitingCardImg.Visible = true;
                //}

                //if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                //{
                //    lbReferSheetImg.Visible = true;
                //}

            }
            loadchild();
            ////loadsizechild();
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        /// <summary>
        /// Loads the grid of Item child .
        /// </summary>
        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }

        /// <summary>
        /// Loads the grid of Size child .
        /// </summary>
        private void loadsizechild(string height,string width)
        {
            DataTable dt6 = new DataTable();
            //Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            //dchildlist.slno = Convert.ToInt32(lbslno.Text);
            //Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            //dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);

            dt6.Columns.Add("BoardHeight", typeof(string));
            dt6.Columns.Add("BoardWidth", typeof(string));
            dt6.Rows.Add(height, width);
            gvSizeChild.DataSource = dt6;
            gvSizeChild.DataBind();
        }

        /// <summary>
        /// show the name of image accounding the link
        /// </summary>
        /// <param name="slno"></param>
        /// <param name="flag"></param>
        protected void GetUploadedJobRequestFiles(int slno, int flag)
        {
            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();
            if (flag == 3)
            {
                a = lblchildid.Text;

                param.slno = Convert.ToInt32(a);
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
            else if(flag == 16)
            {
                a = lbslno.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;
                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
                DataTable dtResult = objData.JobRequestChildFilesDACore(param);
                if (dtResult.Rows.Count > 0)
                {
                    Repeater2.DataSource = dtResult;
                    Repeater2.DataBind();
                    hdNoRecord2.Visible = false;
                    
                }
                else
                {
                    Repeater2.DataSource = null;
                    Repeater2.DataBind();
                    hdNoRecord2.Visible = true;
                }
            }
            else
            {
                a = lbslno.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;
                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
                DataTable dtResult = objData.JobRequestChildFilesDACore(param);
                if (dtResult.Rows.Count > 0)
                {
                    rptImages1.DataSource = dtResult;
                    rptImages1.DataBind();
                    hdNoRecord1.Visible = false;
                   
                }
                else
                {
                    rptImages1.DataSource = null;
                    rptImages1.DataBind();
                    hdNoRecord1.Visible = true;
                }
            }
        }

        /// <summary>
        /// for approve the design submit
        /// </summary>
        private void Approve()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one for approval..','error',3);", true);
            }
            else
            {
                string result = "0";
                string emailerror = string.Empty;

                string error = string.Empty;
                Data.ApproveJob.ApproveJobModel.ApproveProperties ApproveDst = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
                string success = string.Empty;

                if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                {
                    ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                }

                // GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("homebranchid");
                ApproveDst.moduleid = 38;
                ApproveDst.slno = Convert.ToInt32(lbslno.Text);
                ApproveDst.tableNm = TableNme;
                ApproveDst.apdisapremarks = ValidateDataType.EnsureMaximumLength((HttpUtility.HtmlEncode(txtremark.Text)), 6000);
                ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                result = objinsertAssignJob.ApproveJobInsertMethod(ApproveDst);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {
                    if (lblneedapr.Text == "True" && (product.Text.ToLower() != "live product"))
                    {
                        string url = "https://branding.goldmedalindia.in/Transaction/ApproveByParty/ApproveDesign.aspx?uniquekey=" + lbluniquekey.Text;
                        string subject2 = "<table style='width: 100 %; '><tr><td>&nbsp;</td><td>Dear Sir,</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>Please find your design and approve as soon as possible.</a></td><td>&nbsp;</td></tr><tr><td>&nbsp;&nbsp;<a href=" + url + ">Click Here</a></td><td>&nbsp;</td><td>&nbsp;</td></tr></table>";
                        Core.DesignSubmit.DesignSubmit ds = new Core.DesignSubmit.DesignSubmit();
                        emailerror = ds.sendmail(lblsndemail.Text, subject2, "Approve Design", string.Empty, string.Empty);
                        if (emailerror == "0")
                        {
                            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            designsub.sendemial = lblsndemail.Text;
                            designsub.slno = Convert.ToInt32(lbslno.Text);
                            Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                            int resultemail = 0;
                            resultemail = cdsub.UpdateEmail(designsub);
                            if (resultemail == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved and mail send and updated  successfully !','success',3);", true);
                            }
                            if (resultemail != 1)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully and mail sent but not updated  !','success',3);", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully but mail not sent !','success',3);", true);
                        }
                        clean();
                    }
                    else if (lblneedapr.Text == "False" && (product.Text.ToLower() != "live product"))
                    {
                        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                        Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                        int resultemail2 = 0;
                        designsub.slno = Convert.ToInt32(lbslno.Text);
                        resultemail2 = cdsub.UpdateFinalApr(designsub);
                        if (resultemail2 == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Approved By Designhead And There is no need of email and approval from managementant But The Final Approval Has Failed.  ','error',3);", true);
                        }
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);
                    }
                    clean();
                }
            }
            clean();
        }

        /// <summary>
        /// For disapprove the design submit
        /// </summary>
        private void DisApprove()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one for approval..','error',3);", true);
            }
            else
            {
                string result = "0";
                int result2 = 0;
                string emailerror = string.Empty;

                string error = string.Empty;
                Data.ApproveJob.ApproveJobModel.ApproveProperties ApproveDst = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
                string success = string.Empty;

                if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                {
                    ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                }

                //GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("homebranchid");
                ApproveDst.moduleid = 25;
                ApproveDst.slno = Convert.ToInt32(lbslno.Text);
                ApproveDst.tableNm = TableNme;
                ApproveDst.apdisapremarks = ValidateDataType.EnsureMaximumLength((HttpUtility.HtmlEncode(txtremark.Text)), 6000);
                ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                
                Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                result = objinsertAssignJob.DisApproveJobInsertMethod(ApproveDst);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {
                    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty ds = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                    ds.slno = Convert.ToInt32(lbslno.Text);
                    ds.assignslno = Convert.ToInt32(lblassignto.Text);
                    ds.remark = txtremark.Text;
                    ds.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    ds.status = "Disapproved";
                    
                    Core.DesignSubmit.DesignSubmit cds = new Core.DesignSubmit.DesignSubmit();
                    result2 = cds.DesignSubmitTrackInsertMethod(ds);
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','DisApproved successfully !','success',3);", true);
                }
            }
            clean();
        }

        /// <summary>
        /// For disapprove and the design submit the design submit
        /// </summary>
        private void DisApproveandcancel()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one for approval..','error',3);", true);
            }
            else
            {
                string result = "0";
                int result2 = 0;
                string emailerror = string.Empty;

                string error = string.Empty;
                Data.ApproveJob.ApproveJobModel.ApproveProperties ApproveDst = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
                string success = string.Empty;

                if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                {
                    ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                }

                //GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("homebranchid");

                ApproveDst.moduleid = 38;
                ApproveDst.slno = Convert.ToInt32(lbslno.Text);
                ApproveDst.tableNm = TableNme;
                ApproveDst.apdisapremarks = ValidateDataType.EnsureMaximumLength((HttpUtility.HtmlEncode(txtremark.Text)), 6000);
                ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                result = objinsertAssignJob.DisApproveJobInsertMethod(ApproveDst);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {
                    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty ds = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                    ds.slno = Convert.ToInt32(lbslno.Text);
                    ds.assignslno = Convert.ToInt32(lblassignto.Text);
                    ds.remark = txtremark.Text;
                    ds.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    ds.status = "Cancel";
                    
                    Core.DesignSubmit.DesignSubmit cds = new Core.DesignSubmit.DesignSubmit();
                    result2 = cds.DesignSubmitTrackInsertMethod(ds);

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','DisApproved successfully !','success',3);", true);
                }
            }
            clean();
        }


        private void SendEmail()
        {
            string emailerror = string.Empty;

            if (hfSlno.Value == "0" || hfPopupEmail.Value == "0" || lbluniquekey.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one for resend email.','error',3);", true);
            }
            else
            {
                string url = "https://branding.goldmedalindia.in/Transaction/ApproveByParty/ApproveDesign.aspx?uniquekey=" + lbluniquekey.Text;
                string subject2 = "<table style='width: 100 %; '><tr><td>&nbsp;</td><td>Dear Sir,</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>Please find your design and approve as soon as possible.</a></td><td>&nbsp;</td></tr><tr><td>&nbsp;&nbsp;<a href=" + url + ">Click Here</a></td><td>&nbsp;</td><td>&nbsp;</td></tr></table>";
                Core.DesignSubmit.DesignSubmit ds = new Core.DesignSubmit.DesignSubmit();
                emailerror = ds.sendmail(hfPopupEmail.Value, subject2, "Approve Design", string.Empty, string.Empty);
                if (emailerror == "0")
                {
                    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                    designsub.sendemial = hfPopupEmail.Value;
                    designsub.slno = Convert.ToInt32(hfSlno.Value);
                    Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                    int resultemail = 0;
                    resultemail = cdsub.UpdateEmail(designsub);
                    if (resultemail == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mail sent successfully !','success',3);", true);
                    }
                    if (resultemail != 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mail sent successfully but not updated!','success',3);", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mail not sent. Please try again!','error',3);", true);
                }
            }

            hfSlno.Value = "0";
            hfPopupEmail.Value = "0";

            ASPxGridView2.DataBind();
        }

        /// <summary>
        /// Clean all the control
        /// </summary>
        protected void clean()
        {
            LblRequestNo.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblNameType.Text = string.Empty;
            lblName.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblContact.Text = string.Empty;
            lblContactPerson.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblsndemail.Text = string.Empty;
            lblSubName.Text = string.Empty;
            lblSubAddress.Text = string.Empty;
            lblSubContact.Text = string.Empty;
            lblGivenBy.Text = string.Empty;
            jobtype.Text = string.Empty;
            subjobtype.Text = string.Empty;
            subsubjobtype.Text = string.Empty;
            designtyp.Text = string.Empty;
            product.Text = string.Empty;
            lbltotalamount.Text = string.Empty;
            lblchildid.Text = string.Empty;
            lblassignto.Text = string.Empty;
            lblneedapr.Text = string.Empty;
            lbluniquekey.Text = string.Empty;
            lblqty.Text = string.Empty;
            ImgLink.Text= string.Empty;
            deslink.Text= string.Empty;
            lbslno.Text = "0";
            lblassignslno.Text = "0";
            lblchildid.Text = "0";
            lblassignto.Text = "0";
            lblneedapr.Text = "0";
            lbluniquekey.Text = "0";

            txtremark.Text = "";

            lblJobRemark.Text = string.Empty;
            lblApproveRemark.Text = string.Empty;
            lblAssignRemark.Text = string.Empty;
            lblDesignRemark.Text = string.Empty;

            lblCinNo.Text = string.Empty;

            loadchild();
            loadsizechild("0","0");
            partyremark.Style.Add("display", "none");

            ASPxPageControl1.ActiveTabIndex = 1;
            ASPxGridView1.DataBind();
        }


        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            string email = HttpUtility.HtmlEncode(txtPopupEmail.Text);
            if (email != null && email != "")
            {
                hfPopupEmail.Value = txtPopupEmail.Text;
                this.mpeImage2.Hide();
                SendEmail();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter email.','error',3);", true);
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
                GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
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
        protected void rptImages1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
            
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 4);
            }
        }
        protected void rptImages1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfImgIName.Value);
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

        #endregion Methods

        protected void disapplink_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 16);
            this.mpeImage3.Show();
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");

            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 16);
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfImgIName.Value);
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
    }
}