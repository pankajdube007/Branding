using GoldMedal.Branding.Data.BillUpload;
using System.Data;

namespace GoldMedal.Branding.Service.BillUpload
{
    public static class BillUploadServiceCall
    {
        public static int BillUploadInsertServiceMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti, string DatabaseType)
        {
            int recid = 0;
            BillUploadDataAccess objinsert = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateBillUploadDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int BillUploadDeleteServiceMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadDelete dti, string DatabaseType)
        {
            int recid = 0;
            BillUploadDataAccess objdelete = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteBillUploadDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllBillUploadServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllBillUploadDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable BillUploadTypeNameServiceMethod(string DatabaseType, int TypeID,int BranchId)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.BillUploadTypeNameDA(TypeID, BranchId);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable BillUploadDcNumberServiceMethod(string DatabaseType, int TypeId, int TypeNameId)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.BillUploadDcNumberDA(TypeId, TypeNameId);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable BillUploadDcNumberServiceMethodEdit(string DatabaseType, int TypeId, int TypeNameId)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.BillUploadDcNumberEditDA(TypeId, TypeNameId);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllBranchServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllBranchDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleBillUploadServiceMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            BillUploadDataAccess objsingledesigntype = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SingleBillUploadDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable FilesServiceMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            BillUploadDataAccess objsingledesigntype = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.FilesDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable BillUploadApprovalListServiceMethod(string DatabaseType, int UserID)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllBillUploadApprovalListDA(UserID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable BillUploadApprovalServiceMethod(string DatabaseType, int UserID,int BranchId)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.BillUploadTypeNameDA(UserID, BranchId);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static int BillUploadApproveServiceMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti, string DatabaseType)
        {
            int recid = 0;
            BillUploadDataAccess objinsert = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ApproveBillUploadDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        public static int BillUploadDisApproveServiceMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti, string DatabaseType)
        {
            int recid = 0;
            BillUploadDataAccess objinsert = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.DisApproveBillUploadDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable BillUploadReportServiceMethod(string DatabaseType, string BranchIDs, string FromDate, string ToDate)
        {
            DataTable recid = null;
            BillUploadDataAccess objselectall = new BillUploadDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllBillUploadReportDA(BranchIDs, FromDate, ToDate);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}