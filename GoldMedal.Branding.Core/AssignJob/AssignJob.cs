using GoldMedal.Branding.Service.AssignJobService;
using System.Data;

namespace GoldMedal.Branding.Core.AssignJob
{
    public class AssignJob : IAssignJob
    {
        public DataTable AllJobRequestHeadForAssignDACore()
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.AllJobRequestHeadForAssignDAServiceMethod("MSSQLSERVER");
            return result;
        }

        public DataTable AllJobRequestHeadForAssignDACoreuser(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata)
        {
            DataTable result = new DataTable(); 
          
              result = AssignJobServiceCall.AllJobRequestHeadForAssignDAServiceMethodUser(alldata, "MSSQLSERVER");
            
            return result;
        }

        public DataTable AllJobRequestHeadForChangeAssignDACoreuser(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata)
        {
            DataTable result = new DataTable();

            result = AssignJobServiceCall.AllJobRequestHeadForChangeAssignDAServiceMethodUser(alldata, "MSSQLSERVER");

            return result;
        }

        public bool AssignedJobDelete(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti)
        {
            bool recid = false;

            return recid;
        }

        public int AssignedJobDeleteMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti)
        {
            int recid = 0;

            recid = AssignJobServiceCall.AssignedJobDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable AllAssignedJobDACore()
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.AllAssignedJobDAServiceMethod("MSSQLSERVER");
            return result;
        }
        public DataTable AllAssignedJobDACoreUser(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti)
        {
            DataTable result = new DataTable();
            
            result = AssignJobServiceCall.AllAssignedJobDAServiceMethodUser(dti, "MSSQLSERVER");

            return result;
        }

        public DataTable AllUsersDACore()
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.AllUsersDAServiceMethod("MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestChildSelectForAssignParticularCore(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata)
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.JobRequestChildSelectParticularForAssignServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestChildSelectForReAssignParticularCore(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata)
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.JobRequestChildSelectParticularForReAssignServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable UserWorkStatus(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata)
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.UserWorkStatus(alldata, "MSSQLSERVER");
            return result;
        }

        public int AssignJobInsertMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti)
        {
            int recid = 0;

            recid = AssignJobServiceCall.AddAssignJobInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int ChangeAssignJobInsertMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti)
        {
            int recid = 0;

            recid = AssignJobServiceCall.ChangeAssignJobInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int ReopenJobMethod(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties dti)
        {
            int recid = 0;

            recid = AssignJobServiceCall.ReopenJobServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable AssReqnoCore(GoldMedal.Branding.Data.AssignJob.AssignJobModel.AssignProperties alldata)
        {
            DataTable result = new DataTable();
            result = AssignJobServiceCall.AssReqnoServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }
    }
}