using DevExpress.Web;
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

namespace GoldMedal.Branding.Admin.Transaction.ApprovdisapprovdesignsubmitByManagement
{
    public partial class apdapdesignsubmitbymanag : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit ";
       
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/liveproductimage";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        private string FileNameVC = string.Empty;

        public apdapdesignsubmitbymanag()
        {
            _goldMedia = new GoldMedia();
        }

        #region PageEvent

        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                    ASPxGridView2.DataBind();
                    ASPxGridView3.DataBind();
                }
            }
            CheckRole();
        }

        #endregion PageEvent
        private void CheckRole()
        {
            int role = 0;
            role = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid");
            if (role == 46)
            {
                ASPxGridView2.Columns[26].Visible = true;
            }
            else
            {
                ASPxGridView2.Columns[26].Visible = false;
            }
        }
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

        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            lnkvisible.Text = "2";
            lbIsListShow.Text = "0";
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 5);
            this.mpeImage3.Show();
        }


        /// <summary>
        /// Show the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            checkViewFile();
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

        /// <summary>
        /// for clean the lable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            lbslno.Text = "0";
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
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



        #endregion Events

        #region Methods

        /// <summary>
        /// List Of Assigned submited by the user.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt5 = objselectall.GetAllDesignSubmitByUserforapprovelmanagement(dsp);
            return dt5;
        }

        private DataTable GetApprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllSubmitedDesignApprovedByMgm(dsp);
            return dt4;
        }

        private DataTable GetDispprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllSubmitedDesignDisapprovedByMgm(dsp);
            return dt4;
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

        protected void ASPxGridView2_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string Approval = e.GetValue("NeedApproval").ToString();
            string Printed = e.GetValue("IsPrinted").ToString();

            LinkButton lbSend = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Email Action"] as GridViewDataTextColumn, "CmdEdit") as LinkButton;


            if(lbSend != null)
            {
                if (Convert.ToBoolean(Approval))
                {
                    lbSend.Visible = true;
                }
                else
                {
                    lbSend.Visible = false;
                }


                if (Convert.ToBoolean(Printed))
                {
                    lbSend.Visible = false;
                }
                else
                {
                    lbSend.Visible = true;
                }
            }
           


            LinkButton lbPrinted = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Reopen"] as GridViewDataTextColumn, "CmdReopen") as LinkButton;
            if (lbPrinted != null)
            {
                if (Convert.ToBoolean(Printed))
                {
                    lbPrinted.Visible = false;
                }
                else
                {
                    lbPrinted.Visible = true;
                }
            }
        }

        /// <summary>
        /// fill all the control for the edit the submited design.
        /// </summary>
        protected void show2()
        {
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectsingle = new Core.DesignSubmit.DesignSubmit();
            DataTable dt = objselectsingle.GetDetailOfDesignSubmitByUser(dtsingle);
            if (dt.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
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
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);

                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);


                hfApprovalImg.Text = Convert.ToString(dt.Rows[0]["LiveProductImg"]);

                loadsizechild(Convert.ToString(dt.Rows[0]["Height"]), Convert.ToString(dt.Rows[0]["Width"]));


                //lblHeadSlno.Text = Convert.ToString(dt.Rows[0]["HeadSlno"]);
                //lblPlaceSize.Text = Convert.ToString(dt.Rows[0]["isplacesize"]) == "False" ? "No" : "Yes";
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                //lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                //if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                //{
                //    lbVisitingCardImg.Visible = true;
                //}

                //if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                //{
                //    lbReferSheetImg.Visible = true;
                //}


                txtApprovalGivenBy.Text = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usernm", Convert.ToBoolean(0)).Replace(@"+", string.Empty);

            }
            loadchild();
            ////loadsizechild();
            ASPxPageControl1.ActiveTabIndex = 0;
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
                    designsub.slno = Convert.ToInt32(lbslno.Text);
                    designsub.ispayment = rdlist.SelectedValue;
                    designsub.flg = 1;
                    designsub.slno = Convert.ToInt32(hfSlno.Value);

                    Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                    int resultemail = 0;
                    resultemail = cdsub.UpdateEmailbymanagement(designsub);
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
        /// Loads the grid of child during edit.
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

        private void loadsizechild(string height, string width)
        {
            DataTable dt6 = new DataTable();
            ////Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            ////dchildlist.slno = Convert.ToInt32(lbslno.Text);
            ////Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            ////dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);

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
            else if(flag == 4)
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
            else if (flag == 5)
            {
                a = lbslno.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;

                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();

                DataTable dtResult = objData.LiveProductFilesDACore(param);
                if (dtResult.Rows.Count > 0)
                {
                    rptImages3.DataSource = dtResult;
                    rptImages3.DataBind();
                    hdNoRecord3.Visible = false;
                }
                else
                {
                    rptImages3.DataSource = null;
                    rptImages3.DataBind();
                    hdNoRecord3.Visible = true;
                }
            }
        }

        private string[] Validation()
        {
            string[] result = new string[2];

            string strFileTypeVC = Path.GetExtension(fuPhoto.FileName).ToLower();

            if (lbslno.Text != "0")
            {
                result[0] = "false";
                result[1] = string.Empty;

                string strFileType = string.Empty;
                int count = fuPhoto.PostedFiles.Count();

                if (count > 0)
                {
                    foreach (var file in fuPhoto.PostedFiles)
                    {
                        if (file.FileName != string.Empty)
                        {
                            strFileType = Path.GetExtension(file.FileName).ToLower();

                            string singleFile = string.Empty;
                            decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);

                            if (size <= 20480)
                            {
                                if (strFileType == ".jpg" || strFileType == ".jpeg" || strFileType == ".png" || strFileType == ".pdf")
                                {
                                    result[0] = "false";
                                    result[1] = string.Empty;
                                }
                                else
                                {
                                    result[0] = "true";
                                    result[1] = "Please upload only .jpg, .jpeg, .png or .pdf file.";
                                }
                            }
                            else
                            {
                                lblModalTitle.Text = "Warning";
                                lblModalBody.Text = "Sorry, Image size can not be greater then 20MB.";
                                lblModalBody.Attributes.Add("style", "font-size:15px; color:Red; font-weight:lighter;");
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                                upModal.Update();
                            }
                        }
                        else
                        {
                            //result[0] = "true";
                            //result[1] = "Please upload file.";
                            result[0] = "false";
                            result[1] = string.Empty;
                        }
                    }
                }
                else
                {
                    //result[0] = "true";
                    //result[1] = "Please upload file.";

                    result[0] = "false";
                    result[1] = string.Empty;
                }
            }
            else
            {
                result[0] = "true";
                result[1] = "Please select job first.";
            }

            return result;
        }

        /// <summary>
        /// for approve the design submit
        /// </summary>
        private void Approve()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for approvel','error',3);", true);
            }
            //else if (string.IsNullOrEmpty(txtApprovalGivenBy.Text) || string.IsNullOrEmpty(txtMgmRemark.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter both approval given by and remark.','error',3);", true);
            //}
            else if (string.IsNullOrEmpty(txtApprovalGivenBy.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter  approval given by.','error',3);", true);
            }
            else if (Validation()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
            }
            else
            {

                string strFileType = "";
                foreach (var file in fuPhoto.PostedFiles)
                {
                    if (file.FileName != "")
                    {
                        bool rtnVallpost = false;
                        string uploadedFileName = "";

                        SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME3);
                        if (rtnVallpost)
                        {
                            strFileType = Path.GetExtension(file.FileName).ToLower();
                            if (FileNameVC == "")
                            {
                                FileNameVC = uploadedFileName;
                            }
                            else
                            {
                                FileNameVC = FileNameVC + ',' + uploadedFileName;
                            }
                        }
                    }
                }
                if (lbslno.Text == "0")
                {
                    FileNameVC = FileNameVC.TrimEnd(',');
                }
                else
                {
                    if (hfApprovalImg.Text != "")
                    {
                        FileNameVC = FileNameVC.TrimEnd(',') + ',' + hfApprovalImg.Text;

                        if (FileNameVC.Contains(",,"))
                        {
                            FileNameVC.Replace(",,", "");
                        }
                    }
                }


                string emailerror = string.Empty;
                string error = string.Empty;

                if (lblneedapr.Text == "True" && product.Text.ToLower() == "live product")
                {
                    string url = "https://branding.goldmedalindia.in/Transaction/ApproveByParty/ApproveDesign.aspx?uniquekey=" + lbluniquekey.Text;
                    string subject2 = "<table style='width: 100 %; '><tr><td>&nbsp;</td><td>Dear Sir,</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>Please find your design and approve as soon as possible.</a></td><td>&nbsp;</td></tr><tr><td>&nbsp;&nbsp;<a href=" + url + ">Click Here</a></td><td>&nbsp;</td><td>&nbsp;</td></tr></table>";
                    Core.DesignSubmit.DesignSubmit ds = new Core.DesignSubmit.DesignSubmit();
                     emailerror = ds.sendmail(lblsndemail.Text, subject2, "Approve Design", string.Empty, string.Empty);
                    //emailerror = "0";
                    if (emailerror == "0")
                    {
                        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();

                        var submitimg = FileNameVC;
                        designsub.LiveProductImg = submitimg;
                        designsub.sendemial = lblsndemail.Text;
                        designsub.slno = Convert.ToInt32(lbslno.Text);
                        designsub.ispayment = rdlist.SelectedValue;
                        designsub.flg = 1;

                        designsub.ApprovalGivenBy = txtApprovalGivenBy.Text.Trim();
                        designsub.MgmRemark = txtMgmRemark.Text.Trim();

                        Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                        int resultemail = 0;
                        resultemail = cdsub.UpdateEmailbymanagement(designsub);
                        if (resultemail == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mail send and updated  successfully !','success',3);", true);
                        }
                        if (resultemail != 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mail  sent but not updated  !','success',3);", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Some Error !','error',3);", true);
                    }
                    clean();
                }
                else
                {
                    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                    designsub.sendemial = lblsndemail.Text;
                    designsub.slno = Convert.ToInt32(lbslno.Text);
                    designsub.ispayment = rdlist.SelectedValue;
                    designsub.flg = 0;

                    var submitimg = FileNameVC;
                    designsub.LiveProductImg = submitimg;

                    designsub.ApprovalGivenBy = txtApprovalGivenBy.Text.Trim();
                    designsub.MgmRemark = txtMgmRemark.Text.Trim();

                    Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                    int resultemail = 0;
                    resultemail = cdsub.UpdateEmailbymanagement(designsub);
                    if (resultemail == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mail was not requried but details updated  successfully !','success',3);", true);
                    }
                    if (resultemail != 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Mail was not requried but Some error in updation!','error',3);", true);
                    }
                }
            }
            clean();
        }

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
            ImgLink.Text = string.Empty;
            deslink.Text = string.Empty;
            lblJobRemark.Text = string.Empty;
            hfApprovalImg.Text = string.Empty;
            hfApprovalImgDelete.Text = string.Empty;
            lblCinNo.Text = string.Empty;
            txtApprovalGivenBy.Text = string.Empty;
            txtMgmRemark.Text = string.Empty;

            lbslno.Text = "0";
            lblchildid.Text = "0";
            lblassignto.Text = "0";
            lblneedapr.Text = "0";
            lbluniquekey.Text = "0";
            loadchild();
            loadsizechild("0", "0");
            ASPxGridView1.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        #endregion Methods

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


        protected void rptImages3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");

            if (e.CommandName == "cmdRemove")
            {
                hfApprovalImg.Text = hfApprovalImg.Text.Trim().Replace(hfImgIName.Value, "");
                hfApprovalImgDelete.Text = hfApprovalImgDelete.Text + ',' + hfImgIName.Value;
                e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                this.mpeImage3.Show();
            }
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 5);
            }
        }
        protected void rptImages3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME3, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME3, hfImgIName.Value);
            hfvisible.Value = "false";

            if (lnkvisible.Text == "2")
            {
                hfvisible.Value = "true";
            }
            if (hfvisible.Value == "true")
            {
                lnkDelete.Visible = true;
            }
            else
            {
                lnkDelete.Visible = false;
            }

            if (lbIsListShow.Text == "1")
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

        private string Delete(string file)
        {
            string result = string.Empty;
            string folderpath = string.Empty;
            string path = string.Empty;
            string[] Files = file.Split(',');
            folderpath = FILE_DIRECTORY_NAME;
            for (int i = 0; i < Files.Length; i++)
            {
                path = folderpath + '/' + Files[i];

                var oldFileName = path.Split('/').Last();
                var retStr = _goldMedia.GoldMediaDelete(path);
                result = string.Format("{0} : {1}", oldFileName, retStr.Values.FirstOrDefault());
            }
            return result;
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

        protected void checkViewFile()
        {
            lnkFiles4.Text = "";
            string hfimf1 = hfApprovalImg.Text.Replace(",", "");
            if (!string.IsNullOrEmpty(hfimf1))
            {
                lnkFiles4.Text = "View Files";
            }
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
            MimeType.Xlsx,
            MimeType.Xls,
            MimeType.Doc,
            MimeType.Docx,
            MimeType.Txt,
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
            if (!GoldMimeType.IsFileSizeAllowed(file.ContentLength, out size, 1024 * 1024 * 20))
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

        protected void btnDisapprove_Click(object sender, EventArgs e)
        {
            DisApprove();
        }
        /// <summary>
        /// For disapprove the design submit live product
        /// </summary>
        private void DisApprove()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for approvel','error',3);", true);
            }
            else if (string.IsNullOrEmpty(txtApprovalGivenBy.Text) || string.IsNullOrEmpty(txtMgmRemark.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter both approval given by and remark.','error',3);", true);
            }
            
            else
            {

                string emailerror = string.Empty;
                string error = string.Empty;

                if (product.Text.ToLower() == "live product")
                {
                    
                        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();

                       
                        designsub.slno = Convert.ToInt32(lbslno.Text);
                        
                        designsub.ApprovalGivenBy = txtApprovalGivenBy.Text.Trim();
                        designsub.MgmRemark = txtMgmRemark.Text.Trim();

                        Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                        int resultemail = 0;
                        resultemail = cdsub.UpdateDisapprovalbymanagement(designsub);
                    if (resultemail == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                    }
                    else
                    {
                        
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','DisApproved successfully !','success',3);", true);
                    }

                    clean();
                }
                
            }
            clean();
        }

        protected void CmdReopen_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            Reopen();
            
        }
        private void Reopen()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for reopen','error',3);", true);
            }
          
            else
            {

                    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                    
                    designsub.slno = Convert.ToInt32(lbslno.Text);
                   
                    designsub.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    

                    Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
                    int result = 0;
                    result = cdsub.LiveProductjobsReopenbymanagement(designsub);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Reopened Successfully !','success',3);", true);
                    }
                    if (result != 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                    }
               
            }
            ASPxGridView2.DataBind();

        }

        protected void ASPxGridView3_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView3.DataSource = GetDispprovedJobs();
        }

        protected void ASPxGridView3_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }
    }
}