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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.AssignToFabricator
{
    public partial class CancelFabricatorPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                // if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2"|| usertype == "3" || usertype == "4" || usertype == "5")
                if (usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
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
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
        protected void clean()
        {
            ASPxGridView1.DataBind();

            ASPxPageControl1.ActiveTabIndex = 1;
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable3();
        }
        private DataTable GetTable3()
        {

            Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle = new Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO();
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
            DataTable dt = objselectsingle.GetGenarateFabricatorPOForCancelList(dtsingle);

            return dt;
        }
        protected void CmdCancel_Command(object sender, CommandEventArgs e)
        {
            int result = 0;
            string error = string.Empty;
            string approvestatus = string.Empty;

            Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO dst = new Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO();

            hdedit.Value = "";
            hdedit.Value = e.CommandArgument.ToString();
            long AssignFabricatorSlno = 0;
            long POChildslno = 0;
            long PoHeadslno = 0;

            var val = hdedit.Value.ToString().Split(':');
            if (val.Length <= 3)
            {
                AssignFabricatorSlno = Convert.ToInt64(val[0]);
                POChildslno = Convert.ToInt64(val[1]);
                PoHeadslno = Convert.ToInt64(val[2]);
            }
            dst.AssignFabricatorSlno = AssignFabricatorSlno;
            dst.POChildslno = POChildslno;
            dst.PoHeadslno = PoHeadslno;
            dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.AssignToFabricator.AssignToFabricator objinsert = new Core.AssignToFabricator.AssignToFabricator();

            result = objinsert.CancelFabricatorPo(dst);
            if (result > 0)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','PO Cancelled successfully !','success',3);", true);
                ASPxGridView1.DataBind();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);

            }

        }
    }
}