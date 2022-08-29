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

namespace GoldMedal.Branding.Admin.Transaction.CancelJob
{
    public partial class JobCancel : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        private string TableNme = "Tbl_DesignSubmit ";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/visitingcard";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/refersheet";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME13 = "jobrequest/cdrfile";
        private const string FILE_DIRECTORY_NAME4 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME12 = "jobrequest/approveprintjob";
        private const string FILE_DIRECTORY_NAME10 = "jobrequest/liveproductimage";
        private const string FILE_DIRECTORY_NAME14 = "jobrequest/detailsbyparty";
        private const string FILE_DIRECTORY_NAME5 = "jobrequest/submitimagebyprinter";
        private const string FILE_DIRECTORY_NAME6 = "jobrequest/submitimagebyfabricator";
        private const string FILE_DIRECTORY_NAME7 = "jobrequest/submitimagefinalassembly";

        #region PageEvent
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    lblFabricatorAssignID.Text = "0";
                    txtFrmDate.Text = DateTime.Now.AddDays(-30).Date.ToString("dd/MM/yyyy");
                    txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    BindBranch();
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
                }
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


        #endregion PageEvent
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
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
           // clean();

            if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
            
        }
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblFinalAssemblyID.Text = FieldTripID.ToString();
            lblgd1.Text = "1";
            show2();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean2();
        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();

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
                Data.CancelJob.CancelJob.CancelJobProperty dsp = new Data.CancelJob.CancelJob.CancelJobProperty();

                Core.CancelJob.CancelJob objselectall = new Core.CancelJob.CancelJob();
                dt5 = objselectall.ListOfJobForCancelDateWise(frmDate, toDate, branchIDs);
            }



           
            return dt5;
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
                    ASPxGridView1.DataBind();
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

        protected void show2()
        {
            Data.CancelJob.CancelJob.CancelJobProperty dtsingle = new Data.CancelJob.CancelJob.CancelJobProperty();
            
            dtsingle.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dtsingle.Remark = txtremark.Text;
            Core.CancelJob.CancelJob objselectsingle = new Core.CancelJob.CancelJob();
            DataTable dt = objselectsingle.DetailsOfJobForJobCancel(dtsingle);
            if (dt.Rows.Count > 0)
            {
                //All Ids
                lblHeadID.Text = Convert.ToString(dt.Rows[0]["HeadID"]);
                lblChildID.Text = Convert.ToString(dt.Rows[0]["ChildID"]);
                lblDesignSubmitID.Text = Convert.ToString(dt.Rows[0]["DesignSubmitID"]);
                lblPrinterAssignID.Text = Convert.ToString(dt.Rows[0]["PrinterAssignID"]);
                lblPrinterID.Text = Convert.ToString(dt.Rows[0]["PrinterID"]);
                lblFabricatorAssignID.Text = Convert.ToString(dt.Rows[0]["FabricatorAssignID"]);
                lblFabricatorID.Text = Convert.ToString(dt.Rows[0]["FabricatorID"]);
                lblFinalAssemblyID.Text = Convert.ToString(dt.Rows[0]["FinalAssemblyID"]);

                //Job Request Details
                lblBranch.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["NameType"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                lblSubmittedBy.Text = Convert.ToString(dt.Rows[0]["submittedby"]);
                lblApprovedBy.Text = Convert.ToString(dt.Rows[0]["approvedby"]);
                lblJobStatus.Text = Convert.ToString(dt.Rows[0]["JobStatus"]);

                //Dealer Details
                lblName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["ContactPerson"]);
                lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblGST.Text = Convert.ToString(dt.Rows[0]["GstNo"]);

                if (Convert.ToString(dt.Rows[0]["RetailerID"]) != "0")
                {
                    retailerdetails.Style.Add("display", "block");
                    //Retailer Details
                    lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);
                    lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                    lblSubAddress.Text = Convert.ToString(dt.Rows[0]["SubAddress"]);
                    lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                    lblSubEmail.Text = Convert.ToString(dt.Rows[0]["subemail"]);
                }

                //Job Details
                lblDimension.Text = Convert.ToString(dt.Rows[0]["Dimension"]);
                lblQty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblJobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                lblSubJobtype.Text = Convert.ToString(dt.Rows[0]["subjobtype"]);
                lblSubSubJobtype.Text = Convert.ToString(dt.Rows[0]["subsubjobtype"]);
                lblDesignType.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                lblProductType.Text = Convert.ToString(dt.Rows[0]["producttype"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrinterLocation.Text = Convert.ToString(dt.Rows[0]["PrinterLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);
                lblInstallAddress.Text = Convert.ToString(dt.Rows[0]["InstallAddress"]);

                lblIsPartyApproval.Text = Convert.ToString(dt.Rows[0]["IsPartyApproval"]);
                if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                {
                    partyapprovedetails.Style.Add("display", "block");
                    lblPartyApprovalTo.Text = Convert.ToString(dt.Rows[0]["ApprovalTo"]);
                    lblApprovalEmailID.Text = Convert.ToString(dt.Rows[0]["approvalemail"]);
                }

                lblIsPlaceSize.Text = Convert.ToString(dt.Rows[0]["IsPlaceSize"]);
                JobImgLink.Text = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                JobImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["ApproveRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                    lbVisitingCard.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                    lbRefersheet.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["JobImage"]) != "")
                {
                    JobImgLink.Visible = true;
                    lbJobImage.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["cdrfile"]) != "")
                {
                    lbCDRFile.Visible = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["JobCount"]) > 1)
                {
                    lbOtherJobImage.Visible = true;
                    lbOtherJobImage.Visible = true;
                }

                
            }

           

            ASPxPageControl1.ActiveTabIndex = 0;
        }

        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            if (lblChildID.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Please select any one record !','error',3);", true);
            }
            else if (txtremark.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Please enter remark !','error',3);", true);
            }
            else
            {
                
                    Data.CancelJob.CancelJob.CancelJobProperty dst = new Data.CancelJob.CancelJob.CancelJobProperty();
                    dst.slno = Convert.ToInt64(lblChildID.Text);
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.Remark = txtremark.Text;
                    Core.CancelJob.CancelJob objinsert = new Core.CancelJob.CancelJob();
                    result = objinsert.JobCancel(dst);
               

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job cancelled successfully !','success',3);", true);
                    clean2();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                    clean2();
                }
            }
            clean2();
        }
        protected void lnkFiles1_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadID.Text), 1);
            this.mpeAll.Show();
        }
        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadID.Text), 2);
            this.mpeAll.Show();
        }
        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblChildID.Text), 3);
            this.mpeAll.Show();
        }
        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblChildID.Text), 13);
            this.mpeAll.Show();
        }
        protected void lnkFiles5_Click(object sender, EventArgs e)
        {
           // GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 4);
           // this.mpeAll.Show();
        }
        protected void lnkFiles6_Click(object sender, EventArgs e)
        {
           // GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 12);
            //this.mpeAll.Show();
        }
        protected void lnkFiles7_Click(object sender, EventArgs e)
        {
          //  GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 10);
          //  this.mpeAll.Show();
        }
        protected void lnkFiles8_Click(object sender, EventArgs e)
        {
           // GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 14);
           // this.mpeAll.Show();
        }
        protected void lnkFiles9_Click(object sender, EventArgs e)
        {
           // GetUploadedJobRequestFiles(Convert.ToInt64(lblPrinterAssignID.Text), 5);
           // this.mpeAll.Show();
        }
        protected void lnkFiles10_Click(object sender, EventArgs e)
        {
          //  GetUploadedJobRequestFiles(Convert.ToInt64(lblFabricatorAssignID.Text), 6);
           // this.mpeAll.Show();
        }
        protected void lnkFiles11_Click(object sender, EventArgs e)
        {
          //  GetUploadedJobRequestFiles(Convert.ToInt64(lblFinalAssemblyID.Text), 7);
           // this.mpeAll.Show();
        }
        protected void lnkFiles12_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadID.Text), 11);
            this.mpeAll.Show();
        }
        protected void lnkFiles13_Click(object sender, EventArgs e)
        {
          //  GetUploadedJobRequestFiles(Convert.ToInt64(lblPrinterAssignID.Text), 5);
           // this.mpeAll.Show();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }
        protected void clean2()
        {
            lblHeadID.Text = "0";
            lblChildID.Text = "0";
            lblDesignSubmitID.Text = "0";
            lblPrinterID.Text = "0";
            lblFabricatorID.Text = "0";
            lblPrinterAssignID.Text = "0";
            lblFabricatorAssignID.Text = "0";
            lblFinalAssemblyID.Text = "0";

            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";

            lblgd1.Text = "0";
            lblgd2.Text = "0";
            lblgd3.Text = "0";

            LblRequestNo.Text = "";
            lblBranch.Text = "";
            lblDate.Text = "";
            lblNameType.Text = "";
            lblGivenBy.Text = "";
            lblSubmittedBy.Text = "";
            lblApprovedBy.Text = "";
            lblJobStatus.Text = "";

            lblName.Text = "";
            lblAddress.Text = "";
            lblContactPerson.Text = "";
            lblContactNo.Text = "";
            lblEmail.Text = "";
            lblCinNo.Text = "";
            lblGST.Text = "";

            retailerdetails.Style.Add("display", "none");
            lblFirmName.Text = "";
            lblSubName.Text = "";
            lblSubAddress.Text = "";
            lblSubContact.Text = "";
            lblSubEmail.Text = "";

            lblDimension.Text = "";
            lblQty.Text = "";
            lblJobtype.Text = "";
            lblSubJobtype.Text = "";
            lblSubSubJobtype.Text = "";
            lblDesignType.Text = "";
            lblProductType.Text = "";
            lblBoardType.Text = "";
            lblPrinterLocation.Text = "";
            lblFabricatorLocation.Text = "";
            lblPriority.Text = "";
            lblInstallAddress.Text = "";
            lblIsPartyApproval.Text = "";

            partyapprovedetails.Style.Add("display", "none");
            lblPartyApprovalTo.Text = "";
            lblApprovalEmailID.Text = "";

            lblIsPlaceSize.Text = "";
            JobImgLink.Text = "";
            JobImgLink.NavigateUrl = "";
            lblJobRemark.Text = "";
            lblApproveRemark.Text = "";
            lblAssignRemark.Text = "";

           

            lbVisitingCard.Visible = false;

            lbRefersheet.Visible = false;

            JobImgLink.Visible = false;
            lbJobImage.Visible = false;

            lbCDRFile.Visible = false;

            lbRefersheet.Visible = false;

           

            txtremark.Text = string.Empty;

            
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
                if (hfPopupImageFlag.Value == "1")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadID.Text), 1);
                }
                else if (hfPopupImageFlag.Value == "2")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadID.Text), 2);
                }
                else if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblChildID.Text), 3);
                }
                else if (hfPopupImageFlag.Value == "13")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadID.Text), 13);
                }
                else if (hfPopupImageFlag.Value == "4")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 4);
                }
                else if (hfPopupImageFlag.Value == "12")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME12, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 12);
                }
                else if (hfPopupImageFlag.Value == "10")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME10, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 10);
                }
                else if (hfPopupImageFlag.Value == "14")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME14, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 14);
                }
                else if (hfPopupImageFlag.Value == "5")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblPrinterAssignID.Text), 5);
                }
                else if (hfPopupImageFlag.Value == "6")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME6, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblFabricatorAssignID.Text), 6);
                }
                else if (hfPopupImageFlag.Value == "7")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME7, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblFinalAssemblyID.Text), 7);
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

            if (hfPopupImageFlag.Value == "1")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "2")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "3")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "13")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "4")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "12")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME12, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME12, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "10")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME10, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME10, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "14")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME14, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME14, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "5")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "6")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME6, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME6, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "7")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME7, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME7, hfPImgName.Value);
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
        protected void columnhide()
        {
            ASPxGridView1.Columns[21].Visible = false;
            
        }
        protected void columnshow()
        {
            ASPxGridView1.Columns[21].Visible = true;
           
        }

        protected string GetFileName()
        {
            return string.Format("JobCancel_{0}", DateTime.Now.ToString());
        }
    }
}