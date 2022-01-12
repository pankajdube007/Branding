using DevExpress.Web;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using GoldMedal.Branding.Data.DesignSubmit;


namespace GoldMedal.Branding.Admin.Transaction.DesignSubmit
{
    public partial class DesignSubmit : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private DataTable dts = new DataTable();
        private DataTable dtss = new DataTable();
        private string strFileTypeVC = string.Empty;
        private string FolderName = "SubmitImage";
        private string FileNameVC = string.Empty;
        private string FileNameup = string.Empty;
        public string party = string.Empty;
        private double Cnt;
        private int result = 0;
        private int result2 = 0;
        private int result3 = 0;
        private int errorresulr = 0;

        private const string FILE_DIRECTORY_NAME1 = "jobrequest/visitingcard";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/refersheet";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME4 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME5 = "jobrequest/shopphoto";
        private const string FILE_DIRECTORY_NAME13 = "jobrequest/cdrfile";

        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

        DesignSubmitDataAccess da = new DesignSubmitDataAccess();

        #endregion Initialization
        #region Page Event
        /// <summary>
        /// Lode the item combo and the grid whic contains the list of child whic are assigned and the list of submitdesign.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            Session.Timeout = 7200;
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    ViewState["_SizePageID"] = (new Random()).Next().ToString();
                    LoadItemDivision();
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
            }
            createSessionData();
            createSizeSessionData();
        }
        public DesignSubmit()
        {
            _goldMedia = new GoldMedia();
            finYear = "17-18";
        }
        #endregion Page Event
        #region Private Methods


        protected void SaveUploadedFile()
        {
            string strFileType = "";
            string fname = "";
            foreach (var file in fuPhoto.PostedFiles)
            {
                if (file.FileName != "")
                {
                    fname = file.FileName;
                    bool rtnVallpost = false;
                    string uploadedFileName = "";

                    SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME1);
                    if (rtnVallpost)
                    {

                        strFileType = Path.GetExtension(file.FileName).ToLower();
                        if (FileNameup == "")
                        {
                            FileNameup = uploadedFileName;
                        }
                        else
                        {
                            FileNameup = FileNameup + ',' + uploadedFileName;
                        }
                    }
                }
            }

            if (fname != "")
            {
                if (lbslno.Text == "0")
                {
                    FileNameup = FileNameup.TrimEnd(',');
                }
                else
                {
                    if (hfReferSheet.Text != "")
                    {
                        FileNameup = FileNameup.TrimEnd(',') + ',' + hfReferSheet.Text;

                        if (FileNameup.Contains(",,"))
                        {
                            FileNameup.Replace(",,", "");
                        }
                    }
                }
                ViewState["FileNameupl"] = fname;
            }
        }

        /// <summary>
        /// List Of Assinged jobs for the user.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt4 = objselectall.GetAssignedJobForUserAll(dsp);
            return dt4;
        }
        /// <summary>
        /// List Of  submited Jobs by the user.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dsp = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dsp.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt5 = objselectall.GetAllDesignSubmitByUser(dsp);
            return dt5;
        }
        /// <summary>
        /// fill all the control for the submit design.
        /// </summary>
        protected void show()
        {
            Session[ViewState["_PageID"].ToString() + "Scheme"] = null;
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectsingle = new Core.DesignSubmit.DesignSubmit();
            DataTable dt = objselectsingle.GetAssignedJobForUserSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                ImgLink.Text= Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl= Convert.ToString(dt.Rows[0]["ImageLink"]);
                lnkFiles2.Visible = true;
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["RequestDate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["nametype"]);
                lblName.Text = Convert.ToString(dt.Rows[0]["name"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["address"]);
                lblContact.Text = Convert.ToString(dt.Rows[0]["contactnumber"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["contactperson"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["email"]);
                lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                lblSubAddress.Text = Convert.ToString(dt.Rows[0]["subaddress"]);
                lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                lblismailsnd.Text = Convert.ToString(dt.Rows[0]["NeedApproval"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                lblAprrovalRemark.Text = Convert.ToString(dt.Rows[0]["AprrovalRemark"]);

                if (Convert.ToString(dt.Rows[0]["isplacesize"]) == "False")
                {
                    ////rdsizetype.SelectedValue = "0";
                    ////btnaddsize.Enabled = false;
                    ////txtboardhight.Enabled = false;
                    ////txtboardwidth.Enabled = false;
                    ////txtprintheight.Enabled = false;
                    ////txtprintwidth.Enabled = false;
                    ////txtpheight.Enabled = true;
                    ////txtpwidth.Enabled = true;


                    txtbheight.Enabled = false;
                    txtbwidth.Enabled = false;
                    
                    txtbheight.Text = Convert.ToString(dt.Rows[0]["height"]);
                    txtbwidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                }
                else
                {
                    ////rdsizetype.SelectedValue = "1";
                    ////btnaddsize.Enabled = true;
                    ////txtboardhight.Enabled = true;
                    ////txtboardwidth.Enabled = true;
                    ////txtprintheight.Enabled = true;
                    ////txtprintwidth.Enabled = true;
                    ////txtpheight.Enabled = false;
                    ////txtpwidth.Enabled = false;

                    txtbheight.Enabled = false;
                    txtbwidth.Enabled = false;
                    
                    txtbwidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                    txtbheight.Text = Convert.ToString(dt.Rows[0]["height"]);
                }
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                subjobtype.Text = Convert.ToString(dt.Rows[0]["subjobtype"]);
               
                subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjobtype"]);
                designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["jobrequestchildid"]);
                lblHeadSlno.Text = Convert.ToString(dt.Rows[0]["HeadSlno"]);
                LoadProductType();
                cmbProductType.Text = Convert.ToString(dt.Rows[0]["producttype"]);


                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);

                lblPlaceSize.Text = Convert.ToString(dt.Rows[0]["isplacesize"]) == "False" ? "No" : "Yes";
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);
                lblPartyRemarks.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);
                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                    lbVisitingCardImg.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                    lbReferSheetImg.Visible = true;
                }

                

                //ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                //ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);

            }
            ASPxPageControl1.ActiveTabIndex = 0;
        }
        /// <summary>
        /// fill all the control for the edit the submited design.
        /// </summary>
        protected void show2()
        {
            Session[ViewState["_PageID"].ToString() + "Scheme"] = null;
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dtsingle.slno = Convert.ToInt32(lbldslno.Text);
            Core.DesignSubmit.DesignSubmit objselectsingle = new Core.DesignSubmit.DesignSubmit();
            DataTable dt = objselectsingle.GetDetailOfDesignSubmitByUser(dtsingle);
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
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                subjobtype.Text = Convert.ToString(dt.Rows[0]["subjob"]);
                lblsizetype.Text = Convert.ToString(dt.Rows[0]["sizetype"]);
                subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjob"]);
                lblismailsnd.Text = Convert.ToString(dt.Rows[0]["NeedApproval"]);
                designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                LoadProductType();
                cmbProductType.Text = Convert.ToString(dt.Rows[0]["product"]);
                hfReferSheet.Text = Convert.ToString(dt.Rows[0]["submitimage"]);
                txttotalamt.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["jobrequestchildid"]);
                lblHeadSlno.Text = Convert.ToString(dt.Rows[0]["HeadSlno"]);
                lblrefid.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
                lbslno.Text = Convert.ToString(dt.Rows[0]["assignslno"]);
                ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);
                txtLink.Text = Convert.ToString(dt.Rows[0]["designlink"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                txtremark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);

                lblAprrovalRemark.Text = Convert.ToString(dt.Rows[0]["AprrovalRemark"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);


                if (Convert.ToString(dt.Rows[0]["status"]) == "Approved 2")
                {
                    btnSubmit.Visible = false;
                    btnadditem.Visible = false;
                }
                
               else if (Convert.ToString(dt.Rows[0]["status"]) == "Open" && Convert.ToString(dt.Rows[0]["statuss"]) == "View")  
                {
                    
                        btnSubmit.Visible = false;
                        btnadditem.Visible = false;
                   
                }
                else
                {
                    btnSubmit.Visible = true;
                    btnadditem.Visible = true;
                }

                if (lblsizetype.Text == "0")
                {
                    //rdsizetype.SelectedValue = "0";
                    //btnaddsize.Enabled = false;
                    //txtboardhight.Enabled = false;
                    //txtboardwidth.Enabled = false;
                    //txtprintheight.Enabled = false;
                    //txtprintwidth.Enabled = false;
                    //txtpheight.Enabled = true;
                    //txtpwidth.Enabled = true;
                    //txtpheight.Text = Convert.ToString(dt.Rows[0]["ph"]);
                    //txtpwidth.Text = Convert.ToString(dt.Rows[0]["pw"]);

                    txtbheight.Enabled = false;
                    txtbwidth.Enabled = false;
                    //txtbheight.Text = Convert.ToString(dt.Rows[0]["bh"]);
                    //txtbwidth.Text = Convert.ToString(dt.Rows[0]["bw"]);

                    if (dt.Rows[0]["OldHeight"].ToString() == "" && dt.Rows[0]["OldWidth"].ToString() == "")
                    {
                        txtbheight.Text = Convert.ToString(dt.Rows[0]["height"]);
                        txtbwidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                        txtNewHeight.Text = string.Empty;
                        txtNewWidth.Text = string.Empty;
                    }
                    else
                    {
                        txtbheight.Text = Convert.ToString(dt.Rows[0]["OldHeight"]);
                        txtbwidth.Text = Convert.ToString(dt.Rows[0]["OldWidth"]);
                        txtNewHeight.Text = Convert.ToString(dt.Rows[0]["height"]);
                        txtNewWidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                    }
                }
                else
                {
                    loadsizechild();
                    ////rdsizetype.SelectedValue = "1";
                    ////btnaddsize.Enabled = true;
                    ////txtboardhight.Enabled = true;
                    ////txtboardwidth.Enabled = true;
                    ////txtprintheight.Enabled = true;
                    ////txtprintwidth.Enabled = true;
                    ////txtpheight.Enabled = false;
                    ////txtpwidth.Enabled = false;

                    txtbheight.Enabled = false;
                    txtbwidth.Enabled = false;

                    if (dt.Rows[0]["OldHeight"].ToString() == "" && dt.Rows[0]["OldWidth"].ToString() == "")
                    {
                        txtbheight.Text = Convert.ToString(dt.Rows[0]["height"]);
                        txtbwidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                        txtNewHeight.Text = string.Empty;
                        txtNewWidth.Text = string.Empty;
                    }
                    else
                    {
                        txtbheight.Text = Convert.ToString(dt.Rows[0]["OldHeight"]);
                        txtbwidth.Text = Convert.ToString(dt.Rows[0]["OldWidth"]);
                        txtNewHeight.Text = Convert.ToString(dt.Rows[0]["height"]);
                        txtNewWidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                    }
                }

                lblPlaceSize.Text = Convert.ToString(dt.Rows[0]["isplacesize"]) == "False" ? "No" : "Yes";
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                    lbVisitingCardImg.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                    lbReferSheetImg.Visible = true;
                }
            }
            loadchild();
            ASPxPageControl1.ActiveTabIndex = 0;
        }
        /// <summary>
        /// Fill The Product Combo.
        /// </summary>
        public void LoadProductType()
        {
            Core.ProductType.ProductType db = new Core.ProductType.ProductType();
            DataTable jobdt = db.GetProductTypeAll();
            cmbProductType.Items.Clear();
            cmbProductType.Value = null;
            cmbProductType.DataSource = jobdt;
            cmbProductType.TextField = "name";
            cmbProductType.ValueField = "slno";
            cmbProductType.SelectedIndex = 0;
            cmbProductType.DataBind();
        }

        public void LoadItemDivision()
        {
            Core.DesignSubmit.DesignSubmit db = new Core.DesignSubmit.DesignSubmit();
            DataTable itdt = db.GetItemDivisonAll();
            cmbItemDivision.Items.Clear();
            cmbItemDivision.Value = null;
            cmbItemDivision.DataSource = itdt;
            cmbItemDivision.TextField = "divisionnm";
            cmbItemDivision.ValueField = "slno";
            cmbItemDivision.DataBind();
            cmbItemDivision.SelectedIndex = -1;
        }

        protected void cmbItemDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemDivision.SelectedItem != null)
            {
                LoadItemType(Convert.ToInt32(cmbItemDivision.SelectedItem.Value));
            }
        }

        /// <summary>
        /// Fill the item Combo
        /// </summary>
        public void LoadItemType(int divisionid)
        {
            Core.DesignSubmit.DesignSubmit db = new Core.DesignSubmit.DesignSubmit();
            DataTable itdt = db.GetItemTypeAll(divisionid);
            CmbItem.Items.Clear();
            CmbItem.Value = null;
            CmbItem.DataSource = itdt;
            CmbItem.TextField = "name";
            CmbItem.ValueField = "slno";
            CmbItem.SelectedIndex = 0;
            CmbItem.DataBind();
            CmbItem.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Gv For the Item
        /// </summary>
        protected void bindgvSchemeChild()
        {
            gvSchemeChild.DataSource = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
            gvSchemeChild.DataBind();
        }
        /// <summary>
        /// Bind Gv For the Size
        /// </summary>
        ///
        protected void bindgvSizeChild()
        {
            gvSizeChild.DataSource = (DataTable)Session[ViewState["_SizePageID"].ToString() + "Size"];
            gvSizeChild.DataBind();
        }
        /// <summary>
        /// Create The Session for the item
        /// </summary>
        protected void createSessionData()
        {
            if (Session[ViewState["_PageID"].ToString() + "Scheme"] != null)
            {
                dtss = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
            }
            else
            {
                dtss = new DataTable();
                DataColumn pk = dtss.Columns.Add("Slno", typeof(System.Int32));
                pk.AllowDBNull = false;
                pk.Unique = true;
                pk.AutoIncrement = true;
                pk.AutoIncrementSeed = 1;
                pk.AutoIncrementStep = 1;
                dtss.Columns.Add("childslno", typeof(System.Int32));
                dtss.Columns.Add("Itemid", typeof(System.Int32));
                dtss.Columns.Add("Item", typeof(System.String));
                dtss.Columns.Add("MRP", typeof(System.Decimal));
                dtss.Columns.Add("Discount", typeof(System.Decimal));
                dtss.Columns.Add("Qty", typeof(System.Int32));
                dtss.Columns.Add("Amount", typeof(System.Decimal));
            }
        }
        /// <summary>
        /// create the session for the size
        /// </summary>
        protected void createSizeSessionData()
        {
            if (Session[ViewState["_SizePageID"].ToString() + "Size"] != null)
            {
                dts = (DataTable)Session[ViewState["_SizePageID"].ToString() + "Size"];
            }
            else
            {
                dts = new DataTable();
                DataColumn pk = dts.Columns.Add("Slno", typeof(System.Int32));
                pk.AllowDBNull = false;
                pk.Unique = true;
                pk.AutoIncrement = true;
                pk.AutoIncrementSeed = 1;
                pk.AutoIncrementStep = 1;
                dts.Columns.Add("SizeSlno", typeof(System.Int32));
                dts.Columns.Add("BoardHeight", typeof(System.Decimal));
                dts.Columns.Add("BoardWidth", typeof(System.Decimal));
                dts.Columns.Add("PrintHeight", typeof(System.Decimal));
                dts.Columns.Add("PrintWidth", typeof(System.Decimal));
            }
        }
        /// <summary>
        /// for the caluction  for item.
        /// </summary>
        private void calulation()
        {
            if (!string.IsNullOrEmpty(txtqty.Text))
            {
                txtDiscount.Text = (Convert.ToDecimal(txtmrp.Text) / 2).ToString();
                txtamt.Text = ((Convert.ToDecimal(txtmrp.Text) - Convert.ToDecimal(txtDiscount.Text)) * (Convert.ToInt32(txtqty.Text))).ToString();
            }
        }
        /// <summary>
        /// Clean the records during the item add in gridview
        /// </summary>
        private void clean()
        {
            CmbItem.SelectedIndex = -1;
            txtamt.Text = "0";
            txtDiscount.Text = "0";
            txtmrp.Text = "0";
            txtqty.Text = "0";
        }
        /// <summary>
        /// Clean the records during the size add in gridview
        /// </summary>
        private void cleansize()
        {
            ////txtboardhight.Text = "0";
            ////txtprintheight.Text = "0";
            ////txtboardwidth.Text = "0";
            ////txtprintwidth.Text = "0";
        }
        /// <summary>
        /// validation for the upper record
        /// </summary>
        /// <returns></returns>
        private string[] Validation()
        {
            string[] result = new string[2];
            strFileTypeVC = Path.GetExtension(fuPhoto.FileName).ToLower();
            if (lbldslno.Text == "0")
            {
                if (cmbProductType.Text != string.Empty)
                {
                    result[0] = "false";
                    result[1] = string.Empty;
                    if ((strFileTypeVC == ".jpg" || strFileTypeVC == ".jpeg" || strFileTypeVC == ".png"))
                    {
                        result[0] = "false";
                        result[1] = string.Empty;
                        ////rdsizetype.SelectedValue == "0" && 
                        if (lblsizetype.Text == "0" && gvSizeChild.Rows.Count > 0)
                        {
                            result[0] = "true";
                            result[1] = "You Have seleted board option so adding the value from size detail into the list is  invalid";
                        }
                        else
                        {
                            ////rdsizetype.SelectedValue == "1" && 
                            if (lblsizetype.Text == "1" && gvSizeChild.Rows.Count == 0)
                            {
                                result[0] = "true";
                                result[1] = "You Have seleted place option so adding the value from size detail into the list is  mandatory ";
                            }
                            else
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                        }
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
                }
                else
                {
                    result[0] = "true";
                    result[1] = "Product Type  is empty ";
                }
            }
            else
            {
                strFileTypeVC = Path.GetExtension(fuPhoto.FileName).ToLower();

                if (strFileTypeVC != "")
                {
                    if ((strFileTypeVC == ".jpg" || strFileTypeVC == ".jpeg" || strFileTypeVC == ".png"))
                    {
                        result[0] = "false";
                        result[1] = string.Empty;
                        ////rdsizetype.SelectedValue == "0" && 
                        if (lblsizetype.Text == "0" && gvSizeChild.Rows.Count > 0)
                        {
                            result[0] = "true";
                            result[1] = "You Have seleted board option so adding the value from size detail into the list is  invalid";
                            return result;
                        }
                        else
                        {
                            ////rdsizetype.SelectedValue == "1" && 
                            if (lblsizetype.Text == "1" && gvSizeChild.Rows.Count == 0)
                            {
                                result[0] = "true";
                                result[1] = "You Have seleted place option so adding the value from size detail into the list is  mandatory ";
                                return result;
                            }
                            else
                            {
                                result[0] = "false";
                                result[1] = string.Empty;
                            }
                        }
                    }
                    
                }
                else if (hfReferSheet.Text != "")
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
                        return result;
                    }
                }
                else
                {
                    result[0] = "true";
                    result[1] = "File and Image Link both fields are empty or image format is wrong";
                    return result;
                }


                if (cmbProductType.Text != string.Empty)
                {
                    result[0] = "false";
                    result[1] = string.Empty;

                    ////rdsizetype.SelectedValue == "0" && 
                    if (lblsizetype.Text == "0" && gvSizeChild.Rows.Count > 0)
                    {
                        result[0] = "true";
                        result[1] = "You Have seleted board option so adding the value from size detail into the list is  invalid";
                    }
                    else
                    {
                        ////rdsizetype.SelectedValue == "1" && 
                        if (lblsizetype.Text == "1" && gvSizeChild.Rows.Count == 0)
                        {
                            result[0] = "true";
                            result[1] = "You Have seleted place option so adding the value from size detail into the list is  mandatory ";
                        }
                        else
                        {
                            result[0] = "false";
                            result[1] = string.Empty;
                        }
                    }
                }
                else
                {
                    result[0] = "true";
                    result[1] = "Product Type  is empty ";
                }
            }

            return result;
        }
        /// <summary>
        /// Add or update the  desinsubmit.
        /// </summary>
        private void Submit()
        {
            if (lbslno.Text == "0" && lbldslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any job for design submit or updation of the submitted design. ','error',3);", true);
            }

            //else if (rdsizetype.SelectedValue == "0" && (txtbwidth.Text == string.Empty || txtbheight.Text == string.Empty || txtpwidth.Text == string.Empty || txtpheight.Text == string.Empty)) // 
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Please Add Size  !','warning',3);", true);
            //}
            //else if (rdsizetype.SelectedValue == "1" && (gvSizeChild.Rows.Count == 0))
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Please Add Size  !','warning',3);", true);
            //}
            else
            {
                decimal newwidth = 0;
                decimal newheight = 0;

                if (txtNewWidth.Text != string.Empty && txtNewHeight.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter height. ','error',3);", true);
                }
                if (txtNewWidth.Text == string.Empty && txtNewHeight.Text != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter width. ','error',3);", true);
                }
                if (txtNewWidth.Text != string.Empty && txtNewHeight.Text != string.Empty)
                {
                    newwidth = Convert.ToDecimal(txtNewWidth.Text);
                    newheight = Convert.ToDecimal(txtNewHeight.Text);
                }

                if (Validation()[0] == "true")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
                }
                else
                {
                    if (cmbProductType.Value.ToString() == "3" && gvSchemeChild.Rows.Count <= 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please add item!','warning',3);", true);
                    }
                    else
                    {
                        #region UpperEntry

                        //foreach (var file in funewimg.PostedFiles)
                        //{
                        //    strFileTypeVC = Path.GetExtension(file.FileName).ToLower();
                        //    string theFileName = string.Empty;
                        //    string singleFile = string.Empty;
                        //    singleFile = Guid.NewGuid().ToString() + strFileTypeVC;
                        //    theFileName = Path.Combine(Server.MapPath("~/Upload/JobRequest/"), FolderName, party, singleFile);
                        //    file.SaveAs(theFileName);
                        //    FileNameVC += string.Format(@"{0},", singleFile);
                        //}
                        //if (strFileTypeVC != string.Empty)
                        //{
                        //    FileNameVC = FileNameVC.TrimEnd(',');
                        //}
                        //else
                        //{
                        //    FileNameVC = string.Empty;
                        //}

                        string strFileType = "";
                        foreach (var file in fuPhoto.PostedFiles)
                        {
                            if (file.FileName != "")
                            {
                                bool rtnVallpost = false;
                                string uploadedFileName = "";

                                SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME4);
                                if (rtnVallpost)
                                {

                                    strFileType = Path.GetExtension(file.FileName).ToLower();
                                    if (FileNameVC == "")
                                    {
                                        FileNameVC = uploadedFileName;
                                    }
                                    else
                                    {
                                        FileNameVC = FileNameVC + ',' + uploadedFileName;
                                    }
                                }
                            }
                        }
                        if (lbslno.Text == "0")
                        {
                            FileNameVC = FileNameVC.TrimEnd(',');
                        }
                        else
                        {
                            if (hfReferSheet.Text != "")
                            {
                                FileNameVC = FileNameVC.TrimEnd(',') + ',' + hfReferSheet.Text;

                                if (FileNameVC.Contains(",,"))
                                {
                                    FileNameVC.Replace(",,", "");
                                }
                            } 
                        }



                        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dst = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                        int assignslno = Convert.ToInt32(lbslno.Text);
                        int slno = Convert.ToInt32(lbldslno.Text);
                        var submitimg = FileNameVC;
                        string link = txtLink.Text;
                        int newproducttypeid = Convert.ToInt32(cmbProductType.Value);
                        decimal totalamount = Convert.ToDecimal(txttotalamt.Text);
                        dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                        dst.needapproval = Convert.ToBoolean(lblismailsnd.Text);
                        dst.assignslno = assignslno;
                        dst.slno = slno;
                        dst.sumbmitimg = submitimg;
                        dst.newproducttypeid = newproducttypeid;
                        dst.totalamount = totalamount;
                        dst.pagename = HttpContext.Current.Request.Url.ToString();
                        ////dst.sizetype = Convert.ToInt32(rdsizetype.SelectedValue);
                        dst.link = link;

                        dst.NewWidth = newwidth;
                        dst.NewHeight = newheight;
                        dst.remark = txtremark.Text;

                        Core.DesignSubmit.DesignSubmit objinsert = new Core.DesignSubmit.DesignSubmit();
                        result = objinsert.DesignSubmitInsertMethod(dst);

                        if (result == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                            FinalClean();
                        }
                        else if (result != -1 && result != 0)
                        {
                            if (dst.createuid != 0) ////rdsizetype.SelectedValue == "0" Added true condition just to enter in the code
                            {
                                //Data.DesignSubmit.DesignSubmit.DesignSubmitProperty sizechild = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                                //decimal boardwidth = Convert.ToDecimal(txtbwidth.Text);
                                //decimal boardheight = Convert.ToDecimal(txtbheight.Text);
                                ////decimal printwidth = Convert.ToDecimal(txtpwidth.Text);
                                ////decimal printheight = Convert.ToDecimal(txtpheight.Text);
                                //sizechild.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                                //sizechild.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                                //sizechild.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                                //sizechild.needapproval = Convert.ToBoolean(lblismailsnd.Text);
                                //sizechild.assignslno = assignslno;
                                //sizechild.slno = slno;
                                //sizechild.boardheight = boardheight;
                                //sizechild.boardwidth = boardwidth;
                                //sizechild.printheight = 0;//// printheight;
                                //sizechild.printwidth = 0;//// printwidth;
                                //sizechild.oldsizetype = Convert.ToInt16(lblsizetype.Text);
                                ////sizechild.newsizetype = Convert.ToInt16(rdsizetype.SelectedValue);
                                //sizechild.refid = result;
                                //sizechild.pagename = HttpContext.Current.Request.Url.ToString();
                                //Core.DesignSubmit.DesignSubmit objinsertsizechild = new Core.DesignSubmit.DesignSubmit();
                                //result3 = 1;// objinsert.SizeDesignSubmitInsertMethod(sizechild);
                                //if (result3 == -1)
                                //{
                                //    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                                //    del.assignslno = Convert.ToInt32(assignslno);
                                //    errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                                //    FinalClean();
                                //}
                                //else
                                //{
                                    if (gvSchemeChild.Rows.Count > 0)
                                    {
                                        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dstt = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                                        foreach (GridViewRow row in gvSchemeChild.Rows)
                                        {
                                            int Itemid = Convert.ToInt32(((HiddenField)row.FindControl("Itemid")).Value);
                                            int childslno = Convert.ToInt32(((HiddenField)row.FindControl("hfchildslno")).Value);
                                            decimal MRP = Convert.ToDecimal(row.Cells[2].Text);
                                            decimal Discount = Convert.ToDecimal(row.Cells[3].Text);
                                            int Qty = Convert.ToInt32(row.Cells[4].Text);
                                            decimal Amount = Convert.ToDecimal(row.Cells[5].Text);
                                            dstt.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                                            dstt.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                                            dstt.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                                            dstt.refid = result;
                                            dstt.pagename = HttpContext.Current.Request.Url.ToString();
                                            dstt.itemid = Itemid;
                                            dstt.assignslno = assignslno;
                                            dstt.slno = Convert.ToInt32(lbldslno.Text);
                                            dstt.childslno = childslno;
                                            dstt.mrp = MRP;
                                            dstt.discount = Discount;
                                            dstt.qty = Qty;
                                            dstt.amount = Amount;
                                            result2 = objinsert.ItemDesignSubmitInsertMethod(dstt);
                                            if (result2 == -1)
                                            {
                                                Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                                                del.assignslno = Convert.ToInt16(assignslno);
                                                errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                                                FinalClean();
                                                break;
                                            }
                                        }
                                        if (lbldslno.Text == "0")
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details  Added successfully !','success',3);", true);
                                            FinalClean();
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details Updated successfully !','success',3);", true);
                                            Delete(hfReferSheetDelete.Text);
                                            FinalClean();
                                        }
                                    }
                                    else
                                    {
                                        if (lbldslno.Text == "0")
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details  Added successfully !','success',3);", true);
                                            FinalClean();
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details Updated successfully !','success',3);", true);
                                            Delete(hfReferSheetDelete.Text);
                                            FinalClean();
                                        }
                                    }
                               // }
                            }
                            //else if (1==1)  ////rdsizetype.SelectedValue == "1"
                            //{
                            //    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty sizechildgrid = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //    foreach (GridViewRow row in gvSizeChild.Rows)
                            //    {
                            //        int sizeslno = Convert.ToInt32(((HiddenField)row.FindControl("hfsizeslno")).Value);
                            //        decimal boardheightg = Convert.ToDecimal(row.Cells[1].Text);
                            //        decimal boardwidthg = Convert.ToDecimal(row.Cells[2].Text);
                            //        decimal printheightg = Convert.ToDecimal(row.Cells[3].Text);
                            //        decimal printwidthg = Convert.ToDecimal(row.Cells[4].Text);
                            //        sizechildgrid.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                            //        sizechildgrid.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                            //        sizechildgrid.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                            //        sizechildgrid.refid = result;
                            //        sizechildgrid.pagename = HttpContext.Current.Request.Url.ToString();
                            //        sizechildgrid.assignslno = assignslno;
                            //        sizechildgrid.slno = Convert.ToInt32(lbldslno.Text);
                            //        sizechildgrid.sizeslno = sizeslno;
                            //        sizechildgrid.boardheight = boardheightg;
                            //        sizechildgrid.boardwidth = boardwidthg;
                            //        sizechildgrid.printheight = printheightg;
                            //        sizechildgrid.oldsizetype = Convert.ToInt16(lblsizetype.Text);
                            //        ////sizechildgrid.newsizetype = Convert.ToInt16(rdsizetype.SelectedValue);
                            //        sizechildgrid.printwidth = printwidthg;
                            //        result3 = objinsert.SizeDesignSubmitInsertMethod(sizechildgrid);
                            //        if (result3 == -1 && lbldslno.Text == "0")
                            //        {
                            //            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //            del.assignslno = Convert.ToInt16(assignslno);
                            //            errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured  !','warning',3);", true);
                            //            FinalClean();
                            //            break;
                            //        }
                            //        if (result3 == -1 && lbldslno.Text != "0")
                            //        {
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured during size update please try again  !','warning',3);", true);
                            //            FinalClean();
                            //            break;
                            //        }
                            //    }
                            //    if (gvSchemeChild.Rows.Count > 0)
                            //    {
                            //        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dstt = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //        foreach (GridViewRow row in gvSchemeChild.Rows)
                            //        {
                            //            int Itemid = Convert.ToInt32(((HiddenField)row.FindControl("Itemid")).Value);
                            //            int childslno = Convert.ToInt32(((HiddenField)row.FindControl("hfchildslno")).Value);
                            //            decimal MRP = Convert.ToDecimal(row.Cells[2].Text);
                            //            decimal Discount = Convert.ToDecimal(row.Cells[3].Text);
                            //            int Qty = Convert.ToInt32(row.Cells[4].Text);
                            //            decimal Amount = Convert.ToDecimal(row.Cells[5].Text);
                            //            dstt.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                            //            dstt.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                            //            dstt.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                            //            dstt.refid = result;
                            //            dstt.pagename = HttpContext.Current.Request.Url.ToString();
                            //            dstt.itemid = Itemid;
                            //            dstt.assignslno = assignslno;
                            //            dstt.slno = Convert.ToInt32(lbldslno.Text);
                            //            dstt.childslno = childslno;
                            //            dstt.mrp = MRP;
                            //            dstt.discount = Discount;
                            //            dstt.qty = Qty;
                            //            dstt.amount = Amount;
                            //            result2 = objinsert.ItemDesignSubmitInsertMethod(dstt);
                            //            if (result2 == -1 && lbldslno.Text == "0")
                            //            {
                            //                Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //                del.assignslno = Convert.ToInt16(assignslno);
                            //                errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                            //                break;
                            //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                            //            }
                            //            if (result2 == -1 && lbldslno.Text != "0")
                            //            {
                            //                break;
                            //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured updating items !','warning',3);", true);
                            //                FinalClean();
                            //            }
                            //        }
                            //        if (lbldslno.Text == "0")
                            //        {
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details  Added successfully !','success',3);", true);
                            //            FinalClean();
                            //        }
                            //        else
                            //        {
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details Updated successfully !','success',3);", true);
                            //            FinalClean();
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (lbldslno.Text == "0")
                            //        {
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details  Added successfully !','success',3);", true);
                            //            FinalClean();
                            //        }
                            //        else
                            //        {
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details Updated successfully !','success',3);", true);
                            //            FinalClean();
                            //        }
                            //    }
                            //}
                            else
                            {
                                Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                                del.assignslno = Convert.ToInt16(assignslno);
                                errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Can Not Add Or Update Because You Are Adding Values In Wrong Condition','warning',3);", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                            FinalClean();
                        }
                    }
                }
            }
            FinalClean();

            #endregion UpperEntry
        }
        /// <summary>
        /// validation for the child.
        /// </summary>
        /// <returns></returns>
        private string[] Validationchild()
        {
            string[] results = new string[2];
            if (CmbItem.Value == string.Empty || Convert.ToDecimal(txtmrp.Text) <= 0 || Convert.ToDecimal(txtqty.Text) <= 0 || Convert.ToDecimal(txtamt.Text) <= 0)
            {
                results[0] = "true";
                results[1] = "some error occured";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please Check mandatory fields','warning',3);", true);
            }
            else
            {
                results[0] = "false";
                results[1] = string.Empty;
            }
            return results;
        }
        /// <summary>
        /// Loads the grid of Item child during edit.
        /// </summary>
        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lblrefid.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            Session[ViewState["_PageID"].ToString() + "Scheme"] = dt6;
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }
        /// <summary>
        /// Loads the grid of Size child during edit.
        /// </summary>
        private void loadsizechild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lblrefid.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);
            Session[ViewState["_SizePageID"].ToString() + "Size"] = dt6;
            gvSizeChild.DataSource = dt6;
            gvSizeChild.DataBind();
        }
        /// <summary>
        /// final clean.
        /// </summary>
        private void FinalClean()
        {
            txtremark.Text = string.Empty;
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
            lblqty.Text = string.Empty;
            jobtype.Text = string.Empty;
            subjobtype.Text = string.Empty;
            subsubjobtype.Text = string.Empty;
            designtyp.Text = string.Empty;
            cmbProductType.SelectedIndex = -1;
            CmbItem.SelectedIndex = -1;
            hfReferSheet.Text = "";
            hfReferSheetDelete.Text = "";
            lbslno.Text = "0";
            lbldslno.Text = "0";
            lblchildid.Text = "0";
            lblrefid.Text = "0";
            lblismailsnd.Text = string.Empty;
            txttotalamt.Text = "0";
            lblsizetype.Text = "0";
            txtamt.Text = "0.00";
            txtmrp.Text = "0.0";
            txtDiscount.Text = "0.00";
            txtqty.Text = "0";
            txttotalamt.Text = "0.00";

            lblCinNo.Text = string.Empty;
            lblUnit.Text = string.Empty;
            lblBoardType.Text = string.Empty;
            lblPrintLocation.Text = string.Empty;
            lblFabricatorLocation.Text = string.Empty;
            lblPriority.Text = string.Empty;
            lblAprrovalRemark.Text = string.Empty;
            ////txtboardhight.Text = string.Empty;
            ////txtboardwidth.Text = string.Empty;
            ////txtprintheight.Text = string.Empty;
            ////txtprintwidth.Text = string.Empty;
            ////txtpheight.Text = string.Empty;
            ////txtpwidth.Text = string.Empty;

            txtbheight.Text = string.Empty;
            txtbwidth.Text = string.Empty;

            lblJobRemark.Text = string.Empty;
            lblAssignRemark.Text = string.Empty;

            txtNewHeight.Text = string.Empty;
            txtNewWidth.Text = string.Empty;
            lblPlaceSize.Text = string.Empty;

            ImgLink.Text = string.Empty;
            ASPxGridView1.DataBind();
            gvdesignsubmit.DataBind();
            gvSchemeChild.DataBind();
            gvSizeChild.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }
        #endregion Private Methods
        #region Events
        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            FinalClean();

            if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                gvdesignsubmit.DataBind();
            }
        }
        /// <summary>
        /// call clean and final cleqan method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
            FinalClean();
        }
        /// <summary>
        /// call the submit method for submit or update the record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }
        /// <summary>
        /// Bind the list of assigned child for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }

        protected void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbItem.SelectedItem != null)
            {
                if (CmbItem.SelectedItem.Value.ToString() != "0")
                {
                    GetItemPrice(Convert.ToInt32(CmbItem.SelectedItem.Value));
                }
            }
        }

        protected void GetItemPrice(int ItemID)
        {
            decimal itemPrice = 0;

            itemPrice = da.GetItemPriceDA(ItemID);
            txtmrp.Text = itemPrice.ToString();
            txtDiscount.Text = (Convert.ToDecimal(txtmrp.Text) / 2).ToString();
        }

        /// <summary>
        /// Cal the calculation method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cal_changed(object sender, EventArgs e)
        {
            calulation();
        }
        /// <summary>
        /// bind the all the submited child by  the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvdesignsubmit_DataBinding(object sender, EventArgs e)
        {
            gvdesignsubmit.DataSource = GetTable2();
        }

        protected void gvdesignsubmit_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string submitimg = e.GetValue("sumbmitimg").ToString();

            string submitlink = e.GetValue("ImageLink").ToString();

            string jobimg = e.GetValue("jobimage").ToString();

            string joblink = e.GetValue("jobimagelink").ToString();

            LinkButton hlSubImg = gvdesignsubmit.FindRowCellTemplateControl(e.VisibleIndex, gvdesignsubmit.Columns["Submitted Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;
            HyperLink hlSubLink = gvdesignsubmit.FindRowCellTemplateControl(e.VisibleIndex, gvdesignsubmit.Columns["Submitted Image Link"] as GridViewDataTextColumn, "submitLink") as HyperLink;

            LinkButton hljobImg = gvdesignsubmit.FindRowCellTemplateControl(e.VisibleIndex, gvdesignsubmit.Columns["Reference Image"] as GridViewDataTextColumn, "lnkShowImg3") as LinkButton;
            //HyperLink hljobLink = gvdesignsubmit.FindRowCellTemplateControl(e.VisibleIndex, gvdesignsubmit.Columns["Reference Imag Link"] as GridViewDataTextColumn, "submitLink2") as HyperLink;


            if (submitimg == "")
            {  
                hlSubImg.Visible = false;
            }

            if (jobimg == "")
            {
                hljobImg.Visible = false;
            }

            if (submitlink == "")
            {
                hlSubLink.Visible = false;
            }
            else
            {
                hlSubLink.NavigateUrl = submitlink;
            }
        }

        

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
        /// <summary>
        /// Call show fuction when want to submit the design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show();
            checkViewFile();
        }
        /// <summary>
        /// Call show fuction when want to edit submited  design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdDSEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbldslno.Text = FieldTripID.ToString();
            show2();
            checkViewFile();
        }
        

        protected void lbVisitingCardImg_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 1);
            this.mpeAll.Show();
        }

        protected void lbReferSheetImg_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 2);
            this.mpeAll.Show();
        }

        protected void lnkShowImg2_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblHeadSlno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadSlno.Text), 1);
            this.mpeAll.Show();
        }


        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblchildid.Text), 3);
            this.mpeAll.Show();
        }

        protected void lnkShowImg3_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblchildid.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
            this.mpeAll.Show();
        }

        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            lnkvisible.Text = "2";
            lbIsListShow.Text = "0";
            GetUploadedJobRequestFiles(Convert.ToInt64(lbldslno.Text), 4);
            this.mpeImage1.Show();
        }

        protected void lnkAllFiles_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 11);
            this.mpeAll.Show();
        }
        protected void lnkFilesShop_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 15);
            this.mpeAll.Show();
        }
        protected void lnkShowImg_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbldslno.Text = FieldTripID.ToString();
            lbIsListShow.Text = "1";
            lnkvisible.Text = "2";
            GetUploadedJobRequestFiles(Convert.ToInt32(lbldslno.Text), 4);
            this.mpeImage1.Show();
        }

        
        /// <summary>
        /// add the item for the job
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnadditem_Click(object sender, EventArgs e)
        {
            if (Validationchild()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validationchild()[1] + "','warning',3);", true);
            }
            else
            {
                calulation();
                Boolean matchdata = false;

                if (txtmrp.Text != string.Empty && txtqty.Text != string.Empty && CmbItem.Value != string.Empty)
                {
                    DataRow row = dtss.NewRow();

                    if (Session[ViewState["_PageID"].ToString() + "Scheme"] != null)
                    {
                        DataTable dt2 = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            if (Convert.ToString(dt2.Rows[i]["Item"]) == CmbItem.Text)
                            {
                                matchdata = true;
                                lblMsg2.Text = "Opps! duplicate value";
                                lblMsg2.Style.Add("color", "red");
                                break;
                            }
                        }
                    }

                    if (matchdata == false)
                    {
                        row["childslno"] = "0";
                        row["Itemid"] = CmbItem.Value;
                        row["Item"] = CmbItem.Text;
                        row["MRP"] = Convert.ToDecimal(txtmrp.Text);
                        row["Discount"] = Convert.ToDecimal(txtDiscount.Text);
                        row["Qty"] = Convert.ToDecimal(txtqty.Text);
                        row["Amount"] = Convert.ToDecimal(txtamt.Text);
                        dtss.Rows.Add(row);
                        dtss.AcceptChanges();
                        Session[ViewState["_PageID"].ToString() + "Scheme"] = dtss;
                        bindgvSchemeChild();
                        //  clean2();
                    }
                }
                else
                {
                    lblMsg2.Text = "Please enter every mandatory details";
                    lblMsg2.Style.Add("color", "red");
                }
                for (int i = 0; i < gvSchemeChild.Rows.Count; i++)
                {
                    Cnt += Convert.ToDouble(gvSchemeChild.Rows[i].Cells[5].Text);
                }
                txttotalamt.Text = Cnt.ToString();
                clean();
            }
        }
        /// <summary>
        /// add the size for the job
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnaddsize_Click(object sender, EventArgs e)
        {
            //////if (Validationchild()[0] == "true")
            //////{
            //////    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validationchild()[1] + "','warning',3);", true);
            //////}
            //////else
            //////{
            ////Boolean matchdata = false;

            ////if (txtboardhight.Text != string.Empty && txtboardhight.Text != string.Empty && txtprintheight.Text != string.Empty && txtprintwidth.Text != string.Empty)
            ////{
            ////    DataRow row = dts.NewRow();

            ////    if (matchdata == false)
            ////    {
            ////        row["SizeSlno"] = "0";
            ////        row["BoardHeight"] = Convert.ToDecimal(txtboardhight.Text);
            ////        row["BoardWidth"] = Convert.ToDecimal(txtboardwidth.Text);
            ////        row["PrintHeight"] = Convert.ToDecimal(txtprintheight.Text);
            ////        row["PrintWidth"] = Convert.ToDecimal(txtprintwidth.Text);
            ////        dts.Rows.Add(row);
            ////        dts.AcceptChanges();
            ////        Session[ViewState["_SizePageID"].ToString() + "Size"] = dts;
            ////        bindgvSizeChild();
            ////    }
            ////}
            ////else
            ////{
            ////    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter every mandatory details','warning',3);", true);
            ////    //lblMsg2.Text = "Please enter every mandatory details";
            ////    //lblMsg2.Style.Add("color", "red");
            ////}
            ////cleansize();
            ////// }
        }
        /// <summary>
        /// Delete the item from the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvSchemeChild_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rows = 0;
            int index = Convert.ToInt32(e.RowIndex);
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty param1 = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            //child srno
            param1.slno = Convert.ToInt32(((HiddenField)gvSchemeChild.Rows[index].FindControl("hfchildslno")).Value);
            Core.DesignSubmit.DesignSubmit objdelete = new Core.DesignSubmit.DesignSubmit();
            rows = objdelete.DeleteItemForDesignSubmitCore(param1);
            if (rows == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Item Deleted successfully !','success',3);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
            }

            DataTable dtss = Session[ViewState["_PageID"].ToString() + "Scheme"] as DataTable;

            dtss.Rows[index].Delete();
            dtss.AcceptChanges();
            Session[ViewState["_PageID"].ToString() + "Scheme"] = dtss;

            bindgvSchemeChild();
            for (int i = 0; i < gvSchemeChild.Rows.Count; i++)
            {
                Cnt += Convert.ToDouble(gvSchemeChild.Rows[i].Cells[5].Text);
            }
            txttotalamt.Text = Cnt.ToString();
        }
        /// <summary>
        /// Delete the size from the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvSizeChild_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rows = 0;
            int index = Convert.ToInt32(e.RowIndex);
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty param1 = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            //child srno
            param1.slno = Convert.ToInt32(((HiddenField)gvSizeChild.Rows[index].FindControl("hfsizeslno")).Value);
            Core.DesignSubmit.DesignSubmit objdelete = new Core.DesignSubmit.DesignSubmit();
            rows = objdelete.DeleteSizeForDesignSubmitCore(param1);
            if (rows == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Item Deleted successfully !','success',3);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
            }

            DataTable dts = Session[ViewState["_SizePageID"].ToString() + "Size"] as DataTable;

            dts.Rows[index].Delete();
            dts.AcceptChanges();
            Session[ViewState["_SizePageID"].ToString() + "Size"] = dts;
            bindgvSizeChild();
        }
        protected void gvSchemeChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (gvSchemeChild.Rows.Count != 0)
                //{
                //    gvSchemeChild.Rows[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                //}

                int lastCellIndex = e.Row.Cells.Count - 1;
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[lastCellIndex].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete Item Name: " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void gvSizeChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (gvSizeChild.Rows.Count > 0)
                //{
                //    gvSizeChild.Rows[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                //}

                int lastCellIndex = e.Row.Cells.Count - 1;
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[lastCellIndex].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete Item Name: " + item + "?')){ return false; };";
                    }
                }
            }
        }
        /// <summary>
        /// Action for the type of size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdsizetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdsizetype.SelectedValue == "0")
            //{
            //    //rdsizetype.SelectedValue = "0";
            //    //btnaddsize.Enabled = false;
            //    //txtboardhight.Enabled = false;
            //    //txtboardwidth.Enabled = false;
            //    //txtprintheight.Enabled = false;
            //    //txtprintwidth.Enabled = false;
            //    //txtpheight.Enabled = true;
            //    //txtpwidth.Enabled = true;

            //    txtbheight.Enabled = true;
            //    txtbwidth.Enabled = true;
                
            //}
            //else
            //{
            //    //rdsizetype.SelectedValue = "1";
            //    //btnaddsize.Enabled = true;
            //    //txtboardhight.Enabled = true;
            //    //txtboardwidth.Enabled = true;
            //    //txtprintheight.Enabled = true;
            //    //txtprintwidth.Enabled = true;
            //    //txtpheight.Enabled = false;
            //    //txtpwidth.Enabled = false;

            //    txtbheight.Enabled = false;
            //    txtbwidth.Enabled = false;
                
            //}
        }

        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            //if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            //string VisitingCardImg = e.GetValue("VisitingCardImg").ToString();

            //LinkButton hlSubImg = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Visiting Card Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;

            //if (VisitingCardImg == "")
            //{
            //    hlSubImg.Visible = false;
            //}
        }

        #endregion Events

        private string Delete(string file)
        {
            string result = string.Empty;
            string folderpath = string.Empty;
            string path = string.Empty;
            string[] Files = file.Split(',');
            folderpath = FILE_DIRECTORY_NAME4;
            for (int i = 0; i < Files.Length; i++)
            {
                path = folderpath + '/' + Files[i];

                var oldFileName = path.Split('/').Last();
                var retStr = _goldMedia.GoldMediaDelete(path);
                result = string.Format("{0} : {1}", oldFileName, retStr.Values.FirstOrDefault());
            }
            return result;
        }
       
        protected void checkViewFile()
        {
            //lnkFiles3.Text = "";
            //string hfimf1 = hfReferSheet.Text.Replace(",", "");
            //if (!string.IsNullOrEmpty(hfimf1))
            //{
                lnkFiles3.Text = "View Files";
            //}
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

            if (flag == 4)
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
        }

        protected void rptImages1_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                this.mpeImage1.Show();
            }
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt64(lbldslno.Text), 4);
            }
        }
        protected void rptImages1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfImgIName.Value);
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME4, hfImgIName.Value);
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

            if (lbIsListShow.Text == "1")
            {
                lnkDelete.Visible = false;
            }

            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
            }
            if (hfImgIName.Value.Contains(".pptx"))
            {
                imgDocs.ImageUrl = "~/images/ppt-icon.png";
                imgDocs.ToolTip = "Download pptx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfImgIName.Value.Contains(".ppt"))
            {
                imgDocs.ImageUrl = "~/images/ppt-icon.png";
                imgDocs.ToolTip = "Download ppt";
                hyLink.NavigateUrl = FileIdPath;
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
                    GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 1);
                }
                else if (hfPopupImageFlag.Value == "2")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 2);
                }
                else if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lblchildid.Text), 3);
                }
                else if (hfPopupImageFlag.Value == "4")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lbldslno.Text), 4);
                }
                else if (hfPopupImageFlag.Value == "11")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 11);
                }
                else if (hfPopupImageFlag.Value == "15")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadSlno.Text), 15);
                }
                else if (hfPopupImageFlag.Value == "13")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 13);
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
            else if (hfPopupImageFlag.Value == "4")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "11")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "15")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "13")
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
            GetUploadedJobRequestFiles(Convert.ToInt64(lblchildid.Text), 13);
            this.mpeAll.Show();
        }
    }
}