using System.Data;

namespace GoldMedal.Branding.Core.CheckTime
{
    public interface ICheckTime
    {
        DataTable GetCheckTimeForNode(GoldMedal.Branding.Data.CheckTime.CheckTimeModel.CheckTimeInsert dtsingle);
    }
}