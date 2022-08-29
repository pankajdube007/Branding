using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.BillUpload;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.BillFillUpload
{
    public partial class BillUploadApproval : System.Web.UI.Page
    {
        #region Initialization
        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private const string FILE_DIRECTORY_NAME = "billupload";
        private readonly IGoldMedia _goldMedia;
        #endregion Initialization

        #region PageEvent
        public BillUploadApproval()
        {
            _goldMedia = new GoldMedia();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    LoadBranch();
                    ASPxGridView1.DataBind();
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
        protected void CmdApprove_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show();
            ASPxPageControl1.ActiveTabIndex = 0;
            checkViewFile();
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable();
        }

        protected string GetFileName()
        {
            return string.Format("Transaction_BillUpload_{0}", DateTime.Now.ToString());
        }
        protected void CmdApprove_Click(object sender, EventArgs e)
        {
            Approve();
        }
        protected void CmdDisApprove_Click(object sender, EventArgs e)
        {
            DisApprove();
        }

        private void Approve()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one for approval..','error',3);", true);
            }
            else
            {
                int result = 0;
                BillUploadModel.BillUploadInsert dst = new BillUploadModel.BillUploadInsert();
                int slno = Convert.ToInt32(lbslno.Text);
                dst.slno = slno;
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.BranchID = Convert.ToInt32(lblBranchID.Text);
                Core.BillUpload.BillUpload objinsert = new Core.BillUpload.BillUpload();
                result = objinsert.BillUploadApproveMethod(dst);
                if (result == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);
                    clean();
                }
            }

        }

        private void DisApprove()
        {
            int result = 0;
            BillUploadModel.BillUploadInsert dst = new BillUploadModel.BillUploadInsert();
            int slno = Convert.ToInt32(lbslno.Text);
            dst.slno = slno;
            dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dst.BranchID = Convert.ToInt32(lblBranchID.Text);
            Core.BillUpload.BillUpload objinsert = new Core.BillUpload.BillUpload();
            result = objinsert.BillUploadDisApproveMethod(dst);
            if (result == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);
                clean();
            }
        }
        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        #endregion Event

        #region Method

        protected void columnhide()
        {
            ASPxGridView1.Columns[4].Visible = false;
            ASPxGridView1.Columns[5].Visible = false;
        }

        protected void columnshow()
        {
            ASPxGridView1.Columns[4].Visible = true;
            ASPxGridView1.Columns[5].Visible = true;       
        }
        private DataTable GetTable()
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            DataTable dt4 = new DataTable();
            BillUploadModel.BillUploadInsert dtsingle = new BillUploadModel.BillUploadInsert();
            Core.BillUpload.BillUpload objselectsingle = new Core.BillUpload.BillUpload();
            dt4 = objselectsingle.GetBillUploadApprovalList(userID);
            return dt4;
        }

        protected void show()
        {
            BillUploadModel.BillUploadInsert dtsingle = new BillUploadModel.BillUploadInsert();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.BillUpload.BillUpload objselectsingle = new Core.BillUpload.BillUpload();
            DataTable dt = objselectsingle.GetBillUploadSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                LoadBranch();
                cmbBranch.Text = Convert.ToString(dt.Rows[0]["locnm"]);
                lblBranchID.Text = Convert.ToString(dt.Rows[0]["branchid"]);
                hfReferSheet.Text = Convert.ToString(dt.Rows[0]["FileNm"]);
                cboType.Value = Convert.ToString(dt.Rows[0]["TypeId"]);
                BindTypeName();
                cboTypeName.Value = Convert.ToString(dt.Rows[0]["TypeNameId"]);
                // BindDcNumber();
                DataTable dt1 = objselectsingle.GetBillUploadDcNumberEdit(Convert.ToInt32(cboType.Value), Convert.ToInt32(cboTypeName.Value));//1=Printer,2=Fabricator
                cboDCNumber.DataSource = dt1;
                cboDCNumber.TextField = "InvoiceNumber";
                cboDCNumber.ValueField = "InvoiceNumber";
                cboDCNumber.DataBind();
                if (dt.Rows[0]["DCNumber"].ToString() != "")
                {
                    foreach (var item in Convert.ToString(dt.Rows[0]["DCNumber"]).Split(','))
                    {
                        if (item != "")
                        {
                            for (int i = 0; i < cboDCNumber.Items.Count; i++)
                            {
                                if (item == cboDCNumber.Items[i].Value.ToString())
                                {
                                    cboDCNumber.Items[i].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            ASPxPageControl1.ActiveTabIndex = 0;
        }

      
        protected void LoadBranch()
        {
            if (cmbBranch.SelectedIndex != 0)
            {
                Core.BillUpload.IBillUpload objselectsingle = new Core.BillUpload.BillUpload();
                DataTable dt = objselectsingle.GetBranchAll();
                cmbBranch.DataSource = dt;
                cmbBranch.TextField = "locnm";
                cmbBranch.ValueField = "slno";
                cmbBranch.DataBind();
                cmbBranch.Items.Insert(0, new ListEditItem("Select"));
                cmbBranch.SelectedIndex = 0;
            }
        }

        protected void clean()
        {
            hfReferSheet.Text = string.Empty;
            hfReferSheet.Text = "";
            hfReferSheetDelete.Text = "";
            hfReferSheetDelete.Text = string.Empty;
            lbslno.Text = "0";
            cboTypeName.Text = "";
            cboDCNumber.UnselectAll();
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
        #region File Section
        protected void GetUploadedFiles(int slno, int flag)
        {
            string a = string.Empty;
            BillUploadModel.BillUploadInsert dtsingle = new BillUploadModel.BillUploadInsert();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.BillUpload.BillUpload objselectsingle = new Core.BillUpload.BillUpload();
            DataTable dt = objselectsingle.GetBillUploadFiles(dtsingle);
            if (dt.Rows.Count > 0)
            {
                rptImages.DataSource = dt;
                rptImages.DataBind();
                hdNoRecord.Visible = false;
                lblfilename.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                rptImages.DataSource = null;
                rptImages.DataBind();
                hdNoRecord.Visible = true;
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
                GetUploadedFiles(Convert.ToInt32(lbslno.Text), 9);
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
            GetUploadedFiles(Convert.ToInt32(lbslno.Text), 9);
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
        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedFiles(Convert.ToInt32(lbslno.Text), 9);
            this.mpeImage.Show();
        }
        #endregion
        protected void BindTypeName()
        {
            Core.BillUpload.BillUpload objselectsingle = new Core.BillUpload.BillUpload();
            DataTable dt = objselectsingle.GetBillUploadTypeName(Convert.ToInt32(cboType.Value), Convert.ToInt32(cmbBranch.Value));//1=Printer,2=Fabricator
            cboTypeName.DataSource = dt;
            cboTypeName.TextField = "name";
            cboTypeName.ValueField = "slno";
            cboTypeName.DataBind();
        }

        protected void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTypeName();
        }
        protected void BindDcNumber()
        {
            Core.BillUpload.BillUpload objselectsingle = new Core.BillUpload.BillUpload();
            DataTable dt = objselectsingle.GetBillUploadDcNumber(Convert.ToInt32(cboType.Value), Convert.ToInt32(cboTypeName.Value));//1=Printer,2=Fabricator
            cboDCNumber.DataSource = dt;
            cboDCNumber.TextField = "InvoiceNumber";
            cboDCNumber.ValueField = "InvoiceNumber";
            cboDCNumber.DataBind();
        }

        protected void cboTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDcNumber();
        }
    }
}