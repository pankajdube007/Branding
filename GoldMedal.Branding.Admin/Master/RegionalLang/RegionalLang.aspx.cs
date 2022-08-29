using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Master.RegionalLang
{
    public partial class RegionalLang : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int rows = 0;
        private int job = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_RegionalLang";
        private string Node = "Master";

        #endregion Edit Block - Variable

        #region Page Event

        /// <summary>
        /// The combo box for the job type , the list box for the  sub job type and  grid  for the records is filled here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    FillJobType();
                    BindBranch();
                    //Clean();
                    ASPxGridView1.DataBind();
                    ASPxPageControl1.ActiveTabIndex = 0;
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }

        #endregion Page Event

        #region Method


        protected void BindBranch()
        {
            Core.RegionalLang.IRegionalLang objselectsingle = new Core.RegionalLang.RegionalLang();
            DataTable dt = objselectsingle.GetBranchAll();

            //param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            //Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            //DataSet dsaselect = objselectsingleselect.AllBranchSelected(param);

            cmbbranch.Items.Clear();
            cmbbranch.Value = null;
            cmbbranch.DataSource = dt;
            cmbbranch.TextField = "locnm";
            cmbbranch.ValueField = "slno";
            cmbbranch.DataBind();
            cmbbranch.Items.Insert(0, new ListEditItem("Select", null));
            cmbbranch.SelectedIndex = 0;

            //if (dsaselect.Tables[0].Rows.Count > 0)
            //{
            //    cmbbranch.SelectedItem = cmbbranch.Items.FindByValue(dsaselect.Tables[0].Rows[0]["homebranchid"].ToString());
            //}

        }

        protected void cmbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbranch.SelectedItem != null && cmbbranch.SelectedItem.Value != null)
            {
                cmbbranch.Value = cmbbranch.SelectedItem.Value;
               // BindBranch();
            }
            else
            {
                cmbbranch.Items.Clear();
            }
            //clean();
            
           // LoadPrintFabLocation();
        }

        protected void cmbJobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJobType.SelectedItem != null && cmbJobType.SelectedItem.Value != null)
            {
                BindSubJobType(Convert.ToInt32(cmbJobType.SelectedItem.Value));
            }
            else
            {
                cmbSubJobType.Items.Clear();
            }
        }

        private void BindSubJobType(int JobTypeID)
        {
            Data.RegionalLang.RegionalLangModel.RegionalLangInsert param = new Data.RegionalLang.RegionalLangModel.RegionalLangInsert();
            param.jobtypeid = Convert.ToInt32(JobTypeID);

            Core.RegionalLang.RegionalLang db = new Core.RegionalLang.RegionalLang();
            DataTable subjobdt = db.GetAllJobTypeForJobType(param);

            cmbSubJobType.Items.Clear();
            cmbSubJobType.Value = null;
            cmbSubJobType.DataSource = subjobdt;
            cmbSubJobType.TextField = "subjobname";
            cmbSubJobType.ValueField = "subjobtypeid";

            cmbSubJobType.DataBind();
            cmbSubJobType.Items.Insert(0, new ListEditItem("Select", null));
            cmbSubJobType.SelectedIndex = 0;

        }

        /// <summary>
        /// Fille the List box with sub job type
        /// </summary>  
        /// 

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
        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[4].Visible = false;
            ASPxGridView1.Columns[5].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[1].Visible = true;
            ASPxGridView1.Columns[2].Visible = true;
        }

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>
        /// 
        protected void clean()
        {
            lbid.Text = "0";
            //cmbSubJobType.Items.Clear();
            cmbSubJobType.SelectedIndex = 0;
            cmbSubJobType.Items.Clear();
            cmbJobType.SelectedIndex = 0;
            cmbJobType.Items.Clear();
            cmbbranch.Items.Clear();
            chk.Checked = false;
            BindBranch();
            FillJobType();
            // gvSchemeChild.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }
        /// <summary>
        /// returns the datatable which contains the all job type mapping records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.RegionalLang.RegionalLang objselectall = new Core.RegionalLang.RegionalLang();
            dt4 = objselectall.RegionalLangAll();
            return dt4;
        }

        /// <summary>
        /// After  delete action this function reset editmode column which indicates that the value is deleteble  or not
        /// </summary>
        ///
        protected void ResetFunc()
        {
            if (lbid.Text != "0")
            {
                Data.CheckEdit.CheckEditModel.CheckEditInsert dstreset = new Data.CheckEdit.CheckEditModel.CheckEditInsert();
                dstreset.slno = lbid.Text;
                dstreset.TableNm = ValidateDataType.EnsureMaximumLength(TableNm, 100);
                Core.CheckEdit.CheckEdit objselectall = new Core.CheckEdit.CheckEdit();
                string resetSts = objselectall.ResetEditStatus(dstreset);
            }
        }
        protected void CmdEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbid.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Edit", Convert.ToInt32(lbid.Text));

            #endregion Edit Block - Code
        }
        /// <summary>
        /// Used in delete  action for tarcking data is deletable or not
        /// </summary>
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
            dst.slno = lbid.Text;
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

                        Data.RegionalLang.RegionalLangModel.RegionalLangDelete ddel = new Data.RegionalLang.RegionalLangModel.RegionalLangDelete();
                        ddel.slno = Convert.ToInt32(lbid.Text);
                        ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.RegionalLang.RegionalLang objdelete = new Core.RegionalLang.RegionalLang();
                        rows = objdelete.RegionalLangDeleteMethod(ddel);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull ! !','success',3);", true);
                            ASPxGridView1.DataBind();
                            clean();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit','warning',3);", true);
                            clean();
                        }
                    }
                    #endregion Delete Block
                    else
                    {
                        #region Edit Block

                        Data.RegionalLang.RegionalLangModel.RegionalLangInsert dtsingle = new Data.RegionalLang.RegionalLangModel.RegionalLangInsert();
                        dtsingle.slno = Convert.ToInt32(lbid.Text);
                        Core.RegionalLang.RegionalLang objselectsingle = new Core.RegionalLang.RegionalLang();
                        DataTable dt = objselectsingle.GetRegionalLangTypeSingle(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            cmbJobType.Value = Convert.ToString(dt.Rows[0]["jobtypeid"]);
                            BindSubJobType(Convert.ToInt32(dt.Rows[0]["jobtypeid"]));
                            cmbSubJobType.Value = Convert.ToString(dt.Rows[0]["subjobtypeid"]);
                            cmbbranch.Value = Convert.ToString(dt.Rows[0]["branchId"]);
                            chk.Checked = Convert.ToBoolean(dt.Rows[0]["isactive"]);
                            lbid.Text = Convert.ToString(dt.Rows[0]["slno"]);
                        }
                        else
                        {
                            #region Edit Block - Code

                            ResetFunc();

                            #endregion Edit Block - Code

                            lbid.Text = "0";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
                        }

                        ASPxPageControl1.ActiveTabIndex = 0;

                        #endregion Edit Block
                        #endregion Edit Block
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
                        lbid.Text = "0";
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
                        lbid.Text = "0";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
                    }
                }
                else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Error")
                {
                    lbid.Text = "0";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Error occurred, please refresh and try again.','error',3);", true);
                }
            }
            else
            {
                lbid.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
            }
        }

        /// <summary>
        /// Fille the combo box with job type
        /// </summary>
        public void FillJobType()
        {
            DataTable JobTypeMapingDt = new DataTable();
            Core.JobType.JobType objselectall = new Core.JobType.JobType();
            JobTypeMapingDt = objselectall.GetJobTypeAll();

            cmbJobType.Value = null;
            cmbJobType.DataSource = JobTypeMapingDt;
            cmbJobType.TextField = "name";
            cmbJobType.ValueField = "slno";

            cmbJobType.DataBind();
            cmbJobType.Items.Insert(0, new ListEditItem("Select", null));
            cmbJobType.SelectedIndex = 0;
        }



        /// <summary>
        /// perform the action of submit   and called by CmdSubmit_Click event
        /// </summary>
        public void DataInsert()
        {
            string msg = string.Empty;
            Data.RegionalLang.RegionalLangModel.RegionalLangInsert dst = new Data.RegionalLang.RegionalLangModel.RegionalLangInsert();
            int result = 0;
            bool isactive;
            string error = string.Empty;

            if (chk.Checked == true)
            {
                isactive = Convert.ToBoolean(1);
            }
            else
            {
                isactive = Convert.ToBoolean(0);
            }

            var jobtype = HttpUtility.HtmlEncode(cmbJobType.Value);
            var subjobtype = HttpUtility.HtmlEncode(cmbSubJobType.Value);
            var branch = HttpUtility.HtmlEncode(cmbbranch.Value);

            //dst.Name = ValidateDataType.EnsureMaximumLength(name, 100);
            dst.BranchID = Convert.ToInt16(cmbbranch.Value);
            dst.jobtypeid = Convert.ToInt16(cmbJobType.Value);
            dst.subjobtypeid = Convert.ToInt16(cmbSubJobType.Value);
            dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
            dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dst.pagename = HttpContext.Current.Request.Url.ToString();
            dst.slno = Convert.ToInt16(lbid.Text);
            dst.isactive = isactive;
            dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(branch)))
            {
                error += "Branch  Should not be empty.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(jobtype)))
            {
                error += "Job type  Should not be empty.!</br>";
            }
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(subjobtype)))
            {
                error += "Sub job type Should not be empty.!</br>";
            }
            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
                if (lbid.Text == "0")
                {
                    Core.RegionalLang.RegionalLang objinsert = new Core.RegionalLang.RegionalLang();
                    result = objinsert.RegionalLangInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Regional Language Type already exists !','warning',3);", true);
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Regional Langugage Type added successfully !','success',3);", true);
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                    }
                }
                else
                {
                    Core.RegionalLang.RegionalLang objinsert = new Core.RegionalLang.RegionalLang();
                    result = objinsert.RegionalLangInsertMethod(dst);
                    if (result == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Regional Language Type already exists !','warning',3);", true);
                        ASPxPageControl1.ActiveTabIndex = 1;
                        ResetFunc();
                        clean();
                    }
                    else if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Regional Language Updated successfully !','success',3);", true);
                        ResetFunc();
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        ResetFunc();
                        clean();
                    }
                    ResetFunc();
                }

            }
            
        }

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_RegionalLanguage_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>



        #region Export

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

        /// <summary>
        /// Used for export the grid in csv format
        /// </summary>
        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
            // ASPxGridViewExporter1.WriteCsvToResponse();
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);
            columnshow();
        }

        #endregion Export

        #region Event

        /// <summary>
        /// Event  performs clean method
        /// </summary>
        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        /// <summary>
        /// Used for delete the record
        /// </summary>
        protected void CmdDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbid.Text = FieldTripID.ToString();

            #region Edit Block - Code

            CheckEditBlock("Delete", FieldTripID);

            #endregion Edit Block - Code

            ResetFunc();
            clean();
        }

        /// <summary>
        /// Event perform submit  action using DataInsert method
        /// </summary>
        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
        }



        /// <summary>
        /// Use for shifting one record from listbox 2 to list box 1
        /// </summary>
        /// <returns></returns>
        protected void btnremove_Click(object sender, EventArgs e)
        {
            //int index = list2.SelectedIndex;
            //if (index >= 0)
            //{
            //    list1.Items.Add(list2.Items[list2.SelectedIndex]);

            //    list2.Items.Remove(list2.Items[list2.SelectedIndex]);
            //    list1.ClearSelection();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Select Atleast one option.','error',3);", true);
            //}
        }

        /// <summary>
        /// Use for shifting all record from listbox 2 to list box 1
        /// </summary>
        /// <returns></returns>
        protected void btnremoveall_Click(object sender, EventArgs e)
        {
            //FillSubJobType();
            //list2.Items.Clear();
        }
        #endregion Event
    }
}