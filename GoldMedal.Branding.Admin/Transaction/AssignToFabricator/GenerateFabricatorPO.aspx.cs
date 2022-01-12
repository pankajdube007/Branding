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
    public partial class GenerateFabricatorPO : System.Web.UI.Page
    {
        string childslno = string.Empty;
        private readonly string finYear = string.Empty;

        public GenerateFabricatorPO()
        {
            
            finYear = ConfigurationManager.AppSettings["finYear"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
            if (!IsPostBack)
            {
                //  if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408 || usertype == "1" || usertype == "2")
                if (usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    lbslno.Text = "0";
                    ASPxPageControl1.ActiveTabIndex = 1;
                    LoadBranch();

                    ASPxGridView2.DataBind();
                }
            }
        }

        public void LoadBranch()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

           
            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            DataSet dsaselect = objselectsingleselect.AllBranchSelected(param);

            cmbbranch.Items.Clear();
            cmbbranch.Value = null;
            cmbbranch.DataSource = dsaselect.Tables[1];
            cmbbranch.TextField = "locnm";
            cmbbranch.ValueField = "branchid";
            cmbbranch.DataBind();

            if (dsaselect.Tables[0].Rows.Count > 0)
            {
                cmbbranch.SelectedItem = cmbbranch.Items.FindByValue(dsaselect.Tables[0].Rows[0]["homebranchid"].ToString());
            }
        }
        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {
            
            if (ASPxPageControl1.ActiveTabIndex == 1)
            {
                ASPxGridView1.DataBind();
            }
        }
        protected void CmdEdit_Command(object sender, CommandEventArgs e)
        {
            int FieldTripID = Convert.ToInt32(e.CommandArgument);
            lbslno.Text = FieldTripID.ToString();
            
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
        protected void ASPxCallback1_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }
        private DataTable GetTable2()
        {
            DataTable dt4 = new DataTable();

            DataTable dt = new DataTable();
            

            string frmDate = txtFrmDate.Date.ToString("yyyy-MM-dd");
            int branchIDs = 0;

            
            branchIDs = Convert.ToInt32(cmbbranch.Value);

            if (frmDate == "0001-01-01")
            {
                frmDate = "";
            }
            string toDate = txtToDate.Date.ToString("yyyy-MM-dd");
            if (toDate == "0001-01-01")
            {
                toDate = "";
            }



            if (frmDate != "" && toDate != "")
            {
                Core.FabricatorDesignSubmit.FabricatorDesignSubmit objselectall = new Core.FabricatorDesignSubmit.FabricatorDesignSubmit();
                dt4 = objselectall.GetAllJobForFabricatorForPO(frmDate, toDate, branchIDs);
            }





          
            
            return dt4;
        }
        protected void show2()
        {
            Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dsp = new Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty();
            dsp.slno = Convert.ToInt32(lbslno.Text);
            Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
            DataTable dt = objselectsingle.GetSingleForReceiveDC(dsp);
            if (dt.Rows.Count > 0)
            {

            }
          
            ASPxPageControl1.ActiveTabIndex = 0;
        }

        protected void clean()
        {
            ASPxGridView1.DataBind();
            ASPxGridView2.DataBind();
            ASPxPageControl1.ActiveTabIndex = 1;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            string error = string.Empty;
            string approvestatus = string.Empty;

            Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO dst = new Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO();

            List<object> fieldValues = ASPxGridView1.GetSelectedFieldValues(new string[] { "assignfabslno" });

            if (fieldValues.Count == 0)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please Select Jobs To Genarate PO!','warning',3);", true);
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
                dst.slno = childslno;
                dst.finYear = finYear;
                dst.branchid = Convert.ToInt32(cmbbranch.Value);
                dst.createuid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
                dst.createlogno = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno");

                Core.AssignToFabricator.AssignToFabricator objinsert = new Core.AssignToFabricator.AssignToFabricator();

                result = objinsert.GenerateFabricatorPOInsertMethod(dst);
                if (result > 0)
                {
                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','PO Generated successfully !','success',3);", true);
                    ASPxGridView1.DataBind();
                    ASPxGridView2.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Oops ! some error occured !','error',3);", true);

                }
            }
        }

        protected void CmdSearch_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }
        //protected void show2(int poheadslno)
        //{
        //    Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle = new Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO();
        //    dtsingle.slno = poheadslno;
           
        //    Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
        //    DataTable dt = objselectsingle.GetGenarateFabricatorPO(dtsingle);
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblfabpoheadslno.Text = Convert.ToString(dt.Rows[0]["slno"]);
        //        LblPoNo.Text = Convert.ToString(dt.Rows[0]["PoNumber"]);
        //        LblPoDate.Text = Convert.ToString(dt.Rows[0]["Podt"]);
        //        lblfabname.Text = Convert.ToString(dt.Rows[0]["name"]);
        //        lblfabaddress.Text = Convert.ToString(dt.Rows[0]["partyadd"]);
        //        lblbillingadd.Text = Convert.ToString(dt.Rows[0]["billingadd"]);
        //        lbldispatch.Text = Convert.ToString(dt.Rows[0]["dispatchadd"]);
        //        lbldeldate.Text = Convert.ToString(dt.Rows[0]["DelivryDate"]);
        //        lbllastdeldate.Text = Convert.ToString(dt.Rows[0]["LastDelivryDate"]);
        //        lbltotalqty.Text = Convert.ToString(dt.Rows[0]["TotalQty"]);
        //        lbltotalcost.Text = Convert.ToString(dt.Rows[0]["TotalCost"]);

        //    }
           
        //    ASPxPageControl1.ActiveTabIndex = 0;
        //}

       

        protected void ASPxGridView2_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView2.DataSource = GetTable3();
        }

        private DataTable GetTable3()
        {
            

            Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle = new Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO();
            dtsingle.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.AssignToFabricator.AssignToFabricator objselectsingle = new Core.AssignToFabricator.AssignToFabricator();
            DataTable dt = objselectsingle.GetGenarateFabricatorPO(dtsingle);

            return dt;
        }
    }
}