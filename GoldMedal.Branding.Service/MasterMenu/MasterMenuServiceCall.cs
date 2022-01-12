using GoldMedal.Branding.Data.MasterMenu;
using System.Data;

namespace GoldMedal.Branding.Service.MasterMenu
{
    public static class MasterMenuServiceCall
    {
        public static DataTable MasterMenuUserCheckServiceMethod(GoldMedal.Branding.Data.MasterMenu.MasterMenuModel.UserCheck dti, string DatabaseType)
        {
            DataTable recid =new DataTable();
            MasterMenuDataAccess objcheck = new MasterMenuDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid =   objcheck.UserCheckMasterMenuDA(dti);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}