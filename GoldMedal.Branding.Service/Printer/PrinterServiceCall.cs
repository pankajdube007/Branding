using GoldMedal.Branding.Data.Printer;
using System.Data;

namespace GoldMedal.Branding.Service.Printer
{
    public static class PrinterServiceCall
    {
        public static int PrinterInsertServiceMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdatePrinterDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int printermaterialSubmitupdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.printermaterialSubmitupdate(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int PrinterPricingAddUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dti, string DatabaseType)
        { 
            int recid = 0;
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PrinterPricingAddUpdate(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static int PrinterFabricatorMappingAddUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterFabricatorMappingInsert dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PrinterFabricatorMappingAddUpdate(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int PrinterPricingAUpdate(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PrinterPricingUpdate(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        

        public static string GetAddressServiceMethod(long SendToID, int SendToType, int PartyType, string DatabaseType)
        {
            string recid = "";
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.GetAddressFromSendToIDDA(SendToID, SendToType, PartyType);
            }
            else
            {
                recid = "";
            }
            return recid;
        }

        public static int PrinterDeleteServiceMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objdelete = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeletePrinterDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int PermanentDeletepr(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objdelete = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.PermanentDeletepr(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int Deleteprintermaterial(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterDelete dti, string DatabaseType)
        {
            int recid = 0;
            PrinterDataAccess objdelete = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.Deleteprintermaterial(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllPrinterServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPrinterDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllPrinterServiceForMappingMethod(string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPrinterForMappingDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable PrinterByLocationServiceMethod(string DatabaseType, int LocationID)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.PrinterByLocationDA(LocationID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static DataTable AllPrinterPricingServiceMethod(string DatabaseType) 
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPrinterPricingDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllPrinterFabricatorMappingServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPrinterFabricatorMappingDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable SendToListServiceMethod(string DatabaseType, int SendToType, int LocationID)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.SendToListDA(SendToType, LocationID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        

        public static DataTable SinglePrinterServiceMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objsingledesigntype = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SinglePrinterDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SinglePrinterPriceServiceMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterPricingInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objsingledesigntype = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SinglePrinterPriceDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static DataTable GetDetailOfMaterialListForPrinter(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetDetailOfMaterialListForPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable GetDetailOfPricingListForPrinter(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objselectall = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.GetDetailOfPricingListForPrinter(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        

        public static string PrinterLoginServiceMethod(GoldMedal.Branding.Data.Printer.PrinterModel.PrinterLogin plogin, string DatabaseType)
        {
            string recid = "0";
            PrinterDataAccess objinsert = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.PrinterLogin(plogin);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }

        public static DataTable GetPrinterPriceComparisonServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            PrinterDataAccess objsingledesigntype = new PrinterDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.GetPrinterPriceComparisonDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}