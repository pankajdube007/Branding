using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.Disapproved
{
    public partial class DisapprovedList : System.Web.UI.Page
    {
        #region Page Event
        private const string FILE_DIRECTORY_NAME = "jobrequest/visitingcard";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/refersheet";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/brandimage";


        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        /// <summary>
        /// Lode Job Request head list which contains atleast one disapproved job.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    BindGridview();
                    gvHead.DataBind();
                    ASPxPageControl1.ActiveTabIndex = 1;
                }
            }
        }

        #endregion Page Event

        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        public string party = string.Empty;
        private int rows = 0;
        private string flagImg = string.Empty;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_JobRequestHead";
        private string Node = "Transaction";

        #endregion Edit Block - Variable

        #region Methods

        #region Bind Values


        public DisapprovedList()
        {
            _goldMedia = new GoldMedia();
        }

        /// <summary>
        /// Bind the job type
        /// </summary>
        public void LoadJobType()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable jobdt = db.GetJobTypeAll();

                ddlTypeofJob.Items.Clear();

                ddlTypeofJob.DataSource = jobdt;
                ddlTypeofJob.DataBind();

                ddlTypeofJob.Items.Insert(0, "Select");
            }
        }

        /// <summary>
        /// Bind the design type
        /// </summary>
        public void LoadDesignType()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlDesignType = (DropDownList)row.FindControl("ddlDesignType");

                Core.Design.DesignType db = new Core.Design.DesignType();
                DataTable jobdt = db.GetDesignTypeAll();

                ddlDesignType.DataSource = jobdt;
                ddlDesignType.DataBind();
                ddlDesignType.Items.Insert(0, "Select");
            }
        }

        /// <summary>
        /// Bind the product type
        /// </summary>
        public void LoadProductType()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlProductType = (DropDownList)row.FindControl("ddlProductType");

                Core.ProductType.ProductType db = new Core.ProductType.ProductType();
                DataTable jobdt = db.GetProductTypeAll();

                ddlProductType.DataSource = jobdt;
                ddlProductType.DataBind();

                ddlProductType.Items.Insert(0, "Select");
            }
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

        public void LoadUnit()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable dtunit = db.GetUnits();

                ddlUnit.Items.Clear();

                ddlUnit.DataSource = dtunit;
                ddlUnit.DataBind();

                ddlUnit.Items.Insert(0, "Select");
            }
        }

        #endregion Bind Values

        #region Web Methods

        [System.Web.Services.WebMethod]
        public static string GetBoardType(string jobtype, string jobtypeval)
        {
            string result = string.Empty;

            bool success = int.TryParse(jobtypeval, out int jobtypeid);

            Core.JobTypeMaping.JobTypeMaping db = new Core.JobTypeMaping.JobTypeMaping();

            DataTable dtboardTypes = new DataTable();

            if (success)
            {
                dtboardTypes = db.GetAllBoardTypeForJobType(jobtypeid);

                if (dtboardTypes.Rows.Count > 0)
                {
                    result = @"<select id='ddlBoardType_" + jobtype + "' name ='ddlBoardType_" + jobtype + "' " +
                                       "style='width:110px' class='form-control-grid fntsize' onchange='checkprintandfab(this.id,this)'> " +
                                       "<option value='0'>Select</option>";

                    for (int i = 0; i < dtboardTypes.Rows.Count; i++)
                    {
                        result += @"<option isprintreq='" + dtboardTypes.Rows[i]["IsPrintLocationReq"] + "'  isfabreq = '" + dtboardTypes.Rows[i]["IsFabricatorLocationReq"] + @"'
                                     value ='" + dtboardTypes.Rows[i]["slno"] + "'>" + dtboardTypes.Rows[i]["BoardType"] + "</option>";
                    }
                    result += "</select>";
                }
                else
                {
                    result += "<select style='width:110px' class='form-control-grid'><option value='0'>Select</option></select>";
                }


            }

            return result;
        }

        /// <summary>
        /// Give Sub Job Type On the change of job type
        /// </summary>
        /// <param name="jobtype"></param>
        /// <param name="jobtypeval"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string GetSubJobType(string jobtype, string jobtypeval)
        {
            Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert param = new Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert();
            param.jobtypeid = Convert.ToInt32(jobtypeval);

            Core.JobTypeMaping.JobTypeMaping db = new Core.JobTypeMaping.JobTypeMaping();
            DataTable subjobdt = db.GetAllJobTypeForJobType(param);

            string result = string.Empty;

            if (subjobdt.Rows.Count > 0)
            {
                result = "<select valimage='" + subjobdt.Rows[0]["isimgreq"] + "' valaprove='" + subjobdt.Rows[0]["isaprreq"] + "' id='ddlSubJobType_" + jobtype + "' style='width:220px' class='form-control-grid' onchange='loadsubsubjobdis(this.id)'> <option value='0'>Select</option>";

                for (int i = 0; i < subjobdt.Rows.Count; i++)
                {
                    result += "<option value='" + subjobdt.Rows[i]["subjobtypeid"] + "'>" + subjobdt.Rows[i]["subjobname"] + "</option>";
                }
            }
            //else
            //{
            //    result += "<select style='width:140px' class='form-control-grid'><option value='0'>Select</option></select>";
            //}

            result += "</select>";

            return result;
        }

        /// <summary>
        /// Give Sub Sub Job Type On the change of Sub job type
        /// </summary>
        /// <param name="jobtype"></param>
        /// <param name="jobtypeval"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static string GetSubSubJobType(string subjobtype, string subjobtypeval)
        {
            string result = "<select onchange='fillsubsubjobdis(this.id)' id='ddlSubSubJobType_" + subjobtype + "' name='ddlSubSubJobType_" + subjobtype + "' style='width:330px' class='form-control-grid''> <option value='0'>Select</option>";

            Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert param = new Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert();
            param.subjobtypeid = Convert.ToInt32(subjobtypeval);

            Core.SubJobTypeMaping.SubJobTypeMaping db = new Core.SubJobTypeMaping.SubJobTypeMaping();
            DataTable subsubjobdt = db.GetAllSubSubJobTypeForSubJobType(param);

            if (subsubjobdt.Rows.Count > 0)
            {
                for (int i = 0; i < subsubjobdt.Rows.Count; i++)
                {
                    result += "<option value='" + subsubjobdt.Rows[i]["subsubjobtypeid"] + "'>" + subsubjobdt.Rows[i]["subsubjobname"] + "</option>";
                }
            }
            //else
            //{
            //    result += "<select><option value='0'>Select</option></select>";
            //}

            result += "</select>";
            return result;
        }

        #endregion Web Methods

        #region Private Method

        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        /// <summary>
        /// Check validation For Child
        /// </summary>
        /// <returns></returns>
        private string[] Validation()
        {
            string[] result = new string[2];

            #region Set value for validation On Child

            string FolderName = string.Empty;
            string msg = string.Empty;
            string gvslno = "0";
            foreach (GridViewRow row in gvDetails.Rows)
            {
                if (result[1] == "Please check head validation.!")
                {
                    break;
                }

                if (result[1] == "Please check child validation.!")
                {
                    break;
                }

                string txtTaskID = ((Label)row.FindControl("txtTaskID")).Text;
                string txtSizeInch = ((TextBox)row.FindControl("txtSizeInch")).Text;
                string txtSizeHeight = ((TextBox)row.FindControl("txtSizeHeight")).Text;

                DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");
                string selectedJobType = ddlTypeofJob.SelectedValue;


                //DropDownList ddlSubJobType = (DropDownList)row.FindControl("ddlSubJobType");
                //string selectedsubJobType = ddlSubJobType.SelectedValue;

                //DropDownList dlSubSubJobType = (DropDownList)row.FindControl("dlSubSubJobType");
                //string selectedsubsubJobType = dlSubSubJobType.SelectedValue;

                TextBox hfddlSubJob = (TextBox)row.FindControl("hfddlSubJob");
                string selectedJobSubType = hfddlSubJob.Text;

                TextBox hfddlSubSubJob = (TextBox)row.FindControl("hfddlSubSubJob");
                string selectedMaterial = hfddlSubSubJob.Text;

                DropDownList ddlDesignType = (DropDownList)row.FindControl("ddlDesignType");
                string selectedDesign = ddlDesignType.SelectedValue;

                DropDownList ddlProductType = (DropDownList)row.FindControl("ddlProductType");
                string selectedProduct = ddlProductType.SelectedValue;

                string txtQty = ((TextBox)row.FindControl("txtQty")).Text;
                string txtmail = ((TextBox)row.FindControl("txtmail")).Text;
                CheckBox chkisapprov = (CheckBox)row.FindControl("chkisapprov");

                TextBox lblchkisapprov = (TextBox)row.FindControl("lblchkisapprov");

                string txtInstallAddress = ((TextBox)row.FindControl("txtInstallAddress")).Text;
                string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
                if (lbslno.Text != "0")
                {
                    gvslno = ((HiddenField)row.FindControl("hfslnochild")).Value;
                }

                TextBox hfddlBoardType = (TextBox)row.FindControl("hfddlBoardType");
                string selectedBoardType = hfddlBoardType.Text;

                HiddenField hfIsPrintReq = (HiddenField)row.FindControl("hfIsPrintReq");
                string IsPrintRq = hfIsPrintReq.Value;

                HiddenField hfIsFabReq = (HiddenField)row.FindControl("hfIsFabReq");
                string IsFabReq = hfIsFabReq.Value;


                TextBox isimgreq = (TextBox)row.FindControl("lblimgreq");
                string hfImagename = ((TextBox)row.FindControl("hfImagename")).Text;

                TextBox link = (TextBox)row.FindControl("txtlink");

                DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");
                string Unit = ddlUnit.SelectedValue;

                DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");
                string printlocation = ddlPrintLocation.SelectedValue;

                DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");
                string fablocation = ddlFabricatorLocation.SelectedValue;

                string lblPrinterLocation = (row.FindControl("lblPrinterLocation") as TextBox).Text;
                string lblFabricatorLocation = (row.FindControl("lblFabricatorLocation") as TextBox).Text;

                #endregion Set value for validation On Child

                #region ImageSave

                FileUpload fuPhoto = (FileUpload)row.FindControl("fuPhoto");
                string FileName = string.Empty;
                string strFileType = string.Empty;
                int count = fuPhoto.PostedFiles.Count();
                string imagename = string.Empty;

                foreach (var file in fuPhoto.PostedFiles)
                {
                    if (result[1] == "Please check head validation.!")
                    {
                        break;
                    }
                    //FolderName = "BrandImage";
                    if (file.FileName != string.Empty)
                    {
                        strFileType = Path.GetExtension(file.FileName).ToLower();
                        // string theFileName = string.Empty;
                        string singleFile = string.Empty;
                        decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);

                        if (size <= 20480)
                        {
                            if (strFileType == ".jpg" || strFileType == ".jpeg" || strFileType == ".png")
                            {
                                var time = DateTime.Now;
                                string formattedTime = time.ToString("yyyyMMddhhmmss");
                                singleFile = string.Format(@"{0}{1}", Guid.NewGuid().ToString() + formattedTime, strFileType);
                                imagename += singleFile + ",";
                                // theFileName = Path.Combine(Server.MapPath("~/Upload/JobRequest/"), FolderName, party, singleFile);
                                //file.SaveAs(theFileName);
                                Stream strm = file.InputStream;
                                // GenerateThumbnails(0.5, strm, theFileName);
                                FileName += string.Format(@"{0},", singleFile);
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

                #endregion ImageSave

                #region Check Child validation


                if (selectedBoardType != string.Empty || Unit != "Select" || txtSizeInch != string.Empty || txtSizeHeight != string.Empty || selectedJobType != "Select" || selectedJobSubType != string.Empty || selectedMaterial != string.Empty || selectedDesign != "Select" || selectedProduct != "Select" || txtQty != string.Empty || txtInstallAddress != string.Empty)
                {
                    if (selectedBoardType != string.Empty && Unit != "Select" && txtSizeInch != string.Empty && txtSizeHeight != string.Empty && selectedJobType != "Select" && selectedJobSubType != string.Empty && selectedMaterial != string.Empty && selectedDesign != "Select" && selectedProduct != "Select" && txtQty != string.Empty && txtInstallAddress != string.Empty)
                    {
                        #region insertcase

                        if (isimgreq.Text == "True" && gvslno == "0")
                        {
                            if (imagename != string.Empty)
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                            else if (link.Text != string.Empty)
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                            else
                            {
                                result[0] = "true";
                                result[1] = "Please check child validation.!";
                                break;
                            }
                        }

                        #endregion insertcase

                        #region updatecase

                        if (isimgreq.Text == "True" && gvslno != "0")
                        {
                            if (hfImagename.Trim(',') != string.Empty || imagename != string.Empty)
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                            else if (link.Text != string.Empty)
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                            else
                            {
                                result[0] = "true";
                                result[1] = "Please check child validation.!";
                                break;
                            }
                        }

                        #endregion updatecase

                        #region email valid

                        if (chkisapprov.Checked == true)
                        {
                            if (txtmail != string.Empty)
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                            else
                            {
                                result[0] = "true";
                                result[1] = "Please check child validation.!";
                                break;
                            }
                        }
                        else
                        {
                            result[0] = "false";
                            result[1] = string.Empty;
                        }

                        if (lblchkisapprov.Text == "True")
                        {
                            if (txtmail != string.Empty)
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                            else
                            {
                                result[0] = "true";
                                result[1] = "Please enter approver email!";
                                break;
                            }
                        }
                        else
                        {
                            result[0] = "false";
                            result[1] = string.Empty;
                        }

                        #endregion email valid


                        if (Unit == "Select")
                        {
                            result[0] = "true";
                            result[1] = "Please check child validation.!";
                            break;
                        }

                        if (selectedBoardType == "" || selectedBoardType == "0")
                        {
                            result[0] = "true";
                            result[1] = "Please check child validation.!";
                            break;
                        }

                        if (IsPrintRq == "True" && (printlocation == "Select" || lblPrinterLocation == ""))
                        {
                            result[0] = "true";
                            result[1] = "Please check child validation.!";
                            break;
                        }

                        if (IsFabReq == "True" && (fablocation == "Select" || lblFabricatorLocation == ""))
                        {
                            result[0] = "true";
                            result[1] = "Please check child validation.!";
                            break;
                        }
                    }
                    else
                    {
                        result[0] = "true";
                        result[1] = "Please check child validation!";
                        break;
                    }
                }
            }

            return result;

            #endregion Check Child validation
        }

        /// <summary>
        /// Show Uplode File
        /// </summary>
        protected void checkViewFile()
        {
            lnkFiles2.Text = string.Empty;
            string hfimf = hfVisitingImage.Text.Replace(",", string.Empty);
            if (!string.IsNullOrEmpty(hfimf))
            {
                lnkFiles2.Text = "View Files";
            }

            lnkFiles3.Text = string.Empty;
            string hfimf1 = hfReferSheet.Text.Replace(",", string.Empty);
            if (!string.IsNullOrEmpty(hfimf1))
            {
                lnkFiles3.Text = "View Files";
            }
        }

        /// <summary>
        ///1-Final Delete of child if required using sp.
        ///2-Update and opne the child if checked on the open? option .
        /// </summary>
        private void SaveAsDraft(string JobRequestStatus)
        {
            string s = lbslno.Text;
            int finalresult = 0;
            string FileNameVC = string.Empty;
            string strFileTypeVC = string.Empty;
            string FolderName = string.Empty;
            string msg = string.Empty;
            string gvslno = "0";
            Data.JobRequest.JobRequestModel.JobRequestProperties ds = new JobRequestModel.JobRequestProperties();
            if (Validation()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    #region Unit Binding

                    DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");
                    Core.JobType.JobType dbUnit = new Core.JobType.JobType();
                    DataTable Unitdt = dbUnit.GetUnits();
                    ddlUnit.Items.Clear();
                    ddlUnit.DataSource = Unitdt;
                    ddlUnit.DataBind();
                    ddlUnit.Items.Insert(0, "Select");
                    string lblUnit = (row.FindControl("lblUnit") as TextBox).Text;
                    if (!string.IsNullOrEmpty(lblUnit))
                    {
                        ddlUnit.Items.FindByValue(lblUnit).Selected = true;
                    }
                    else
                    {
                        lblUnit = "0";
                    }

                    #endregion Unit Binding

                    #region Job Type Binding

                    DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");
                    Core.JobType.JobType db = new Core.JobType.JobType();
                    DataTable jobdt = db.GetJobTypeAll();
                    ddlTypeofJob.Items.Clear();
                    ddlTypeofJob.DataSource = jobdt;
                    ddlTypeofJob.DataBind();
                    ddlTypeofJob.Items.Insert(0, "Select");
                    string lblCJobTypeId = (row.FindControl("lblCJobTypeId") as TextBox).Text;
                    if (!string.IsNullOrEmpty(lblCJobTypeId))
                    {
                        ddlTypeofJob.Items.FindByValue(lblCJobTypeId).Selected = true;
                    }
                    else
                    {
                        lblCJobTypeId = "0";
                    }

                    #endregion Job Type Binding

                    #region Sub Job Type Binding

                    string result2 = "<select title='Sub Job Type' onchange='loadsubsubjobedit(this.id)' id='ddlSubJobType_" + ddlTypeofJob.ClientID + "' name ='ddlSubJobType_" + ddlTypeofJob.ClientID + "' style='width:220px' class='form-control-grid'> <option value='0'>Select</option>";
                    Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert param = new Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert();
                    param.jobtypeid = Convert.ToInt32(lblCJobTypeId);
                    Core.JobTypeMaping.JobTypeMaping db3 = new Core.JobTypeMaping.JobTypeMaping();
                    DataTable subjobdt = db3.GetAllJobTypeForJobType(param);
                    string selected = string.Empty;
                    string hfddlSubJob = (row.FindControl("hfddlSubJob") as TextBox).Text;
                    if (string.IsNullOrEmpty(hfddlSubJob))
                    {
                        hfddlSubJob = "0";
                    }
                    if (subjobdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < subjobdt.Rows.Count; i++)
                        {
                            if (hfddlSubJob == subjobdt.Rows[i]["subjobtypeid"].ToString())
                            {
                                selected = "selected";
                            }
                            else { selected = string.Empty; }
                            result2 += "<option " + selected + " value='" + subjobdt.Rows[i]["subjobtypeid"] + "'>" + subjobdt.Rows[i]["subjobname"] + "</option>";
                        }
                    }
                    else
                    {
                        result2 += "<option value='0'>Select</option>";
                    }
                    result2 += "</select>";
                    HtmlGenericControl ddlSubJob = (HtmlGenericControl)row.FindControl("ddlSubJob");
                    ddlSubJob.InnerHtml = result2;

                    #endregion Sub Job Type Binding

                    #region Sub Sub Job Type Binding

                    string result1 = "<select title='Materials used by printer' onchange='fillsubsubjobedit(this.id)' id='ddlSubSubJobType_" + ddlTypeofJob.ClientID + "' name='ddlSubSubJobType_" + ddlTypeofJob.ClientID + "' style='width:330px' class='form-control-grid''> <option value='0'>Select</option>";
                    Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert param1 = new Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert();
                    param1.subjobtypeid = Convert.ToInt32(hfddlSubJob);
                    Core.SubJobTypeMaping.SubJobTypeMaping db4 = new Core.SubJobTypeMaping.SubJobTypeMaping();
                    DataTable subsubjobdt = db4.GetAllSubSubJobTypeForSubJobType(param1);
                    string hfddlSubSubJob = (row.FindControl("hfddlSubSubJob") as TextBox).Text;
                    if (string.IsNullOrEmpty(hfddlSubJob))
                    {
                        hfddlSubSubJob = "0";
                    }
                    if (subsubjobdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < subsubjobdt.Rows.Count; i++)
                        {
                            if (hfddlSubSubJob == subsubjobdt.Rows[i]["subsubjobtypeid"].ToString())
                            {
                                selected = "selected";
                            }
                            else { selected = string.Empty; }
                            result1 += "<option " + selected + " value='" + subsubjobdt.Rows[i]["subsubjobtypeid"] + "'>" + subsubjobdt.Rows[i]["subsubjobname"] + "</option>";
                        }
                    }
                    else
                    {
                        result1 += "<option value='0'>Select</option>";
                    }
                    result1 += "</select>";
                    HtmlGenericControl ddlSubSubJob = (HtmlGenericControl)row.FindControl("ddlSubSubJob");
                    ddlSubSubJob.InnerHtml = result1;

                    #endregion Sub Sub Job Type Binding

                    #region Board Type Binding

                    HiddenField hfIsPrintReq = (HiddenField)row.FindControl("hfIsPrintReq");
                    HiddenField hfIsFabReq = (HiddenField)row.FindControl("hfIsFabReq");

                    DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");


                    Core.JobType.JobType db22 = new Core.JobType.JobType();
                    DataTable dtprintloc = db22.GetPrinterLocation();

                    ddlPrintLocation.Items.Clear();
                    ddlPrintLocation.DataSource = dtprintloc;
                    ddlPrintLocation.DataBind();
                    ddlPrintLocation.Items.Insert(0, "Select");

                    DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");

                    Core.JobType.JobType db33 = new Core.JobType.JobType();
                    DataTable dtfabloc = db33.GetFabricatorLocation();

                    ddlFabricatorLocation.Items.Clear();
                    ddlFabricatorLocation.DataSource = dtfabloc;
                    ddlFabricatorLocation.DataBind();
                    ddlFabricatorLocation.Items.Insert(0, "Select");


                    string boardtypes = "<select title='Board Type' onchange='checkprintandfabedit(this.id,this)' id='ddlBoardType_" + ddlTypeofJob.ClientID + "' name ='ddlBoardType_" + ddlTypeofJob.ClientID + "' style='width:110px' class='form-control-grid'> <option value='0'>Select</option>";

                    Core.JobTypeMaping.JobTypeMaping objBoard = new Core.JobTypeMaping.JobTypeMaping();
                    DataTable dtboardTypes = objBoard.GetAllBoardTypeForJobType(Convert.ToInt32(lblCJobTypeId));


                    string boardselected = string.Empty;
                    string hfddlBoardType = (row.FindControl("hfddlBoardType") as TextBox).Text;

                    if (string.IsNullOrEmpty(hfddlBoardType))
                    {
                        hfddlBoardType = "0";
                    }

                    if (dtboardTypes.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtboardTypes.Rows.Count; i++)
                        {
                            if (hfddlBoardType == dtboardTypes.Rows[i]["slno"].ToString())
                            {
                                boardselected = "selected";

                                if (dtboardTypes.Rows[i]["IsPrintLocationReq"].ToString() == "False")
                                {
                                    hfIsPrintReq.Value = "False";
                                    ddlPrintLocation.Enabled = false;
                                    ddlPrintLocation.Style.Add("background-color", "#e8e8e8");
                                }
                                else
                                {
                                    hfIsPrintReq.Value = "True";
                                    ddlPrintLocation.Enabled = true;
                                    ddlPrintLocation.Style.Add("background-color", "#fff");
                                }

                                if (dtboardTypes.Rows[i]["IsFabricatorLocationReq"].ToString() == "False")
                                {
                                    hfIsFabReq.Value = "False";
                                    ddlFabricatorLocation.Enabled = false;
                                    ddlFabricatorLocation.Style.Add("background-color", "#e8e8e8");
                                }
                                else
                                {
                                    hfIsFabReq.Value = "True";
                                    ddlFabricatorLocation.Enabled = true;
                                    ddlFabricatorLocation.Style.Add("background-color", "#fff");
                                }

                            }
                            else
                            {
                                boardselected = string.Empty;
                            }



                            boardtypes += "<option isprintreq='" + dtboardTypes.Rows[i]["IsPrintLocationReq"] + "'  isfabreq = '" + dtboardTypes.Rows[i]["IsFabricatorLocationReq"] + "' " + boardselected + " value='" + dtboardTypes.Rows[i]["slno"] + "'>" + dtboardTypes.Rows[i]["BoardType"] + "</option>";
                        }
                    }
                    else
                    {
                        boardtypes += "<option value='0'>Select</option>";
                    }

                    boardtypes += "</select>";

                    HtmlGenericControl ddlBoardType = (HtmlGenericControl)row.FindControl("ddlBoardType");

                    ddlBoardType.InnerHtml = boardtypes;

                    #endregion Board Type Binding


                    string lblPrinterLocation = (row.FindControl("lblPrinterLocation") as TextBox).Text;

                    if (!string.IsNullOrEmpty(lblPrinterLocation))
                    {
                        ddlPrintLocation.Items.FindByValue(lblPrinterLocation).Selected = true;
                    }

                    string lblFabricatorLocation = (row.FindControl("lblFabricatorLocation") as TextBox).Text;

                    if (!string.IsNullOrEmpty(lblFabricatorLocation))
                    {
                        ddlFabricatorLocation.Items.FindByValue(lblFabricatorLocation).Selected = true;
                    }
                }
            }
            else
            {
                #region Insert Child

                Data.Disapproved.DisApproveJobModel.DisapprovedProperties Childdst = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    string txtTaskID = ((Label)row.FindControl("txtTaskID")).Text;
                    string txtSizeInch = ((TextBox)row.FindControl("txtSizeInch")).Text;
                    string txtSizeHeight = ((TextBox)row.FindControl("txtSizeHeight")).Text;
                    DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");
                    string selectedJobType = ddlTypeofJob.SelectedValue;
                    DropDownList DropDownList1 = (DropDownList)row.FindControl("DropDownList1");
                    string approveto = DropDownList1.SelectedValue;
                    TextBox hfddlSubJob = (TextBox)row.FindControl("hfddlSubJob");
                    string selectedJobSubType = hfddlSubJob.Text;
                    TextBox hfddlSubSubJob = (TextBox)row.FindControl("hfddlSubSubJob");
                    HiddenField hfcancel = (HiddenField)row.FindControl("hfcancel");
                    string selectedMaterial = hfddlSubSubJob.Text;
                    DropDownList ddlDesignType = (DropDownList)row.FindControl("ddlDesignType");
                    string selectedDesign = ddlDesignType.SelectedValue;
                    DropDownList ddlProductType = (DropDownList)row.FindControl("ddlProductType");
                    string selectedProduct = ddlProductType.SelectedValue;
                    string txtQty = ((TextBox)row.FindControl("txtQty")).Text;
                    string txtmail = ((TextBox)row.FindControl("txtmail")).Text;
                    string txtInstallAddress = ((TextBox)row.FindControl("txtInstallAddress")).Text;
                    string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
                    string txtlink = ((TextBox)row.FindControl("txtlink")).Text;
                    if (lbslno.Text != "0")
                    {
                        gvslno = ((HiddenField)row.FindControl("hfslnochild")).Value;
                    }
                    TextBox chkisapprov = ((TextBox)row.FindControl("lblchkisapprov"));
                    bool approved = Convert.ToBoolean(chkisapprov.Text);
                    //CheckBox chkisapprov = ((CheckBox)row.FindControl("chkisapprov"));
                    //bool approved = false;
                    //if (chkisapprov.Checked)
                    //{
                    //    approved = true;
                    //}
                    CheckBox chkopen = ((CheckBox)row.FindControl("chkopen"));
                    bool openeded = false;
                    if (chkopen.Checked)
                    {
                        openeded = true;
                    }

                    #region ImageSave

                    FileUpload fuPhoto = (FileUpload)row.FindControl("fuPhoto");


                    string FileNameimg = string.Empty;

                    foreach (var file in fuPhoto.PostedFiles)
                    {

                        if (file.FileName != string.Empty)
                        {
                            bool rtnVallpost = false;
                            string strFileTypeimg = Path.GetExtension(file.FileName).ToLower();
                            string theFileName = string.Empty;
                            string uploadedFileName = "";
                            string singleFile = string.Empty;
                            decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);

                            if (size <= 20480)
                            {
                                if (strFileTypeimg == ".jpg" || strFileTypeimg == ".jpeg" || strFileTypeimg == ".png")
                                {

                                    SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME2);
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

                    #endregion ImageSave

                    DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");
                    string sizeUnit = ddlUnit.SelectedValue;

                    DropDownList ddlPriority = (DropDownList)row.FindControl("ddlPriority");
                    int priority = Convert.ToInt16(ddlPriority.SelectedValue);

                    TextBox hfddlBoardType = (TextBox)row.FindControl("hfddlBoardType");
                    string selectedBoardType = hfddlBoardType.Text;


                    DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");
                    int printlocation = 0;

                    DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");
                    int fabricatorlocation = 0;

                    HiddenField hfIsPrintReq = (HiddenField)row.FindControl("hfIsPrintReq");
                    HiddenField hfIsFabReq = (HiddenField)row.FindControl("hfIsFabReq");

                    string lblPrinterLocation = (row.FindControl("lblPrinterLocation") as TextBox).Text;
                    string lblFabricatorLocation = (row.FindControl("lblFabricatorLocation") as TextBox).Text;


                    if (hfIsPrintReq.Value == "True")
                    {
                        if (ddlPrintLocation.SelectedValue != "Select" && lblPrinterLocation != "")
                        {
                            printlocation = Convert.ToInt16(lblPrinterLocation);
                        }
                        else
                        {
                            printlocation = 0;
                        }
                    }

                    if (hfIsFabReq.Value == "True")
                    {
                        if (ddlFabricatorLocation.SelectedValue != "Select" && lblFabricatorLocation != "")
                        {
                            fabricatorlocation = Convert.ToInt16(lblFabricatorLocation);
                        }
                        else
                        {
                            fabricatorlocation = 0;
                        }
                    }

                    string hfImagename = ((TextBox)row.FindControl("hfImagename")).Text;
                    if (sizeUnit != "0" && txtSizeInch != string.Empty && txtSizeHeight != string.Empty && selectedJobType != string.Empty && selectedJobSubType != string.Empty && selectedMaterial != string.Empty && selectedDesign != string.Empty && selectedProduct != string.Empty && txtQty != string.Empty && txtInstallAddress != string.Empty)
                    {
                        string TaskID = HttpUtility.HtmlEncode(txtTaskID);
                        decimal SizeInch = Convert.ToDecimal(HttpUtility.HtmlEncode(txtSizeInch));
                        decimal SizeHeight = Convert.ToDecimal(HttpUtility.HtmlEncode(txtSizeHeight));
                        string JobType = HttpUtility.HtmlEncode(selectedJobType);
                        string JobSubType = HttpUtility.HtmlEncode(selectedJobSubType);
                        string Material = HttpUtility.HtmlEncode(selectedMaterial);
                        string sendemail = HttpUtility.HtmlEncode(txtmail);
                        string Design = HttpUtility.HtmlEncode(selectedDesign);
                        string Product = HttpUtility.HtmlEncode(selectedProduct);
                        string Qty = HttpUtility.HtmlEncode(txtQty);
                        string Address = HttpUtility.HtmlEncode(txtInstallAddress);
                        string Remark = HttpUtility.HtmlEncode(txtRemark);
                        string isapprov = HttpUtility.HtmlEncode(chkisapprov);
                        string isstatus = HttpUtility.HtmlEncode(openeded);
                        string emailtoapr = HttpUtility.HtmlEncode(approveto);
                        string ImageName = HttpUtility.HtmlEncode(FileNameimg + ',' + hfImagename);
                        string Link = HttpUtility.HtmlEncode(txtlink);
                        string slnochild = gvslno;
                        bool DeleteFlag = false;
                        string hfimg = ((TextBox)row.FindControl("hfImagenameDelete")).Text;
                        string slno = lbslno.Text;
                        deleteFiles(hfimg, slno, slnochild);

                        string Unit = HttpUtility.HtmlEncode(sizeUnit);

                        string BoardType = HttpUtility.HtmlEncode(selectedBoardType);


                        Childdst.BoardTypeID = Convert.ToInt16(BoardType);
                        Childdst.PrintLocation = Convert.ToInt16(printlocation);
                        Childdst.FabricatorLocation = Convert.ToInt16(fabricatorlocation);
                        Childdst.Priority = Convert.ToInt16(priority);
                        Childdst.UnitID = Convert.ToInt16(Unit);



                        Childdst.TaskId = Convert.ToInt16(TaskID);
                        Childdst.Height = Convert.ToInt16(SizeHeight);
                        Childdst.approvalmail = sendemail;

                        Childdst.Width = Convert.ToInt16(SizeInch);
                        Childdst.JobTypeId = Convert.ToInt16(JobType);
                        Childdst.SubJobTypeId = Convert.ToInt16(JobSubType);
                        Childdst.SubSubJobTypeId = Convert.ToInt16(Material);
                        Childdst.DesignTypeId = Convert.ToInt16(Design);
                        Childdst.ProductTypeId = Convert.ToInt16(Product);
                        Childdst.approvto = emailtoapr;
                        Childdst.Qty = Convert.ToInt16(Qty);
                        Childdst.Remark = Remark;
                        Childdst.NeedApproval = approved;
                        Childdst.status = openeded.ToString();
                        Childdst.ImageName = ImageName;
                        Childdst.installaddress = Address;
                        Childdst.childstatus = Convert.ToInt16(JobRequestStatus);
                        Childdst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        Childdst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Childdst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                        Childdst.pagename = HttpContext.Current.Request.Url.ToString();
                        Childdst.refid = slno;
                        Childdst.slno = Convert.ToInt32(slnochild);
                        Childdst.DeleteFlag = DeleteFlag;
                        Childdst.Link = Link;
                        Core.Disapproved.Disapproved objinsertChild = new Core.Disapproved.Disapproved();
                        finalresult = objinsertChild.UpdateDisapprovedJobRequestChildDACore(Childdst);
                    }
                }

                #endregion Insert Child

                if (finalresult == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job request updated successfully !','success',3);", true);
                    ResetFunc();
                    clean();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured !','warning',3);", true);
                    ResetFunc();
                    clean();
                }
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
        /// Delete the uploded files.
        /// </summary>
        /// <param name="hfimg"></param>
        /// <param name="slno"></param>
        /// <param name="slnochild"></param>
        protected void deleteFiles(string hfimg, string slno, string slnochild)
        {
            foreach (var item in hfimg)
            {
                hfimg = hfimg.Replace(",", string.Empty);
                string theFileName1 = string.Empty;
                int flag = 0;

                string hfImgIName = item.ToString();

                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/JobRequest/VisitingCard/"), hfimg)))
                {
                    theFileName1 = Path.Combine(Server.MapPath("~/Upload/JobRequest/VisitingCard"), hfimg);
                    flag = 1;
                }

                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/JobRequest/ReferSheet"), hfimg)))
                {
                    theFileName1 = Path.Combine(Server.MapPath("~/Upload/JobRequest/ReferSheet"), hfimg);
                    flag = 2;
                }

                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/JobRequest/BrandImage"), hfimg)))
                {
                    theFileName1 = Path.Combine(Server.MapPath("~/Upload/JobRequest/BrandImage"), hfimg);
                    flag = 3;
                }

                if (File.Exists(theFileName1))
                {
                    File.Delete(theFileName1);
                }

                JobRequestDataAccess objselectall = new JobRequestDataAccess();

                Data.JobRequest.JobRequestModel.JobRequestProperties dtssingle = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                dtssingle.slno = Convert.ToInt32(slno);
                dtssingle.VisitingCardImg = hfimg;
                dtssingle.flag = flag;

                Core.JobRequest.JobRequest objsselectsingle = new Core.JobRequest.JobRequest();
                rows = objsselectsingle.DeleteJobRequestFilesDACore(dtssingle);

                if (rows > 0)
                {
                    GetUploadedJobRequestFiles(Convert.ToInt32(slnochild), flag);
                }
            }
        }

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Transaction_DisapproveList_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            gvHead.Columns[11].Visible = false;
            gvHead.Columns[12].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            gvHead.Columns[11].Visible = true;
            gvHead.Columns[12].Visible = true;
        }

        /// <summary>
        /// Used in delete and edit action for tarcking data is editable,deletable or not
        /// </summary>
        ///
        protected void CheckEditBlock(string param, int id)
        {
            string str = string.Empty;
            overwriteStr = string.Empty;
            string overtime = string.Empty, maxtime = string.Empty;
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
            dst.usercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
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

                        Data.Disapproved.DisApproveJobModel.DisapprovedProperties param1 = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
                        param1.slno = Convert.ToInt32(lbslno.Text);
                        param1.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        param1.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                        Core.Disapproved.Disapproved objdelete = new Core.Disapproved.Disapproved();
                        rows = objdelete.DeleteJobRequestHeaddisapprovedCore(param1);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull !','success',3);", true);
                            gvHead.DataBind();
                        }
                        if (rows == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Something Wrong !','error',3);", true);
                            gvHead.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit !','warning',3);", true);
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
            }
        }

        /// <summary>
        /// show all the heads which comntains at least one dis approved child
        /// </summary>
        /// <returns></returns>
        private DataTable GetTableHead()
        {
            Data.Disapproved.DisApproveJobModel.DisapprovedProperties param = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Disapproved.Disapproved objdata = new Core.Disapproved.Disapproved();
            //DataTable dt = objdata.AllDisapproveJobRequestHeadForApproveDACore();
            DataTable dtbranch = objdata.AllDisapproveJobRequestHeadBranchForApproveDACore(param);
            return dtbranch;
        }

        private DataTable GetTableHead2()
        {
            Data.Disapproved.DisApproveJobModel.DisapprovedProperties param = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Disapproved.Disapproved objdata = new Core.Disapproved.Disapproved();
            //DataTable dt = objdata.AllDisapproveJobRequestHeadForApproveDACore();
            DataTable dtbranch = objdata.AllDisapproveJobRequestHeadBranchForApproveOldDACore(param);
            return dtbranch;
        }


        /// <summary>
        /// Bind child grid view
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
                ImageLink = string.Empty,
                isplacesize = "False",
                NeedApproval = "False",
            };
            List<DummyGrid> list = new List<DummyGrid>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(test1);
            }

            gvDetails.DataSource = list;
            gvDetails.DataBind();

            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + gvDetails.ClientID + "', 400, 1840 , 30 ,true); </script>", false);

            LoadJobType();
            LoadPrintLocation();
            LoadFabricatorLocation();
            LoadUnit();

            LoadDesignType();
            LoadProductType();
        }

        /// <summary>
        /// Reset after the edit or delete
        /// </summary>
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

        public static DataTable IsEditable(int slno, string TableNm, string uid, string ucat, string PageNm)
        {
            string overtime = string.Empty, maxtime = string.Empty, check = string.Empty;
            overtime = "40";
            maxtime = "20";
            check = "Yes";

            DataTable dt = new DataTable();

            JobRequestDataAccess objselectall = new JobRequestDataAccess();

            if (check == "Yes")
            {
                // dt = objselectall.CheckEditStatusJR(slno, TableNm, Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(uid)))), ucat, PageNm, Convert.ToInt32(overtime), Convert.ToInt32(maxtime), check);
            }
            else
            {
                dt.Columns.Add("PStatus");
                dt.Columns.Add("showpopup");
                dt.Columns.Add("viewoverwrite");

                DataRow dr = dt.NewRow();

                dr["PStatus"] = "Unchecked";
                dr["showpopup"] = "No";
                dr["viewoverwrite"] = "No";
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// For filling values in child and head during the update.
        /// </summary>
        protected void show()
        {
            #region Edit Block

            Data.Disapproved.DisApproveJobModel.DisapprovedProperties paramHead = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
            paramHead.slno = Convert.ToInt32(lbslno.Text);

            Core.Disapproved.Disapproved objdataHead = new Core.Disapproved.Disapproved();
            DataTable dtHead = objdataHead.DisapprovedJobRequestHeadSelectParticularCore(paramHead);

            if (dtHead.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dtHead.Rows[0]["reqno"]);
                lblNameType.Text = Convert.ToString(dtHead.Rows[0]["NameType"]);
                lblName.Text = Convert.ToString(dtHead.Rows[0]["AllName"]);
                lblAddress.Text = Convert.ToString(dtHead.Rows[0]["AllAddress"]);
                lblContact.Text = Convert.ToString(dtHead.Rows[0]["contactnumber"]);
                lblContactPerson.Text = Convert.ToString(dtHead.Rows[0]["ContactPerson"]);
                lblEmail.Text = Convert.ToString(dtHead.Rows[0]["Email"]);
                lblDate.Text = Convert.ToString(dtHead.Rows[0]["RequestDate"]);
                lblSubName.Text = Convert.ToString(dtHead.Rows[0]["subname"]);
                lblSubAddress.Text = Convert.ToString(dtHead.Rows[0]["SubAddress"]);
                lblSubContact.Text = Convert.ToString(dtHead.Rows[0]["SubContact"]);
                lblGivenBy.Text = Convert.ToString(dtHead.Rows[0]["GivenByName"]);
                lblsubemail.Text = Convert.ToString(dtHead.Rows[0]["subemail"]);
                lblsubmitby.Text = Convert.ToString(dtHead.Rows[0]["submittedby"]);
                lblapproveby.Text = Convert.ToString(dtHead.Rows[0]["approvedby"]);
                lbslno.Text = Convert.ToString(dtHead.Rows[0]["slno"]);
                hfVisitingImage.Text = Convert.ToString(dtHead.Rows[0]["VisitingCardImg"]);
                hfReferSheet.Text = Convert.ToString(dtHead.Rows[0]["ReferSheet"]);
                Core.Disapproved.Disapproved objdataChild = new Core.Disapproved.Disapproved();
                DataTable dtChild = objdataChild.DisapprovedJobRequestChildSelectParticularCore(paramHead);

                for (int i = dtChild.Rows.Count + 1; i <= dtChild.Rows.Count; i++)
                {
                    DataRow row = dtChild.NewRow();
                    row["slno"] = 0;
                    dtChild.Rows.Add(row);
                }

                gvDetails.DataSource = dtChild;
                gvDetails.DataBind();

                //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + gvDetails.ClientID + "', 400, 1840 , 30 ,true); </script>", false);

                LblRequestNo.Focus();
            }
            else
            {
                #region Edit Block - Code

                ResetFunc();

                #endregion Edit Block - Code

                lbslno.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
            }

            ASPxPageControl1.ActiveTabIndex = 0;

            #endregion Edit Block
        }

        public static string ResetEditStatus(int slno, string TableNm)
        {
            //JobRequestDataAccess objselectall = new JobRequestDataAccess();
            string overtime = string.Empty, maxtime = string.Empty, check = string.Empty, sts = string.Empty;

            //if (check == "Yes")
            //{
            //    sts = objselectall.ResetPageEditStatusJR(Convert.ToInt32(slno), TableNm).ToString();
            //    //sts = g.reterive_val("exec ResetPageEditStatus " + slno + ",'" + TableNm + "'");
            //}

            return sts;
        }

        protected void GetUploadedJobRequestFiles(int slno, int flag)
        {
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties(); ;
            param.slno = Convert.ToInt32(slno);
            param.flag = flag;
            Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            DataTable dtResult = objData.JobRequestChildFilesDACore(param);
            if (flag == 1)
            {
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

            if (flag == 2)
            {
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
            else
            {
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                    HiddenField hfslnochild = (HiddenField)row.FindControl("hfslnochild");
                    if (slno == Convert.ToInt32(hfslnochild.Value))
                    {
                        if (dtResult.Rows.Count > 0 && !string.IsNullOrEmpty(hfImagename.Text))
                        {
                            rptImages2.DataSource = dtResult;
                            rptImages2.DataBind();
                            hdNoRecord2.Visible = false;
                        }
                        else
                        {
                            rptImages2.DataSource = null;
                            rptImages2.DataBind();
                            hdNoRecord2.Visible = true;
                        }
                    }
                }
            }
        }

        protected void getrequestno()
        {
            var isstate = string.Empty;
            var comman = string.Empty;
            var year = DateTime.Now.Year;
            var mon = DateTime.Now.Month;
            if (mon < 4)
            {
                comman = (((Convert.ToInt32(year) - 1).ToString()) + '-' + ((Convert.ToInt32(year)).ToString())).ToString();
            }
            else
            {
                comman = (((Convert.ToInt32(year)).ToString()) + '-' + ((Convert.ToInt32(year) + 1).ToString())).ToString();
            }
            if (ConfigurationManager.AppSettings["state"].ToString() == "true")
            {
                isstate = "1";
            }
            else
            {
                isstate = "0";
            }
            Data.JobRequest.JobRequestModel.getrequest getrequest = new Data.JobRequest.JobRequestModel.getrequest();
            getrequest.comman = comman;
            getrequest.isstate = Convert.ToInt16(isstate);
            getrequest.stateid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("stateid");
            Core.JobRequest.JobRequest objdataHead = new Core.JobRequest.JobRequest();
            DataTable dtreqno = objdataHead.ReqnoCore(getrequest);
            if (dtreqno.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dtreqno.Rows[0]["reqno"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','SomeThingWrong.','error',2);", true);
            }
        }

        /// <summary>
        /// Clean Head values
        /// </summary>
        protected void clean()
        {
            lbslno.Text = "0";
            hfReferSheetDelete.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            hfVisitingImageDelete.Text = string.Empty;
            hfVisitingImage.Text = string.Empty;

            foreach (GridViewRow row in gvDetails.Rows)
            {
                TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                TextBox hfImagenameDelete = (TextBox)row.FindControl("hfImagenameDelete");

                hfImagename.Text = string.Empty;
                hfImagenameDelete.Text = string.Empty;
            }

            cleanChild(0);

            ASPxPageControl1.ActiveTabIndex = 1;
            gvHead.DataBind();
        }

        /// <summary>
        /// Clean child values
        /// </summary>
        protected void cleanChild(int rowid)
        {
            checkViewFile();
            foreach (GridViewRow row in gvDetails.Rows)
            {
                TextBox txtSizeInch = (TextBox)row.FindControl("txtSizeInch");
                TextBox txtSizeHeight = (TextBox)row.FindControl("txtSizeHeight");
                TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");
                TextBox hfddlSubJob = (TextBox)row.FindControl("hfddlSubJob");
                TextBox hfddlSubSubJob = (TextBox)row.FindControl("hfddlSubSubJob");
                DropDownList ddlDesignType = (DropDownList)row.FindControl("ddlDesignType");
                DropDownList ddlProductType = (DropDownList)row.FindControl("ddlProductType");
                TextBox txtQty = ((TextBox)row.FindControl("txtQty"));
                TextBox txtInstallAddress = ((TextBox)row.FindControl("txtInstallAddress"));
                TextBox txtRemark = ((TextBox)row.FindControl("txtRemark"));
                CheckBox chkisapprov = ((CheckBox)row.FindControl("chkisapprov"));
                CheckBox chkopen = ((CheckBox)row.FindControl("chkopen"));
                HiddenField hfslnochild = (HiddenField)row.FindControl("hfslnochild");
                HiddenField hfcancel = (HiddenField)row.FindControl("hfcancel");

                DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");
                TextBox lblUnit = (TextBox)row.FindControl("lblUnit");

                DropDownList ddlPriority = (DropDownList)row.FindControl("ddlPriority");
                Label lblPriority = (Label)row.FindControl("lblPriority");

                TextBox hfddlBoardType = (TextBox)row.FindControl("hfddlBoardType");

                HiddenField hfIsPrintReq = (HiddenField)row.FindControl("hfIsPrintReq");
                HiddenField hfIsFabReq = (HiddenField)row.FindControl("hfIsFabReq");
                DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");
                TextBox lblPrinterLocation = (TextBox)row.FindControl("lblPrinterLocation");
                DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");
                TextBox lblFabricatorLocation = (TextBox)row.FindControl("lblFabricatorLocation");


                if (Convert.ToInt32(rowid) == Convert.ToInt32(hfslnochild.Value))
                {
                    txtSizeInch.Enabled = false;

                    txtSizeHeight.Enabled = false;

                    txtQty.Enabled = false;

                    txtInstallAddress.Enabled = false;
                    txtRemark.Enabled = false;

                    hfImagename.Enabled = false;
                    chkisapprov.Enabled = false;
                    ddlTypeofJob.Enabled = false;
                    hfddlSubJob.Enabled = false;
                    hfddlSubSubJob.Enabled = false;
                    ddlDesignType.Enabled = false;
                    ddlProductType.Enabled = false;
                    hfslnochild.Value = "0";
                    hfcancel.Value = "1";

                    //chkopen.Checked = true;
                    chkopen.Enabled = false;

                    ddlUnit.Enabled = false;
                    lblUnit.Enabled = false;

                    ddlPriority.Enabled = false;
                    lblPriority.Enabled = false;

                    hfddlBoardType.Enabled = false;

                    ddlPrintLocation.Enabled = false;
                    lblPrinterLocation.Enabled = false;
                    ddlFabricatorLocation.Enabled = false;
                    lblFabricatorLocation.Enabled = false;
                }
                else if (Convert.ToInt32(rowid) == 0)
                {
                    txtSizeInch.Enabled = false;

                    txtSizeHeight.Enabled = false;

                    txtQty.Enabled = false;

                    txtInstallAddress.Enabled = false;
                    txtRemark.Enabled = false;

                    hfImagename.Enabled = false;
                    chkisapprov.Enabled = false;
                    ddlTypeofJob.Enabled = false;
                    hfddlSubJob.Enabled = false;
                    hfddlSubSubJob.Enabled = false;
                    ddlDesignType.Enabled = false;
                    ddlProductType.Enabled = false;
                    hfslnochild.Value = "0";
                    hfcancel.Value = "1";
                    //chkopen.Checked = true;
                    chkopen.Enabled = false;

                    hfIsPrintReq.Value = string.Empty;
                    hfIsFabReq.Value = string.Empty;

                    ddlUnit.Enabled = false;
                    lblUnit.Enabled = false;

                    ddlPriority.Enabled = false;
                    lblPriority.Enabled = false;

                    hfddlBoardType.Enabled = false;

                    ddlPrintLocation.Enabled = false;
                    lblPrinterLocation.Enabled = false;
                    ddlFabricatorLocation.Enabled = false;
                    lblFabricatorLocation.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Cretae grid for child
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
            public string apdisapremarks { get; set; }

            public string isplacesize { get; set; }
            public string NeedApproval { get; set; }
            public string Width { get; set; }
            public string approvalto { get; set; }
            public string approvalemail { get; set; }

            public string Height { get; set; }
            public string JobTypeId { get; set; }
            public string SubJobTypeId { get; set; }
            public string SubSubJobTypeId { get; set; }
            public string DesignTypeId { get; set; }
            public string ProductTypeId { get; set; }
            public string Image { get; set; }
            public string ChildStatus { get; set; }

            public string ImageLink { get; set; }
        }

        #endregion Private Method

        #endregion Methods

        #region Events

        /// <summary>
        /// Used After Edir and delete task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
            show();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //job type
                DropDownList ddlTypeofJob = (DropDownList)e.Row.FindControl("ddlTypeofJob");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable jobdt = db.GetJobTypeAll();

                ddlTypeofJob.Items.Clear();

                ddlTypeofJob.DataSource = jobdt;
                ddlTypeofJob.DataBind();

                ddlTypeofJob.Items.Insert(0, "Select");

                string lblCJobTypeId = (e.Row.FindControl("lblCJobTypeId") as TextBox).Text;

                if (!string.IsNullOrEmpty(lblCJobTypeId))
                {
                    ddlTypeofJob.Items.FindByValue(lblCJobTypeId).Selected = true;
                }
                else
                {
                    lblCJobTypeId = "0";
                }


                //Unit
                DropDownList ddlUnit = (DropDownList)e.Row.FindControl("ddlUnit");

                Core.JobType.JobType dbunit = new Core.JobType.JobType();
                DataTable Unitdt = dbunit.GetUnits();

                ddlUnit.Items.Clear();

                ddlUnit.DataSource = Unitdt;
                ddlUnit.DataBind();

                ddlUnit.Items.Insert(0, "Select");

                string lblUnit = (e.Row.FindControl("lblUnit") as TextBox).Text;

                if (lblUnit != "0")
                {
                    if (!string.IsNullOrEmpty(lblUnit))
                    {
                        ddlUnit.Items.FindByValue(lblUnit).Selected = true;
                    }
                    else
                    {
                        lblUnit = "0";
                    }
                }





                //Board Type

                HiddenField hfIsPrintReq = (HiddenField)e.Row.FindControl("hfIsPrintReq");
                HiddenField hfIsFabReq = (HiddenField)e.Row.FindControl("hfIsFabReq");

                DropDownList ddlPrintLocation = (DropDownList)e.Row.FindControl("ddlPrintLocation");


                Core.JobType.JobType db22 = new Core.JobType.JobType();
                DataTable dtprintloc = db22.GetPrinterLocation();

                ddlPrintLocation.Items.Clear();

                ddlPrintLocation.DataSource = dtprintloc;
                ddlPrintLocation.DataBind();

                ddlPrintLocation.Items.Insert(0, "Select");

                DropDownList ddlFabricatorLocation = (DropDownList)e.Row.FindControl("ddlFabricatorLocation");

                Core.JobType.JobType db33 = new Core.JobType.JobType();
                DataTable dtfabloc = db33.GetFabricatorLocation();

                ddlFabricatorLocation.Items.Clear();

                ddlFabricatorLocation.DataSource = dtfabloc;
                ddlFabricatorLocation.DataBind();

                ddlFabricatorLocation.Items.Insert(0, "Select");


                string boardtypes = "<select title='Board type' onchange='checkprintandfabedit(this.id,this)' id='ddlBoardType_" + ddlTypeofJob.ClientID + "' name ='ddlBoardType_" + ddlTypeofJob.ClientID + "' style='width:110px' class='form-control-grid'> <option value='0'>Select</option>";

                Core.JobTypeMaping.JobTypeMaping objBoard = new Core.JobTypeMaping.JobTypeMaping();
                DataTable dtboardTypes = objBoard.GetAllBoardTypeForJobType(Convert.ToInt32(lblCJobTypeId));


                string boardselected = string.Empty;
                string hfddlBoardType = (e.Row.FindControl("hfddlBoardType") as TextBox).Text;

                if (string.IsNullOrEmpty(hfddlBoardType))
                {
                    hfddlBoardType = "0";
                }

                if (dtboardTypes.Rows.Count > 0)
                {
                    for (int i = 0; i < dtboardTypes.Rows.Count; i++)
                    {
                        if (hfddlBoardType == dtboardTypes.Rows[i]["slno"].ToString())
                        {
                            boardselected = "selected";

                            if (dtboardTypes.Rows[i]["IsPrintLocationReq"].ToString() == "False")
                            {
                                hfIsPrintReq.Value = "False";
                                ddlPrintLocation.Enabled = false;
                                ddlPrintLocation.Style.Add("background-color", "#e8e8e8");
                            }
                            else
                            {
                                hfIsPrintReq.Value = "True";
                                ddlPrintLocation.Enabled = true;
                                ddlPrintLocation.Style.Add("background-color", "#fff");
                            }

                            if (dtboardTypes.Rows[i]["IsFabricatorLocationReq"].ToString() == "False")
                            {
                                hfIsFabReq.Value = "False";
                                ddlFabricatorLocation.Enabled = false;
                                ddlFabricatorLocation.Style.Add("background-color", "#e8e8e8");
                            }
                            else
                            {
                                hfIsFabReq.Value = "True";
                                ddlFabricatorLocation.Enabled = true;
                                ddlFabricatorLocation.Style.Add("background-color", "#fff");
                            }

                        }
                        else
                        {
                            boardselected = string.Empty;
                        }

                        boardtypes += "<option isprintreq='" + dtboardTypes.Rows[i]["IsPrintLocationReq"] + "'  isfabreq = '" + dtboardTypes.Rows[i]["IsFabricatorLocationReq"] + "' " + boardselected + " value='" + dtboardTypes.Rows[i]["slno"] + "'>" + dtboardTypes.Rows[i]["BoardType"] + "</option>";
                    }
                }
                else
                {
                    boardtypes += "<option value='0'>Select</option>";
                }

                boardtypes += "</select>";

                HtmlGenericControl ddlBoardType = (HtmlGenericControl)e.Row.FindControl("ddlBoardType");

                ddlBoardType.InnerHtml = boardtypes;

                //sub job type
                string result = "<select title='Sub Job Type' onchange='loadsubsubjobedit(this.id)' id='ddlSubJobType_" + ddlTypeofJob.ClientID + "' name ='ddlSubJobType_" + ddlTypeofJob.ClientID + "' style='width:220px' class='form-control-grid'> <option value='0'>Select</option>";

                Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert param = new Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert();
                param.jobtypeid = Convert.ToInt32(lblCJobTypeId);

                Core.JobTypeMaping.JobTypeMaping db3 = new Core.JobTypeMaping.JobTypeMaping();
                DataTable subjobdt = db3.GetAllJobTypeForJobType(param);

                string selected = string.Empty;
                string hfddlSubJob = (e.Row.FindControl("hfddlSubJob") as TextBox).Text;

                if (string.IsNullOrEmpty(hfddlSubJob))
                {
                    hfddlSubJob = "0";
                }

                if (subjobdt.Rows.Count > 0)
                {
                    for (int i = 0; i < subjobdt.Rows.Count; i++)
                    {
                        if (hfddlSubJob == subjobdt.Rows[i]["subjobtypeid"].ToString())
                        {
                            selected = "selected";
                        }
                        else { selected = string.Empty; }
                        result += "<option " + selected + " value='" + subjobdt.Rows[i]["subjobtypeid"] + "'>" + subjobdt.Rows[i]["subjobname"] + "</option>";
                    }
                }
                else
                {
                    result += "<option value='0'>Select</option>";
                }

                result += "</select>";

                HtmlGenericControl ddlSubJob = (HtmlGenericControl)e.Row.FindControl("ddlSubJob");

                ddlSubJob.InnerHtml = result;

                //sub sub job type
                string result1 = "<select title='Materials used by printer' onchange='fillsubsubjobedit(this.id)' id='ddlSubSubJobType_" + ddlTypeofJob.ClientID + "' name='ddlSubSubJobType_" + ddlTypeofJob.ClientID + "' style='width:330px' class='form-control-grid''> <option value='0'>Select</option>";

                Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert param1 = new Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert();
                param1.subjobtypeid = Convert.ToInt32(hfddlSubJob);

                Core.SubJobTypeMaping.SubJobTypeMaping db4 = new Core.SubJobTypeMaping.SubJobTypeMaping();
                DataTable subsubjobdt = db4.GetAllSubSubJobTypeForSubJobType(param1);

                string hfddlSubSubJob = (e.Row.FindControl("hfddlSubSubJob") as TextBox).Text;

                if (string.IsNullOrEmpty(hfddlSubJob))
                {
                    hfddlSubSubJob = "0";
                }

                if (subsubjobdt.Rows.Count > 0)
                {
                    for (int i = 0; i < subsubjobdt.Rows.Count; i++)
                    {
                        if (hfddlSubSubJob == subsubjobdt.Rows[i]["subsubjobtypeid"].ToString())
                        {
                            selected = "selected";
                        }
                        else { selected = string.Empty; }
                        result1 += "<option " + selected + " value='" + subsubjobdt.Rows[i]["subsubjobtypeid"] + "'>" + subsubjobdt.Rows[i]["subsubjobname"] + "</option>";
                    }
                }
                else
                {
                    result1 += "<option value='0'>Select</option>";
                }

                result1 += "</select>";

                HtmlGenericControl ddlSubSubJob = (HtmlGenericControl)e.Row.FindControl("ddlSubSubJob");

                ddlSubSubJob.InnerHtml = result1;

                //design type
                DropDownList ddlDesignType = (DropDownList)e.Row.FindControl("ddlDesignType");

                Core.Design.DesignType db1 = new Core.Design.DesignType();
                DataTable jobdt1 = db1.GetDesignTypeAll();

                ddlDesignType.DataSource = jobdt1;
                ddlDesignType.DataBind();
                ddlDesignType.Items.Insert(0, "Select");

                string lblDesignType = (e.Row.FindControl("lblDesignType") as Label).Text;

                if (!string.IsNullOrEmpty(lblDesignType))
                {
                    ddlDesignType.Items.FindByValue(lblDesignType).Selected = true;
                }

                //product type
                DropDownList ddlProductType = (DropDownList)e.Row.FindControl("ddlProductType");
                DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("DropDownList1");

                Core.ProductType.ProductType db2 = new Core.ProductType.ProductType();
                DataTable jobdt2 = db2.GetProductTypeAll();

                ddlProductType.DataSource = jobdt2;
                ddlProductType.DataBind();

                ddlProductType.Items.Insert(0, "Select");

                string lblProductType = (e.Row.FindControl("lblProductType") as Label).Text;

                if (!string.IsNullOrEmpty(lblProductType))
                {
                    ddlProductType.Items.FindByValue(lblProductType).Selected = true;
                }
                string lblPartyApprovalTo = (e.Row.FindControl("lblPartyApprovalTo") as Label).Text;

                if (!string.IsNullOrEmpty(lblPartyApprovalTo))
                {
                    DropDownList1.Items.FindByValue(lblPartyApprovalTo).Selected = true;
                }


                //DropDownList ddlUnit = (DropDownList)e.Row.FindControl("ddlUnit");
                //string lblUnit = (e.Row.FindControl("lblUnit") as Label).Text;

                //if (!string.IsNullOrEmpty(lblUnit))
                //{
                //    ddlUnit.Items.FindByValue(lblUnit).Selected = true;
                //}

                DropDownList ddlPriority = (DropDownList)e.Row.FindControl("ddlPriority");
                string lblPriority = (e.Row.FindControl("lblPriority") as Label).Text;

                if (!string.IsNullOrEmpty(lblPriority))
                {
                    ddlPriority.Items.FindByValue(lblPriority).Selected = true;
                }



                string lblPrinterLocation = (e.Row.FindControl("lblPrinterLocation") as TextBox).Text;

                if (!string.IsNullOrEmpty(lblPrinterLocation))
                {
                    ddlPrintLocation.Items.FindByValue(lblPrinterLocation).Selected = true;
                }


                string lblFabricatorLocation = (e.Row.FindControl("lblFabricatorLocation") as TextBox).Text;

                if (!string.IsNullOrEmpty(lblFabricatorLocation))
                {
                    ddlFabricatorLocation.Items.FindByValue(lblFabricatorLocation).Selected = true;
                }


                //fill checkboxes
                CheckBox chkisapprov = (CheckBox)e.Row.FindControl("chkisapprov");
                TextBox lblchkisapprov = (TextBox)e.Row.FindControl("lblchkisapprov");

                if (lblchkisapprov.Text == "False" || string.IsNullOrEmpty(lblchkisapprov.Text))
                {
                    chkisapprov.Checked = false;
                }
                else
                {
                    chkisapprov.Checked = true;
                }
                HiddenField hfslnochild = (HiddenField)e.Row.FindControl("hfslnochild");
                TextBox txtmail = (TextBox)e.Row.FindControl("txtmail");

                Data.JobRequest.JobRequestModel.JobRequestProperties chldde = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                chldde.childslno = Convert.ToInt32(hfslnochild.Value);
                Core.JobRequest.JobRequest objdataHead = new Core.JobRequest.JobRequest();
                DataTable dtHead = objdataHead.JobRequestChildOnlyCore(chldde);
                if (dtHead.Rows.Count > 0)
                {
                    TextBox isimgreq = (TextBox)e.Row.FindControl("lblimgreq");
                    isimgreq.Text = Convert.ToString(dtHead.Rows[0]["imgreq"]);
                    TextBox lblaprreq = (TextBox)e.Row.FindControl("lblaprreq");
                    lblaprreq.Text = Convert.ToString(dtHead.Rows[0]["aprreq"]);
                    if (lblaprreq.Text == "True")
                    {
                        chkisapprov.Checked = true;
                        chkisapprov.Enabled = false;
                        DropDownList1.Enabled = true;
                        txtmail.Enabled = true;
                    }
                    else
                    {
                        if (chkisapprov.Checked == true)
                        {
                            DropDownList1.Enabled = true;
                            txtmail.Enabled = true;
                        }
                    }
                }
                //fill image
                TextBox hfImagename = (TextBox)e.Row.FindControl("hfImagename");
                LinkButton CmdlnkImage3 = (LinkButton)e.Row.FindControl("CmdlnkImage3");
                // TextBox isimgreq = (TextBox)e.Row.FindControl("lblimgreq");
                string hfimg = hfImagename.Text.Replace(",", string.Empty);
                if (hfimg == string.Empty)
                {
                    CmdlnkImage3.Text = string.Empty;
                }
                else
                {
                    CmdlnkImage3.Text = "View Files";
                    //  isimgreq.Text = "True";
                }
                repType.Value = "3";
            }
        }

        protected void gvHead_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            ResetFunc();
            clean();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        /// <summary>
        /// Used for cancel all child for particular  job request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdDelete_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Delete", FieldTripID);

            #endregion Edit Block - Code
        }

        /// <summary>
        /// Used for delete single child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdDeleteChild_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
                Data.Disapproved.DisApproveJobModel.DisapprovedProperties param1 = new Data.Disapproved.DisApproveJobModel.DisapprovedProperties();
                //child srno
                param1.slno = Convert.ToInt32(FieldTripID);
                //head slno
                param1.refid = lbslno.Text;
                param1.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                param1.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                Core.Disapproved.Disapproved objdelete = new Core.Disapproved.Disapproved();
                rows = objdelete.DeleteDisapprovedJobRequestChildCore(param1);
                if (rows == 1)
                {
                    cleanChild(Convert.ToInt32(e.CommandArgument.ToString()));
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull!','success',3);", true);
                    ResetFunc();
                }
                else if (rows == -1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Some Error Occured!','warning',3);", true);
                    ResetFunc();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit !','warning',3);", true);
                    ResetFunc();
                }
            }
        }

        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Edit", Convert.ToInt32(lbslno.Text));

            #endregion Edit Block - Code

            checkViewFile();
        }

        public static string UpdateEditStatus(int slno, string TableNm, string adminid, string usercat, string pageNm)
        {
            string sts = string.Empty;

            //sts = g.reterive_val("exec UpdatePageEditStatus " + slno + ",'" + TableNm + "'," + adminid + ",'" + usercat + "','" + pageNm + "'");

            return sts;
        }

        protected void CmdlnkImage1_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            GetUploadedJobRequestFiles(FieldTripID, 1);
            this.mpeImage.Show();
        }

        protected void CmdlnkImage2_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            GetUploadedJobRequestFiles(FieldTripID, 2);
            this.mpeImage.Show();
        }

        protected void CmdlnkImage3_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
                lbslnochildid.Text = FieldTripID.ToString();
            }
            GetUploadedJobRequestFiles(FieldTripID, 3);
            this.mpeImage2.Show();
        }



        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 1);
            this.mpeImage.Show();
            repType.Value = "1";
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 2);
            this.mpeImage1.Show();
            repType.Value = "2";
        }

        protected void btnCloseMPE_Click1(object sender, EventArgs e)
        {
            if (repType.Value == "1")
            {
                string hfimf = hfVisitingImage.Text;
                if (!string.IsNullOrEmpty(hfimf.Replace(",", string.Empty)))
                {
                    lnkFiles2.Text = "View Files";
                }
                else
                {
                    lnkFiles2.Text = string.Empty;
                }
            }
            else if (repType.Value == "2")
            {
                string hfimf = hfReferSheet.Text;
                if (!string.IsNullOrEmpty(hfimf.Replace(",", string.Empty)))
                {
                    lnkFiles3.Text = "View Files";
                }
                else
                {
                    lnkFiles3.Text = string.Empty;
                }
            }
            else
            {
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    TextBox hfImagename = (TextBox)row.FindControl("hfImagename");

                    LinkButton CmdlnkImage3 = (LinkButton)row.FindControl("CmdlnkImage3");
                    string hfimf = hfImagename.Text;
                    if (!string.IsNullOrEmpty(hfimf.Replace(",", string.Empty)))
                    {
                        CmdlnkImage3.Text = "View Files";
                    }
                    else
                    {
                        CmdlnkImage3.Text = string.Empty;
                    }
                }
            }
            checkViewFile();
            this.mpeImage.Hide();
        }

        /// <summary>
        /// Work for action of cancel and update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdSaveAsDraft_Click(object sender, EventArgs e)
        {
            SaveAsDraft("1");
        }

        /// <summary>
        /// Load grid of job request head
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvHead_DataBinding(object sender, EventArgs e)
        {
            gvHead.DataSource = GetTableHead();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTableHead2();
        }



        #endregion Events

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

        #endregion Export


        #region Export

        /// <summary>
        /// Used for export the grid in csv format
        /// </summary>
        protected void btnCsvExport1_Click(object sender, EventArgs e)
        {
            //columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter2, FileName, true);
            //columnshow();
        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport1_Click(object sender, EventArgs e)
        {
            //columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter2, FileName, true);
            //columnshow();
        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport1_Click(object sender, EventArgs e)
        {
            //columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter2, FileName, true);
            //columnshow();
        }

        #endregion Export

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
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 1);
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

            imgDocs.ImageUrl = PictureIDPath;
            hyLink.NavigateUrl = PictureIDPath;
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
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 2);
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

        }


        protected void rptImages2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");

            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslnochildid.Text), 3);
            }
        }
        protected void rptImages2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME2, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME2, hfImgIName.Value);
            imgDocs.ImageUrl = PictureIDPath;
            hyLink.NavigateUrl = PictureIDPath;
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

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (e.Tab.Index == 1)
            {
                gvHead.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                ASPxGridView1.DataBind();
            }
        }

    }
}