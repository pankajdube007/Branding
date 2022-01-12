using GoldMedal.Branding.Service.CheckTime;
using System.Data;

namespace GoldMedal.Branding.Core.CheckTime
{
    public class CheckTime : ICheckTime
    {
        public DataTable GetCheckTimeForNode(GoldMedal.Branding.Data.CheckTime.CheckTimeModel.CheckTimeInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = CheckTimeServiceCall.GetCheckTimeForNodeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}