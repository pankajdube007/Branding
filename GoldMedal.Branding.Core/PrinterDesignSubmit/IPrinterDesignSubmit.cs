using System.Data;

namespace GoldMedal.Branding.Core.PrinterDesignSubmit
{
    internal interface IPrinterDesignSubmit
    {
        DataTable GetAllJobForPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle);

        DataTable GetAllSubmittedJobForPrinter(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle);

        DataTable GetApprovedJobsForDC(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle);

        DataTable GetSingleApprovedJobsForDC(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle);

        int UpdateRecord(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti);

        DataTable GetDesignSubmitJobForPrinterSingle(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dtsingle);

        int DesignSubmitByPrinterInsertMethod(GoldMedal.Branding.Data.PrinterDesignSubmit.PrinterDesignSubmitProperty dti);

        int JobSendByPrinterMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti);

        int JobReceiveMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend dti);
    }
}