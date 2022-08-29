using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.BillUpload
{
    public class BillUploadDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateBillUploadDA(BillUploadModel.BillUploadInsert ObjBillUploadInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@BranchId", ObjBillUploadInput.BranchID);
            objParameter[1] = new SqlParameter("@TypeId", ObjBillUploadInput.Type);
            objParameter[2] = new SqlParameter("@TypeNameId", ObjBillUploadInput.TypeNameID);
            objParameter[3] = new SqlParameter("@DCNumber", ObjBillUploadInput.DCNumber);
            objParameter[4] = new SqlParameter("@FileNm", ObjBillUploadInput.FileNm);
            objParameter[5] = new SqlParameter("@Createuid", ObjBillUploadInput.createuid);
            objParameter[6] = new SqlParameter("@Createlogno", ObjBillUploadInput.createlogno);
            objParameter[7] = new SqlParameter("@pagename", ObjBillUploadInput.pagename);
            objParameter[8] = new SqlParameter("@slno", ObjBillUploadInput.slno);
            objParameter[9] = new SqlParameter("@editusercat", ObjBillUploadInput.editusercat);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BillUploadAddUpdate", objParameter));
        }

        public int DeleteBillUploadDA(BillUploadModel.BillUploadDelete ObjBillUploadInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjBillUploadInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjBillUploadInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjBillUploadInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BillUploadDelete", objParameter));
        }
        
        public DataTable AllBillUploadDA()
        {
            return (objDataAccess.ReturnDataTable("BillUploadList"));
        }
        
        public DataTable BillUploadTypeNameDA(int TypeID,int BranchId)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@TypeID", TypeID);
            objParameter[1] = new SqlParameter("@BranchId", BranchId);
            return (objDataAccess.ReturnDataTableWithParameters("GetTypeName", objParameter));
        }

        public DataTable BillUploadDcNumberDA(int TypeId, int TypeNameId)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@TypeId", TypeId);
            objParameter[1] = new SqlParameter("@TypeNameId", TypeNameId);
            return (objDataAccess.ReturnDataTableWithParameters("[GetDcNumberBillUpload]", objParameter));
        }
        public DataTable BillUploadDcNumberEditDA(int TypeId, int TypeNameId)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@TypeId", TypeId);
            objParameter[1] = new SqlParameter("@TypeNameId", TypeNameId);
            return (objDataAccess.ReturnDataTableWithParameters("[GetDcNumberBillUploadEdit]", objParameter));
        }
        public DataTable AllBranchDA()
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            return (objDataAccess.ReturnDataTable("BranchList"));
        }
        public DataTable SingleBillUploadDA(BillUploadModel.BillUploadInsert ObjBillUploadsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjBillUploadsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("BillUploadSelectParticular", objParameter));
        }

        public DataTable FilesDA(BillUploadModel.BillUploadInsert ObjBillUploadsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjBillUploadsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("GetBillUploadFiles", objParameter));
        }

        public DataTable AllBillUploadApprovalListDA(int UserID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Uid", UserID);
            return (objDataAccess.ReturnDataTableWithParameters("BillUploadApprovalList", objParameter));
        }

        public int ApproveBillUploadDA(BillUploadModel.BillUploadInsert ObjBillUploadInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjBillUploadInput.slno);
            objParameter[1] = new SqlParameter("@uid", ObjBillUploadInput.createuid);
            objParameter[2] = new SqlParameter("@branchid", ObjBillUploadInput.BranchID);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BillUploadApproval", objParameter));
        }
        public int DisApproveBillUploadDA(BillUploadModel.BillUploadInsert ObjBillUploadInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjBillUploadInput.slno);
            objParameter[1] = new SqlParameter("@uid", ObjBillUploadInput.createuid);
            objParameter[2] = new SqlParameter("@branchid", ObjBillUploadInput.BranchID);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BillUploadDisApproval", objParameter));
        }

        public DataTable AllBillUploadReportDA(string BranchIDs, string FromDate, string ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@FromDate", FromDate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("BillUploadReport", objParameter));
        }
    }
}