using GoldMedal.Branding.Service.JobRequestService;
using System.Data;

namespace GoldMedal.Branding.Core.JobRequest
{
    public class JobRequest : IJobRequest
    {
        public DataTable AllJobRequestHeadDACore()
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllJobRequestHeadDAServiceMethod("MSSQLSERVER");
            return result;
        }

        public DataTable AllSalesExecutiveCore()
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllSalesExecutiveServiceMethod("MSSQLSERVER");
            return result;
        }


        public DataTable AllJobRequestBranchHeadDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllJobRequestHeadBranchDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataSet AllWallSizeJobRequestBranchHeadDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataSet result = new DataSet();
            result = JobRequestServiceCall.AllWallSizeJobRequestHeadBranchDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllNameCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllNameServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllSubNameCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllSubNameServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable GetDealerJobHistoryCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.GetDealerJobHistoryServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }
        public DataTable GetRetailerJobHistoryCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.GetRetailerJobHistoryServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllAddressContactsCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllAddressContactsServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllSubAddressCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllSubAddressServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllSubEmailCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllSubEmailServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllSubmittedbyCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllSubmittedbyServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllBranchCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllBranchServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }
        public DataSet AllBranchSelected(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataSet result = new DataSet();
            result = JobRequestServiceCall.AllBranchSelectedServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllSubContactsCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllSubContactsServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllEmailCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllEmailServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllContactDetailCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllContactDetailServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestHeadSelectParticularCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.JobRequestHeadSelectParticularServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable AllGstNo(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllGstNoServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestChildSelectParticularCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.JobRequestChildSelectParticularServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestChildOnlyCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.JobRequestChildOnlyServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestChildFilesDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.JobRequestChildFilesDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable JobRequestRegionalLangDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.JobRequestRegionalLangBranchDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable LiveProductFilesDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.LiveProductFilesDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int AddUpdateJobRequesHeadtDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            int result = JobRequestServiceCall.AddUpdateJobRequesHeadtDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int AddUpdateJobRequestChildDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            int result = JobRequestServiceCall.AddUpdateJobRequestChildDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }


        public int AddOrgDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.orginsert alldata)
        {
            int result = JobRequestServiceCall.AddOrgDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }



        public int DeleteJobRequestHeadCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            int result = JobRequestServiceCall.DeleteJobRequestHeadServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int PermanentDeleteJobRequestCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            int result = JobRequestServiceCall.PermanentDeleteJobRequestServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int DeleteJobRequestChildCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            int result = JobRequestServiceCall.DeleteJobRequestChildServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int DeleteJobRequestFilesDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            int result = JobRequestServiceCall.DeleteJobRequestFilesDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable ReqnoCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.getrequest alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.ReqnoServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable GetPartyCatAll()
        {
            DataTable recid = new DataTable();
            recid = JobRequestServiceCall.AllPartyCatServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetAreaAll()
        {
            DataTable recid = new DataTable();
            recid = JobRequestServiceCall.AllAreaServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable AllDataForName(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata)
        {
            DataTable result = new DataTable();
            result = JobRequestServiceCall.AllDataForNameServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }


       


        public DataTable StatusOfRetailer(GoldMedal.Branding.Data.JobRequest.JobRequestModel.DhbApproveStatus dtsingle)
        {
            DataTable recid = new DataTable();
            recid = JobRequestServiceCall.StatusOfRetailerMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}