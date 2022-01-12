using GoldMedal.Branding.Data.Unit;
using System.Data;

namespace GoldMedal.Branding.Service.UnitService
{
    public static class UnitServiceCall
    {
        public static int UnitInsertServiceMethod(GoldMedal.Branding.Data.Unit.UnitModel.UnitInsert dti, string DatabaseType)
        {
            int recid = 0;
            UnitDataAccess objinsert = new UnitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateUnitDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int UnitDeleteServiceMethod(GoldMedal.Branding.Data.Unit.UnitModel.UnitDelete dti, string DatabaseType)
        {
            int recid = 0;
            UnitDataAccess objdelete = new UnitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteUnitDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllUnitServiceMethod(string DatabaseType)
        {
            DataTable recid = null;

            UnitDataAccess objselectall = new UnitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllUnitDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleUnitServiceMethod(GoldMedal.Branding.Data.Unit.UnitModel.UnitInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            UnitDataAccess objsingleunit = new UnitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleunit.SingleUnitDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}