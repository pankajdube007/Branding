using GoldMedal.Branding.Service.Fabricator;
using System.Data;

namespace GoldMedal.Branding.Core.Fabricator
{
    public class Fabricator : IFabricator
    {
        public int FabricatorInsertMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.FabricatorInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int ModeofDispatchAddUpdate(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.ModeofDispatchAddUpdateServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int FabricatorDeleteMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.FabricatorDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int DeleteModeofDispatch(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.DeleteModeofDispatchServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool FabricatorDelete(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetFabricatorAll() 
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AllFabricatorServiceMethod("MSSQLSERVER");
            return recid;
        }
        public DataTable GetListForModeofDispatch()
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.GetListForModeofDispatchServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorForMappingAll()
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AllFabricatorServiceForMappingMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorByLocation(int LocationID)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.FabricatorByLocationServiceMethod("MSSQLSERVER", LocationID);
            return recid;
        }

        public DataTable GetAreaAll()
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AllAreaServiceMethod("MSSQLSERVER");
            return recid;
        }
        public DataTable GetBranchAll()
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AllBranchServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorSingle(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.SingleFabricatorServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSingleModeofDispatch(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.GetSingleModeofDispatchServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorPriceSingle(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorPricingInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.SingleFabricatorPriceServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetPricingComparison()
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.GetFabricatorPriceComparisonServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable AreaDetail(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AreaDetailServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable BranchDetail(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AreaDetailServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int fabricatormaterialSubmitupdate(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.fabricatormaterialSubmitupdate(dti, "MSSQLSERVER");
            return recid;
        }

        public int PermanentDeletefab(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.PermanentDeletefab(dti, "MSSQLSERVER");
            return recid;
        }

        public int Deletefabricatormaterial(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.Deletefabricatormaterial(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfMaterialListForFabricator(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.GetDetailOfMaterialListForFabricator(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public string FabricatorLoginMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorLogin dti)
        {
            string recid = "0";

            recid = FabricatorServiceCall.FabricatorLoginServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorPricingAll()
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.AllFabricatorPricingServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetDetailOfPricingListForFabricator(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.GetDetailOfPricingListForFabricator(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int FabricatorPricingAddUpdate(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorPricingInsert dti)
        {
            int recid = 0;

            recid = FabricatorServiceCall.FabricatorPricingAddUpdate(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSendToList(int SendType, int LocationID)
        {
            DataTable recid = new DataTable();
            recid = FabricatorServiceCall.SendToListServiceMethod("MSSQLSERVER", SendType, LocationID);
            return recid;
        }
        public string GetAddressFromSendToID(long SendToID, int SendToType, int PartyType)
        {
            string recid = "";

            recid = FabricatorServiceCall.GetAddressServiceMethod(SendToID, SendToType, PartyType, "MSSQLSERVER");
            return recid;
        }
    }
}