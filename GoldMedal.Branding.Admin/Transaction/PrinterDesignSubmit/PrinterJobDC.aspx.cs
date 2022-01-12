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

namespace GoldMedal.Branding.Admin.Transaction.PrinterDesignSubmit
{
    public partial class PrinterJobDC : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit ";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/submitimagebyprinter";

        private readonly string finYear = string.Empty;

        public PrinterJobDC()
        {
            //finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }

        #region PageEvent

        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (usertype == "1")
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
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }

        #endregion PageEvent

        #region Events

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 1)
            {
                ASPxGridView1.DataBind();
            }
        }

        /// <summary>
        /// Show the image which are added  in job request child.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
            this.mpeImage.Show();
        }

        /// <summary>
        /// Show the image which are added  in designsubmit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbldesignsubmitsslno.Text), 4);
            this.mpeImage1.Show();
        }

        /// <summary>
        /// Show the image which are added  by the printer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 5);
            this.mpeImage2.Show();
        }




        /// <summary>
        /// shoe the detail of submited design by the printer
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

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        protected void cmbSendToType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSendToOther.Text = "";
            cmbSendTo.SelectedIndex = -1;
            lblsendto.Text = "";
            ddlsendto.Style.Add("display", "none");
            othername.Style.Add("display", "none");
            txtAddress.Text = "";
            address.Style.Add("display", "none");

            fabcost.Style.Add("display", "none");
            lblFabricatorCost.Text = "";

            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for send..','error',3);", true);
            }
            else
            {
                if (cmbSendToType.SelectedItem != null)
                {
                    if (cmbSendToType.SelectedItem.Value.ToString() != "0")
                    {
                        if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3)
                        {
                            if (string.IsNullOrEmpty(lblFabricatorLocationID.Text) || lblFabricatorLocationID.Text == "0")
                            {
                                cmbSendToType.SelectedIndex = 0;
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! This job cant sent to Fabricator as fabricator location is not mentioned.','warning',3);", true);
                            }
                        }
                        else
                        {
                            if (cmbSendToType.SelectedItem.Value.ToString() != "4")
                            {
                                BindSendToList(Convert.ToInt16(cmbSendToType.SelectedItem.Value));

                                lblsendto.Text = cmbSendToType.SelectedItem.Text + ":";

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
                        txtAddress.Text = "";
                        address.Style.Add("display", "none");
                    }
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
                        string sendtoid = cmbSendTo.SelectedItem.Value.ToString().Split('/').First();
                        int partytype = Convert.ToInt16(cmbSendTo.SelectedItem.Value.ToString().Split('/').Last());

                        GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);

                        address.Style.Add("display", "block");
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "2")
                    {
                        GetAddressFromName(Convert.ToInt64(cmbSendTo.SelectedItem.Value), Convert.ToInt16(cmbSendToType.SelectedItem.Value), 0);
                        txtAddress.Enabled = false;
                        address.Style.Add("display", "block");
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "3")
                    {
                        txtAddress.Text = "";
                        address.Style.Add("display", "none");
                        loadfabricatormaterial();
                    }
                    if (cmbSendToType.SelectedItem.Value.ToString() == "4")
                    {
                        txtAddress.Text = "";
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

        #endregion Events

        #region Methods

        protected void BindSendToList(int SendToType)
        {
            int fabLoc = 0;
            fabLoc = lblFabricatorLocationID.Text == "" ? 0 : Convert.ToInt32(lblFabricatorLocationID.Text);

            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            DataTable dt = objselectsingle.GetSendToList(SendToType, fabLoc);
            cmbSendTo.DataSource = dt;
            cmbSendTo.TextField = "name";
            cmbSendTo.ValueField = "slno";
            cmbSendTo.SelectedIndex = -1;
            cmbSendTo.DataBind();
        }

        protected void GetAddressFromName(long SendToID, int SendToType, int PartyType)
        {
            Core.Printer.Printer objselectsingle = new Core.Printer.Printer();
            string Address = objselectsingle.GetAddressFromSendToID(SendToID, SendToType, PartyType);
            txtAddress.Text = Address;
        }

        /// <summary>
        /// List Of Job Done By Printer For Approval
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            //dsp.printer = 4;
            dsp.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectall = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            dt4 = objselectall.GetApprovedJobsForDC(dsp);
            return dt4;
        }

        /// <summary>
        /// fill all the control.
        /// </summary>
        protected void show2()
        {
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            dsp.slno = Convert.ToInt32(lbslno.Text);
            dsp.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectsingle = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            DataTable dt = objselectsingle.GetSingleApprovedJobsForDC(dsp);
            if (dt.Rows.Count > 0)
            {
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
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
                jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                subjobtype.Text = Convert.ToString(dt.Rows[0]["subjob"]);
                subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjob"]);
                designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                designtypeID.Text = Convert.ToString(dt.Rows[0]["designtypeid"]);

                product.Text = Convert.ToString(dt.Rows[0]["product"]);
                lbltotalamount.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["childid"]);
                lblprinterid.Text = Convert.ToString(dt.Rows[0]["printerslno"]);
                lbldesignsubmitsslno.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
                lblprinter.Text = Convert.ToString(dt.Rows[0]["printername"]);
                lblpriemail.Text = Convert.ToString(dt.Rows[0]["printeremail"]);
                lblpricontect.Text = Convert.ToString(dt.Rows[0]["printercontact"]);
                lblprimobile.Text = Convert.ToString(dt.Rows[0]["printermobile"]);
                ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);
                deslink.Text = Convert.ToString(dt.Rows[0]["designlink"]);
                deslink.NavigateUrl = Convert.ToString(dt.Rows[0]["designlink"]);
                prilink.Text = Convert.ToString(dt.Rows[0]["prilink"]);
                prilink.NavigateUrl = Convert.ToString(dt.Rows[0]["prilink"]);


                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);

                lblCost.Text = Convert.ToString(dt.Rows[0]["PrintCost"]);

                hfDesignSubmitID.Value = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
                hfJobRequestNo.Value = Convert.ToString(dt.Rows[0]["reqno"]);

                lblFabricatorLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);

                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);

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

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["JobSendType"])))
                {
                    cmbSendToType.SelectedIndex = Convert.ToInt16(dt.Rows[0]["JobSendType"].ToString());

                    if (cmbSendToType.SelectedItem.Value.ToString() != "0")
                    {
                        if (cmbSendToType.SelectedItem.Value.ToString() == "1")
                        {
                            BindSendToList(Convert.ToInt16(cmbSendToType.SelectedItem.Value));

                            int partytype = Convert.ToInt16(dt.Rows[0]["PartyType"]);

                            if (partytype == 1)
                            {
                                string selectname = Convert.ToString(dt.Rows[0]["JobSendToID"] + "/1");
                                cmbSendTo.Value = selectname;

                                string sendtoid = selectname.Split('/').First();

                                GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);
                            }
                            if (partytype == 2)
                            {
                                string selectname2 = Convert.ToString(dt.Rows[0]["JobSendToID"] + "/2");
                                cmbSendTo.Value = selectname2;

                                string sendtoid = selectname2.Split('/').First();

                                GetAddressFromName(Convert.ToInt64(sendtoid), Convert.ToInt16(cmbSendToType.SelectedItem.Value), partytype);
                            }

                            ddlsendto.Style.Add("display", "block");
                            address.Style.Add("display", "block");
                        }
                        else if (cmbSendToType.SelectedItem.Value.ToString() == "2" || cmbSendToType.SelectedItem.Value.ToString() == "3")
                        {
                            BindSendToList(Convert.ToInt16(cmbSendToType.SelectedItem.Value));

                            cmbSendTo.Value = Convert.ToString(dt.Rows[0]["JobSendToID"]);
                            ddlsendto.Style.Add("display", "block");
                            txtAddress.Text = "";
                            address.Style.Add("display", "none");

                            if (cmbSendToType.SelectedItem.Value.ToString() == "2")
                            {
                                address.Style.Add("display", "block");
                                GetAddressFromName(Convert.ToInt64(dt.Rows[0]["JobSendToID"]), Convert.ToInt16(cmbSendToType.SelectedItem.Value), 0);
                            }
                        }
                        else if (cmbSendToType.SelectedItem.Value.ToString() == "4")
                        {
                            txtSendToOther.Text = Convert.ToString(dt.Rows[0]["JobSendToOther"]);
                            othername.Style.Add("display", "block");

                            txtAddress.Text = Convert.ToString(dt.Rows[0]["SendToAddress"]);
                            address.Style.Add("display", "block");
                        }
                    }
                    else
                    {
                        cmbSendToType.SelectedItem.Value = "0";
                        txtSendToOther.Text = "";
                        cmbSendTo.SelectedIndex = -1;
                        lblsendto.Text = "";
                        ddlsendto.Style.Add("display", "none");
                        othername.Style.Add("display", "none");
                        txtAddress.Text = "";
                        address.Style.Add("display", "none");
                    }
                }
            }
            loadchild();
            loadsizechild();
            loadprintermaterial();

            if (cmbSendToType.SelectedItem.Value.ToString() == "3")
            {
                loadfabricatormaterial();
                fabcost.Style.Add("display", "block");
            }

            cmbSendToType.Enabled = false;
            cmbSendTo.Enabled = false;
            txtSendToOther.Enabled = false;
            txtAddress.Enabled = false;

            ASPxPageControl1.ActiveTabIndex = 0;
        }

        /// <summary>
        /// Loads the grid of item.
        /// </summary>
        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbldesignsubmitsslno.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }

        /// <summary>
        /// Loads the grid of size.
        /// </summary>
        private void loadsizechild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lbldesignsubmitsslno.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);
            gvSizeChild.DataSource = dt6;
            gvSizeChild.DataBind();
        }

        /// <summary>
        /// show the name of image accounding the link
        /// </summary>
        /// <param name="slno"></param>
        /// <param name="flag"></param>
        protected void GetUploadedJobRequestFiles(int slno, int flag)
        {
            //string a = string.Empty;
            //JobRequestDataAccess objselectall = new JobRequestDataAccess();
            //Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();
            //if (flag == 3)
            //{
            //    a = lblchildid.Text;
            //}
            //else if (flag == 4)
            //{
            //    a = lbldesignsubmitsslno.Text;
            //}
            //else
            //{
            //    a = lbslno.Text;
            //}
            //param.slno = Convert.ToInt32(a);
            //param.flag = flag;
            //Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            //DataTable dtResult = objData.JobRequestChildFilesDACore(param);
            //if (dtResult.Rows.Count > 0)
            //{
            //    RptDocs.DataSource = dtResult;
            //    RptDocs.DataBind();
            //    hdNoRecord.Visible = false;
            //}
            //else
            //{
            //    RptDocs.DataSource = null;
            //    RptDocs.DataBind();
            //    hdNoRecord.Visible = true;
            //}
            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();
            if (flag == 3)
            {
                a = lblchildid.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;
                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
                DataTable dtResult = objData.JobRequestChildFilesDACore(param);
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
            else if (flag == 4)
            {
                a = lbldesignsubmitsslno.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;
                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
                DataTable dtResult = objData.JobRequestChildFilesDACore(param);
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
                a = lbslno.Text;

                param.slno = Convert.ToInt32(a);
                param.flag = flag;
                Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
                DataTable dtResult = objData.JobRequestChildFilesDACore(param);
                if (dtResult.Rows.Count > 0)
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

        /// <summary>
        /// Load the material list for the perticular printer
        /// </summary>
        private void loadprintermaterial()
        {
            DataTable dt6 = new DataTable();
            Data.Printer.PrinterModel.PrinterInsert dchildlist = new Data.Printer.PrinterModel.PrinterInsert();
            dchildlist.slno = Convert.ToInt32(lblprinterid.Text);
            dchildlist.BranchID = Convert.ToInt32(lblPrintLocationID.Text);
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt6 = objselectall.GetDetailOfMaterialListForPrinter(dchildlist);
            gvPrinter.DataSource = dt6;
            gvPrinter.DataBind();
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
            CalculateCost();
        }

        private bool IsPricingAvailable()
        {
            bool result = false;

            foreach (GridViewRow row in gvfabdetail.Rows)
            {
                HiddenField hfMaterialID = (HiddenField)row.FindControl("hfMaterialID");

                string Rate = row.Cells[2].Text;
                string Unit = row.Cells[3].Text;

                if (hfMaterialID.Value == designtypeID.Text)
                {
                    lblPricingUnit.Text = Unit;
                    lblPrice.Text = Rate;

                    result = true;
                    fabcost.Style.Add("display", "block");
                    break;
                }
            }

            return result;
        }

        private void CalculateCost()
        {
            if (IsPricingAvailable())
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

                        height = Convert.ToDecimal(row.Cells[0].Text);
                        width = Convert.ToDecimal(row.Cells[1].Text);


                        CalculateSize(width, height);
                        cost = cost + Convert.ToDouble(lblFabricatorCost.Text);
                    }
                    lblFabricatorCost.Text = cost.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please add size details.','error',3);", true);
                }

            }
            else
            {
                lblFabricatorCost.Text = "0.00";
            }

            RoundCost();
        }

        private void RoundCost()
        {
            if (!string.IsNullOrEmpty(lblFabricatorCost.Text) && !string.IsNullOrEmpty(lblqty.Text))
            {
                double cost = Convert.ToDouble(lblFabricatorCost.Text);

                cost = cost * Convert.ToInt32(lblqty.Text);

                lblFabricatorCost.Text = cost.ToString("F2");
            }
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
                lblFabricatorCost.Text = "0.00";
            }
            else
            {
                totalPrintArea = width * height;

                if (lblUnit.Text == lblPricingUnit.Text)
                {
                    totalPrice = totalPrintArea * QTPrice;

                    lblFabricatorCost.Text = totalPrice.ToString();
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
                            lblFabricatorCost.Text = "0.00";
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

        private void ConvertFeet(string jrUnit, decimal totalPrintArea, decimal QTPrice)
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

        private void ConvertMeters(string jrUnit, decimal totalPrintArea, decimal QTPrice)
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

        private void ConvertCentimeters(string jrUnit, decimal totalPrintArea, decimal QTPrice)
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

        private void ConvertMillimeters(string jrUnit, decimal totalPrintArea, decimal QTPrice)
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

        private string[] Validation1()
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

                    if (result[0] == "false")
                    {
                        if (cmbSendToType.SelectedItem.Value.ToString() == "1" || cmbSendToType.SelectedItem.Value.ToString() == "2")
                        {
                            if (string.IsNullOrEmpty(txtAddress.Text))
                            {
                                result[0] = "true";
                                result[1] = "Please enter address!";
                            }
                        }
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


        private bool ISPrinterPOGenerated(string AllSlno)
        {
            bool result = false;
            int getresult = 0;
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            dsp.Allslno = AllSlno;
           Core.PrinterDesignSubmit.PrinterDesignSubmit objselectsingle = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            getresult = objselectsingle.IsPrinterPoGenerated(dsp);
            if(getresult == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Approve the record submited by the printer.
        /// </summary>
        protected void Send()
        {
            string msg = string.Empty;
            int result = 0;


            //List<object> fieldValues = ASPxGridView1.GetSelectedFieldValues(new string[] { "slno" });
            //foreach (object item in fieldValues)
            //{
            //    if (lbmultipleslno.Text == "0")
            //    {
            //        lbmultipleslno.Text = item.ToString();
            //    }
            //    else
            //    {
            //        lbmultipleslno.Text = lbmultipleslno.Text + "," + item.ToString();
            //    }
            //}

            int result1 = 0;





            if (lbmultipleslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for send..','error',3);", true);
            }
            else
            {
                //if (Validation1()[0] == "true")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation1()[1] + "','warning',3);", true);
                //}
                //else if (Validation2()[0] == "true")
                if (Validation2()[0] == "true")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation2()[1] + "','warning',3);", true);
                }
                //else if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && string.IsNullOrEmpty(lblFabricatorLocationID.Text) || lblFabricatorLocationID.Text == "0")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! This job cant sent to Fabricator as fabricator location is not mentioned.','warning',3);", true);
                //}
                //else if (Convert.ToInt32(cmbSendToType.SelectedItem.Value) == 3 && (gvfabdetail.Rows.Count <= 0 || !IsPricingAvailable() || lblFabricatorCost.Text == "" || lblFabricatorCost.Text == "0.00" || lblFabricatorCost.Text == "0"))
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Selected fabricator have not added pricing for the fabrication material - " + designtyp.Text + " !','warning',3);", true);
                //}
                else if(!ISPrinterPOGenerated(lbmultipleslno.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','PO not generated for any of the job !','warning',3);", true);
                    clean();

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


                                Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dst1 = new Data.DesignSubmit.DesignSubmit.PrinterJobDCSend();
                                dst1.slno = Slno;
                                dst1.QtySentByPrinter = Convert.ToInt32(SendingQty.Text);
                                Core.PrinterDesignSubmit.PrinterDesignSubmit objSend1 = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
                                result1 = objSend1.UpdateSentQtybyPrinterMethod(dst1);


                            }
                        }
                    }


                    Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dst = new Data.DesignSubmit.DesignSubmit.PrinterJobDCSend();

                    // dst.slno = Convert.ToInt16(lbslno.Text);

                    dst.Allslno = lbmultipleslno.Text;

                    //int partytype = 0;
                    //long jobSendID = 0;

                    //if (cmbSendToType.SelectedItem.Value.ToString() == "1")
                    //{
                    //    string[] party = cmbSendTo.SelectedItem.Value.ToString().Split('/');

                    //    if (party[1] == "1")
                    //    {
                    //        partytype = 1;
                    //    }

                    //    if (party[1] == "2")
                    //    {
                    //        partytype = 2;
                    //    }

                    //    jobSendID = Convert.ToInt64(cmbSendTo.SelectedItem.Value.ToString().Split('/')[0]);
                    //}
                    //else if (cmbSendToType.SelectedItem.Value.ToString() == "2" || cmbSendToType.SelectedItem.Value.ToString() == "3")
                    //{
                    //    jobSendID = Convert.ToInt64(cmbSendTo.SelectedItem.Value);
                    //}

                    // dst.JobSendType = Convert.ToInt16(cmbSendToType.SelectedItem.Value);
                    // dst.JobSendToID = jobSendID;
                    //  dst.PartyType = partytype;
                    // dst.JobSendToOther = txtSendToOther.Text.Trim();
                    // dst.SendToAddress = txtAddress.Text.Trim();
                    dst.LRNumber = txtLRNumber.Text.Trim();
                    dst.LRDate = txtLRDate.Date.ToString("yyyy-MM-dd");
                    dst.TranspoterName = txtTranspoterName.Text.Trim();


                    dst.InvoiceNumber = txtInvoiceNumber.Text.Trim();
                    dst.InvoiceDate = txtInvoiceDate.Date.ToString("yyyy-MM-dd");
                    dst.TransportMode = cmbTransportMode.SelectedItem.Text.Trim();

                    dst.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");


                    //dst.FabDesignSubmitID = Convert.ToInt64(hfDesignSubmitID.Value);
                    //dst.FabRemark = "";
                    // dst.FabJobReqNo = hfJobRequestNo.Value.Trim();
                    dst.Fabfinyear = finYear;
                    dst.pagename = HttpContext.Current.Request.Url.ToString();

                    dst.FabricationCost = Convert.ToDecimal(lblFabricatorCost.Text == "" ? "0" : lblFabricatorCost.Text);

                    dst.NoofPackages = Convert.ToInt32(txtpkges.Text == "" ? "0" : txtpkges.Text);
                    dst.PrinterDcRemark = txtprintdcremark.Text.Trim();

                    Core.PrinterDesignSubmit.PrinterDesignSubmit objSend = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
                    result = objSend.JobSendByPrinterMethod(dst);
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
            lblCinNo.Text = string.Empty;
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
            jobtype.Text = string.Empty;
            subjobtype.Text = string.Empty;
            subsubjobtype.Text = string.Empty;
            designtyp.Text = string.Empty;
            product.Text = string.Empty;
            lbltotalamount.Text = string.Empty;
            lblqty.Text = string.Empty;
            lblchildid.Text = "0";
            lblprinterid.Text = "0";
            lbldesignsubmitsslno.Text = "0";
            lbslno.Text = "0";
            lblprinter.Text = string.Empty;
            lblpriemail.Text = string.Empty;
            lblpricontect.Text = string.Empty;
            lblprimobile.Text = string.Empty;
            ImgLink.Text = string.Empty;
            ImgLink.NavigateUrl = string.Empty;
            deslink.Text = string.Empty;
            deslink.NavigateUrl = string.Empty;
            prilink.Text = string.Empty;
            prilink.NavigateUrl = string.Empty;
            lblJobRemark.Text = "";
            cmbSendTo.SelectedIndex = -1;
            cmbSendToType.SelectedIndex = 0;
            txtSendToOther.Text = "";
            lblsendto.Text = "";
            ddlsendto.Style.Add("display", "none");
            othername.Style.Add("display", "none");
            txtAddress.Text = "";
            address.Style.Add("display", "none");

            txtLRDate.Text = "";
            txtLRNumber.Text = "";
            txtTranspoterName.Text = "";

            designtypeID.Text = string.Empty;
            lblPricingUnit.Text = string.Empty;
            lblPrice.Text = string.Empty;

            fabcost.Style.Add("display", "none");

            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";
            lbmultipleslno.Text = "0";
            ASPxGridView1.DataBind();
            loadchild();
            loadsizechild();
            loadprintermaterial();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void clean2()
        {
            lblCinNo.Text = string.Empty;
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
            jobtype.Text = string.Empty;
            subjobtype.Text = string.Empty;
            subsubjobtype.Text = string.Empty;
            designtyp.Text = string.Empty;
            product.Text = string.Empty;
            lbltotalamount.Text = string.Empty;
            lblqty.Text = string.Empty;
            lblchildid.Text = "0";
            lblprinterid.Text = "0";
            lbldesignsubmitsslno.Text = "0";
            lbslno.Text = "0";
            lblprinter.Text = string.Empty;
            lblpriemail.Text = string.Empty;
            lblpricontect.Text = string.Empty;
            lblprimobile.Text = string.Empty;
            ImgLink.Text = string.Empty;
            ImgLink.NavigateUrl = string.Empty;
            deslink.Text = string.Empty;
            deslink.NavigateUrl = string.Empty;
            prilink.Text = string.Empty;
            prilink.NavigateUrl = string.Empty;

            designtypeID.Text = string.Empty;
            lblPricingUnit.Text = string.Empty;
            lblPrice.Text = string.Empty;

            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";

            hfDesignSubmitID.Value = "0";
            hfJobRequestNo.Value = "0";
            lblJobRemark.Text = "";
            cmbSendTo.SelectedIndex = -1;
            cmbSendToType.SelectedIndex = 0;
            txtSendToOther.Text = "";
            lblsendto.Text = "";
            ddlsendto.Style.Add("display", "none");
            othername.Style.Add("display", "none");
            txtAddress.Text = "";
            address.Style.Add("display", "none");

            fabcost.Style.Add("display", "none");

            lblFabricatorLocationID.Text = string.Empty;
        }

        #endregion Methods

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
                GetUploadedJobRequestFiles(Convert.ToInt32(lblchildid.Text), 3);
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
            var FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME, hfImgIName.Value);
            hfvisible.Value = "false";

            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
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
                GetUploadedJobRequestFiles(Convert.ToInt32(lbldesignsubmitsslno.Text), 4);
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


            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
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
                GetUploadedJobRequestFiles(Convert.ToInt32(lbslno.Text), 5);
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


            if (hfImgIName.Value.Contains(".jpg") || hfImgIName.Value.Contains(".png") || hfImgIName.Value.Contains(".jpeg"))
            {
                imgDocs.ImageUrl = PictureIDPath;
                hyLink.NavigateUrl = PictureIDPath;
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

            //List<object> fieldValues = ASPxGridView1.GetSelectedFieldValues(new string[] { "slno" });
            //foreach (object item in fieldValues)
            //{
            //    if (lbmultipleslno.Text == "0")
            //    {
            //        lbmultipleslno.Text = item.ToString();

            //    }
            //    else
            //    {
            //        lbmultipleslno.Text = lbmultipleslno.Text + "," + item.ToString();

            //    }

            //}

            //if (lbmultipleslno.Text != "0")
            //{
            //    this.mpeImage3.Show();
            //}
            

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
            Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dsp = new Data.PrinterDesignSubmit.PrinterDesignSubmitProperty();
            //dsp.printer = 4;
            dsp.printer = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("slno");
            Core.PrinterDesignSubmit.PrinterDesignSubmit objselectall = new Core.PrinterDesignSubmit.PrinterDesignSubmit();
            dt4 = objselectall.GetApprovedJobsForViewDC(dsp);
            return dt4;
        }

        protected void CmdEdit_Command1(object sender, CommandEventArgs e)
        {

        }
    }
}