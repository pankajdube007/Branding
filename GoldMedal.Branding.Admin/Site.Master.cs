using System;
using System.Data;

namespace GoldMedal.Branding.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        // General g1 = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userlogid"] != null)
            {
                CheckUrl();
            }
            else if (Request.Cookies["usertype"] != null)
            {
                CheckUrl();
            }
            else
            {
                Response.Redirect("~/logout.aspx");
            }
        }

        private void CheckUrl()
        {
            if (Request.RawUrl.Contains("JobDetails.aspx?key="))
            {
                topmenu.Style.Add("display", "none");
                mainmenu.Style.Add("display", "none");
            }
            else
            {
                topmenu.Style.Add("display", "none");
                mainmenu.Style.Add("display", "none");
                lbnm15.Text = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usernm", Convert.ToBoolean(0)).Replace(@"+", string.Empty);
                lbnm16.Text = lbnm15.Text.Replace(@"+", string.Empty);





                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("slno", Convert.ToBoolean(1)) == "" && GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usernm", Convert.ToBoolean(1)) != "")
                {
                    topmenu.Style.Add("display", "block");
                    mainmenu.Style.Add("display", "block");
                    if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid") != 0)
                    {

                        int userID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");


                        if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 408)//408
                        {
                            AssemblyMenu.Style.Add("display", "block");
                            MasterMenu.Style.Add("display", "none");
                            HOReportMenuMaster.Style.Add("display", "none");
                            AuditReportMenuMaster.Style.Add("display", "none");
                            TransactionMenu.Style.Add("display", "none");
                            homemenu.Style.Add("display", "none");
                            ReportMenuMaster.Style.Add("display", "none");
                            DbMenu.Style.Add("display", "none");
                            helpmenu.Style.Add("display", "none");
                        }
                        else
                        {
                            if (CheckUserRightsForMaster(userID))
                            {
                                MasterMenu.Style.Add("display", "block");

                                HOReportMenuMaster.Style.Add("display", "block");
                                ReportMenu6.Style.Add("display", "block");
                                ReportMenu7.Style.Add("display", "block");
                                //  ReportMenu13.Style.Add("display", "block");
                                //  ReportMenu15.Style.Add("display", "block");

                                ReportMenu1.Style.Add("display", "block");
                                //ReportMenu2.Style.Add("display", "block");
                                ReportMenu22.Style.Add("display", "block");
                                ReportMenu3.Style.Add("display", "block");
                                ReportMenu4.Style.Add("display", "block");
                                ReportMenuJobAging.Style.Add("display", "block");
                                ReportMenuPrinterPOAging.Style.Add("display", "block");
                                ReportMenuFabricatorPOAging.Style.Add("display", "block");
                                ReportMenu10.Style.Add("display", "block");
                                ReportMenu11.Style.Add("display", "block");
                                //  ReportMenu12.Style.Add("display", "block");
                                DbMenu.Style.Add("display", "block");
                                helpmenu.Style.Add("display", "block");
                                ChangeAssignMenu.Style.Add("display", "block");
                                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46)
                                {
                                    ReportMenu5.Style.Add("display", "block");
                                    // ReportMenu6.Style.Add("display", "block");
                                    // ReportMenu7.Style.Add("display", "block");

                                    BranchMenu1.Style.Add("display", "block");
                                    BranchMenuReopenSendForPrint.Style.Add("display", "block");
                                    ReportMenu8.Style.Add("display", "block");
                                    ReportMenu9.Style.Add("display", "block");
                                    AuditReportMenuMaster.Style.Add("display", "block");
                                }
                                else if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 132)
                                {
                                    ReportMenu21.Style.Add("display", "block");
                                    ReportMenu22.Style.Add("display", "none");
                                }
                                else
                                {
                                    ReportMenu5.Style.Add("display", "none");
                                    //  ReportMenu6.Style.Add("display", "none");
                                    // ReportMenu7.Style.Add("display", "none");
                                    //  ReportMenu21.Style.Add("display", "none");
                                    BranchMenu1.Style.Add("display", "none");
                                    BranchMenuReopenSendForPrint.Style.Add("display", "none");
                                    ReportMenu8.Style.Add("display", "none");
                                    ReportMenu9.Style.Add("display", "none");
                                    AuditReportMenuMaster.Style.Add("display", "none");
                                }

                            }
                            else
                            {
                                MasterMenu.Style.Add("display", "none");

                                HOReportMenuMaster.Style.Add("display", "none");
                                ReportMenu6.Style.Add("display", "none");
                                ReportMenu7.Style.Add("display", "none");
                                //  ReportMenu13.Style.Add("display", "none");
                                //  ReportMenu15.Style.Add("display", "none");

                                AuditReportMenuMaster.Style.Add("display", "none");


                                ReportMenu1.Style.Add("display", "block");
                                ReportMenu22.Style.Add("display", "block");
                                ChangeAssignMenu.Style.Add("display", "none");
                                //ReportMenu2.Style.Add("display", "none");
                                ReportMenu3.Style.Add("display", "block");
                                ReportMenu4.Style.Add("display", "block");
                                ReportMenuJobAging.Style.Add("display", "block");
                                ReportMenuPrinterPOAging.Style.Add("display", "block");
                                ReportMenuFabricatorPOAging.Style.Add("display", "block");
                                ReportMenu10.Style.Add("display", "block");
                                ReportMenu11.Style.Add("display", "block");
                                //  ReportMenu12.Style.Add("display", "block");
                                DbMenu.Style.Add("display", "none");
                                helpmenu.Style.Add("display", "block");
                                if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 46)
                                {
                                    ReportMenu5.Style.Add("display", "block");
                                    // ReportMenu6.Style.Add("display", "block");
                                    // ReportMenu7.Style.Add("display", "block");

                                    BranchMenu1.Style.Add("display", "block");
                                    BranchMenuReopenSendForPrint.Style.Add("display", "block");
                                    ReportMenu8.Style.Add("display", "block");
                                    ReportMenu9.Style.Add("display", "block");
                                    AuditReportMenuMaster.Style.Add("display", "block");
                                }
                                else if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("designationid") == 132)
                                {
                                    ReportMenu21.Style.Add("display", "block");
                                    ReportMenu22.Style.Add("display", "none");
                                }
                                else
                                {
                                    ReportMenu5.Style.Add("display", "none");
                                    //  ReportMenu6.Style.Add("display", "none");
                                    // ReportMenu7.Style.Add("display", "none");
                                    // ReportMenu21.Style.Add("display", "none");
                                    BranchMenu1.Style.Add("display", "none");
                                    BranchMenuReopenSendForPrint.Style.Add("display", "none");
                                    ReportMenu8.Style.Add("display", "none");
                                    ReportMenu9.Style.Add("display", "none");
                                    AuditReportMenuMaster.Style.Add("display", "none");

                                }

                            }
                        }
                    }

                    if (GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("logno") == 0 || string.Equals(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("logged", Convert.ToBoolean(1)), "no") || GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid") == 0 || GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usercat", Convert.ToBoolean(1)) == string.Empty)
                    {
                        string logged = "no";
                        GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("logged", logged, TimeSpan.FromHours(12));
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    string usertype = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("usertype", Convert.ToBoolean(1));
                    if (usertype == "1")
                    {
                        MasterMenu.Style.Add("display", "none");
                        HOReportMenuMaster.Style.Add("display", "none");
                        AuditReportMenuMaster.Style.Add("display", "none");
                        TransactionMenu.Style.Add("display", "none");
                        homemenu.Style.Add("display", "none");
                        ReportMenuMaster.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        FabricatorMenu.Style.Add("display", "none");
                        PrinterMenu.Style.Add("display", "block");

                    }
                    if (usertype == "2")
                    {
                        MasterMenu.Style.Add("display", "none");
                        HOReportMenuMaster.Style.Add("display", "none");
                        AuditReportMenuMaster.Style.Add("display", "none");
                        TransactionMenu.Style.Add("display", "none");
                        homemenu.Style.Add("display", "none");
                        ReportMenuMaster.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        
                        PrinterMenu.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        //  mainmenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        FabricatorMenu.Style.Add("display", "block");
                    }
                    if (usertype == "3")
                    {
                        MasterMenu.Style.Add("display", "none");
                        HOReportMenuMaster.Style.Add("display", "none");
                        AuditReportMenuMaster.Style.Add("display", "none");
                        TransactionMenu.Style.Add("display", "none");
                        homemenu.Style.Add("display", "none");
                        ReportMenuMaster.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        
                        PrinterMenu.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        //  mainmenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        FabricatorMenu.Style.Add("display", "none");
                        DispatchTeamMenu.Style.Add("display", "block");
                        SelfInstallationTeamMenu.Style.Add("display", "none");
                        VendorTeamMenu.Style.Add("display", "none");
                    }
                    if (usertype == "4")
                    {
                        MasterMenu.Style.Add("display", "none");
                        HOReportMenuMaster.Style.Add("display", "none");
                        AuditReportMenuMaster.Style.Add("display", "none");
                        TransactionMenu.Style.Add("display", "none");
                        homemenu.Style.Add("display", "none");
                        ReportMenuMaster.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        
                        PrinterMenu.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        //  mainmenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        FabricatorMenu.Style.Add("display", "none");
                        DispatchTeamMenu.Style.Add("display", "none");
                        SelfInstallationTeamMenu.Style.Add("display", "block");
                        VendorTeamMenu.Style.Add("display", "none");
                    }
                    if (usertype == "5")
                    {
                        MasterMenu.Style.Add("display", "none");
                        HOReportMenuMaster.Style.Add("display", "none");
                        AuditReportMenuMaster.Style.Add("display", "none");
                        TransactionMenu.Style.Add("display", "none");
                        homemenu.Style.Add("display", "none");
                        ReportMenuMaster.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        
                        PrinterMenu.Style.Add("display", "none");
                        DbMenu.Style.Add("display", "none");
                        //  mainmenu.Style.Add("display", "none");
                        helpmenu.Style.Add("display", "none");
                        FabricatorMenu.Style.Add("display", "none");
                        DispatchTeamMenu.Style.Add("display", "none");
                        SelfInstallationTeamMenu.Style.Add("display", "none");
                        VendorTeamMenu.Style.Add("display", "block");
                    }
                    if (usertype == "1" || usertype == "2" || usertype == "3" || usertype == "4" || usertype == "5")
                    {
                        topmenu.Style.Add("display", "block");
                        mainmenu.Style.Add("display", "block");
                        lbnm15.Text = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("name", Convert.ToBoolean(0)).Replace(@"+", string.Empty);
                        lbnm16.Text = lbnm15.Text;
                    }

                }
            }
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
    }
}