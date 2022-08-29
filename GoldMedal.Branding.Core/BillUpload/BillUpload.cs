using GoldMedal.Branding.Service.BillUpload;
using System.Data;

namespace GoldMedal.Branding.Core.BillUpload
{
    public class BillUpload : IBillUpload
    {
        public int BillUploadInsertMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti)
        {
            int recid = 0;
            recid = BillUploadServiceCall.BillUploadInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int BillUploadDeleteMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadDelete dti)
        {
            int recid = 0;

            recid = BillUploadServiceCall.BillUploadDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool BillUploadDelete(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetBillUploadAll()
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.AllBillUploadServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetBillUploadTypeName(int TypeId,int BranchId)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.BillUploadTypeNameServiceMethod("MSSQLSERVER", TypeId, BranchId);
            return recid;
        }

        public DataTable GetBillUploadDcNumber(int TypeId, int TypeNameId)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.BillUploadDcNumberServiceMethod("MSSQLSERVER", TypeId, TypeNameId);
            return recid;
        }

        public DataTable GetBillUploadDcNumberEdit(int TypeId, int TypeNameId)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.BillUploadDcNumberServiceMethodEdit("MSSQLSERVER", TypeId, TypeNameId);
            return recid;
        }

        public DataTable GetBranchAll()
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.AllBranchServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetBillUploadSingle(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.SingleBillUploadServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetBillUploadFiles(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.FilesServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetBillUploadApprovalList(int UserID)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.BillUploadApprovalListServiceMethod("MSSQLSERVER", UserID);
            return recid;
        }

        public int BillUploadApproveMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti)
        {
            int recid = 0;
            recid = BillUploadServiceCall.BillUploadApproveServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int BillUploadDisApproveMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti)
        {
            int recid = 0;
            recid = BillUploadServiceCall.BillUploadDisApproveServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetBillUploadReport(string BranchIDs, string FromDate, string ToDate)
        {
            DataTable recid = new DataTable();
            recid = BillUploadServiceCall.BillUploadReportServiceMethod("MSSQLSERVER", BranchIDs, FromDate, ToDate);
            return recid;
        }
    }
}