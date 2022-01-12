using GoldMedal.Branding.Service.FabricatorQuotation;
using System.Data;

namespace GoldMedal.Branding.Core.FabricatorQuotation
{
    public class FabricatorQuotation : IFabricatorQuotation
    {
        public int FabricatorQuotationInsertMethod(GoldMedal.Branding.Data.FabricatorQuotation.FabricatorQuotation.FabricatorQuotationInsert dti)
        {
            int recid = 0;

            recid = FabricatorQuotationServiceCall.FabricatorQuotationInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorQuotationAll()
        {
            DataTable recid = new DataTable();
            recid = FabricatorQuotationServiceCall.AllFabricatorQuotationServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorQuotationForFabricator(long FabricatorID)
        {
            DataTable recid = new DataTable();
            recid = FabricatorQuotationServiceCall.FabricatorQuotationForFabricatorServiceMethod("MSSQLSERVER", FabricatorID);
            return recid;
        }

        public DataTable GetFabricatorQuotationSingle(GoldMedal.Branding.Data.FabricatorQuotation.FabricatorQuotation.FabricatorQuotationInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorQuotationServiceCall.SingleFabricatorQuotationServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}