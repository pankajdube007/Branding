using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Master.JobTypeMaping
{
    public partial class JobTypeMaping : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int rows = 0;
        private string checkseq = string.Empty, checkdata = string.Empty;

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "Tbl_JobSubJobType_Mapping";
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
                FillSubJobType();
                list2.Items.Clear();
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
           // ASPxGridView1.Columns[1].Visible = false;
            ASPxGridView1.Columns[2].Visible = false;
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
        protected void clean()
        {
            list2.Items.Clear();
            FillJobType();
            FillSubJobType();
        }

        /// <summary>
        /// returns the datatable which contains the all job type mapping records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.JobTypeMaping.JobTypeMaping objselectall = new Core.JobTypeMaping.JobTypeMaping();
            dt4 = objselectall.GetJobTypeMapingAll();
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
                    #region Delete Block

                    Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingDelete ddel = new Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingDelete();
                    ddel.slno = Convert.ToInt32(lbid.Text);
                    ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    Core.JobTypeMaping.JobTypeMaping objdelete = new Core.JobTypeMaping.JobTypeMaping();
                    rows = objdelete.JobTypeMapingDeleteMethod(ddel);
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

                    #endregion Delete Block
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
            cmbJobType.DataSource = JobTypeMapingDt;
            cmbJobType.TextField = "name";
            cmbJobType.ValueField = "slno";
            cmbJobType.SelectedIndex = 0;
            cmbJobType.DataBind();
        }

        /// <summary>
        /// Fille the List box with sub job type
        /// </summary>
        public void FillSubJobType()
        {
            DataTable DesignTypeDt = new DataTable();
            Core.SubJobType.SubJobType objselectall = new Core.SubJobType.SubJobType();
            DesignTypeDt = objselectall.GetSubJobTypeAll();
            list1.DataSource = DesignTypeDt;
            list1.DataBind();
        }

        /// <summary>
        /// Fille the list box name list2 with job type
        /// </summary>
        public void FillSubJobType2()
        {
            DataTable DesignTypeDt = new DataTable();
            Core.SubJobType.SubJobType objselectall = new Core.SubJobType.SubJobType();
            DesignTypeDt = objselectall.GetSubJobTypeAll();
            list2.DataSource = DesignTypeDt;
            list2.DataBind();
        }

        /// <summary>
        /// perform the action of submit   and called by CmdSubmit_Click event
        /// </summary>
        public void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            string error = string.Empty;
            Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert dst = new Data.JobTypeMaping.JobTypeMapingModel.JobTypeMapingInsert();
            var jobtype = HttpUtility.HtmlEncode(cmbJobType.Value);
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(jobtype)))
            {
                error += "Job Type Should not be empty.!</br>";
            }
            else if (list2.Items.Count <= 0)
            {
                error += "Please Map atleast one Sub job type with Job type.!</br>";
            }
            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    dst.jobtypeid = Convert.ToInt32(jobtype);
                    dst.subjobtypeid = Convert.ToInt32(list2.Items[i].Value);
                    dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                    dst.pagename = HttpContext.Current.Request.Url.ToString();
                    Core.JobTypeMaping.JobTypeMaping objinsert = new Core.JobTypeMaping.JobTypeMaping();
                    result = objinsert.JobTypeMapingInsertMethod(dst);
                }
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Type maping added successfully !','success',3);", true);
                    ASPxPageControl1.ActiveTabIndex = 0;
                    clean();
                }
                if (result == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Type maping added successfully !','success',3);", true);
                    ASPxPageControl1.ActiveTabIndex = 0;
                    clean();
                }
            }
        }

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_JobType_SubJobType_Mapping_{0}", DateTime.Now.ToString());
        }

        /// <summary>
        /// perform the reset action and called by CmdReset_Click event
        /// </summary>

        #endregion Method

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
        /// Use for shifting one record from listbox 1 to list box 2
        /// </summary>
        /// <returns></returns>
        protected void btnadd_Click(object sender, EventArgs e)
        {
            int index = list1.SelectedIndex;
            if (index >= 0)
            {
                list2.Items.Add(list1.Items[list1.SelectedIndex]);

            list1.Items.Remove(list1.Items[list1.SelectedIndex]);
            list2.ClearSelection();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Select Atleast one option.','error',3);", true);
                
            }
        }

        /// <summary>
        /// Use for shifting All record from listbox 1 to list box 2
        /// </summary>
        /// <returns></returns>
        protected void btnaddall_Click(object sender, EventArgs e)
        {
            FillSubJobType2();
            list1.Items.Clear();
        }

        /// <summary>
        /// Use for shifting one record from listbox 2 to list box 1
        /// </summary>
        /// <returns></returns>
        protected void btnremove_Click(object sender, EventArgs e)
        {
            int index = list2.SelectedIndex;
            if (index >= 0)
            {
                list1.Items.Add(list2.Items[list2.SelectedIndex]);

            list2.Items.Remove(list2.Items[list2.SelectedIndex]);
            list1.ClearSelection();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Select Atleast one option.','error',3);", true);
            }
        }

        /// <summary>
        /// Use for shifting all record from listbox 2 to list box 1
        /// </summary>
        /// <returns></returns>
        protected void btnremoveall_Click(object sender, EventArgs e)
        {
            FillSubJobType();
            list2.Items.Clear();
        }

        /// <summary>
        /// Bind the grid viwe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }

        #endregion Event
    }
}