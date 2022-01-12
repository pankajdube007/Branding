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

namespace GoldMedal.Branding.Admin.Transaction.AssigntoPrinter
{
    public partial class CancelPrinterPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                // if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2")
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


            Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle = new Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO();
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.AssigntoPrinter.Assigntoprinter objselectsingle = new Core.AssigntoPrinter.Assigntoprinter();
            DataTable dt = objselectsingle.GetGenaratePrinterForCancelListPO(dtsingle);

            return dt;
        }
        protected void CmdCancel_Command(object sender, CommandEventArgs e)
        {
            int result = 0;
            string error = string.Empty;
            string approvestatus = string.Empty;

            Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO dst = new Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO();

            hdedit.Value = "";
            hdedit.Value = e.CommandArgument.ToString();
            long AssignPrinterSlno = 0;
            long POChildslno = 0;
            long PoHeadslno = 0;

            var val = hdedit.Value.ToString().Split(':');
            if (val.Length <= 3)
            {
                AssignPrinterSlno = Convert.ToInt64(val[0]);
                POChildslno = Convert.ToInt64(val[1]);
                PoHeadslno = Convert.ToInt64(val[2]);
            }
            dst.AssignPrinterSlno = AssignPrinterSlno;
            dst.POChildslno = POChildslno;
            dst.PoHeadslno = PoHeadslno;
            dst.createuid= GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.AssigntoPrinter.Assigntoprinter objinsert = new Core.AssigntoPrinter.Assigntoprinter();

                result = objinsert.CancelPrinterPoMethod(dst);
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
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int result = 0;
            string error = string.Empty;
            string status = string.Empty;

            Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO dst = new Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO();

            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                // ASPxCheckBox chk = ASPxGridView1.FindRowCellTemplateControl(i, ASPxGridView1.Columns["Cancel"] as GridViewDataColumn, "gvCheck") as ASPxCheckBox;
                var chk = ASPxGridView1.Selection.IsRowSelected(i);

                if (chk != null)
                {

                 //   if (chk.Checked == true)
                        if (chk == true)
                        {
                        ASPxTextBox CancelRemark = ASPxGridView1.FindRowCellTemplateControl(i, ASPxGridView1.Columns["Remark"] as GridViewDataTextColumn, "txtcancelremark") as ASPxTextBox;


                        int PoHeadslno = Convert.ToInt32(ASPxGridView1.GetRowValues(i, "slno"));
                        int AssignPrinterSlno = Convert.ToInt32(ASPxGridView1.GetRowValues(i, "AssignPrinterSlno"));
                        int POChildslno = Convert.ToInt32(ASPxGridView1.GetRowValues(i, "POChildslno"));

                        dst.AssignPrinterSlno = AssignPrinterSlno;
                        dst.POChildslno = POChildslno;
                        dst.PoHeadslno = PoHeadslno;
                        dst.CancelRemark = Convert.ToString(CancelRemark.Text);
                        dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

                        Core.AssigntoPrinter.Assigntoprinter objinsert = new Core.AssigntoPrinter.Assigntoprinter();

                        result = objinsert.CancelPrinterPoMethod(dst);
                        if (result > 0)
                        {
                            //if(status != "1")
                            //{
                            //    status = "0";

                            //}

                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','PO Cancelled successfully !','success',3);", true);
                          

                        }
                        else
                        {
                           // status = "1";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);

                        }



                    }
                }
            }
            //if(status == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','PO Cancelled successfully !','success',3);", true);

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);

            //}



            clean();
        }

        protected void gvCheckAll_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);

            
        }

       
    }
}