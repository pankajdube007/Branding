using GoldMedal.Branding.Service.ApproveJob;
using System.Data;

namespace GoldMedal.Branding.Core.ApproveJob
{
    public class ApproveJob : IApproveJob
    {
        public DataTable JobRequestChildSelectForApproveParticularCore(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata)
        {
            DataTable result = new DataTable();
            result = ApproveJobServiceCall.JobRequestChildSelectParticularForApproveServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public string ApproveJobInsertMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti)
        {
            string recid = "0"; 
            recid = ApproveJobServiceCall.AddApproveJobInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public string PartyApproveApproveJobInsertMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti)
        {
            string recid = "0";
            recid = ApproveJobServiceCall.PartyApproveUpdateServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public string DisApproveJobInsertMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti)
        { 
            string recid = "0";
            recid = ApproveJobServiceCall.AddDisApproveJobInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public string ReopenJobInsertMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti)
        {
            string recid = "0";
            recid = ApproveJobServiceCall.ReopenJobInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable AllJobRequestHeadForApproveDACore(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata)
        {
            DataTable result = new DataTable();
            result = ApproveJobServiceCall.AllJobRequestHeadForApproveDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllApprovedJobByUserCore(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties alldata)
        {
            DataTable result = new DataTable();
            result = ApproveJobServiceCall.AllApprovedJobByUserServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int ApproveCount(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.ApproveProperties dti)
        {
            int recid = 0;
            recid = ApproveJobServiceCall.ApproveCount(dti, "MSSQLSERVER");
            return recid;
        }
        public string CancelOverdueJobsMethod(GoldMedal.Branding.Data.ApproveJob.ApproveJobModel.OverdueJobsCancel dti)
        {
            string recid = "0";
            recid = ApproveJobServiceCall.CancelOverdueJobsServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
    }
}