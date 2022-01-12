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
    public partial class reopenassigntoprinter : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46)
                {
                    ViewState["_PageID"] = (new Random()).Next().ToString();
                    ViewState["_SizePageID"] = (new Random()).Next().ToString();
                    lbslno.Text = "0";
                    ASPxGridView2.DataBind();
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
        }
        public reopenassigntoprinter()
        {
            _goldMedia = new GoldMedia();
            //  finYear = "17-18";
            finYear = ConfigurationManager.AppSettings["finYear"];
        }
        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            clean();

            if (e.Tab.Index == 1)
            {
                ASPxGridView2.DataBind();
            }

        }

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable2();
        }


        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
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
            dt5 = objselectall.DetailOfJobToReopenPrinter(dsp);
            return dt5;
        }

       

        private void Reopen()
        {
            if (lbslno.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please select any one job for reopen','error',3);", true);
            }

            else
            {
                Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dst = new Data.DesignSubmit.DesignSubmit.DesignSubmitProperty();

                int assignslno = Convert.ToInt32(lbldslno.Text);

                int slno = Convert.ToInt32(lbslno.Text);

                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.slno = slno;
               

                Core.DesignSubmit.DesignSubmit objinsert = new Core.DesignSubmit.DesignSubmit();
                result = objinsert.UpdateReopenSendForPrintMethod(dst);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Job Reopened Successfully !','success',3);", true);
                }
                if (result != 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);
                }

            }
            ASPxGridView2.DataBind();

        }
        protected void clean()
        {

            hfIsFabSend.Value = "0";
            hfAllowSubmit.Value = "0";
            hfAllowSubmit2.Value = "0";
            hfFabPricingAvailable.Value = "0";

            lblchildid.Text = string.Empty;

            lblPrintLocationID.Text = "0";



            lblBranchID.Text = string.Empty;
            lblBranch.Text = string.Empty;

            lbslno.Text = "0";
            ASPxGridView2.DataBind();
            lblchildid.Text = "0";
            lbprilrequestno.Text = string.Empty;

            ASPxPageControl1.ActiveTabIndex = 1;
            lbslno.Text = "0";
            lblchildid.Text = "0";


            lblDSSlno.Text = "0";

        }

        protected void CmdReopen_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            Reopen();
        }
    }
}