using GoldMedal.Branding.Service.MasterMenu;
using System.Data;

namespace GoldMedal.Branding.Core.MasterMenu
{
    public class MasterMenu : IMasterMenu
    {
        public DataTable UserCheckMethod(GoldMedal.Branding.Data.MasterMenu.MasterMenuModel.UserCheck dti)
        {
            DataTable recid = new DataTable();

            recid = MasterMenuServiceCall.MasterMenuUserCheckServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
    }
}