using GoldMedal.Branding.Service.DCGenerationDesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Core.DCGenerationDesignSubmit
{
    public class DCGenerationDesignSubmit
    {

        public DataTable GetApprovedJobsForDC(GoldMedal.Branding.Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = DCGenerationDesignSubmitServiceCall.ApprovedJobsForDCServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
        public int UpdateSentQtybyDCGenerationMethod(GoldMedal.Branding.Data.DCGeneration.DCGeneration.DCGenerationSend dti)
        {
            int recid = 0;

            recid = DCGenerationDesignSubmitServiceCall.UpdateSentQtybyFabricatorServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int SendByDCGenerationMethod(GoldMedal.Branding.Data.DCGeneration.DCGeneration.DCGenerationSend dti)
        {
            int recid = 0;

            recid = DCGenerationDesignSubmitServiceCall.SendByDCGenerationServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetApprovedJobsForViewDC(GoldMedal.Branding.Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty dt)
        {
            DataTable recid = new DataTable();
            recid = DCGenerationDesignSubmitServiceCall.ApprovedJobsForViewDCServiceMethod(dt, "MSSQLSERVER");
            return recid;
        }
    }
}
