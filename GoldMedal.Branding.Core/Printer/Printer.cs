using GoldMedal.Branding.Service.Printer;
using System.Data;

namespace GoldMedal.Branding.Core.Printer
{
    public class Printer : IPrinter
    {
        public int PrinterInsertMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.PrinterInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int printermaterialSubmitupdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.printermaterialSubmitupdate(dti, "MSSQLSERVER");
            return recid;
        }

        public int PrinterPricingAddUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dti) 
        {
            int recid = 0;

            recid = PrinterServiceCall.PrinterPricingAddUpdate(dti, "MSSQLSERVER");
            return recid;
        }

        public int PrinterFabricatorMappingAddUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterFabricatorMappingInsert dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.PrinterFabricatorMappingAddUpdate(dti, "MSSQLSERVER");
            return recid;
        }

        public int PrinterPricingUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.PrinterPricingAUpdate(dti, "MSSQLSERVER");
            return recid;
        }

        public int PrinterDeleteMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.PrinterDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int PermanentDeletepr(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.PermanentDeletepr(dti, "MSSQLSERVER");
            return recid;
        }

        public int Deleteprintermaterial(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti)
        {
            int recid = 0;

            recid = PrinterServiceCall.Deleteprintermaterial(dti, "MSSQLSERVER");
            return recid;
        }

        public bool PrinterDelete(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetPrinterAll() 
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.AllPrinterServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterForMappingAll()
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.AllPrinterServiceForMappingMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterByLocation(int LocationID)
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.PrinterByLocationServiceMethod("MSSQLSERVER", LocationID);
            return recid;
        }

        public DataTable GetPrinterPricingAll() 
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.AllPrinterPricingServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterFabricatorMappingAll()
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.AllPrinterFabricatorMappingServiceMethod("MSSQLSERVER");
            return recid;
        }
        public DataTable GetSendToList(int SendType, int LocationID)
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.SendToListServiceMethod("MSSQLSERVER", SendType, LocationID);
            return recid;
        }
        

        public string GetAddressFromSendToID(long SendToID, int SendToType, int PartyType)
        {
            string recid = "";

            recid = PrinterServiceCall.GetAddressServiceMethod(SendToID, SendToType, PartyType, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterSingle(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.SinglePrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPrinterPriceSingle(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.SinglePrinterPriceServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfMaterialListForPrinter(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.GetDetailOfMaterialListForPrinter(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfPricingListForPrinter(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.GetDetailOfPricingListForPrinter(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public string PrinterLoginMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterLogin dti)
        {
            string recid = "0";

            recid = PrinterServiceCall.PrinterLoginServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPricingComparison()
        {
            DataTable recid = new DataTable();
            recid = PrinterServiceCall.GetPrinterPriceComparisonServiceMethod("MSSQLSERVER");
            return recid;
        }
    }
}