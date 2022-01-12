using System.Data;

namespace GoldMedal.Branding.Core.Printer
{
    public interface IPrinter
    {
        int PrinterInsertMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dti);

        int printermaterialSubmitupdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dti);

        bool PrinterDelete(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti);

        int PermanentDeletepr(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti);

        int Deleteprintermaterial(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti);

        DataTable GetPrinterAll();
        DataTable GetSendToList(int SendType, int LocationID);
        

        string GetAddressFromSendToID(long SendToID, int SendToType, int PartyType);

        DataTable GetPrinterSingle(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle);

        DataTable GetPrinterPricingAll();

        DataTable GetDetailOfPricingListForPrinter(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle);

        int PrinterPricingAddUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dti);

        DataTable GetPrinterByLocation(int LocationID);
    }
}