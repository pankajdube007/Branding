using System.Data;

namespace GoldMedal.Branding.Core.CancelJob
{
    internal interface ICancelJob
    {
        DataTable ListOfJobForCancel(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dtsingle);
    }
}
