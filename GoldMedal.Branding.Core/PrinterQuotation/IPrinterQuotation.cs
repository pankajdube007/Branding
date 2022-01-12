using System.Data;

namespace GoldMedal.Branding.Core.PrinterQuotation
{
    public interface IPrinterQuotation
    {
        int PrinterQuotationInsertMethod(GoldMedal.Branding.Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dti);

        DataTable GetPrinterQuotationSingle(GoldMedal.Branding.Data.PrinterQuotation.PrinterQuotation.PrinterQuotationInsert dtsingle);

        DataTable GetPrinterQuotationAll();

        DataTable GetPrinterQuotationForPrinter(long PrinterID);
    }
}