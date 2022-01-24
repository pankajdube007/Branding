using GoldMedal.Branding.Data.JobRequest;
using System.Data;

namespace GoldMedal.Branding.Service.JobRequestService
{
    public static class JobRequestServiceCall
    {
        public static DataTable AllJobRequestHeadDAServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllJobRequestHeadDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSalesExecutiveServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllSalesExecutive();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllJobRequestHeadBranchDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllJobRequestHeadDABranch(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataSet AllWallSizeJobRequestHeadBranchDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataSet recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllWallSizeJobRequestHeadDABranch(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllNameServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllName(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubNameServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllSubName(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetDealerJobHistoryServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetDealerJobHistoryDA(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable GetRetailerJobHistoryServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.GetRetailerJobHistoryDA(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllAddressContactsServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllAddressContact(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubAddressServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllSubAddress(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubEmailServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllSubEmail(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubmittedbyServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllSubmittedby(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllBranchServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllBranch(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataSet AllBranchSelectedServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataSet recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.SelectedBranch(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllSubContactsServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllSubContact(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllEmailServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllEmail(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllContactDetailServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllContactDetail(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable AllGstNoServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllGstNo(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
        public static DataTable JobRequestHeadSelectParticularServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestHeadSelectParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable ReqnoServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.getrequest alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.Reqno(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobRequestChildSelectParticularServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestChildSelectParticular(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobRequestChildOnlyServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestChildOnly(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable JobRequestChildFilesDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.JobRequestChildFilesDA(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable LiveProductFilesDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.LiveProductFilesDA(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        

        public static int AddUpdateJobRequesHeadtDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AddUpdateJobRequesHeadtDA(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int AddUpdateJobRequestChildDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AddUpdateJobRequestChildDA(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }


        public static int AddOrgDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.orginsert alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AddOrgDA(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DeleteJobRequestHeadServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DeleteJobRequestHead(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int PermanentDeleteJobRequestServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.PermanentDeleteJobRequest(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DeleteJobRequestChildServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DeleteJobRequestChild(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int DeleteJobRequestFilesDAServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            int recid = 0;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.DeleteJobRequestFilesDA(alldata);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }
        

        public static DataTable AllPartyCatServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllPartCatDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }


        public static DataTable AllAreaServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllAreaDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable AllDataForNameServiceMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.JobRequestProperties alldata, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objdata = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdata.AllDataForName(alldata);
            }
            else
            {
                recid = null;
            }
            return recid;
        }


       

        public static DataTable StatusOfRetailerMethod(GoldMedal.Branding.Data.JobRequest.JobRequestModel.DhbApproveStatus dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            JobRequestDataAccess objselectall = new JobRequestDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.StatusOfRetailer(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}