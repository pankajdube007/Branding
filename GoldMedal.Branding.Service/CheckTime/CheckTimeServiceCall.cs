using GoldMedal.Branding.Data.CheckTime;
using System.Data;

namespace GoldMedal.Branding.Service.CheckTime
{
    public static class CheckTimeServiceCall
    {
        public static DataTable GetCheckTimeForNodeServiceMethod(GoldMedal.Branding.Data.CheckTime.CheckTimeModel.CheckTimeInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            CheckTimeDataAccess objsingledesigntype = new CheckTimeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingledesigntype.GetTimeForNodeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}