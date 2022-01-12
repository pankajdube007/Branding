using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.Disapproved
{
    public class DisApproveJobDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllDisapprovedJobRequestHeadDA()
        {
            return (objDataAccess.ReturnDataTable("JobRequestListForDisApproveJob"));
        }
        public DataTable AllDisapprovedJobRequestHeadDABranch(DisApproveJobModel.DisapprovedProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@userid", ObjDesignTypeInput.userid);
          
           
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestListForDisApproveJob", objParameter));

            // return (objDataAccess.ReturnDataTable("JobRequestListForDisApproveJob"));
        }

        public DataTable AllDisapprovedJobRequestHeadOldDABranch(DisApproveJobModel.DisapprovedProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@userid", ObjDesignTypeInput.userid);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestListForDisApproveJobOld", objParameter));
        }

        

        public int DeleteDisapprovedJobRequestHead(DisApproveJobModel.DisapprovedProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteDisapprovedJobRequestHead", objParameter));
        }

        public int DeleteDisapprovedJobRequestChild(DisApproveJobModel.DisapprovedProperties ObjDesignTypeInput)

        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@refid", ObjDesignTypeInput.refid);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[3] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteDisapprovedJobRequestChild", objParameter));
        }

        public DataTable DisapprovedJobRequestHeadSelectParticular(DisApproveJobModel.DisapprovedProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("DISAPPROVEDJobRequestHeadSelectParticular", objParameter));
        }

        public DataTable DisapprovedJobRequestChildSelectParticular(DisApproveJobModel.DisapprovedProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("DisapprovedJobRequestChildSelectParticular", objParameter));
        }

        public int UpdateDisapprovedJobRequestChildDA(DisApproveJobModel.DisapprovedProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[31];
            objParameter[0] = new SqlParameter("@taskid", ObjDesignTypeInput.TaskId);
            objParameter[1] = new SqlParameter("@width", ObjDesignTypeInput.Width);
            objParameter[2] = new SqlParameter("@height", ObjDesignTypeInput.Height);
            objParameter[3] = new SqlParameter("@jobtypeid", ObjDesignTypeInput.JobTypeId);
            objParameter[4] = new SqlParameter("@subjobtypeid", ObjDesignTypeInput.SubJobTypeId);
            objParameter[5] = new SqlParameter("@subsubjobtypeid", ObjDesignTypeInput.SubSubJobTypeId);
            objParameter[6] = new SqlParameter("@designtypeid", ObjDesignTypeInput.DesignTypeId);
            objParameter[7] = new SqlParameter("@producttypeid", ObjDesignTypeInput.ProductTypeId);
            objParameter[8] = new SqlParameter("@qty", ObjDesignTypeInput.Qty);
            objParameter[9] = new SqlParameter("@installaddress", ObjDesignTypeInput.installaddress);
            objParameter[10] = new SqlParameter("@needapproval", ObjDesignTypeInput.NeedApproval);
            objParameter[11] = new SqlParameter("@image", ObjDesignTypeInput.ImageName);
            objParameter[12] = new SqlParameter("@remark", ObjDesignTypeInput.Remark);
            objParameter[13] = new SqlParameter("@refid", ObjDesignTypeInput.refid);
            objParameter[14] = new SqlParameter("@childstatus", ObjDesignTypeInput.childstatus);
            objParameter[15] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[16] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[17] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[18] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[19] = new SqlParameter("@editusercat", ObjDesignTypeInput.editusercat);
            objParameter[20] = new SqlParameter("@DeleteFlag", ObjDesignTypeInput.DeleteFlag);
            objParameter[21] = new SqlParameter("@status", ObjDesignTypeInput.status);
            objParameter[22] = new SqlParameter("@approvalmail", ObjDesignTypeInput.approvalmail);
            objParameter[23] = new SqlParameter("@approvto", ObjDesignTypeInput.approvto);
            objParameter[24] = new SqlParameter("@link", ObjDesignTypeInput.Link);
            objParameter[25] = new SqlParameter("@UnitID", ObjDesignTypeInput.UnitID);
            objParameter[26] = new SqlParameter("@Priority", ObjDesignTypeInput.Priority);
            objParameter[27] = new SqlParameter("@BoardTypeID", ObjDesignTypeInput.BoardTypeID);
            objParameter[28] = new SqlParameter("@PrintLocation", ObjDesignTypeInput.PrintLocation);
            objParameter[29] = new SqlParameter("@FabricatorLocation", ObjDesignTypeInput.FabricatorLocation);

            objParameter[30] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[30].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobRequestDisapprovedChildUpdate", objParameter));
        }
    }
}