using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.PrinterQuotation
{
    public class PrinterQuotationDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdatePrinterQuotationDA(PrinterQuotation.PrinterQuotationInsert ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@PrinterId", ObjInput.PrinterId);
            objParameter[1] = new SqlParameter("@Quotation", ObjInput.Quotation);
            objParameter[2] = new SqlParameter("@EffDate", ObjInput.EffDate);
            objParameter[3] = new SqlParameter("@Createuid", ObjInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjInput.createlogno);
            objParameter[5] = new SqlParameter("@slno", ObjInput.slno);
            objParameter[6] = new SqlParameter("@branch", ObjInput.branch);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterQuotationAddUpdate", objParameter));
        }

        public DataTable AllPrinterQuotationDA()
        {
            return (objDataAccess.ReturnDataTable("PrinterQuotationList"));
        }

        public DataTable GetBranchForPrinterDA(int PrinterID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@PrinterID", PrinterID);
            return (objDataAccess.ReturnDataTableWithParameters("GetBranchForPrinter", objParameter));
        }

        public DataTable PrinterQuotationForPrinterDA(long PrinterID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@PrinterID", PrinterID);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterQuotationForPrinter", objParameter));
        }
        

        public DataTable SinglePrinterQuotationDA(PrinterQuotation.PrinterQuotationInsert ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjInput.slno);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterQuotationSelectParticular", objParameter));
        }
    }
}