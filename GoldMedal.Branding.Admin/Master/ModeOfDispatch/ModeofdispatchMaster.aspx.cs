using DevExpress.Web;
using GoldMedal.Branding.Core.Common;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.Printer;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Master.ModeOfDispatch
{
    public partial class ModeofdispatchMaster : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private DataTable dts = new DataTable();
        private string FileName = string.Empty;
        private IExport xpt = null;
        private int rows = 0;
        private int totval = 0;

        PrinterDataAccess da = new PrinterDataAccess();

        #endregion Initialization

        #region Edit Block - Variable

        private string html = string.Empty;
        private string overwriteStr = string.Empty;
        private string TableNm = "tbl_fabricator";
        private string Node = "Master";

        #endregion Edit Block - Variable

      

        /// <summary>
        /// In the Page Lode lblslno is 0 by which program deside the process of submit button which can be submit the record or update the record and also lode the grid and combobox of area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Session.Timeout = 7200;
           
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    
                    ASPxGridView1.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
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
        protected void clean()
        {
            lbslno.Text = "0";
            chkstatus.Checked = false;
          
            txtmobno.Text = string.Empty;
            txtname.Text = string.Empty;
           txtshortname.Text = string.Empty;
        }
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
        /// <summary>
        /// Hide the unnecessary column during export
        /// </summary>
        protected void columnhide()
        {
            ASPxGridView1.Columns[6].Visible = false;
            ASPxGridView1.Columns[7].Visible = false;
        }

        /// <summary>
        /// Show those column which have hidden during the export
        /// </summary>
        protected void columnshow()
        {
            ASPxGridView1.Columns[6].Visible = true;
            ASPxGridView1.Columns[7].Visible = true;
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }
        private DataTable GetTable1()
        {
            DataTable dt4 = new DataTable();
            Core.Fabricator.Fabricator objselectall = new Core.Fabricator.Fabricator();
            dt4 = objselectall.GetListForModeofDispatch();
            return dt4;
        }
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

            CheckEditBlock("Edit", Convert.ToInt32(lbslno.Text));
        }

        protected void CmdDelete_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();

           

            CheckEditBlock("Delete", FieldTripID);
        }
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            int result2 = 0;
            int errorresulr = 0;
            bool status;
            string error = string.Empty;
            Data.Fabricator.FabricatorModel.FabricatorInsert dst = new Data.Fabricator.FabricatorModel.FabricatorInsert();
           
            var Name = HttpUtility.HtmlEncode(txtname.Text.Trim());
            var Shortname = HttpUtility.HtmlEncode(txtshortname.Text.Trim());
            var mobile = HttpUtility.HtmlEncode(txtmobno.Text.Trim());
            var Modeofdispatch = HttpUtility.HtmlEncode(cmbMode.Value);
            if (chkstatus.Checked == true)
            {
                status = Convert.ToBoolean(1);
            }
            else
            {
                status = Convert.ToBoolean(0);
            }

          
            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(Name)))
            {
                error += "Name Should not be empty.!</br>";
            }
           

            if (string.IsNullOrEmpty(ValidateDataType.EnsureNotNull(mobile)))
            {
                error += "Mobile Should not be empty.!</br>";
            }
           



            if (error != string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + error + "','warning',3);", true);
            }
            else
            {
               
                dst.Name = ValidateDataType.EnsureMaximumLength(Name, 100);
                dst.ShortName = ValidateDataType.EnsureMaximumLength(Shortname, 50);
                dst.mobile = mobile;
                dst.Modeofdispatch = Convert.ToInt32(Modeofdispatch);
                dst.Status = status;
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.slno = Convert.ToInt32(lbslno.Text);
               
               
                Core.Fabricator.Fabricator objinsert = new Core.Fabricator.Fabricator();
                result = objinsert.ModeofDispatchAddUpdate(dst);
                if (result == -2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Record already exists !','warning',3);", true);
                 
                    clean();
                }
                else if (result == -1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                   
                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                }
              
                else
                {
                    if(lbslno.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mode Of Dispatch added successfully !','success',3);", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Mode Of Dispatch updated successfully !','success',3);", true);

                    }
                       
                    
                   
                    clean();
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
            }
        }
        protected void CheckEditBlock(string param, int id)
        {
            string str = string.Empty;
           
               
                    if (param == "Delete")
                    {
                        #region Delete Block

                        Data.Fabricator.FabricatorModel.FabricatorDelete ddel = new Data.Fabricator.FabricatorModel.FabricatorDelete();
                        ddel.slno = Convert.ToInt32(lbslno.Text);
                        ddel.Createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        Core.Fabricator.Fabricator objdelete = new Core.Fabricator.Fabricator();
                        rows = objdelete.DeleteModeofDispatch(ddel);
                        if (rows == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull !','success',3);", true);
                            ASPxGridView1.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit !','warning',3);", true);
                            clean();
                        }

                        #endregion Delete Block
                    }
                    else
                    {
                        #region Edit Block

                        Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle = new Data.Fabricator.FabricatorModel.FabricatorInsert();
                        dtsingle.slno = Convert.ToInt32(lbslno.Text);
                        Core.Fabricator.Fabricator objselectsingle = new Core.Fabricator.Fabricator();
                        DataTable dt = objselectsingle.GetSingleModeofDispatch(dtsingle);
                        if (dt.Rows.Count > 0)
                        {
                            txtname.Text = Convert.ToString(dt.Rows[0]["Name"]);
                            txtshortname.Text = Convert.ToString(dt.Rows[0]["ShortName"]);
                            lbslno.Text = Convert.ToString(dt.Rows[0]["Slno"]);
                            txtmobno.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                            cmbMode.SelectedItem = cmbMode.Items.FindByValue(Convert.ToString(dt.Rows[0]["ModeofDispatch"]));

                    if (Convert.ToString(dt.Rows[0]["Status"]) == "False")
                            {
                                chkstatus.Checked = false;
                            }
                            else
                            {
                                chkstatus.Checked = true;
                            }
                           
                           
                           
                        }
                        else
                        {
                            #region Edit Block - Code

                           

                            #endregion Edit Block - Code

                            lbslno.Text = "0";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
                        }

                        ASPxPageControl1.ActiveTabIndex = 0;

                        #endregion Edit Block
                    }
                
                
            
           
        }
        #region Export

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        /// 
        protected string GetFileName()
        {
            return string.Format("Master_Mode_Of_Dispatch_{0}", DateTime.Now.ToString());
        }
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            columnhide();
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);
            columnshow();
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
        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
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

        #endregion Export

        protected void CmdSubmit_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {

        }

        protected void CmdReset_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}