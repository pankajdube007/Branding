using GoldMedal.Branding.Service.Disapproved;
using System.Data;

namespace GoldMedal.Branding.Core.Disapproved
{
    public class Disapproved : IDisapproved
    {
        public DataTable AllDisapproveJobRequestHeadForApproveDACore()
        {
            DataTable result = new DataTable();
            result = DisApproveJobServiceCall.AllDisapprovedJobRequestHeadDAServiceMethod("MSSQLSERVER");
            return result;
        }
        public DataTable AllDisapproveJobRequestHeadBranchForApproveDACore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            DataTable result = new DataTable();
            //result = DisApproveJobServiceCall.AllDisapprovedJobRequestHeadDAServiceMethod("MSSQLSERVER");
            result = DisApproveJobServiceCall.AllDisapprovedJobRequestHeadBranchDAServiceMethod(alldata,"MSSQLSERVER");
            return result;
        }

        public DataTable AllDisapproveJobRequestHeadBranchForApproveOldDACore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            DataTable result = new DataTable();
            result = DisApproveJobServiceCall.AllDisapprovedJobRequestHeadBranchOldDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int DeleteJobRequestHeaddisapprovedCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            int result = DisApproveJobServiceCall.DeleteDisapprovedJobRequestHeadServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int DeleteDisapprovedJobRequestChildCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            int result = DisApproveJobServiceCall.DeleteDisapprovedJobRequestChildServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable DisapprovedJobRequestHeadSelectParticularCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            DataTable result = new DataTable();
            result = DisApproveJobServiceCall.DisapprovedJobRequestHeadSelectParticularServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public DataTable DisapprovedJobRequestChildSelectParticularCore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            DataTable result = new DataTable();
            result = DisApproveJobServiceCall.DisapprovedJobRequestChildSelectParticularServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }

        public int UpdateDisapprovedJobRequestChildDACore(GoldMedal.Branding.Data.Disapproved.DisApproveJobModel.DisapprovedProperties alldata)
        {
            int result = DisApproveJobServiceCall.UpdateDisapprovedJobRequestChildDAServiceMethod(alldata, "MSSQLSERVER");
            return result;
        }
    }
}