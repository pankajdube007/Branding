using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.ApproveJob
{
    public class ApproveJobDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllJobRequestHeadForApproveDA(ApproveJob.ApproveJobModel.ApproveProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignTypesingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestListForApproveJob", objParameter));
        }

        public DataTable AllApprovedJobByUserDA(ApproveJob.ApproveJobModel.ApproveProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@uid", ObjDesignTypesingle.uid);
            objParameter[1] = new SqlParameter("@fromdate", ObjDesignTypesingle.fromdate);
            objParameter[2] = new SqlParameter("@todate", ObjDesignTypesingle.todate);
            return (objDataAccess.ReturnDataTableWithParameters("ApprovedJobRequestByUser", objParameter));
        }
        

        public DataTable JobRequestChildSelectForApproveParticular(ApproveJob.ApproveJobModel.ApproveProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestChildSelectParticularforapprove", objParameter));
        }

        public string AddApproveJobeDA(ApproveJob.ApproveJobModel.ApproveProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@branchid", ObjAssignJobInput.branchid);
            objParameter[2] = new SqlParameter("@uid", ObjAssignJobInput.uid);
            objParameter[3] = new SqlParameter("@tableNm", ObjAssignJobInput.tableNm);
            objParameter[4] = new SqlParameter("@moduleid", ObjAssignJobInput.moduleid);
            objParameter[5] = new SqlParameter("@apdisapremarks", ObjAssignJobInput.apdisapremarks);
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("CommonAppprovalSystem", objParameter));
        }

        public string AddWallSizeJobApprovalDA(ApproveJob.ApproveJobModel.ApproveProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@branchid", ObjAssignJobInput.branchid);
            objParameter[2] = new SqlParameter("@uid", ObjAssignJobInput.uid);
            objParameter[3] = new SqlParameter("@moduleid", ObjAssignJobInput.moduleid);
           
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("WallsizejobsApprovalUpdate", objParameter));
        }

        public string PartyApproveUpdateJobeDA(ApproveJob.ApproveJobModel.ApproveProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
           
            objParameter[1] = new SqlParameter("@uid", ObjAssignJobInput.uid);
           
           
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("partyapprovalstatusupdate", objParameter));
        }

        public int ApproveCount(ApproveJob.ApproveJobModel.ApproveProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("approvecount", objParameter));
        }

        public string AddDisApproveJobeDA(ApproveJob.ApproveJobModel.ApproveProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@branchid", ObjAssignJobInput.branchid);
            objParameter[2] = new SqlParameter("@uid", ObjAssignJobInput.uid);
            objParameter[3] = new SqlParameter("@tableNm", ObjAssignJobInput.tableNm);
            objParameter[4] = new SqlParameter("@moduleid", ObjAssignJobInput.moduleid);
            objParameter[5] = new SqlParameter("@apdisapremarks", ObjAssignJobInput.apdisapremarks);

            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("CommonDisAppprovalSystem", objParameter));
        }

        public string ReopenJobeDA(ApproveJob.ApproveJobModel.ApproveProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
            
            objParameter[1] = new SqlParameter("@uid", ObjAssignJobInput.uid);
          
            

            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("ReopenJobByDesignHead", objParameter));
        }

        public string CancelOverdueJobsDA(ApproveJob.ApproveJobModel.OverdueJobsCancel ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjAssignJobInput.slno);
            
            objParameter[1] = new SqlParameter("@uid", ObjAssignJobInput.uid);
            
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("OverdueJobsDisapproval", objParameter));
        }
    }
}