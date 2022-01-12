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
    public partial class JobCloser : System.Web.UI.Page
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
        private const string FILE_DIRECTORY_NAME8 = "jobrequest/jobcloser";
        private readonly IGoldMedia _goldMedia;
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
                    txtInstallationDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    txtInstallationDate.MaxDate = DateTime.Now;
                    lblFabricatorAssignID.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    ASPxGridView1.DataBind();
                }
            }
        }
        public JobCloser()
        {
            _goldMedia = new GoldMedia();
            
        }
        #endregion PageEvent

        #region Events
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
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
            else if (e.Tab.Index == 3)
            {
                ASPxGridView3.DataBind();
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
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            clean2();
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblFinalAssemblyID.Text = FieldTripID.ToString();
            lblgd1.Text = "1";
            show2();
        }

        protected void CmdEdit2_Command(object sender, CommandEventArgs e)
        {
            clean2();
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblFinalAssemblyID.Text = FieldTripID.ToString();
            lblgd2.Text = "1";
            show3();
        }

        protected void CmdEdit3_Command(object sender, CommandEventArgs e)
        {
            clean2();
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lblFinalAssemblyID.Text = FieldTripID.ToString();
            lblgd3.Text = "1";
            show4();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }

        protected void ASPxGridView3_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView3.DataSource = GetTable4();
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            clean();
        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            DataInsert();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        #endregion Events

        #region Methods

        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.ListOfJobForJobCloser(dsp);
            return dt5;
        }

        private DataTable GetTable3()
        {
            DataTable dt5 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.ListOfApprovedJobForJobCloser(dsp);
            return dt5;
        }

        private DataTable GetTable4()
        {
            DataTable dt5 = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dsp = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dsp.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();
            dt5 = objselectall.ListOfPrintedJobForJobCloser(dsp);
            return dt5;
        }

        protected void show2()
        {
            
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dtsingle.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectsingle = new Core.FinalAssembaly.FinalAssembly();
            DataTable dt = objselectsingle.ListOfJobForJobCloser(dtsingle);
            if (dt.Rows.Count > 0)
            {
                //All Ids
                lblHeadID.Text = Convert.ToString(dt.Rows[0]["HeadID"]);
                lblChildID.Text = Convert.ToString(dt.Rows[0]["ChildID"]);
                lblDesignSubmitID.Text = Convert.ToString(dt.Rows[0]["DesignSubmitID"]);
                lblPrinterAssignID.Text = Convert.ToString(dt.Rows[0]["PrinterAssignID"]);
                lblPrinterID.Text = Convert.ToString(dt.Rows[0]["PrinterID"]);
                lblFabricatorAssignID.Text = Convert.ToString(dt.Rows[0]["FabricatorAssignID"]);
                lblFabricatorID.Text = Convert.ToString(dt.Rows[0]["FabricatorID"]);
                lblFinalAssemblyID.Text = Convert.ToString(dt.Rows[0]["FinalAssemblyID"]);

                //Job Request Details
                lblBranch.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["NameType"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                lblSubmittedBy.Text = Convert.ToString(dt.Rows[0]["submittedby"]);
                lblApprovedBy.Text = Convert.ToString(dt.Rows[0]["approvedby"]);
                lblJobStatus.Text = Convert.ToString(dt.Rows[0]["JobStatus"]);

                //Dealer Details
                lblName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["ContactPerson"]);
                lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblGST.Text = Convert.ToString(dt.Rows[0]["GstNo"]);

                if (Convert.ToString(dt.Rows[0]["RetailerID"]) != "0")
                {
                    retailerdetails.Style.Add("display", "block");
                    //Retailer Details
                    lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);
                    lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                    lblSubAddress.Text = Convert.ToString(dt.Rows[0]["SubAddress"]);
                    lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                    lblSubEmail.Text = Convert.ToString(dt.Rows[0]["subemail"]);
                }

                //Job Details
                lblDimension.Text = Convert.ToString(dt.Rows[0]["Dimension"]);
                lblQty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblJobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                lblSubJobtype.Text = Convert.ToString(dt.Rows[0]["subjobtype"]);
                lblSubSubJobtype.Text = Convert.ToString(dt.Rows[0]["subsubjobtype"]);
                lblDesignType.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                lblProductType.Text = Convert.ToString(dt.Rows[0]["producttype"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrinterLocation.Text = Convert.ToString(dt.Rows[0]["PrinterLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);
                lblInstallAddress.Text = Convert.ToString(dt.Rows[0]["InstallAddress"]);

                lblIsPartyApproval.Text = Convert.ToString(dt.Rows[0]["IsPartyApproval"]);
                if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                {
                    partyapprovedetails.Style.Add("display", "block");
                    lblPartyApprovalTo.Text = Convert.ToString(dt.Rows[0]["ApprovalTo"]);
                    lblApprovalEmailID.Text = Convert.ToString(dt.Rows[0]["approvalemail"]);
                }

                lblIsPlaceSize.Text = Convert.ToString(dt.Rows[0]["IsPlaceSize"]);
                JobImgLink.Text = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                JobImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["ApproveRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                    lbVisitingCard.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                    lbRefersheet.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["JobImage"]) != "")
                {
                    JobImgLink.Visible = true;
                    lbJobImage.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["cdrfile"]) != "")
                {
                    lbCDRFile.Visible = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["JobCount"]) > 1)
                {
                    lbOtherJobImage.Visible = true;
                    lbOtherJobImage.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["DesignSubmitID"]) != "0")
                {
                    designdetails.Style.Add("display", "block");
                    //Design Details
                    lblDesignerName.Text = Convert.ToString(dt.Rows[0]["DesignerName"]);
                    lblNewProductType.Text = Convert.ToString(dt.Rows[0]["NewProductType"]);
                    lbltotalamount.Text = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    lblDesignRemark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);
                    Designlink.Text = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    Designlink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    PrintLink.Text = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);
                    PrintLink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);

                    lblDesignApproveRemark.Text = Convert.ToString(dt.Rows[0]["DesignApproveRemark"]);

                    if (Convert.ToString(dt.Rows[0]["NewProductType"]) == "Live Product")
                    {
                        liveproductdetails.Style.Add("display", "block");
                        lblApprovalGivenBy.Text = Convert.ToString(dt.Rows[0]["ApprovalGivenBy"]);
                        lblManagementRemark.Text = Convert.ToString(dt.Rows[0]["MgmRemark"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                    {
                        partyapprovaldetails.Style.Add("display", "block");

                        lblPartyEmail.Text = Convert.ToString(dt.Rows[0]["PartyEmail"]);
                        lblIsMailSent.Text = Convert.ToString(dt.Rows[0]["IsMailSent"]);
                        lblIsApprovedByParty.Text = Convert.ToString(dt.Rows[0]["IsApproveParty"]);
                        lblIsFinalPartyApproved.Text = Convert.ToString(dt.Rows[0]["IsFinalApproved"]);
                        lblPartyRemark.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["PrinterAssignID"]) != "0")
                    {
                        jobsenddetails.Style.Add("display", "block");
                        printerdetails.Style.Add("display", "block");
                        //Assign Printer Details
                        lblJobSendTo.Text = Convert.ToString(dt.Rows[0]["JobSendTypeName"]);
                        lblSendToName.Text = Convert.ToString(dt.Rows[0]["SendToName"]);
                        lblSendToOtherName.Text = Convert.ToString(dt.Rows[0]["JobSendToOther"]);
                        lblSendToAddress.Text = Convert.ToString(dt.Rows[0]["JobSendToAddress"]);


                        if (dt.Rows[0]["JobSendTypeName"].ToString() == "Party")
                        {
                            ddlsendto.Style.Add("display", "block");
                            address.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Branch")
                        {
                            ddlsendto.Style.Add("display", "block");
                            address.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Fabricator")
                        {
                            ddlsendto.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Other")
                        {
                            othername.Style.Add("display", "block");
                        }

                        lblprinter.Text = Convert.ToString(dt.Rows[0]["printername"]);
                        lblprimobile.Text = Convert.ToString(dt.Rows[0]["printermobile"]);
                        lblpricontect.Text = Convert.ToString(dt.Rows[0]["printercontact"]);
                        lblpriemail.Text = Convert.ToString(dt.Rows[0]["printeremail"]);

                        PrinterLink.Text = Convert.ToString(dt.Rows[0]["PrinterImageLink"]);
                        PrinterLink.NavigateUrl = Convert.ToString(dt.Rows[0]["PrinterImageLink"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["TransportMode"]) != "")
                    {
                        transportdetails.Style.Add("display", "block");
                        //Printer Job Send DC Details
                        lblTransportMode.Text = Convert.ToString(dt.Rows[0]["TransportMode"]);
                        lblTranspoterName.Text = Convert.ToString(dt.Rows[0]["TranspoterName"]);
                        lblInvoiceNumber.Text = Convert.ToString(dt.Rows[0]["InvoiceNumber"]);
                        lblInvoiceDate.Text = Convert.ToString(dt.Rows[0]["InvoiceDate"]);
                        lblLRNumber.Text = Convert.ToString(dt.Rows[0]["LRNumber"]);
                        lblLRDate.Text = Convert.ToString(dt.Rows[0]["LRDate"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["FabricatorAssignID"]) != "0")
                    {
                        fabricatordetails.Style.Add("display", "block");
                        //Fabricator Assign Details
                        lblfabname.Text = Convert.ToString(dt.Rows[0]["fabname"]);
                        lblfabmobile.Text = Convert.ToString(dt.Rows[0]["fabmobile"]);
                        lblfabcontact.Text = Convert.ToString(dt.Rows[0]["contact"]);
                        lblfabemail.Text = Convert.ToString(dt.Rows[0]["fabemail"]);

                        Fablink.Text = Convert.ToString(dt.Rows[0]["FabImageLink"]);
                        Fablink.NavigateUrl = Convert.ToString(dt.Rows[0]["FabImageLink"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["FinalAssemblyID"]) != "0")
                    {
                        finalassemblydetails.Style.Add("display", "block");
                        //Final Assembly details
                        hlFinalAssembly.Text = Convert.ToString(dt.Rows[0]["FinalAssemblyImageLink"]);
                        hlFinalAssembly.NavigateUrl = Convert.ToString(dt.Rows[0]["FinalAssemblyImageLink"]);
                        lblFinalRemark.Text = Convert.ToString(dt.Rows[0]["FinalRemark"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["DesignImage"]) != "")
                    {
                        Designlink.Visible = true;
                        lbDesignImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["DesignPrintImage"]) != "")
                    {
                        PrintLink.Visible = true;
                        lbPrintImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["LiveProductImg"]) != "")
                    {
                        lbLiveProductImg.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PartyImage"]) != "")
                    {
                        lbPartyImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PrinterImage"]) != "")
                    {
                        PrinterLink.Visible = true;
                        lbPrinterImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["FabImage"]) != "")
                    {
                        Fablink.Visible = true;
                        lbFabricatorImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["FinalAssemblyImage"]) != "")
                    {
                        hlFinalAssembly.Visible = true;
                        lbFinalAssembly.Visible = true;
                    }
                }
            }

            loadchild();
            loadsizechild();
            loadprintermaterial();
            loadfabricatorrmaterial();

            ASPxPageControl1.ActiveTabIndex = 0;
        }

        protected void show3()
        {
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dtsingle.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectsingle = new Core.FinalAssembaly.FinalAssembly();
            DataTable dt = objselectsingle.ListOfApprovedJobForJobCloser(dtsingle);
            if (dt.Rows.Count > 0)
            {
                //All Ids
                lblHeadID.Text = Convert.ToString(dt.Rows[0]["HeadID"]);
                lblChildID.Text = Convert.ToString(dt.Rows[0]["ChildID"]);
                lblDesignSubmitID.Text = Convert.ToString(dt.Rows[0]["DesignSubmitID"]);
              
                //Job Request Details
                lblBranch.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["NameType"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                lblSubmittedBy.Text = Convert.ToString(dt.Rows[0]["submittedby"]);
                lblApprovedBy.Text = Convert.ToString(dt.Rows[0]["approvedby"]);
                lblJobStatus.Text = Convert.ToString(dt.Rows[0]["JobStatus"]);

                //Dealer Details
                lblName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["ContactPerson"]);
                lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblGST.Text = Convert.ToString(dt.Rows[0]["GstNo"]);

                if (Convert.ToString(dt.Rows[0]["RetailerID"]) != "0")
                {
                    retailerdetails.Style.Add("display", "block");
                    //Retailer Details
                    lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);
                    lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                    lblSubAddress.Text = Convert.ToString(dt.Rows[0]["SubAddress"]);
                    lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                    lblSubEmail.Text = Convert.ToString(dt.Rows[0]["subemail"]);
                }

                //Job Details
                lblDimension.Text = Convert.ToString(dt.Rows[0]["Dimension"]);
                lblQty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblJobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                lblSubJobtype.Text = Convert.ToString(dt.Rows[0]["subjobtype"]);
                lblSubSubJobtype.Text = Convert.ToString(dt.Rows[0]["subsubjobtype"]);
                lblDesignType.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                lblProductType.Text = Convert.ToString(dt.Rows[0]["producttype"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrinterLocation.Text = Convert.ToString(dt.Rows[0]["PrinterLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);
                lblInstallAddress.Text = Convert.ToString(dt.Rows[0]["InstallAddress"]);

                lblIsPartyApproval.Text = Convert.ToString(dt.Rows[0]["IsPartyApproval"]);
                if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                {
                    partyapprovedetails.Style.Add("display", "block");
                    lblPartyApprovalTo.Text = Convert.ToString(dt.Rows[0]["ApprovalTo"]);
                    lblApprovalEmailID.Text = Convert.ToString(dt.Rows[0]["approvalemail"]);
                }

                lblIsPlaceSize.Text = Convert.ToString(dt.Rows[0]["IsPlaceSize"]);
                JobImgLink.Text = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                JobImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["ApproveRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                    lbVisitingCard.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                    lbRefersheet.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["JobImage"]) != "")
                {
                    JobImgLink.Visible = true;
                    lbJobImage.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["cdrfile"]) != "")
                {
                    lbCDRFile.Visible = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["JobCount"]) > 1)
                {
                    lbOtherJobImage.Visible = true;
                    lbOtherJobImage.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["DesignSubmitID"]) != "0")
                {
                    designdetails.Style.Add("display", "block");
                    //Design Details
                    lblDesignerName.Text = Convert.ToString(dt.Rows[0]["DesignerName"]);
                    lblNewProductType.Text = Convert.ToString(dt.Rows[0]["NewProductType"]);
                    lbltotalamount.Text = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    lblDesignRemark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);
                    Designlink.Text = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    Designlink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    PrintLink.Text = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);
                    PrintLink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);

                    lblDesignApproveRemark.Text = Convert.ToString(dt.Rows[0]["DesignApproveRemark"]);

                    if (Convert.ToString(dt.Rows[0]["NewProductType"]) == "Live Product")
                    {
                        liveproductdetails.Style.Add("display", "block");
                        lblApprovalGivenBy.Text = Convert.ToString(dt.Rows[0]["ApprovalGivenBy"]);
                        lblManagementRemark.Text = Convert.ToString(dt.Rows[0]["MgmRemark"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                    {
                        partyapprovaldetails.Style.Add("display", "block");

                        lblPartyEmail.Text = Convert.ToString(dt.Rows[0]["PartyEmail"]);
                        lblIsMailSent.Text = Convert.ToString(dt.Rows[0]["IsMailSent"]);
                        lblIsApprovedByParty.Text = Convert.ToString(dt.Rows[0]["IsApproveParty"]);
                        lblIsFinalPartyApproved.Text = Convert.ToString(dt.Rows[0]["IsFinalApproved"]);
                        lblPartyRemark.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["DesignImage"]) != "")
                    {
                        Designlink.Visible = true;
                        lbDesignImage.Visible = true;
                    }
                    
                    if (Convert.ToString(dt.Rows[0]["LiveProductImg"]) != "")
                    {
                        lbLiveProductImg.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PartyImage"]) != "")
                    {
                        lbPartyImage.Visible = true;
                    }
                    

                }
            }

            loadchild();
            loadsizechild();

            ASPxPageControl1.ActiveTabIndex = 0;
        }

        protected void show4()
        {
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dtsingle.slno = Convert.ToInt32(lblFinalAssemblyID.Text);
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectsingle = new Core.FinalAssembaly.FinalAssembly();
            DataTable dt = objselectsingle.ListOfPrintedJobForJobCloser(dtsingle);
            if (dt.Rows.Count > 0)
            {
                //All Ids
                lblHeadID.Text = Convert.ToString(dt.Rows[0]["HeadID"]);
                lblChildID.Text = Convert.ToString(dt.Rows[0]["ChildID"]);
                lblDesignSubmitID.Text = Convert.ToString(dt.Rows[0]["DesignSubmitID"]);
                lblPrinterAssignID.Text = Convert.ToString(dt.Rows[0]["PrinterAssignID"]);
                lblPrinterID.Text = Convert.ToString(dt.Rows[0]["PrinterID"]);
               
                //Job Request Details
                lblBranch.Text = Convert.ToString(dt.Rows[0]["BranchName"]);
                LblRequestNo.Text = Convert.ToString(dt.Rows[0]["reqno"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["requestdate"]);
                lblNameType.Text = Convert.ToString(dt.Rows[0]["NameType"]);
                lblGivenBy.Text = Convert.ToString(dt.Rows[0]["GivenByName"]);
                lblSubmittedBy.Text = Convert.ToString(dt.Rows[0]["submittedby"]);
                lblApprovedBy.Text = Convert.ToString(dt.Rows[0]["approvedby"]);
                lblJobStatus.Text = Convert.ToString(dt.Rows[0]["JobStatus"]);

                //Dealer Details
                lblName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                lblContactPerson.Text = Convert.ToString(dt.Rows[0]["ContactPerson"]);
                lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblEmail.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblGST.Text = Convert.ToString(dt.Rows[0]["GstNo"]);

                if (Convert.ToString(dt.Rows[0]["RetailerID"]) != "0")
                {
                    retailerdetails.Style.Add("display", "block");
                    //Retailer Details
                    lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);
                    lblSubName.Text = Convert.ToString(dt.Rows[0]["subpname"]);
                    lblSubAddress.Text = Convert.ToString(dt.Rows[0]["SubAddress"]);
                    lblSubContact.Text = Convert.ToString(dt.Rows[0]["subcontact"]);
                    lblSubEmail.Text = Convert.ToString(dt.Rows[0]["subemail"]);
                }

                //Job Details
                lblDimension.Text = Convert.ToString(dt.Rows[0]["Dimension"]);
                lblQty.Text = Convert.ToString(dt.Rows[0]["qty"]);
                lblJobtype.Text = Convert.ToString(dt.Rows[0]["jobtype"]);
                lblSubJobtype.Text = Convert.ToString(dt.Rows[0]["subjobtype"]);
                lblSubSubJobtype.Text = Convert.ToString(dt.Rows[0]["subsubjobtype"]);
                lblDesignType.Text = Convert.ToString(dt.Rows[0]["designtype"]);
                lblProductType.Text = Convert.ToString(dt.Rows[0]["producttype"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrinterLocation.Text = Convert.ToString(dt.Rows[0]["PrinterLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);
                lblInstallAddress.Text = Convert.ToString(dt.Rows[0]["InstallAddress"]);

                lblIsPartyApproval.Text = Convert.ToString(dt.Rows[0]["IsPartyApproval"]);
                if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                {
                    partyapprovedetails.Style.Add("display", "block");
                    lblPartyApprovalTo.Text = Convert.ToString(dt.Rows[0]["ApprovalTo"]);
                    lblApprovalEmailID.Text = Convert.ToString(dt.Rows[0]["approvalemail"]);
                }

                lblIsPlaceSize.Text = Convert.ToString(dt.Rows[0]["IsPlaceSize"]);
                JobImgLink.Text = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                JobImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["JobImageLink"]);
                lblJobRemark.Text = Convert.ToString(dt.Rows[0]["JobRemark"]);
                lblApproveRemark.Text = Convert.ToString(dt.Rows[0]["ApproveRemark"]);
                lblAssignRemark.Text = Convert.ToString(dt.Rows[0]["AssignRemark"]);

                if (Convert.ToString(dt.Rows[0]["VisitingCardImg"]) != "")
                {
                    lbVisitingCard.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["ReferSheet"]) != "")
                {
                    lbRefersheet.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["JobImage"]) != "")
                {
                    JobImgLink.Visible = true;
                    lbJobImage.Visible = true;
                }
                if (Convert.ToString(dt.Rows[0]["cdrfile"]) != "")
                {
                    lbCDRFile.Visible = true;
                }
                if (Convert.ToInt32(dt.Rows[0]["JobCount"]) > 1)
                {
                    lbOtherJobImage.Visible = true;
                    lbOtherJobImage.Visible = true;
                }

                if (Convert.ToString(dt.Rows[0]["DesignSubmitID"]) != "0")
                {
                    designdetails.Style.Add("display", "block");
                    //Design Details
                    lblDesignerName.Text = Convert.ToString(dt.Rows[0]["DesignerName"]);
                    lblNewProductType.Text = Convert.ToString(dt.Rows[0]["NewProductType"]);
                    lbltotalamount.Text = Convert.ToString(dt.Rows[0]["TotalAmount"]);
                    lblDesignRemark.Text = Convert.ToString(dt.Rows[0]["DesignRemark"]);
                    Designlink.Text = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    Designlink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignImageLink"]);
                    PrintLink.Text = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);
                    PrintLink.NavigateUrl = Convert.ToString(dt.Rows[0]["DesignPrintLink"]);

                    lblDesignApproveRemark.Text = Convert.ToString(dt.Rows[0]["DesignApproveRemark"]);

                    if (Convert.ToString(dt.Rows[0]["NewProductType"]) == "Live Product")
                    {
                        liveproductdetails.Style.Add("display", "block");
                        lblApprovalGivenBy.Text = Convert.ToString(dt.Rows[0]["ApprovalGivenBy"]);
                        lblManagementRemark.Text = Convert.ToString(dt.Rows[0]["MgmRemark"]);
                    }

                    if (Convert.ToString(dt.Rows[0]["IsPartyApproval"]) == "Yes")
                    {
                        partyapprovaldetails.Style.Add("display", "block");

                        lblPartyEmail.Text = Convert.ToString(dt.Rows[0]["PartyEmail"]);
                        lblIsMailSent.Text = Convert.ToString(dt.Rows[0]["IsMailSent"]);
                        lblIsApprovedByParty.Text = Convert.ToString(dt.Rows[0]["IsApproveParty"]);
                        lblIsFinalPartyApproved.Text = Convert.ToString(dt.Rows[0]["IsFinalApproved"]);
                        lblPartyRemark.Text = Convert.ToString(dt.Rows[0]["PartyRemark"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["PrinterAssignID"]) != "0")
                    {
                        jobsenddetails.Style.Add("display", "block");
                        printerdetails.Style.Add("display", "block");
                        //Assign Printer Details
                        lblJobSendTo.Text = Convert.ToString(dt.Rows[0]["JobSendTypeName"]);
                        lblSendToName.Text = Convert.ToString(dt.Rows[0]["SendToName"]);
                        lblSendToOtherName.Text = Convert.ToString(dt.Rows[0]["JobSendToOther"]);
                        lblSendToAddress.Text = Convert.ToString(dt.Rows[0]["JobSendToAddress"]);


                        if (dt.Rows[0]["JobSendTypeName"].ToString() == "Party")
                        {
                            ddlsendto.Style.Add("display", "block");
                            address.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Branch")
                        {
                            ddlsendto.Style.Add("display", "block");
                            address.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Fabricator")
                        {
                            ddlsendto.Style.Add("display", "block");
                        }
                        else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Other")
                        {
                            othername.Style.Add("display", "block");
                        }

                        lblprinter.Text = Convert.ToString(dt.Rows[0]["printername"]);
                        lblprimobile.Text = Convert.ToString(dt.Rows[0]["printermobile"]);
                        lblpricontect.Text = Convert.ToString(dt.Rows[0]["printercontact"]);
                        lblpriemail.Text = Convert.ToString(dt.Rows[0]["printeremail"]);

                        PrinterLink.Text = Convert.ToString(dt.Rows[0]["PrinterImageLink"]);
                        PrinterLink.NavigateUrl = Convert.ToString(dt.Rows[0]["PrinterImageLink"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["TransportMode"]) != "")
                    {
                        transportdetails.Style.Add("display", "block");
                        //Printer Job Send DC Details
                        lblTransportMode.Text = Convert.ToString(dt.Rows[0]["TransportMode"]);
                        lblTranspoterName.Text = Convert.ToString(dt.Rows[0]["TranspoterName"]);
                        lblInvoiceNumber.Text = Convert.ToString(dt.Rows[0]["InvoiceNumber"]);
                        lblInvoiceDate.Text = Convert.ToString(dt.Rows[0]["InvoiceDate"]);
                        lblLRNumber.Text = Convert.ToString(dt.Rows[0]["LRNumber"]);
                        lblLRDate.Text = Convert.ToString(dt.Rows[0]["LRDate"]);
                    }


                    if (Convert.ToString(dt.Rows[0]["DesignImage"]) != "")
                    {
                        Designlink.Visible = true;
                        lbDesignImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["DesignPrintImage"]) != "")
                    {
                        PrintLink.Visible = true;
                        lbPrintImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["LiveProductImg"]) != "")
                    {
                        lbLiveProductImg.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PartyImage"]) != "")
                    {
                        lbPartyImage.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["PrinterImage"]) != "")
                    {
                        PrinterLink.Visible = true;
                        lbPrinterImage.Visible = true;
                    }
                }
            }

            loadchild();
            loadsizechild();
            loadprintermaterial();

            ASPxPageControl1.ActiveTabIndex = 0;
        }

        private void loadchild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lblDesignSubmitID.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfItemListForDesignSubmit(dchildlist);
            gvSchemeChild.DataSource = dt6;
            gvSchemeChild.DataBind();
        }

        private void loadsizechild()
        {
            DataTable dt6 = new DataTable();
            Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dchildlist = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();
            dchildlist.slno = Convert.ToInt32(lblDesignSubmitID.Text);
            Core.DesignSubmit.DesignSubmit objselectall = new Core.DesignSubmit.DesignSubmit();
            dt6 = objselectall.GetDetailOfSizeListForDesignSubmit(dchildlist);
            gvSizeChild.DataSource = dt6;
            gvSizeChild.DataBind();
        }

        private void loadprintermaterial()
        {
            DataTable dt6 = new DataTable();
            Data.Printer.PrinterModel.PrinterInsert dchildlist = new Data.Printer.PrinterModel.PrinterInsert();
            dchildlist.slno = Convert.ToInt32(lblPrinterID.Text);
            dchildlist.BranchID = Convert.ToInt32(lblPrintLocationID.Text);
            Core.Printer.Printer objselectall = new Core.Printer.Printer();
            dt6 = objselectall.GetDetailOfMaterialListForPrinter(dchildlist);
            gvPrinter.DataSource = dt6;
            gvPrinter.DataBind();
        }

        private void loadfabricatorrmaterial()
        {
            DataTable dt7 = new DataTable();
            Data.Fabricator.FabricatorModel.FabricatorInsert dchildlist = new Data.Fabricator.FabricatorModel.FabricatorInsert();
            dchildlist.slno = Convert.ToInt32(lblFabricatorID.Text);
            dchildlist.BranchID = Convert.ToInt32(lblFabLocationID.Text);
            Core.Fabricator.Fabricator objselectall = new Core.Fabricator.Fabricator();
            dt7 = objselectall.GetDetailOfMaterialListForFabricator(dchildlist);
            gvfab.DataSource = dt7;
            gvfab.DataBind();
        }

        /// <summary>
        /// Close the job.
        /// </summary>
        protected void DataInsert()
        {
            string msg = string.Empty;
            int result = 0;
            string FileNameVC = string.Empty;
            if (lblFinalAssemblyID.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! Please select any one record !','error',3);", true);
            }
           else if (txtInstallationDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select installation date','warning',3);", true);
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

                        SavePostedFile(out rtnVallpost, file, out uploadedFileName, FILE_DIRECTORY_NAME8);
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

                var submitimg = FileNameVC;
                if (lblgd1.Text == "1")
                {
                    Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                    
                    dst.slno = Convert.ToInt64(lblFinalAssemblyID.Text);
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.Remark = txtremark.Text;
                    dst.InstallationDate = txtInstallationDate.Date.ToString("yyyy-MM-dd");
                    dst.JobCloserImg = submitimg;
                    Core.FinalAssembaly.FinalAssembly objinsert = new Core.FinalAssembaly.FinalAssembly();
                    result = objinsert.JobCloser(dst);
                }
                else if (lblgd2.Text == "1")
                {
                    Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                    dst.slno = Convert.ToInt64(lblFinalAssemblyID.Text);
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.Remark = txtremark.Text;
                    dst.InstallationDate = txtInstallationDate.Date.ToString("yyyy-MM-dd");
                    dst.JobCloserImg = submitimg;
                    Core.FinalAssembaly.FinalAssembly objinsert = new Core.FinalAssembaly.FinalAssembly();
                    result = objinsert.ApprovedJobCloser(dst);
                }
                else if (lblgd3.Text == "1")
                {
                    Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
                    dst.slno = Convert.ToInt64(lblFinalAssemblyID.Text);
                    dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                    dst.Remark = txtremark.Text;
                    dst.InstallationDate = txtInstallationDate.Date.ToString("yyyy-MM-dd");
                    dst.JobCloserImg = submitimg;
                    Core.FinalAssembaly.FinalAssembly objinsert = new Core.FinalAssembaly.FinalAssembly();
                    result = objinsert.PrintedJobCloser(dst);
                }



                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job closed successfully !','success',3);", true);
                    clean();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                    clean();
                }
            }
            clean();
        }

       
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

            lblgd1.Text = "0";
            lblgd2.Text = "0";
            lblgd3.Text = "0";

            LblRequestNo.Text = "";
            lblBranch.Text = "";
            lblDate.Text = "";
            lblNameType.Text = "";
            lblGivenBy.Text = "";
            lblSubmittedBy.Text = "";
            lblApprovedBy.Text = "";
            lblJobStatus.Text = "";

            lblName.Text = "";
            lblAddress.Text = "";
            lblContactPerson.Text = "";
            lblContactNo.Text = "";
            lblEmail.Text = "";
            lblCinNo.Text = "";
            lblGST.Text = "";

            retailerdetails.Style.Add("display", "none");
            lblFirmName.Text = "";
            lblSubName.Text = "";
            lblSubAddress.Text = "";
            lblSubContact.Text = "";
            lblSubEmail.Text = "";

            lblDimension.Text = "";
            lblQty.Text = "";
            lblJobtype.Text = "";
            lblSubJobtype.Text = "";
            lblSubSubJobtype.Text = "";
            lblDesignType.Text = "";
            lblProductType.Text = "";
            lblBoardType.Text = "";
            lblPrinterLocation.Text = "";
            lblFabricatorLocation.Text = "";
            lblPriority.Text = "";
            lblInstallAddress.Text = "";
            lblIsPartyApproval.Text = "";

            partyapprovedetails.Style.Add("display", "none");
            lblPartyApprovalTo.Text = "";
            lblApprovalEmailID.Text = "";

            lblIsPlaceSize.Text = "";
            JobImgLink.Text = "";
            JobImgLink.NavigateUrl = "";
            lblJobRemark.Text = "";
            lblApproveRemark.Text = "";
            lblAssignRemark.Text = "";

            lblDesignerName.Text = "";
            lblNewProductType.Text = "";
            lbltotalamount.Text = "";
            lblDesignRemark.Text = "";
            Designlink.Text = "";
            Designlink.NavigateUrl = "";
            PrintLink.Text = "";
            PrintLink.NavigateUrl = "";

            lblJobSendTo.Text = "";
            lblSendToName.Text = "";
            lblSendToOtherName.Text = "";
            lblSendToAddress.Text = "";

            ddlsendto.Style.Add("display", "none");
            address.Style.Add("display", "none");
            othername.Style.Add("display", "none");

            lblDesignApproveRemark.Text = "";

            liveproductdetails.Style.Add("display", "none");
            lblApprovalGivenBy.Text = "";
            lblManagementRemark.Text = "";

            partyapprovaldetails.Style.Add("display", "none");

            lblPartyEmail.Text = "";
            lblIsMailSent.Text = "";
            lblIsApprovedByParty.Text = "";
            lblIsFinalPartyApproved.Text = "";
            lblPartyRemark.Text = "";

            lblprinter.Text = "";
            lblprimobile.Text = "";
            lblpricontect.Text = "";
            lblpriemail.Text = "";
            txtInstallationDate.Text = "";
            PrinterLink.Text = "";
            PrinterLink.NavigateUrl = "";

            lblTransportMode.Text = "";
            lblTranspoterName.Text = "";
            lblInvoiceNumber.Text = "";
            lblInvoiceDate.Text = "";
            lblLRNumber.Text = "";
            lblLRDate.Text = "";

            lblfabname.Text = "";
            lblfabmobile.Text = "";
            lblfabcontact.Text = "";
            lblfabemail.Text = "";

            Fablink.Text = "";
            Fablink.NavigateUrl = "";

            lbVisitingCard.Visible = false;

            lbRefersheet.Visible = false;

            JobImgLink.Visible = false;
            lbJobImage.Visible = false;

            lbCDRFile.Visible = false;

            lbRefersheet.Visible = false;

            Designlink.Visible = false;
            lbDesignImage.Visible = true;

            PrintLink.Visible = false;
            lbPrintImage.Visible = false;

            lbLiveProductImg.Visible = false;

            lbPartyImage.Visible = false;

            Fablink.Visible = false;
            lbFabricatorImage.Visible = false;

            hlFinalAssembly.Visible = false;
            lbFinalAssembly.Visible = false;
            lblFinalRemark.Text = "";

            txtremark.Text = string.Empty;

            jobsenddetails.Style.Add("display", "none");
            printerdetails.Style.Add("display", "none");
            transportdetails.Style.Add("display", "none");
            fabricatordetails.Style.Add("display", "none");
            finalassemblydetails.Style.Add("display", "none");
        }

        protected void clean2()
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

            lblgd1.Text = "0";
            lblgd2.Text = "0";
            lblgd3.Text = "0";

            LblRequestNo.Text = "";
            lblBranch.Text = "";
            lblDate.Text = "";
            lblNameType.Text = "";
            lblGivenBy.Text = "";
            lblSubmittedBy.Text = "";
            lblApprovedBy.Text = "";
            lblJobStatus.Text = "";

            lblName.Text = "";
            lblAddress.Text = "";
            lblContactPerson.Text = "";
            lblContactNo.Text = "";
            lblEmail.Text = "";
            lblCinNo.Text = "";
            lblGST.Text = "";

            retailerdetails.Style.Add("display", "none");
            lblFirmName.Text = "";
            lblSubName.Text = "";
            lblSubAddress.Text = "";
            lblSubContact.Text = "";
            lblSubEmail.Text = "";

            lblDimension.Text = "";
            lblQty.Text = "";
            lblJobtype.Text = "";
            lblSubJobtype.Text = "";
            lblSubSubJobtype.Text = "";
            lblDesignType.Text = "";
            lblProductType.Text = "";
            lblBoardType.Text = "";
            lblPrinterLocation.Text = "";
            lblFabricatorLocation.Text = "";
            lblPriority.Text = "";
            lblInstallAddress.Text = "";
            lblIsPartyApproval.Text = "";

            partyapprovedetails.Style.Add("display", "none");
            lblPartyApprovalTo.Text = "";
            lblApprovalEmailID.Text = "";

            lblIsPlaceSize.Text = "";
            JobImgLink.Text = "";
            JobImgLink.NavigateUrl = "";
            lblJobRemark.Text = "";
            lblApproveRemark.Text = "";
            lblAssignRemark.Text = "";

            lblDesignerName.Text = "";
            lblNewProductType.Text = "";
            lbltotalamount.Text = "";
            lblDesignRemark.Text = "";
            Designlink.Text = "";
            Designlink.NavigateUrl = "";
            PrintLink.Text = "";
            PrintLink.NavigateUrl = "";

            lblJobSendTo.Text = "";
            lblSendToName.Text = "";
            lblSendToOtherName.Text = "";
            lblSendToAddress.Text = "";

            ddlsendto.Style.Add("display", "none");
            address.Style.Add("display", "none");
            othername.Style.Add("display", "none");

            lblDesignApproveRemark.Text = "";

            liveproductdetails.Style.Add("display", "none");
            lblApprovalGivenBy.Text = "";
            lblManagementRemark.Text = "";

            partyapprovaldetails.Style.Add("display", "none");

            lblPartyEmail.Text = "";
            lblIsMailSent.Text = "";
            lblIsApprovedByParty.Text = "";
            lblIsFinalPartyApproved.Text = "";
            lblPartyRemark.Text = "";

            lblprinter.Text = "";
            lblprimobile.Text = "";
            lblpricontect.Text = "";
            lblpriemail.Text = "";

            PrinterLink.Text = "";
            PrinterLink.NavigateUrl = "";

            lblTransportMode.Text = "";
            lblTranspoterName.Text = "";
            lblInvoiceNumber.Text = "";
            lblInvoiceDate.Text = "";
            lblLRNumber.Text = "";
            lblLRDate.Text = "";

            lblfabname.Text = "";
            lblfabmobile.Text = "";
            lblfabcontact.Text = "";
            lblfabemail.Text = "";

            Fablink.Text = "";
            Fablink.NavigateUrl = "";

            lbVisitingCard.Visible = false;

            lbRefersheet.Visible = false;

            JobImgLink.Visible = false;
            lbJobImage.Visible = false;

            lbCDRFile.Visible = false;

            lbRefersheet.Visible = false;

            Designlink.Visible = false;
            lbDesignImage.Visible = true;

            PrintLink.Visible = false;
            lbPrintImage.Visible = false;

            lbLiveProductImg.Visible = false;

            lbPartyImage.Visible = false;

            Fablink.Visible = false;
            lbFabricatorImage.Visible = false;

            hlFinalAssembly.Visible = false;
            lbFinalAssembly.Visible = false;
            lblFinalRemark.Text = "";

            txtremark.Text = string.Empty;

            jobsenddetails.Style.Add("display", "none");
            printerdetails.Style.Add("display", "none");
            transportdetails.Style.Add("display", "none");
            fabricatordetails.Style.Add("display", "none");
            finalassemblydetails.Style.Add("display", "none");
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
                else if (hfPopupImageFlag.Value == "8")
                {
                    path = string.Format("{0}/{1}", FILE_DIRECTORY_NAME8, hfPImgName.Value);
                    Download(path);
                    GetUploadedJobRequestFiles(Convert.ToInt32(lblFinalAssemblyID.Text), 8);
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
            else if (hfPopupImageFlag.Value == "8")
            {
                PictureIDPath = string.Format("../../Download/ImageHandler.aspx?PictureID={0}/{1}", FILE_DIRECTORY_NAME8, hfPImgName.Value);
                FileIdPath = string.Format("../../Download/ImageHandler.aspx?FileId={0}/{1}", FILE_DIRECTORY_NAME8, hfPImgName.Value);
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

    }
}