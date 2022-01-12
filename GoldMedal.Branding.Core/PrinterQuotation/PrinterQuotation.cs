using GoldMedal.Branding.Service.PrinterQuotation;
using System.Data;

namespace GoldMedal.Branding.Core.PrinterQuotation
{
    public class PrinterQuotation : IPrinterQuotation
    {
        public int PrinterQuotationInsertMethod(GoldMedal.Branding.Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dti)
        {
            int recid = 0;

            recid = PrinterQuotationServiceCall.PrinterQuotationInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterQuotationAll()
        {
            DataTable recid = new DataTable();
            recid = PrinterQuotationServiceCall.AllPrinterQuotationServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterQuotationForPrinter(long PrinterID)
        {
            DataTable recid = new DataTable();
            recid = PrinterQuotationServiceCall.PrinterQuotationForPrinterServiceMethod("MSSQLSERVER", PrinterID);
            return recid;
        }

        public DataTable GetPrinterQuotationSingle(GoldMedal.Branding.Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterQuotationServiceCall.SinglePrinterQuotationServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}