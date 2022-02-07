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
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.JobRequest
{
    public partial class JobRequest : System.Web.UI.Page
    {

        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        public string party = string.Empty;
        private int rows = 0;
        private string flagImg = string.Empty;

        JobRequestDataAccess da = new JobRequestDataAccess();

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_JobRequestHead";
        private string Node = "Transaction";
        private const string FILE_DIRECTORY_NAME = "jobrequest/visitingcard";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/refersheet";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/cdrfile";
        private const string FILE_DIRECTORY_NAME4 = "jobrequest/shopphoto";

        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;

        #endregion Edit Block - Variable

        #region page Event
        protected void UpdatePanel3_Unload(object sender, EventArgs e)
        {
            MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();
            methodInfo.Invoke(ScriptManager.GetCurrent(Page),
            new object[] { sender as UpdatePanel });
        }
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
                    LoadAllName(string.Empty);
                    LoadCategory();
                    LoadArea();
                    LoadBranch();
                    LoadSubmitted();
                    LoadSalesExecutive();
                    BindGridview();

                    ASPxPageControl1.ActiveTabIndex = 0;
                    txtDate.Text = DateTime.Now.ToString();
                }
            }
            //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "loadgridhead();", true);
        }

        public JobRequest()
        {
            _goldMedia = new GoldMedia();
            //  finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }

        #endregion page Event

        #region Methods

        #region Bind Values


        public void LoadSalesExecutive()
        {
            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dt = objselectsingle.AllSalesExecutiveCore();
            cmbSalesExecutive.Items.Clear();
            cmbSalesExecutive.Value = null;
            cmbSalesExecutive.DataSource = dt;
            cmbSalesExecutive.TextField = "salesexnm";
            cmbSalesExecutive.ValueField = "slno";
            cmbSalesExecutive.SelectedIndex = -1;
            cmbSalesExecutive.DataBind();
        }


        /// <summary>
        /// Bind all name type which are static.
        /// </summary>
        /// <param name="countryName"></param>
        public void LoadAllName(string countryName)
        {
            cmbNameType.Items.Add("Distributor", "1");
            cmbNameType.Items.Add("Branch", "5");
            cmbNameType.Items.Add("Dealer", "2");
            cmbNameType.Items.Add("Retailer", "4");
        }

        public void LoadNameDataNew()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.nameid = Convert.ToInt32(CmbName.Value);
            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dt = da.AllDataForNameNew(param);

            if (dt.Rows.Count > 0)
            {
                //lblAddress.Text = Convert.ToString(dt.Rows[0]["address"]);
                //lblContactPerson.Text = Convert.ToString(dt.Rows[0]["contactperson"]);
                //lblContactNo.Text = Convert.ToString(dt.Rows[0]["mobile"]);
                //lblEmail.Text = Convert.ToString(dt.Rows[0]["email"]);
                //lblGSTNo.Text = Convert.ToString(dt.Rows[0]["GSTNo"]);
                //lblCINNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
            }
            else
            {
                //lblAddress.Text = "";
                //lblContactPerson.Text = "";
                //lblContactNo.Text = "";
                //lblEmail.Text = "";
                //lblGSTNo.Text = "";
                //lblCINNo.Text = "";
            }
        }

        public void LoadNameData()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.nameid = Convert.ToInt32(CmbName.Value);
            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dta = objselectsingle.AllDataForName(param);

            cmbAddress.DataSource = dta;
            cmbAddress.TextField = "address";
            cmbAddress.ValueField = "addressid";
            cmbAddress.SelectedIndex = 0;
            cmbAddress.DataBind();

            cmbcontactperson.DataSource = dta;
            cmbcontactperson.TextField = "contactperson";
            cmbcontactperson.ValueField = "contactperson";
            cmbcontactperson.SelectedIndex = 0;
            cmbcontactperson.DataBind();

            cmbcontact.DataSource = dta;
            cmbcontact.TextField = "mobile";
            cmbcontact.ValueField = "mobile";
            cmbcontact.SelectedIndex = 0;
            cmbcontact.DataBind();

            cmbemail.DataSource = dta;
            cmbemail.TextField = "email";
            cmbemail.ValueField = "email";
            cmbemail.SelectedIndex = 0;
            cmbemail.DataBind();

            cmbgst.DataSource = dta;
            cmbgst.TextField = "GSTNo";
            cmbgst.ValueField = "GSTNo";
            cmbgst.SelectedIndex = 0;
            cmbgst.DataBind();

            cmbcinnum.DataSource = dta;
            cmbcinnum.TextField = "cinnum";
            cmbcinnum.ValueField = "cinnum";
            cmbcinnum.SelectedIndex = 0;
            cmbcinnum.DataBind();
        }

        public void LoadNameDataTemp()
        {
            DataTable dta = new DataTable();

            dta.Columns.Add("slno", typeof(System.String));
            dta.Columns.Add("name", typeof(System.String));
            dta.Columns.Add("address", typeof(System.String));
            dta.Columns.Add("addressid", typeof(System.String));
            dta.Columns.Add("contactperson", typeof(System.String));
            dta.Columns.Add("mobile", typeof(System.String));
            dta.Columns.Add("email", typeof(System.String));
            dta.Columns.Add("GSTNo", typeof(System.String));

            DataRow r1 = dta.NewRow();
            r1["slno"] = cmbbranch.SelectedItem.Value;
            r1["name"] = cmbbranch.SelectedItem.Text;
            r1["address"] = "N/A";
            r1["addressid"] = "0";
            r1["contactperson"] = "N/A";
            r1["mobile"] = "N/A";
            r1["email"] = "N/A";
            r1["GSTNo"] = "N/A";
            dta.Rows.Add(r1);


            CmbName.DataSource = dta;
            CmbName.TextField = "name";
            CmbName.ValueField = "slno";
            CmbName.SelectedIndex = 0;
            CmbName.DataBind();

            cmbAddress.DataSource = dta;
            cmbAddress.TextField = "address";
            cmbAddress.ValueField = "addressid";
            cmbAddress.SelectedIndex = 0;
            cmbAddress.DataBind();

            cmbcontactperson.DataSource = dta;
            cmbcontactperson.TextField = "contactperson";
            cmbcontactperson.ValueField = "contactperson";
            cmbcontactperson.SelectedIndex = 0;
            cmbcontactperson.DataBind();

            cmbcontact.DataSource = dta;
            cmbcontact.TextField = "mobile";
            cmbcontact.ValueField = "mobile";
            cmbcontact.SelectedIndex = 0;
            cmbcontact.DataBind();

            cmbemail.DataSource = dta;
            cmbemail.TextField = "email";
            cmbemail.ValueField = "email";
            cmbemail.SelectedIndex = 0;
            cmbemail.DataBind();

            namedata.Style.Add("display", "none");
            namedata2.Style.Add("display", "none");
            rduseaddress.SelectedIndex = 1;
        }


        /// <summary>
        /// Bind all the name accounrding to the name time
        /// </summary>
        public void LoadName()
        {
            if (Convert.ToInt32(cmbNameType.Value) != 4)
            {
                Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                param.nametype = Convert.ToInt32(cmbNameType.Value);
                param.userbranchid = Convert.ToInt32(cmbbranch.Value);
                Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
                DataTable dt = objselectsingle.AllNameCore(param);
                CmbName.Items.Clear();
                CmbName.Value = null;
                CmbName.DataSource = dt;
                CmbName.TextField = "name";
                CmbName.ValueField = "slno";
                CmbName.SelectedIndex = -1;
                CmbName.DataBind();
            }
            else
            {
                LoadNameDataTemp();
                LoadSubName();
            }


        }

        /// <summary>
        /// Bind all the Subname accounrding to the name type and name
        /// </summary>
        public void LoadSubName()
        {
            bool status;
            if (Convert.ToInt32(cmbNameType.Value) != 4)
            {
                Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                param.nametype = Convert.ToInt32(cmbNameType.Value);
                param.nameid = Convert.ToInt32(CmbName.Value);
                param.userid = Convert.ToInt32(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid"));

                if (chkStatecheck.Checked == true)
                {
                    status = Convert.ToBoolean(1);
                }
                else
                {
                    status = Convert.ToBoolean(0);
                }

                param.Statecheck = Convert.ToBoolean(status);
                Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
                DataTable dt = objselectsingle.AllSubNameCore(param);
                cmbSubName.Items.Clear();
                cmbSubName.Value = null;
                cmbSubName.DataSource = dt;
                cmbSubName.TextField = "name";
                cmbSubName.ValueField = "slno";
                cmbSubName.SelectedIndex = -1;
                cmbSubName.DataBind();
            }
            else
            {
                Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                param.nametype = Convert.ToInt32(cmbNameType.Value);
                param.userbranchid = Convert.ToInt32(cmbbranch.Value);
               param.userid= Convert.ToInt32(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid"));
                if (chkStatecheck.Checked == true)
                {
                    status = Convert.ToBoolean(1);
                }
                else
                {
                    status = Convert.ToBoolean(0);
                }

                param.Statecheck = Convert.ToBoolean(status);
                Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
                DataTable dt = objselectsingle.AllNameCore(param);
                cmbSubName.Items.Clear();
                cmbSubName.Value = null;
                cmbSubName.DataSource = dt;
                cmbSubName.TextField = "name";
                cmbSubName.ValueField = "slno";
                cmbSubName.SelectedIndex = -1;
                cmbSubName.DataBind();
            }
        }

        /// <summary>
        /// Bind the address
        /// </summary>
        public void LoadAddress()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.nameid = Convert.ToInt32(CmbName.Value);
            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dta = objselectsingle.AllAddressContactsCore(param);
            cmbAddress.Items.Clear();
            cmbAddress.Value = null;
            cmbAddress.DataSource = dta;
            cmbAddress.TextField = "address";
            cmbAddress.ValueField = "addressid";

            cmbAddress.SelectedIndex = 0;
            cmbAddress.DataBind();


        }

        /// <summary>
        /// Bind the Subaddress
        /// </summary>
        public void LoadSubAddress()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
           
            int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
            da.SavePageLog(Convert.ToString(cmbSubName.Value), Request.RawUrl + "#" + lineNumber);

            if (cmbSubName.Value != null)
            {
                int SubNameID = 0;

                bool result = int.TryParse(cmbSubName.Value.ToString(), out SubNameID);

                if (result && !string.IsNullOrEmpty(cmbSubName.Value.ToString()))
                {
                    param.SubNameId = SubNameID;

                    Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
                    DataTable dta = objselectsingle.AllSubAddressCore(param);
                    cmbSubAddress.Items.Clear();
                    cmbSubAddress.Value = null;
                    cmbSubAddress.DataSource = dta;
                    cmbSubAddress.TextField = "regaddress";
                    cmbSubAddress.ValueField = "regaddress";
                    cmbSubAddress.SelectedIndex = 0;
                    cmbSubAddress.DataBind();
                }
            }
        }

        /// <summary>
        /// Bind the email id of the sub party.
        /// </summary>
        public void LoadSubEmail()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
            da.SavePageLog(Convert.ToString(cmbSubName.Value), Request.RawUrl + "#" + lineNumber);

            if (cmbSubName.Value != null)
            {
                int SubNameID = 0;

                bool result = int.TryParse(cmbSubName.Value.ToString(), out SubNameID);

                if (result && !string.IsNullOrEmpty(cmbSubName.Value.ToString()))
                {
                    param.SubNameId = SubNameID;

                    Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
                    DataTable dta = objselectsingle.AllSubEmailCore(param);
                    cmbsubmail.Items.Clear();
                    cmbsubmail.Value = null;
                    cmbsubmail.DataSource = dta;
                    cmbsubmail.TextField = "regemail";
                    cmbsubmail.ValueField = "regemail";
                    cmbsubmail.SelectedIndex = 0;
                    cmbsubmail.DataBind();
                }
            }



            

        }

        /// <summary>
        /// Bind the submitted by of the sub party.
        /// </summary>
        public void LoadSubmitted()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.SubNameId = Convert.ToInt32(cmbSubName.Value);

            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dta = objselectsingle.AllSubmittedbyCore(param);
            cmbSubmitby.Items.Clear();
            cmbSubmitby.Value = null;
            cmbSubmitby.DataSource = dta;
            cmbSubmitby.TextField = "salesexnm";
            cmbSubmitby.ValueField = "salesexnm";
            cmbSubmitby.SelectedIndex = -1;
            cmbSubmitby.DataBind();

        }

        public void LoadBranch()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            //Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            //DataTable dta = objselectsingle.AllBranchCore(param);
            //cmbbranch.Items.Clear();
            //cmbbranch.Value = null;
            //cmbbranch.DataSource = dta;
            //cmbbranch.TextField = "locnm";
            //cmbbranch.ValueField = "slno";
            //cmbbranch.DataBind();

            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            DataSet dsaselect = objselectsingleselect.AllBranchSelected(param);

            cmbbranch.Items.Clear();
            cmbbranch.Value = null;
            cmbbranch.DataSource = dsaselect.Tables[1];
            cmbbranch.TextField = "locnm";
            cmbbranch.ValueField = "branchid";
            cmbbranch.DataBind();

            if (dsaselect.Tables[0].Rows.Count > 0)
            {
                cmbbranch.SelectedItem = cmbbranch.Items.FindByValue(dsaselect.Tables[0].Rows[0]["homebranchid"].ToString());
            }
        }

        public void LoadSubContact()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
            da.SavePageLog(Convert.ToString(cmbSubName.Value), Request.RawUrl + "#" + lineNumber);


            if (cmbSubName.Value != null)
            {
                int SubNameID = 0;

                bool result = int.TryParse(cmbSubName.Value.ToString(), out SubNameID);

                if (result && !string.IsNullOrEmpty(cmbSubName.Value.ToString()))
                {
                    param.SubNameId = SubNameID;

                    Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
                    DataTable dta = objselectsingle.AllSubContactsCore(param);
                    cmbSubContact.Items.Clear();
                    cmbSubContact.Value = null;
                    cmbSubContact.DataSource = dta;
                    cmbSubContact.TextField = "regcontactno";
                    cmbSubContact.ValueField = "regcontactno";
                    cmbSubContact.SelectedIndex = 0;
                    cmbSubContact.DataBind();
                }
            }


           

        }

        /// <summary>
        /// Bind the contact person but here we use text and value type are same (contact person)
        /// </summary>
        public void LoadContactPerson()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.nameid = Convert.ToInt32(CmbName.Value);

            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dtco = objselectsingle.AllContactDetailCore(param);
            cmbcontactperson.Items.Clear();
            cmbcontactperson.Value = null;

            cmbcontactperson.DataSource = dtco;
            cmbcontactperson.TextField = "contactperson";
            cmbcontactperson.ValueField = "contactperson";
            cmbcontactperson.SelectedIndex = 0;
            cmbcontactperson.DataBind();

        }

        /// <summary>
        /// Bind the contact mobile but here we use text and value type are same mobile)
        /// </summary>
        public void LoadContactMobile()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.nameid = Convert.ToInt32(CmbName.Value);

            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dtco = objselectsingle.AllContactDetailCore(param);
            cmbcontact.Items.Clear();
            cmbcontact.Value = null;
            cmbcontact.DataSource = dtco;
            cmbcontact.TextField = "mobile";
            cmbcontact.ValueField = "mobile";
            cmbcontact.SelectedIndex = 0;
            cmbcontact.DataBind();

        }

        /// <summary>
        /// Bind the contact email but here we use text and value type are same email)
        /// </summary>
        public void LoadEmail()
        {

            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.addressid = Convert.ToInt32(cmbAddress.Value);

            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dteml = objselectsingle.AllEmailCore(param);

            cmbemail.Items.Clear();
            cmbemail.Value = null;
            cmbemail.DataSource = dteml;
            cmbemail.TextField = "email";
            cmbemail.ValueField = "email";
            cmbemail.SelectedIndex = 0;
            cmbemail.DataBind();



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

        public void LoadPrintLocation()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");

                TextBox lblPrinterLocation = (TextBox)row.FindControl("lblPrinterLocation");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable dtprintloc = db.GetPrinterLocation();

                ddlPrintLocation.Items.Clear();

                ddlPrintLocation.DataSource = dtprintloc;
                ddlPrintLocation.DataBind();

                ddlPrintLocation.Items.Insert(0, "Select");

                if (cmbbranch.SelectedItem != null)
                {
                    ddlPrintLocation.SelectedItem.Text = cmbbranch.SelectedItem.Text;
                    ddlPrintLocation.SelectedItem.Value = cmbbranch.SelectedItem.Value.ToString();
                    lblPrinterLocation.Text = cmbbranch.SelectedItem.Value.ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        public void LoadFabricatorLocation()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");

                TextBox lblFabricatorLocation = (TextBox)row.FindControl("lblFabricatorLocation");

                Core.JobType.JobType db = new Core.JobType.JobType();
                DataTable dtfabloc = db.GetFabricatorLocation();

                ddlFabricatorLocation.Items.Clear();

                ddlFabricatorLocation.DataSource = dtfabloc;
                ddlFabricatorLocation.DataBind();

                ddlFabricatorLocation.Items.Insert(0, "Select");
                ddlFabricatorLocation.SelectedItem.Text = cmbbranch.SelectedItem.Text;
                ddlFabricatorLocation.SelectedItem.Value = cmbbranch.SelectedItem.Value.ToString();
                lblFabricatorLocation.Text = cmbbranch.SelectedItem.Value.ToString();
            }
        }

        public void LoadPrintFabLocation()
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                DropDownList ddlPrintLocation = (DropDownList)row.FindControl("ddlPrintLocation");

                TextBox lblPrinterLocation = (TextBox)row.FindControl("lblPrinterLocation");

                DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");

                TextBox lblFabricatorLocation = (TextBox)row.FindControl("lblFabricatorLocation");

                if (cmbbranch.SelectedItem != null)
                {
                    ddlPrintLocation.SelectedItem.Text = cmbbranch.SelectedItem.Text;
                    ddlPrintLocation.SelectedItem.Value = cmbbranch.SelectedItem.Value.ToString();
                    lblPrinterLocation.Text = cmbbranch.SelectedItem.Value.ToString();

                    ddlFabricatorLocation.SelectedItem.Text = cmbbranch.SelectedItem.Text;
                    ddlFabricatorLocation.SelectedItem.Value = cmbbranch.SelectedItem.Value.ToString();
                    lblFabricatorLocation.Text = cmbbranch.SelectedItem.Value.ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
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
        public void LoadGstNo()
        {

            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.nametype = Convert.ToInt32(cmbNameType.Value);
            param.nameid = Convert.ToInt32(CmbName.Value);
            var id = Convert.ToInt32(cmbSubName.Value);
            Core.JobRequest.JobRequest objdataGstNo = new Core.JobRequest.JobRequest();
            DataTable dtgstno = objdataGstNo.AllGstNo(param);
            cmbgst.Items.Clear();
            cmbgst.Value = null;
            cmbgst.DataSource = dtgstno;
            cmbgst.TextField = "GSTNo";
            cmbgst.ValueField = "GSTNo";

            cmbgst.SelectedIndex = 0;
            cmbgst.DataBind();


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

        /// <summary>
        /// Bind The Gird of job request head
        /// </summary>
        private DataTable GetTableHead()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            param.userbranchid = Convert.ToInt32(cmbbranch.Value);
            Core.JobRequest.JobRequest objdata = new Core.JobRequest.JobRequest();
            DataTable dt = objdata.AllJobRequestBranchHeadDACore(param);
            return dt;
        }

        /// <summary>
        /// Bind the grid of job request child
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

        #endregion Bind Values

        #region WebMethods

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
                result = "<select valimage='" + subjobdt.Rows[0]["isimgreq"] + "' valaprove='" + subjobdt.Rows[0]["isaprreq"] + "' id='ddlSubJobType_" + jobtype + "' name ='ddlSubJobType_" + jobtype + "' style='width:220px' class='form-control-grid fntsize' onchange='loadsubsubjob(this.id)'> <option value='0'>Select</option>";

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
            string result = "<select onchange='fillsubsubjob(this.id)' id='ddlSubSubJobType_" + subjobtype + "' name='ddlSubSubJobType_" + subjobtype + "' style='width:330px' class='form-control-grid fntsize''> <option value='0'>Select</option>";

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

        #endregion WebMethods

        #region Private Methods
        protected void LoadCategory()
        {
            Core.JobRequest.IJobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dt = objselectsingle.GetPartyCatAll();
            cmbcat.Items.Clear();
            cmbcat.Value = null;
            cmbcat.Items.Clear();
            cmbcat.Value = null;
            cmbcat.DataSource = dt;
            cmbcat.TextField = "partycatnm";
            cmbcat.ValueField = "slno";
            cmbcat.SelectedIndex = 0;
            cmbcat.DataBind();
        }
        protected void LoadArea()
        {
            Core.JobRequest.IJobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dt = objselectsingle.GetAreaAll();
            cmbarea.Items.Clear();
            cmbarea.Value = null;
            cmbarea.Items.Clear();
            cmbarea.Value = null;
            cmbarea.DataSource = dt;
            cmbarea.TextField = "areanm";
            cmbarea.ValueField = "areaid";
            cmbarea.SelectedIndex = 0;
            cmbarea.DataBind();
        }
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
        /// Check validation For Head And Child
        /// </summary>
        /// <returns></returns>
        private string[] Validation()
        {
            string[] result = new string[2];

            #region validation On Head

            //List<string> allfieldsHead = new List<string>();
            //allfieldsHead.Add(cmbNameType.Text);
            //allfieldsHead.Add(CmbName.Text);
            //allfieldsHead.Add(cmbAddress.Text);
            //allfieldsHead.Add(cmbcontactperson.Text);
            //allfieldsHead.Add(cmbcontact.Text);

            //allfieldsHead.Add(cmbemail.Text);  //commented by gaurav
            //allfieldsHead.Add(cmbgst.Text); //commented by gaurav

            //foreach (var item in allfieldsHead)
            //{
            //    if (string.IsNullOrEmpty(item) || item == "Select")
            //    {
            //        result[0] = "true";
            //        result[1] = "Please check head validation.!";
            //    }
            //}

            if (string.IsNullOrEmpty(cmbNameType.Text) || cmbNameType.Text == "Select")
            {
                result[0] = "true";
                result[1] = "Please select type in head.!";
            }
            else if (string.IsNullOrEmpty(CmbName.Text) || CmbName.Text == "Select")
            {
                result[0] = "true";
                result[1] = "Please select name in head.!";
            }
            else if (string.IsNullOrEmpty(cmbAddress.Text) || cmbAddress.Text == "Select")
            {
                result[0] = "true";
                result[1] = "Address is empty in head.!";
            }
            else if (string.IsNullOrEmpty(cmbcontactperson.Text) || cmbcontactperson.Text == "Select")
            {
                result[0] = "true";
                result[1] = "Contact person is empty in head.!";
            }
            else if (string.IsNullOrEmpty(cmbcontact.Text) || cmbcontact.Text == "Select")
            {
                result[0] = "true";
                result[1] = "Contact is empty in head.!";
            }



            if (cmbGivenBy.SelectedItem != null && cmbGivenBy.SelectedItem.Value != null)
            {
                if (cmbGivenBy.SelectedItem.Value.ToString() == "1")
                {
                    if (cmbSalesExecutive.SelectedItem == null || cmbSalesExecutive.SelectedItem.Value == null)
                    {
                        result[0] = "true";
                        result[1] = "Please check head validation.!";
                    }
                }


                if (cmbGivenBy.SelectedItem.Value.ToString() == "2")
                {
                    if (txtGivenByOther.Text == null || txtGivenByOther.Text == "")
                    {
                        result[0] = "true";
                        result[1] = "Please check head validation.!";
                    }
                }
            }

            #endregion validation On Head


            string FolderName = string.Empty;
            string msg = string.Empty;
            string gvslno = "0";
            foreach (GridViewRow row in gvDetails.Rows)
            {
                if (!string.IsNullOrEmpty(result[1]))
                {
                    break;
                }

                if (!string.IsNullOrEmpty(result[1]))
                {
                    break;
                }

                #region Set value for validation On Child

                //if (result[1] == "Please check child validation.!")
                //{
                //    break;
                //}

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
                    if (!string.IsNullOrEmpty(result[1]))
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

                if (Unit != "Select" || txtSizeInch != string.Empty || txtSizeHeight != string.Empty || selectedJobType != "Select" || selectedJobSubType != string.Empty || selectedMaterial != string.Empty || selectedDesign != "Select" || selectedProduct != "Select" || selectedBoardType != string.Empty || txtQty != string.Empty || txtInstallAddress != string.Empty)
                {

                    if (Unit == "Select")
                    {
                        result[0] = "true";
                        result[1] = "Please select unit.!";
                        break;
                    }

                    if (txtSizeInch == string.Empty)
                    {
                        result[0] = "true";
                        result[1] = "Please enter width.!";
                        break;
                    }

                    if (txtSizeHeight == string.Empty)
                    {
                        result[0] = "true";
                        result[1] = "Please enter height.!";
                        break;
                    }

                    if (selectedJobType == "Select")
                    {
                        result[0] = "true";
                        result[1] = "Please select job type.!";
                        break;
                    }

                    if (selectedJobSubType == string.Empty || selectedJobSubType == "Select")
                    {
                        result[0] = "true";
                        result[1] = "Please select sub job type.!";
                        break;
                    }

                    if (selectedMaterial == string.Empty || selectedMaterial == "Select")
                    {
                        result[0] = "true";
                        result[1] = "Please select printer material.!";
                        break;
                    }

                    if (selectedDesign == "Select" || selectedDesign == string.Empty)
                    {
                        result[0] = "true";
                        result[1] = "Please select fabrication material.!";
                        break;
                    }

                    if (selectedProduct == "Select" || selectedProduct == string.Empty)
                    {
                        result[0] = "true";
                        result[1] = "Please select product type.!";
                        break;
                    }

                    if (selectedBoardType == "" || selectedBoardType == "0")
                    {
                        result[0] = "true";
                        result[1] = "Please select board type.!";
                        break;
                    }

                    if (IsPrintRq == "True" && (printlocation == "Select" || lblPrinterLocation == ""))
                    {
                        result[0] = "true";
                        result[1] = "Please select printer location.!";
                        break;
                    }

                    if (IsFabReq == "True" && (fablocation == "Select" || lblFabricatorLocation == ""))
                    {
                        result[0] = "true";
                        result[1] = "Please select fabricator location.!";
                        break;
                    }

                    if (txtQty == string.Empty || txtQty == "0")
                    {
                        result[0] = "true";
                        result[1] = "Please enter quantity.!";
                        break;
                    }

                    if (txtInstallAddress == string.Empty)
                    {
                        result[0] = "true";
                        result[1] = "Please enter address.!";
                        break;
                    }

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
                            result[1] = "Please enter approver email.!";
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
                            result[1] = "Please add image or link.!";
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
                            result[1] = "Please add image or link.!";
                            break;
                        }
                    }

                    #endregion updatecase

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
            #region For Visiting Card

            lnkFiles2.Text = string.Empty;
            string hfimf = hfVisitingImage.Text.Replace(",", string.Empty);
            if (!string.IsNullOrEmpty(hfimf))
            {
                lnkFiles2.Text = "View Files";
            }

            #endregion For Visiting Card


            #region For Shop photo

            lnkFiles4.Text = string.Empty;
            string hfspimf = hfShopPhoto.Text.Replace(",", string.Empty);
            if (!string.IsNullOrEmpty(hfspimf))
            {
                lnkFiles4.Text = "View Files";
            }

            #endregion For Shop photo

            #region For ReferSheet

            lnkFiles3.Text = string.Empty;
            string hfimf1 = hfReferSheet.Text.Replace(",", string.Empty);
            if (!string.IsNullOrEmpty(hfimf1))
            {
                lnkFiles3.Text = "View Files";
            }

            #endregion For ReferSheet
        }

        /// <summary>
        ///1-This method is called by booth the button submit and save as draft submit gives 1 and save as draft gives 0
        ///2-First Check validation
        ///3-Now we execute the proc. for the head section and get a result which we use as refrence in child if the result is -1 then in the starting of child section we break the process and through the error other wise execute the child proc.
        ///4-Now We execute the proc. for the child and get final result  for multiple child when ever we get filan result result -1 then we delete all the child and head of that perticular entry .
        /// </summary>
        /// <param name="JobRequestStatus"></param>
        private void SaveAsDraft(string JobRequestStatus)
        {
            int result = 0;
            string s = lbslno.Text;
            int finalresult = 0;
            int errorresulr = 0;
            string FileNameVC = string.Empty;
            string FileNameSP = string.Empty;
            string strFileTypeVC = string.Empty;
            string strFileTypeSP = string.Empty;
            string FolderName = string.Empty;
            string msg = string.Empty;
            string gvslno = "0";
            Data.JobRequest.JobRequestModel.JobRequestProperties ds = new JobRequestModel.JobRequestProperties();

            if (gvDetails.Rows.Count > 0)
            {
                if (Validation()[0] == "true")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);showbuttons();", true);

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
                        string lblPrinterLocation = (row.FindControl("lblPrinterLocation") as TextBox).Text;

                        Core.JobType.JobType db22 = new Core.JobType.JobType();
                        DataTable dtprintloc = db22.GetPrinterLocation();

                        ddlPrintLocation.Items.Clear();
                        ddlPrintLocation.DataSource = dtprintloc;
                        ddlPrintLocation.DataBind();
                        ddlPrintLocation.Items.Insert(0, "Select");

                        DropDownList ddlFabricatorLocation = (DropDownList)row.FindControl("ddlFabricatorLocation");
                        string lblFabricatorLocation = (row.FindControl("lblFabricatorLocation") as TextBox).Text;

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

                        CheckBox chkisapprov = (CheckBox)row.FindControl("chkisapprov");

                        TextBox lblchkisapprov = (TextBox)row.FindControl("lblchkisapprov");

                        DropDownList DropDownList1 = (DropDownList)row.FindControl("DropDownList1");


                        if (lblchkisapprov.Text == "True")
                        {
                            chkisapprov.Checked = true;
                            chkisapprov.Enabled = false;
                        }
                        else
                        {
                            chkisapprov.Enabled = true;
                            chkisapprov.Checked = false;
                        }


                        if (!string.IsNullOrEmpty(lblPrinterLocation))
                        {
                            ddlPrintLocation.Items.FindByValue(lblPrinterLocation).Selected = true;
                        }

                        if (!string.IsNullOrEmpty(lblFabricatorLocation))
                        {
                            ddlFabricatorLocation.Items.FindByValue(lblFabricatorLocation).Selected = true;
                        }

                    }
                }
                else
                {

                    #region Insert Head

                    Data.JobRequest.JobRequestModel.JobRequestProperties Headdst = new Data.JobRequest.JobRequestModel.JobRequestProperties();

                    #region Visiting card

                    foreach (var file in fuVisitingCard.PostedFiles)
                    {
                        if (file.FileName != "")
                        {
                            bool rtnVallpost = false;
                            string uploadedFileName = "";
                            strFileTypeVC = Path.GetExtension(file.FileName).ToLower();
                            if (strFileTypeVC == ".jpg" || strFileTypeVC == ".jpeg" || strFileTypeVC == ".png")
                            {

                                SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME);
                                if (rtnVallpost)
                                {

                                    strFileTypeVC = Path.GetExtension(file.FileName).ToLower();

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
                            else
                            {
                                FileNameVC = string.Empty;
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Invalid file. Please note Only JPG, jpg, jpeg and png of max size 5MB is allowed.');showbuttons();", true);
                                return;
                            }
                        }
                    }


                    if (lbslno.Text == "0")
                    {
                        FileNameVC = FileNameVC.TrimEnd(',');
                    }
                    else
                    {
                        FileNameVC = FileNameVC.TrimEnd(',') + ',' + hfVisitingImage.Text;
                    }
                    #endregion Visiting card

                    #region Shop Photo

                    foreach (var file in fuShopPhoto.PostedFiles)
                    {
                        if (file.FileName != "")
                        {
                            bool rtnVallpost = false;
                            string uploadedFileName = "";
                            strFileTypeSP = Path.GetExtension(file.FileName).ToLower();
                            if (strFileTypeSP == ".jpg" || strFileTypeSP == ".jpeg" || strFileTypeSP == ".png")
                            {

                                SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME4);
                                if (rtnVallpost)
                                {

                                    strFileTypeSP = Path.GetExtension(file.FileName).ToLower();

                                    if (FileNameSP == "")
                                    {
                                        FileNameSP = uploadedFileName;
                                    }
                                    else
                                    {
                                        FileNameSP = FileNameSP + ',' + uploadedFileName;
                                    }

                                }
                            }
                            else
                            {
                                FileNameSP = string.Empty;
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Invalid file. Please note Only JPG, jpg, jpeg and png of max size 5MB is allowed.');showbuttons();", true);
                                return;
                            }
                        }
                    }


                    if (lbslno.Text == "0")
                    {
                        FileNameSP = FileNameSP.TrimEnd(',');
                    }
                    else
                    {
                        FileNameSP = FileNameSP.TrimEnd(',') + ',' + hfShopPhoto.Text;
                    }
                    #endregion Shop Photo

                    #region Refersheet

                    string strFileTypeRS = "";
                    string FileNameRS = string.Empty;
                    foreach (var file in fuReferSheet.PostedFiles)
                    {
                        if (file.FileName != "")
                        {
                            bool rtnVallpost = false;
                            string uploadedFileName = "";

                            strFileTypeRS = Path.GetExtension(file.FileName).ToLower();
                            if (strFileTypeRS == ".xlx" || strFileTypeRS == ".xlsx" || strFileTypeRS == ".ppt" || strFileTypeRS == ".pptx")
                            {
                                SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME1);
                                if (rtnVallpost)
                                {



                                    if (FileNameRS == "")
                                    {
                                        FileNameRS = uploadedFileName;
                                    }
                                    else
                                    {
                                        FileNameRS = FileNameRS + ',' + uploadedFileName;
                                    }

                                }
                            }
                            else
                            {
                                FileNameRS = string.Empty;
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Invalid file. Please note Only Excel Sheet, Power Point document of max size 20MB is allowed.','warning',3);showbuttons();", true);
                                return;
                            }
                        }
                    }
                    if (lbslno.Text == "0")
                    {
                        FileNameRS = FileNameRS.TrimEnd(',');
                    }
                    else
                    {
                        FileNameRS = FileNameRS.TrimEnd(',') + ',' + hfReferSheet.Text;
                    }



                    #endregion Refersheet

                    if (lbslno.Text == "0")
                    {
                        //    getrequestno();
                    }

                    // var reqno = txtRequestNo.Text;
                    var nametypeid = HttpUtility.HtmlEncode(cmbNameType.Value);
                    var nameid = HttpUtility.HtmlEncode(CmbName.SelectedItem.Value.ToString());
                    var address = HttpUtility.HtmlEncode(cmbAddress.SelectedItem.Value.ToString());
                    var contactperson = HttpUtility.HtmlEncode(cmbcontactperson.Value);
                    var email = HttpUtility.HtmlEncode(cmbemail.Text);
                    var contactnumber = HttpUtility.HtmlEncode(cmbcontact.Text);
                    //var requestdate = HttpUtility.HtmlEncode(txtDate.Text);
                    var requestdate = DateTime.Now.ToString();
                    //var subnameid = HttpUtility.HtmlEncode(cmbSubName.Value);
                    var subnameid = "";
                    if (HttpUtility.HtmlEncode(hdfsubname.Text) == "")
                    {
                        subnameid = "0";
                    }
                    else
                    {
                        subnameid = HttpUtility.HtmlEncode(hdfsubname.Text); 
                    }

                    var subaddress = HttpUtility.HtmlEncode(cmbSubAddress.Text);
                    var subcontact = HttpUtility.HtmlEncode(cmbSubContact.Text);
                    var subemail = HttpUtility.HtmlEncode(cmbsubmail.Text);
                    var submittedby = HttpUtility.HtmlEncode(cmbSubmitby.Text);
                    var approvedby = HttpUtility.HtmlEncode(txtapproveby.Text);

                    var givenby = HttpUtility.HtmlEncode(txtGivenByOther.Text);
                    var givenbyid = Convert.ToInt32(cmbSalesExecutive.Value);

                    var wallsizechildslno = Convert.ToInt32(cmbWallSizeJobs.Value);
                    var wallsizeheadreqno = HttpUtility.HtmlEncode(cmbWallSizeJobs.Text);

                    if (cmbGivenBy.SelectedItem != null && cmbGivenBy.SelectedItem.Value != null)
                    {
                        if (cmbGivenBy.SelectedItem.Value.ToString() == "1")
                        {
                            givenby = HttpUtility.HtmlEncode(cmbSalesExecutive.Text);
                        }
                        if (cmbGivenBy.SelectedItem.Value.ToString() == "2")
                        {
                            givenby = HttpUtility.HtmlEncode(txtGivenByOther.Text);
                            givenbyid = 0;
                        }
                    }



                    string gstno = HttpUtility.HtmlEncode(cmbgst.Value);

                    if (string.IsNullOrEmpty(gstno))
                    {
                        gstno = "";
                    }

                    string slno = lbslno.Text;
                    string VisitingCardImg = FileNameVC;
                    string ShopImg = FileNameSP;
                    string ReferSheet = FileNameRS;
                    // Headdst.reqno = reqno;

                    bool IsSubnameIdstaterightswise ;

                    if (chkStatecheck.Checked == true)
                    {
                        IsSubnameIdstaterightswise = Convert.ToBoolean(1);
                    }
                    else
                    {
                        IsSubnameIdstaterightswise = Convert.ToBoolean(0);
                    }


                    bool IsWallSize;

                    if (chkwallsize.Checked == true)
                    {
                        IsWallSize = Convert.ToBoolean(1);
                    }
                    else
                    {
                        IsWallSize = Convert.ToBoolean(0);
                    }



                    Headdst.NameTypeId = Convert.ToInt32(nametypeid);

                    Headdst.NameId = Convert.ToInt32(nameid);

                    Headdst.Address = Convert.ToInt32(address);
                    Headdst.ContactPerson = contactperson;
                    Headdst.Email = email;
                    Headdst.ContactNumber = contactnumber;
                    Headdst.RequestDate = Convert.ToDateTime(requestdate);
                    Headdst.SubNameId = Convert.ToInt32(subnameid);
                    Headdst.SubAddress = subaddress;
                    Headdst.SubContact = subcontact;
                    Headdst.subemail = subemail;
                    Headdst.submittedby = submittedby;
                    Headdst.approvedby = approvedby;
                    Headdst.GivenBy = givenby;
                    Headdst.GivenByID = givenbyid;
                    Headdst.GstNo = gstno;
                    Headdst.VisitingCardImg = VisitingCardImg;
                    Headdst.Shopphoto = ShopImg;
                    Headdst.ReferSheet = ReferSheet;
                    Headdst.headstatus = Convert.ToInt16(JobRequestStatus);
                    Headdst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    Headdst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    Headdst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                    Headdst.pagename = HttpContext.Current.Request.Url.ToString();
                    Headdst.slno = Convert.ToInt64(slno);
                    Headdst.finyear = finYear;
                    Headdst.Statecheck = IsSubnameIdstaterightswise;
                    Headdst.IsWallSize = IsWallSize;
                   
                    Core.JobRequest.JobRequest objinsert = new Core.JobRequest.JobRequest();
                    result = objinsert.AddUpdateJobRequesHeadtDACore(Headdst);
                    deleteFiles(hfVisitingImageDelete.Text, slno, slno);
                    deleteFiles(hfShopPhotoDelete.Text, slno, slno);
                    deleteFiles(hfReferSheetDelete.Text, slno, slno);

                    #endregion Insert Head

                    #region Insert Child

                    Data.JobRequest.JobRequestModel.JobRequestProperties Childdst = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                    foreach (GridViewRow row in gvDetails.Rows)
                    {
                        if (result == -1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured !','warning',3);showbuttons();", true);
                            break;
                        }
                        string hfImagename = ((TextBox)row.FindControl("hfImagename")).Text;
                        string hfFilename = ((TextBox)row.FindControl("hfFilename")).Text;
                        string txtTaskID = ((Label)row.FindControl("txtTaskID")).Text;
                        string txtSizeInch = ((TextBox)row.FindControl("txtSizeInch")).Text;
                        string txtSizeHeight = ((TextBox)row.FindControl("txtSizeHeight")).Text;
                        DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");
                        string selectedJobType = ddlTypeofJob.SelectedValue;

                        DropDownList ddlUnit = (DropDownList)row.FindControl("ddlUnit");
                        string sizeUnit = ddlUnit.SelectedValue;


                        DropDownList ddlapprovalto = (DropDownList)row.FindControl("DropDownList1");
                        string selectedapprovalto = ddlapprovalto.SelectedValue;
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
                        string txtInstallAddress = ((TextBox)row.FindControl("txtInstallAddress")).Text;
                        string txtRemark = ((TextBox)row.FindControl("txtRemark")).Text;
                        string txtlink = ((TextBox)row.FindControl("txtlink")).Text;
                        if (lbslno.Text != "0")
                        {
                            gvslno = ((HiddenField)row.FindControl("hfslnochild")).Value;
                        }
                        TextBox chkisapprov = ((TextBox)row.FindControl("lblchkisapprov"));
                        string chkapproved = chkisapprov.Text;
                        bool approved = false;
                        if (chkapproved == "True")
                        {
                            approved = true;
                        }
                        else
                        {
                            approved = false;
                        }
                        TextBox chkisplace = ((TextBox)row.FindControl("lblchkisplace"));
                        string chkplace = chkisplace.Text;
                        bool place = false;
                        if (chkplace == "True")
                        {
                            place = true;
                        }
                        else
                        {
                            place = false;
                        }

                        #region ImageSave

                        FileUpload fuPhoto = (FileUpload)row.FindControl("fuPhoto");
                        string FileName = string.Empty;

                        int count = fuPhoto.PostedFiles.Count();
                        string imagename = string.Empty;



                        string FileNameimg = string.Empty;
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
                        if (lbslno.Text == "0")
                        {
                            FileNameimg = FileNameimg.TrimEnd(',');

                        }
                        else
                        {
                            FileNameimg = FileNameimg.TrimEnd(',') + ',' + hfImagename;


                        }

                        FileUpload fuFile = (FileUpload)row.FindControl("fuFile");
                        string CDRFileName = string.Empty;

                        int CDRFilecount = fuFile.PostedFiles.Count();
                        string Filename = string.Empty;



                        string CDRFileNameimg = string.Empty;
                        foreach (var Cdrfile in fuFile.PostedFiles)
                        {
                            if (Cdrfile.FileName != "")
                            {
                                bool cdrrtnVallpost = false;

                                string cdruploadedFileName = "";
                                string cdrstrFileTypeimg = Path.GetExtension(Cdrfile.FileName).ToLower();
                                string cdrtheFileName = string.Empty;
                                string singleFile = string.Empty;
                                decimal size = Math.Round(((decimal)Cdrfile.ContentLength / (decimal)1024), 2);


                                if (size <= 4096)
                                {
                                    if (cdrstrFileTypeimg == ".cdr")
                                    {

                                        SavePostedFile(out cdrrtnVallpost, Cdrfile, out cdruploadedFileName, FILE_DIRECTORY_NAME3);
                                        if (cdrrtnVallpost)
                                        {

                                            cdrstrFileTypeimg = Path.GetExtension(Cdrfile.FileName).ToLower();
                                            if (CDRFileNameimg == "")
                                            {
                                                CDRFileNameimg = cdruploadedFileName;
                                            }
                                            else
                                            {
                                                CDRFileNameimg = CDRFileNameimg + ',' + cdruploadedFileName;
                                            }
                                        }
                                    }
                                }


                                else
                                {
                                    lblModalTitle.Text = "Warning";
                                    lblModalBody.Text = "Sorry, Image size can not be greater then 4MB.";
                                    lblModalBody.Attributes.Add("style", "font-size:15px; color:Red; font-weight:lighter;");
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                                    upModal.Update();
                                    return;
                                }
                            }

                        }


                        if (lbslno.Text == "0")
                        {

                            CDRFileNameimg = CDRFileNameimg.TrimEnd(',');
                        }
                        else
                        {

                            CDRFileNameimg = CDRFileNameimg.TrimEnd(',') + ',' + hfFilename;
                        }


                        #endregion ImageSave




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


                        //string hfImagename = ((TextBox)row.FindControl("hfImagename")).Text;
                        if (sizeUnit != "0" && txtSizeInch != string.Empty && txtSizeHeight != string.Empty && selectedJobType != string.Empty && selectedJobSubType != string.Empty && selectedMaterial != string.Empty && selectedDesign != string.Empty && selectedProduct != string.Empty && txtQty != string.Empty && txtInstallAddress != string.Empty)

                        {
                            string TaskID = HttpUtility.HtmlEncode(txtTaskID);
                            decimal SizeInch = Convert.ToDecimal(HttpUtility.HtmlEncode(txtSizeInch));
                            decimal SizeHeight = Convert.ToDecimal(HttpUtility.HtmlEncode(txtSizeHeight));
                            string JobType = HttpUtility.HtmlEncode(selectedJobType);
                            string JobSubType = HttpUtility.HtmlEncode(selectedJobSubType);
                            string Material = HttpUtility.HtmlEncode(selectedMaterial);
                            string Design = HttpUtility.HtmlEncode(selectedDesign);
                            string Product = HttpUtility.HtmlEncode(selectedProduct);
                            string Qty = HttpUtility.HtmlEncode(txtQty);
                            string Address = HttpUtility.HtmlEncode(txtInstallAddress);
                            string approvalo = HttpUtility.HtmlEncode(selectedapprovalto);
                            string emailto = HttpUtility.HtmlEncode(txtmail);
                            string Remark = HttpUtility.HtmlEncode(txtRemark);
                            string isapprov = HttpUtility.HtmlEncode(chkisapprov);
                            // string ImageName = HttpUtility.HtmlEncode(imagename + ',' + hfImagename);
                            string Link = HttpUtility.HtmlEncode(txtlink);

                            string ImageName = HttpUtility.HtmlEncode(FileNameimg);
                            string CFileName = HttpUtility.HtmlEncode(CDRFileNameimg);
                            string slnochild = gvslno;
                            bool DeleteFlag = false;
                            string hfimg = ((TextBox)row.FindControl("hfImagenameDelete")).Text;
                            deleteFiles(hfimg, slno, slnochild);

                            string Unit = HttpUtility.HtmlEncode(sizeUnit);

                            string BoardType = HttpUtility.HtmlEncode(selectedBoardType);


                            Childdst.BoardTypeID = Convert.ToInt16(BoardType);
                            Childdst.PrintLocation = Convert.ToInt16(printlocation);
                            Childdst.FabricatorLocation = Convert.ToInt16(fabricatorlocation);
                            Childdst.Priority = Convert.ToInt16(priority);
                            Childdst.UnitID = Convert.ToInt16(Unit);
                            Childdst.TaskId = Convert.ToInt16(TaskID);
                            Childdst.Height = SizeHeight;
                            Childdst.Width = SizeInch;
                            Childdst.JobTypeId = Convert.ToInt16(JobType);
                            Childdst.SubJobTypeId = Convert.ToInt16(JobSubType);
                            Childdst.SubSubJobTypeId = Convert.ToInt16(Material);
                            Childdst.approvto = approvalo;
                            Childdst.approvalmail = emailto;
                            Childdst.DesignTypeId = Convert.ToInt16(Design);
                            Childdst.ProductTypeId = Convert.ToInt16(Product);
                            Childdst.Qty = Convert.ToInt16(Qty);
                            Childdst.Remark = Remark;
                            Childdst.ispalce = place;
                            Childdst.NeedApproval = approved;
                            Childdst.ImageName = ImageName;
                            Childdst.installaddress = Address;
                            Childdst.childstatus = Convert.ToInt16(JobRequestStatus);
                            Childdst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                            Childdst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                            Childdst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                            Childdst.pagename = HttpContext.Current.Request.Url.ToString();
                            Childdst.refid = result.ToString();
                            Childdst.slno = Convert.ToInt64(slnochild);
                            Childdst.DeleteFlag = DeleteFlag;
                            Childdst.Link = Link;
                            Childdst.CdrFile = CFileName;
                            Childdst.UseAddressType = Convert.ToInt16(rduseaddress.SelectedValue);
                            Childdst.WallSizeJobChildSlno = wallsizechildslno;
                            Childdst.WallsizejobheadReqNo = wallsizeheadreqno;
                            Core.JobRequest.JobRequest objinsertChild = new Core.JobRequest.JobRequest();
                            finalresult = objinsertChild.AddUpdateJobRequestChildDACore(Childdst);
                            if (finalresult == -1)
                            {
                                Data.JobRequest.JobRequestModel.JobRequestProperties delreq = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                                delreq.slno = Convert.ToInt64(result);
                                errorresulr = objinsertChild.PermanentDeleteJobRequestCore(delreq);
                                break;
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured !','warning',3);showbuttons();", true);
                            }
                        }
                    }

                    #endregion Insert Child

                    if (finalresult == 1)
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job request added successfully !','success',3);showbuttons();", true);

                        ResetFunc();
                        clean();

                    }
                    else if (finalresult == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job request updated successfully !','success',3);showbuttons();", true);
                        ResetFunc();
                        Delete(hfVisitingImageDelete.Text, FILE_DIRECTORY_NAME);
                        Delete(hfShopPhotoDelete.Text, FILE_DIRECTORY_NAME4);
                        Delete(hfReferSheetDelete.Text, FILE_DIRECTORY_NAME1);
                        foreach (GridViewRow row in gvDetails.Rows)
                        {

                            TextBox hfImagenameDelete = (TextBox)row.FindControl("hfImagenameDelete");
                            Delete(hfImagenameDelete.Text, FILE_DIRECTORY_NAME2);
                        }
                        clean();
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job request head added/updated successfully without any child !','success',3);showbuttons();", true);
                        ResetFunc();
                        clean();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter child details!','warning',3);showbuttons();", true);
            }
        }

        private void SaveOrg()
        {
            string msg = string.Empty;
            int result = 0, areaid1 = 0;
            var area = cmbarea.Value.ToString();
            string[] str = area.Split(',');
            areaid1 = Convert.ToInt32(str[0]);
            Data.JobRequest.JobRequestModel.orginsert orgadd = new Data.JobRequest.JobRequestModel.orginsert();
            var name = HttpUtility.HtmlEncode(txtname.Text);
            var compname = HttpUtility.HtmlEncode(txtcomname.Text.Trim());
            int categoryid = Convert.ToInt32(cmbcat.Value);
            var regaddress = HttpUtility.HtmlEncode(txtaddress.Text.Trim());
            var regcontactno = HttpUtility.HtmlEncode(txtmob.Text.Trim());
            int desigid = 0;
            int areaid = Convert.ToInt32(areaid1);
            orgadd.name = HttpUtility.HtmlEncode(name);
            orgadd.compname = HttpUtility.HtmlEncode(compname);
            orgadd.categoryid = Convert.ToInt32(categoryid);
            orgadd.regaddress = HttpUtility.HtmlEncode(regaddress);
            orgadd.regcontactno = HttpUtility.HtmlEncode(regcontactno);
            orgadd.desigid = 0;
            orgadd.areaid = Convert.ToInt32(areaid1);
            orgadd.crtuid1 = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            orgadd.logon1 = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");



            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(name)))
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Name Should not be empty.!','warning',3);", true);
                lber.Text = "Name Should not be empty.";
            }

            else if (categoryid == 0)
            {
                //  ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Category Should not be empty.!','warning',3);", true);
                lber.Text = "Category Should not be empty.";
            }

            else if (areaid == 0)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Area Should not be empty.!','warning',3);", true);
                lber.Text = "Area Should not be empty.";
            }
            else
            {
                Core.JobRequest.JobRequest orginsert = new Core.JobRequest.JobRequest();
                result = orginsert.AddOrgDACore(orgadd);
                if (result == 1)
                {
                    // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success', added successfully !','success',3);", true);
                    lber.Text = "added successfully.";
                    txtname.Text = "";
                    txtcomname.Text = "";
                    txtmob.Text = "";
                    txtaddress.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Some Thing Wrong !','warning',3);", true);
                    lber.Text = "Some Thing Wrong.";
                    txtname.Text = "";
                    txtcomname.Text = "";
                    txtmob.Text = "";
                    txtaddress.Text = "";

                }
            }




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
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            gvHead.Columns[14].Visible = false;
            gvHead.Columns[15].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            gvHead.Columns[14].Visible = true;
            gvHead.Columns[15].Visible = true;
        }

        /// <summary>
        /// Used in delete and edit action for tarcking data is editable,deletable or not
        /// </summary>
        ///
        protected void CheckEditBlock(string param, int id)
        {
            #region Is Editable

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

            #endregion Is Editable

            if (dtEditChk.Rows.Count > 0)
            {
                #region Editable

                if (dtEditChk.Rows[0]["PStatus"] != null && (dtEditChk.Rows[0]["PStatus"].ToString() == "InActive" || dtEditChk.Rows[0]["PStatus"].ToString() == "Unchecked"))
                {
                    if (param == "Delete")
                    {
                        #region Delete Block

                        Data.JobRequest.JobRequestModel.JobRequestProperties param1 = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                        param1.slno = Convert.ToInt32(lbslno.Text);
                        param1.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        param1.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                        Core.JobRequest.JobRequest objdelete = new Core.JobRequest.JobRequest();
                        rows = objdelete.DeleteJobRequestHeadCore(param1);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull !','success',3);", true);
                            gvHead.DataBind();
                            ResetFunc();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit !','warning',3);", true);
                            gvHead.DataBind();
                            ResetFunc();
                        }

                        #endregion Delete Block
                    }
                    else
                    {
                        #region Edit Block

                        show();

                        #endregion Edit Block
                    }

                    #endregion Editable
                }

                #region Not editable

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

                #endregion Not editable

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
        /// After edit or delete action this function reset editmode column which indicates that the value is editable,deleteble  or not
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

            Data.JobRequest.JobRequestModel.JobRequestProperties paramHead = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            paramHead.slno = Convert.ToInt32(lbslno.Text);
            Core.JobRequest.JobRequest objdataHead = new Core.JobRequest.JobRequest();
            DataTable dtHead = objdataHead.JobRequestHeadSelectParticularCore(paramHead);
            if (dtHead.Rows.Count > 0)
            {
                
               


                txtRequestNo.Text = Convert.ToString(dtHead.Rows[0]["reqno"]);
                cmbNameType.Text = Convert.ToString(dtHead.Rows[0]["NameType"]);
                cmbNameType.Value = Convert.ToString(dtHead.Rows[0]["NameTypeId"]);
                if (Convert.ToString(dtHead.Rows[0]["MappedWallSizeJob"]) == "True")
                {
                    chkmapjob.Checked = true;
                }
                else
                {
                    chkmapjob.Checked = false;
                }
                LoadWallSizeJobs(Convert.ToInt32(lbslno.Text));
                cmbWallSizeJobs.Value = Convert.ToString(dtHead.Rows[0]["WallSizeJobChildSlno"]);
                cmbWallSizeJobs.Text = Convert.ToString(dtHead.Rows[0]["WallSizeJobHeadReqNo"]);
                

                cmbWallSizeJobs.Enabled = false;
                chkmapjob.Enabled = false;
                chkwallsize.Enabled = false;



                if (cmbNameType.Value.ToString() != "4")
                {
                    LoadName();
                    CmbName.Text = Convert.ToString(dtHead.Rows[0]["AllName"]);
                    CmbName.Value = Convert.ToString(dtHead.Rows[0]["NameId"]);
                    LoadAddress();
                    cmbAddress.Text = Convert.ToString(dtHead.Rows[0]["AllAddress"]);
                    cmbAddress.Value = Convert.ToString(dtHead.Rows[0]["Address"]);
                    LoadContactPerson();
                    cmbcontactperson.Text = Convert.ToString(dtHead.Rows[0]["ContactPerson"]);
                    LoadContactMobile();
                    cmbcontact.Text = Convert.ToString(dtHead.Rows[0]["ContactNumber"]);
                    LoadEmail();
                    cmbemail.Text = Convert.ToString(dtHead.Rows[0]["Email"]);
                    //LoadGstNo();
                    cmbgst.Text = Convert.ToString(dtHead.Rows[0]["GstNo"]);
                    cmbgst.Value = Convert.ToString(dtHead.Rows[0]["GstNo"]);

                    cmbcinnum.Text = Convert.ToString(dtHead.Rows[0]["cinnum"]);
                    cmbcinnum.Value = Convert.ToString(dtHead.Rows[0]["cinnum"]);
                }
                else
                {
                    LoadNameDataTemp();
                }

                LoadSubName();

                hdfsubname.Text = Convert.ToString(dtHead.Rows[0]["slno"]);

                cmbSubName.Value = Convert.ToString(dtHead.Rows[0]["slno"]);
                cmbSubName.Text = Convert.ToString(dtHead.Rows[0]["name"]);

                lblStatus.Text = dtHead.Rows[0]["headstatus"].ToString();

                if (Convert.ToString(dtHead.Rows[0]["headstatus"]) == "0")
                {
                    txtDate.Text = DateTime.Now.ToString();
                }
                else
                {
                    txtDate.Text = Convert.ToString(dtHead.Rows[0]["RequestDate"]);
                }

                cmbSubmitby.Text = Convert.ToString(dtHead.Rows[0]["submittedby"]);
                txtapproveby.Text = Convert.ToString(dtHead.Rows[0]["approvedby"]);
                cmbSubAddress.Text = Convert.ToString(dtHead.Rows[0]["SubAddress"]);
                cmbSubContact.Text = Convert.ToString(dtHead.Rows[0]["SubContact"]);
                cmbsubmail.Text = Convert.ToString(dtHead.Rows[0]["subemail"]);


                if (dtHead.Rows[0]["GivenByID"] != null && dtHead.Rows[0]["GivenByID"].ToString() != "")
                {
                    if (Convert.ToString(dtHead.Rows[0]["GivenByID"]) == "0")
                    {
                        txtGivenByOther.Text = Convert.ToString(dtHead.Rows[0]["GivenBy"]);
                        cmbGivenBy.SelectedIndex = 2;

                        othergivenby.Style.Add("display", "block");
                        salesex.Style.Add("display", "none");
                    }
                    if (Convert.ToString(dtHead.Rows[0]["GivenByID"]) != "0")
                    {
                        cmbSalesExecutive.Text = HttpUtility.HtmlEncode(dtHead.Rows[0]["GivenBy"]);
                        cmbGivenBy.SelectedIndex = 1;

                        othergivenby.Style.Add("display", "none");
                        salesex.Style.Add("display", "block");
                    }
                }
                if (Convert.ToString(dtHead.Rows[0]["IsSubnameIdstaterightswise"]) == "True")
                {
                    chkStatecheck.Checked = true;
                }
                else
                {
                    chkStatecheck.Checked = false;
                }


                hfVisitingImage.Text = Convert.ToString(dtHead.Rows[0]["VisitingCardImg"]);
                hfShopPhoto.Text = Convert.ToString(dtHead.Rows[0]["ShopPhoto"]);
                hfReferSheet.Text = Convert.ToString(dtHead.Rows[0]["Refersheet"]);
                Core.JobRequest.JobRequest objdataChild = new Core.JobRequest.JobRequest();
                DataTable dtChild = objdataChild.JobRequestChildSelectParticularCore(paramHead);
                for (int i = dtChild.Rows.Count + 1; i <= 10; i++)
                {
                    DataRow row = dtChild.NewRow();
                    row["slno"] = 0;
                    dtChild.Rows.Add(row);
                    string a = lbslno.Text;
                }

                gvDetails.DataSource = dtChild;
                gvDetails.DataBind();

                //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + gvDetails.ClientID + "', 400, 1840 , 30 ,false); </script>", false);

                txtRequestNo.Focus();


                if (Convert.ToString(dtHead.Rows[0]["headstatus"].ToString()) != "0")
                {
                    CmdSaveAsDraft.Visible = false;
                    btnSubmit.Visible = false;
                    CmdReset.Visible = false;
                }
                if (Convert.ToString(dtHead.Rows[0]["jobheadstatus"].ToString()) == "Waiting For Approval")
                {

                    CmdSaveAsDraft.Visible = true;
                    btnSubmit.Visible = true;
                    CmdReset.Visible = true;

                }

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
            string overtime = string.Empty, maxtime = string.Empty, check = string.Empty, sts = string.Empty;
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
            if (flag == 15)
            {
                if (dtResult.Rows.Count > 0)
                {
                    rptImages3.DataSource = dtResult;
                    rptImages3.DataBind();
                    hdNoRecord3.Visible = false;
                }
                else
                {
                    rptImages3.DataSource = null;
                    rptImages3.DataBind();
                    hdNoRecord3.Visible = true;
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

        /// <summary>
        /// Genrate Request No.
        /// </summary>
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
                txtRequestNo.Text = Convert.ToString(dtreqno.Rows[0]["reqno"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','SomeThingWrong.','error',2);", true);
            }
        }

        /// <summary>
        /// Clean Head values
        /// </summary>


        protected void clearselection()
        {
            CmbName.Items.Clear();
            CmbName.Value = null;
            CmbName.Text = null;

            cmbAddress.Items.Clear();
            cmbAddress.Value = null;
            cmbAddress.Text = null;

            cmbcontactperson.Items.Clear();
            cmbcontactperson.Value = null;
            cmbcontactperson.Text = null;

            cmbcontact.Items.Clear();
            cmbcontact.Value = null;
            cmbcontact.Text = null;

            cmbemail.Items.Clear();
            cmbemail.Value = null;
            cmbemail.Text = null;

            cmbcinnum.Items.Clear();
            cmbcinnum.Value = null;
            cmbcinnum.Text = null;

            cmbgst.Items.Clear();
            cmbgst.Value = null;
            cmbgst.Text = null;

            hdfsubname.Text = "0";
            cmbSubName.Items.Clear();
            cmbSubName.Value = null;
            cmbSubName.Text = null;
            
            cmbSubAddress.Items.Clear();
            cmbSubAddress.Value = null;
            cmbSubAddress.Text = null;

            cmbSubContact.Items.Clear();
            cmbSubContact.Value = null;
            cmbSubContact.Text = null;

            cmbsubmail.Items.Clear();
            cmbsubmail.Value = null;
            cmbsubmail.Text = null;

            namedata.Style.Add("display", "block");
            namedata2.Style.Add("display", "block");
            rduseaddress.SelectedIndex = 0;
        }

        protected void clearselection2()
        {
            cmbAddress.Items.Clear();
            cmbAddress.Value = null;
            cmbAddress.Text = null;

            cmbcontactperson.Items.Clear();
            cmbcontactperson.Value = null;
            cmbcontactperson.Text = null;

            cmbcontact.Items.Clear();
            cmbcontact.Value = null;
            cmbcontact.Text = null;

            cmbemail.Items.Clear();
            cmbemail.Value = null;
            cmbemail.Text = null;

            cmbcinnum.Items.Clear();
            cmbcinnum.Value = null;
            cmbcinnum.Text = null;

            cmbgst.Items.Clear();
            cmbgst.Value = null;
            cmbgst.Text = null;

            hdfsubname.Text = "0";
            cmbSubName.Items.Clear();
            cmbSubName.Value = null;
            cmbSubName.Text = null;

            cmbSubAddress.Items.Clear();
            cmbSubAddress.Value = null;
            cmbSubAddress.Text = null;

            cmbSubContact.Items.Clear();
            cmbSubContact.Value = null;
            cmbSubContact.Text = null;

            cmbsubmail.Items.Clear();
            cmbsubmail.Value = null;
            cmbsubmail.Text = null;

            namedata.Style.Add("display", "block");
            namedata2.Style.Add("display", "block");
            rduseaddress.SelectedIndex = 0;
        }
        protected void clean()
        {
            txtRequestNo.Text = string.Empty;
            cmbNameType.Value = null;
            cmbNameType.Text = null;
            CmbName.Value = null;
            CmbName.Text = null;
            cmbAddress.Value = null;
            cmbAddress.Text = null;
            cmbcontact.Value = null;
            cmbcontact.Text = null;
            cmbcontactperson.Value = null;
            cmbcontactperson.Text = null;
            cmbemail.Value = null;
            cmbemail.Text = null;
            cmbSubName.Text = null;
            cmbSubName.Value = null;
            cmbSubAddress.Text = null;
            cmbSubContact.Text = null;
            cmbsubmail.Text = null;


            cmbcinnum.Value = null;
            cmbcinnum.Text = null;

            cmbGivenBy.SelectedIndex = -1;
            cmbSalesExecutive.Value = null;
            cmbSalesExecutive.Text = null;
            othergivenby.Style.Add("display", "none");
            salesex.Style.Add("display", "none");

            //lblAddress.Text = "";
            //lblContactPerson.Text = "";
            //lblContactNo.Text = "";
            //lblEmail.Text = "";
            //lblGSTNo.Text = "";
            //lblCINNo.Text = "";

            hdfsubname.Text = "0";
            txtGivenByOther.Text = string.Empty;
            lbslno.Text = "0";
            hfReferSheetDelete.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            hfVisitingImageDelete.Text = string.Empty;
            hfShopPhotoDelete.Text = string.Empty;
            hfVisitingImage.Text = string.Empty;
            hfShopPhoto.Text = string.Empty;
            cmbgst.Text = null;
            cmbSubmitby.Value = null;
            cmbSubmitby.Text = null;
            txtapproveby.Text = string.Empty;

            foreach (GridViewRow row in gvDetails.Rows)
            {
                TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                TextBox hfImagenameDelete = (TextBox)row.FindControl("hfImagenameDelete");

                hfImagename.Text = string.Empty;
                hfImagenameDelete.Text = string.Empty;
            }

            namedata.Style.Add("display", "block");
            namedata2.Style.Add("display", "block");
            rduseaddress.SelectedIndex = 0;

            cleanChild(0);

            ASPxPageControl1.ActiveTabIndex = 1;
            gvHead.DataBind();

            BindGridview();

            CmdSaveAsDraft.Visible = true;
            btnSubmit.Visible = true;
            CmdReset.Visible = true;
        }

        /// <summary>
        /// Clean Child Values
        /// </summary>
        /// <param name="rowid"></param>
        protected void cleanChild(int rowid)
        {
            checkViewFile();

            foreach (GridViewRow row in gvDetails.Rows)
            {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ClearChild('" + row.ClientID.ToString() + "');", true);
                TextBox txtSizeInch = (TextBox)row.FindControl("txtSizeInch");
                TextBox txtSizeHeight = (TextBox)row.FindControl("txtSizeHeight");
                TextBox lblCJobTypeId = (TextBox)row.FindControl("lblCJobTypeId");
                TextBox lblimgreq = (TextBox)row.FindControl("lblimgreq");
                TextBox lblaprreq = (TextBox)row.FindControl("lblaprreq");
                DropDownList ddlTypeofJob = (DropDownList)row.FindControl("ddlTypeofJob");
                TextBox hfddlSubJob = (TextBox)row.FindControl("hfddlSubJob");
                TextBox hfddlSubSubJob = (TextBox)row.FindControl("hfddlSubSubJob");
                Label lblDesignType = (Label)row.FindControl("lblDesignType");
                DropDownList ddlDesignType = (DropDownList)row.FindControl("ddlDesignType");
                Label lblProductType = (Label)row.FindControl("lblProductType");
                DropDownList ddlProductType = (DropDownList)row.FindControl("ddlProductType");
                TextBox txtQty = ((TextBox)row.FindControl("txtQty"));
                TextBox txtInstallAddress = ((TextBox)row.FindControl("txtInstallAddress"));
                TextBox txtRemark = ((TextBox)row.FindControl("txtRemark"));
                TextBox txtemail = ((TextBox)row.FindControl("txtmail"));
                TextBox txtlink = ((TextBox)row.FindControl("txtlink"));
                TextBox lblchkisapprov = ((TextBox)row.FindControl("lblchkisapprov"));
                CheckBox chkisapprov = ((CheckBox)row.FindControl("chkisapprov"));
                TextBox lblchkisplace = ((TextBox)row.FindControl("lblchkisplace"));
                CheckBox chkisplace = ((CheckBox)row.FindControl("chkisapprov"));
                TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                HiddenField hfslnochild = (HiddenField)row.FindControl("hfslnochild");


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
                    txtSizeInch.Text = string.Empty;
                    txtSizeHeight.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtInstallAddress.Text = string.Empty;
                    txtRemark.Text = string.Empty;
                    hfImagename.Text = string.Empty;
                    chkisapprov.Checked = false;
                    ddlTypeofJob.SelectedIndex = 0;
                    txtemail.Text = string.Empty;
                    txtlink.Text = string.Empty;
                    hfddlSubJob.Text = string.Empty;
                    hfddlSubSubJob.Text = string.Empty;
                    lblCJobTypeId.Text = string.Empty;
                    lblimgreq.Text = string.Empty;
                    lblaprreq.Text = string.Empty;
                    ddlDesignType.SelectedIndex = 0;
                    lblProductType.Text = string.Empty;
                    lblDesignType.Text = string.Empty;
                    ddlProductType.SelectedIndex = 0;
                    hfslnochild.Value = "0";

                    ddlUnit.SelectedIndex = 0;
                    lblUnit.Text = string.Empty;

                    ddlPriority.SelectedIndex = 0;
                    lblPriority.Text = string.Empty;


                    hfddlBoardType.Text = string.Empty;
                    hfIsPrintReq.Value = string.Empty;
                    hfIsFabReq.Value = string.Empty;

                    ddlPrintLocation.SelectedIndex = 0;
                    lblPrinterLocation.Text = string.Empty;
                    ddlFabricatorLocation.SelectedIndex = 0;
                    lblFabricatorLocation.Text = string.Empty;
                }
                else if (Convert.ToInt32(rowid) == 0)
                {
                    txtSizeInch.Text = string.Empty;
                    txtSizeHeight.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtInstallAddress.Text = string.Empty;
                    txtRemark.Text = string.Empty;
                    txtlink.Text = string.Empty;
                    hfImagename.Text = string.Empty;
                    chkisapprov.Checked = false;
                    ddlTypeofJob.SelectedIndex = 0;
                    hfddlSubJob.Text = string.Empty;
                    hfddlSubSubJob.Text = string.Empty;
                    ddlDesignType.SelectedIndex = 0;
                    ddlProductType.SelectedIndex = 0;
                    hfslnochild.Value = "0";

                    ddlUnit.SelectedIndex = 0;
                    lblUnit.Text = string.Empty;

                    ddlPriority.SelectedIndex = 0;
                    lblPriority.Text = string.Empty;

                    hfddlBoardType.Text = string.Empty;
                    hfIsPrintReq.Value = string.Empty;
                    hfIsFabReq.Value = string.Empty;

                    ddlPrintLocation.SelectedIndex = 0;
                    lblPrinterLocation.Text = string.Empty;
                    ddlFabricatorLocation.SelectedIndex = 0;
                    lblFabricatorLocation.Text = string.Empty;
                }
            }
        }


        protected void clean2()
        {
            txtRequestNo.Text = string.Empty;
            cmbNameType.Value = null;
            cmbNameType.Text = null;
            CmbName.Value = null;
            CmbName.Text = null;
            cmbAddress.Value = null;
            cmbAddress.Text = null;
            cmbcontact.Value = null;
            cmbcontact.Text = null;
            cmbcontactperson.Value = null;
            cmbcontactperson.Text = null;
            cmbemail.Value = null;
            cmbemail.Text = null;
            cmbSubName.Text = null;
            cmbSubName.Value = null;
            cmbSubAddress.Text = null;
            cmbSubContact.Text = null;
            cmbsubmail.Text = null;

            cmbcinnum.Value = null;
            cmbcinnum.Text = null;
            hdfsubname.Text = "0";
            cmbGivenBy.SelectedIndex = -1;
            cmbSalesExecutive.Value = null;
            cmbSalesExecutive.Text = null;
            txtGivenByOther.Text = string.Empty;

            othergivenby.Style.Add("display", "none");
            salesex.Style.Add("display", "none");

            lbslno.Text = "0";
            hfReferSheetDelete.Text = string.Empty;
            hfReferSheet.Text = string.Empty;
            hfVisitingImageDelete.Text = string.Empty;
            hfShopPhotoDelete.Text = string.Empty;
            hfVisitingImage.Text = string.Empty;
            hfShopPhoto.Text = string.Empty;
            cmbgst.Text = null;
            cmbSubmitby.Value = null;
            cmbSubmitby.Text = null;
            txtapproveby.Text = string.Empty;

            namedata.Style.Add("display", "block");
            namedata2.Style.Add("display", "block");
            rduseaddress.SelectedIndex = 0;

            foreach (GridViewRow row in gvDetails.Rows)
            {
                TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                TextBox hfImagenameDelete = (TextBox)row.FindControl("hfImagenameDelete");

                hfImagename.Text = string.Empty;
                hfImagenameDelete.Text = string.Empty;
            }

            cleanChild(0);


            gvHead.DataBind();
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

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Transaction_JobRequest_{0}", DateTime.Now.ToString());
        }

        #endregion Private Methods

        #endregion Methods

        #region Events

        protected void ddlGivenBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGivenBy.SelectedItem != null && cmbGivenBy.SelectedItem.Value != null)
            {
                if (cmbGivenBy.SelectedItem.Value.ToString() == "1")
                {
                    salesex.Style.Add("display", "block");
                    othergivenby.Style.Add("display", "none");
                    txtGivenByOther.Text = string.Empty;
                }
                if (cmbGivenBy.SelectedItem.Value.ToString() == "2")
                {
                    othergivenby.Style.Add("display", "block");
                    salesex.Style.Add("display", "none");
                    cmbSalesExecutive.SelectedIndex = -1;
                }
            }
            else
            {
                othergivenby.Style.Add("display", "none");
                salesex.Style.Add("display", "none");
                cmbSalesExecutive.SelectedIndex = -1;
                txtGivenByOther.Text = string.Empty;
            }
        }

        protected void cmbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            clean2();
            LoadPrintFabLocation();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (e.Tab.Index == 0)
            {
                txtRequestNo.Text = "It will be system generated";
                txtDate.Text = DateTime.Now.ToString();
            }
            else if (e.Tab.Index == 1)
            {
                gvHead.DataBind();
            }
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
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


                string boardtypes = "<select title='Board Type' onchange='checkprintandfabedit(this.id,this)' id='ddlBoardType_" + ddlTypeofJob.ClientID + "' name ='ddlBoardType_" + ddlTypeofJob.ClientID + "' style='width:110px' class='form-control-grid'> <option value='0'>Select</option>";

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


                string lblPartyApprovalTo = (e.Row.FindControl("lblPartyApprovalTo") as Label).Text;

                if (!string.IsNullOrEmpty(lblPartyApprovalTo))
                {
                    DropDownList1.Items.FindByValue(lblPartyApprovalTo).Selected = true;
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

                CheckBox chkisplace = (CheckBox)e.Row.FindControl("chkisplace");
                TextBox lblchkisplace = (TextBox)e.Row.FindControl("lblchkisplace");

                if (lblchkisplace.Text == "False" || string.IsNullOrEmpty(lblchkisplace.Text))
                {
                    chkisplace.Checked = false;
                }
                else
                {
                    chkisplace.Checked = true;
                }
                HiddenField hfslnochild = (HiddenField)e.Row.FindControl("hfslnochild");

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
                    }
                }

                //fill image
                TextBox hfImagename = (TextBox)e.Row.FindControl("hfImagename");
                LinkButton CmdlnkImage3 = (LinkButton)e.Row.FindControl("CmdlnkImage3");

                string hfimg = hfImagename.Text.Replace(",", string.Empty);
                if (hfimg == string.Empty)
                {
                    CmdlnkImage3.Text = string.Empty;
                }
                else
                {
                    CmdlnkImage3.Text = "View Files";
                    // isimgreq.Text = "True";
                }
                repType.Value = "3";
            }
        }

        protected void gvHead_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
        }

        /// <summary>
        /// For reset the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }

        /// <summary>
        /// For cancel the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        /// <summary>
        /// Used for delete job request
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
        /// Used for delete child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdDeleteChild_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = 0;

            string s = e.CommandArgument.ToString();

            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                FieldTripID = Convert.ToInt32(e.CommandArgument);
                Data.JobRequest.JobRequestModel.JobRequestProperties param1 = new Data.JobRequest.JobRequestModel.JobRequestProperties();
                //child srno
                param1.slno = Convert.ToInt32(FieldTripID);
                //head slno
                param1.refid = lbslno.Text;
                param1.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                param1.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                Core.JobRequest.JobRequest objdelete = new Core.JobRequest.JobRequest();
                rows = objdelete.DeleteJobRequestChildCore(param1);
                if (rows == 1)
                {
                    cleanChild(Convert.ToInt32(e.CommandArgument.ToString()));
                    //MessageBox("Delete Successfull !", "Success");
                }
                else if (rows == 2)
                {
                    // MessageBox("Atleast one data required.", "Warning");
                }
                else
                {
                    //MessageBox("Data present delete not permit !", "Warning");
                }
            }

            lbslno.Text = FieldTripID.ToString();
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
            this.mpeImage1.Show();
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

        protected void RptDocs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();

            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");

            if (repType.Value == "1")
            {
                hfVisitingImage.Text = hfVisitingImage.Text.Trim().Replace(hfImgIName.Value + ',', string.Empty);
                hfVisitingImageDelete.Text = hfVisitingImageDelete.Text + ',' + hfImgIName.Value;
            }
            else if (repType.Value == "2")
            {
                hfReferSheet.Text = hfReferSheet.Text.Trim().Replace(hfImgIName.Value + ',', string.Empty);
                hfReferSheetDelete.Text = hfReferSheetDelete.Text + ',' + hfImgIName.Value;
            }
            else if (repType.Value == "3")
            {
                foreach (GridViewRow row in gvDetails.Rows)
                {
                    TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                    TextBox hfImagenameDelete = (TextBox)row.FindControl("hfImagenameDelete");
                    if (hfImagename.Text.Contains(hfImgIName.Value))
                    {
                        hfImagenameDelete.Text = hfImagenameDelete.Text + ',' + hfImgIName.Value;
                    }

                    hfImagename.Text = hfImagename.Text.Trim().Replace(hfImgIName.Value + ',', string.Empty);
                }
            }
            if (repType.Value == "4")
            {
                hfShopPhoto.Text = hfShopPhoto.Text.Trim().Replace(hfImgIName.Value + ',', string.Empty);
                hfShopPhotoDelete.Text = hfShopPhotoDelete.Text + ',' + hfImgIName.Value;
            }
            e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;

            this.mpeImage.Show();
        }

        protected void RptDocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");

            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg") || hfImgIName.Value.Contains(".xls"))
            {
                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/JobRequest/VisitingCard/"), hfImgIName.Value)))
                {
                    imgDocs.ImageUrl = "~/Upload/JobRequest/VisitingCard/" + hfImgIName.Value.Replace(".jpeg", ".jpg");
                    hyLink.NavigateUrl = "~/Upload/JobRequest/VisitingCard/" + hfImgIName.Value.Replace(".jpeg", ".jpg");
                }

                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/JobRequest/ReferSheet"), hfImgIName.Value)))
                {
                    imgDocs.ImageUrl = "~/images/ExcelIcon.jpg";
                    imgDocs.ToolTip = "Download Excel";
                    hyLink.NavigateUrl = "~/Upload/JobRequest/ReferSheet/" + hfImgIName.Value;
                }

                if (File.Exists(Path.Combine(Server.MapPath("~/Upload/JobRequest/BrandImage"), hfImgIName.Value)))
                {
                    imgDocs.ImageUrl = "~/Upload/JobRequest/BrandImage/" + hfImgIName.Value.Replace(".jpeg", ".jpg");
                    hyLink.NavigateUrl = "~/Upload/JobRequest/BrandImage/" + hfImgIName.Value.Replace(".jpeg", ".jpg");
                }
            }

            repType.Value = "3";
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
           else if (repType.Value == "4")
            {
                string hfimf = hfShopPhoto.Text;
                if (!string.IsNullOrEmpty(hfimf.Replace(",", string.Empty)))
                {
                    lnkFiles4.Text = "View Files";
                }
                else
                {
                    lnkFiles4.Text = string.Empty;
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
        /// Work for submit or update and  work as save as draft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdSaveAsDraft_Click(object sender, EventArgs e)
        {
            SaveAsDraft("0");
        }

        /// <summary>
        /// Work for submit or update and  work as sumbit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Load name on change of name type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void CmbNameType_Callback(object source, CallbackEventArgsBase e)
        {
            LoadName();
        }

        /// <summary>
        /// Load Address on change of name
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cmbName_Callback(object source, CallbackEventArgsBase e)
        {
            LoadNameData();
            LoadSubName();
        }

        protected void cmbSubName_Callback(object source, CallbackEventArgsBase e)
        {
            LoadSubAddress();
            LoadSubContact();
            LoadSubEmail();
        }

        /// <summary>
        /// Load address on change of contactperson
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cmbAddress_Callback(object source, CallbackEventArgsBase e)
        {
            // LoadContactPerson();
        }

        /// <summary>
        /// Load Mobile on change of contactperson
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cmbContactPerson_Callback(object source, CallbackEventArgsBase e)
        {
            // LoadContactMobile();
        }

        /// <summary>
        /// Load Email on the change of contact
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cmbContact_Callback(object source, CallbackEventArgsBase e)
        {
            // LoadEmail();
        }


        /// <summary>
        /// Used After Edir and delete task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
            show();
        }

        /// <summary>
        /// Get the Address using radio button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void txtQty_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox ddl = (TextBox)sender;
        //    GridViewRow row = (GridViewRow)ddl.NamingContainer;
        //    TextBox txtaddress = (TextBox)row.FindControl("txtInstallAddress");
        //    if (rduseaddress.SelectedValue == "0")
        //    {
        //        txtaddress.Text = cmbAddress.Text;
        //    }
        //    else if(rduseaddress.SelectedValue == "1")
        //    {
        //        txtaddress.Text = cmbSubAddress.Text;
        //    }
        //    else
        //    {
        //        txtaddress.Text = "";
        //    }
        //}

        protected void rduseaddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvDetails.Rows)
            {
                TextBox txtInstallAddress = (TextBox)row.FindControl("txtInstallAddress");
                TextBox txtqty = (TextBox)row.FindControl("txtQty");
                if (txtqty.Text != string.Empty)
                {
                    if (rduseaddress.SelectedValue == "0")
                    {
                        txtInstallAddress.Text = cmbAddress.Text;
                    }
                    else if (rduseaddress.SelectedValue == "1")
                    {
                        txtInstallAddress.Text = cmbSubAddress.Text;
                    }
                    else
                    {
                        txtInstallAddress.Text = string.Empty;
                    }
                }
                else
                {
                    txtInstallAddress.Text = string.Empty;
                }
            }
        }
        protected void btnaddorg_Click(object sender, EventArgs e)
        {
            SaveOrg();
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

        protected void rptImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
            if (e.CommandName == "cmdRemove")
            {
                hfVisitingImage.Text = hfVisitingImage.Text.Trim().Replace(hfImgIName.Value, "");
                hfVisitingImageDelete.Text = hfVisitingImageDelete.Text + ',' + hfImgIName.Value;

              

                e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                this.mpeImage.Show();
            }
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
            if (e.CommandName == "cmdRemove")
            {
                hfReferSheet.Text = hfReferSheet.Text.Trim().Replace(hfImgIName.Value, "");
                hfReferSheetDelete.Text = hfReferSheetDelete.Text + ',' + hfImgIName.Value;
                e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                this.mpeImage1.Show();
            }
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
        }
        protected void rptImages2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
            if (e.CommandName == "cmdRemove")
            {

                foreach (GridViewRow row in gvDetails.Rows)
                {
                    TextBox hfImagename = (TextBox)row.FindControl("hfImagename");
                    TextBox hfImagenameDelete = (TextBox)row.FindControl("hfImagenameDelete");

                    hfImagename.Text = hfImagename.Text.Trim().Replace(hfImgIName.Value, "");
                    hfImagenameDelete.Text = hfImagenameDelete.Text + ',' + hfImgIName.Value;
                    e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                    this.mpeImage2.Show();
                }
            }
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

        private string Delete(string file, string folderpath)
        {
            string result = string.Empty;
            //string folderpath = string.Empty;
            string path = string.Empty;
            string[] Files = file.Split(',');
            //folderpath = FILE_DIRECTORY_NAME;
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

        protected void cmbNameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearselection();
            LoadName();
        }

        protected void CmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearselection2();
            LoadNameData();
            LoadSubName();
            //LoadNameDataNew();
            LoadDealerJobHistory();

        }
        public void LoadDealerJobHistory()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();
            
            param.nameid = Convert.ToInt32(CmbName.Value);
            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dt = objselectsingle.GetDealerJobHistoryCore(param);
            gvdetail.DataSource = dt;
            gvdetail.DataBind();



            mpeImagee.Show();


        }
        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 15);
            this.mpeImage3.Show();
            repType.Value = "4";
        }

        protected void rptImages3_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
            if (e.CommandName == "cmdRemove")
            {
              
                hfShopPhoto.Text = hfShopPhoto.Text.Trim().Replace(hfImgIName.Value, "");
                hfShopPhotoDelete.Text = hfShopPhotoDelete.Text + ',' + hfImgIName.Value;

                e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                this.mpeImage3.Show();
            }
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 15);
            }
        }

        protected void rptImages3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            System.Web.UI.WebControls.Image imgDocs = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgDocs");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HyperLink hyLink = (HyperLink)e.Item.FindControl("hyLink");
            HiddenField hfvisible = (HiddenField)e.Item.FindControl("hfvisible");
            var PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfImgIName.Value);

            imgDocs.ImageUrl = PictureIDPath;
            hyLink.NavigateUrl = PictureIDPath;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            this.mpeConfirmPopup.Hide();
            LoadRetailerJobHistory();
        }
        public void LoadRetailerJobHistory()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            param.SubNameId = Convert.ToInt32(cmbSubName.Value);
            Core.JobRequest.JobRequest objselectsingle = new Core.JobRequest.JobRequest();
            DataTable dt = objselectsingle.GetRetailerJobHistoryCore(param);
            gvdetail.DataSource = dt;
            gvdetail.DataBind();



            mpeImagee.Show();


        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            this.mpeConfirmPopup.Hide();
        }

        protected void cmbSubName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.JobRequest.JobRequestModel.DhbApproveStatus dtsingle = new Data.JobRequest.JobRequestModel.DhbApproveStatus();
            dtsingle.slno = Convert.ToInt32(cmbSubName.Value);
            Core.JobRequest.JobRequest objdatastatus = new Core.JobRequest.JobRequest();

            DataTable dt = objdatastatus.StatusOfRetailer(dtsingle);
            if (dt.Rows.Count > 0)
            {
                lblApprovalStatus.Text= Convert.ToString(dt.Rows[0]["ApprovalStatus"]);
                lblCurrentStatus.Text = Convert.ToString(dt.Rows[0]["CurrentStatus"]);
            }
            this.mpeConfirmPopup.Show();
        }

        //code-behind
        protected string GetLinkButtonText(object field)
        {
            // field contains the value of the field specified in the markup
            // check conditions, e.g:
            if (field.ToString() == "Draft" || field.ToString() == "Waiting For Approval")
                return "Edit";
            else
                return "View";
        }

        protected void chkStatecheck_CheckedChanged(object sender, EventArgs e)
        {
            LoadSubName();
        }

        protected void chkmapjob_CheckedChanged(object sender, EventArgs e)
        {
            if(chkmapjob.Checked==true)
            {
                LoadWallSizeJobs(0);


            }
            else
            {
                cmbWallSizeJobs.Items.Clear();
                cmbWallSizeJobs.Value = null;
                cmbWallSizeJobs.Text = null;
            }
        }

        public void LoadWallSizeJobs(int headslno)
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            param.slno = Convert.ToInt32(headslno);
            param.userbranchid = Convert.ToInt32(cmbbranch.Value);
            Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            DataSet dsaselect = objselectsingleselect.AllWallSizeJobRequestBranchHeadDACore(param);

            if (dsaselect.Tables[0].Rows.Count > 0)
            {
                cmbWallSizeJobs.Items.Clear();
                cmbWallSizeJobs.Value = null;
                cmbWallSizeJobs.DataSource = dsaselect.Tables[0];
                cmbWallSizeJobs.TextField = "reqno";
                cmbWallSizeJobs.ValueField = "slno";
                cmbWallSizeJobs.DataBind();

            }


        }



    }
}