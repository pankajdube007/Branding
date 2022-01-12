using DevExpress.Web;
using System;
using System.Data;
using System.Threading;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Transaction.AssignJob
{
    public partial class DeleteAssignJob : System.Web.UI.Page
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
                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
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

            //int FieldTripID = Convert.ToInt32(e.CommandArgument);

            lbldelslno.Text = Convert.ToString(e.CommandArgument);

            this.mpeImage.Show();


            //Data.AssignJob.AssignJobModel.AssignProperties ddel = new Data.AssignJob.AssignJobModel.AssignProperties();
            //ddel.slno = Convert.ToInt32(FieldTripID);
            //ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
            //ddel.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            //Core.AssignJob.AssignJob objdelete = new Core.AssignJob.AssignJob();
            //rows = objdelete.AssignedJobDeleteMethod(ddel);
            //if (rows == 1)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull ! !','success',3);", true);
            //    ASPxGridView1.DataBind();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit','warning',3);", true);
            //    ASPxGridView1.DataBind();
            //}
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
            Data.AssignJob.AssignJobModel.AssignProperties param = new Data.AssignJob.AssignJobModel.AssignProperties();
            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.AssignJob.AssignJob objdata = new Core.AssignJob.AssignJob();
            DataTable dt = objdata.AllAssignedJobDACoreUser(param);
           
            return dt;


            //DataTable dt4 = new DataTable();
            //Core.AssignJob.AssignJob objselectall = new Core.AssignJob.AssignJob();
            //dt4 = objselectall.AllAssignedJobDACore();
            //return dt4;
        }

        #endregion Method

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtremark.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Please Enter Remark.','error',3);", true);
            }
            else
            {

                Data.AssignJob.AssignJobModel.AssignProperties ddel = new Data.AssignJob.AssignJobModel.AssignProperties();
                ddel.slno = Convert.ToInt32(lbldelslno.Text);
                ddel.DeleteRemark = txtremark.Text;
                ddel.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");
                ddel.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                Core.AssignJob.AssignJob objdelete = new Core.AssignJob.AssignJob();
                rows = objdelete.AssignedJobDeleteMethod(ddel);
                if (rows == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull ! !','success',3);", true);
                    clean();
                    ASPxGridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit','warning',3);", true);
                    clean();
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
            lbldelslno.Text = "0";
        }
        protected void btnOverWrite_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.mpeImage.Hide();
            clean();
        }
    }
}