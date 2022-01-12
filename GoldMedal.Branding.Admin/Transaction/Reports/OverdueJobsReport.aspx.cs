using DevExpress.Web;
using GoldMedal.Branding.Core.Export;
using GoldMedal.Branding.Data.JobRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Transaction.Reports
{
    public partial class OverdueJobsReport : System.Web.UI.Page
    {
        private string FileName = string.Empty;
        private IExport xpt = null;
        string childslno = string.Empty;
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
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = GetTable2();
        }

        private DataTable GetTable2()
        {
            DataTable dt = new DataTable();
            Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dst = new Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty();
            dst.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.FinalAssembaly.FinalAssembly objselectall = new Core.FinalAssembaly.FinalAssembly();

                dt = objselectall.ListOfOverdueJobs(dst);
            
            return dt;
        }
        protected string GetFileName()
        {
            return string.Format("Overdue_Jobs_{0}", DateTime.Now.ToString());
        }
        #region Export
        /// <summary>
        /// Used for export the grid in csv format
        /// </summary>
        protected void btnCsvExport_Click(object sender, EventArgs e)
        {
           
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToCsv(ASPxGridViewExporter1, FileName, true);
            
        }

        /// <summary>
        /// Used for export the grid in xls format
        /// </summary>
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXls(ASPxGridViewExporter1, FileName, true);
            
        }

        /// <summary>
        /// Used for export the grid in xlsx format
        /// </summary>
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
           
            xpt = new Export();
            FileName = GetFileName();
            xpt.GoldGridExportToXlsx(ASPxGridViewExporter1, FileName, true);
            
        }

        #endregion Export

        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = "0";
            string error = string.Empty;
            string approvestatus = string.Empty;

            Data.ApproveJob.ApproveJobModel.OverdueJobsCancel CancelOverdue = new Data.ApproveJob.ApproveJobModel.OverdueJobsCancel();

            List<object> fieldValues = ASPxGridView1.GetSelectedFieldValues(new string[] { "slno" });

            if (fieldValues.Count == 0)
            {
               
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please Select Jobs To Cancel!','warning',3);", true);
                return;
            }
            else
            {
                foreach (object item in fieldValues)
                {
                    if (childslno == "")
                    {
                        childslno = item.ToString();
                    }
                    else
                    {
                        childslno = childslno + "," + item.ToString();
                    }
                }
                CancelOverdue.slno = childslno;
                CancelOverdue.uid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                Core.ApproveJob.ApproveJob objCancelOverdueJob = new Core.ApproveJob.ApproveJob();
                result = objCancelOverdueJob.CancelOverdueJobsMethod(CancelOverdue);
                if (result == "-1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Canceled successfully !','success',3);", true);
                    ASPxGridView1.DataBind();
                }
            }
        }
    }
   
}