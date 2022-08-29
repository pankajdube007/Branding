using GoldMedal.Branding.Data.AssigntoPrinter;
using System.Data;

namespace GoldMedal.Branding.Service.AssigntoPrinter
{
    public class AssignToPrinterServiceCall
    {
        public static DataTable DetailOfJobToPrinterForUserServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfJobToPrinter(dtsingle); 
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int GeneratePrinterPOInsertServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO dti, string DatabaseType)
        {
            int recid = 0;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GenaratePrinterPoInsert(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int CancelPrinterPoServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GenaratePrinterPO dti, string DatabaseType)
        {
            int recid = 0;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.CancelPrinterPoDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable GetGenaratePrinterPOServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetGenaratePrinterPODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetOtherBranchGenaratePrinterPOServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetOtherBranchGenaratePrinterPODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetGenaratePrinterForCancelListPOServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetGenaratePrinterForCancelListPODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetCancelledPrinterPOListPOServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetCancelledPrinterPOListDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetPrinterPOwithValueAuditReportServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetPrinterPOwithValueAuditReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetPrinterPOwithoutValueHoReportServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetPrinterPOwithoutValueHoReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetPrinterPOAgingReportServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.GetGenaratePrinterPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetPrinterPOAgingReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable DetailOfJobToReopenPrinterForUserServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfJobToReopenPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable DetailOfJobToReassignPrinterForUserServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfJobToReassignPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetApprovalDetailOfJobToPrinterForUserServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetApprovalDetailOfJobToPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable ApprovalDetailOfJobToPrinterForUserServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ApprovalDetailOfJobToPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DetailOfJobDoneByPrinterForApprovalUserServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfJobDoneByPrinterForApproval(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllApprovedJobsOfPrinterServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllApprovedJobsOfPrinterDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static DataTable JobSentByPrinterToReceiveServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.JobSentByPrinterToReceiveDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterCreditDebitJobsToApprove1ServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterCreditDebitJobsToApprove1DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterCreditDebitJobsToApprove2ServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objselectall = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterCreditDebitJobsToApprove2DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int ApproveDesignSubmitByPrinterServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti, string DatabaseType)
        {
            int recid = 0;
            AssignToPrinterDataAccess objinsert = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ApproveDesignSubmitByPrinter(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int AddAssignPrinterInsertServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti, string DatabaseType, out string PrinterEmailOut, out string PrinterMobileOut)
        {
            int recid = 0;
            string email = string.Empty;
            string mobile = string.Empty;
            AssignToPrinterDataAccess objinsert = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddAssignPrinter(dti, out string PrinterEmail, out string PrinterMobile);
                email = PrinterEmail;
                mobile = PrinterMobile;
            }
            else
            {
                recid = 0;
            }
            PrinterEmailOut = email;
            PrinterMobileOut = mobile;
            return recid;
        }


        public static int ReAssignPrinterInsertServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti, string DatabaseType, out string PrinterEmailOut, out string PrinterMobileOut)
        {
            int recid = 0;
            string email = string.Empty;
            string mobile = string.Empty;
            AssignToPrinterDataAccess objinsert = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ReAssignPrinter(dti, out string PrinterEmail, out string PrinterMobile);
                email = PrinterEmail;
                mobile = PrinterMobile;
            }
            else
            {
                recid = 0;
            }
            PrinterEmailOut = email;
            PrinterMobileOut = mobile;
            return recid;
        }

        public static int AssignedPrinterForJobDeleteServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti, string DatabaseType)
        {
            int recid = 0;
            AssignToPrinterDataAccess objdelete = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteAssignedPrinterForJobDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllAssignedPrinterForJobDAServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objdata = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllAssignedPrinterForJobDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllAssignedPrinterForJobDAServiceMethodUser(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objdata = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
               // recid = objdata.AllAssignedPrinterForJobDA();
                recid = objdata.AllAssignedPrinterForJobDAUser(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable PriReqnoServiceMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty alldata, string DatabaseType)
        {
            DataTable recid = null;
            AssignToPrinterDataAccess objdata = new AssignToPrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.PriReqno(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}