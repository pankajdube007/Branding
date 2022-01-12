using System;
using System.Data;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Transaction.AssignToFabricator
{
    public partial class DeleteAssignedFabricator : System.Web.UI.Page
    {
        private int rows = 0;

        #region Page Event

        /// <summary>
        /// bind all assigned job on page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    ASPxGridView1.DataBind();
                }
            }
        }

        #endregion Page Event

        #region event

        /// <summary>
        /// delete the assigned child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CmdDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty ddel = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            ddel.slno = Convert.ToInt32(FieldTripID);
            ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
            ddel.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignToFabricator.AssignToFabricator objdelete = new Core.AssignToFabricator.AssignToFabricator();
            rows = objdelete.AssignedfabricatorDeleteMethod(ddel);
            if (rows == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull ! !','success',3);", true);
                ASPxGridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit','warning',3);", true);
                ASPxGridView1.DataBind();
            }
        }

        /// <summary>
        /// bind the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable1();
        }

        #endregion event

        #region Method

        /// <summary>
        /// list of all assigned job
        /// </summary>
        /// <returns></returns>
        private DataTable GetTable1()
        {
            //DataTable dt4 = new DataTable();
            //Core.AssignToFabricator.AssignToFabricator objselectall = new Core.AssignToFabricator.AssignToFabricator();
            //dt4 = objselectall.AllAssignedfabricatorDACore();
            //return dt4;

            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty param = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignToFabricator.AssignToFabricator objdata = new Core.AssignToFabricator.AssignToFabricator();
            // DataTable dt = objdata.AllAssignedPrinterForJobDACore();
            DataTable dt = objdata.AllAssignedfabricatorDACoreUser(param);
           // DataTable dt = objdata.AllAssignedfabricatorDACore();
            return dt;
        }

        #endregion Method
    }
}