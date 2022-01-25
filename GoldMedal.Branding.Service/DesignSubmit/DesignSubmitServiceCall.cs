using GoldMedal.Branding.Data.DesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Service.DesignSubmit
{
    public class DesignSubmitServiceCall
    {
        public static DataTable AllAssignedJobForUserServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllAssignedJobForUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleAssignedJobForUserServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.Detailofassignedjobchild(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable PrinterWorkStatus(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterWorkStatus(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable JobDetailsForParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.JobDetailsForParty(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDesignSubmitByUserServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignSubmitByUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int AddDesignSubmitTracknsertServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddDesignSubmitTrackDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllDesignSubmitByUserforapprovelServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignSubmitByUserforapprovelDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDesignSubmitByUserforWallsizejobsapprovelServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubmitedDesignWallsizeJobsApprovedByUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubmitedDesignApprovedByUserlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubmitedDesignApprovedByUserDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubmitedDesignDisApprovedByPartylServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubmitedDesignDisapprovedByPartyDA(dtsingle);
            } 
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDesignDisApprovedByPartylServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignDisapprovedByPartyDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllDesignApprovedByPartylServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignApprovedByPartyDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetPartyApprovalPendingJobsServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetPartyApprovalPendingJobsDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable AllSubmitedDesignApprovedByMgmlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        { 
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubmitedDesignApprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetDesignerwiseSubmitedDesignApprovedByMgmServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetDesignerwiseSubmitedDesignApprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetBranchwiseSubmitedDesignApprovedByMgmServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetBranchwiseSubmitedDesignApprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubmitedDesignDisapprovedByMgmlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllSubmitedDesignDisapprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetDesignerwiseSubmitedDesignDisapprovedByMgmlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetDesignerwiseSubmitedDesignDisapprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetBranchwiseSubmitedDesignDisapprovedByMgmlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetBranchwiseSubmitedDesignDisapprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDesignApprovedByMgmlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignApprovedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllDesignAcceptedByMgmlServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignAcceptedByMgmDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }




        public static DataTable AllDesignSubmitByUserforapprovelmanagementServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllDesignSubmitByUserforapprovelmanagementDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DetailOfDesignSubmitByUserServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailSingleDesignSubmitByUser(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DetailOfDesignSubmitWallSizeByUserServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailSingleDesignSubmitWallSizeJobsByUser(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DetailOfItemListForDesignSubmitServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfItemListForDesignSubmit(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable DetailOfSizeListForDesignSubmitServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.DetailOfSizeListForDesignSubmit(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllItemDivisonServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllItemDivisionDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllItemTypeServiceMethod(string DatabaseType, int DivisionID)
        {
            DataTable recid = null;
            DesignSubmitDataAccess objselectall = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllItemTypeDA(DivisionID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int DesignSubmitInsertServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddDesignSubmitDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DesignSubmitUpdateServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateDesignSubmitDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static int UpdateReopenSendForPrintServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateReopenSendForPrintDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int ItemDesignSubmitInsertServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddItemDesignSubmitDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int SizeDesignSubmitInsertServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddSizeDesignSubmitDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdateEmail(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateEmail(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdateFinalApr(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateFinalApr(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UpdateEmailbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateEmailbymanagement(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int LiveProductjobsReopenbymanagementService(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.LiveProductjobsReopen(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int LiveProductjobsAcceptbymanagementService(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.LiveProductjobsAccept(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int UpdateDisapprovalbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateDisapprovalbymanagement(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int ApproveByParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ApproveByParty(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int PermanentDeleteDesignSubmitServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PermanentDeleteDesignSubmit(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DeleteItemForDesignSubmitServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.DeleteItemForDesignSubmit(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DeleteSizeForDesignSubmitServiceMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti, string DatabaseType)
        {
            int recid = 0;
            DesignSubmitDataAccess objinsert = new DesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.DeleteSizeForDesignSubmit(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
    }
}