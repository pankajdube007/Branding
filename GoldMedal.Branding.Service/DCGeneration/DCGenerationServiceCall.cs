using System;
using System.Collections.Generic;
//using GoldMedal.Branding.Data.DCGeneration;
using System.Data;


namespace GoldMedal.Branding.Service.DCGeneration
{
    public static class DCGenerationServiceCall
    {
        //public static int FabricatorInsertServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    DCGenerationDataAccess objinsert = new DCGenerationDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objinsert.AddUpdateFabricatorDA(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}
        //public static int ModeofDispatchAddUpdateServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objinsert = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objinsert.ModeofDispatchAddUpdateDA(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}

        //public static int FabricatorDeleteServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.DeleteFabricatorDA(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}
        //public static int DeleteModeofDispatchServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.DeleteModeofDispatchDA(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}

        //public static DataTable AllFabricatorServiceMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.AllFabricatorDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}
        //public static DataTable GetListForModeofDispatchServiceMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.GetListForModeofDispatchDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}


        //public static DataTable AllFabricatorServiceForMappingMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.AllFabricatorForMappingDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static DataTable FabricatorByLocationServiceMethod(string DatabaseType, int LocationID)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.FabricatorByLocationDA(LocationID);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}


        //public static DataTable AllAreaServiceMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.AllAreaDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static DataTable AllBranchServiceMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.AllBranchDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static DataTable SingleFabricatorServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle, string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objsingledesigntype = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objsingledesigntype.SingleFabricatorDA(dtsingle);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}
        //public static DataTable GetSingleModeofDispatchServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle, string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objsingledesigntype = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objsingledesigntype.GetSingleModeofDispatchDA(dtsingle);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static DataTable SingleFabricatorPriceServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorPricingInsert dtsingle, string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objsingledesigntype = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objsingledesigntype.SingleFabricatorPriceDA(dtsingle);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static DataTable GetFabricatorPriceComparisonServiceMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objsingledesigntype = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objsingledesigntype.GetFabricatorPriceComparisonDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}



        //public static DataTable AreaDetailServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle, string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objsingledesigntype = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objsingledesigntype.AreaDetailDA(dtsingle);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static int fabricatormaterialSubmitupdate(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objinsert = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objinsert.FabricatormaterialSubmitupdate(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}

        //public static int PermanentDeletefab(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.PermanentDeletefab(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}

        //public static int Deletefabricatormaterial(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorDelete dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.Deletefabricatormaterial(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}

        //public static DataTable GetDetailOfMaterialListForFabricator(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle, string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.GetDetailOfMaterialListForFabricator(dtsingle);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static string FabricatorLoginServiceMethod(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorLogin flogin, string DatabaseType)
        //{
        //    string recid = "0";
        //    FabricatorDataAccess objinsert = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objinsert.FabricatorLogin(flogin);
        //    }
        //    else
        //    {
        //        recid = "0";
        //    }
        //    return recid;
        //}


        //public static DataTable AllFabricatorPricingServiceMethod(string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.AllFabricatorPricingDA();
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}


        //public static DataTable GetDetailOfPricingListForFabricator(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorInsert dtsingle, string DatabaseType)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objdelete = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objdelete.PricingListForFabricatorDA(dtsingle);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static int FabricatorPricingAddUpdate(GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorPricingInsert dti, string DatabaseType)
        //{
        //    int recid = 0;
        //    FabricatorDataAccess objinsert = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objinsert.FabricatorPricingAddUpdateDA(dti);
        //    }
        //    else
        //    {
        //        recid = 0;
        //    }
        //    return recid;
        //}
        //public static DataTable SendToListServiceMethod(string DatabaseType, int SendToType, int LocationID)
        //{
        //    DataTable recid = null;
        //    FabricatorDataAccess objselectall = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objselectall.SendToListDA(SendToType, LocationID);
        //    }
        //    else
        //    {
        //        recid = null;
        //    }
        //    return recid;
        //}

        //public static string GetAddressServiceMethod(long SendToID, int SendToType, int PartyType, string DatabaseType)
        //{
        //    string recid = "";
        //    FabricatorDataAccess objinsert = new FabricatorDataAccess();
        //    if (string.Equals(DatabaseType, "MSSQLSERVER"))
        //    {
        //        recid = objinsert.GetAddressFromSendToIDDA(SendToID, SendToType, PartyType);
        //    }
        //    else
        //    {
        //        recid = "";
        //    }
        //    return recid;
        //}
    }
}
