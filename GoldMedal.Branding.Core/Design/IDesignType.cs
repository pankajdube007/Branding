using System.Data;

namespace GoldMedal.Branding.Core.Design
{
    public interface IDesignType
    {
        int DesignTypeInsertMethod(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dti);

        bool DesignTypeDelete(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeDelete dti);

        DataTable GetDesignTypeAll();

        DataTable GetDesignTypeSingle(GoldMedal.Branding.Data.DesignType.DesignTypeModel.DesignTypeInsert dtsingle);
    }
}