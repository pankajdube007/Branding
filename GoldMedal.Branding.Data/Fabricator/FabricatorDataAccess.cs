using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.Fabricator
{
    public class FabricatorDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateFabricatorDA(FabricatorModel.FabricatorInsert ObjFabricatorInput)
        {
            SqlParameter[] objParameter = new SqlParameter[20];
            // objParameter[0] = new SqlParameter("@Code", ObjFabricatorInput.Code);
            objParameter[0] = new SqlParameter("@Name", ObjFabricatorInput.Name);
            objParameter[1] = new SqlParameter("@area", ObjFabricatorInput.area);
            objParameter[2] = new SqlParameter("@emailid", ObjFabricatorInput.emailid);
            objParameter[3] = new SqlParameter("@contact", ObjFabricatorInput.contactno);
            objParameter[4] = new SqlParameter("@mobile", ObjFabricatorInput.mobile);
            objParameter[5] = new SqlParameter("@Createuid", ObjFabricatorInput.createuid);
            objParameter[6] = new SqlParameter("@Createlogno", ObjFabricatorInput.createlogno);
            objParameter[7] = new SqlParameter("@pagename", ObjFabricatorInput.pagename);
            objParameter[8] = new SqlParameter("@slno", ObjFabricatorInput.slno);
            objParameter[9] = new SqlParameter("@editusercat", ObjFabricatorInput.editusercat);
            objParameter[10] = new SqlParameter("@branch", ObjFabricatorInput.branch);
            objParameter[11] = new SqlParameter("@usernm", ObjFabricatorInput.usernm);
            objParameter[12] = new SqlParameter("@password", ObjFabricatorInput.password);
            objParameter[13] = new SqlParameter("@SupplierID", ObjFabricatorInput.SupplierID);
            objParameter[14] = new SqlParameter("@Address", ObjFabricatorInput.Address);
            objParameter[15] = new SqlParameter("@Pincode", ObjFabricatorInput.Pincode);
            objParameter[16] = new SqlParameter("@Gstno", ObjFabricatorInput.Gstno);
            objParameter[17] = new SqlParameter("@ContactPerson", ObjFabricatorInput.ContactPerson);
            objParameter[18] = new SqlParameter("@Status", ObjFabricatorInput.Status);
            objParameter[19] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[19].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorAddUpdate", objParameter));
        }

        public int ModeofDispatchAddUpdateDA(FabricatorModel.FabricatorInsert ObjFabricatorInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];

            objParameter[0] = new SqlParameter("@Slno", ObjFabricatorInput.slno);
            objParameter[1] = new SqlParameter("@Name", ObjFabricatorInput.Name);
            objParameter[2] = new SqlParameter("@ShortName", ObjFabricatorInput.ShortName);
            objParameter[3] = new SqlParameter("@MobileNo", ObjFabricatorInput.mobile);
            objParameter[4] = new SqlParameter("@ModeofDispatch", ObjFabricatorInput.Modeofdispatch);
            objParameter[5] = new SqlParameter("@Status", ObjFabricatorInput.Status);
            objParameter[6] = new SqlParameter("@Createuid", ObjFabricatorInput.createuid);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ModeofDispatchAddUpdate", objParameter));
        }

        public int DeleteFabricatorDA(FabricatorModel.FabricatorDelete ObjFabricatorInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjFabricatorInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjFabricatorInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjFabricatorInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorDelete", objParameter));
        }
        public int DeleteModeofDispatchDA(FabricatorModel.FabricatorDelete ObjFabricatorInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@slno", ObjFabricatorInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjFabricatorInput.Createuid);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteModeofDispatch", objParameter));
        }

        public DataTable AllFabricatorDA()
        {
            return (objDataAccess.ReturnDataTable("FabricatorList"));
        }
        public DataTable GetListForModeofDispatchDA()
        {
            return (objDataAccess.ReturnDataTable("GetListForModeofDispatch"));
        }

        public DataTable AllFabricatorForMappingDA()
        {
            return (objDataAccess.ReturnDataTable("GetFabricatorForMapping"));
        }

        public DataTable FabricatorByLocationDA(int LocationID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@LocationID", LocationID);
            return (objDataAccess.ReturnDataTableWithParameters("GetFabricatorByLocation", objParameter));
        }
        

        public DataTable AllAreaDA()
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            return (objDataAccess.ReturnDataTable("AreaList"));
        }
        public DataTable AllBranchDA()
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            return (objDataAccess.ReturnDataTable("BranchList"));



        }
        public DataTable SingleFabricatorDA(FabricatorModel.FabricatorInsert ObjFabricatorsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjFabricatorsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorSelectParticular", objParameter));
        }
        public DataTable GetSingleModeofDispatchDA(FabricatorModel.FabricatorInsert ObjFabricatorsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjFabricatorsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("GetSingleModeofDispatch", objParameter));
        }

        public DataTable SingleFabricatorPriceDA(FabricatorModel.FabricatorPricingInsert ObjFabricatorsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjFabricatorsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorSelectPriceParticular", objParameter));
        }
        public DataTable GetFabricatorPriceComparisonDA()
        {
           
            return (objDataAccess.ReturnDataTable("GetPriceComparisonReport"));
        }


        public DataTable AreaDetailDA(FabricatorModel.FabricatorInsert ObjFabricatorsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@area", ObjFabricatorsingle.area);
            return (objDataAccess.ReturnDataTableWithParameters("Areadeatil", objParameter));
        }

        public int FabricatormaterialSubmitupdate(FabricatorModel.FabricatorInsert ObjPrinterInput)
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
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("materialfabricatorAdd", objParameter));
        }

        public int PermanentDeletefab(FabricatorModel.FabricatorDelete ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeletehardFabricator", objParameter));
        }

        public int Deletefabricatormaterial(FabricatorModel.FabricatorDelete ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("Deletefabricatormaterial", objParameter));
        }

        public DataTable GetDetailOfMaterialListForFabricator(FabricatorModel.FabricatorInsert ObjPrintersingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjPrintersingle.slno);
            objParameter[1] = new SqlParameter("@BranchID", ObjPrintersingle.BranchID);
            return (objDataAccess.ReturnDataTableWithParameters("getmateriallistforFabricatornew", objParameter));
        }

        public string FabricatorLogin(FabricatorModel.FabricatorLogin FabricatorLogin)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@usernm", FabricatorLogin.usernm);
            objParameter[1] = new SqlParameter("@password", FabricatorLogin.password);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.VarChar, 200);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorLogin", objParameter));
        }

        public DataTable AllFabricatorPricingDA()
        {
            return (objDataAccess.ReturnDataTable("FabricatorPricingList"));
        }


        public DataTable PricingListForFabricatorDA(FabricatorModel.FabricatorInsert ObjFabricatorsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjFabricatorsingle.slno);
            objParameter[1] = new SqlParameter("@BranchID", ObjFabricatorsingle.BranchID);
            return (objDataAccess.ReturnDataTableWithParameters("getpricinglistforfabricator", objParameter));
        }

        public int FabricatorPricingAddUpdateDA(FabricatorModel.FabricatorPricingInsert ObjPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@slno", ObjPrinterInput.slno);
            objParameter[1] = new SqlParameter("@FabricatorID", ObjPrinterInput.FabricatorID);
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
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorPricingAddUpdate", objParameter));
        }

        public int DeleteFabricatorPriceDA(long slno, long logno, int userid)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", slno);
            objParameter[1] = new SqlParameter("@Createlogno", logno);
            objParameter[2] = new SqlParameter("@Createuid", userid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorPriceDelete", objParameter));
        }
        public DataTable SendToListDA(int SendToType, int LocationID)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@SendToType", SendToType);
            objParameter[1] = new SqlParameter("@LocationID", LocationID);

            return (objDataAccess.ReturnDataTableWithParameters("GetSendToList", objParameter));
        }
        public string GetAddressFromSendToIDDA(long SendToID, int SendToType, int PartyType)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@SendToID", SendToID);
            objParameter[1] = new SqlParameter("@SendToType", SendToType);
            objParameter[2] = new SqlParameter("@PartyType", PartyType);

            return Convert.ToString(objDataAccess.ExecuteScalarWithParameters("GetAddressFromSendToID", objParameter));
        }
        //public DataTable GetDetailOfMaterialListForFabricator(FabricatorModel.FabricatorInsert ObjPrintersingle)
        //{
        //    SqlParameter[] objParameter = new SqlParameter[1];
        //    objParameter[0] = new SqlParameter("@slno", ObjPrintersingle.slno);
        //    return (objDataAccess.ReturnDataTableWithParameters("getmateriallistforFabricator", objParameter));
        //}
    }
}