using System.Data;

namespace GoldMedal.Branding.Core.Unit
{
    public interface IUnit
    {
        int UnitInsertMethod(GoldMedal.Branding.Data.Unit.UnitModel.UnitInsert dti);

        bool UnitDelete(GoldMedal.Branding.Data.Unit.UnitModel.UnitDelete dti);

        DataTable GetUnitAll();

        DataTable GetUnitSingle(GoldMedal.Branding.Data.Unit.UnitModel.UnitInsert dtsingle);
    }
}