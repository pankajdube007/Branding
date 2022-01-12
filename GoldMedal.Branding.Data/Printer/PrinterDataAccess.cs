using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.Printer
{
    public class PrinterDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdatePrinterDA(PrinterModel.PrinterInsert ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[20];
            // objParameter[0] = new SqlParameter("@Code", ObjPrinterInput.Code);
            objParameter[0] = new SqlParameter("@Name", ObjPrinterInput.Name);
            objParameter[1] = new SqlParameter("@area", ObjPrinterInput.area);
            objParameter[2] = new SqlParameter("@emailid", ObjPrinterInput.emailid);
            objParameter[3] = new SqlParameter("@contact", ObjPrinterInput.contactno);
            objParameter[4] = new SqlParameter("@mobile", ObjPrinterInput.mobile);
            objParameter[5] = new SqlParameter("@Createuid", ObjPrinterInput.createuid);
            objParameter[6] = new SqlParameter("@Createlogno", ObjPrinterInput.createlogno);
            objParameter[7] = new SqlParameter("@pagename", ObjPrinterInput.pagename);
            objParameter[8] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[9] = new SqlParameter("@editusercat", ObjPrinterInput.editusercat);
            objParameter[10] = new SqlParameter("@branch", ObjPrinterInput.branch);
            objParameter[11] = new SqlParameter("@usernm", ObjPrinterInput.usernm);
            objParameter[12] = new SqlParameter("@password", ObjPrinterInput.password);
            objParameter[13] = new SqlParameter("@SupplierID", ObjPrinterInput.SupplierID);
            objParameter[14] = new SqlParameter("@Address", ObjPrinterInput.Address);
            objParameter[15] = new SqlParameter("@Pincode", ObjPrinterInput.Pincode);
            objParameter[16] = new SqlParameter("@Gstno", ObjPrinterInput.Gstno);
            objParameter[17] = new SqlParameter("@ContactPerson", ObjPrinterInput.ContactPerson);
            objParameter[18] = new SqlParameter("@Status", ObjPrinterInput.Status);
            objParameter[19] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[19].Direction = ParameterDirection.Output; 
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterAddUpdate", objParameter));
        }

        public int printermaterialSubmitupdate(PrinterModel.PrinterInsert ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@materialid", ObjPrinterInput.materialid);
            objParameter[2] = new SqlParameter("@RatePerJob", ObjPrinterInput.RatePerJOb);
            objParameter[3] = new SqlParameter("@unitid", ObjPrinterInput.unitid);
            objParameter[4] = new SqlParameter("@refid", ObjPrinterInput.refid);
            objParameter[5] = new SqlParameter("@childslno", ObjPrinterInput.childslno);
            objParameter[6] = new SqlParameter("@Createlogno", ObjPrinterInput.createlogno);
            objParameter[7] = new SqlParameter("@pagename", ObjPrinterInput.pagename);
            objParameter[8] = new SqlParameter("@Createuid", ObjPrinterInput.createuid);
            objParameter[9] = new SqlParameter("@editusercat", ObjPrinterInput.editusercat);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("materialprinterAdd", objParameter));
        }
        public DataTable GetPrinterPriceComparisonDA()
        {

            return (objDataAccess.ReturnDataTable("GetPriceComparisonReportForPrinter"));
        }
        public int PrinterPricingAddUpdate(PrinterModel.PrinterPricingInsert ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@PrinterID", ObjPrinterInput.PrinterID);
            objParameter[2] = new SqlParameter("@MaterialID", ObjPrinterInput.MaterialID);
            objParameter[3] = new SqlParameter("@UnitID", ObjPrinterInput.UnitID);
            objParameter[4] = new SqlParameter("@Rate", ObjPrinterInput.Rate);
            objParameter[5] = new SqlParameter("@EffectiveFromDate", ObjPrinterInput.EffectiveFromDate);
            objParameter[6] = new SqlParameter("@Createuid", ObjPrinterInput.Createuid);
            objParameter[7] = new SqlParameter("@Createlogno", ObjPrinterInput.Createlogno);
            objParameter[8] = new SqlParameter("@pagename", ObjPrinterInput.pagename);
            objParameter[9] = new SqlParameter("@BranchID", ObjPrinterInput.BranchID);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterPricingAddUpdate", objParameter));
        }


        public int PrinterFabricatorMappingAddUpdate(PrinterModel.PrinterFabricatorMappingInsert ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            
            objParameter[0] = new SqlParameter("@PrinterId", ObjPrinterInput.PrinterId);
            objParameter[1] = new SqlParameter("@FabricatorId", ObjPrinterInput.FabricatorId);
            objParameter[2] = new SqlParameter("@createuid", ObjPrinterInput.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterFabricatorMappingInsert", objParameter));
        }

        public int PrinterPricingUpdate(PrinterModel.PrinterPricingInsert ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@UnitID", ObjPrinterInput.UnitID);
            objParameter[2] = new SqlParameter("@Rate", ObjPrinterInput.Rate);
            objParameter[3] = new SqlParameter("@EffectiveFromDate", ObjPrinterInput.EffectiveFromDate);
            objParameter[4] = new SqlParameter("@Createuid", ObjPrinterInput.Createuid);
            objParameter[5] = new SqlParameter("@Createlogno", ObjPrinterInput.Createlogno);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterPricingUpdate", objParameter));
        }

        public int DeletePrinterPriceDA(long slno,long logno,int userid)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", slno);
            objParameter[1] = new SqlParameter("@Createlogno", logno);
            objParameter[2] = new SqlParameter("@Createuid", userid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterPriceDelete", objParameter));
        }

        public int DeletePrinterFabricatorMappingDA(long slno, int userid)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@slno", slno);
            objParameter[1] = new SqlParameter("@Createuid", userid);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterFabricatorMappingDelete", objParameter));
        }

        public string GetAddressFromSendToIDDA(long SendToID, int SendToType, int PartyType)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@SendToID", SendToID);
            objParameter[1] = new SqlParameter("@SendToType", SendToType);
            objParameter[2] = new SqlParameter("@PartyType", PartyType);

            return Convert.ToString(objDataAccess.ExecuteScalarWithParameters("GetAddressFromSendToID", objParameter));
        }

        public int DeletePrinterDA(PrinterModel.PrinterDelete ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjPrinterInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjPrinterInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterDelete", objParameter));
        }

        public int Deleteprintermaterial(PrinterModel.PrinterDelete ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("Deleteprintermaterial", objParameter));
        }

        public int PermanentDeletepr(PrinterModel.PrinterDelete ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeletehardPrinter", objParameter));
        }

        public DataTable AllPrinterDA()
        {
            return (objDataAccess.ReturnDataTable("PrinterList"));
        }

        public DataTable AllPrinterForMappingDA()
        {
            return (objDataAccess.ReturnDataTable("GetPrinterForMapping"));
        }


        public DataTable PrinterByLocationDA(int LocationID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@LocationID", LocationID);
            return (objDataAccess.ReturnDataTableWithParameters("GetPrinterByLocation", objParameter));
        }

        public DataTable AllPrinterPricingDA()
        {
            return (objDataAccess.ReturnDataTable("PrinterPricingList"));
        }

        public DataTable AllPrinterFabricatorMappingDA()
        {
            return (objDataAccess.ReturnDataTable("PrinterFabricatorMappingList"));
        }


        public DataTable SendToListDA(int SendToType, int LocationID)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@SendToType", SendToType);
            objParameter[1] = new SqlParameter("@LocationID", LocationID);
           
            return (objDataAccess.ReturnDataTableWithParameters("GetSendToList", objParameter));
        }
       

        public DataTable SinglePrinterDA(PrinterModel.PrinterInsert ObjPrintersingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjPrintersingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterSelectParticular", objParameter));
        }

        public DataTable SinglePrinterPriceDA(PrinterModel.PrinterPricingInsert ObjPrintersingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjPrintersingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterSelectPriceParticular", objParameter));
        }

        public DataTable GetDetailOfMaterialListForPrinter(PrinterModel.PrinterInsert ObjPrintersingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrintersingle.slno);
            objParameter[1] = new SqlParameter("@BranchID", ObjPrintersingle.BranchID);
            return (objDataAccess.ReturnDataTableWithParameters("getmateriallistforprinternew", objParameter));
        }

        public DataTable GetDetailOfPricingListForPrinter(PrinterModel.PrinterInsert ObjPrintersingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrintersingle.slno);
            objParameter[1] = new SqlParameter("@BranchID", ObjPrintersingle.BranchID);
            return (objDataAccess.ReturnDataTableWithParameters("getpricinglistforprinter", objParameter));
        }
        

        public string PrinterLogin(PrinterModel.PrinterLogin PrinterLogin)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@usernm", PrinterLogin.usernm);
            objParameter[1] = new SqlParameter("@password", PrinterLogin.password);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.VarChar, 200);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterLogin", objParameter));
        }

        public DataTable GetUserDetails(int UserID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserID", UserID);
            return objDataAccess.ReturnDataTableWithParameters("GetUserDetailsByUserID", objParameter);
        }

        public DataTable AllSupplierListDA()
        {
            //  return (objDataAccess.ReturnDataTable("GetSupplierList"));

            return (objDataAccess.ReturnDataTable("GetSupplierListPrinter"));
        }
        public DataTable AllSupplierListFabricatorDA()
        {
            
            return (objDataAccess.ReturnDataTable("GetSupplierListFabricator"));
        }

        public DataTable GetSupplierDetails(int SupplierID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@SupplierID", SupplierID);
            return (objDataAccess.ReturnDataTableWithParameters("GetSupplierDetails", objParameter));
        }

        public DataTable GetSupplierDetailsFab(int SupplierID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@SupplierID", SupplierID);
            return (objDataAccess.ReturnDataTableWithParameters("GetSupplierDetailsFab", objParameter));
        }
    }
}