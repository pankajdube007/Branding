using DevExpress.Web;
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

namespace GoldMedal.Branding.Admin.Master.PrinterQuotation
{
    public partial class PrinterQuotation : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();

        private string strFileTypeVC = string.Empty;
      
        private string FileNameVC = string.Empty;
        public string party = string.Empty;
        private string FileName = string.Empty; 
        private IExport xpt = null;
        private const string FILE_DIRECTORY_NAME = "printer/quotation";

        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

        #endregion Initialization

        #region PageEvent
        public PrinterQuotation()
        {
            _goldMedia = new GoldMedia();
            finYear = "17-18";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    lbslno.Text = "0";
                ASPxPageControl1.ActiveTabIndex = 0;
                PrinterList();
                LoadBranch();
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
        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {

            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show();
            ASPxPageControl1.ActiveTabIndex = 0;
            checkViewFile();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            lnkvisible.Text = "2";
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 8);
            this.mpeImage.Show();
        }

        protected void CmdlnkImage4_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
            }
            GetUploadedJobRequestFiles(FieldTripID, 8);
            this.mpeImage.Show();
        }

        protected void RptDocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");

            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg") || hfImgIName.Value.Contains(".xls") || hfImgIName.Value.Contains(".xlsx") || hfImgIName.Value.Contains(".docx") || hfImgIName.Value.Contains(".txt"))
            {
                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/Printer/Quotation"), hfImgIName.Value)))
                {
                    imgDocs.ImageUrl = "~/Upload/Printer/Quotation/" + hfImgIName.Value.Replace(".jpeg", ".jpg");
                    hyLink.NavigateUrl = "~/Upload/Printer/Quotation/" + hfImgIName.Value.Replace(".jpeg", ".jpg");
                }
                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/Printer/Quotation"), hfImgIName.Value)) && (hfImgIName.Value.Contains(".xls") || hfImgIName.Value.Contains(".xlsx")))
                {
                    imgDocs.ImageUrl = "~/images/ExcelIcon.jpg";
                    imgDocs.ToolTip = "Download";
                    hyLink.NavigateUrl = "~/Upload/Printer/Quotation/" + hfImgIName.Value;
                }
                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/Printer/Quotation"), hfImgIName.Value)) && (hfImgIName.Value.Contains(".txt")))
                {
                    imgDocs.ImageUrl = "~/images/txticone.jpg";
                    imgDocs.ToolTip = "Download";
                    hyLink.NavigateUrl = "~/Upload/Printer/Quotation/" + hfImgIName.Value;
                }

                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/Printer/Quotation"), hfImgIName.Value)) && (hfImgIName.Value.Contains(".docx")))
                {
                    imgDocs.ImageUrl = "~/images/docxicon.jpg";
                    imgDocs.ToolTip = "Download";
                    hyLink.NavigateUrl = "~/Upload/Printer/Quotation/" + hfImgIName.Value;
                }
            }
        }

        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        #endregion Event

        #region Method

        protected void columnhide()
        {
            ASPxGridView1.Columns[3].Visible = false;
            ASPxGridView1.Columns[4].Visible = false;
        }

        protected void columnshow()
        {
            ASPxGridView1.Columns[3].Visible = true;
            ASPxGridView1.Columns[4].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("Master_PrinterQuotation_{0}", DateTime.Now.ToString());
        }

        private DataTable GetTable()
        {
            DataTable dt4 = new DataTable();
            Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dtsingle = new Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert();
            Core.PrinterQuotation.PrinterQuotation objselectsingle = new Core.PrinterQuotation.PrinterQuotation();
            dt4 = objselectsingle.GetPrinterQuotationAll();
            return dt4;
        }

        protected void show()
        {
            Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dtsingle = new Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.PrinterQuotation.PrinterQuotation objselectsingle = new Core.PrinterQuotation.PrinterQuotation();
            DataTable dt = objselectsingle.GetPrinterQuotationSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                cmbPrinter.Text = Convert.ToString(dt.Rows[0]["printername"]);
               // cmbBranch.Text = Convert.ToString(dt.Rows[0]["locnm"]);

                foreach (var item in Convert.ToString(Convert.ToString(dt.Rows[0]["branchcd"])).Split(','))
                {
                    if (item != "")
                    {
                        lbBranch.Items.FindByValue(item).Selected = true;
                    }
                }


                if (Convert.ToDateTime(dt.Rows[0]["effdate"]).ToString("dd/MM/yyyy") != "01-01-0000")
                {
                    txtdate.Text = Convert.ToDateTime(dt.Rows[0]["effdate"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    txtdate.Text = string.Empty;
                }
                // txtdate.Text = Convert.ToString(dt.Rows[0]["effdate"]);
               
                hfReferSheet.Text= Convert.ToString(dt.Rows[0]["quotation"]);
            }

            ASPxPageControl1.ActiveTabIndex = 0;
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
        protected void LoadBranch()
        {
            if (lbBranch.SelectedIndex != 0)
            {
                Core.Fabricator.IFabricator objselectsingle = new Core.Fabricator.Fabricator();
                DataTable dt = objselectsingle.GetBranchAll();
                //cmbBranch.Items.Clear();
                //cmbBranch.Value = null;
                //cmbBranch.Items.Clear();
                //cmbBranch.Value = null;
                //cmbBranch.DataSource = dt;
                //cmbBranch.TextField = "locnm";
                //cmbBranch.ValueField = "slno";
                ////cmbArea.SelectedIndex = 0;
                //cmbBranch.DataBind();

                //cmbBranch.Items.Insert(0, new ListEditItem("Select"));
                //cmbBranch.SelectedIndex = 0;

                lbBranch.Items.Clear();
                lbBranch.Value = null;
                lbBranch.DataSource = dt;
                lbBranch.TextField = "locnm";
                lbBranch.ValueField = "slno";
                lbBranch.DataBind();
            }
        }
        protected void PrinterList()
        {
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            DataTable dt = objselectsingle.GetPrinterAll();
            cmbPrinter.DataSource = dt;
            cmbPrinter.TextField = "name";
            cmbPrinter.ValueField = "slno";
            cmbPrinter.SelectedIndex = -1;
            cmbPrinter.DataBind();
        }

    

        private void Submit()
        {
            //int result = 0;

            //if (Validation()[0] == "true")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
            //}
            //else
            //{
            //    FolderName = "Quotation";
            //    foreach (var file in funewimg.PostedFiles)
            //    {
            //        strFileTypeVC = Path.GetExtension(file.FileName).ToLower();
            //        string theFileName = string.Empty;
            //        string singleFile = string.Empty;
            //        singleFile = Guid.NewGuid().ToString() + strFileTypeVC;
            //        theFileName = Path.Combine(Server.MapPath("~/Upload/Printer/"), FolderName, party, singleFile);
            //        file.SaveAs(theFileName);
            //        FileNameVC += string.Format(@"{0},", singleFile);
            //    }
            //    if (strFileTypeVC != string.Empty)
            //    {
            //        FileNameVC = FileNameVC.TrimEnd(',');
            //    }
            //    else
            //    {
            //        FileNameVC = string.Empty;
            //    }
            //    if (lbslno.Text != string.Empty && FileNameVC == string.Empty)
            //    {
            //        FileNameVC = hf.Value;
            //    }
            //    Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dst = new Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert();
            //    int slno = Convert.ToInt32(lbslno.Text);
            //    int Printer = Convert.ToInt32(cmbPrinter.Value);
            //    string Edt = string.Empty;
            //    ; string[] st1 = txtdate.Text.Split('/');
            //    if (st1.Length > 2)
            //    {
            //        Edt = st1[1] + "/" + st1[0] + "/" + st1[2];
            //    }
            //    DateTime EffDate = Convert.ToDateTime(Edt);

            //    var submitimg = FileNameVC;
            //    dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
            //    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            //    dst.slno = slno;
            //    dst.Quotation = submitimg;
            //    dst.EffDate = EffDate;
            //    dst.PrinterId = Printer;
            //    Core.PrinterQuotation.PrinterQuotation objinsert = new Core.PrinterQuotation.PrinterQuotation();
            //    result = objinsert.PrinterQuotationInsertMethod(dst);
            //    if (result == 2)
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Added successfully !','success',3);", true);
            //        clean();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
            //        clean();
            //    }
            //}


            #region FileUpload
            string FileName = "";
            string strFileType = "";
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
                FileName = FileName.TrimEnd(',') + ',' + hfReferSheet.Text;
            }
            #endregion
            var Printer = HttpUtility.HtmlEncode(cmbPrinter.Value);
           // var BranchId = HttpUtility.HtmlEncode(cmbBranch.SelectedIndex);

            var branch = "";



            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branch += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branch = branch.TrimEnd(',');



            string error = string.Empty;
            if (cmbPrinter.SelectedIndex == -1)
            {
                error += "Printer Should not be empty.!</br>";
            }
            if (txtdate.Text == "")
            {
                error += "Eff date Should not be empty.!</br>";
            }

           //if (cmbBranch.SelectedIndex == 0)
                if (branch == "")
                {
                error += "Branch Should not be empty.!</br>";
            }

            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
               // if ((txtdate.Text != "") && (Printer != "") && (Printer != "0") && (BranchId != "0") || (Printer == null))
                    if ((txtdate.Text != "") && (Printer != "") && (Printer != "0") && (branch != "") || (Printer == null))
                    {
                if (FileName.Trim(',') == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please Upload File','warning',3);", true);
                }
                else
                {
                    int result = 0;
                    Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dst = new Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert();
                    int slno = Convert.ToInt32(lbslno.Text);
                    int Printers = Convert.ToInt32(cmbPrinter.Value);
                        //  int Branch = Convert.ToInt32(cmbBranch.Value);
                    string Branch = branch;
                    string Edt = string.Empty;
                    //string[] st1 = txtdate.Text.Split('-');
                    string[] st1 = txtdate.Text.Split('/'); //code by gaurav
                    if (st1.Length > 2)
                    {
                        Edt = st1[1] + "/" + st1[0] + "/" + st1[2];
                    }
                    DateTime EffDate = Convert.ToDateTime(Edt);

                    var submitimg = FileName;
                    dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.slno = slno;
                    dst.branch = Branch;
                    dst.Quotation = submitimg;
                    dst.EffDate = EffDate;
                    dst.PrinterId = Printers;
                    Core.PrinterQuotation.PrinterQuotation objinsert = new Core.PrinterQuotation.PrinterQuotation();
                    result = objinsert.PrinterQuotationInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Added successfully !','success',3);", true);
                        if (lbslno.Text != "0")
                        {
                            Delete(hfReferSheet.Text);
                        }
                        clean();
                        ASPxPageControl1.ActiveTabIndex = 0;
                    }
                        else if (result == 3)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Updated successfully !','success',3);", true);
                            if (lbslno.Text != "0")
                            {
                                Delete(hfReferSheetDelete.Text);
                            }
                            clean();
                            ASPxPageControl1.ActiveTabIndex = 0;
                        }
                        else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                        ASPxPageControl1.ActiveTabIndex = 0;
                    }
                }

            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Printer Or Date Or Branch Empty','warning',3);", true);
            }
            
        }
    }

        protected void clean()
        {
            lbslno.Text = "0";
            txtdate.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            hfReferSheet.Text = "";
            hfReferSheetDelete.Text = "";
            hfReferSheetDelete.Text = string.Empty;
            cmbPrinter.SelectedIndex = -1;
            ASPxPageControl1.ActiveTabIndex = 0;
            //cmbBranch.SelectedIndex = 0;
            lbBranch.Items.Clear();
            LoadBranch();
        }

        #endregion Method

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
        protected void LinkButViewFile_Command(object sender, CommandEventArgs e)
        {
            lnkvisible.Text = "1";
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 8);
            this.mpeImage.Show();

        }
        protected void checkViewFile()
        {
            lnkFiles3.Text = "";
            string hfimf1 = hfReferSheet.Text.Replace(",", "");
            if (!string.IsNullOrEmpty(hfimf1))
            {
                lnkFiles3.Text = "View Files";
            }
        }
    }
}