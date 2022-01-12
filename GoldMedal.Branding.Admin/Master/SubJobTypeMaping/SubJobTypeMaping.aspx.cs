using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Master.SubJobTypeMaping
{
    public partial class SubJobTypeMaping : System.Web.UI.Page
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
        private string TableNm = "Tbl_SubJobsubsubjobType_Mapping";
        private string Node = "Master";

        #endregion Edit Block - Variable

        #region Page Event

        /// <summary>
        /// The combo box for the Subjob type , the list box for the  Sub sub job type and  grid  for the records is filled here
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
                    FillSubJobType();
                FillSubSubJobType();
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

        #region Export
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
            //  ASPxGridViewExporter1.WriteCsvToResponse();
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

        /// <summary>
        /// Event  performs clean method
        /// </summary>
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
        /// Bind the grid viwe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
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
           
                FillSubSubJobType2();
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
           
                FillSubSubJobType();
                list2.Items.Clear();
            
        }

        #endregion Event

        #region Method

        /// <summary>
        /// Set The file name during the export.
        /// </summary>
        /// <returns></returns>
        protected string GetFileName()
        {
            return string.Format("Master_SubJobType_SubSubJobType_Mapping_{0}", DateTime.Now.ToString());
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
            lbid.Text = "0";
            list2.Items.Clear();
            FillSubJobType();
            FillSubSubJobType();
        }

        /// <summary>
        /// returns the datatable which contains the all job type mapping records
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.SubJobTypeMaping.SubJobTypeMaping objselectall = new Core.SubJobTypeMaping.SubJobTypeMaping();
            dt4 = objselectall.GetSubJobTypeMapingAll();
            return dt4;
        }

        /// <summary>
        /// Fille the combo box with Sub job type
        /// </summary>
        public void FillSubJobType()
        {
            DataTable SubJobTypeMapingDt = new DataTable();

            Core.SubJobType.SubJobType objselectall = new Core.SubJobType.SubJobType();
            SubJobTypeMapingDt = objselectall.GetSubJobTypeAll();
            cmbSubJobType.DataSource = SubJobTypeMapingDt;
            cmbSubJobType.TextField = "name";
            cmbSubJobType.ValueField = "slno";
            cmbSubJobType.SelectedIndex = 0;
            cmbSubJobType.DataBind();
        }

        /// <summary>
        /// Fille the List box with Subsub job type
        /// </summary>
        public void FillSubSubJobType()
        {
            DataTable DesignTypeDt = new DataTable();

            Core.SubSubJobType.SubSubJobType objselectall = new Core.SubSubJobType.SubSubJobType();
            DesignTypeDt = objselectall.GetSubSubJobTypeAll();
            list1.DataSource = DesignTypeDt;
            list1.DataBind();
        }

        /// <summary>
        /// Fille the List box 2 with Sub sub job type
        /// </summary>
        public void FillSubSubJobType2()
        {
            DataTable DesignTypeDt = new DataTable();
            Core.SubSubJobType.SubSubJobType objselectall = new Core.SubSubJobType.SubSubJobType();
            DesignTypeDt = objselectall.GetSubSubJobTypeAll();
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
            Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert dst = new Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingInsert();
            var subjobtype = HttpUtility.HtmlEncode(cmbSubJobType.Value);
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(subjobtype)))
            {
                error += "SubJob Type Should not be empty.!</br>";
            }
            else if (list2.Items.Count <= 0)
            {
                error += "Please Map atleast one Material with Sub job type.!</br>";
            }

            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    dst.subjobtypeid = Convert.ToInt32(subjobtype);
                    dst.subsubjobtypeid = Convert.ToInt32(list2.Items[i].Value);
                    dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                    dst.pagename = HttpContext.Current.Request.Url.ToString();
                    Core.SubJobTypeMaping.SubJobTypeMaping objinsert = new Core.SubJobTypeMaping.SubJobTypeMaping();
                    result = objinsert.SubJobTypeMapingInsertMethod(dst);
                }
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','SubJob Type maping added successfully !','success',3);", true);
                    clean();
                }
                if (result == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mapping already exist !','warning',3);", true);
                    clean();
                }
            }
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
                dstreset.slno = ValidateDataType.EnsureMaximumLength(lbid.Text, 100);
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
            dst.slno = ValidateDataType.EnsureMaximumLength(lbid.Text, 100);
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

                    Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingDelete ddel = new Data.SubJobTypeMaping.SubJobTypeMapingModel.SubJobTypeMapingDelete();
                    ddel.slno = Convert.ToInt32(lbid.Text);
                    ddel.createlogno = Convert.ToInt64(Request.Cookies["logno"].Value.ToString());   //changed by gaurav
                    ddel.Createuid = Convert.ToInt32(Request.Cookies["userlogid"].Value.ToString()); //changed by gaurav

                    //Commented by gaurav
                    //ddel.createlogno = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["logno"].Value))));
                    //ddel.Createuid = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["userlogid"].Value))));

                    Core.SubJobTypeMaping.SubJobTypeMaping objdelete = new Core.SubJobTypeMaping.SubJobTypeMaping();
                    rows = objdelete.SubJobTypeMapingDeleteMethod(ddel);
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

        #endregion Method
    }
}