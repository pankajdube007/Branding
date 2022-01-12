using GoldMedal.Branding.Data.CheckEdit;
using System.Data;

namespace GoldMedal.Branding.Service.CheckEditService
{
    public static class CheckEditServiceCall
    {
        public static DataTable AllCheckEditServiceMethod(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            CheckEditDataAccess objselectall = new CheckEditDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllCheckEditDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static string ResetEditStatus(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dti, string DatabaseType)
        {
            string recid = string.Empty;
            CheckEditDataAccess objinsert = new CheckEditDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.ResetEditStatus(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }

        public static string updateeditstatus(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dti, string DatabaseType)
        {
            string recid = string.Empty;
            CheckEditDataAccess objinsert = new CheckEditDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.updateeditstatus(dti);
            }
            else
            {
                recid = "0";
            }
            return recid;
        }
    }
}