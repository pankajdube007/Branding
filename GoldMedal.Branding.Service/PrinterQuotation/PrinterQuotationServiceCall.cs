using GoldMedal.Branding.Data.PrinterQuotation;
using System.Data;

namespace GoldMedal.Branding.Service.PrinterQuotation
{
    public static class PrinterQuotationServiceCall
    {
        public static int PrinterQuotationInsertServiceMethod(GoldMedal.Branding.Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dti, string DatabaseType)
        {
            int recid = 0;
            PrinterQuotationDataAccess objinsert = new PrinterQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdatePrinterQuotationDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllPrinterQuotationServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            PrinterQuotationDataAccess objselectall = new PrinterQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPrinterQuotationDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable PrinterQuotationForPrinterServiceMethod(string DatabaseType, long PrinterID)
        {
            DataTable recid = null;
            PrinterQuotationDataAccess objselectall = new PrinterQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterQuotationForPrinterDA(PrinterID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static DataTable SinglePrinterQuotationServiceMethod(GoldMedal.Branding.Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterQuotationDataAccess objsingledesigntype = new PrinterQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SinglePrinterQuotationDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}