using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.AssignFabricator
{
    public class AssignToFabricatorDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable ListOfJobForAssignToFabricator(AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignlisttoassignfabricator", objParameter));
        }

        public DataTable GetGenarateFabricatorPODA(AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            
            return (objDataAccess.ReturnDataTableWithParameters("GetGeneratedFabricatorPO", objParameter));
        }
        public DataTable GetGenarateFabricatorPOForCancelListDA(AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetGeneratedFabricatorPOForCancelList", objParameter));
        }

        public DataTable GetFabricatorPOwithValueAuditDA(AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetFabricatorPOwithValueAuditReport", objParameter));
        }

        public DataTable GetFabricatorPOwithoutValueHODA(AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetFabricatorPOwithoutValueHOReport", objParameter));
        }

        public DataTable ListOfJobForAssignToFabricatorSendByPrinter(AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            objParameter[1] = new SqlParameter("@slno", Objsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignlisttoassignfabricatorsendbyprinter", objParameter));
        }

        public int AssignFabricatorInsert(AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[13];
            objParameter[0] = new SqlParameter("@tofabricator", ObjAssignfabInput.tofabricator);
            objParameter[1] = new SqlParameter("@designsubmitid", ObjAssignfabInput.designsubmitid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignfabInput.Remark);
            objParameter[3] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjAssignfabInput.createlogno);
            objParameter[5] = new SqlParameter("@pagename", ObjAssignfabInput.pagename);
            objParameter[6] = new SqlParameter("@editusercat", ObjAssignfabInput.editusercat);
            objParameter[7] = new SqlParameter("@reqno", ObjAssignfabInput.reqno);
            objParameter[8] = new SqlParameter("@jobreqno", ObjAssignfabInput.jobreqno);
            objParameter[9] = new SqlParameter("@finyear", ObjAssignfabInput.finyear);
            objParameter[10] = new SqlParameter("@FabricationCost", ObjAssignfabInput.FabricationCost);
            objParameter[11] = new SqlParameter("@assignprinterslno", ObjAssignfabInput.assignprinterslno);
            objParameter[12] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[12].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AddAssignfabricator", objParameter));
        }

        public int GenarateFabricatorPoInsert(AssignFabricator.AssignToFabricator.GenarateFabricatorPO ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignfabInput.slno);
            objParameter[1] = new SqlParameter("@finYear", ObjAssignfabInput.finYear);
            objParameter[2] = new SqlParameter("@branchid", ObjAssignfabInput.branchid);
            objParameter[3] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[4] = new SqlParameter("@createlogno", ObjAssignfabInput.createlogno);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("GenerateFabricatorPo", objParameter));
        }
        public int CancelFabricatorPoDA(AssignFabricator.AssignToFabricator.GenarateFabricatorPO ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@AssignFabricatorSlno", ObjAssignfabInput.AssignFabricatorSlno);
            objParameter[1] = new SqlParameter("@POChildslno", ObjAssignfabInput.POChildslno);
            objParameter[2] = new SqlParameter("@PoHeadslno", ObjAssignfabInput.PoHeadslno);
            objParameter[3] = new SqlParameter("@createuid", ObjAssignfabInput.createuid);

            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("CancelFabricatorPO", objParameter));
        }

        public int AssignedfabricatorDelete(AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AssigenedfabricatoForJobDelete", objParameter));
        }

        public DataTable AllAssignedfabricator()
        {
            return (objDataAccess.ReturnDataTable("Assighnedjobtofabricator"));
        }
        public DataTable AllAssignedfabricatorUser(AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("Assighnedjobtofabricator", objParameter));
        }

        public DataTable DetailOfJobDoneByFabricatorForApproval(AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsumitbfabricatorforapprove", objParameter));
        }

        public DataTable GetAllApprovedFabricatorJobsDA(AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetAllApprovedFabricatorJobs", objParameter));
        }

        

        public int ApproveDesignSubmitByFabricator(AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty ObjAssignPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@slno", ObjAssignPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignPrinterInput.createuid);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ApproveDesignSubmitByFabricator", objParameter));
        }
        public DataTable JobSentByFabricatorToReceiveDA(AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetJobSentByFabricatorToReceive", objParameter));
        }

        public DataTable GetFabricatorCreditDebitJobsToApprove1DA(AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetFabricatorCreditDebitJobsToApprove1", objParameter));
        }
        public DataTable GetFabricatorCreditDebitJobsToApprove2DA(AssignToFabricator.AssigntoFabricatorProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetFabricatorCreditDebitJobsToApprove2", objParameter));
        }

        public DataTable SingleJobForReceiveDA(AssignToFabricator.AssigntoFabricatorProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorSingleJobForReceiveDC", objParameter));
        }

        public DataTable SingleFabricatorCreditDebitJobForApprove1DA(AssignToFabricator.AssigntoFabricatorProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SingleFabricatorCreditDebitJobForApprove1", objParameter));
        }
        public DataTable SingleFabricatorCreditDebitJobForApprove2DA(AssignToFabricator.AssigntoFabricatorProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SingleFabricatorCreditDebitJobForApprove2", objParameter));
        }
    }
}