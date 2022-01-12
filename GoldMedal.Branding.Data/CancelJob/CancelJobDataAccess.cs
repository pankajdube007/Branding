using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.CancelJob
{
   public class CancelJobDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable GetJobdetailforthejobcancel()
        {
            return (objDataAccess.ReturnDataTable("getJobdetailforthejobcancel"));
        }


        public DataTable GetDetailsOfJobForJobcancel(CancelJob.CancelJobProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthejobcancelbyslno", objParameter));
        }
        public int JobCancel(CancelJob.CancelJobProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjAssignfabInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignfabInput.Remark);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("CancelJob", objParameter));
        }

    }
}
