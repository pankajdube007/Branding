using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.Reports
{
    public partial class JobTypeImageReport : System.Web.UI.Page
    {
        private const string FILE_DIRECTORY_NAME = "master/jobtypeimage";
        private string FileName = string.Empty;
        private IExport xpt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (CheckUserRightsForMaster(userID))
            {
                if (!IsPostBack)
                {

                    ASPxPageControl1.ActiveTabIndex = 0;
                    //ASPxGridView1.DataBind();
                    // ASPxGridView2.DataBind();
                }
                ASPxGridView1.DataBind();
                ASPxGridView2.DataBind();
            }
            else
            {
                Response.Redirect("~/logout.aspx");
            }
        }

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
            if (e.Tab.Index == 0)
            {
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 1)
            {
                ASPxGridView2.DataBind();
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }


        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();
            Core.JobType.JobType objselectall = new Core.JobType.JobType();
            dt4 = objselectall.GetJobTypeActiveImage();
            return dt4;
        }


        protected void columnhide()
        {
            ASPxGridView1.Columns[2].Visible = false;
           
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[2].Visible = true;
           
        }

        protected string GetFileName()
        {
            return string.Format("Active_Job_Type_Image_List_{0}", DateTime.Now.ToString());
        }

        protected string GetFileName1()
        {
            return string.Format("Inactive_Job_Type_Image_List_{0}", DateTime.Now.ToString());
        }
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
        protected void lnkJobTypePhoto_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 17);
            this.mpeAll.Show();
        }

        protected void lnkJobTypePhotoInactive_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 19);
            this.mpeAll.Show();
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
        protected void rptAllImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hfPImgName = (HiddenField)e.Item.FindControl("hfPImgName");

            var path = "";

            if (e.CommandName == "Down")
            {
                if (hfPopupImageFlag.Value == "17")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 17);
                }

               else if (hfPopupImageFlag.Value == "19")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 19);
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

            if (hfPopupImageFlag.Value == "17")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
            }
           else if (hfPopupImageFlag.Value == "19")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
            }


            if (hfPImgName.Value.Contains(".jpg") || hfPImgName.Value.Contains(".png") || hfPImgName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
            }
            
        }

        protected void btnXlsExport1_Click(object sender, EventArgs e)
        {
            columnhide1();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToXls(ASPxGridViewExporter2, FileName, true);
            columnshow1();
        }

        protected void btnXlsxExport1_Click(object sender, EventArgs e)
        {
            columnhide1();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter2, FileName, true);
            columnshow1();
        }

        protected void btnCsvExport1_Click(object sender, EventArgs e)
        {
            columnhide1();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter2, FileName, true);
            columnshow1();
        }
        protected void columnhide1()
        {
            ASPxGridView2.Columns[2].Visible = false;
           
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow1()
        {
            ASPxGridView2.Columns[2].Visible = true;
            
        }
        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }
        private DataTable GetTable3()
        {
            DataTable dt4 = new DataTable();
            Core.JobType.JobType objselectall = new Core.JobType.JobType();
            dt4 = objselectall.GetJobTypeInactiveImage();
            return dt4;
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
    }
}