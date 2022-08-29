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
    public partial class BillUploadReport : System.Web.UI.Page
    {
        #region Initialization
        private DataTable dt = new DataTable();
        private string FileNameVC = string.Empty;
        private string FileName = string.Empty;
        private IExport xpt = null;
        private const string FILE_DIRECTORY_NAME = "billupload";
        private readonly IGoldMedia _goldMedia;
        #endregion Initialization

        #region PageEvent
        public BillUploadReport()
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
                    DateTime fdt = new DateTime(DateTime.Now.Year, 4, 1);
                    if (DateTime.Now.Month > 3)
                    {
                        fdt = new DateTime(DateTime.Now.Year, 4, 1);
                    }
                    else

                    {
                        fdt = new DateTime(DateTime.Now.Year - 1, 4, 1);
                    }
                    txtFromDate.Text = fdt.ToString("dd/MM/yyyy");
                    txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 0;
                    LoadBranch();
                    ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }
        protected void LoadBranch()
        {
            Core.BillUpload.IBillUpload objselectsingle = new Core.BillUpload.BillUpload();
            DataTable dt = objselectsingle.GetBranchAll();
            cmbBranch.DataSource = dt;
            cmbBranch.TextField = "locnm";
            cmbBranch.ValueField = "slno";
            cmbBranch.DataBind();
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

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedFiles(Convert.ToInt32(lbslno.Text), 9);
            this.mpeImage.Show();
        }


        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        #endregion Event

        #region Method

        protected void columnhide()
        {
            ASPxGridView1.Columns[7].Visible = false;
        }

        protected void columnshow()
        {
            ASPxGridView1.Columns[7].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("Transaction_BillUploadReport_{0}", DateTime.Now.ToString());
        }

        private DataTable GetTable()
        {
            DataTable dt4 = new DataTable();
            BillUploadModel.BillUploadInsert dtsingle = new BillUploadModel.BillUploadInsert();
            Core.BillUpload.BillUpload objselectsingle = new Core.BillUpload.BillUpload();
            string BranchIDs = "";
            for (int i = 0; i < cmbBranch.Items.Count; i++)
            {
                if (cmbBranch.Items[i].Selected == true)
                {
                    BranchIDs += cmbBranch.Items[i].Value.ToString() + ",";
                }
            }
            BranchIDs = BranchIDs.TrimEnd(',');

            string FromDate = string.Empty, ToDate = string.Empty;

            string[] st1 = txtFromDate.Text.Split('/');
            if (st1.Count() > 2)
            {
                FromDate = st1[1] + "/" + st1[0] + "/" + st1[2];
            }

            string[] st2 = txtToDate.Text.Split('/');

            if (st2.Count() > 2)
            {
                ToDate = st2[1] + "/" + st2[0] + "/" + st2[2];
            }

            dt4 = objselectsingle.GetBillUploadReport(BranchIDs, FromDate, ToDate);
            return dt4;
        }
        protected void CmdSearch_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }


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
            }
            else
            {
                rptImages.DataSource = null;
                rptImages.DataBind();
                hdNoRecord.Visible = true;
            }
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
    }
}