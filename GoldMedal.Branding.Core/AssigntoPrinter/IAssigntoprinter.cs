using System.Data;

namespace GoldMedal.Branding.Core.AssigntoPrinter
{
    public interface IAssigntoprinter
    {
        DataTable DetailOfJobToPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle);

        DataTable DetailOfJobDoneByPrinterForApproval(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle);

        DataTable AllApprovedJobsOfPrinter(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle);
        int AssignPrinterInsertMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti,out string PrinterEmail, out string PrinterMobile);

        int ApproveDesignSubmitByPrinterMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti);

        DataTable AllAssignedPrinterForJobDACore();

        int AssignedPrinterForJobDeleteMethod(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dti);

        DataTable PriReqnoCore(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty alldata);

        DataTable GetJobSentByPrinterToReceive(GoldMedal.Branding.Data.AssigntoPrinter.AssigntoPrinter.AssigntoPrinterProperty dtsingle);
    }
}