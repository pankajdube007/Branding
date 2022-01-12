using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.FabricatorQuotation
{
    public class FabricatorQuotationDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateFabricatorQuotationDA(FabricatorQuotation.FabricatorQuotationInsert ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@FabricatorId", ObjInput.FabricatorId);
            objParameter[1] = new SqlParameter("@Quotation", ObjInput.Quotation);
            objParameter[2] = new SqlParameter("@EffDate", ObjInput.EffDate);
            objParameter[3] = new SqlParameter("@Createuid", ObjInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjInput.createlogno);
            objParameter[5] = new SqlParameter("@slno", ObjInput.slno);
            objParameter[6] = new SqlParameter("@branch", ObjInput.branch);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorQuotationAddUpdate", objParameter));
        }

        public DataTable AllFabricatorQuotationDA()
        {
            return (objDataAccess.ReturnDataTable("FabricatorQuotationList"));
        }

        public DataTable FabricatorQuotationForFabricatorDA(long FabricatorID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@FabricatorID", FabricatorID);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorQuotationForFabricator", objParameter));
        }

        

        public DataTable SingleFabricatorQuotationDA(FabricatorQuotation.FabricatorQuotationInsert ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjInput.slno);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorQuotationSelectParticular", objParameter));
        }

        public DataTable GetBranchForFabricatorDA(int FabricatorID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@FabricatorID", FabricatorID);
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchForFabricator", objParameter));
        }
    }
}