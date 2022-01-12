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

namespace GoldMedal.Branding.Admin.Transaction.PrinterDesignSubmit
{
    public partial class printerdesignsubmit : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private DataTable dts = new DataTable();
        private DataTable dtss = new DataTable();
        private string strFileTypeVC = string.Empty;
        private string FolderName = "SubmitImage";
        private string FileNameVC = string.Empty;
        public string party = string.Empty;
        private double Cnt;
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/approveprintjob";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/submitimagebyprinter";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

        #endregion Initialization

        #region PageEvent
        public printerdesignsubmit()
        {
            _goldMedia = new GoldMedia();
            finYear = "17-18";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "1")
                {
                    lbslno.Text = "0";
                ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }

        #endregion PageEvent

        #region Events

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            //clean();
            if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                ASPxGridView2.DataBind();
            }
        }

        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
            this.mpeAll.Show();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbldesignsubmitid.Text), 4);
            this.mpeAll.Show();
        }

        protected void lnkPrintFile_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbldesignsubmitid.Text), 12);
            this.mpeAll.Show();
        }

        /// <summary>
        /// shoe the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show2();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }

        /// <summary>
        /// for clean the lable.
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
        /// call the approve method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            Submit();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// List Of Jobs Assigned To The Printer.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            //dsp.printer = 4;
            dsp.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectall = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            dt4 = objselectall.GetAllJobForPrinter(dsp);
            return dt4;
        }

        private DataTable GetTable3()
        {
            DataTable dt4 = new DataTable();
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            //dsp.printer = 4;
            dsp.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectall = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            dt4 = objselectall.GetAllSubmittedJobForPrinter(dsp);
            return dt4;
        }

        /// <summary>
        /// Fill all the control for submit the detail by the printer.
        /// </summary>
        protected void show2()
        {
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectsingle = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            DataTable dt = objselectsingle.GetDesignSubmitJobForPrinterSingle(dtsingle);
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
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lbldesignsubmitid.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
               
                ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);
                deslink.Text = Convert.ToString(dt.Rows[0]["designlink"]);
                deslink.NavigateUrl = Convert.ToString(dt.Rows[0]["designlink"]);

                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);


                hlPrintLink.Text = Convert.ToString(dt.Rows[0]["PrintLink"]);
                hlPrintLink.NavigateUrl = Convert.ToString(dt.Rows[0]["PrintLink"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);

                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);


                lblCost.Text = Convert.ToString(dt.Rows[0]["PrintCost"]);


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

                lblapprvprintremark.Text = Convert.ToString(dt.Rows[0]["ApproveSendForPrintRemark"]);
                lblprintremark.Text = Convert.ToString(dt.Rows[0]["SendForPrintRemark"]);
            }
            loadchild();
            loadsizechild();
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        /// <summary>
        /// Load the grid of  Item child for the perticular child.
        /// </summary>
        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbldesignsubmitid.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }

        /// <summary>
        /// Load the grid of  Size child for the perticular child.
        /// </summary>
        private void loadsizechild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbldesignsubmitid.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);
            gvSizeChild.DataSource = dt6;
            gvSizeChild.DataBind();
        }

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

        /// <summary>
        /// Validation before the submit
        /// </summary>
        ///
        private string[] Validation()
        {
            string[] result = new string[2];
            strFileTypeVC = Path.GetExtension(fuPhoto.FileName).ToLower();
            result[0] = "false";
            result[1] = string.Empty;
            if ((strFileTypeVC == ".jpg" || strFileTypeVC == ".jpeg" || strFileTypeVC == ".png"))
            {
                result[0] = "false";
                result[1] = string.Empty;
            }
            else if (txtLink.Text != string.Empty)
            {
                Uri uriResult;
                bool resultlink = Uri.TryCreate(txtLink.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (resultlink == true)
                {
                    result[0] = "false";
                    result[1] = string.Empty;
                }
                else
                {
                    result[0] = "true";

                    result[1] = "Link is not in valid format";
                }

            }
            else
            {
                result[0] = "true";
                result[1] = "File and Image Link both fields are empty or image format is wrong";
            }
            return result;
        }

        /// <summary>
        /// Submit the design by the printer for the perticular job
        /// </summary>
        private void Submit()
        {
            int result = 0;
            //if (Validation()[0] == "true")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
            //}
            //else
            //{
                if (lbslno.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one record..','error',3);", true);
                }
                else
                {
                    
                    //string strFileType = "";
                    //foreach (var file in fuPhoto.PostedFiles)
                    //{
                    //    if (file.FileName != "")
                    //    {
                    //        bool rtnVallpost = false;
                    //        string uploadedFileName = "";

                    //        SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME3);
                    //        if (rtnVallpost)
                    //        {

                    //            strFileType = Path.GetExtension(file.FileName).ToLower();
                    //            if (FileNameVC == "")
                    //            {
                    //                FileNameVC = uploadedFileName;
                    //            }
                    //            else
                    //            {
                    //                FileNameVC = FileNameVC + ',' + uploadedFileName;
                    //            }
                    //        }
                    //    }
                    //}
                   
                  
                    FileNameVC = FileNameVC.TrimEnd(',');
                   
                    
                    Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dst = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
                    int slno = Convert.ToInt32(lbslno.Text);
                    var submitimg = FileNameVC;
                    string link = txtLink.Text;
                    dst.slno = slno;
                    dst.sumbmitimg = submitimg;
                    dst.link = "N/A"; // link; code by gaurav from 3-12-19 no link or image is provided by printer
                    Core.PrinterDesignSubmit.PrinterDesignSubmit objinsert = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
                    result = objinsert.DesignSubmitByPrinterInsertMethod(dst);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Received successfully.','success',1);", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Some error occured.','error',2);", true);
                    }

                    clean();
                }
           // }
        }

        /// <summary>
        /// Clean the controls.
        /// </summary>
        protected void clean()
        {
            lblCinNo.Text = string.Empty;
            LblRequestNo.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblNameType.Text = string.Empty;
            lblName.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblContact.Text = string.Empty;
            lblContactPerson.Text = string.Empty;
            lblEmail.Text = string.Empty;
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

            lblapprvprintremark.Text = string.Empty;
            lblprintremark.Text = string.Empty;


            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";

            lblqty.Text = string.Empty;
            ImgLink.Text = string.Empty;
            ImgLink.NavigateUrl = string.Empty;
            deslink.Text = string.Empty;
            deslink.NavigateUrl = string.Empty;
            lblJobRemark.Text = string.Empty;

            hlPrintLink.Text = string.Empty;
            hlPrintLink.NavigateUrl = string.Empty;

            lbslno.Text = "0";
            lblchildid.Text = "0";
            lbldesignsubmitid.Text = "0";
            loadchild();
            loadsizechild();
            ASPxGridView1.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
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
            if (!GoldMimeType.IsFileSizeAllowed(file.ContentLength, out size, 1024 * 1024 * 25))
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

        #endregion Methods


        protected void rptAllImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hfPImgName = (HiddenField)e.Item.FindControl("hfPImgName");

            var path = "";

            if (e.CommandName == "Down")
            {
                if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lblchildid.Text), 3);
                }
                else if (hfPopupImageFlag.Value == "4")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lbldesignsubmitid.Text), 4);
                }
                else if (hfPopupImageFlag.Value == "12")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lbldesignsubmitid.Text), 12);
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

            if (hfPopupImageFlag.Value == "3")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "4")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "12")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
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