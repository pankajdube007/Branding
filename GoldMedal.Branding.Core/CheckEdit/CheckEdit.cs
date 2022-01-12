using GoldMedal.Branding.Service.CheckEditService;
using System.Data;

namespace GoldMedal.Branding.Core.CheckEdit
{
    public class CheckEdit : ICheckEdit
    {
        public DataTable GetCheckEditAll(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dtsingle)
        {
            DataTable recid = new DataTable();
            recid = CheckEditServiceCall.AllCheckEditServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public string ResetEditStatus(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dtsingle)
        {
            string recid = string.Empty;
            recid = CheckEditServiceCall.ResetEditStatus(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public string updateeditstatus(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dtsingle)
        {
            string recid = string.Empty;
            recid = CheckEditServiceCall.updateeditstatus(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}