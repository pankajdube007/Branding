using DevExpress.Web;
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

namespace GoldMedal.Branding.Admin.Transaction.AssignToFabricator
{
    public partial class AssignToFabricator : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit ";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/submitimagebyprinter";
        private readonly IGoldMedia _goldMedia;
        private readonly string finYear = string.Empty;
        #region PageEvent

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
                    lbldesignsubmitsslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
            }
        }
        public AssignToFabricator()
        {
            _goldMedia = new GoldMedia();
            //  finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }
        #endregion PageEvent

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
        /// Show the image submitted by the printer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt32(lblassignprinterslno.Text), 5);
            this.mpeImage2.Show();
        }

        /// <summary>
        /// track the location of the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   

        /// <summary>
        /// shoe the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
           // lbldesignsubmitsslno.Text = FieldTripID.ToString();
            lblassignprinterslno.Text = FieldTripID.ToString();
            show2();
        }

        protected void CmdEdit2_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
           // lbldesignsubmitsslno.Text = FieldTripID.ToString();
            lblassignprinterslno.Text = FieldTripID.ToString();
            show();
        }

        /// <summary>
        /// Load The Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Assign the job to the fabricator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Load the detail of the fabricator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmbfab_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadfabdetail();
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// List Of Assigned submited by the user.
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dsp = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dsp.slno = Convert.ToInt32(lbldesignsubmitsslno.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignToFabricator.AssignToFabricator objselectall = new Core.AssignToFabricator.AssignToFabricator();
            dt5 = objselectall.ListOfJobForAssignToFabricator(dsp);
            return dt5;
        }


        private DataTable GetTable3()
        {
            DataTable dt5 = new DataTable();
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dsp = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            dsp.slno = 0;
            Core.AssignToFabricator.AssignToFabricator objselectall = new Core.AssignToFabricator.AssignToFabricator();
            dt5 = objselectall.ListOfJobForAssignToFabricatorSendByPrinter(dsp);
            return dt5;
        }

        /// <summary>
        /// fill all the control for the edit the submited design.
        /// </summary>
        protected void show2()
        {
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dtsingle.slno = Convert.ToInt32(lblassignprinterslno.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
            DataTable dt = objselectsingle.ListOfJobForAssignToFabricator(dtsingle);
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
                lbldesignsubmitsslno.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
                designtypeID.Text = Convert.ToString(dt.Rows[0]["designtypeid"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                product.Text = Convert.ToString(dt.Rows[0]["product"]);
                lbltotalamount.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["childid"]);
                lblprinterid.Text = Convert.ToString(dt.Rows[0]["printerslno"]);
                lblassignprinterslno.Text = Convert.ToString(dt.Rows[0]["assignprinterid"]);
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
                
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);

                FabricatorList(Convert.ToInt32(Convert.ToString(dt.Rows[0]["FabricatorLocationID"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["FabricatorLocationID"])));

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

            }
            loadchild();
            loadsizechild();
            loadprintermaterial();
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        protected void show()
        {
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dtsingle.slno = Convert.ToInt32(lblassignprinterslno.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
            DataTable dt = objselectsingle.ListOfJobForAssignToFabricatorSendByPrinter(dtsingle);
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
                lbldesignsubmitsslno.Text = Convert.ToString(dt.Rows[0]["designsubmitslno"]);
                designtypeID.Text = Convert.ToString(dt.Rows[0]["designtypeid"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                product.Text = Convert.ToString(dt.Rows[0]["product"]);
                lbltotalamount.Text = Convert.ToString(dt.Rows[0]["totalamount"]);
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblchildid.Text = Convert.ToString(dt.Rows[0]["childid"]);
                lblprinterid.Text = Convert.ToString(dt.Rows[0]["printerslno"]);
                lblassignprinterslno.Text = Convert.ToString(dt.Rows[0]["assignprinterid"]);
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

                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);

                FabricatorList(Convert.ToInt32(Convert.ToString(dt.Rows[0]["FabricatorLocationID"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["FabricatorLocationID"])));
            }
            loadchild();
            loadsizechild();
            loadprintermaterial();
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        /// <summary>
        /// Load The Grid Of The Item.
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
        /// Load The Grid Of The Size.
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
                a = lblassignprinterslno.Text;

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
        /// Load The material of the printer
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

        /// <summary>
        /// Load the material of the fabricator.
        /// </summary>
        private void loadfabricatormaterial()
        {
            DataTable dt6 = new DataTable();

            Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle = new Data.Fabricator.FabricatorModel.FabricatorInsert();
            dtsingle.slno = Convert.ToInt32(cmbFab.Value);
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
                lblCost.Text = "0";
                if (gvSizeChild.Rows.Count > 0)
                {
                    foreach (GridViewRow row in gvSizeChild.Rows)
                    {
                        cost = Convert.ToDouble(lblCost.Text);

                        height = Convert.ToDecimal(row.Cells[0].Text);
                        width = Convert.ToDecimal(row.Cells[1].Text);


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
            else
            {
                lblCost.Text = "0.00";
            }

            RoundCost();
        }

        private void RoundCost()
        {
            if (!string.IsNullOrEmpty(lblCost.Text) && !string.IsNullOrEmpty(lblqty.Text))
            {
                double cost = Convert.ToDouble(lblCost.Text);

                cost = cost * Convert.ToInt32(lblqty.Text);

                lblCost.Text = cost.ToString("F2");
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
                        case "Piece":

                            lblCost.Text = QTPrice.ToString();
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



        /// <summary>
        /// Load the fabricator detail.
        /// </summary>
        protected void loadfabdetail()
        {
            Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle = new Data.Fabricator.FabricatorModel.FabricatorInsert();
            dtsingle.slno = Convert.ToInt32(cmbFab.Value);
            Core.Fabricator.Fabricator objselectsingle = new Core.Fabricator.Fabricator();
            DataTable dt = objselectsingle.GetFabricatorSingle(dtsingle);
            if (dt.Rows.Count > 0)
            {
                lblfabcontact.Text = Convert.ToString(dt.Rows[0]["contact"]);
                lblfabemail.Text = Convert.ToString(dt.Rows[0]["emailid"]);
                lblfabmobile.Text = Convert.ToString(dt.Rows[0]["mobile"]);
                loadfabricatormaterial();
            }
        }

        /// <summary>
        /// Assign a job to the fabricator.
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            if (lbldesignsubmitsslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select any one record...!','warning',3);", true);
            }
            else
            {
                Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dst = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
                int fabricator = Convert.ToInt32(HttpUtility.HtmlEncode(cmbFab.Value));
                if (fabricator == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Fabricator Should not be empty.!','warning',3);", true);
                }
                else if (gvfabdetail.Rows.Count <= 0 || !IsPricingAvailable() || lblCost.Text == "" || lblCost.Text == "0.00" || lblCost.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! Selected fabricator have not added pricing for the fabrication material - " + designtyp.Text + " !','warning',3);", true);
                }
                else
                {
                    dst.tofabricator = Convert.ToInt32(fabricator);
                    dst.Remark = txtremark.Text;
                    dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.pagename = HttpContext.Current.Request.Url.ToString();
                    dst.designsubmitid = Convert.ToInt32(lbldesignsubmitsslno.Text);
                    dst.assignprinterslno = Convert.ToInt32(lblassignprinterslno.Text);
                    
                    dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                    Core.AssignToFabricator.AssignToFabricator objinsert = new Core.AssignToFabricator.AssignToFabricator();
                    // getrequestno();
                    dst.jobreqno = HttpUtility.HtmlEncode(LblRequestNo.Text);
                    dst.finyear = finYear;
                    dst.reqno = lbfablrequestno.Text;

                    dst.FabricationCost = Convert.ToDecimal(lblCost.Text);

                    result = objinsert.AssignFabricatorInsertMethod(dst);
                    if (result == 1)
                    {
                        // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Assigned To Fabricator successfully And Your Request No Is " + lbfablrequestno.Text + " !','success',3);", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Assigned To Fabricator successfully !','success',3);", true);
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                    }
                }
            }
            clean();
        }

        /// <summary>
        /// Clean The control.
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
            lblfabmobile.Text = string.Empty;
            lblfabcontact.Text = string.Empty;
            lblfabemail.Text = string.Empty;
            lblfabmobile.Text = string.Empty;
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
            lblassignprinterslno.Text = "0";
            cmbFab.SelectedIndex = -1;
            lblprinter.Text = string.Empty;
            lblpriemail.Text = string.Empty;
            lblpricontect.Text = string.Empty;
            lbfablrequestno.Text = string.Empty;
            lblprimobile.Text = string.Empty;
            cmbFab.SelectedIndex = -1;
            lblfabcontact.Text = string.Empty;
            lblfabemail.Text = string.Empty;
            lblfabmobile.Text = string.Empty;
            ImgLink.Text = string.Empty;
            ImgLink.NavigateUrl = string.Empty;
            deslink.Text = string.Empty;
            deslink.NavigateUrl = string.Empty;
            prilink.Text = string.Empty;
            prilink.NavigateUrl = string.Empty;
            lblJobRemark.Text = string.Empty;
            designtypeID.Text = string.Empty;


            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";

            loadfabricatormaterial();
            ASPxGridView1.DataBind();
            loadchild();
            loadsizechild();
            loadprintermaterial();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        /// <summary>
        /// Genrate the request for the job .
        /// </summary>
        protected void getrequestno()
        {
            var Type = "Fab";
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
                lbfablrequestno.Text = Convert.ToString(dtreqno.Rows[0]["reqno"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','SomeThingWrong.','error',2);", true);
            }
        }

        /// <summary>
        /// List of Fabricator.
        /// </summary>
        protected void FabricatorList(int BranchID)
        {
            Core.Fabricator.Fabricator objselectsingle = new Core.Fabricator.Fabricator();
            DataTable dt = objselectsingle.GetFabricatorByLocation(BranchID);
            cmbFab.DataSource = dt;
            cmbFab.TextField = "name";
            cmbFab.ValueField = "slno";
            cmbFab.SelectedIndex = -1;
            cmbFab.DataBind();
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
                GetUploadedJobRequestFiles(Convert.ToInt32(lblassignprinterslno.Text), 5);
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

    }
}