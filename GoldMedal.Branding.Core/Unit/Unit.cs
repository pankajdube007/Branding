using GoldMedal.Branding.Service.UnitService;
using System.Data;

namespace GoldMedal.Branding.Core.Unit
{
    public class Unit : IUnit
    {
        public int UnitInsertMethod(GoldMedal.Branding.Data.Unit.UnitModel.UnitInsert dti)
        {
            int recid = 0;

            recid = UnitServiceCall.UnitInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int UnitDeleteMethod(GoldMedal.Branding.Data.Unit.UnitModel.UnitDelete dti)
        {
            int recid = 0;

            recid = UnitServiceCall.UnitDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public bool UnitDelete(GoldMedal.Branding.Data.Unit.UnitModel.UnitDelete dti)
        {
            bool recid = false;

            return recid;
        }

        public DataTable GetUnitAll()
        {
            DataTable recid = new DataTable();
            recid = UnitServiceCall.AllUnitServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetUnitSingle(GoldMedal.Branding.Data.Unit.UnitModel.UnitInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = UnitServiceCall.SingleUnitServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}