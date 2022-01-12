using GoldMedal.Branding.Service.FabricatorDesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Core.FabricatorDesignSubmit
{
    public class FabricatorDesignSubmit : IFabricatorDesignSubmit
    {
        public DataTable GetAllJobForFabricator(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.AllJobForFabricatorServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPendingJobsdetailsReportFabricator(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.GetPendingJobsdetailsReportFabricatorServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }


        public DataTable GetAllJobForFabricatorForPO(string Fromdate, string ToDate, int BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.AllJobForFabricatorForPOServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }

        public int UpdateRecord(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.UpdateRecordByFabricator(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDesignSubmitJobForFabricatorSingle(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.GetDesignSubmitJobForFabricatorServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int DesignSubmitByFabritorInsertMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.SubmitDetailByFabricatorServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
       
        public DataTable GetApprovedJobsForDC(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.ApprovedJobsForDCServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable RejectedAndShortJobsForFabricatorReport(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.RejectedAndShortJobsForFabricatorReportServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSingleApprovedJobsForDC(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.SingleApprovedJobForDCServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int IsFabricatorPoGenerated(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.IsFabricatorPoGeneratedServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int JobSendByFabricatorMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.JobSendByFabricatorServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateSentQtybyFabricatorMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.UpdateSentQtybyFabricatorServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetApprovedJobsForViewDC(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.ApprovedJobsForViewDCServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorDCReportBranch(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.FabricatorDCReportBranchServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorAccountReportHO(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.FabricatorAccountReportHOServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorAccountReportAudit(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.FabricatorAccountReportAuditServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorSupplierReport(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.FabricatorSupplierReportServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorDCHOBranch(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = fabricatorDesignSubmitServiceCall.FabricatorDCReportHOServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }

        public int JobReceiveMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.JobReceiveServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateFabricatorCreditDebitJobApprove1(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.UpdateFabricatorCreditDebitJobApprove1ServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateFabricatorCreditDebitJobApprove2(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.UpdateFabricatorCreditDebitJobApprove2ServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int JobRejectMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti)
        {
            int recid = 0;

            recid = fabricatorDesignSubmitServiceCall.JobRejectServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
    }
}