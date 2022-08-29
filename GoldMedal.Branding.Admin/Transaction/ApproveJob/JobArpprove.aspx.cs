using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoldMedal.Branding.Data.JobRequest;
using System.Configuration;

namespace GoldMedal.Branding.Admin.Transaction.ApproveJob
{
    public partial class JobArpprove : System.Web.UI.Page
    {

        public JobArpprove()
        {
            _goldMedia = new GoldMedia();
            //  finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }
        #region Initialization



        public string party = string.Empty;
        private int rows = 0;

        private string flagImg = string.Empty;
        private string FileName = string.Empty;
        private IExport xpt = null;
        private string TableNme = "tbl_jobrequestchild";

        private const string FILE_DIRECTORY_NAME1 = "jobrequest/visitingcard";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/refersheet";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME4 = "jobrequest/shopphoto";
        private const string FILE_DIRECTORY_NAME13 = "jobrequest/cdrfile";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        #endregion Initialization
        #region Edit Block - Variable
        private string html = string.Empty;
        private string overtime = string.Empty, maxtime = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "tbl_jobrequesthead";
        private string Node = "Transaction";
        private string str = string.Empty;

        JobRequestDataAccess jobda = new JobRequestDataAccess();

        #endregion Edit Block - Variable

        #region Page Event

        /// <summary>
        /// Show All the jobrequest head of the approvel.
        /// </summary>
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
                    gvHead.DataBind();
                    ASPxPageControl1.ActiveTabIndex = 1;
                    txtToDate.Text = DateTime.Now.ToShortDateString();
                }
            }
            txtToDate.MaxDate = DateTime.Now;
            txtFromDate.MaxDate = DateTime.Now.AddDays(-1);
        }
      
        #endregion 

        #region Method

        /// <summary>
        /// Get All the job request head in which at leat one child is not approved.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTableHead()
        {
            Data.ApproveJob.ApproveJobModel.ApproveProperties paramHead = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
            paramHead.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.ApproveJob.ApproveJob objdata = new Core.ApproveJob.ApproveJob();
            DataTable dt = objdata.AllJobRequestHeadForApproveDACore(paramHead);
            return dt;
        }

        public void LoadPrintLocation()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable dtprintloc = db.GetPrinterLocation();

                ddlPrintLocation.Items.Clear();

                ddlPrintLocation.DataSource = dtprintloc;
                ddlPrintLocation.DataBind();

                ddlPrintLocation.Items.Insert(0, "Select");
            }
        }

        public void LoadFabricatorLocation()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable dtfabloc = db.GetFabricatorLocation();

                ddlFabricatorLocation.Items.Clear();

                ddlFabricatorLocation.DataSource = dtfabloc;
                ddlFabricatorLocation.DataBind();

                ddlFabricatorLocation.Items.Insert(0, "Select");
            }
        }


        private DataTable GetApprovedJobs()
        {
            DataTable dt = new DataTable();

            bool success = false;

            string fromdate = "";
            string todate = "";

            DateTime fdate = DateTime.MinValue;
            DateTime tdate = DateTime.MinValue;

            Data.ApproveJob.ApproveJobModel.ApproveProperties paramHead = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
            paramHead.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            if (string.IsNullOrEmpty(txtFromDate.Text) || string.IsNullOrEmpty(txtToDate.Text))
            {
                fdate = DateTime.Now.AddDays(-30);
                tdate = DateTime.Now;
                success = true;
                paramHead.fromdate = fdate.ToShortDateString();
                paramHead.todate = tdate.ToShortDateString();
            }
            else
            {
                success = DateTime.TryParse(txtFromDate.Text, out fdate);
                if (!success || fdate == DateTime.MinValue)
                {
                    success = false;
                }

                success = DateTime.TryParse(txtToDate.Text, out tdate);
                if (!success || tdate == DateTime.MinValue)
                {
                    success = false;
                }
            }

            if (success)
            {
                double days = (tdate - fdate).TotalDays;

                if (days > 0)
                {
                    paramHead.fromdate = fdate.ToShortDateString();
                    paramHead.todate = tdate.ToShortDateString();
                    Core.ApproveJob.ApproveJob objdata = new Core.ApproveJob.ApproveJob();
                    dt = objdata.AllApprovedJobByUserCore(paramHead);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid to date !','warning',3);", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }

            return dt;
        }

        /// <summary>
        /// Create Dummy Grid for the child
        /// </summary>
        private class DummyGrid
        {
            public string slno { get; set; }
            public string refid { get; set; }
            public string TaskID { get; set; }
            public string UnitID { get; set; }
            public string Priority { get; set; }
            public string BoardTypeID { get; set; }
            public string PrintLocation { get; set; }
            public string FabricatorLocation { get; set; }
            public string SizeInch { get; set; }
            public string SizeHeight { get; set; }
            public string JobType { get; set; }
            public string JobSubType { get; set; }
            public string Material { get; set; }
            public string Product { get; set; }
            public string Qty { get; set; }
            public string InstallAddress { get; set; }
            public string Remark { get; set; }
            public string NeedApproval { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string JobTypeId { get; set; }
            public string SubJobTypeId { get; set; }
            public string SubSubJobTypeId { get; set; }
            public string DesignTypeId { get; set; }
            public string ProductTypeId { get; set; }
            public string Image { get; set; }
            public string ChildStatus { get; set; }
        }

        /// <summary>
        /// Bind The Child Grid
        /// </summary>
        protected void BindGridview()
        {
            DummyGrid test1 = new DummyGrid()
            {
                slno = string.Empty,
                refid = string.Empty,
                UnitID = string.Empty,
                Priority = string.Empty,
                TaskID = string.Empty,
                BoardTypeID = string.Empty,
                PrintLocation = string.Empty,
                FabricatorLocation = string.Empty,
                SizeInch = string.Empty,
                SizeHeight = string.Empty,
                JobType = string.Empty,
                JobSubType = string.Empty,
                Material = string.Empty,
                Product = string.Empty,
                Qty = string.Empty,
                InstallAddress = string.Empty,
                Remark = string.Empty,
                NeedApproval = "False",
            };
            List<DummyGrid> list = new List<DummyGrid>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(test1);
            }
            LoadPrintLocation();
            LoadFabricatorLocation();
            gvDetails.DataSource = list;
            gvDetails.DataBind();
        }


        /// <summary>
        /// Used in approval and disapproval action for check that the particular data is in use are not
        /// </summary>
        ///
        protected void CheckEditBlock(string param, int id)
        {
            popupcount.Value = "0";
            Data.CheckTime.CheckTimeModel.CheckTimeInsert dttime = new Data.CheckTime.CheckTimeModel.CheckTimeInsert();
            dttime.Node = Node;
            Core.CheckTime.CheckTime dttimee = new Core.CheckTime.CheckTime();

            DataTable time = dttimee.GetCheckTimeForNode(dttime);
            if (time.Rows.Count > 0)
            {
                overtime = Convert.ToString(time.Rows[0]["overwrite"]);
                maxtime = Convert.ToString(time.Rows[0]["maxtime"]);
            }
            DataTable dtEditChk = new DataTable();
            Data.CheckEdit.CheckEditModel.CheckEditInsert dst = new Data.CheckEdit.CheckEditModel.CheckEditInsert();
            dst.slno = ValidateDataType.EnsureMaximumLength(lbslno.Text, 100);
            dst.TableNm = ValidateDataType.EnsureMaximumLength(TableNm, 100);
            dst.adminid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dst.PageNm = HttpContext.Current.Request.Url.ToString();
            dst.usercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(1));
            dst.overwritetime = Convert.ToInt32(overtime);
            dst.maxtime = Convert.ToInt32(maxtime);
            Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
            dtEditChk = objselectall.GetCheckEditAll(dst);
            if (dtEditChk.Rows.Count > 0)
            {
                if (dtEditChk.Rows[0]["PStatus"] != null && (dtEditChk.Rows[0]["PStatus"].ToString() == "InActive" || dtEditChk.Rows[0]["PStatus"].ToString() == "Unchecked"))
                {
                    if (param == "Delete")
                    {
                        #region Delete Block

                        Data.JobRequest.JobRequestModel.JobRequestProperties param1 = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                        param1.slno = Convert.ToInt32(lbslno.Text);
                        param1.createlogno = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["logno"].Value))));
                        param1.createuid = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["userlogid"].Value))));

                        Core.JobRequest.JobRequest objdelete = new Core.JobRequest.JobRequest();
                        rows = objdelete.DeleteJobRequestHeadCore(param1);
                        if (rows == 1)
                        {
                            // MessageBox("Delete Successfull !", "Success");
                            gvHead.DataBind();
                        }
                        else
                        {
                            //  MessageBox("Data present delete not permit !", "Warning");
                            gvHead.DataBind();
                        }

                        #endregion Delete Block
                    }
                    else
                    {
                        show();
                    }
                }
                else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Active")
                {
                    #region Build HTML

                    if (dtEditChk.Rows[0]["usercat"] != null && dtEditChk.Rows[0]["usercat"].ToString() != string.Empty)
                    {
                        html += "<div>Name : " + dtEditChk.Rows[0]["usercat"].ToString() + "</div>";
                    }
                    if (dtEditChk.Rows[0]["BranchNm"] != null && dtEditChk.Rows[0]["BranchNm"].ToString() != string.Empty)
                    {
                        html += "<div>Branch : " + dtEditChk.Rows[0]["BranchNm"].ToString() + "</div>";
                    }
                    if (dtEditChk.Rows[0]["Designation"] != null && dtEditChk.Rows[0]["Designation"].ToString() != string.Empty)
                    {
                        html += "<div>Designation : " + dtEditChk.Rows[0]["Designation"].ToString() + "</div>";
                    }

                    if (dtEditChk.Rows[0]["offContactNo"] != null && dtEditChk.Rows[0]["offContactNo"].ToString() != string.Empty)
                    {
                        html += "<div>Contact No : " + dtEditChk.Rows[0]["offContactNo"].ToString() + "</div>";
                    }
                    else if (dtEditChk.Rows[0]["offphone1"] != null && dtEditChk.Rows[0]["offphone1"].ToString() != string.Empty)
                    {
                        html += "<div>Contact No : " + dtEditChk.Rows[0]["offphone1"].ToString() + "</div>";
                    }

                    #endregion Build HTML

                    if (dtEditChk.Rows[0]["viewoverwrite"] != null && dtEditChk.Rows[0]["viewoverwrite"].ToString() == "No")
                    {
                        lbslno.Text = "0";
                        str = @"<div><div>Another user is already working on the page.</div></br>" + html + "</div>";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + str + "','warning');", true);
                    }
                    else if (dtEditChk.Rows[0]["viewoverwrite"] != null && dtEditChk.Rows[0]["viewoverwrite"].ToString() == "Yes")
                    {
                        if (param != "Delete")
                        {
                            overwriteStr = @"<br><div ow-lf>Do you wish to overwrite current session ?</div><div ow-css ow-yes>Yes</div><div ow-css ow-no>No</div></div>";
                        }
                        str = @"<div><div>Another user is already working on the page.</div></br><div>" + html + string.Empty + overwriteStr + "</div>";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + str + "','warning');", true);
                    }
                    else
                    {
                        lbslno.Text = "0";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',3);", true);
                    }
                }
                else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Error")
                {
                    lbslno.Text = "0";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Error occurred, please refresh and try again.','error',3);", true);
                }
            }
            else
            {
                lbslno.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',3);", true);
            }
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
            MimeType.Pdf,
            MimeType.cdr,
            MimeType.ppt,
            MimeType.pptx
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
        /// <summary>
        /// Fill the head and child data after clicking on view link
        /// </summary>
        /// 

        protected void show()
        {
            #region Edit Block

            Data.JobRequest.JobRequestModel.JobRequestProperties paramHead = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            paramHead.slno = Convert.ToInt32(lbslno.Text);
            Core.JobRequest.JobRequest objdataHead = new Core.JobRequest.JobRequest();
            DataTable dtHead = objdataHead.JobRequestHeadSelectParticularCore(paramHead);
            Data.ApproveJob.ApproveJobModel.ApproveProperties paramHeadassign = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
            paramHeadassign.slno = Convert.ToInt64(lbslno.Text);
            if (dtHead.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dtHead.Rows[0]["reqno"]);
                lblNameType.Text = Convert.ToString(dtHead.Rows[0]["NameType"]);
                lblName.Text = Convert.ToString(dtHead.Rows[0]["AllName"]);
                lblAddress.Text = Convert.ToString(dtHead.Rows[0]["AllAddress"]);
                lblContactPerson.Text = Convert.ToString(dtHead.Rows[0]["ContactPerson"]);
                lblContact.Text = Convert.ToString(dtHead.Rows[0]["contactnumber"]);
                lblEmail.Text = Convert.ToString(dtHead.Rows[0]["Email"]);
                lblDate.Text = Convert.ToString(dtHead.Rows[0]["RequestDate"]);

                lblCinNo.Text = Convert.ToString(dtHead.Rows[0]["cinnum"]);


                lblSubName.Text = Convert.ToString(dtHead.Rows[0]["name"]);

                lblSubFirmName.Text = Convert.ToString(dtHead.Rows[0]["Subcompname"]);

                lblSubAddress.Text = Convert.ToString(dtHead.Rows[0]["SubAddress"]);
                lblSubContact.Text = Convert.ToString(dtHead.Rows[0]["SubContact"]);
                lblGivenBy.Text = Convert.ToString(dtHead.Rows[0]["GivenByName"]);

                lblSubmittedBy.Text = Convert.ToString(dtHead.Rows[0]["submittedby"]);
                lblApprovedBy.Text = Convert.ToString(dtHead.Rows[0]["approvedby"]);

                lblacount.Text = Convert.ToString(dtHead.Rows[0]["acount"]);
                hfVisitingImage.Text = Convert.ToString(dtHead.Rows[0]["VisitingCardImg"]);
                hfReferSheet.Text = Convert.ToString(dtHead.Rows[0]["ReferSheet"]);
                hfShopPhoto.Text = Convert.ToString(dtHead.Rows[0]["ShopPhoto"]);

                lblBranchID.Text = Convert.ToString(dtHead.Rows[0]["branchid"]);

                Core.ApproveJob.ApproveJob objdataHeadassign = new Core.ApproveJob.ApproveJob();
                DataTable dtChildassign = objdataHeadassign.JobRequestChildSelectForApproveParticularCore(paramHeadassign);
                for (int i = dtChildassign.Rows.Count + 1; i <= dtChildassign.Rows.Count; i++)
                {
                    DataRow row = dtChildassign.NewRow();
                    row["slno"] = 0;
                    dtChildassign.Rows.Add(row);
                }
                gvDetails.DataSource = dtChildassign;
                gvDetails.DataBind();
                LblRequestNo.Focus();

                if (Convert.ToString(dtHead.Rows[0]["RetailerID"]) != "0")
                {
                    GetDhanbarseRetailerStatus(Convert.ToInt32(dtHead.Rows[0]["RetailerID"]));
                    dhbretdet.Style.Add("display", "block");
                }
            }
            else
            {
                #region Edit Block - Code

                ResetFunc();

                #endregion Edit Block - Code

                lbslno.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
                //MessageBox("Oops ! some error occured !", "Warning");
            }

            ASPxPageControl1.ActiveTabIndex = 0;

            #endregion Edit Block
        }

        protected void GetDhanbarseRetailerStatus(int RetailerID)
        {
            DataTable dtRetailer = new DataTable();
            dtRetailer = jobda.GetRetailerDetails(RetailerID);

            if (dtRetailer.Rows.Count > 0)
            {
                lblRegisterDate.Text = Convert.ToString(dtRetailer.Rows[0]["RegisterDate"]);
                lblApprovalStatus.Text = Convert.ToString(dtRetailer.Rows[0]["ApprovalStatus"]);
                lblApprovalStatuspopup.Text = Convert.ToString(dtRetailer.Rows[0]["ApprovalStatus"]);
                lblCurrentStatuspopup.Text = Convert.ToString(dtRetailer.Rows[0]["CurrentStatus"]);
                lblTotalPoints.Text = Convert.ToString(dtRetailer.Rows[0]["TotalPoints"]);
                lblAvaragePoint.Text = Convert.ToString(dtRetailer.Rows[0]["AvaragePoints"]);
                lblTotalScan.Text = Convert.ToString(dtRetailer.Rows[0]["TotalScan"]);
                lblAvarageScan.Text = Convert.ToString(dtRetailer.Rows[0]["AvarageScan"]);
                lblApprovalDate.Text = Convert.ToString(dtRetailer.Rows[0]["ApprovalDate"]);
            }
            else
            {
                lblRegisterDate.Text = "";
                lblApprovalStatus.Text = "";
                lblTotalPoints.Text = "";
                lblAvaragePoint.Text = "";
                lblTotalScan.Text = "";
                lblAvarageScan.Text = "";
                lblApprovalDate.Text = "";
            }
        }

        /// <summary>
        /// After approve or disapprove action this function reset editmode column
        /// </summary>
        ///
        protected void ResetFunc()
        {
            if (lbslno.Text != "0")
            {
                Data.CheckEdit.CheckEditModel.CheckEditInsert dstreset = new Data.CheckEdit.CheckEditModel.CheckEditInsert();
                dstreset.slno = ValidateDataType.EnsureMaximumLength(lbslno.Text, 100);
                dstreset.TableNm = ValidateDataType.EnsureMaximumLength(TableNm, 100);
                Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
                string resetSts = objselectall.ResetEditStatus(dstreset);
            }
        }

        /// <summary>
        /// Lode the list odf user
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadUserList()
        {
            Core.AssignJob.AssignJob db = new Core.AssignJob.AssignJob();
            DataTable dt = db.AllUsersDACore();
            return dt;
        }

        /// <summary>
        /// User for approv the child
        /// </summary>
        protected void ApprovedSubmit()
        {
            if (lbslno.Text != "0")
            {
                string result = "0";
                string error = string.Empty;
                string approvestatus = string.Empty;
                

                Data.ApproveJob.ApproveJobModel.ApproveProperties ApproveDst = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
                string success = string.Empty;
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    HiddenField hfIsPrintReq = (HiddenField)row.FindControl("hfIsPrintReq");
                    HiddenField hfIsFabReq = (HiddenField)row.FindControl("hfIsFabReq");

                    DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");

                    DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");

                    string PrinterLocation = "";
                    string FabricatorLocation = "";
                    if (!string.IsNullOrEmpty(ddlPrintLocation.SelectedItem.Value))
                    {
                        PrinterLocation = ddlPrintLocation.SelectedItem.Value;
                        //ddlPrintLocation.Items.FindByValue(lblPrinterLocation).Selected = true;
                    }
                    if (!string.IsNullOrEmpty(ddlFabricatorLocation.SelectedItem.Value))
                    {
                        FabricatorLocation = ddlFabricatorLocation.SelectedItem.Value;
                        //ddlFabricatorLocation.Items.FindByValue(lblFabricatorLocation).Selected = true;
                    }
                    string hfImagename = "";
                    string FileNameimg = string.Empty;
                    FileUpload fuPhoto = (FileUpload)row.FindControl("fuPhoto");
                     hfImagename = ((TextBox)row.FindControl("hfnewImagename")).Text;

                    foreach (var file in fuPhoto.PostedFiles)
                    {
                        if (file.FileName != "")
                        {
                            bool rtnVallpost = false;
                            string uploadedFileName = "";
                            string strFileTypeimg = Path.GetExtension(file.FileName).ToLower();
                            string theFileName = string.Empty;
                            string singleFile = string.Empty;
                            decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);


                            if (size <= 20480)
                            {
                                if (strFileTypeimg == ".jpg" || strFileTypeimg == ".jpeg" || strFileTypeimg == ".png")
                                {
                                    SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME3);
                                    if (rtnVallpost)
                                    {

                                        strFileTypeimg = Path.GetExtension(file.FileName).ToLower();
                                        if (FileNameimg == "")
                                        {
                                            FileNameimg = uploadedFileName;
                                        }
                                        else
                                        {
                                            FileNameimg = FileNameimg + ',' + uploadedFileName;
                                        }
                                    }
                                }
                            }


                            else
                            {
                                lblModalTitle.Text = "Warning";
                                lblModalBody.Text = "Sorry, Image size can not be greater then 20MB.";
                                lblModalBody.Attributes.Add("style", "font-size:15px; color:Red; font-weight:lighter;");
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                                upModal.Update();
                            }
                        }

                    }
                    if (lbslno.Text == "0")
                    {
                        FileNameimg = FileNameimg.TrimEnd(',');

                    }
                    else
                    {
                        FileNameimg = FileNameimg.TrimEnd(',') + ',' + hfImagename;

                    }


                    string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
                    string lblwidth = ((Label)row.FindControl("lblwidth")).Text;
                    string hfslnochild = ((HiddenField)row.FindControl("hfslnochild")).Value;
                    CheckBox isapprove = (CheckBox)row.FindControl("chkisapprove");
                    RadioButtonList rdisapprave = (RadioButtonList)row.FindControl("rdisapprave");

                    string a = rdisapprave.SelectedItem.Value;
                    if (a == "1")
                    {
                        approvestatus = "1";
                    }
                    else if (a == "2")
                    {
                        approvestatus = "2";

                        if (txtRemark == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Enter Remark !','error',3);", true);
                            return;
                        }

                    }
                    else if (a == "3")
                    {
                        approvestatus = "3";
                    }

                    if ((!string.IsNullOrEmpty(lblwidth)) && (approvestatus == "1"))
                    {
                        var childsno = HttpUtility.HtmlEncode(hfslnochild);
                        var Remark = HttpUtility.HtmlEncode(txtRemark);
                        var PrintLocation = HttpUtility.HtmlEncode(PrinterLocation);
                        var FabricLocation = HttpUtility.HtmlEncode(FabricatorLocation);
                        if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                        {
                            ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                        }

                        //GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("homebranchid");
                        ApproveDst.moduleid = 37;
                        ApproveDst.slno = Convert.ToInt64(childsno);
                        ApproveDst.tableNm = TableNme;
                        ApproveDst.apdisapremarks = ValidateDataType.EnsureMaximumLength((HttpUtility.HtmlEncode(Remark)), 6000);
                        ApproveDst.apdprinterlocation = Convert.ToInt32(PrintLocation);
                        ApproveDst.apdfabricatorlocation = Convert.ToInt32(FabricLocation);
                        ApproveDst.apdimageName = HttpUtility.HtmlEncode(FileNameimg);
                        ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                        Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                        result = objinsertAssignJob.ApproveJobInsertMethod(ApproveDst);
                        if (result == "-1")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);
                        }
                    }
                    if ((!string.IsNullOrEmpty(lblwidth)) && (approvestatus == "2"))
                    {
                        var childsno = HttpUtility.HtmlEncode(hfslnochild);
                        var Remark = HttpUtility.HtmlEncode(txtRemark);
                        var PrintLocation = HttpUtility.HtmlEncode(PrinterLocation);
                        var FabricLocation = HttpUtility.HtmlEncode(FabricatorLocation);

                        if (!string.IsNullOrWhiteSpace(lblBranchID.Text))
                        {
                            ApproveDst.branchid = Convert.ToInt32(lblBranchID.Text);
                        }

                        //GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("homebranchid");
                        ApproveDst.moduleid = 25;
                        ApproveDst.slno = Convert.ToInt32(childsno);
                        ApproveDst.tableNm = TableNme;
                        ApproveDst.apdisapremarks = ValidateDataType.EnsureMaximumLength((HttpUtility.HtmlEncode(Remark)), 6000);
                        ApproveDst.apdprinterlocation = Convert.ToInt32(PrintLocation);
                        ApproveDst.apdfabricatorlocation = Convert.ToInt32(FabricLocation);
                        ApproveDst.apdimageName = HttpUtility.HtmlEncode(FileNameimg);
                        ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                        Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
                        result = objinsertAssignJob.DisApproveJobInsertMethod(ApproveDst);
                        if (result == "-1")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','DisApproved successfully !','success',3);", true);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any job for approval. !','error',3);", true);
            }

            ResetFunc();
            clean();

        }

        /// <summary>
        /// Used for disapprove the child
        /// </summary>
        //protected void DisApprovedSubmit()
        //{
        //    string result = "0";
        //    string error = string.Empty;
        //    string approvestatus = "0";

        //    Data.ApproveJob.ApproveJobModel.ApproveProperties ApproveDst = new Data.ApproveJob.ApproveJobModel.ApproveProperties();
        //    string success = string.Empty;
        //    foreach (GridViewRow row in gvDetails.Rows)
        //    {
        //        string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
        //        string lblwidth = ((Label)row.FindControl("lblwidth")).Text;
        //        string hfslnochild = ((HiddenField)row.FindControl("hfslnochild")).Value;
        //        CheckBox isapprove = (CheckBox)row.FindControl("chkisapprove");

        //        if (isapprove.Checked == true)
        //        {
        //            approvestatus = "1";
        //        }
        //        if (isapprove.Checked == false)
        //        {
        //            approvestatus = "0";
        //        }

        //        if ((!string.IsNullOrEmpty(lblwidth)) && (approvestatus == "1"))
        //        {
        //            var childsno = HttpUtility.HtmlEncode(hfslnochild);
        //            var Remark = HttpUtility.HtmlEncode(txtRemark);
        //            ApproveDst.branchid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("homebranchid");
        //            ApproveDst.moduleid = 25;
        //            ApproveDst.slno = Convert.ToInt16(childsno);
        //            ApproveDst.tableNm = TableNme;
        //            ApproveDst.apdisapremarks = ValidateDataType.EnsureMaximumLength((HttpUtility.HtmlEncode(Remark)), 6000);

        //            ApproveDst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

        //            Core.ApproveJob.ApproveJob objinsertAssignJob = new Core.ApproveJob.ApproveJob();
        //            result = objinsertAssignJob.DisApproveJobInsertMethod(ApproveDst);
        //            if (result =="-1")
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);

        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Approved successfully !','success',3);", true);

        //            }
        //        }
        //    }

        //    ResetFunc();
        //    clean();
        //}
        /// <summary>
        /// For reset the control.
        /// </summary>
        protected void clean()
        {
            LblRequestNo.Text = string.Empty;
            lblNameType.Text = string.Empty;
            lblName.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblContactPerson.Text = string.Empty;
            lblContact.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblSubFirmName.Text = string.Empty;
            lblSubName.Text = string.Empty;
            lblSubAddress.Text = string.Empty;
            lblSubContact.Text = string.Empty;
            lblGivenBy.Text = string.Empty;
            lblacount.Text = string.Empty;
            hfVisitingImage.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            hfShopPhoto.Text = string.Empty;

            lblSubmittedBy.Text = string.Empty;
            lblApprovedBy.Text = string.Empty;

            lblCinNo.Text = string.Empty;
            lblRegisterDate.Text = string.Empty;
            lblApprovalStatus.Text = string.Empty;
            lblTotalPoints.Text = string.Empty;
            lblAvaragePoint.Text = string.Empty;
            lblTotalScan.Text = string.Empty;
            lblAvarageScan.Text = string.Empty;
            lblApprovalDate.Text = string.Empty;

            dhbretdet.Style.Add("display", "none");

            lbslno.Text = "0";
            gvHead.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
            gvDetails.DataSource = null;
            gvDetails.DataBind();
        }

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Transaction_JobRequestForApproval_{0}", DateTime.Now.ToString());
        }


        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            gvHead.Columns[20].Visible = false;
            gvHead.Columns[26].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {

            gvHead.Columns[20].Visible = true;
            gvHead.Columns[26].Visible = true;
        }

        protected void columnhide2()
        {
            ASPxGridView1.Columns[16].Visible = false;
        }

        protected void columnshow2()
        {
            ASPxGridView1.Columns[16].Visible = true;
        }

        #endregion

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


        protected void btnCsvExport1_Click(object sender, EventArgs e)
        {
            columnhide2();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter2, FileName, true);
            columnshow2();
        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport1_Click(object sender, EventArgs e)
        {
            columnhide2();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter2, FileName, true);
            columnshow2();
        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport1_Click(object sender, EventArgs e)
        {
            columnhide2();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter2, FileName, true);
            columnshow2();
        }


        #endregion

        #region Event

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        /// <summary>
        /// Binds the head grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvHead_DataBinding(object sender, EventArgs e)
        {
            gvHead.DataSource = GetTableHead();
        }

        /// <summary>
        /// Call clean method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            ResetFunc();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        /// <summary>
        /// For view the child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Edit", Convert.ToInt32(lbslno.Text));

            #endregion Edit Block - Code

            checkViewFile();
        }

        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 1);
            this.mpeAll.Show();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 2);
            this.mpeAll.Show();
        }



        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfIsPrintReq = (HiddenField)e.Row.FindControl("hfIsPrintReq");
                HiddenField hfIsFabReq = (HiddenField)e.Row.FindControl("hfIsFabReq");

                Core.JobType.JobType db22 = new Core.JobType.JobType();
                DataTable dtprintloc = db22.GetPrinterLocation();

               


                //ddlPrintLocation.Items.Insert(0, "Select");
                DropDownList ddlPrintLocation = (DropDownList)e.Row.FindControl("ddlPrintLocation");
                ddlPrintLocation.Items.Clear();
                ddlPrintLocation.SelectedValue = null;
                ddlPrintLocation.DataSource = dtprintloc;
                ddlPrintLocation.DataBind();


                DropDownList ddlFabricatorLocation = (DropDownList)e.Row.FindControl("ddlFabricatorLocation");

                Core.JobType.JobType db33 = new Core.JobType.JobType();
                DataTable dtfabloc = db33.GetFabricatorLocation();
                ddlFabricatorLocation.Items.Clear();


                ddlFabricatorLocation.DataSource = dtfabloc;
                ddlFabricatorLocation.DataBind();

                //ddlFabricatorLocation.Items.Insert(0, "Select");

                TextBox hfImagename = (TextBox)e.Row.FindControl("hfImagename");
                LinkButton CmdlnkImage3 = (LinkButton)e.Row.FindControl("CmdlnkImage3");
                if (hfImagename.Text != string.Empty)
                {
                    CmdlnkImage3.Text = "View Files";
                    repType.Value = "3";
                }

                TextBox txtSizeInchHidden = (TextBox)e.Row.FindControl("txtSizeInchHidden");
                Label lblchkisapprov = (Label)e.Row.FindControl("lblchkisapprov");

                string lblPrinterLocation = (e.Row.FindControl("lblPrinterLocation") as TextBox).Text;

                if (!string.IsNullOrEmpty(lblPrinterLocation))
                {
                    //ddlPrintLocation.SelectedItem.Text = lblPrinterLocation;
                    ddlPrintLocation.Items.FindByText(lblPrinterLocation).Selected = true;
                    //ddlPrintLocation.Items.FindByValue(lblPrinterLocation).Selected = true;
                }

                string lblFabricatorLocation = (e.Row.FindControl("lblFabricatorLocation") as TextBox).Text;

                if (!string.IsNullOrEmpty(lblFabricatorLocation))
                {
                    //ddlFabricatorLocation.SelectedItem.Text = lblFabricatorLocation;
                    ddlFabricatorLocation.Items.FindByText(lblFabricatorLocation).Selected = true;
                    //ddlFabricatorLocation.Items.FindByValue(lblFabricatorLocation).Selected = true;
                }
            }
        }

        protected void CmdlnkImage3_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;

            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
                lblImageSlno.Text = FieldTripID.ToString();
            }

            GetUploadedJobRequestFiles(Convert.ToInt64(FieldTripID), 3);
            this.mpeAll.Show();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
            show();
        }

        protected void btnCancelall_Click(object sender, EventArgs e)
        {
        }

        protected void can_Click(object sender, EventArgs e)
        {
            Data.Disapproved.DisApproveJobModel.DisapprovedProperties param1 = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
            param1.slno = Convert.ToInt32(lbslno.Text);
            param1.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
            param1.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Disapproved.Disapproved objdelete = new Core.Disapproved.Disapproved();
            rows = objdelete.DeleteJobRequestHeaddisapprovedCore(param1);
            if (rows == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','JobRequest cancelled Successfull !','success',3);", true);
                clean();
            }
        }

        /// <summary>
        /// For approve theb record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ApprovedSubmit();
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (e.Tab.Index == 1)
            {
                gvHead.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                //txtToDate.Text = DateTime.Now.ToShortDateString();
                //txtFromDate.Text = DateTime.Now.AddDays(-30).ToShortDateString();

                txtToDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txtFromDate.Text = DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy");
                ASPxGridView1.DataBind();
            }
        }

        protected void gvHead_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string VisitingCardImg = e.GetValue("VisitingCardImg").ToString();

            LinkButton hlSubImg = gvHead.FindRowCellTemplateControl(e.VisibleIndex, gvHead.Columns["Visiting Card Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;

            if (VisitingCardImg == "")
            {
                hlSubImg.Visible = false;
            }
        }

        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string VisitingCardImg = e.GetValue("VisitingCardImg").ToString();

            LinkButton hlSubImg = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Visiting Card Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;

            if (VisitingCardImg == "")
            {
                hlSubImg.Visible = false;
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetApprovedJobs();
        }


        protected void lnkShowImg_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblImageSlno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lblImageSlno.Text), 1);
            this.mpeAll.Show();
        }

        protected void lnkShowImg1_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblImageSlno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lblImageSlno.Text), 1);
            this.mpeAll.Show();
        }





        /// <summary>
        /// Show View File Link In the Case Of Update
        /// </summary>
        protected void checkViewFile()
        {
            lnkFiles2.Text = string.Empty;
            if (!string.IsNullOrEmpty(hfVisitingImage.Text))
            {
                lnkFiles2.Text = "View Files";
            }
            lnkFiles3.Text = string.Empty;
            if (!string.IsNullOrEmpty(hfReferSheet.Text))
            {
                lnkFiles3.Text = "View Files";
            }
            lnkFilesShop.Text = string.Empty;
            if (!string.IsNullOrEmpty(hfShopPhoto.Text))
            {
                lnkFilesShop.Text = "View Files";
            }
        }
        #endregion

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
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 1);
                }
                else if (hfPopupImageFlag.Value == "2")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 2);
                }
                else if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblImageSlno.Text), 3);
                }
                else if (hfPopupImageFlag.Value == "15")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 15);
                }
                else if (hfPopupImageFlag.Value == "21")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 21);
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
            else if (hfPopupImageFlag.Value == "15")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "21")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
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

        protected void btnYes_Click(object sender, EventArgs e)
        {
            mpeConfirmPopup.Hide();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            mpeConfirmPopup.Hide();
        }

        protected void rdisapprave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblSubName.Text != "" && popupcount.Value != "1")
            {
                mpeConfirmPopup.Show();
                popupcount.Value = "1";
            }



        }

        protected void lnkFilesShop_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 15);
            this.mpeAll.Show();
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

        protected void lbCDRFile_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 21);
            this.mpeAll.Show();
        }

    }
}