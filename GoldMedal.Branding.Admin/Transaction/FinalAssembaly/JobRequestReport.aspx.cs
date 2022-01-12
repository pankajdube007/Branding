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
    public partial class JobRequestReport : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        protected void Page_Load(object sender, EventArgs e)
        {
           // int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                //if (CheckUserRightsForMaster(userID))
                //{
                //    txtFrmDate.Text = "01/04/2020";
                //txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                //BindBranch();
                //lbActiveTab.Text = "1";
                //gvJobRequest.DataBind();
                //}
                //else
                //{
                //    Response.Redirect("~/logout.aspx");
                //}
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    txtFrmDate.Text = "01/04/2020";
                    txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    BindBranch();
                    lbActiveTab.Text = "1";
                    gvJobRequest.DataBind();
                }
            }
            txtToDate.MaxDate = DateTime.Now;
            txtFrmDate.MaxDate = DateTime.Now.AddDays(-1);
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
        protected void BindBranch()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            DataSet dsaselect = objselectsingleselect.AllBranchSelected(param);

            lbBranch.Items.Clear();
            lbBranch.Value = null;
            lbBranch.DataSource = dsaselect.Tables[1];
            lbBranch.TextField = "locnm";
            lbBranch.ValueField = "branchid";
            lbBranch.DataBind();
            //lbBranch.Items.Insert(0, new ListEditItem("Select all", 0));

            if (dsaselect.Tables[0].Rows.Count > 0)
            {
                lbBranch.SelectedItem = lbBranch.Items.FindByValue(dsaselect.Tables[0].Rows[0]["homebranchid"].ToString());
            }
        }

        protected void BindData()
        {

        }

        private DataTable GetTable1()
        {
            DataTable dt = new DataTable();
            //int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

           
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

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
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                dt = objselectall.ListOfJobRequestForJobReport(frmDate, toDate, branchIDs);
            }

            return dt;
        }

        private DataTable GetTable2()
        {
            DataTable dt = new DataTable();
            //int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

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
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                dt = objselectall.ListOfAssignToDesignerJobRequestForJobReport(frmDate, toDate, branchIDs);
            }

            return dt;
        }

        private DataTable GetTable3()
        {
            DataTable dt = new DataTable();
            //int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

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
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                dt = objselectall.ListOfAssignToPrinterJobRequestForJobReport(frmDate, toDate, branchIDs);
            }

            return dt;
        }

        private DataTable GetTable4()
        {
            DataTable dt = new DataTable();
            //int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

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
                Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
                dt = objselectall.ListOfAssignToFabricatorJobRequestForJobReport(frmDate, toDate, branchIDs);
            }

            return dt;
        }

        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            if (e.Tab.Index == 0)
            {
                lbActiveTab.Text = "1";
                gvJobRequest.DataBind();
            }
            else if (e.Tab.Index == 1)
            {
                lbActiveTab.Text = "2";
                gvAssignToDesign.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                lbActiveTab.Text = "3";
                gvAssignToPrinter.DataBind();
            }
            else if (e.Tab.Index == 3)
            {
                lbActiveTab.Text = "4";
                gvAssignToFabricator.DataBind();
            }
        }

        protected void gvJobRequest_DataBinding(object sender, EventArgs e)
        {
            gvJobRequest.DataSource = GetTable1();
        }

        protected void gvAssignToDesign_DataBinding(object sender, EventArgs e)
        {
            gvAssignToDesign.DataSource = GetTable2();
        }

        protected void gvAssignToDesign_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string submitimg = e.GetValue("sumbmitimg").ToString();

            LinkButton hlSubImg = gvAssignToDesign.FindRowCellTemplateControl(e.VisibleIndex, gvAssignToDesign.Columns["Submitted Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;
           
            if (submitimg == "")
            {
                hlSubImg.Visible = false;
            }
        }
        protected void gvAssignToPrinter_DataBinding(object sender, EventArgs e)
        {
            gvAssignToPrinter.DataSource = GetTable3();
        }

        protected void gvAssignToFabricator_DataBinding(object sender, EventArgs e)
        {
            gvAssignToFabricator.DataSource = GetTable4();
        }

        protected void CmdSearch_Click(object sender, EventArgs e)
        {
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

            if (branchIDs == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select atleast one branch !','warning',3);", true);
                return;
            }


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
                    if(lbActiveTab.Text == "1")
                    {
                        gvJobRequest.DataBind();
                    }
                    else if (lbActiveTab.Text == "2")
                    {
                        gvAssignToDesign.DataBind();
                    }
                    else if (lbActiveTab.Text == "3")
                    {
                        gvAssignToPrinter.DataBind();
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

        protected void lnkShowImg_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 4);
            this.mpeImage1.Show();
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

        protected void GetUploadedJobRequestFiles(long slno, int flag)
        {
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();

            param.slno = Convert.ToInt64(lbslno.Text);
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

        #region Export

        protected void columnhide()
        {
            //ASPxGridView1.Columns[0].Visible = false;
            //ASPxGridView1.Columns[11].Visible = false;
        }
        protected void columnshow()
        {
            //ASPxGridView1.Columns[0].Visible = true;
            //ASPxGridView1.Columns[11].Visible = true;
        }

        protected string GetFileName()
        {
            return string.Format("JobRequests_{0}", DateTime.Now.ToString());
        }

        protected string GetFileName1()
        {
            return string.Format("AssignToDesign_{0}", DateTime.Now.ToString());
        }

        protected string GetFileName2()
        {
            return string.Format("AssignToPrinter_{0}", DateTime.Now.ToString());
        }

        protected string GetFileName3()
        {
            return string.Format("AssignToFabricator_{0}", DateTime.Now.ToString());
        }

        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        protected void btnCsvExport1_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter2, FileName, true);
            columnshow();
        }
        protected void btnXlsExport1_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToXls(ASPxGridViewExporter2, FileName, true);
            columnshow();
        }
        protected void btnXlsxExport1_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName1();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter2, FileName, true);
            columnshow();
        }

        protected void btnCsvExport2_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName2();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter3, FileName, true);
            columnshow();
        }
        protected void btnXlsExport2_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName2();
            xpt.GoldGridExportToXls(ASPxGridViewExporter3, FileName, true);
            columnshow();
        }
        protected void btnXlsxExport2_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName2();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter3, FileName, true);
            columnshow();
        }

        protected void btnCsvExport3_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName3();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter4, FileName, true);
            columnshow();
        }
        protected void btnXlsExport3_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName3();
            xpt.GoldGridExportToXls(ASPxGridViewExporter4, FileName, true);
            columnshow();
        }
        protected void btnXlsxExport3_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName3();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter4, FileName, true);
            columnshow();
        }

        #endregion Export

    }
}