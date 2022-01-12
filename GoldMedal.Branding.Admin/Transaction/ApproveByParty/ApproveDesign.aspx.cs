using GoldMedal.Branding.Data.JobRequest;
using Ionic.Zip;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.ApproveByParty
{
    public partial class ApproveDesign : System.Web.UI.Page
    {
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/detailsbyparty";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        public string party = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddetails();
            }
        }
        public ApproveDesign()
        {
            _goldMedia = new GoldMedia();
            finYear = "19-20";
        }

        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
            if (dt6.Rows.Count == 0)
            {
                gvSchemeChild.Visible = false;
                lbltotamt.Visible = false;
                lbtamt.Visible = false;
                lbltotamt.Visible = false;
                lblable.Visible = false;
            }
        }

        private void loaddetails()
        {
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dtsingle.uniquekey = Request.QueryString["uniquekey"];
            Core.DesignSubmit.DesignSubmit objselectsingle = new Core.DesignSubmit.DesignSubmit();
            DataTable dt = objselectsingle.JobDetailsForParty(dtsingle);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(dt.Rows[0]["isapproveparty"]) != string.Empty)
                {
                    det.Visible = false;

                    if(dt.Rows[0]["isapproveparty"].ToString() == "1")
                    {
                        Label1.Text = "You have allready approved this job.";
                    }
                    else
                    {
                        Label1.Text = "You have allready disapproved this job.";
                    }
                }
                else
                {
                    det.Visible = true;
                    LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                    lblDate.Text = Convert.ToString(dt.Rows[0]["jobrequestdate"]);
                    lblheight.Text = Convert.ToString(dt.Rows[0]["height"]);
                    lblwidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                    jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                    subjobtype.Text = Convert.ToString(dt.Rows[0]["subjob"]);
                    subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjob"]);
                    designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                    producttype.Text = Convert.ToString(dt.Rows[0]["product"]);
                    lbslno.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
                    lbltotamt.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                    hfVisitingImage.Text = Convert.ToString(dt.Rows[0]["sumbmitimg"]);
                    lblchildid.Text = Convert.ToString(dt.Rows[0]["childid"]);
                    ispayment.Text = Convert.ToString(dt.Rows[0]["ispayment"]);

                    lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                    lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                    lblPrintLoc.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                    lblFabLoc.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                    lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);

                    lblAllName.Text = Convert.ToString(dt.Rows[0]["AllName"]);
                    lblAllContactPerson.Text = Convert.ToString(dt.Rows[0]["contactperson"]);
                    lblRetailerName.Text = Convert.ToString(dt.Rows[0]["subname"]);
                    lblRetailerContactPerson.Text = Convert.ToString(dt.Rows[0]["subpname"]);

                    //lblDesignLink.Text = Convert.ToString(dt.Rows[0]["designlink"]);

                    loadchild();
                }
            }
            else
            {
                det.Visible = false;
                Label1.Text = "SomeThing Wrong";
            }
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

        protected void btnApprove_Click1(object sender, EventArgs e)
        {
            string FileNameVC = string.Empty;
            string strFileTypeVC = string.Empty;
            string FolderName = string.Empty;

            string strFileType = "";
            foreach (var file in fuupload.PostedFiles)
            {
                if (file.FileName != "")
                {
                    bool rtnVallpost = false;
                    string uploadedFileName = "";

                    SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME2);
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

            // if (FileNameVC == string.Empty && txtlink.Text == string.Empty)
            //     ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Error. Please Upload Some Files or Enter Image Link..');", true);
            // else
            //  {
            string link = txtlink.Text;

            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            designsub.slno = Convert.ToInt32(lbslno.Text);
            designsub.uplodepartyimg = FileNameVC;
            designsub.link = link;
            designsub.remark = txtRemarks.Text;
            designsub.Action = 1;

            Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
            int resultemail = 0;
            resultemail = cdsub.ApproveByParty(designsub);
            if (resultemail == 1)
            {
                loaddetails();
                Label1.Text = "Approved successfully.";
            }
            if (resultemail != 1)
            {
                Label1.Text = "Some Error Please Try Again After Some Time";
            }
            // }
        }

        protected void btnDisapprove_Click1(object sender, EventArgs e)
        {
            string FileNameVC = string.Empty;
            string strFileTypeVC = string.Empty;
            string FolderName = string.Empty;

            string strFileType = "";
            foreach (var file in fuupload.PostedFiles)
            {
                if (file.FileName != "")
                {
                    bool rtnVallpost = false;
                    string uploadedFileName = "";

                    SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME2);
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


            string link = txtlink.Text;

            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty designsub = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            designsub.slno = Convert.ToInt32(lbslno.Text);
            designsub.uplodepartyimg = FileNameVC;
            designsub.link = link;
            designsub.remark = txtRemarks.Text;
            designsub.Action = 2;

            Core.DesignSubmit.DesignSubmit cdsub = new Core.DesignSubmit.DesignSubmit();
            int resultemail = 0;
            resultemail = cdsub.ApproveByParty(designsub);
            if (resultemail == 1)
            {
                loaddetails();
                Label1.Text = "Disapproved successfully.";
            }
            if (resultemail != 1)
            {
                Label1.Text = "Some Error Please Try Again After Some Time";
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
    }
}