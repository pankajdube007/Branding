using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.FinalAssembaly
{
    public partial class JobHistory : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/submitimagebyprinter";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/submitimagebyfabricator";
        private const string FILE_DIRECTORY_NAME4 = "jobrequest/submitimagefinalassembly";
        private const string FILE_DIRECTORY_NAME5 = "jobrequest/shopphoto";

        private string FileName = string.Empty;
        private IExport xpt = null;

        #region PageEvent

        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    txtFrmDate.Text = "01/04/2021";
                    txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    lblassignfabricatorslno.Text = "0";
                      ASPxPageControl1.ActiveTabIndex = 0;
                     lbActiveTab.Text = "1";
                       ASPxGridView1.DataBind();
                    //    ASPxGridView2.DataBind();
                    GetAllJobCount();
                }
               
            }
            txtToDate.MaxDate = DateTime.Now;
            txtFrmDate.MaxDate = DateTime.Now.AddDays(-1);
        }

        #endregion PageEvent

        #region Events
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
        protected void GetAllJobCount()
        {
            DataTable dt = new DataTable();

            dt = GetAllJob();
            lblTotalJobs.Text = dt.Rows[0]["JobCount"].ToString();
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            if (e.Tab.Index == 0)
            {
                lbActiveTab.Text = "1";
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 1)
            {
                lbActiveTab.Text = "2";
                ASPxGridView2.DataBind();
            }
        }

        /// <summary>
        /// shoe the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// List of jobs which are ready for the closer
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();


            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            if (frmDate == "0001-01-01")
            {
                frmDate = "";
            }
            string toDate = txtToDate.Date.ToString("yyyy-MM-dd");
            if (toDate == "0001-01-01")
            {
                toDate = "";
            }

            if (frmDate != "" && toDate != "")
            {

                Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                dsp.slno = 0; // Convert.ToInt32(lblfinalassemblyslno.Text);
                dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dsp.Fromdate = frmDate;
                dsp.ToDate = toDate;
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                dt5 = objselectall.ListOfJobForJobHistory(dsp);
            }
            return dt5;
        }

        private DataTable GetAllJob()
        {
            DataTable dt = new DataTable();
            //int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt = objselectall.AllJobCount("", "", "");
            return dt;
        }

        #endregion Methods

        #region Export

        protected void columnhide()
        {
            ASPxGridView1.Columns[46].Visible = false;
            ASPxGridView1.Columns[47].Visible = false;
            ASPxGridView1.Columns[48].Visible = false;
            ASPxGridView1.Columns[49].Visible = false;
            ASPxGridView1.Columns[54].Visible = false;
            //ASPxGridView1.Columns[11].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[46].Visible = true;
            ASPxGridView1.Columns[47].Visible = true;
            ASPxGridView1.Columns[48].Visible = true;
            ASPxGridView1.Columns[49].Visible = true;
            ASPxGridView1.Columns[54].Visible = true;
            //ASPxGridView1.Columns[0].Visible = true;
            //ASPxGridView1.Columns[11].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("Full_Job_History_{0}", DateTime.Now.ToString());
        }

        protected string GetFileName1()
        {
            return string.Format("Cancelled_Job_History_{0}", DateTime.Now.ToString());
        }

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

        protected void lnkShopPhoto_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 15);
            this.mpeAll.Show();
        }

        protected void lnkJobPhoto_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 3);
            this.mpeAll.Show();
        }

        protected void lnkDesignSubmittedImage_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 4);
            this.mpeAll.Show();
        }

        protected void lnkInstalledImage_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 7);
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
                if (hfPopupImageFlag.Value == "15")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 15);
                }
                else if (hfPopupImageFlag.Value == "4")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 4);
                }
                else if (hfPopupImageFlag.Value == "7")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 7);
                }
                else if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 3);
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

            if (hfPopupImageFlag.Value == "15")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "4")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "7")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "3")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
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

        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string Designsumimg = e.GetValue("Designsumimg").ToString();

            string JobPhoto = e.GetValue("JobPhoto").ToString();

            string ShopPhoto = e.GetValue("ShopPhoto").ToString();

            string Installedimg = e.GetValue("Installedimg").ToString();

            LinkButton hlDesignsumimg = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Design Submitted Image"] as GridViewDataTextColumn, "lnkDesignSubmittedImage") as LinkButton;
            LinkButton hlJobPhoto = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Job Photo"] as GridViewDataTextColumn, "lnkJobPhoto") as LinkButton;
            LinkButton hlShopPhoto = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Shop Photo"] as GridViewDataTextColumn, "lnkShopPhoto") as LinkButton;
            LinkButton hlInstalledimg = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Installed  Image"] as GridViewDataTextColumn, "lnkInstalledImage") as LinkButton;


            if (Designsumimg == "")
            {
                hlDesignsumimg.Visible = false;
            }

            if (JobPhoto == "")
            {
                hlJobPhoto.Visible = false;
            }

            if (ShopPhoto == "")
            {
                hlShopPhoto.Visible = false;
            }
            if (Installedimg == "")
            {
                hlInstalledimg.Visible = false;
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
            ASPxGridView2.Columns[45].Visible = false;
            ASPxGridView2.Columns[46].Visible = false;
            ASPxGridView2.Columns[47].Visible = false;
            ASPxGridView2.Columns[48].Visible = false;
           
            ASPxGridView2.Columns[53].Visible = false;
            //ASPxGridView1.Columns[11].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow1()
        {
            ASPxGridView2.Columns[45].Visible = true;
            ASPxGridView2.Columns[46].Visible = true;
            ASPxGridView2.Columns[47].Visible = true;
            ASPxGridView2.Columns[48].Visible = true;
            
            ASPxGridView2.Columns[53].Visible = true;
            //ASPxGridView1.Columns[0].Visible = true;
            //ASPxGridView1.Columns[11].Visible = true;
        }
        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }
        private DataTable GetTable3()
        {
            DataTable dt5 = new DataTable();
            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            if (frmDate == "0001-01-01")
            {
                frmDate = "";
            }
            string toDate = txtToDate.Date.ToString("yyyy-MM-dd");
            if (toDate == "0001-01-01")
            {
                toDate = "";
            }

            if (frmDate != "" && toDate != "")
            {
                Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = 0; // Convert.ToInt32(lblfinalassemblyslno.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dsp.Fromdate = frmDate;
                dsp.ToDate = toDate;
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.ListOfCancelledJobForJobHistory(dsp);
                }
            return dt5;
        }
        protected void ASPxGridView2_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string Designsumimg = e.GetValue("Designsumimg").ToString();

            string JobPhoto = e.GetValue("JobPhoto").ToString();

            string ShopPhoto = e.GetValue("ShopPhoto").ToString();

            string Installedimg = e.GetValue("Installedimg").ToString();

            LinkButton hlDesignsumimg = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Design Submitted Image"] as GridViewDataTextColumn, "lnkDesignSubmittedImage") as LinkButton;
            LinkButton hlJobPhoto = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Job Photo"] as GridViewDataTextColumn, "lnkJobPhoto") as LinkButton;
            LinkButton hlShopPhoto = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Shop Photo"] as GridViewDataTextColumn, "lnkShopPhoto") as LinkButton;
            LinkButton hlInstalledimg = ASPxGridView2.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView2.Columns["Installed  Image"] as GridViewDataTextColumn, "lnkInstalledImage") as LinkButton;


            if (Designsumimg == "")
            {
                hlDesignsumimg.Visible = false;
            }

            if (JobPhoto == "")
            {
                hlJobPhoto.Visible = false;
            }

            if (ShopPhoto == "")
            {
                hlShopPhoto.Visible = false;
            }
            if (Installedimg == "")
            {
                hlInstalledimg.Visible = false;
            }
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void CmdSearch_Click(object sender, EventArgs e)
        {
            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            if (frmDate == "0001-01-01")
            {
                frmDate = "";
            }

            string toDate = txtToDate.Date.ToString("yyyy-MM-dd");
            if (toDate == "0001-01-01")
            {
                toDate = "";
            }

            if (frmDate != "" && toDate != "")
            {
                DateTime dtFrm = Convert.ToDateTime(txtFrmDate.Date.ToString("yyyy-MM-dd"));
                DateTime dtTo = Convert.ToDateTime(txtToDate.Date.ToString("yyyy-MM-dd"));

                if (dtFrm <= dtTo)
                {
                    

                    if (lbActiveTab.Text == "1")
                    {
                        ASPxGridView1.DataBind();
                    }
                    else if (lbActiveTab.Text == "2")
                    {
                        ASPxGridView2.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('From Date should be less than To Date.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select both the dates.');", true);
            }
        }

        protected void ASPxCallback2_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
    }
}