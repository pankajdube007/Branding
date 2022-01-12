using DevExpress.Web;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using System;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoldMedal.Branding.Admin.Master
{
    public partial class Dashboard : System.Web.UI.Page
    {
        #region Initialization

        private DataTable dt = new DataTable();
        private int rows = 0;

        private int flag = 0;

        #endregion Initialization

        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            if (!IsPostBack)
            {
                if (CheckUserRightsForMaster(userID))
                {
                    if (Convert.ToInt32(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid")) == 132)
                {
                   // divBranchwiseJobsCount.Visible = true;
                }
                    LoadBranch();
                flag = 1;
                BindData();

                //ASPxPivotGrid1.CellTemplate = new CellTemplate();

                txtFromDate.Text = "01/04/2021";
                txtToDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                flag = 0;
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }

            txtToDate.MaxDate = DateTime.Now;
            // txtFromDate.MaxDate = DateTime.Now.AddDays(-1);
            txtFromDate.MaxDate = DateTime.Now;
        }
        private bool CheckUserRightsForMaster(int UserID)
        {
            bool success = false;

            Data.MasterMenu.MasterMenuModel.UserCheck dst = new Data.MasterMenu.MasterMenuModel.UserCheck();
            dst.UserID = UserID;
            Core.MasterMenu.MasterMenu objcheck = new Core.MasterMenu.MasterMenu();
            DataTable result = objcheck.UserCheckMethod(dst);

            if (Convert.ToInt32(result.Rows[0]["Status"]) == 1)
            {
                success = true;
            }

            return success;
        }
        public void LoadBranch()
        {
            Data.JobRequest.JobRequestModel.JobRequestProperties param = new Data.JobRequest.JobRequestModel.JobRequestProperties();

            param.userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.JobRequest.JobRequest objselectsingleselect = new Core.JobRequest.JobRequest();
            DataSet dsaselect = objselectsingleselect.AllBranchSelected(param);

            lbBranch.Items.Clear();
            lbBranch.Value = null;
            lbBranch.DataSource = dsaselect.Tables[1];
            lbBranch.TextField = "locnm";
            lbBranch.ValueField = "branchid";
            lbBranch.DataBind();

            if (dsaselect.Tables[0].Rows.Count > 0)
            {
                lbBranch.SelectedItem = lbBranch.Items.FindByValue(dsaselect.Tables[0].Rows[0]["homebranchid"].ToString());
            }
        }

        private void BindData()
        {
            ASPxPivotGrid1.DataBind();
            ASPxPivotGrid1.CellTemplate = new CellTemplateDesig();
            ASPxPivotGrid1.FieldValueTemplate = new FieldValueTemplatefordesi();



            ASPxPivotGrid2.DataBind();
            ASPxPivotGrid2.CellTemplate = new CellTemplateBranch();
            ASPxPivotGrid2.FieldValueTemplate = new FieldValueTemplateforBranch();


            ASPxPivotGrid3.DataBind();
            ASPxPivotGrid4.DataBind();

            if(Convert.ToInt32(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid")) == 132)
                {
                ASPxPivotGrid5.DataBind();
                 }
            


            ASPxPivotGrid6.DataBind();

            ASPxPivotGrid6.CellTemplate = new CellTemplate();
            ASPxPivotGrid6.FieldValueTemplate = new FieldValueTemplateforcat();

            ASPxPivotGrid7.DataBind();
            ASPxPivotGrid7.CellTemplate = new CellTemplateLiveProduct();
            ASPxPivotGrid7.FieldValueTemplate = new FieldValueTemplateforLiveProduct();
        }


        class FieldValueTemplateforBranch : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridFieldValueTemplateContainer c = (PivotGridFieldValueTemplateContainer)container;
                // PivotGridFieldValueHtmlCell cell = c.CreateFieldValue();
                PivotFieldValueItem valueItem = c.ValueItem;
                PivotDrillDownDataSource ds = valueItem.CreateDrillDownDataSource();

                int BranchID = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";


                if (ds.RowCount > 0)
                {
                    BranchID = Convert.ToInt32(ds[0]["branchid"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);


                    c.Controls.Add(new MyLinkBranch(c.Text, BranchID, FromDate, Todate));
                }
            }
        }
        class FieldValueTemplateforLiveProduct : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridFieldValueTemplateContainer c = (PivotGridFieldValueTemplateContainer)container;
                // PivotGridFieldValueHtmlCell cell = c.CreateFieldValue();
                PivotFieldValueItem valueItem = c.ValueItem;
                PivotDrillDownDataSource ds = valueItem.CreateDrillDownDataSource();

                int BranchID = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";


                if (ds.RowCount > 0)
                {
                    BranchID = Convert.ToInt32(ds[0]["branchid"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);


                    c.Controls.Add(new MyLinkLiveProduct(c.Text, BranchID, FromDate, Todate));
                }
            }
        }
        class CellTemplateLiveProduct : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridCellTemplateContainer c = container as PivotGridCellTemplateContainer;
                PivotDrillDownDataSource ds = c.Item.CreateDrillDownDataSource();

                int BranchID = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";
                if (ds.RowCount > 0)
                {
                    BranchID = Convert.ToInt32(ds[0]["branchid"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);

                    c.Controls.Add(new MyLinkLiveProduct(c.Text, BranchID, FromDate, Todate));


                }
            }
        }
        public class MyLinkLiveProduct : HyperLink
        {
            public MyLinkLiveProduct(string text, int branchid, string Fromdate, string Todate) : base()
            {
                Text = text;

                //ToolTip = category.ToString();
                NavigateUrl = "~/transaction/ApprovdisapprovdesignsubmitByManagement/apdapdesignsubmitbymanag.aspx";
                Target = "_blank";
            }
        }

        class CellTemplateBranch : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridCellTemplateContainer c = container as PivotGridCellTemplateContainer;
                PivotDrillDownDataSource ds = c.Item.CreateDrillDownDataSource();

                int BranchID = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";
                if (ds.RowCount > 0)
                {
                    BranchID = Convert.ToInt32(ds[0]["branchid"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);

                    c.Controls.Add(new MyLinkBranch(c.Text, BranchID, FromDate, Todate));


                }
            }
        }

        public class MyLinkBranch : HyperLink
        {
            public MyLinkBranch(string text, int branchid, string Fromdate, string Todate) : base()
            {
                Text = text;

                //ToolTip = category.ToString();
                NavigateUrl = "Designerbranchwisejobscount.aspx?branch=2&branchid=" + branchid + "&Fromdate=" + Fromdate + "&Todate=" + Todate;
                Target = "_blank";
            }
        }

        public class MyLinkforBranch : HyperLink
        {
            public MyLinkforBranch(string text, int branchid, string Fromdate, string Todate) : base()
            {
                Text = text;
                Style.Add("cursor", "default");

                //ToolTip = category.ToString();
                //NavigateUrl = "Designerbranchwisejobscount.aspx?designerid=" + designerid;
                //Target = "_blank";
            }
        }










        class FieldValueTemplatefordesi : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridFieldValueTemplateContainer c = (PivotGridFieldValueTemplateContainer)container;
                // PivotGridFieldValueHtmlCell cell = c.CreateFieldValue();
                PivotFieldValueItem valueItem = c.ValueItem;
                PivotDrillDownDataSource ds = valueItem.CreateDrillDownDataSource();

                int BranchID = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";


                if (ds.RowCount > 0)
                {
                    BranchID = Convert.ToInt32(ds[0]["branchid"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);


                    c.Controls.Add(new MyLinkdes(c.Text, BranchID, FromDate, Todate));
                }
            }
        }


        class CellTemplateDesig : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridCellTemplateContainer c = container as PivotGridCellTemplateContainer;
                PivotDrillDownDataSource ds = c.Item.CreateDrillDownDataSource();

                int BranchID = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";
                if (ds.RowCount > 0)
                {
                    BranchID = Convert.ToInt32(ds[0]["branchid"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);

                    c.Controls.Add(new MyLinkforDesig(c.Text, BranchID, FromDate, Todate));


                }
            }
        }

        public class MyLinkdes : HyperLink
        {
            public MyLinkdes(string text, int branchid, string Fromdate,string Todate) : base()
            {
                Text = text;

                //ToolTip = category.ToString();
                NavigateUrl = "Designerbranchwisejobscount.aspx?branch=1&branchid=" + branchid+"&Fromdate="+ Fromdate + "&Todate=" + Todate;
                Target = "_blank";
            }
        }

        public class MyLinkforDesig : HyperLink
        {
            public MyLinkforDesig(string text, int branchid, string Fromdate, string Todate) : base()
            {
                Text = text;
                Style.Add("cursor", "default");

                //ToolTip = category.ToString();
                //NavigateUrl = "Designerbranchwisejobscount.aspx?designerid=" + designerid;
                //Target = "_blank";
            }
        }

        class FieldValueTemplateforcat : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridFieldValueTemplateContainer c = (PivotGridFieldValueTemplateContainer)container;
               // PivotGridFieldValueHtmlCell cell = c.CreateFieldValue();
                PivotFieldValueItem valueItem = c.ValueItem;
                PivotDrillDownDataSource ds = valueItem.CreateDrillDownDataSource();

                int designerid = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";
                if (ds.RowCount > 0)
                {
                    designerid = Convert.ToInt32(ds[0]["DesignerID"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);

                    c.Controls.Add(new MyLink(c.Text, designerid, FromDate, Todate));
                }
            }
        }

        class CellTemplate : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                PivotGridCellTemplateContainer c = container as PivotGridCellTemplateContainer;
                PivotDrillDownDataSource ds = c.Item.CreateDrillDownDataSource();

                int designerid = 0;
                string text = "";
                string text1 = "";
                string FromDate = "";
                string Todate = "";
                if (ds.RowCount > 0)
                {
                    designerid = Convert.ToInt32(ds[0]["DesignerID"]);
                    FromDate = Convert.ToString(ds[0]["FromDate"]);
                    Todate = Convert.ToString(ds[0]["Todate"]);

                    c.Controls.Add(new MyLinkforCat(c.Text, designerid, FromDate, Todate));
                    
                   
                }
            }
        }


        public class MyLink : HyperLink
        {
            public MyLink(string text, int designerid, string Fromdate, string Todate) : base()
            {
                Text = text;

                //ToolTip = category.ToString();
                NavigateUrl = "Designerbranchwisejobscount.aspx?branch=0&designerid=" + designerid + "&Fromdate=" + Fromdate + "&Todate=" + Todate;
                Target = "_blank";
            }
        }

        public class MyLinkforCat : HyperLink
        {
            public MyLinkforCat(string text, int designerid, string Fromdate, string Todate) : base()
            {
                Text = text;
                Style.Add("cursor", "default");
                
                //ToolTip = category.ToString();
                //NavigateUrl = "Designerbranchwisejobscount.aspx?designerid=" + designerid;
                //Target = "_blank";
            }
        }


        private DataTable GetTable1()
        {
            DataTable dt = new DataTable();
            string branchids = "";

            string frmDate = "";
            string toDate = "";

            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }

            if (flag == 1)
            {
                frmDate = "2021-04-01";
                toDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                toDate = txtToDate.Date.ToString("yyyy-MM-dd");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }
            }

            if (frmDate != "" && toDate != "")
            {
                dt = objdata.GetBranchwiseJobCountDACore(branchids, frmDate, toDate);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }
            return dt;
        }

        private DataTable GetTable2()
        {
            DataTable dt = new DataTable();
            string branchids = "";

            string frmDate = "";
            string toDate = "";

            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }

            if (flag == 1)
            {
                frmDate = "2021-04-01";
                toDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                toDate = txtToDate.Date.ToString("yyyy-MM-dd");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }
            }

            if (frmDate != "" && toDate != "")
            {
                dt = objdata.GetBranchwiseApprovedJobCountDACore(branchids, frmDate, toDate);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }
            return dt;
        }

        private DataTable GetTable3()
        {
            DataTable dt = new DataTable();
            string branchids = "";
            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }

            dt = objdata.GetDesignerwiseJobCountDACore(branchids);
            return dt;
        }

        private DataTable GetTable4()
        {
            DataTable dt = new DataTable();
            string branchids = "";
            string frmDate = "";
            string toDate = "";
            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }
            if (flag == 1)
            {
                frmDate = "2021-04-01";
                toDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                toDate = txtToDate.Date.ToString("yyyy-MM-dd");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }
            }

           

            if (frmDate != "" && toDate != "")
            {
                dt = objdata.GetDesignerwiseApprovedPendingJobCountDACore(branchids, frmDate, toDate);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }
            return dt;
        }

        protected void ASPxCallback_Callback(object source, CallbackEventArgs e)
        {
            Thread.Sleep(500);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string branchIDs = "";

            for (int i = 0; i < lbBranch.Items.Count; i++)
            {
                if (lbBranch.Items[i].Selected == true)
                {
                    branchIDs += lbBranch.Items[i].Value.ToString() + ",";
                }
            }

            branchIDs = branchIDs.TrimEnd(',');

            if (branchIDs == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select atleast one branch !','warning',3);", true);
                return;
            }


            string frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
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
                DateTime dtFrm = Convert.ToDateTime(txtFromDate.Date.ToString("yyyy-MM-dd"));
                DateTime dtTo = Convert.ToDateTime(txtToDate.Date.ToString("yyyy-MM-dd"));

                if (dtFrm <= dtTo)
                {
                    BindData();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('From Date should be less then To Date.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select both the dates.');", true);
            }
        }

        protected void ASPxPivotGrid1_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid1.DataSource = GetTable1();
        }

        protected void ASPxPivotGrid2_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid2.DataSource = GetTable2();
        }

        protected void ASPxPivotGrid3_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid3.DataSource = GetTable3();
        }

        protected void ASPxPivotGrid4_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid4.DataSource = GetTable4();
        }

        protected void ASPxPivotGrid5_DataBinding(object sender, EventArgs e)
        {
           // ASPxPivotGrid5.DataSource = GetTable5();
        }

        protected void ASPxPivotGrid6_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid6.DataSource = GetTable6();
        }

        private DataTable GetTable5()
        {
            string frmDate = "";
            string toDate = "";
            DataTable dt = new DataTable();
            string branchids = "";
            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }
            if (flag == 1)
            {
                frmDate = "2021-04-01";
                toDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                toDate = txtToDate.Date.ToString("yyyy-MM-dd");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }
            }


            if (frmDate != "" && toDate != "")
            {
               // dt = objdata.GetBranchwiseJobDashboardCountDACore(branchids, userid, frmDate, toDate);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }
            return dt;
        }

        private DataTable GetTable6()
        {
            DataTable dt = new DataTable();
            string branchids = "";
            string frmDate = "";
            string toDate = "";
            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }
            if (flag == 1)
            {
                frmDate = "2021-04-01";
                toDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                toDate = txtToDate.Date.ToString("yyyy-MM-dd");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }
            }
            
            


            if (frmDate != "" && toDate != "")
            {
                dt = objdata.GetDesignerwiseJobDashboardCountDACore(branchids, frmDate, toDate);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }
            return dt;
        }


        protected void OnHyperLinkDataBinding(object sender, EventArgs e)
        {

            //ASPxHyperLink link = (ASPxHyperLink)sender;
            //link.Text = ((PivotGridFieldValueTemplateContainer)link.Parent).Text;
            
        }

        protected void ASPxPivotGrid7_DataBinding(object sender, EventArgs e)
        {
            ASPxPivotGrid7.DataSource = GetTable7();
        }
        private DataTable GetTable7()
        {
            DataTable dt = new DataTable();
            string branchids = "";

            string frmDate = "";
            string toDate = "";

            int userid = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");

            Core.Dashboard.Dashboard objdata = new Core.Dashboard.Dashboard();

            if (flag == 1)
            {
                branchids = objdata.GetAllUserBranchDACore(userid);
            }
            else
            {
                for (int i = 0; i < lbBranch.Items.Count; i++)
                {
                    if (lbBranch.Items[i].Selected == true)
                    {
                        branchids += lbBranch.Items[i].Value.ToString() + ",";
                    }
                }

                branchids = branchids.TrimEnd(',');
            }

            if (flag == 1)
            {
                frmDate = "2021-04-01";
                toDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                frmDate = txtFromDate.Date.ToString("yyyy-MM-dd");
                if (frmDate == "0001-01-01")
                {
                    frmDate = "";
                }
                toDate = txtToDate.Date.ToString("yyyy-MM-dd");
                if (toDate == "0001-01-01")
                {
                    toDate = "";
                }
            }

            if (frmDate != "" && toDate != "")
            {
                dt = objdata.GetBranchwiseLiveProductApprovalPendingJobCountCore(branchids, frmDate, toDate);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select valid date !','warning',3);", true);
            }
            return dt;
        }
    }
}