using System.Data;

namespace GoldMedal.Branding.Core.FabricatorDesignSubmit
{
    internal interface IFabricatorDesignSubmit
    {
        DataTable GetAllJobForFabricator(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle);

        int UpdateRecord(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti);

        DataTable GetDesignSubmitJobForFabricatorSingle(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dtsingle);

        int DesignSubmitByFabritorInsertMethod(GoldMedal.Branding.Data.FabricatorDesignSubmit.FabricatorDesignSubmitProperty dti);
    }
}