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

namespace GoldMedal.Branding.Admin.Transaction.ApproveByParty
{
    public partial class PartyApprovalStatusUpdate : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/detailsbyparty";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

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
                }
            }
        }
        #endregion PageEvent
        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                ASPxGridView3.DataBind();
            }
            
        }
        protected void CmdEdit3_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            btnDisapprove.Visible = true;
            btnReopen.Visible = true;
            btnCancel.Visible = true;
            show2();
        }
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
            DisApproveandcancel();
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
       


        private DataTable GetDisApprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllDesignDisapprovedByParty(dsp);
            return dt4;
        }

        private DataTable GetApprovedJobs()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();

            dt4 = objselectall.GetAllDesignApprovedByParty(dsp);
            return dt4;
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


               // loadsizechild(Convert.ToString(dt.Rows[0]["Height"]), Convert.ToString(dt.Rows[0]["Width"]));


                //lblHeadSlno.Text = Convert.ToString(dt.Rows[0]["HeadSlno"]);
                //lblPlaceSize.Text = Convert.ToString(dt.Rows[0]["isplacesize"]) == "False" ? "No" : "Yes";
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["AprrovalRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);
                lblDesignRemark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);




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
            else if (flag == 16)
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
            else if (flag == 14)
            {
                a = lbslno.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;
                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
                DataTable dtResult = objData.JobRequestChildFilesDACore(param);
                if (dtResult.Rows.Count > 0)
                {
                    Repeater3.DataSource = dtResult;
                    Repeater3.DataBind();
                    hdNoRecord3.Visible = false;

                }
                else
                {
                    Repeater3.DataSource = null;
                    Repeater3.DataBind();
                    hdNoRecord3.Visible = true;
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

                //if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                //{
                //    ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                //}

               
                ApproveDst.slno = Convert.ToInt32(lbslno.Text);
               
                ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                result = objinsertAssignJob.PartyApproveApproveJobInsertMethod(ApproveDst);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {
                   
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);
                   
                    clean();
                }
            }
            clean();
        }

        private void Reopen()
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

                //if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                //{
                //    ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                //}


                ApproveDst.slno = Convert.ToInt32(lbslno.Text);

                ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                result = objinsertAssignJob.PartyApproveApproveJobInsertMethod(ApproveDst);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);

                    clean();
                }
            }
            clean();
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
            ImgLink.Text = string.Empty;
            deslink.Text = string.Empty;
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
          //  loadsizechild("0", "0");
            partyremark.Style.Add("display", "none");

            ASPxPageControl1.ActiveTabIndex = 1;
            ASPxGridView1.DataBind();

            btnApprove.Visible = false;
            btnDisapprove.Visible = false;
            btnReopen.Visible = false;
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

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetApprovedJobs();
        }

        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            btnApprove.Visible = true;
            btnCancel.Visible = true;
            show2();
        }

        protected void btnReopen_Click(object sender, EventArgs e)
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

              
                ApproveDst.slno = Convert.ToInt32(lbslno.Text);
                ApproveDst.tableNm = TableNme;
               
                ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                result = objinsertAssignJob.ReopenJobInsertMethod(ApproveDst);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {
                   
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Reopened successfully !','success',3);", true);
                }
            }
            clean();
        }
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

        protected void partyappimg_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 14);
            this.mpeImage4.Show();
        }

        protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");

            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 14);
            }
        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME2, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME2, hfImgIName.Value);
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