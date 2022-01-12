using GoldMedal.Branding.Data.FabricatorQuotation;
using System.Data;

namespace GoldMedal.Branding.Service.FabricatorQuotation
{
    public static class FabricatorQuotationServiceCall
    {
        public static int FabricatorQuotationInsertServiceMethod(GoldMedal.Branding.Data.FabricatorQuotation.FabricatorQuotation.FabricatorQuotationInsert dti, string DatabaseType)
        {
            int recid = 0;
            FabricatorQuotationDataAccess objinsert = new FabricatorQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateFabricatorQuotationDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllFabricatorQuotationServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            FabricatorQuotationDataAccess objselectall = new FabricatorQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllFabricatorQuotationDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable FabricatorQuotationForFabricatorServiceMethod(string DatabaseType, long FabricatorID)
        {
            DataTable recid = null;
            FabricatorQuotationDataAccess objselectall = new FabricatorQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.FabricatorQuotationForFabricatorDA(FabricatorID);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        

        public static DataTable SingleFabricatorQuotationServiceMethod(GoldMedal.Branding.Data.FabricatorQuotation.FabricatorQuotation.FabricatorQuotationInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            FabricatorQuotationDataAccess objsingledesigntype = new FabricatorQuotationDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.SingleFabricatorQuotationDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}