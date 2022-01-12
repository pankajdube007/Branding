using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.AssignJob
{
    public class AssignJobDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllJobRequestHeadForAssignDA()
        {
            return (objDataAccess.ReturnDataTable("JobRequestListForAssignJob"));
        }
        public DataTable AllJobRequestHeadForAssignDAUser(AssignJobModel.AssignProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignTypeInput.userid);
            return objDataAccess.ReturnDataTableWithParameters("JobRequestListForAssignJob", objParameter);
           // return (objDataAccess.ReturnDataTable("JobRequestListForAssignJob", objParameter));
        }

        public DataTable AllJobRequestHeadForChangeAssignDAUser(AssignJobModel.AssignProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignTypeInput.userid);
            return objDataAccess.ReturnDataTableWithParameters("JobRequestListForChangeAssignJob", objParameter);
            
        }
        public DataTable AllAssignedJobDA()
        {
            return (objDataAccess.ReturnDataTable("AssighnedrequestList"));
        }
        public DataTable AllAssignedJobDAUser(AssignJobModel.AssignProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignTypeInput.userid);
            return objDataAccess.ReturnDataTableWithParameters("AssighnedrequestList", objParameter);
           // return (objDataAccess.ReturnDataTable("AssighnedrequestList"));
        }

        public DataTable AllUsersDA()
        {
            return (objDataAccess.ReturnDataTable("GraphicsTeamList"));
        }

        public int DeleteAssignedJobDA(AssignJobModel.AssignProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@DeleteRemark", ObjDesignTypeInput.DeleteRemark);
            objParameter[2] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AssigenedJobDelete", objParameter));
        }

        public DataTable JobRequestChildSelectForAssignParticular(AssignJob.AssignJobModel.AssignProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestChildSelectParticularforassign", objParameter));
        }

        public DataTable JobRequestChildSelectForReAssignParticular(AssignJob.AssignJobModel.AssignProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestChildSelectParticularforReassign", objParameter));
        }

        public DataTable UserWorkStatus(AssignJob.AssignJobModel.AssignProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("userpendingwork", objParameter));
        }

        public int AddAssignJobeDA(AssignJob.AssignJobModel.AssignProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@jobrequestchildidP", ObjAssignJobInput.jobrequestchildidP);
            objParameter[1] = new SqlParameter("@Assignto", ObjAssignJobInput.Assignto);
            objParameter[2] = new SqlParameter("@deadline", ObjAssignJobInput.deadline);
            objParameter[3] = new SqlParameter("@Remark", ObjAssignJobInput.Remark);
            objParameter[4] = new SqlParameter("@Createuid", ObjAssignJobInput.createuid);
            objParameter[5] = new SqlParameter("@Createlogno", ObjAssignJobInput.createlogno);
            objParameter[6] = new SqlParameter("@pagename", ObjAssignJobInput.pagename);
            objParameter[7] = new SqlParameter("@editusercat", ObjAssignJobInput.editusercat);
           // objParameter[8] = new SqlParameter("@assignrequestno", ObjAssignJobInput.assignrequestno);
            objParameter[8] = new SqlParameter("@reqno", ObjAssignJobInput.reqno);
            objParameter[9] = new SqlParameter("@finyear", ObjAssignJobInput.finyear);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AddAssignJob", objParameter));
        }

        public int ChangeAssignJobeDA(AssignJob.AssignJobModel.AssignProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@jobrequestchildidP", ObjAssignJobInput.jobrequestchildidP);
            objParameter[1] = new SqlParameter("@Assignto", ObjAssignJobInput.Assignto);
            objParameter[2] = new SqlParameter("@deadline", ObjAssignJobInput.deadline);
            objParameter[3] = new SqlParameter("@Remark", ObjAssignJobInput.Remark);
            objParameter[4] = new SqlParameter("@Createuid", ObjAssignJobInput.createuid);
            objParameter[5] = new SqlParameter("@Createlogno", ObjAssignJobInput.createlogno);
            objParameter[6] = new SqlParameter("@pagename", ObjAssignJobInput.pagename);
            objParameter[7] = new SqlParameter("@editusercat", ObjAssignJobInput.editusercat);
            // objParameter[8] = new SqlParameter("@assignrequestno", ObjAssignJobInput.assignrequestno);
            objParameter[8] = new SqlParameter("@reqno", ObjAssignJobInput.reqno);
            objParameter[9] = new SqlParameter("@finyear", ObjAssignJobInput.finyear);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ChangeAssignJob", objParameter));
        }

        public int ReopenJobDA(AssignJob.AssignJobModel.AssignProperties ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@jobrequestchildid", ObjAssignJobInput.jobrequestchildidP);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignJobInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjAssignJobInput.createlogno);
            objParameter[3] = new SqlParameter("@pagename", ObjAssignJobInput.pagename);
            objParameter[4] = new SqlParameter("@editusercat", ObjAssignJobInput.editusercat);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ReopenJob", objParameter));
        }

        public DataTable AssReqno(AssignJob.AssignJobModel.AssignProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@comman", ObjDesignTypesingle.comman);
            objParameter[1] = new SqlParameter("@type", ObjDesignTypesingle.type); 
                objParameter[2] = new SqlParameter("@assireqno", ObjDesignTypesingle.reqno);
            return (objDataAccess.ReturnDataTableWithParameters("GetPrifabreqno", objParameter));
        }
    }
}