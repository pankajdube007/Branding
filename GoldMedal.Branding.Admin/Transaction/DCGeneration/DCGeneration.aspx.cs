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

namespace GoldMedal.Branding.Admin.Transaction.DCGeneration
{
    public partial class DCGeneration : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit ";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/submitimagebyFabricator";

        private readonly string finYear = string.Empty;

        public DCGeneration()
        {
            //finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "1")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    txtInvoiceDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtLRDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtInvoiceDate.MaxDate = DateTime.Now;
                    txtLRDate.MaxDate = DateTime.Now;
                    ASPxGridView1.DataBind();
                    ASPxGridView2.DataBind();
                }
            }
        }

        #region Events

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 1)
            {
                ASPxGridView1.DataBind();
                ASPxGridView2.DataBind();
            }
        }

        /// <summary>
        /// shoe the detail of submited design by the Fabricator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            clean2();
            lbslno.Text = FieldTripID.ToString();
            show2();
        }

        /// <summary>
        /// Bind The Grid View.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        /// <summary>
        /// for clean the lable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            this.mpeImage3.Hide();
            clean();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        /// <summary>
        /// call the approve method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            Send();
        }
        #endregion Events

        #region Methods


        /// <summary>
        /// List Of Job Done By Fabricator For Approval
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();
            Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty dsp = new Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty();
            dsp.branchid = 11;
            dsp.uid = 1;
            Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit objselectall = new Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit();
            dt4 = objselectall.GetApprovedJobsForDC(dsp);
            return dt4;
        }

        /// <summary>
        /// fill all the control.
        /// </summary>
        protected void show2()
        {
            Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dsp = new Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty();
            dsp.slno = Convert.ToInt32(lbslno.Text);
            dsp.fabricator = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.FabricatorDesignSubmit.FabricatorDesignSubmit objselectsingle = new Core.FabricatorDesignSubmit.FabricatorDesignSubmit();
            DataTable dt = objselectsingle.GetSingleApprovedJobsForDC(dsp);
            if (dt.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);    
            }

            ASPxPageControl1.ActiveTabIndex = 0;
        }

 

  
        private string[] Validation2()
        {
            string[] result = new string[2];

            result[0] = "false";
            result[1] = string.Empty;

            if (Convert.ToString(cmbTransportMode.SelectedItem.Value) == "0" || string.IsNullOrEmpty(txtInvoiceNumber.Text) || string.IsNullOrEmpty(txtInvoiceDate.Text) || string.IsNullOrEmpty(txtTranspoterName.Text) || string.IsNullOrEmpty(txtLRDate.Text) || string.IsNullOrEmpty(txtpkges.Text))
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

 
        /// <summary>
        /// Approve the record submited by the Fabricator.
        /// </summary>
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
                    for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                    {
                        ASPxCheckBox chk = ASPxGridView1.FindRowCellTemplateControl(i, ASPxGridView1.Columns["Send"] as GridViewDataColumn, "gvCheck") as ASPxCheckBox;
                        if (chk != null)
                        {

                            if (chk.Checked == true)
                            {
                                ASPxTextBox SendingQty = ASPxGridView1.FindRowCellTemplateControl(i, ASPxGridView1.Columns["Sending Qty"] as GridViewDataColumn, "txtsendingqty") as ASPxTextBox;

                                int Slno = Convert.ToInt32(ASPxGridView1.GetRowValues(i, "slno"));

                                //Data.DCGeneration.DCGeneration.DCGenerationJobDCSend dst1 = new Data.DCGeneration.DCGeneration.DCGenerationJobDCSend();
                                //dst1.slno = Slno;
                                //dst1.QtySentByDC = Convert.ToInt32(SendingQty.Text);
                                //Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit objSend1 = new Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit();
                                //result1 = objSend1.UpdateSentQtybyDCGenerationMethod(dst1);

                            }
                        }
                    }
                    Data.DCGeneration.DCGeneration.DCGenerationSend dst = new Data.DCGeneration.DCGeneration.DCGenerationSend();

                    // dst.slno = Convert.ToInt16(lbslno.Text);
                    dst.Allslno = lbmultipleslno.Text;
                    dst.JobReqNo = LblRequestNo.Text;
                    dst.JobReceiveDate =lblDate.Text;
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.LRNumber = txtLRNumber.Text.Trim();
                    dst.LRDate = txtLRDate.Date.ToString("yyyy-MM-dd");
                    dst.TranspoterName = txtTranspoterName.Text.Trim();
                    dst.InvoiceNumber = txtInvoiceNumber.Text.Trim();
                    dst.InvoiceDate = txtInvoiceDate.Date.ToString("yyyy-MM-dd");
                    dst.TransportMode = cmbTransportMode.SelectedItem.Text.Trim();
                    dst.fabricator = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
                    dst.Fabfinyear = finYear;
                    dst.pagename = HttpContext.Current.Request.Url.ToString();
                   // dst.FabricationCost = Convert.ToDecimal(lblFabricatorCost.Text == "" ? "0" : lblFabricatorCost.Text);
                    dst.NoofPackages = Convert.ToInt32(txtpkges.Text == "" ? "0" : txtpkges.Text);
                    dst.PrinterDcRemark = txtprintdcremark.Text.Trim();

                    Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit objSend = new Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit();
                    result = objSend.SendByDCGenerationMethod(dst);
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
                    else if (result == 4)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','PO not generated for any of the job !','warning',3);", true);
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

        /// <summary>
        /// clean all the control.
        /// </summary>
        protected void clean()
        {
            LblRequestNo.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblchildid.Text = "0";
            // lblFabricatorid.Text = "0";
            lbldesignsubmitsslno.Text = "0";
            lbslno.Text = "0";
            txtLRDate.Text = "";
            txtLRNumber.Text = "";
            txtTranspoterName.Text = "";
            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";
            lbmultipleslno.Text = "0";
            ASPxGridView1.DataBind();
            ASPxGridView2.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void clean2()
        {
            lblchildid.Text = "0";
            //  lblFabricatorid.Text = "0";
            lbldesignsubmitsslno.Text = "0";
            lbslno.Text = "0";
            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";
            hfDesignSubmitID.Value = "0";
            hfJobRequestNo.Value = "0";
        }

        #endregion Methods

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
                        if (lbmultipleslno.Text == "0")
                        {
                            lbmultipleslno.Text = Slno.ToString();
                        }
                        else
                        {
                            lbmultipleslno.Text = lbmultipleslno.Text + "," + Slno.ToString();
                        }

                    }
                }
            }

            if (lbmultipleslno.Text != "0")
            {
                this.mpeImage3.Show();
            }

        }

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }


        private DataTable GetTable3()
        {
            DataTable dt4 = new DataTable();
            Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty dsp = new Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty();
           // dsp.branchid = 4;
            dsp.JobSendBy = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit objselectall = new Core.DCGenerationDesignSubmit.DCGenerationDesignSubmit();
            dt4 = objselectall.GetApprovedJobsForViewDC(dsp);
            return dt4;
        }

        protected void CmdEdit_Command1(object sender, CommandEventArgs e)
        {

        }
    }
}