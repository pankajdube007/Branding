using System.Data;

namespace GoldMedal.Branding.Core.MasterMenu
{
    public interface IMasterMenu
    {
        DataTable UserCheckMethod(GoldMedal.Branding.Data.MasterMenu.MasterMenuModel.UserCheck dti);
    }
}