using System.Data;

namespace GoldMedal.Branding.Core.FinalAssembaly
{
    internal interface IFinalAssembly
    {
        DataTable ListOfJobForFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle);

        DataTable ListOfJobForJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle);

        int SubmitFinalAssembly(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti);

        int JobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti);

        DataTable ListOfJobForJobHistory(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle);

        DataTable ListOfApprovedJobForJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle);

        DataTable ListOfPrintedJobForJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dtsingle);

        int ApprovedJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti);

        int PrintedJobCloser(GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.FinalAssemblyProperty dti);
    }
}