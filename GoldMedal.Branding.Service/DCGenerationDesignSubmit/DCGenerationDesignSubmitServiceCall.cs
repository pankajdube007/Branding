using GoldMedal.Branding.Data.DCGenerationDesignSubmit;
using System.Data;

namespace GoldMedal.Branding.Service.DCGenerationDesignSubmit
{
    public class DCGenerationDesignSubmitServiceCall
    {
        public static DataTable ApprovedJobsForDCServiceMethod(GoldMedal.Branding.Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DCGenerationDesignSubmitDataAccess objselectall = new DCGenerationDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ApprovedJobsForDCDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static int UpdateSentQtybyFabricatorServiceMethod(GoldMedal.Branding.Data.DCGeneration.DCGeneration.DCGenerationSend dti, string DatabaseType)
        {
            int recid = 0;
            DCGenerationDesignSubmitDataAccess objinsert = new DCGenerationDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.UpdateSentQtybyDCGenerationDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int SendByDCGenerationServiceMethod(GoldMedal.Branding.Data.DCGeneration.DCGeneration.DCGenerationSend dti, string DatabaseType)
        {
            int recid = 0;
            DCGenerationDesignSubmitDataAccess objinsert = new DCGenerationDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.SendByDCGenerationDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable ApprovedJobsForViewDCServiceMethod(GoldMedal.Branding.Data.DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            DCGenerationDesignSubmitDataAccess objselectall = new DCGenerationDesignSubmitDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.ApprovedJobsForViewDCDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}
