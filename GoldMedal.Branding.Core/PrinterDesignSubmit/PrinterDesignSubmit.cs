using GoldMedal.Branding.Service.PrinterDesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Core.PrinterDesignSubmit
{
    public class PrinterDesignSubmit : IPrinterDesignSubmit
    {
        public DataTable GetAllJobForPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.AllJobForPrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPendingJobReportForPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.GetPendingJobReportForPrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllJobForPrinterForPO(string Fromdate, string ToDate, int BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.AllJobForPrinterForPOServiceMethod(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }
        
        public DataTable GetAllSubmittedJobForPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.SubmittedJobForPrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetApprovedJobsForDC(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.ApprovedJobsForDCServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetRejectedAndShortJobsForPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.RejectedAndShortJobsForPrinterServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetApprovedJobsForViewDC(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.ApprovedJobsForViewDCServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterDCReportBranch(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.PrinterDCReportBranchServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterSupplierReport(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.PrinterSupplierReportServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterDCReportHO(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.PrinterDCReportHOServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterAccountReportHO(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.PrinterAccountReportHOServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetPrinterAccountReportAudit(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.PrinterAccountReportAuditServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }


        public DataTable GetSingleApprovedJobsForDC(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.SingleApprovedJobForDCServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int IsPrinterPoGenerated(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.IsPrinterPoGeneratedServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSingleForReceiveDC(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.SingleJobForReceiveServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetSinglePrinterCreditDebitJobForApprove1(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.SinglePrinterCreditDebitJobForApprove1ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSinglePrinterCreditDebitJobForApprove2(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.SinglePrinterCreditDebitJobForApprove2ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int UpdateRecord(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.UpdateRecordByPrinter(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDesignSubmitJobForPrinterSingle(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterDesignSubmitServiceCall.GetDesignSubmitJobForPrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int DesignSubmitByPrinterInsertMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.SubmitDetailByPrinterServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int JobSendByPrinterMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.JobSendByPrinterServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdateSentQtybyPrinterMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.UpdateSentQtybyPrinterServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int JobReceiveMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.JobReceiveServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int UpdatePrinterCreditDebitJobApprove1Method(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.UpdatePrinterCreditDebitJobApprove1ServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int UpdatePrinterCreditDebitJobApprove2Method(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.UpdatePrinterCreditDebitJobApprove2ServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int JobRejectMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti)
        {
            int recid = 0;

            recid = PrinterDesignSubmitServiceCall.JobRejectServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
    }
}