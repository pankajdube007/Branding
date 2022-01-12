using System.Data;

namespace GoldMedal.Branding.Core.JobRequest
{
    public interface IJobRequest
    {
        DataTable AllJobRequestHeadDACore();

        DataTable AllSalesExecutiveCore();

        DataTable AllNameCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllSubNameCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllAddressContactsCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllSubContactsCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllSubAddressCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllSubEmailCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllSubmittedbyCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllEmailCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllContactDetailCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable JobRequestHeadSelectParticularCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable JobRequestChildSelectParticularCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable JobRequestChildOnlyCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable JobRequestChildFilesDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        int AddUpdateJobRequesHeadtDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        int AddUpdateJobRequestChildDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);
        int AddOrgDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.orginsert alldata);

        int DeleteJobRequestHeadCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        int PermanentDeleteJobRequestCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        int DeleteJobRequestChildCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        int DeleteJobRequestFilesDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable ReqnoCore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.getrequest alldata);
        DataTable GetPartyCatAll();
        DataTable GetAreaAll();

        DataTable LiveProductFilesDACore(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);

        DataTable AllDataForName(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata);
    }
}