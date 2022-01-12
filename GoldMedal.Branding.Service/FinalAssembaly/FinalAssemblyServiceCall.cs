using GoldMedal.Branding.Data.FinalAssembaly;
using System.Data;

namespace GoldMedal.Branding.Service.FinalAssembaly
{
    public class FinalAssemblyServiceCall
    {
        public static DataTable ListOfJobForFinlaAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForFinlaAssembly(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable ListOfJobForFinlaAssemblyModeUpdateServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForFinlaAssemblyModeUpdateDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable ListOfJobForFinlaAssemblyDispatchModeServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForFinlaAssemblyDispatchModeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfJobForPOGenerationDispatchModeServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForPOGenerationDispatchModeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfJobForFinlaAssemblySelfInstallationModeServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForFinlaAssemblySelfInstallationModeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfJobForFinlaAssemblyVendorModeServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForFinlaAssemblyVendorModeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable ListOfDispatchModeServiceMethod(string DatabaseType, int Mode)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfDispatchModeDA(Mode);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetJoblisttoacceptforfinalassemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetJoblisttoacceptforfinalassemblyDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

       

        public static DataTable ListOfJobForJobCloserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForJobCloser(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfApprovedJobForJobCloserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfApprovedJobForJobCloser(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfPrintedJobForJobCloserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfPrintedJobForJobCloser(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable DetailOfItemListForFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfItemListForFinalAssemblyDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static int SubmitFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.SubmitFinalAssembly(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static DataTable GetDispatchTeamListServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetDispatchTeamDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int AddDispatchTeamServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddDispatchTeamDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable SingleDispatchTeamUserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objsingledesigntype = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SingleDispatchTeamUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int DispatchTeamUserDeleteServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.DispatchTeamDelete  dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objdelete = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteDispatchTeamDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static DataTable GetSelfInstallationTeamListServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetSelfInstallationTeamDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int AddSelfInstallationTeamServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.SelfInstallationTeamInsert dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddSelfInstallationTeamDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable SingleSelfInstallationTeamUserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.SelfInstallationTeamInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objsingledesigntype = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SingleSelfInstallationTeamUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int SelfInstallationTeamUserDeleteServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.SelfInstallationTeamDelete dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objdelete = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteSelfInstallationTeamDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }



        public static DataTable GetVendorTeamListServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetVendorTeamDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int AddVendorTeamServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.VendorTeamInsert dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddVendorTeamDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable SingleVendorTeamUserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.VendorTeamInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objsingledesigntype = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SingleVendorTeamUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int VendorTeamUserDeleteServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.VendorTeamDelete dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objdelete = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteVendorTeamDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static int AddItemFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddItemFinalAssemblyDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int DeleteItemForFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.DeleteItemForFinalAssembly(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int UpdateModeOfFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateModeOfFinalAssemblyDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int UpdateDispatchDetailsofFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateDispatchDetailsOfFinalAssemblyDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int UpdateSelfInstallationDetailsofFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateSelfInstallationDetailsOfFinalAssemblyDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdateVendorDetailsofFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateVendorDetailsOfFinalAssemblyDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int JobsAcceptForFinalAssemblyServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobsAcceptForFinalAssemblyDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int JobCloserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobCloser(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int ApprovedJobCloserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ApprovedJobCloser(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int PrintedJobCloserServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti, string DatabaseType)
        {
            int recid = 0;
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PrintedJobCloser(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static DataTable ListOfJobForJobHistoryServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForJobHistory(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable ListOfCancelledJobForJobHistoryServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfCancelledJobForJobHistory(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllJobCountServiceMethod(string FromDate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllJobCountDA(FromDate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        

        public static DataTable ListOfDisapprovedJobRequestsServiceMethod(string Fromdate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfDisapprovedJobRequestsDA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfJobRequestForJobReportServiceMethod(string Fromdate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobRequestForJobReportDA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfAssignToDesignerJobRequestForJobReportServiceMethod(string Fromdate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfAssignToDesignerJobRequestForJobReportDA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfAssignToPrinterJobRequestForJobReportServiceMethod(string Fromdate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfAssignToPrinterJobRequestForJobReportDA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfAssignToFabricatorJobRequestForJobReportServiceMethod(string Fromdate, string ToDate, string BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfAssignToFabricatorJobRequestForJobReportDA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfOverdueJobsServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetOverdueJobs(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable UserLoginDetailsServiceMethod(string DatabaseType,string Fromdate)
        {
            DataTable recid = null;
            FinalAssemblyDataAccess objselectall = new FinalAssemblyDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetUserLoginDetails(Fromdate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static string DispatchTeamLoginServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin plogin, string DatabaseType)
        {
            string recid = "0";
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();
           
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.DispatchTeamLogin(plogin);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }


        public static string SelfInstallationTeamLoginServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin plogin, string DatabaseType)
        {
            string recid = "0";
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();

            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.SelfInstallationTeamLogin(plogin);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }
        public static string VendorTeamLoginServiceMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin plogin, string DatabaseType)
        {
            string recid = "0";
            FinalAssemblyDataAccess objinsert = new FinalAssemblyDataAccess();

            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.VendorTeamLogin(plogin);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }
    }
}