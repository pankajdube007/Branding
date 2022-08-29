using DevExpress.Web;
using GoldMedal.Branding.Data.AssigntoPrinter;
using GoldMedal.Branding.Data.DesignSubmit;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.AssigntoPrinter
{
    public partial class reassigntoprinter : System.Web.UI.Page
    {
        private DataTable dts = new DataTable();
        private int result = 0;
        private int result2 = 0;
        private int result3 = 0;
        private int errorresulr = 0;
        private string TableNme = "Tbl_DesignSubmit ";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME3 = "jobrequest/liveproductimage";
        private const string FILE_DIRECTORY_NAME4 = "jobrequest/approveprintjob";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        private string FileNameAPJ = string.Empty;

        DesignSubmitDataAccess da = new DesignSubmitDataAccess();
        AssignToPrinterDataAccess da2 = new AssignToPrinterDataAccess();
        #region PageEvent

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46 || GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 44)
               // if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46 || GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 132)
                {
                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    ViewState["_SizePageID"] = (new Random()).Next().ToString();
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView2.DataBind();
                   
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
            //GetPrintFile();
            createSizeSessionData();
        }

        #endregion PageEvent
        public reassigntoprinter()
        {
            _goldMedia = new GoldMedia();
            //  finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }
        #region Events

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (e.Tab.Index == 1)
            {
                ASPxGridView1.DataBind();
            }
            else if (e.Tab.Index == 2)
            {
                ASPxGridView2.DataBind();
            }
        }

        /// <summary>
        /// Show the image which are added  in job request child.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblchildid.Text), 3);
            this.mpeAll.Show();
        }

        /// <summary>
        /// Show the image which are added  in designsubmit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 4);
            this.mpeAll.Show();
        }

        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblDSSlno.Text), 10);
            this.mpeAll.Show();
        }

        protected void lnkShowImg_Command(object sender, CommandEventArgs e)
        {
            long FieldTripID = Convert.ToInt64(e.CommandArgument);
            lblDSSlno.Text = FieldTripID.ToString();

            GetUploadedJobRequestFiles(Convert.ToInt64(lblDSSlno.Text), 10);
            this.mpeAll.Show();
        }

        protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;

            string LiveProductImg = e.GetValue("LiveProductImg").ToString();

            LinkButton hlSubImg = ASPxGridView1.FindRowCellTemplateControl(e.VisibleIndex, ASPxGridView1.Columns["Live Product Image"] as GridViewDataTextColumn, "lnkShowImg") as LinkButton;

            if (LiveProductImg == "")
            {
                hlSubImg.Visible = false;
            }
        }

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
        /// show the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            show2();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }

        /// <summary>
        /// for clean the lable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
        }

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        /// <summary>
        /// call the method for assign the printer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void lnkPrintFile_Click(object sender, EventArgs e)
        {
            lnkvisible.Text = "2";
            lbIsListShow.Text = "0";
            GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 12);
            this.mpeImage1.Show();
        }

        protected void btnApprovePrintJob_Click(object sender, EventArgs e)
        {
            ApprovePrintJob();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Index changed method for the details of the selected printer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmbprinter_SelectedIndexChanged(object sender, EventArgs e)
        {

            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dt = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dt.slno = Convert.ToInt32(cmbPrinter.SelectedItem.Value);
            Core.DesignSubmit.DesignSubmit objprinter = new Core.DesignSubmit.DesignSubmit();
            DataTable dtChildassign = objprinter.PrinterWorkStatus(dt);
            gvdetail.DataSource = dtChildassign;
            gvdetail.DataBind();



            mpeImagee.Show();
            if (rdsizetype.SelectedValue == "0")
            {
                //if (txtbheight.Text == "" || txtbheight.Text == "0" || txtbwidth.Text == "" || txtbwidth.Text == "0" || txtpheight.Text == "" || txtpheight.Text == "0" || txtpwidth.Text == "" || txtpwidth.Text == "0")
                //{
                //    cmbPrinter.SelectedIndex = -1;
                //    lblCost.Text = "0.00";
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter sizes first.','error',3);", true);
                //}
                //else
                //{
                hfAllowSubmit.Value = "0";
                loadprinterdetail();
                // }
            }
            else if (rdsizetype.SelectedValue == "1")
            {
                //if (gvSizeChild.Rows.Count <= 0)
                //{
                //    cmbPrinter.SelectedIndex = -1;
                //    lblCost.Text = "0.00";
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please enter sizes first.','error',3);", true);
                //}
                //else
                //{
                loadprinterdetail();
                // }
            }
        }

        protected void btnaddsize_Click(object sender, EventArgs e)
        {
            Boolean matchdata = false;

            if (txtboardhight.Text != string.Empty && txtboardwidth.Text != string.Empty && txtprintheight.Text != string.Empty && txtprintwidth.Text != string.Empty)
            {
                DataRow row = dts.NewRow();

                if (matchdata == false)
                {
                    row["SizeSlno"] = "0";
                    row["BoardHeight"] = Convert.ToDecimal(txtboardhight.Text);
                    row["BoardWidth"] = Convert.ToDecimal(txtboardwidth.Text);
                    row["PrintHeight"] = Convert.ToDecimal(txtprintheight.Text);
                    row["PrintWidth"] = Convert.ToDecimal(txtprintwidth.Text);
                    dts.Rows.Add(row);
                    dts.AcceptChanges();
                    Session[ViewState["_SizePageID"].ToString() + "Size"] = dts;
                    bindgvSizeChild();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter every mandatory details','warning',3);", true);
            }
            cleansize();
        }

        private void cleansize()
        {
            txtboardhight.Text = "";
            txtprintheight.Text = "";
            txtboardwidth.Text = "";
            txtprintwidth.Text = "";
        }

        protected void bindgvSizeChild()
        {
            gvSizeChild.DataSource = (DataTable)Session[ViewState["_SizePageID"].ToString() + "Size"];
            gvSizeChild.DataBind();
            CalculateCost();

            if (cmbSendToType.SelectedItem.Value.ToString() == "3" && cmbSendTo.SelectedItem != null)
            {
                CalculateCostf();
            }
        }

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

        protected void rdsizetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdsizetype.SelectedValue == "0")
            {
                //rdsizetype.SelectedValue = "0";
                //btnaddsize.Enabled = false;
                //txtboardhight.Enabled = false;
                //txtboardwidth.Enabled = false;
                //txtprintheight.Enabled = false;
                //txtprintwidth.Enabled = false;
                //txtpheight.Enabled = true;
                //txtpwidth.Enabled = true;

                //txtbheight.Enabled = true;
                //txtbwidth.Enabled = true;
                //cmbPrinter.SelectedIndex = -1;
                //lblCost.Text = "0.00";
            }
            else
            {
                //rdsizetype.SelectedValue = "1";
                //btnaddsize.Enabled = true;
                //txtboardhight.Enabled = true;
                //txtboardwidth.Enabled = true;
                //txtprintheight.Enabled = true;
                //txtprintwidth.Enabled = true;
                //txtpheight.Enabled = false;
                //txtpwidth.Enabled = false;

                //txtbheight.Enabled = false;
                //txtbwidth.Enabled = false;

                //cmbPrinter.SelectedIndex = -1;
                //lblCost.Text = "0.00";
            }
            gvPrinter.DataSource = null;
            gvPrinter.DataBind();
            lblpricontect.Text = "";
            lblpriemail.Text = "";
            lblprimobile.Text = "";
        }

        protected void cmbSendToType_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfIsFabSend.Value = "0";
            txtSendToOther.Text = "";
            cmbSendTo.SelectedIndex = -1;
            lblsendto.Text = "";
            ddlsendto.Style.Add("display", "none");
            othername.Style.Add("display", "none");
            txtAddress.Text = "";
            address.Style.Add("display", "none");
            hfAllowSubmit2.Value = "0";
            fabcost.Style.Add("display", "none");
            lblFabricatorCost.Text = "";
            cmbSendTo.Enabled = true;
            txtAddress.Enabled = true;

            if (cmbSendToType.SelectedItem != null)
            {
                if (cmbSendToType.SelectedItem.Value.ToString() != "0")
                {
                    if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && string.IsNullOrEmpty(lblFabricatorLocationID.Text) || lblFabricatorLocationID.Text == "0")
                    {
                        cmbSendToType.SelectedIndex = 0;
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! This job cant sent to Fabricator as fabricator location is not mentioned.','warning',3);", true);
                    }
                    else
                    {
                        if (cmbSendToType.SelectedItem.Value.ToString() != "4")
                        {
                            BindSendToList(Convert.ToInt16(cmbSendToType.SelectedItem.Value));

                            lblsendto.Text = cmbSendToType.SelectedItem.Text + ":";


                            if (cmbSendToType.Value.ToString() == "1")
                            {
                                //if (hfNameTypeId.Value == "2")
                                //{
                                //    if (hfUseAddressType.Value == "0")
                                //    {
                                cmbSendTo.Value = hfNameId.Value;

                                string sendtoid = cmbSendTo.Value.ToString();
                                int partytype = 1;
                                GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);
                                address.Style.Add("display", "block");
                                //    }



                                //}
                                cmbSendTo.Enabled = false;
                                txtAddress.Enabled = false;


                            }

                            if (cmbSendToType.Value.ToString() == "5")
                            {


                                //if (hfNameTypeId.Value == "4")
                                //{
                                cmbSendTo.Value = hfSubNameId.Value;

                                string sendtoid = cmbSendTo.Value.ToString();
                                int partytype = 2;
                                GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);
                                address.Style.Add("display", "block");
                                // }

                                cmbSendTo.Enabled = false;
                                txtAddress.Enabled = false;
                            }

                            if (cmbSendToType.Value.ToString() == "2")
                            {
                                if (hfNameTypeId.Value == "5")
                                {
                                    cmbSendTo.Value = hfNameId.Value;
                                    GetAddressFromName(Convert.ToInt64(cmbSendTo.SelectedItem.Value), Convert.ToInt16(cmbSendToType.SelectedItem.Value), 0);
                                    address.Style.Add("display", "block");
                                }
                            }

                            ddlsendto.Style.Add("display", "block");
                            othername.Style.Add("display", "none");
                            txtSendToOther.Text = "";


                        }
                        else
                        {
                            lblsendto.Text = "";
                            cmbSendTo.SelectedIndex = -1;
                            ddlsendto.Style.Add("display", "none");
                            othername.Style.Add("display", "block");
                            address.Style.Add("display", "block");
                        }
                    }
                }
                else
                {
                    txtSendToOther.Text = "";
                    cmbSendTo.SelectedIndex = -1;
                    lblsendto.Text = "";
                    ddlsendto.Style.Add("display", "none");
                    othername.Style.Add("display", "none");
                    address.Style.Add("display", "none");
                }
            }
        }

        protected void cmbSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAddress.Enabled = true;
            if (cmbSendToType.SelectedItem != null)
            {
                if (cmbSendToType.SelectedItem.Value.ToString() != "0")
                {
                    if (cmbSendToType.SelectedItem.Value.ToString() == "1")
                    {
                        string sendtoid = cmbSendTo.SelectedItem.Value.ToString();
                        int partytype = 1;

                        GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);

                        address.Style.Add("display", "block");
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "2")
                    {
                        GetAddressFromName(Convert.ToInt64(cmbSendTo.SelectedItem.Value), Convert.ToInt16(cmbSendToType.SelectedItem.Value), 0);
                        // txtAddress.Enabled = false;
                        address.Style.Add("display", "block");
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "3")
                    {
                        hfAllowSubmit2.Value = "0";
                        hfIsFabSend.Value = "1";
                        txtAddress.Text = "";
                        address.Style.Add("display", "none");
                        loadfabricatormaterial();
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "4")
                    {
                        txtAddress.Text = "";
                        address.Style.Add("display", "block");
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "5")
                    {
                        string sendtoid = cmbSendTo.SelectedItem.Value.ToString();
                        int partytype = 2;

                        GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);

                        address.Style.Add("display", "block");
                    }
                }
                else
                {
                    txtAddress.Enabled = true;
                    txtAddress.Text = "";
                    address.Style.Add("display", "none");
                }
            }
        }

        protected void txtHeightWidth_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        protected void txtbheightwidth_TextChanged(object sender, EventArgs e)
        {
            CalculateCostf();
        }

        #endregion Events

        #region Methods

        private void ApprovePrintJob()
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            if (lbslno.Text == "0" && lbldslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any job to assign printer. ','error',3);", true);
            }
            else if ((fuPrintFile.PostedFiles.Count > 0 && Request.Files[0].ContentLength > 0) || txtPrintLink.Text != "")
            {
                string strFileType = "";
                foreach (var file in fuPrintFile.PostedFiles)
                {
                    if (file.FileName != "")
                    {
                        bool rtnVallpost = false;
                        string uploadedFileName = "";
                        decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);

                        if (size <= 30720)
                        {
                            SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME4);
                            if (rtnVallpost)
                            {
                                strFileType = Path.GetExtension(file.FileName).ToLower();
                                if (FileNameAPJ == "")
                                {
                                    FileNameAPJ = uploadedFileName;
                                }
                                else
                                {
                                    FileNameAPJ = FileNameAPJ + ',' + uploadedFileName;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Invalid File Format. ','error',3);", true);

                                //lblModalTitle.Text = "Warning";
                                //lblModalBody.Text = "Sorry, Invalid File Format.";
                                //lblModalBody.Attributes.Add("style", "font-size:15px; color:Red; font-weight:lighter;");
                                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                                //upModal.Update();
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Sorry, Image size can not be greater then 30MB. ','error',3);", true);
                            //lblModalTitle.Text = "Warning";
                            //lblModalBody.Text = "Sorry, Image size can not be greater then 30MB.";
                            //lblModalBody.Attributes.Add("style", "font-size:15px; color:Red; font-weight:lighter;");
                            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                            //upModal.Update();
                            return;
                        }
                    }
                }

                if (hfPrintFile.Text != "")
                {
                    FileNameAPJ = FileNameAPJ.TrimEnd(',') + ',' + hfPrintFile.Text;

                    if (FileNameAPJ.Contains(",,"))
                    {
                        FileNameAPJ.Replace(",,", "");
                    }
                }

                long slno = Convert.ToInt32(lbslno.Text);
                string printfile = FileNameAPJ;
                string printlink = txtPrintLink.Text;
                string Approvejobremark = txtremark.Text;
                int SendForPrintQty = Convert.ToInt32(lblqty.Text);
                result = da.ApprovePrintJobDA(slno, printfile, printlink, userID, Approvejobremark, SendForPrintQty);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Print Job Approved Successfully!','success',3);", true);
                    GetPrintFile();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please upload print file or add print link. ','error',3);", true);
            }
        }

        protected void GetPrintFile()
        {
            if (lbslno.Text != "0")
            {
                long slno = Convert.ToInt64(lbslno.Text);

                DataTable dt = da.GetUploadPrintFileDA(slno);
                if (dt.Rows.Count > 0)
                {
                    txtPrintLink.Text = Convert.ToString(dt.Rows[0]["PrintLink"]);
                    hfPrintFile.Text = Convert.ToString(dt.Rows[0]["PrintFile"]);

                    if (txtPrintLink.Text != "" || hfPrintFile.Text != "")
                    {
                        printerdetails.Style.Add("display", "block");
                    }
                    else
                    {
                        printerdetails.Style.Add("display", "none");
                    }
                }
                else
                {
                    printerdetails.Style.Add("display", "none");
                }
            }
            else
            {
                printerdetails.Style.Add("display", "none");
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
            MimeType.cdr
            };
            #region Validation
            if (String.IsNullOrWhiteSpace(file.FileName))
                return string.Empty;
            if (!GoldMimeType.IsMimeTypeAllowed(oldFileExtension, mineTypeAllowed, out contentType))
            {
                result = string.Format("{0} : Oops!! This type of file upload not allowed.", oldFileName);
                return result;
            }
            if (!GoldMimeType.IsFileSizeAllowed(file.ContentLength, out size, 1024 * 1024 * 30))
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
        protected void BindSendToList(int SendToType)
        {
            int fabLoc = 0;
            int Slno = 0;
            fabLoc = lblFabricatorLocationID.Text == "" ? 0 : Convert.ToInt32(lblFabricatorLocationID.Text);
            Slno = Convert.ToInt32(lbslno.Text);
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            DataTable dt = objselectsingle.GetSendToList(SendToType, fabLoc);

            cmbSendTo.DataSource = dt;
            cmbSendTo.TextField = "name";
            cmbSendTo.ValueField = "slno";
            cmbSendTo.SelectedIndex = -1;
            cmbSendTo.DataBind();

            if (SendToType == 2)
            {
                cmbSendTo.Text = lblBranch.Text;
                cmbSendTo.Value = lblBranchID.Text;
                address.Style.Add("display", "block");
                GetAddressFromName(Convert.ToInt64(cmbSendTo.SelectedItem.Value), Convert.ToInt16(cmbSendToType.SelectedItem.Value), 0);
            }
        }

        protected void GetAddressFromName(long SendToID, int SendToType, int PartyType)
        {
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            string Address = objselectsingle.GetAddressFromSendToID(SendToID, SendToType, PartyType);
            txtAddress.Text = Address;
        }

        /// <summary>
        /// List Of Job To Assign To Printer
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dsp = new Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty();
            dsp.slno = Convert.ToInt32(lbslno.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssigntoPrinter.Assigntoprinter objselectall = new Core.AssigntoPrinter.Assigntoprinter();
            dt5 = objselectall.DetailOfJobToPrinter(dsp);
            return dt5;
        }

        private DataTable GetTable3()
        {
            DataTable dt5 = new DataTable();
            Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dsp = new Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty();
            dsp.slno = Convert.ToInt32(lbslno.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dt5 = da2.DetailOfApprovedDesignJobToReassignPrinter(dsp);
            return dt5;
        }

        /// <summary>
        /// fill all the controls for perticular job.
        /// </summary>
        protected void show2()
        {
            PrinterLocationList();
            Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle = new Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty();
            dtsingle.slno = Convert.ToInt32(lbslno.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssigntoPrinter.Assigntoprinter objselectsingle = new Core.AssigntoPrinter.Assigntoprinter();
            DataTable dt = objselectsingle.DetailOfJobToReassignPrinter(dtsingle);
            if (dt.Rows.Count > 0)
            {

                //  cmbPrinterLocation.Value = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                cmbPrinterLocation.Value = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                Currentlyassignedprinter.Text = Convert.ToString(dt.Rows[0]["PrinterName"]);
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblBranchID.Text = Convert.ToString(dt.Rows[0]["branchid"]);
                lblBranch.Text = Convert.ToString(dt.Rows[0]["branch"]);

                lblNameType.Text = Convert.ToString(dt.Rows[0]["nametype"]);
                lblName.Text = Convert.ToString(dt.Rows[0]["Distributor"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["distaddress"]);
                lblContact.Text = Convert.ToString(dt.Rows[0]["distcontact"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["distcontactperson"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["distemail"]);
                lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                lblSubAddress.Text = Convert.ToString(dt.Rows[0]["subaddress"]);
                lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                subjobtype.Text = Convert.ToString(dt.Rows[0]["subjob"]);
                subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjob"]);
                subsubjobtypeID.Text = Convert.ToString(dt.Rows[0]["SubSubJobTypeId"]);
                designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);

                designtypeID.Text = Convert.ToString(dt.Rows[0]["designtypeid"]);

                product.Text = Convert.ToString(dt.Rows[0]["product"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                lbltotalamount.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["childid"]);
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);
                deslink.Text = Convert.ToString(dt.Rows[0]["designlink"]);
                deslink.NavigateUrl = Convert.ToString(dt.Rows[0]["designlink"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);

                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                lblDesignerName.Text = Convert.ToString(dt.Rows[0]["DesignerName"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblUnitID.Text = Convert.ToString(dt.Rows[0]["UnitID"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblDSSlno.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);

                hfNameId.Value = Convert.ToString(dt.Rows[0]["NameId"]);
                hfNameTypeId.Value = Convert.ToString(dt.Rows[0]["NameTypeId"]);
                hfSubNameId.Value = Convert.ToString(dt.Rows[0]["SubNameId"]);
                hfUseAddressType.Value = Convert.ToString(dt.Rows[0]["UseAddressType"]);
                //  hfsendto.Value = Convert.ToString(dt.Rows[0]["Sendto"]);


                lblapprovejobremark.Text = Convert.ToString(dt.Rows[0]["Approvaljobremark"]);


                if (product.Text == "Live Product")
                {
                    liveproduct.Style.Add("display", "block");
                }

                txtPrintLink.Text = Convert.ToString(dt.Rows[0]["PrintLink"]);
                hfApprovedPrintImage.Text = Convert.ToString(dt.Rows[0]["PrintFile"]);

                if (!string.IsNullOrEmpty(txtPrintLink.Text) || !string.IsNullOrEmpty(hfApprovedPrintImage.Text))
                {
                    printerdetails.Style.Add("display", "block");
                }
                else
                {
                    printerdetails.Style.Add("display", "none");
                }

                //lblHeadSlno.Text = Convert.ToString(dt.Rows[0]["HeadSlno"]);
                //lblPlaceSize.Text = Convert.ToString(dt.Rows[0]["isplacesize"]) == "False" ? "No" : "Yes";
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                //lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                //if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                //{
                //    lbVisitingCardImg.Visible = true;
                //}

                //if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                //{
                //    lbReferSheetImg.Visible = true;
                //}


                //added by gaurav
                lblsizetype.Text = Convert.ToString(dt.Rows[0]["isplacesize"]).ToString() == "False" ? "0" : "1";
                lbldslno.Text = Convert.ToString(dt.Rows[0]["assignslno"]);

                lblFabricatorLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["isapproveparty"])))
                {
                    partyremark.Style.Add("display", "block");
                    lblPartyRemarks.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);
                }


                if (Convert.ToString(dt.Rows[0]["isplacesize"]) == "False")
                {
                    txtbheight.Text = Convert.ToString(dt.Rows[0]["height"]);
                    txtbwidth.Text = Convert.ToString(dt.Rows[0]["width"]);

                    txtpheight.Text = Convert.ToString(dt.Rows[0]["PrintHeight"]);
                    txtpwidth.Text = Convert.ToString(dt.Rows[0]["PrintWidth"]);

                    rdsizetype.SelectedValue = "0";
                    //btnaddsize.Enabled = false;
                    //txtboardhight.Enabled = false;
                    //txtboardwidth.Enabled = false;
                    //txtprintheight.Enabled = false;
                    //txtprintwidth.Enabled = false;
                    //txtpheight.Enabled = true;
                    //txtpwidth.Enabled = true;
                    //txtbheight.Enabled = false;
                    //txtbwidth.Enabled = false; 
                }
                else
                {
                    rdsizetype.SelectedValue = "1";
                    //btnaddsize.Enabled = true;
                    //txtboardhight.Enabled = true;
                    //txtboardwidth.Enabled = true;
                    //txtprintheight.Enabled = true;
                    //txtprintwidth.Enabled = true;
                    //txtpheight.Enabled = false;
                    //txtpwidth.Enabled = false;

                    //txtbheight.Enabled = false;
                    //txtbwidth.Enabled = false;

                   // txtboardwidth.Text = Convert.ToString(dt.Rows[0]["width"]);
                   // txtboardhight.Text = Convert.ToString(dt.Rows[0]["height"]);
                   // txtprintheight.Text = Convert.ToString(dt.Rows[0]["PrintHeight"]);
                   // txtprintwidth.Text = Convert.ToString(dt.Rows[0]["PrintWidth"]);
                }
                if (Convert.ToString(dt.Rows[0]["isplacesize"]) == "True")
                {
                    loadsizechild();
                }
                PrinterList(Convert.ToInt32(Convert.ToString(dt.Rows[0]["PrintLocationID"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["PrintLocationID"])));
            }

            loadchild();
           
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        /// <summary>
        /// Loads the grid of child.
        /// </summary>
        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }

        /// <summary>
        /// Load the grid of sizer child.
        /// </summary>
        private void loadsizechild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbslno.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);
            gvSizeChild.DataSource = dt6;
            gvSizeChild.DataBind();
        }

        /// <summary>
        /// Load the list of printer.
        /// </summary>
        protected void PrinterList(int BranchID)
        {
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            DataTable dt = objselectsingle.GetPrinterByLocation(BranchID);
            cmbPrinter.DataSource = dt;
            cmbPrinter.TextField = "name";
            cmbPrinter.ValueField = "slno";
            cmbPrinter.SelectedIndex = -1;
            cmbPrinter.DataBind();
        }


        protected void PrinterLocationList()
        {
            Core.JobType.JobType db = new Core.JobType.JobType();
            DataTable dtprintloc = db.GetPrinterLocation();

            cmbPrinterLocation.Items.Clear();

            cmbPrinterLocation.DataSource = dtprintloc;
            cmbPrinterLocation.DataBind();

            // cmbPrinterLocation.Items.Insert(0, "Select");
        }


        /// <summary>
        /// Load the details of the printer.
        /// </summary>
        protected void loadprinterdetail()
        {
            Data.Printer.PrinterModel.PrinterInsert dtsingle = new Data.Printer.PrinterModel.PrinterInsert();
            dtsingle.slno = Convert.ToInt32(cmbPrinter.Value);
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            DataTable dt = objselectsingle.GetPrinterSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                lblpricontect.Text = Convert.ToString(dt.Rows[0]["contact"]);
                lblpriemail.Text = Convert.ToString(dt.Rows[0]["emailid"]);
                lblprimobile.Text = Convert.ToString(dt.Rows[0]["mobile"]);
                loadprintermaterial(Convert.ToInt32(lblPrintLocationID.Text));
            }
        }

        /// <summary>
        /// Load the  material for the particular printer.
        /// </summary>
        private void loadprintermaterial(int BranchID)
        {
            DataTable dt6 = new DataTable();
            Data.Printer.PrinterModel.PrinterInsert dchildlist = new Data.Printer.PrinterModel.PrinterInsert();
            dchildlist.slno = Convert.ToInt32(cmbPrinter.Value);
            dchildlist.BranchID = BranchID;
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt6 = objselectall.GetDetailOfMaterialListForPrinter(dchildlist);
            gvPrinter.DataSource = dt6;
            gvPrinter.DataBind();
            CalculateCost();
        }

        private void CalculateCost()
        {
            if (IsPricingAvailable())
            {
                if (rdsizetype.SelectedValue == "0")
                {
                    CalculateSize(Convert.ToDecimal(txtpwidth.Text == "" ? "0" : txtpwidth.Text), Convert.ToDecimal(txtpheight.Text == "" ? "0" : txtpheight.Text));
                }
                else if (rdsizetype.SelectedValue == "1")
                {
                    decimal width = 0;
                    decimal height = 0;
                    double cost = 0; // Convert.ToDouble(lblCost.Text);
                    lblCost.Text = "0";
                    if (gvSizeChild.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in gvSizeChild.Rows)
                        {
                            cost = Convert.ToDouble(lblCost.Text);

                            height = Convert.ToDecimal(row.Cells[3].Text);
                            width = Convert.ToDecimal(row.Cells[4].Text);


                            CalculateSize(width, height);
                            cost = cost + Convert.ToDouble(lblCost.Text);
                        }
                        lblCost.Text = cost.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please add size details.','error',3);", true);
                    }
                }
            }
            else
            {
                lblCost.Text = "0.00";
            }

            RoundCost();
        }

        private void RoundCost()
        {
            double cost = Convert.ToDouble(lblCost.Text);

            cost = cost * Convert.ToInt32(lblqty.Text);

            lblCost.Text = cost.ToString("F2");
        }

        private void CalculateSize(decimal width, decimal height)
        {
            string jrUnit = lblUnit.Text;
            string PricingUnit = lblPricingUnit.Text;

            decimal totalPrintArea = 0;
            decimal totalPrice = 0;
            decimal QTPrice = Convert.ToDecimal(lblPrice.Text);

            if (width == 0 || height == 0)
            {
                lblCost.Text = "0.00";
            }
            else
            {
                totalPrintArea = width * height;

                if (lblUnit.Text == lblPricingUnit.Text)
                {
                    totalPrice = totalPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();
                }
                else
                {
                    switch (PricingUnit)
                    {
                        case "Inches":

                            ConvertInches(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Feet":

                            ConvertFeet(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Meters":

                            ConvertMeters(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Centimeters":

                            ConvertCentimeters(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Millimeters":

                            ConvertMillimeters(jrUnit, totalPrintArea, QTPrice);
                            break;
                        default:
                            lblCost.Text = "0.00";
                            break;
                    }
                }
            }
        }

        private void ConvertInches(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Feet":

                    newPrintArea = totalPrintArea * 144;

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Meters":

                    newPrintArea = totalPrintArea * 1550;

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Centimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, Convert.ToDecimal(6.452));

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 645);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertFeet(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Divide(totalPrintArea, 144);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;

                case "Meters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(10.764));

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Centimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 929);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 92903);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertMeters(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Divide(totalPrintArea, 1550);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Feet":

                    newPrintArea = Decimal.Divide(totalPrintArea, Convert.ToDecimal(10.764));

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;

                case "Centimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 10000);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 1000000);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertCentimeters(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(6.452));

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Feet":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 929);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Meters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 10000);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;

                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 100);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertMillimeters(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(645));

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Feet":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(92903));

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Meters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 1000000);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;
                case "Centimeters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 100);

                    totalPrice = newPrintArea * QTPrice;

                    lblCost.Text = totalPrice.ToString();

                    break;

            }
        }



        private string[] Validation()
        {
            string[] result = new string[2];

            if (lbslno.Text == "0")
            {
                result[0] = "false";
                result[1] = string.Empty;

                if (rdsizetype.SelectedValue == "0" && gvSizeChild.Rows.Count > 0)
                {
                    result[0] = "true";
                    result[1] = "You Have seleted board option so adding the value from size detail into the list is invalid";
                }
                else
                {
                    if (rdsizetype.SelectedValue == "1" && gvSizeChild.Rows.Count == 0)
                    {
                        //result[0] = "true";
                        //result[1] = "You Have seleted place option so adding the value from size detail into the list is mandatory ";

                        result[0] = "false";
                        result[1] = string.Empty;
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
                result[0] = "false";
                result[1] = string.Empty;

                if (rdsizetype.SelectedValue == "0" && gvSizeChild.Rows.Count > 0)
                {
                    result[0] = "true";
                    result[1] = "You Have seleted board option so adding the value from size detail into the list is invalid";
                }
                else
                {
                    if (rdsizetype.SelectedValue == "1" && gvSizeChild.Rows.Count == 0)
                    {
                        //result[0] = "true";
                        //result[1] = "You Have seleted place option so adding the value from size detail into the list is mandatory ";
                        result[0] = "false";
                        result[1] = string.Empty;

                    }
                    else
                    {
                        result[0] = "false";
                        result[1] = string.Empty;
                    }
                }
            }
            return result;
        }

        private string[] Validation2()
        {
            string[] result = new string[2];

            result[0] = "false";
            result[1] = string.Empty;

            if (cmbSendToType.SelectedItem.Value.ToString() == "0")
            {
                result[0] = "true";
                result[1] = "Please select send to type!";
                return result;
            }

            if (cmbSendToType.SelectedItem.Value.ToString() != "0")
            {
                if (cmbSendToType.SelectedItem.Value.ToString() != "4")
                {
                    if (cmbSendTo.SelectedIndex == -1)
                    {
                        result[0] = "true";
                        result[1] = "Please select send to name!";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtSendToOther.Text))
                    {
                        result[0] = "true";
                        result[1] = "Please enter other name!";
                        return result;
                    }
                    if (string.IsNullOrEmpty(txtAddress.Text))
                    {
                        result[0] = "true";
                        result[1] = "Please enter address!";
                    }
                }
                return result;
            }

            return result;
        }

        private bool IsPricingAvailable()
        {
            bool result = false;

            foreach (GridViewRow row in gvPrinter.Rows)
            {
                HiddenField hfMaterialID = (HiddenField)row.FindControl("hfMaterialID");

                string Rate = row.Cells[2].Text;
                string Unit = row.Cells[3].Text;

                if (hfMaterialID.Value == subsubjobtypeID.Text)
                {
                    lblPricingUnit.Text = Unit;
                    lblPrice.Text = Rate;
                    hfAllowSubmit.Value = "1";
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Assign The Printer For A Job.
        /// </summary>
        protected void DataInsert()
        {
            if (lbslno.Text == "0" || cmbPrinter.Value == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select printer.','error',3);", true);
            }
            else
            {
                //if (rdsizetype.SelectedValue == "0" && (txtbwidth.Text == string.Empty || txtbheight.Text == string.Empty || txtpwidth.Text == string.Empty || txtpheight.Text == string.Empty))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Please Add both Print Height and Width.  !','warning',3);", true);
                //}
                //else if (rdsizetype.SelectedValue == "1" && (gvSizeChild.Rows.Count == 0))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Please Add Size Details  !','warning',3);", true);
                //}
                //else 

                if (hfAllowSubmit.Value.ToString() == "0")
                {
                    if (gvPrinter.Rows.Count <= 0 || !IsPricingAvailable() || lblCost.Text == "" || lblCost.Text == "0.00" || lblCost.Text == "0")
                    {
                        if (hfAllowSubmit.Value.ToString() == "0")
                        {
                            printmsg.Style.Add("display", "block");
                            fabmsg.Style.Add("display", "none");
                            lblPopupsubsubjobtype.Text = subsubjobtype.Text;
                            this.mpeConfirmPopup.Show();
                        }
                        //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", " confirm('Oops! Selected printer have not added pricing for the printing material - " + subsubjobtype.Text + ". Still you want to assign printer?'); 'yes,no'", true);
                    }
                }
                else if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && hfAllowSubmit2.Value.ToString() == "0" && hfIsFabSend.Value.ToString() == "1")
                {
                    if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && (gvfabdetail.Rows.Count <= 0 || !IsPricingAvailablef() || lblFabricatorCost.Text == "" || lblFabricatorCost.Text == "0.00" || lblFabricatorCost.Text == "0"))
                    {
                        if (hfAllowSubmit2.Value.ToString() == "0")
                        {
                            printmsg.Style.Add("display", "none");
                            fabmsg.Style.Add("display", "block");
                            lblPopupdesigntype.Text = designtyp.Text;
                            this.mpeConfirmPopup2.Show();
                        }
                        //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", " confirm('Oops! Selected printer have not added pricing for the printing material - " + subsubjobtype.Text + ". Still you want to assign printer?'); 'yes,no'", true);
                    }
                }
                //else if (gvPrinter.Rows.Count <= 0 || !IsPricingAvailable() || lblCost.Text == "" || lblCost.Text == "0.00" || lblCost.Text == "0")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Selected printer have not added pricing for the printing material - " + subsubjobtype.Text + " !','warning',3);", true);
                //}
                //else if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && (gvfabdetail.Rows.Count <= 0 || !IsPricingAvailablef() || lblFabricatorCost.Text == "" || lblFabricatorCost.Text == "0.00" || lblFabricatorCost.Text == "0"))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Selected fabricator have not added pricing for the fabrication material - " + designtyp.Text + " !','warning',3);", true);
                //}
                else
                {
                    if (Validation()[0] == "true")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
                    }
                    else if (Validation2()[0] == "true")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation2()[1] + "','warning',3);", true);
                    }
                    else if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && string.IsNullOrEmpty(lblFabricatorLocationID.Text) || lblFabricatorLocationID.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! This job cant sent to Fabricator as fabricator location is not mentioned.','warning',3);", true);
                    }
                    else
                    {
                        #region UpperEntry

                        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dst = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();

                        int assignslno = Convert.ToInt32(lbldslno.Text);

                        int slno = Convert.ToInt32(lbslno.Text);

                        dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                        dst.slno = slno;
                        dst.sizetype = Convert.ToInt32(rdsizetype.SelectedValue);

                        Core.DesignSubmit.DesignSubmit objinsert = new Core.DesignSubmit.DesignSubmit();
                        result = objinsert.DesignSubmitUpdateMethod(dst);

                        if (result != -1)
                        {
                            //if (rdsizetype.SelectedValue == "0")
                            //{
                            //    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty sizechild = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //    decimal boardwidth = Convert.ToDecimal(txtbwidth.Text);
                            //    decimal boardheight = Convert.ToDecimal(txtbheight.Text);
                            //    decimal printwidth = Convert.ToDecimal(txtpwidth.Text);
                            //    decimal printheight = Convert.ToDecimal(txtpheight.Text);
                            //    sizechild.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                            //    sizechild.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                            //    sizechild.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));

                            //    sizechild.assignslno = assignslno;
                            //    sizechild.slno = 0;
                            //    sizechild.boardheight = boardheight;
                            //    sizechild.boardwidth = boardwidth;
                            //    sizechild.printheight = printheight;
                            //    sizechild.printwidth = printwidth;
                            //    sizechild.oldsizetype = Convert.ToInt16(lblsizetype.Text);
                            //    sizechild.newsizetype = Convert.ToInt16(rdsizetype.SelectedValue);
                            //    sizechild.refid = result;
                            //    sizechild.pagename = HttpContext.Current.Request.Url.ToString();
                            //    Core.DesignSubmit.DesignSubmit objinsertsizechild = new Core.DesignSubmit.DesignSubmit();
                            //    result3 = objinsert.SizeDesignSubmitInsertMethod(sizechild);
                            //    if (result3 == -1)
                            //    {
                            //        Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //        del.assignslno = Convert.ToInt32(assignslno);
                            //        errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                            //        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                            //        clean();
                            //    }

                            //}
                            //else if (rdsizetype.SelectedValue == "1")
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
                            //        sizechildgrid.slno = 0;
                            //        sizechildgrid.sizeslno = sizeslno;
                            //        sizechildgrid.boardheight = boardheightg;
                            //        sizechildgrid.boardwidth = boardwidthg;
                            //        sizechildgrid.printheight = printheightg;
                            //        sizechildgrid.oldsizetype = Convert.ToInt16(lblsizetype.Text);
                            //        sizechildgrid.newsizetype = Convert.ToInt16(rdsizetype.SelectedValue);
                            //        sizechildgrid.printwidth = printwidthg;
                            //        result3 = objinsert.SizeDesignSubmitInsertMethod(sizechildgrid);
                            //        if (result3 == -1 && lbslno.Text == "0")
                            //        {
                            //            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //            del.assignslno = Convert.ToInt16(assignslno);
                            //            errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured  !','warning',3);", true);
                            //            clean();
                            //            break;
                            //        }
                            //        if (result3 == -1 && lbslno.Text != "0")
                            //        {
                            //            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured during size update please try again  !','warning',3);", true);
                            //            clean();
                            //            break;
                            //        }
                            //    }

                            //}
                            //else
                            //{
                            //    Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                            //    del.assignslno = Convert.ToInt16(assignslno);
                            //    errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Can Not Add Or Update Because You Are Adding Values In Wrong Condition','warning',3);", true);
                            //}


                            if (result != -1 && result3 != -1)
                            {
                                string msg = string.Empty;
                                int result = 0;
                                Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dst2 = new Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty();

                                int printer = Convert.ToInt32(HttpUtility.HtmlEncode(cmbPrinter.Value));
                                int printerlocation = Convert.ToInt32(HttpUtility.HtmlEncode(cmbPrinterLocation.Value));
                                if (printer == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Printer Should not be empty.!','warning',3);", true);
                                }
                                else
                                {
                                    dst2.toprinter = Convert.ToInt32(printer);
                                    dst2.Remark = txtremark.Text;
                                    dst2.newprinterlocation = Convert.ToInt32(printerlocation);
                                    dst2.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                                    dst2.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                                    dst2.pagename = HttpContext.Current.Request.Url.ToString();
                                    dst2.designsubmitid = Convert.ToInt32(lbslno.Text);
                                    dst2.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));

                                    Core.AssigntoPrinter.Assigntoprinter objinsert2 = new Core.AssigntoPrinter.Assigntoprinter();
                                    dst2.reqno = HttpUtility.HtmlEncode(LblRequestNo.Text);
                                    //getrequestno();
                                    dst2.requestno = lbprilrequestno.Text;
                                    dst2.finyear = finYear;


                                    int partytype = 0;
                                    long jobSendID = 0;

                                    if (cmbSendToType.SelectedItem.Value.ToString() == "1")
                                    {
                                        string party = cmbSendTo.SelectedItem.Value.ToString();


                                        partytype = 1;


                                        jobSendID = Convert.ToInt64(cmbSendTo.SelectedItem.Value.ToString().Split('/')[0]);
                                    }
                                    else if (cmbSendToType.SelectedItem.Value.ToString() == "5")
                                    {
                                        string party = cmbSendTo.SelectedItem.Value.ToString();


                                        partytype = 2;


                                        jobSendID = Convert.ToInt64(cmbSendTo.SelectedItem.Value.ToString().Split('/')[0]);
                                    }
                                    else if (cmbSendToType.SelectedItem.Value.ToString() == "2" || cmbSendToType.SelectedItem.Value.ToString() == "3")
                                    {
                                        jobSendID = Convert.ToInt64(cmbSendTo.SelectedItem.Value);
                                    }



                                    dst2.JobSendType = Convert.ToInt16(cmbSendToType.SelectedItem.Value);
                                    dst2.JobSendToID = jobSendID;
                                    dst2.PartyType = partytype;
                                    dst2.JobSendToOther = txtSendToOther.Text.Trim();
                                    dst2.SendToAddress = txtAddress.Text.Trim();

                                    dst2.PrintCost = Convert.ToDecimal(lblCost.Text);

                                    result = objinsert2.ReAssignPrinterInsertMethod(dst2, out string PrEmail, out string PrMobile);
                                    string PrinterEmail = PrEmail;
                                    string PrinterMobile = PrMobile;

                                    string body = "<table style='width:100%;'><tr><td>&nbsp;</td><td>Dear User,</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>New job is assigned to you.Please Login to your <a href='https://branding.goldmedalindia.in/' target='_blank'>Account</a> and submit the details. Original Files for printing purpose will be sending through Email/We transfer.JPG is just for your reference.</a></td><td>&nbsp;</td></tr><tr><td>&nbsp;&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table>";

                                    string emailerror = "0";
                                    if (PrinterEmail != string.Empty)
                                    {
                                        if (PrinterEmail != "")
                                        {
                                            if (PrinterEmail != null)
                                            {
                                                //PrinterEmail = "gaurav.goldmedalindia@gmail.com";
                                                emailerror = objinsert2.sendmail(PrinterEmail, body, "Printer Assign", "Goldmedal Branding", string.Empty);
                                            }
                                        }
                                    }


                                    if (PrinterMobile != string.Empty)
                                    {
                                        if (PrinterMobile != "")
                                        {
                                            if (PrinterMobile != null)
                                            {
                                                byte[] bufData = null;
                                                using (System.Net.WebClient web = new System.Net.WebClient())
                                                {
                                                    //PrinterMobile = "9920420506";
                                                    string smsbody = "Dear User, New job is assigned to you.Please Login to your account https://branding.goldmedalindia.in and submit the details. Original Files for printing purpose will be sending through Email/We transfer.JPG is just for your reference.  Thanks Team Goldmedal";
                                                    // string msgurl = "http://sms6.rmlconnect.net:8080/bulksms/bulksms?username=goldmedal&password=sd56jjaa&type=0&dlr=0&destination=" + PrinterMobile.Trim() + "&source=GLDMDL&message=" + smsbody + "&url=KKKK%3E";

                                                    string msgurl = "http://sms6.rmlconnect.net:8080/bulksms/bulksms?username=goldmedal&password=sd56jjaa&type=0&dlr=1&destination=" + PrinterMobile.Trim() + "&source=GLDMDL&message=" + smsbody + "&entityid=1601100000000001629&tempid=1007678896123869298";

                                                    bufData = web.DownloadData(msgurl);
                                                }
                                            }
                                        }
                                    }


                                    if (result == 1 && emailerror == "1")
                                    {
                                        // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Assigned To Printer successfully And Your Request Is " + lbprilrequestno.Text + " !','success',3);", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Assigned To Printer & Email sent successfully !','success',3);", true);
                                        clean();
                                    }
                                    else if (result == 1 && emailerror == "-1")
                                    {
                                        // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Assigned To Printer successfully And Your Request Is " + lbprilrequestno.Text + " !','success',3);", true);
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Assigned To Printer successfully but Email not sent !','success',3);", true);
                                        clean();
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                                        clean();
                                    }
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        }

                        #endregion UpperEntry
                    }
                }
            }
            //clean();
        }

        /// <summary>
        /// Clean All The Control.
        /// </summary>
        protected void clean()
        {
            printmsg.Style.Add("display", "none");
            fabmsg.Style.Add("display", "none");
            hfIsFabSend.Value = "0";
            hfAllowSubmit.Value = "0";
            hfAllowSubmit2.Value = "0";
            hfFabPricingAvailable.Value = "0";
            LblRequestNo.Text = string.Empty;
            lblNameType.Text = string.Empty;
            lblName.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblContact.Text = string.Empty;
            lblContactPerson.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblSubName.Text = string.Empty;
            lblSubAddress.Text = string.Empty;
            lblSubContact.Text = string.Empty;
            jobtype.Text = string.Empty;
            subjobtype.Text = string.Empty;
            subsubjobtype.Text = string.Empty;
            designtyp.Text = string.Empty;
            product.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblGivenBy.Text = string.Empty;
            lbltotalamount.Text = string.Empty;
            lblchildid.Text = string.Empty;
            lblqty.Text = string.Empty;
            lblpricontect.Text = string.Empty;
            lblpriemail.Text = string.Empty;
            lblprimobile.Text = string.Empty;
            ImgLink.Text = string.Empty;
            deslink.Text = string.Empty;
            cmbPrinter.SelectedIndex = -1;
            lblPrintLocationID.Text = "0";

            gvPrinter.DataSource = null;
            gvPrinter.DataBind();

            hfPrintFile.Text = "";
            hfPrintFileDelete.Text = "";

            txtremark.Text = string.Empty;
            lblDesignerName.Text = string.Empty;
            txtboardhight.Text = string.Empty;
            txtboardwidth.Text = string.Empty;
            txtprintheight.Text = string.Empty;
            txtprintwidth.Text = string.Empty;
            txtpheight.Text = string.Empty;
            txtpwidth.Text = string.Empty;
            txtbheight.Text = string.Empty;
            txtbwidth.Text = string.Empty;

            lblUnitID.Text = string.Empty;
            subsubjobtypeID.Text = string.Empty;

            cmbSendTo.SelectedIndex = -1;
            cmbSendToType.SelectedIndex = 0;
            txtSendToOther.Text = "";
            txtAddress.Text = "";
            lblsendto.Text = "";
            ddlsendto.Style.Add("display", "none");
            othername.Style.Add("display", "none");
            address.Style.Add("display", "none");

            lblFabricatorLocationID.Text = string.Empty;

            lblCinNo.Text = string.Empty;

            lblBranchID.Text = string.Empty;
            lblBranch.Text = string.Empty;

            lbslno.Text = "0";
            ASPxGridView1.DataBind();
            ASPxGridView2.DataBind();
            lblchildid.Text = "0";
            lbprilrequestno.Text = string.Empty;
            loadchild();
            loadsizechild();
            ASPxPageControl1.ActiveTabIndex = 1;
            lbslno.Text = "0";
            lblchildid.Text = "0";
            lblJobRemark.Text = string.Empty;
            designtypeID.Text = string.Empty;
            lblPricingUnit.Text = string.Empty;
            lblPrice.Text = string.Empty;

            lblPricingUnitf.Text = string.Empty;
            lblPricef.Text = string.Empty;

            fabcost.Style.Add("display", "none");

            partyremark.Style.Add("display", "none");

            lblDSSlno.Text = "0";
            liveproduct.Style.Add("display", "none");
            printerdetails.Style.Add("display", "none");
            txtPrintLink.Text = string.Empty;
            hfApprovedPrintImage.Text = string.Empty;
        }

        /// <summary>
        /// Get The Request No during the printer assign.
        /// </summary>
        protected void getrequestno()
        {
            var Type = "Printer";
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
            Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty getdtl = new Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty();
            getdtl.comman = comman;
            getdtl.type = Type;
            Core.AssigntoPrinter.Assigntoprinter objdataHead = new Core.AssigntoPrinter.Assigntoprinter();
            DataTable dtreqno = objdataHead.PriReqnoCore(getdtl);
            if (dtreqno.Rows.Count > 0)
            {
                lbprilrequestno.Text = Convert.ToString(dtreqno.Rows[0]["reqno"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','SomeThingWrong.','error',2);", true);
            }
        }

        /// <summary>
        /// show the name of image accounding the link
        /// </summary>
        /// <param name="slno"></param>
        /// <param name="flag"></param>
        protected void GetUploadedJobRequestFiles(long slno, int flag)
        {
            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();

            if (flag == 3)
            {
                param.slno = slno;
                hfPopupImageFlag.Value = "3";
            }
            else if (flag == 4)
            {
                param.slno = slno;
                hfPopupImageFlag.Value = "4";
            }
            else if (flag == 10)
            {
                param.slno = slno;
                hfPopupImageFlag.Value = "10";
            }
            else if (flag == 12)
            {
                param.slno = slno;
                hfPopupImageFlag.Value = "12";
            }


            param.flag = flag;

            Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            DataTable dtResult = objData.JobRequestChildFilesDACore(param);

            if (flag == 12)
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

        #endregion Methods


        protected void rptImages1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string userid = e.CommandArgument.ToString();
            LinkButton lnkDown = (LinkButton)e.Item.FindControl("lnkDown");
            HiddenField hfImgIName = (HiddenField)e.Item.FindControl("hfImgIName");
            HiddenField rphfslno = (HiddenField)e.Item.FindControl("rphfslno");
            if (e.CommandName == "cmdRemove")
            {
                hfPrintFile.Text = hfPrintFile.Text.Trim().Replace(hfImgIName.Value, "");
                hfPrintFileDelete.Text = hfPrintFileDelete.Text + ',' + hfImgIName.Value;
                e.Item.FindControl("imgDocs").Parent.Parent.Visible = false;
                this.mpeImage1.Show();
            }
            if (e.CommandName == "Down")
            {
                var path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfImgIName.Value);
                Download(path);
                GetUploadedJobRequestFiles(Convert.ToInt64(lbslno.Text), 12);
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
            if (hfImgIName.Value.Contains(".cdr"))
            {
                imgDocs.ImageUrl = "~/images/txt-icon.jpg";
                imgDocs.ToolTip = "Download cdr";
                hyLink.NavigateUrl = FileIdPath;
            }
        }



        protected void rptAllImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hfPImgName = (HiddenField)e.Item.FindControl("hfPImgName");

            var path = "";

            if (e.CommandName == "Down")
            {
                if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
                }
                else if (hfPopupImageFlag.Value == "4")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 4);
                }
                else if (hfPopupImageFlag.Value == "10")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDSSlno.Text), 10);
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

            if (hfPopupImageFlag.Value == "3")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "4")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "10")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
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

        private void loadfabricatormaterial()
        {
            DataTable dt6 = new DataTable();

            Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle = new Data.Fabricator.FabricatorModel.FabricatorInsert();
            dtsingle.slno = Convert.ToInt32(cmbSendTo.Value);
            dtsingle.BranchID = Convert.ToInt32(lblFabLocationID.Text);
            Core.Fabricator.Fabricator objselectall = new Core.Fabricator.Fabricator();
            dt6 = objselectall.GetDetailOfMaterialListForFabricator(dtsingle);
            gvfabdetail.DataSource = dt6;
            gvfabdetail.DataBind();
            CalculateCostf();
        }

        private bool IsPricingAvailablef()
        {
            bool result = false;

            foreach (GridViewRow row in gvfabdetail.Rows)
            {
                HiddenField hfMaterialID = (HiddenField)row.FindControl("hfMaterialID");

                string Rate = row.Cells[2].Text;
                string Unit = row.Cells[3].Text;

                if (hfMaterialID.Value == designtypeID.Text)
                {
                    lblPricingUnitf.Text = Unit;
                    lblPricef.Text = Rate;
                    hfAllowSubmit2.Value = "1";
                    hfFabPricingAvailable.Value = "1";
                    result = true;
                    fabcost.Style.Add("display", "block");
                    break;
                }
            }

            return result;
        }

        private void CalculateCostf()
        {
            if (IsPricingAvailablef())
            {
                if (rdsizetype.SelectedValue == "0")
                {
                    CalculateSizef(Convert.ToDecimal(txtbwidth.Text == "" ? "0" : txtbwidth.Text), Convert.ToDecimal(txtbheight.Text == "" ? "0" : txtbheight.Text));
                }
                else if (rdsizetype.SelectedValue == "1")
                {
                    decimal width = 0;
                    decimal height = 0;
                    double cost = 0; // Convert.ToDouble(lblCost.Text);
                    lblFabricatorCost.Text = "0";
                    if (gvSizeChild.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in gvSizeChild.Rows)
                        {
                            cost = Convert.ToDouble(lblFabricatorCost.Text);

                            height = Convert.ToDecimal(row.Cells[1].Text);
                            width = Convert.ToDecimal(row.Cells[2].Text);


                            CalculateSizef(width, height);
                            cost = cost + Convert.ToDouble(lblFabricatorCost.Text);
                        }
                        lblFabricatorCost.Text = cost.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please add size details.','error',3);", true);
                    }
                }
            }
            else
            {
                hfAllowSubmit2.Value = "0";
                hfFabPricingAvailable.Value = "0";
                lblFabricatorCost.Text = "0.00";
            }

            RoundCostf();
        }

        private void RoundCostf()
        {
            if (!string.IsNullOrEmpty(lblFabricatorCost.Text) && !string.IsNullOrEmpty(lblqty.Text))
            {
                double cost = Convert.ToDouble(lblFabricatorCost.Text);

                cost = cost * Convert.ToInt32(lblqty.Text);

                lblFabricatorCost.Text = cost.ToString("F2");
            }
        }

        private void CalculateSizef(decimal width, decimal height)
        {
            string jrUnit = lblUnit.Text;
            string PricingUnit = lblPricingUnitf.Text;

            decimal totalPrintArea = 0;
            decimal totalPrice = 0;
            decimal QTPrice = Convert.ToDecimal(lblPricef.Text);

            if (width == 0 || height == 0)
            {
                lblFabricatorCost.Text = "0.00";
            }
            else
            {
                totalPrintArea = width * height;

                if (lblUnit.Text == lblPricingUnitf.Text)
                {
                    totalPrice = totalPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();
                }
                else
                {
                    switch (PricingUnit)
                    {
                        case "Inches":

                            ConvertInchesf(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Feet":

                            ConvertFeetf(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Meters":

                            ConvertMetersf(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Centimeters":

                            ConvertCentimetersf(jrUnit, totalPrintArea, QTPrice);
                            break;
                        case "Millimeters":

                            ConvertMillimetersf(jrUnit, totalPrintArea, QTPrice);
                            break;
                        default:
                            lblFabricatorCost.Text = "0.00";
                            break;
                    }
                }
            }
        }

        private void ConvertInchesf(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Feet":

                    newPrintArea = totalPrintArea * 144;

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Meters":

                    newPrintArea = totalPrintArea * 1550;

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Centimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, Convert.ToDecimal(6.452));

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 645);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertFeetf(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Divide(totalPrintArea, 144);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;

                case "Meters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(10.764));

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Centimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 929);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 92903);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertMetersf(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Divide(totalPrintArea, 1550);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Feet":

                    newPrintArea = Decimal.Divide(totalPrintArea, Convert.ToDecimal(10.764));

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;

                case "Centimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 10000);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 1000000);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertCentimetersf(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(6.452));

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Feet":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 929);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Meters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 10000);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;

                case "Millimeters":

                    newPrintArea = Decimal.Divide(totalPrintArea, 100);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
            }
        }

        private void ConvertMillimetersf(string jrUnit, decimal totalPrintArea, decimal QTPrice)
        {
            decimal newPrintArea = 0;
            decimal totalPrice = 0;

            switch (jrUnit)
            {
                case "Inches":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(645));

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Feet":

                    newPrintArea = Decimal.Multiply(totalPrintArea, Convert.ToDecimal(92903));

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Meters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 1000000);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;
                case "Centimeters":

                    newPrintArea = Decimal.Multiply(totalPrintArea, 100);

                    totalPrice = newPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();

                    break;

            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            hfAllowSubmit.Value = "1";
            this.mpeConfirmPopup.Hide();
            DataInsert();
            clean();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            hfAllowSubmit.Value = "0";
            this.mpeConfirmPopup.Hide();
        }

        protected void btnYes2_Click(object sender, EventArgs e)
        {
            hfAllowSubmit2.Value = "1";
            this.mpeConfirmPopup2.Hide();
            DataInsert();
        }

        protected void btnNo2_Click(object sender, EventArgs e)
        {
            hfAllowSubmit2.Value = "0";
            this.mpeConfirmPopup2.Hide();
        }

        protected void cmbPrinterLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrinterList(Convert.ToInt32(cmbPrinterLocation.Value));
        }
    }
}