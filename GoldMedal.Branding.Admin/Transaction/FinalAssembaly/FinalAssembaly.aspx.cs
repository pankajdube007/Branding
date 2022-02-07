using DevExpress.Web;
using GoldMedal.Branding.Data.JobRequest;
using System;
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
    public partial class FinalAssembaly : System.Web.UI.Page
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
                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    LoadItemDivision();
                    lblFabricatorAssignID.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                    ASPxGridView2.DataBind();
                }
            }
            createSessionData();
        }

        #endregion PageEvent
        public FinalAssembaly()
        {
            _goldMedia = new GoldMedia();
            finYear = "20-21";
        }
        #region Events
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                ASPxGridView1.DataBind();
            }
        }
        protected void createSessionData()
        {
            if (Session[ViewState["_PageID"].ToString() + "Scheme"] != null)
            {
                dtss = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
            }
            else
            {
                dtss = new DataTable();
                DataColumn pk = dtss.Columns.Add("Slno", typeof(System.Int32));
                pk.AllowDBNull = false;
                pk.Unique = true;
                pk.AutoIncrement = true;
                pk.AutoIncrementSeed = 1;
                pk.AutoIncrementStep = 1;
                dtss.Columns.Add("childslno", typeof(System.Int32));
                dtss.Columns.Add("Itemid", typeof(System.Int32));
                dtss.Columns.Add("Item", typeof(System.String));
                dtss.Columns.Add("Qty", typeof(System.Int32));
                
            }
        }

        protected void lnkFiles1_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadID.Text), 1);
            this.mpeAll.Show();
        }
        protected void lnkFiles2_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadID.Text), 2);
            this.mpeAll.Show();
        }
        protected void lnkFiles3_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblChildID.Text), 3);
            this.mpeAll.Show();
        }
        protected void lnkFiles4_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblChildID.Text), 13);
            this.mpeAll.Show();
        }
        protected void lnkFiles5_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 4);
            this.mpeAll.Show();
        }
        protected void lnkFiles6_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 12);
            this.mpeAll.Show();
        }
        protected void lnkFiles7_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 10);
            this.mpeAll.Show();
        }
        protected void lnkFiles8_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblDesignSubmitID.Text), 14);
            this.mpeAll.Show();
        }
        protected void lnkFiles9_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblPrinterAssignID.Text), 5);
            this.mpeAll.Show();
        }
        protected void lnkFiles10_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblFabricatorAssignID.Text), 6);
            this.mpeAll.Show();
        }
        protected void lnkFiles11_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblFinalAssemblyID.Text), 7);
            this.mpeAll.Show();
        }
        protected void lnkFiles12_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblHeadID.Text), 11);
            this.mpeAll.Show();
        }
        protected void lnkFiles13_Click(object sender, EventArgs e)
        {
            GetUploadedJobRequestFiles(Convert.ToInt64(lblPrinterAssignID.Text), 5);
            this.mpeAll.Show();
        }


        /// <summary>
        /// Show the detail of submited design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblFabricatorAssignID.Text = FieldTripID.ToString();
            show2();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
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

        

        /// <summary>
        /// call the submit method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnapprove_Click(object sender, EventArgs e)
        {
            DataInsert(1);
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// List Of Job done by fabricator and approved..
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            DataTable dt5 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = 0;
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.GetJoblisttoacceptforfinalassembly(dsp);
            return dt5;
        }

        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = Convert.ToInt32(lblFabricatorAssignID.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.ListOfJobForFinalAssembly(dsp);
            return dt5;
        }

        /// <summary>
        /// fill all the control .
        /// </summary>
        protected void show2()
        {
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = Convert.ToInt32(lblFabricatorAssignID.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectsingle = new Core.FinalAssembaly.FinalAssembly();
            DataTable dt = objselectsingle.ListOfJobForFinalAssembly(dsp);
            if (dt.Rows.Count > 0)
            {
                //All Ids
                lblsubmittedby.Text = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usernm", Convert.ToBoolean(0)).Replace(@"+", string.Empty);
                lblHeadID.Text = Convert.ToString(dt.Rows[0]["HeadID"]);
                lblChildID.Text = Convert.ToString(dt.Rows[0]["ChildID"]);
                lblDesignSubmitID.Text = Convert.ToString(dt.Rows[0]["DesignSubmitID"]);
                lblPrinterAssignID.Text = Convert.ToString(dt.Rows[0]["PrinterAssignID"]);
                lblPrinterID.Text = Convert.ToString(dt.Rows[0]["PrinterID"]);
                lblFabricatorAssignID.Text = Convert.ToString(dt.Rows[0]["FabricatorAssignID"]);
                lblFabricatorID.Text = Convert.ToString(dt.Rows[0]["FabricatorID"]);

                LoadProductType();
                //Job Request Details
                //   lblBranch.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["NameType"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                //lblSubmittedBy.Text = Convert.ToString(dt.Rows[0]["submittedby"]);
                //lblApprovedBy.Text = Convert.ToString(dt.Rows[0]["approvedby"]);
                //lblJobStatus.Text = Convert.ToString(dt.Rows[0]["JobStatus"]);

                //Dealer Details
                lblName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                lblContact.Text = Convert.ToString(dt.Rows[0]["distcontact"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["ContactPerson"]);
               // lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
               // lblGST.Text = Convert.ToString(dt.Rows[0]["GstNo"]);

                if (Convert.ToString(dt.Rows[0]["RetailerID"]) != "0")
                {
                  //  retailerdetails.Style.Add("display", "block");
                    //Retailer Details
                    lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);
                    lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                    lblSubAddress.Text = Convert.ToString(dt.Rows[0]["SubAddress"]);
                    lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                  //  lblSubEmail.Text = Convert.ToString(dt.Rows[0]["subemail"]);
                }

                //Job Details
                //  lblDimension.Text = Convert.ToString(dt.Rows[0]["Dimension"]);
                lblqty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                jobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                subjobtype.Text = Convert.ToString(dt.Rows[0]["subjobtype"]);
                subsubjobtype.Text = Convert.ToString(dt.Rows[0]["subsubjobtype"]);
                subsubjobtypeID.Text = Convert.ToString(dt.Rows[0]["SubSubJobTypeId"]);
                designtyp.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                designtypeID.Text = Convert.ToString(dt.Rows[0]["designtypeid"]);
                //lblProductType.Text = Convert.ToString(dt.Rows[0]["producttype"]);
                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblUnitID.Text = Convert.ToString(dt.Rows[0]["UnitID"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrinterLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblFabricatorLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);
                product.Text = Convert.ToString(dt.Rows[0]["product"]);
                //  lblInstallAddress.Text = Convert.ToString(dt.Rows[0]["InstallAddress"]);

                //  lblIsPartyApproval.Text = Convert.ToString(dt.Rows[0]["IsPartyApproval"]);
                if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                {
                    //partyapprovedetails.Style.Add("display", "block");
                    //lblPartyApprovalTo.Text = Convert.ToString(dt.Rows[0]["ApprovalTo"]);
                    //lblApprovalEmailID.Text = Convert.ToString(dt.Rows[0]["approvalemail"]);
                }

                //lblIsPlaceSize.Text = Convert.ToString(dt.Rows[0]["IsPlaceSize"]);
                //JobImgLink.Text = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                //JobImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                //lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["ApproveRemark"]);
                //lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                   // lbVisitingCard.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                  //  lbRefersheet.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["JobImage"]) != "")
                {
                    //JobImgLink.Visible = true;
                    //lbJobImage.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["cdrfile"]) != "")
                {
                  //  lbCDRFile.Visible = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["JobCount"]) > 1)
                {
                    //lbOtherJobImage.Visible = true;
                    //lbOtherJobImage.Visible = true;
                }
                //if (Convert.ToString(dt.Rows[0]["isplacesize"]) == "No")
                //{
                //  rdsizetype.SelectedValue = "0";
                   
                //}
                //else
                //{
                //    rdsizetype.SelectedValue = "1";
                   
                //}
                if (Convert.ToString(dt.Rows[0]["DesignSubmitID"]) != "0")
                {
                  //  designdetails.Style.Add("display", "block");
                    //Design Details
                    lblDesignerName.Text = Convert.ToString(dt.Rows[0]["DesignerName"]);
                    //lblNewProductType.Text = Convert.ToString(dt.Rows[0]["NewProductType"]);
                    //lbltotalamount.Text = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    //lblDesignRemark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);
                    //Designlink.Text = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    //Designlink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    //PrintLink.Text = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);
                    //PrintLink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);

                    //lblDesignApproveRemark.Text = Convert.ToString(dt.Rows[0]["DesignApproveRemark"]);

                    if (Convert.ToString(dt.Rows[0]["NewProductType"]) == "Live Product")
                    {
                        //liveproductdetails.Style.Add("display", "block");
                        //lblApprovalGivenBy.Text = Convert.ToString(dt.Rows[0]["ApprovalGivenBy"]);
                        //lblManagementRemark.Text = Convert.ToString(dt.Rows[0]["MgmRemark"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                    {
                        //partyapprovaldetails.Style.Add("display", "block");

                        //lblPartyEmail.Text = Convert.ToString(dt.Rows[0]["PartyEmail"]);
                        //lblIsMailSent.Text = Convert.ToString(dt.Rows[0]["IsMailSent"]);
                        //lblIsApprovedByParty.Text = Convert.ToString(dt.Rows[0]["IsApproveParty"]);
                        //lblIsFinalPartyApproved.Text = Convert.ToString(dt.Rows[0]["IsFinalApproved"]);
                        //lblPartyRemark.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["PrinterAssignID"]) != "0")
                    {
                        //jobsenddetails.Style.Add("display", "block");
                        //printerdetails.Style.Add("display", "block");
                        ////Assign Printer Details
                        //lblJobSendTo.Text = Convert.ToString(dt.Rows[0]["JobSendTypeName"]);
                        //lblSendToName.Text = Convert.ToString(dt.Rows[0]["SendToName"]);
                        //lblSendToOtherName.Text = Convert.ToString(dt.Rows[0]["JobSendToOther"]);
                        //lblSendToAddress.Text = Convert.ToString(dt.Rows[0]["JobSendToAddress"]);


                        if (dt.Rows[0]["JobSendTypeName"].ToString() == "Party")
                        {
                            //ddlsendto.Style.Add("display", "block");
                            //address.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Branch")
                        {
                            //ddlsendto.Style.Add("display", "block");
                            //address.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Fabricator")
                        {
                           // ddlsendto.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Other")
                        {
                          //  othername.Style.Add("display", "block");
                        }

                        //lblprinter.Text = Convert.ToString(dt.Rows[0]["printername"]);
                        //lblprimobile.Text = Convert.ToString(dt.Rows[0]["printermobile"]);
                        //lblpricontect.Text = Convert.ToString(dt.Rows[0]["printercontact"]);
                        //lblpriemail.Text = Convert.ToString(dt.Rows[0]["printeremail"]);

                        //PrinterLink.Text = Convert.ToString(dt.Rows[0]["PrinterImageLink"]);
                        //PrinterLink.NavigateUrl = Convert.ToString(dt.Rows[0]["PrinterImageLink"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["TransportMode"]) != "")
                    {
                        //transportdetails.Style.Add("display", "block");
                        ////Printer Job Send DC Details
                        //lblTransportMode.Text = Convert.ToString(dt.Rows[0]["TransportMode"]);
                        //lblTranspoterName.Text = Convert.ToString(dt.Rows[0]["TranspoterName"]);
                        //lblInvoiceNumber.Text = Convert.ToString(dt.Rows[0]["InvoiceNumber"]);
                        //lblInvoiceDate.Text = Convert.ToString(dt.Rows[0]["InvoiceDate"]);
                        //lblLRNumber.Text = Convert.ToString(dt.Rows[0]["LRNumber"]);
                        //lblLRDate.Text = Convert.ToString(dt.Rows[0]["LRDate"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["FabricatorAssignID"]) != "0")
                    {
                        //fabricatordetails.Style.Add("display", "block");
                        ////Fabricator Assign Details
                        //lblfabname.Text = Convert.ToString(dt.Rows[0]["fabname"]);
                        //lblfabmobile.Text = Convert.ToString(dt.Rows[0]["fabmobile"]);
                        //lblfabcontact.Text = Convert.ToString(dt.Rows[0]["contact"]);
                        //lblfabemail.Text = Convert.ToString(dt.Rows[0]["fabemail"]);

                        //Fablink.Text = Convert.ToString(dt.Rows[0]["FabImageLink"]);
                        //Fablink.NavigateUrl = Convert.ToString(dt.Rows[0]["FabImageLink"]);
                    }

                   

                    if (Convert.ToString(dt.Rows[0]["DesignImage"]) != "")
                    {
                    //    Designlink.Visible = true;
                        lbDesignImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["DesignPrintImage"]) != "")
                    {
                        //PrintLink.Visible = true;
                        //lbPrintImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["LiveProductImg"]) != "")
                    {
                      //  lbLiveProductImg.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PartyImage"]) != "")
                    {
                      //  lbPartyImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PrinterImage"]) != "")
                    {
                        //PrinterLink.Visible = true;
                        //lbPrinterImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["FabImage"]) != "")
                    {
                        //Fablink.Visible = true;
                        //lbFabricatorImage.Visible = true;
                    }
                }
            }

            loadchild();
            loadsizechild();
            loadprintermaterial();
            loadfabricatorrmaterial();

            ASPxPageControl1.ActiveTabIndex = 0;
        }

        /// <summary>
        /// Load the grid of child during edit.
        /// </summary>
        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dst.slno = Convert.ToInt32(lblFabricatorAssignID.Text);
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt6 = objselectall.DetailOfItemListForFinalAssembly(dst);
            Session[ViewState["_PageID"].ToString() + "Scheme"] = dt6;
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }

        private void loadsizechild()
        {
            //DataTable dt6 = new DataTable();
            //Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            //dchildlist.slno = Convert.ToInt32(lblDesignSubmitID.Text);
            //Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            //dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);
            //gvSizeChild.DataSource = dt6;
            //gvSizeChild.DataBind();
        }

        /// <summary>
        /// Load the material of the printer
        /// </summary>
        private void loadprintermaterial()
        {
            //DataTable dt6 = new DataTable();
            //Data.Printer.PrinterModel.PrinterInsert dchildlist = new Data.Printer.PrinterModel.PrinterInsert();
            //dchildlist.slno = Convert.ToInt32(lblPrinterID.Text);
            //dchildlist.BranchID = Convert.ToInt32(lblPrintLocationID.Text);
            //Core.Printer.Printer objselectall = new Core.Printer.Printer();
            //dt6 = objselectall.GetDetailOfMaterialListForPrinter(dchildlist);
            //gvPrinter.DataSource = dt6;
            //gvPrinter.DataBind();
        }

        /// <summary>
        /// Load the material of the fabricator.
        /// </summary>
        private void loadfabricatorrmaterial()
        {
            //DataTable dt7 = new DataTable();
            //Data.Fabricator.FabricatorModel.FabricatorInsert dchildlist = new Data.Fabricator.FabricatorModel.FabricatorInsert();
            //dchildlist.slno = Convert.ToInt32(lblFabricatorID.Text);
            //dchildlist.BranchID = Convert.ToInt32(lblFabLocationID.Text);
            //Core.Fabricator.Fabricator objselectall = new Core.Fabricator.Fabricator();
            //dt7 = objselectall.GetDetailOfMaterialListForFabricator(dchildlist);
            //gvfab.DataSource = dt7;
            //gvfab.DataBind();
        }

        /// <summary>
        /// validate the data.
        /// </summary>
        /// <returns></returns>
        private string[] Validation()
        {
            string[] result = new string[2];
            strFileTypeVC = Path.GetExtension(fuPhoto.FileName).ToLower();
            result[0] = "false";
            result[1] = string.Empty;
            if ((strFileTypeVC == ".jpg" || strFileTypeVC == ".jpeg" || strFileTypeVC == ".png"))
            {
                result[0] = "false";
                result[1] = string.Empty;
            }
            //else if (txtLink.Text != string.Empty)
            //{
            //    Uri uriResult;
            //    bool resultlink = Uri.TryCreate(txtLink.Text, UriKind.Absolute, out uriResult)
            //        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            //    if (resultlink == true)
            //    {
            //        result[0] = "false";
            //        result[1] = string.Empty;
            //    }
            //    else
            //    {
            //        result[0] = "true";

            //        result[1] = "Link is not in valid format";
            //    }

            //}
            else
            {
                result[0] = "true";
                // result[1] = "File and Image Link both fields are empty or image format is wrong";
                result[1] = "File upload is empty or image format is wrong";
            }
            return result;
        }

        /// <summary>
        /// Submit the final assembaly
        /// </summary>
        protected void DataInsert(int SubmitStatus)
        {
            int result = 0;

            string FileNameVC = string.Empty;
            if (Validation()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validation()[1] + "','warning',3);", true);
            }
            else
            {
                if (lblFabricatorAssignID.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops !Please select any one record!','error',3);", true);
                }
                else
                {
                    string strFileType = "";
                    foreach (var file in fuPhoto.PostedFiles)
                    {
                        if (file.FileName != "")
                        {
                            bool rtnVallpost = false;
                            string uploadedFileName = "";

                            SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME7);
                            if (rtnVallpost)
                            {

                                strFileType = Path.GetExtension(file.FileName).ToLower();
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
                    }


                    FileNameVC = FileNameVC.TrimEnd(',');

                    Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                    var submitimg = FileNameVC;
                 
                    dst.submitdesign = submitimg;
                  //  string link = txtLink.Text;
                   // dst.link = link;
                  //  dst.Remark = txtremark.Text;
                    dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.pagename = HttpContext.Current.Request.Url.ToString();
                    dst.Remark = "";
                    dst.link = "";
                    dst.designsubmitid = Convert.ToInt64(lblDesignSubmitID.Text);
                    dst.assignfabid = Convert.ToInt64(lblFabricatorAssignID.Text);
                    dst.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                    dst.SubmitStatus  = Convert.ToBoolean(SubmitStatus);
                    Core.FinalAssembaly.FinalAssembly objinsert = new Core.FinalAssembaly.FinalAssembly();
                    result = objinsert.SubmitFinalAssembly(dst);
                    if (result != -1 && result != 0)
                    {
                        if (gvSchemeChild.Rows.Count > 0)
                        {
                            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dstt = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                            foreach (GridViewRow row in gvSchemeChild.Rows)
                            {
                                int Itemid = Convert.ToInt32(((HiddenField)row.FindControl("Itemid")).Value);
                                int childslno = Convert.ToInt32(((HiddenField)row.FindControl("hfchildslno")).Value);
                              
                                int Qty = Convert.ToInt32(row.Cells[2].Text);
                              
                                dstt.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                                dstt.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                                dstt.editusercat = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(0));
                                dstt.refid = result;
                                dstt.pagename = HttpContext.Current.Request.Url.ToString();
                                dstt.itemid = Itemid;
                                dstt.slno = Convert.ToInt32(lblFabricatorAssignID.Text);
                                dstt.childslno = childslno;
                                dstt.qty = Qty;
                               dstt.assignfabid = Convert.ToInt64(lblFabricatorAssignID.Text);
                                result2 = objinsert.ItemFinalAssemblyInsertMethod(dstt);
                                if (result2 == -1)
                                {
                                   // Data.DesignSubmit.DesignSubmit.DesignSubmitProperty del = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
                                   // del.assignslno = Convert.ToInt16(assignslno);
                                  //  errorresulr = objinsert.PermanentDeleteDesignSubmitCore(del);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
                                   
                                    break;
                                }
                            }
                            if (lblFabricatorAssignID.Text == "0")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details  Added successfully !','success',3);", true);
                               
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details Updated successfully !','success',3);", true);
                               
                            }
                        }
                        else
                        {
                            if (lblFabricatorAssignID.Text == "0")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details  Added successfully !','success',3);", true);
                               
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Details Updated successfully !','success',3);", true);
                                
                            }
                        }
                        //  ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Final Assembly Done successfully!','success',3);", true);
                        clean();
                    }
                    else if (result == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Allready Exists!','success',3);", true);
                        clean();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                        clean();
                    }
                    ASPxGridView1.DataBind();
                    ASPxGridView2.DataBind();
                }
            }
            clean();
        }

        /// <summary>
        /// Clean the control.
        /// </summary>
        protected void clean()
        {
            lblHeadID.Text = "0";
            lblChildID.Text = "0";
            lblDesignSubmitID.Text = "0";
            lblPrinterID.Text = "0";
            lblFabricatorID.Text = "0";
            lblPrinterAssignID.Text = "0";
            lblFabricatorAssignID.Text = "0";
            lblFinalAssemblyID.Text = "0";

            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";

            LblRequestNo.Text = "";
           // lblBranch.Text = "";
            lblDate.Text = "";
            lblNameType.Text = "";
            lblGivenBy.Text = "";
            //lblSubmittedBy.Text = "";
            //lblApprovedBy.Text = "";
            //lblJobStatus.Text = "";

            lblName.Text = "";
            lblAddress.Text = "";
            lblContactPerson.Text = "";
            // lblContactNo.Text = "";
            lblContact.Text = "";
             lblEmail.Text = "";
            lblCinNo.Text = "";
            // lblGST.Text = "";
            product.Text = "";
           // retailerdetails.Style.Add("display", "none");
            lblFirmName.Text = "";
            lblSubName.Text = "";
            lblSubAddress.Text = "";
            lblSubContact.Text = "";
            //lblSubEmail.Text = "";
            lblUnit.Text = "";
            lblUnitID.Text = "";
            //lblDimension.Text = "";
            lblqty.Text = "";
            //lblJobtype.Text = "";
            //lblSubJobtype.Text = "";
            //lblSubSubJobtype.Text = "";
            jobtype.Text = "";
            subjobtype.Text = "";
            subsubjobtype.Text = "";
            subsubjobtypeID.Text = "";
            //lblDesignType.Text = "";
            //lblProductType.Text = "";
            lblBoardType.Text = "";
           // lblPrinterLocation.Text = "";
            lblFabricatorLocation.Text = "";
            lblPriority.Text = "";
            //lblInstallAddress.Text = "";
            //lblIsPartyApproval.Text = "";

            //partyapprovedetails.Style.Add("display", "none");
            //lblPartyApprovalTo.Text = "";
            //lblApprovalEmailID.Text = "";

            //lblIsPlaceSize.Text = "";
            //JobImgLink.Text = "";
            //JobImgLink.NavigateUrl = "";
            lblJobRemark.Text = "";
            //lblApproveRemark.Text = "";
            //lblAssignRemark.Text = "";

            lblDesignerName.Text = "";
            //lblNewProductType.Text = "";
            //lbltotalamount.Text = "";
            //lblDesignRemark.Text = "";
            //Designlink.Text = "";
            //Designlink.NavigateUrl = "";
            //PrintLink.Text = "";
            //PrintLink.NavigateUrl = "";

            //lblJobSendTo.Text = "";
            //lblSendToName.Text = "";
            //lblSendToOtherName.Text = "";
            //lblSendToAddress.Text = "";

            //ddlsendto.Style.Add("display", "none");
            //address.Style.Add("display", "none");
            //othername.Style.Add("display", "none");

            //lblDesignApproveRemark.Text = "";

            //liveproductdetails.Style.Add("display", "none");
            //lblApprovalGivenBy.Text = "";
            //lblManagementRemark.Text = "";

            //partyapprovaldetails.Style.Add("display", "none");

            //lblPartyEmail.Text = "";
            //lblIsMailSent.Text = "";
            //lblIsApprovedByParty.Text = "";
            //lblIsFinalPartyApproved.Text = "";
            //lblPartyRemark.Text = "";

            //lblprinter.Text = "";
            //lblprimobile.Text = "";
            //lblpricontect.Text = "";
            //lblpriemail.Text = "";

            //PrinterLink.Text = "";
            //PrinterLink.NavigateUrl = "";

            //lblTransportMode.Text = "";
            //lblTranspoterName.Text = "";
            //lblInvoiceNumber.Text = "";
            //lblInvoiceDate.Text = "";
            //lblLRNumber.Text = "";
            //lblLRDate.Text = "";

            //lblfabname.Text = "";
            //lblfabmobile.Text = "";
            //lblfabcontact.Text = "";
            //lblfabemail.Text = "";

            //Fablink.Text = "";
            //Fablink.NavigateUrl = "";

            //lbVisitingCard.Visible = false;

            //lbRefersheet.Visible = false;

            //JobImgLink.Visible = false;
            //lbJobImage.Visible = false;

            //lbCDRFile.Visible = false;

            //lbRefersheet.Visible = false;

            //Designlink.Visible = false;
            lbDesignImage.Visible = true;

            //PrintLink.Visible = false;
            //lbPrintImage.Visible = false;

            //lbLiveProductImg.Visible = false;

            //lbPartyImage.Visible = false;

            //Fablink.Visible = false;
            //lbFabricatorImage.Visible = false;

            //txtremark.Text = string.Empty;
            //txtLink.Text = string.Empty;
           

            //jobsenddetails.Style.Add("display", "none");
            //printerdetails.Style.Add("display", "none");
            //transportdetails.Style.Add("display", "none");
            //fabricatordetails.Style.Add("display", "none");
            

            loadchild();
            loadsizechild();
            loadprintermaterial();
            loadfabricatorrmaterial();
            ASPxGridView1.DataBind();
            ASPxGridView2.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        #endregion Methods

        protected void GetUploadedJobRequestFiles(long slno, int flag)
        {
            string a = string.Empty;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new JobRequestModel.JobRequestProperties();

            hfPopupImageFlag.Value = flag.ToString();

            param.slno = slno;
            param.flag = flag;

            Core.JobRequest.JobRequest objData = new Core.JobRequest.JobRequest();
            DataTable dtResult = objData.JobRequestChildFilesDACore(param);

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

        protected void rptAllImages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hfPImgName = (HiddenField)e.Item.FindControl("hfPImgName");

            var path = "";

            if (e.CommandName == "Down")
            {
                if (hfPopupImageFlag.Value == "1")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadID.Text), 1);
                }
                else if (hfPopupImageFlag.Value == "2")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadID.Text), 2);
                }
                else if (hfPopupImageFlag.Value == "3")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblChildID.Text), 3);
                }
                else if (hfPopupImageFlag.Value == "13")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblHeadID.Text), 13);
                }
                else if (hfPopupImageFlag.Value == "4")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 4);
                }
                else if (hfPopupImageFlag.Value == "12")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME12, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 12);
                }
                else if (hfPopupImageFlag.Value == "10")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME10, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 10);
                }
                else if (hfPopupImageFlag.Value == "14")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME14, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblDesignSubmitID.Text), 14);
                }
                else if (hfPopupImageFlag.Value == "5")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblPrinterAssignID.Text), 5);
                }
                else if (hfPopupImageFlag.Value == "6")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME6, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblFabricatorAssignID.Text), 6);
                }
                else if (hfPopupImageFlag.Value == "7")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME7, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblFinalAssemblyID.Text), 7);
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

            if (hfPopupImageFlag.Value == "1")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME1, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "2")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME2, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "3")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME3, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "13")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME13, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "4")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME4, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "12")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME12, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME12, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "10")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME10, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME10, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "14")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME14, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME14, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "5")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME5, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "6")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME6, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME6, hfPImgName.Value);
            }
            else if (hfPopupImageFlag.Value == "7")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME7, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME7, hfPImgName.Value);
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
            if (hfPImgName.Value.Contains(".pptx"))
            {
                imgDocs.ImageUrl = "~/images/ppt-icon.png";
                imgDocs.ToolTip = "Download pptx";
                hyLink.NavigateUrl = FileIdPath;
            }
            if (hfPImgName.Value.Contains(".ppt"))
            {
                imgDocs.ImageUrl = "~/images/ppt-icon.png";
                imgDocs.ToolTip = "Download ppt";
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
            MimeType.Pdf
            };
            #region Validation
            if (String.IsNullOrWhiteSpace(file.FileName))
                return string.Empty;
            if (!GoldMimeType.IsMimeTypeAllowed(oldFileExtension, mineTypeAllowed, out contentType))
            {
                result = string.Format("{0} : Oops!! This type of file upload not allowed.", oldFileName);
                return result;
            }
            if (!GoldMimeType.IsFileSizeAllowed(file.ContentLength, out size, 2000 * 2000 * 10))
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

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable2();
        }

        protected void CmdAccept_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            Accept();
        }
        private void Accept()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job to accept','error',3);", true);
            }

            else
            {

               
                int result = 0;
               

                Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                dst.slno = Convert.ToInt32(lbslno.Text);
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.FinalAssembaly.FinalAssembly objinsert = new Core.FinalAssembaly.FinalAssembly();
                result = objinsert.JobsAcceptForFinalAssembly(dst);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Accepted Successfully !','success',3);", true);
                }
                if (result != 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }

            }
            ASPxGridView1.DataBind();
            ASPxGridView2.DataBind();

        }

        protected void CmdSaveAsDraft_Click(object sender, EventArgs e)
        {
            DataInsert(0);
        }

        protected void rdsizetype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void LoadProductType()
        {
            Core.ProductType.ProductType db = new Core.ProductType.ProductType();
            DataTable jobdt = db.GetProductTypeAll();
            cmbProductType.Items.Clear();
            cmbProductType.Value = null;
            cmbProductType.DataSource = jobdt;
            cmbProductType.TextField = "name";
            cmbProductType.ValueField = "slno";
            cmbProductType.SelectedIndex = 0;
            cmbProductType.DataBind();
        }

        public void LoadItemDivision()
        {
            Core.DesignSubmit.DesignSubmit db = new Core.DesignSubmit.DesignSubmit();
            DataTable itdt = db.GetItemDivisonAll();
            cmbItemDivision.Items.Clear();
            cmbItemDivision.Value = null;
            cmbItemDivision.DataSource = itdt;
            cmbItemDivision.TextField = "divisionnm";
            cmbItemDivision.ValueField = "slno";
            cmbItemDivision.DataBind();
            cmbItemDivision.SelectedIndex = -1;
        }
        protected void cmbItemDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemDivision.SelectedItem != null)
            {
                LoadItemType(Convert.ToInt32(cmbItemDivision.SelectedItem.Value));
            }
        }
        public void LoadItemType(int divisionid)
        {
            Core.DesignSubmit.DesignSubmit db = new Core.DesignSubmit.DesignSubmit();
            DataTable itdt = db.GetItemTypeAll(divisionid);
            CmbItem.Items.Clear();
            CmbItem.Value = null;
            CmbItem.DataSource = itdt;
            CmbItem.TextField = "name";
            CmbItem.ValueField = "slno";
            CmbItem.SelectedIndex = 0;
            CmbItem.DataBind();
            CmbItem.SelectedIndex = -1;
        }
        protected void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbItem.SelectedItem != null)
            {
                if (CmbItem.SelectedItem.Value.ToString() != "0")
                {
                    GetItemPrice(Convert.ToInt32(CmbItem.SelectedItem.Value));
                }
            }
        }
        protected void GetItemPrice(int ItemID)
        {
            decimal itemPrice = 0;

            //itemPrice = da.GetItemPriceDA(ItemID);
            //txtmrp.Text = itemPrice.ToString();
            //txtDiscount.Text = (Convert.ToDecimal(txtmrp.Text) / 2).ToString();
        }
        protected void btnadditem_Click(object sender, EventArgs e)
        {
            if (Validationchild()[0] == "true")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + Validationchild()[1] + "','warning',3);", true);
            }
            else
            {
                calulation();
                Boolean matchdata = false;

                if (txtqty.Text != string.Empty && CmbItem.Value != string.Empty)
                {
                    DataRow row = dtss.NewRow();
                    //Commented on 07022022 Need to Single Item add in Multiple Times.
                    //if (Session[ViewState["_PageID"].ToString() + "Scheme"] != null)
                    //{
                    //    DataTable dt2 = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
                    //    for (int i = 0; i < dt2.Rows.Count; i++)
                    //    {
                    //        if (Convert.ToString(dt2.Rows[i]["Item"]) == CmbItem.Text)
                    //        {
                    //            matchdata = true;
                    //            lblMsg2.Text = "Opps! duplicate value";
                    //            lblMsg2.Style.Add("color", "red");
                    //            break;
                    //        }
                    //    }
                    //}

                    if (matchdata == false)
                    {
                        row["childslno"] = "0";
                        row["Itemid"] = CmbItem.Value;
                        row["Item"] = CmbItem.Text;
                        row["Qty"] = Convert.ToDecimal(txtqty.Text);
                        
                        dtss.Rows.Add(row);
                        dtss.AcceptChanges();
                        Session[ViewState["_PageID"].ToString() + "Scheme"] = dtss;
                        bindgvSchemeChild();
                        //  clean2();
                    }
                }
                else
                {
                    lblMsg2.Text = "Please enter every mandatory details";
                    lblMsg2.Style.Add("color", "red");
                }
                
               // clean();
            }
        }
        /// <summary>
        /// validation for the child.
        /// </summary>
        /// <returns></returns>
        private string[] Validationchild()
        {
            string[] results = new string[2];
            if (CmbItem.Value == string.Empty  || Convert.ToDecimal(txtqty.Text) <= 0)
            {
                results[0] = "true";
                results[1] = "some error occured";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please Check mandatory fields','warning',3);", true);
            }
            else
            {
                results[0] = "false";
                results[1] = string.Empty;
            }
            return results;
        }
        protected void bindgvSchemeChild()
        {
            gvSchemeChild.DataSource = (DataTable)Session[ViewState["_PageID"].ToString() + "Scheme"];
            gvSchemeChild.DataBind();
        }
        protected void gvSchemeChild_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (gvSchemeChild.Rows.Count != 0)
                //{
                //    gvSchemeChild.Rows[0].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
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

        protected void gvSchemeChild_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rows = 0;
            int index = Convert.ToInt32(e.RowIndex);
            
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty param1 = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            //child srno
            param1.slno = Convert.ToInt32(((HiddenField)gvSchemeChild.Rows[index].FindControl("hfchildslno")).Value);
            
            Core.FinalAssembaly.FinalAssembly objdelete = new Core.FinalAssembaly.FinalAssembly();
            rows = objdelete.DeleteItemForFinalAssembly(param1);
            if (rows == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Item Deleted successfully !','success',3);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Oops ! some error occured adding items !','warning',3);", true);
            }

            DataTable dtss = Session[ViewState["_PageID"].ToString() + "Scheme"] as DataTable;

            dtss.Rows[index].Delete();
            dtss.AcceptChanges();
            Session[ViewState["_PageID"].ToString() + "Scheme"] = dtss;

            bindgvSchemeChild();
            //for (int i = 0; i < gvSchemeChild.Rows.Count; i++)
            //{
            //    Cnt += Convert.ToDouble(gvSchemeChild.Rows[i].Cells[5].Text);
            //}
            //txttotalamt.Text = Cnt.ToString();
        }
        protected void cal_changed(object sender, EventArgs e)
        {
          //  calulation();
        }
        private void calulation()
        {
            if (!string.IsNullOrEmpty(txtqty.Text))
            {
              //  txtDiscount.Text = (Convert.ToDecimal(txtmrp.Text) / 2).ToString();
              //  txtamt.Text = ((Convert.ToDecimal(txtmrp.Text) - Convert.ToDecimal(txtDiscount.Text)) * (Convert.ToInt32(txtqty.Text))).ToString();
            }
        }

    }
}