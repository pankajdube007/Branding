using DevExpress.Web;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.FinalAssembaly
{
    public partial class FabricatorCreditDebitNoteJobsApproval1 : System.Web.UI.Page
    {
        private string TableNme = "Tbl_DesignSubmit";
        private const string FILE_DIRECTORY_NAME = "jobrequest/brandimage";
        private const string FILE_DIRECTORY_NAME1 = "jobrequest/submitimage";
        private const string FILE_DIRECTORY_NAME2 = "jobrequest/submitimagebyprinter";
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                   
                    ASPxGridView1.DataBind();
                }
            }
        }

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
            Receive();
        }

        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }



        #region Methods

        /// <summary>
        /// List Of Job Done By Printer For Approval
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable2()
        {
            DataTable dt5 = new DataTable();
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dsp = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dsp.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignToFabricator.AssignToFabricator objselectall = new Core.AssignToFabricator.AssignToFabricator();
            dt5 = objselectall.GetFabricatorCreditDebitJobsToApprove1(dsp);
            return dt5;
        }

        /// <summary>
        /// fill all the control.
        /// </summary>
        protected void show2()
        {
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dsp = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dsp.slno = Convert.ToInt32(lbslno.Text);
            Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
            DataTable dt = objselectsingle.GetSingleFabricatorCreditDebitJobForApprove1(dsp);
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
                lblfabricator.Text = Convert.ToString(dt.Rows[0]["fabricatorname"]);
                lblfabricatoremail.Text = Convert.ToString(dt.Rows[0]["fabricatoremail"]);
                lblfabricatorcontact.Text = Convert.ToString(dt.Rows[0]["fabricatorcontact"]);
                lblfabricatormobile.Text = Convert.ToString(dt.Rows[0]["fabricatormobile"]);
                ImgLink.Text = Convert.ToString(dt.Rows[0]["ImageLink"]);
                ImgLink.NavigateUrl = Convert.ToString(dt.Rows[0]["ImageLink"]);
                deslink.Text = Convert.ToString(dt.Rows[0]["designlink"]);
                deslink.NavigateUrl = Convert.ToString(dt.Rows[0]["designlink"]);
                prilink.Text = Convert.ToString(dt.Rows[0]["prilink"]);
                prilink.NavigateUrl = Convert.ToString(dt.Rows[0]["prilink"]);
                // lblJobSendTo.Text = Convert.ToString(dt.Rows[0]["JobSendTypeName"]);
                // lblSendToName.Text = Convert.ToString(dt.Rows[0]["SendToName"]);
                // lblSendToOtherName.Text = Convert.ToString(dt.Rows[0]["JobSendToOther"]);
                // lblSendToAddress.Text = Convert.ToString(dt.Rows[0]["JobSendToAddress"]);
                lblLRNumber.Text = Convert.ToString(dt.Rows[0]["LRNumber"]);
                lblLRDate.Text = Convert.ToString(dt.Rows[0]["LRDate"]);
                lblTranspoterName.Text = Convert.ToString(dt.Rows[0]["TranspoterName"]);

                lblCinNo.Text = Convert.ToString(dt.Rows[0]["cinnum"]);
                lblFirmName.Text = Convert.ToString(dt.Rows[0]["subname"]);

                lblUnit.Text = Convert.ToString(dt.Rows[0]["Unit"]);
                lblBoardType.Text = Convert.ToString(dt.Rows[0]["BoardType"]);
                lblPrintLocation.Text = Convert.ToString(dt.Rows[0]["PrintLocation"]);
                lblFabricatorLocation.Text = Convert.ToString(dt.Rows[0]["FabricatorLocation"]);
                lblPriority.Text = Convert.ToString(dt.Rows[0]["Priority"]);

                lblPrintLocationID.Text = Convert.ToString(dt.Rows[0]["PrintLocationID"]);
                lblFabLocationID.Text = Convert.ToString(dt.Rows[0]["FabricatorLocationID"]);

                lblTransportMode.Text = Convert.ToString(dt.Rows[0]["TransportMode"]);
                lblInvoiceNumber.Text = Convert.ToString(dt.Rows[0]["InvoiceNumber"]);
                lblInvoiceDate.Text = Convert.ToString(dt.Rows[0]["InvoiceDate"]);

                //if (dt.Rows[0]["JobSendTypeName"].ToString() == "Party")
                //{
                //    ddlsendto.Style.Add("display", "block");
                //    address.Style.Add("display", "block");
                //}
                //else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Branch")
                //{
                //    ddlsendto.Style.Add("display", "block");
                //    address.Style.Add("display", "block");
                //}
                //else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Fabricator")
                //{
                //    ddlsendto.Style.Add("display", "block");
                //}
                //else if (dt.Rows[0]["JobSendTypeName"].ToString() == "Other")
                //{
                //    othername.Style.Add("display", "block");
                //}

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

        /// <summary>
        /// Approve the record submited by the printer.
        /// </summary>
        protected void Receive()
        {
            string msg = string.Empty;
            int result = 0;
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for send..','error',3);", true);
            }
            else
            {

                        Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dst = new Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend();

                        dst.slno = Convert.ToInt16(lbslno.Text);
                       
                        dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                       
                        Core.FabricatorDesignSubmit.FabricatorDesignSubmit objSend = new Core.FabricatorDesignSubmit.FabricatorDesignSubmit();
                        result = objSend.UpdateFabricatorCreditDebitJobApprove1(dst);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job approved successfully !','success',3);", true);
                            clean();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                            clean();
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
            lblJobRemark.Text = string.Empty;

            // lblSendToAddress.Text = "";
            //  lblJobSendTo.Text = "";
            //  lblSendToName.Text = "";
            // lblSendToOtherName.Text = "";
            lblLRNumber.Text = "";
            lblLRDate.Text = "";
            lblTranspoterName.Text = "";
           
            lblTransportMode.Text = "";
            lblInvoiceNumber.Text = "";
            lblInvoiceDate.Text = "";


            lblPrintLocationID.Text = "0";
            lblFabLocationID.Text = "0";

            // ddlsendto.Style.Add("display", "none");
            //othername.Style.Add("display", "none");
            // address.Style.Add("display", "none");

            ASPxGridView1.DataBind();
            loadchild();
            loadsizechild();
            loadprintermaterial();
            ASPxPageControl1.ActiveTabIndex = 1;
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

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Reject();
        }

        protected void Reject()
        {
            string msg = string.Empty;
            int result = 0;
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for send..','error',3);", true);
            }
            else
            {

                        Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dst = new Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend();

                        dst.slno = Convert.ToInt16(lbslno.Text);
                        
                        dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                        dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                        Core.FabricatorDesignSubmit.FabricatorDesignSubmit objSend = new Core.FabricatorDesignSubmit.FabricatorDesignSubmit();
                        result = objSend.JobRejectMethod(dst);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job received successfully !','success',3);", true);
                            clean();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                            clean();
                        }
                   
            }


            // clean();
        }
    }
}