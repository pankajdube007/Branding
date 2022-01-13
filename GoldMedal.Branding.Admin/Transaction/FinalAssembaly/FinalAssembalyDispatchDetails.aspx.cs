using DevExpress.Web;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.FinalAssembaly
{
    public partial class FinalAssembalyDispatchDetails : System.Web.UI.Page
    {
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
        private string strFileTypeVC = string.Empty;
        public string party = string.Empty;
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        private DataTable dtss = new DataTable();
        private int result2 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "3")
                {
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                   
                }
                else
                {

                    Response.Redirect("~/logout.aspx");


                }
            }
        }

        protected void ASPxPageControl1_TabClick(object source, DevExpress.Web.TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }
        private DataTable GetTable1()
        {
            DataTable dt5 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.ListOfJobForFinlaAssemblyDispatchMode(dsp);
            return dt5;
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                ASPxCheckBox chk = ASPxGridView1.FindRowCellTemplateControl(i, ASPxGridView1.Columns["Send"] as GridViewDataColumn, "gvCheck") as ASPxCheckBox;
                if (chk != null)
                {

                    if (chk.Checked == true)
                    {

                        int Slno = Convert.ToInt32(ASPxGridView1.GetRowValues(i, "slno"));
                        int Qty = Convert.ToInt32(ASPxGridView1.GetRowValues(i, "Qty"));
                        if (lbmultipleslno.Text == "0")
                        {
                            lbmultipleslno.Text = Slno.ToString();
                            lblqty.Text = Qty.ToString();
                        }
                        else
                        {
                            lbmultipleslno.Text = lbmultipleslno.Text + "," + Slno.ToString();
                            lblqty.Text = Convert.ToString(Convert.ToInt32(lblqty.Text)  + Convert.ToInt32(Qty));
                        }
                        txtnoofboards.Text = lblqty.Text;
                    }
                }
            }
            if (lbmultipleslno.Text != "0")
            {
                this.mpeImage3.Show();
            }
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Send();
        }
        protected void Send()
        {
            string msg = string.Empty;
            int result = 0;


            int result1 = 0;


            if (lbmultipleslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for send..','error',3);", true);
            }
            else
            {
               
                if (Validation2()[0] == "true")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation2()[1] + "','warning',3);", true);
                }
               
              
                else
                {

                    Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();


                    dst.Allslno = lbmultipleslno.Text;

                   
                    dst.LRNumber = txtLRNumber.Text.Trim();
                    dst.LRDate = txtLRDate.Date.ToString("yyyy-MM-dd");
                    dst.TranspoterName = txtTranspoterName.Text.Trim();


                    dst.InvoiceNumber = txtInvoiceNumber.Text.Trim();
                    dst.InvoiceDate = txtInvoiceDate.Date.ToString("yyyy-MM-dd");
                    dst.TransportMode = cmbTransportMode.SelectedItem.Text.Trim();

                    dst.pagename = HttpContext.Current.Request.Url.ToString();

                    dst.NoofPackages = Convert.ToInt32(txtpkges.Text == "" ? "0" : txtpkges.Text);
                    dst.Remark = txtremark.Text.Trim();
                    dst.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
                    dst.TotalBoardQty = Convert.ToInt32(txtnoofboards.Text == "" ? "0" : txtnoofboards.Text);

                    Core.FinalAssembaly.FinalAssembly objSend = new Core.FinalAssembaly.FinalAssembly();
                    result = objSend.UpdateDispatchDetailOfFinalAssembly(dst);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job send successfully !','success',3);", true);
                        clean();
                    }
                    else if (result == 3)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','LR Number already exist !','warning',3);", true);
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                    }
                }
            }

            // clean();
        }

        private string[] Validation2()
        {
            string[] result = new string[2];

            result[0] = "false";
            result[1] = string.Empty;

            if (Convert.ToString(cmbTransportMode.SelectedItem.Value) == "0" || string.IsNullOrEmpty(txtInvoiceNumber.Text) || string.IsNullOrEmpty(txtInvoiceDate.Text) || string.IsNullOrEmpty(txtTranspoterName.Text) || string.IsNullOrEmpty(txtLRNumber.Text) || string.IsNullOrEmpty(txtLRDate.Text) || string.IsNullOrEmpty(txtpkges.Text))
            {
                result[0] = "true";
                result[1] = "Please check Transport Details validation!";
                return result;
            }
            else
            {
                bool success = false;
                DateTime lrdate = DateTime.MinValue;
                DateTime iddate = DateTime.MinValue;
                success = DateTime.TryParse(txtLRDate.Date.ToString("yyyy-MM-dd"), out lrdate);
                success = DateTime.TryParse(txtInvoiceDate.Date.ToString("yyyy-MM-dd"), out iddate);

                if (!success || lrdate == DateTime.MinValue || iddate == DateTime.MinValue)
                {
                    result[0] = "true";
                    result[1] = "Please select valid date!";
                    return result;
                }
            }

            return result;
        }
        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.mpeImage3.Hide();
            clean();
        }
        protected void clean()
        {
            
            lblchildid.Text = "0";
            lblprinterid.Text = "0";
            lbldesignsubmitsslno.Text = "0";
            lbslno.Text = "0";
            

            txtLRDate.Text = "";
            txtLRNumber.Text = "";
            txtTranspoterName.Text = "";
            txtnoofboards.Text = "";


            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";
            lbmultipleslno.Text = "0";
            ASPxGridView1.DataBind();
           
            ASPxPageControl1.ActiveTabIndex = 1;
        }
    }
}