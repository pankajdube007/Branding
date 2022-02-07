using GoldMedal.Branding.Service.FinalAssembaly;
using System.Data;

namespace GoldMedal.Branding.Core.FinalAssembaly
{
    public class FinalAssembly : IFinalAssembly
    {
        public string DispatchTeamLoginMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin dti)
        {
            string recid = "0";

            recid = FinalAssemblyServiceCall.DispatchTeamLoginServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public string SelfInstallationTeamLoginMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin dti)
        {
            string recid = "0";

            recid = FinalAssemblyServiceCall.SelfInstallationTeamLoginServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public string VendorTeamLoginMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin dti)
        {
            string recid = "0";

            recid = FinalAssemblyServiceCall.VendorTeamLoginServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable ListOfJobForFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForFinlaAssemblyServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable ListOfJobForFinlaAssemblyModeUpdate(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForFinlaAssemblyModeUpdateServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable ListOfJobForFinlaAssemblyDispatchMode(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForFinlaAssemblyDispatchModeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobForPOGenerationDispatchMode(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForPOGenerationDispatchModeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobForFinlaAssemblySelfInstallationMode(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForFinlaAssemblySelfInstallationModeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobForFinlaAssemblyVendorMode(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForFinlaAssemblyVendorModeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable ListOfDispatchMode(int Mode)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfDispatchModeServiceMethod("MSSQLSERVER", Mode);
            return recid;
        }

        public DataTable GetJoblisttoacceptforfinalassembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.GetJoblisttoacceptforfinalassemblyServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

       

        public DataTable ListOfJobForJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForJobCloserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfApprovedJobForJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfApprovedJobForJobCloserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfPrintedJobForJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfPrintedJobForJobCloserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable DetailOfItemListForFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.DetailOfItemListForFinalAssemblyServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int SubmitFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.SubmitFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetDispatchTeamUsers()
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.GetDispatchTeamListServiceMethod("MSSQLSERVER");
            return recid;
        }
        public int AddDispatchTeam(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.AddDispatchTeamServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetDispatchTeamUserSingle(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.DispatchTeamInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.SingleDispatchTeamUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int DispatchTeamUserDeleteMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.DispatchTeamDelete dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.DispatchTeamUserDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetSelfInstallationTeamUsers()
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.GetSelfInstallationTeamListServiceMethod("MSSQLSERVER");
            return recid;
        }
        public int AddSelfInstallationTeam(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.SelfInstallationTeamInsert dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.AddSelfInstallationTeamServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSelfInstallationTeamUserSingle(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.SelfInstallationTeamInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.SingleSelfInstallationTeamUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int SelfInstallationTeamUserDeleteMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.SelfInstallationTeamDelete dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.SelfInstallationTeamUserDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }


        public DataTable GetVendorTeamUsers()
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.GetVendorTeamListServiceMethod("MSSQLSERVER");
            return recid;
        }
        public int AddVendorTeam(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.VendorTeamInsert dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.AddVendorTeamServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetVendorTeamUserSingle(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.VendorTeamInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.SingleVendorTeamUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int VendorTeamUserDeleteMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.VendorTeamDelete dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.VendorTeamUserDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int ItemFinalAssemblyInsertMethod(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.AddItemFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int DeleteItemForFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.DeleteItemForFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateModeOfFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.UpdateModeOfFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateDispatchDetailOfFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.UpdateDispatchDetailsofFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateSelfInstallationDetailOfFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.UpdateSelfInstallationDetailsofFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateVendorDetailOfFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.UpdateVendorDetailsofFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int JobsAcceptForFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.JobsAcceptForFinalAssemblyServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int JobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.JobCloserServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int ApprovedJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.ApprovedJobCloserServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int PrintedJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti)
        {
            int recid = 0;

            recid = FinalAssemblyServiceCall.PrintedJobCloserServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobForJobHistory(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobForJobHistoryServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetJobAgingReport(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.GetJobAgingReportServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable ListOfCancelledJobForJobHistory(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfCancelledJobForJobHistoryServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable AllJobCount(string FromDate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.AllJobCountServiceMethod(FromDate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfDisapprovedJobRequests(string Fromdate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfDisapprovedJobRequestsServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobRequestForJobReport(string Fromdate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfJobRequestForJobReportServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfAssignToDesignerJobRequestForJobReport(string Fromdate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfAssignToDesignerJobRequestForJobReportServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfAssignToPrinterJobRequestForJobReport(string Fromdate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfAssignToPrinterJobRequestForJobReportServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfAssignToFabricatorJobRequestForJobReport(string Fromdate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfAssignToFabricatorJobRequestForJobReportServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }
        public DataTable ListOfOverdueJobs(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.ListOfOverdueJobsServiceMethod(dtsingle,"MSSQLSERVER");
            return recid;
        }

        public DataTable UserLoginDetails(string Fromdate)
        {
            DataTable recid = new DataTable();
            recid = FinalAssemblyServiceCall.UserLoginDetailsServiceMethod("MSSQLSERVER",Fromdate);
            return recid;
        }
    }
}