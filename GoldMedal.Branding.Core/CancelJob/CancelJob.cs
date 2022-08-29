using GoldMedal.Branding.Service.CancelJob;
using System.Data;

namespace GoldMedal.Branding.Core.CancelJob
{
   public class CancelJob : ICancelJob
    {
        public DataTable ListOfJobForCancel(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = CancelJobServiceCall.ListOfJobForCancelServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobForCancelDateWise(string Fromdate, string ToDate, string BranchIDs)
        {
            DataTable recid = new DataTable();
            recid = CancelJobServiceCall.ListOfJobForCancelServiceMethodDateWise(Fromdate, ToDate, BranchIDs, "MSSQLSERVER");
            return recid;
        }


        public DataTable DetailsOfJobForJobCancel(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = CancelJobServiceCall.DetailsOfJobForJobCloserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public int JobCancel(GoldMedal.Branding.Data.CancelJob.CancelJob.CancelJobProperty dti)
        {
            int recid = 0;

            recid = CancelJobServiceCall.JobCancelServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

    }
}
