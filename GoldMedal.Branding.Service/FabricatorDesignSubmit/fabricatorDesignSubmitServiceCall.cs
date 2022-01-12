using GoldMedal.Branding.Data.FabricatorDesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Service.FabricatorDesignSubmit
{
    public class fabricatorDesignSubmitServiceCall
    {
        public static DataTable AllJobForFabricatorServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllAssignedJobForFabricatorDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetPendingJobsdetailsReportFabricatorServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetPendingJobsdetailsReportFabricatorDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllJobForFabricatorForPOServiceMethod(string Fromdate, string ToDate, int BranchIDs, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllAssignedJobForFabricatorPODA(Fromdate, ToDate, BranchIDs);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int UpdateRecordByFabricator(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
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

        public static DataTable GetDesignSubmitJobForFabricatorServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailSingleDesignSubmitByFabricator(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int SubmitDetailByFabricatorServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.SubmitDetailByFabricatorDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable ApprovedJobsForDCServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
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

        public static DataTable RejectedAndShortJobsForFabricatorReportServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.RejectedAndShortJobsForFabricatorReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable SingleApprovedJobForDCServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
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
        public static int IsFabricatorPoGeneratedServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.IsFabricatorPoGeneratedDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int JobSendByFabricatorServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.JobSendByFabricatorDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int UpdateSentQtybyFabricatorServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateSentQtybyFabricatorDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable ApprovedJobsForViewDCServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
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
        public static DataTable FabricatorDCReportBranchServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.FabricatorDCReportBranchDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable FabricatorAccountReportHOServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.FabricatorAccountReportHODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable FabricatorAccountReportAuditServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.FabricatorAccountReportAuditDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable FabricatorSupplierReportServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.FabricatorSupplierReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable FabricatorDCReportHOServiceMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorDesignSubmitDataAccess objselectall = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.FabricatorDCReportHODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int JobReceiveServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
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

        public static int UpdateFabricatorCreditDebitJobApprove1ServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateFabricatorCreditDebitJobApprove1DA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdateFabricatorCreditDebitJobApprove2ServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateFabricatorCreditDebitJobApprove2DA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int JobRejectServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorDesignSubmitDataAccess objinsert = new FabricatorDesignSubmitDataAccess();
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