using GoldMedal.Branding.Data.PrinterDesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Service.PrinterDesignSubmit
{
    public class PrinterDesignSubmitServiceCall
    {
        public static DataTable AllJobForPrinterServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllAssignedJobForPrinterDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetPendingJobReportForPrinterServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetPendingJobReportForPrinterDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllJobForPrinterForPOServiceMethod(string Fromdate, string ToDate, int BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllAssignedJobForPrinterPODA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
       
        public static DataTable SubmittedJobForPrinterServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubmittedJobForPrinterDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ApprovedJobsForDCServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ApprovedJobsForDCDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable RejectedAndShortJobsForPrinterServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.RejectedAndShortJobsForPrinterDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable ApprovedJobsForViewDCServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ApprovedJobsForViewDCDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable PrinterDCReportBranchServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterDCReportBranchDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterSupplierReportServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterSupplierReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterDCReportHOServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterDCReportHODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterAccountReportHOServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterAccountReportHODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterAccountReportAuditServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterAccountReportAuditDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleApprovedJobForDCServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SingleApprovedJobForDCDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int IsPrinterPoGeneratedServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.IsPrinterPoGeneratedDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable SingleJobForReceiveServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SingleJobForReceiveDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable SinglePrinterCreditDebitJobForApprove1ServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SinglePrinterCreditDebitJobForApprove1DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable SinglePrinterCreditDebitJobForApprove2ServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SinglePrinterCreditDebitJobForApprove2DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static int UpdateRecordByPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateRecord(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable GetDesignSubmitJobForPrinterServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDesignSubmitDataAccess objselectall = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailSingleDesignSubmitByPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int SubmitDetailByPrinterServiceMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.SubmitDetailByPrinterDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int JobSendByPrinterServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobSendByPrinterDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdateSentQtybyPrinterServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateSentQtybyPrinterDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int JobReceiveServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobReceiveDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdatePrinterCreditDebitJobApprove1ServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdatePrinterCreditDebitJobApprove1DA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int UpdatePrinterCreditDebitJobApprove2ServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdatePrinterCreditDebitJobApprove2DA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int JobRejectServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDesignSubmitDataAccess objinsert = new PrinterDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobRejectDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
    }
}