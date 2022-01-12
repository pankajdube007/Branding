using System.Data;

namespace GoldMedal.Branding.Core.CheckEdit
{
    public interface ICheckEdit
    {
        DataTable GetCheckEditAll(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dtsingle);

        string ResetEditStatus(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dti);

        string updateeditstatus(GoldMedal.Branding.Data.CheckEdit.CheckEditModel.CheckEditInsert dti);
    }
}