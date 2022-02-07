using GoldMedal.Branding.Data.AssignFabricator;
using System.Data;

namespace GoldMedal.Branding.Service.AssignToFabricator
{
    public class AssignToFabricatorServiceCall
    {
        public static DataTable ListOfJobForAssignToFabricatorServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForAssignToFabricator(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetGenarateFabricatorPOServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetGenarateFabricatorPODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetGenarateFabricatorPOForCancelListServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetGenarateFabricatorPOForCancelListDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetFabricatorPOwithValueAuditServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetFabricatorPOwithValueAuditDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetFabricatorPOwithoutValueHOServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetFabricatorPOwithoutValueHODA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetFabricatorPOAgingReportServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetFabricatorPOAgingReportDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ListOfJobForAssignToFabricatorSendByPrinterServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ListOfJobForAssignToFabricatorSendByPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int AssignFabricatorInsertServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti, string DatabaseType)
        {
            int recid = 0;
            AssignToFabricatorDataAccess objinsert = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AssignFabricatorInsert(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int GenerateFabricatorPOInsertServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO dti, string DatabaseType)
        {
            int recid = 0;
            AssignToFabricatorDataAccess objinsert = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.GenarateFabricatorPoInsert(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int CancelFabricatorPoServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO dti, string DatabaseType)
        {
            int recid = 0;
            AssignToFabricatorDataAccess objinsert = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.CancelFabricatorPoDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int AssignedfabricatorDeleteServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti, string DatabaseType)
        {
            int recid = 0;
            AssignToFabricatorDataAccess objdelete = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.AssignedfabricatorDelete(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllAssignedfabricatorServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objdata = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllAssignedfabricator();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllAssignedfabricatorServiceMethodUser(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objdata = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
               // recid = objdata.AllAssignedfabricator();
                recid = objdata.AllAssignedfabricatorUser(dti);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DetailOfJobDoneByFabricatorForApprovalUserServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfJobDoneByFabricatorForApproval(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetAllApprovedFabricatorJobsServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetAllApprovedFabricatorJobsDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static int ApproveDesignSubmitByFabricatorServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti, string DatabaseType)
        {
            int recid = 0;
            AssignToFabricatorDataAccess objinsert = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ApproveDesignSubmitByFabricator(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static DataTable JobSentByFabricatorToReceiveServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.JobSentByFabricatorToReceiveDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

         public static DataTable GetFabricatorCreditDebitJobsToApprove1ServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetFabricatorCreditDebitJobsToApprove1DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetFabricatorCreditDebitJobsToApprove2ServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetFabricatorCreditDebitJobsToApprove2DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleJobForReceiveServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
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


        public static DataTable SingleFabricatorCreditDebitJobForApprove1ServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SingleFabricatorCreditDebitJobForApprove1DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable SingleFabricatorCreditDebitJobForApprove2ServiceMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            AssignToFabricatorDataAccess objselectall = new AssignToFabricatorDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SingleFabricatorCreditDebitJobForApprove2DA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}