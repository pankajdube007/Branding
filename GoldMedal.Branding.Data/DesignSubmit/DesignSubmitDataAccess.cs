using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.DesignSubmit
{
    public class DesignSubmitDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllAssignedJobForUserDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("Assignedjobforuserlist", objParameter));
        }

        public DataTable Detailofassignedjobchild(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("detailsofassighedjobparticular", objParameter));
        }

        public DataTable AllDesignSubmitByUserDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitlist", objParameter));
        }

        public DataTable AllDesignSubmitByUserforapprovelDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitlistforapprovel", objParameter));
        }
        

        public DataTable AllSubmitedDesignApprovedByUserDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignApprovedByUser", objParameter));
        }

        public DataTable AllSubmitedDesignDisapprovedByPartyDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignDisApprovedByParty", objParameter));
        }
        public DataTable AllDesignDisapprovedByPartyDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignDisApprovedByParty", objParameter));
        }
        public DataTable AllDesignApprovedByPartyDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@createuid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignApprovedByParty", objParameter));
        }

        public DataTable GetPartyApprovalPendingJobsDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("PartyApprovalPendingJobsReport", objParameter));
        }


        public DataTable AllSubmitedDesignApprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignApprovedByMgm", objParameter));
        }
        public DataTable GetDesignerwiseSubmitedDesignApprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignApprovedByMgmDesignerwise", objParameter));
        }


        public DataTable GetBranchwiseSubmitedDesignApprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignApprovedByMgmBranchwise", objParameter));
        }

        public DataTable AllSubmitedDesignDisapprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignDisapprovedByMgm", objParameter));
        }
        public DataTable GetDesignerwiseSubmitedDesignDisapprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignDisapprovedByMgmDesignerwise", objParameter));
        }
        public DataTable GetBranchwiseSubmitedDesignDisapprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetSubmitedDesignDisapprovedByMgmBranchwise", objParameter));
        }

        public DataTable AllDesignApprovedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignApprovedByMgm", objParameter));
        }

        public DataTable AllDesignAcceptedByMgmDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("GetDesignAcceptedByMgm", objParameter));
        }

        public DataTable AllDesignSubmitByUserforapprovelmanagementDA(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.createuid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitlistforapprovelbymanagement", objParameter));
        }

        public DataTable DetailSingleDesignSubmitByUser(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitparticular", objParameter));
        }
        public DataTable PrinterWorkStatus(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("printerpendingwork", objParameter));
        }
        public DataTable JobDetailsForParty(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uniquekey", ObjDesignSubmitsingle.uniquekey);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitdetailforparty", objParameter));
        }

        public DataTable DetailOfItemListForDesignSubmit(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getitemlistfordesignsubmit", objParameter));
        }

        public DataTable DetailOfSizeListForDesignSubmit(DesignSubmit.DesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getsizelistfordesignsubmit", objParameter));
        }

        public DataTable AllItemDivisionDA()
        {
            return (objDataAccess.ReturnDataTable("ItemDivisionList"));
        }

        public DataTable AllItemTypeDA(int DivisionID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DivisionID", DivisionID);

            return (objDataAccess.ReturnDataTableWithParameters("ItemTypeList", objParameter));
        }

        public decimal GetItemPriceDA(int ItemID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@ItemID", ItemID);

            return Convert.ToDecimal(objDataAccess.ExecuteScalarWithParameters("GetItemPrice", objParameter));
        }

        public int AddDesignSubmitDA(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[16];
            objParameter[0] = new SqlParameter("@assignslno", ObjDesignTypeInput.assignslno);
            objParameter[1] = new SqlParameter("@sumbmitimg", ObjDesignTypeInput.sumbmitimg);
            objParameter[2] = new SqlParameter("@newproducttypeid", ObjDesignTypeInput.newproducttypeid);
            objParameter[3] = new SqlParameter("@totalamount", ObjDesignTypeInput.totalamount);
            objParameter[4] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[5] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[6] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[7] = new SqlParameter("@editusercat", ObjDesignTypeInput.editusercat);
            objParameter[8] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[9] = new SqlParameter("@needapproval", ObjDesignTypeInput.needapproval);
            objParameter[10] = new SqlParameter("@sizetype", ObjDesignTypeInput.sizetype);
            objParameter[11] = new SqlParameter("@link", ObjDesignTypeInput.link);
            objParameter[12] = new SqlParameter("@NewWidth", ObjDesignTypeInput.NewWidth);
            objParameter[13] = new SqlParameter("@NewHeight", ObjDesignTypeInput.NewHeight);
            objParameter[14] = new SqlParameter("@Remark", ObjDesignTypeInput.remark);
            objParameter[15] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[15].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DesignSubmitAdd", objParameter));
        }

        public int UpdateDesignSubmitDA(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[3] = new SqlParameter("@sizetype", ObjDesignTypeInput.sizetype);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UpdateSubmitedDesign", objParameter));
        }


        public int UpdateReopenSendForPrintDA(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ReopenSendForPrintJobs", objParameter));
        }

        public int AddItemDesignSubmitDA(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[14];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Itemid", ObjDesignTypeInput.itemid);
            objParameter[2] = new SqlParameter("@MRP", ObjDesignTypeInput.mrp);
            objParameter[3] = new SqlParameter("@Discount", ObjDesignTypeInput.discount);
            objParameter[4] = new SqlParameter("@Qty", ObjDesignTypeInput.qty);
            objParameter[5] = new SqlParameter("@Amount", ObjDesignTypeInput.amount);
            objParameter[6] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[7] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[8] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[9] = new SqlParameter("@editusercat", ObjDesignTypeInput.editusercat);
            objParameter[10] = new SqlParameter("@refid", ObjDesignTypeInput.refid);
            objParameter[11] = new SqlParameter("@childslno", ObjDesignTypeInput.childslno);
            objParameter[12] = new SqlParameter("@assignslno", ObjDesignTypeInput.assignslno);
            objParameter[13] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[13].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ItemDesignSubmitAdd", objParameter));
        }

        public int AddSizeDesignSubmitDA(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[14];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@boardheight", ObjDesignTypeInput.boardheight);
            objParameter[2] = new SqlParameter("@boardwidth", ObjDesignTypeInput.boardwidth);
            objParameter[3] = new SqlParameter("@printheight", ObjDesignTypeInput.printheight);
            objParameter[4] = new SqlParameter("@printwidth", ObjDesignTypeInput.printwidth);
            objParameter[5] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[6] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[7] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[8] = new SqlParameter("@editusercat", ObjDesignTypeInput.editusercat);
            objParameter[9] = new SqlParameter("@refid", ObjDesignTypeInput.refid);
            objParameter[10] = new SqlParameter("@sizeslno", ObjDesignTypeInput.sizeslno);
            objParameter[11] = new SqlParameter("@oldsizetype", ObjDesignTypeInput.oldsizetype);
            objParameter[12] = new SqlParameter("@newsizetype", ObjDesignTypeInput.newsizetype);
            objParameter[13] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[13].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SizeDesignSubmitAdd", objParameter));
        }

        public int PermanentDeleteDesignSubmit(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@assignslno", ObjDesignTypeInput.assignslno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteJobSubmit", objParameter));
        }

        public int DeleteItemForDesignSubmit(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteItemOfDesignSumit", objParameter));
        }

        public int DeleteSizeForDesignSubmit(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteSizeOfDesignSumit", objParameter));
        }

        public int AddDesignSubmitTrackDA(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@designsubmitslno", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@assignto", ObjAssignJobInput.assignslno);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignJobInput.remark);
            objParameter[3] = new SqlParameter("@Createuid", ObjAssignJobInput.createuid);
            objParameter[4] = new SqlParameter("@status", ObjAssignJobInput.status);
            
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("Adddesignsubmittrack", objParameter));
        }

        public int UpdateEmail(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@sendemial", ObjAssignJobInput.sendemial);
            objParameter[1] = new SqlParameter("@slno ", ObjAssignJobInput.slno);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("updateemaildesignsubmit", objParameter));
        }

        public int UpdateFinalApr(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno ", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("updatefinalapr", objParameter));
        }

        public int UpdateEmailbymanagement(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[8];
            objParameter[0] = new SqlParameter("@sendemial", ObjAssignJobInput.sendemial);
            objParameter[1] = new SqlParameter("@slno ", ObjAssignJobInput.slno);
            objParameter[2] = new SqlParameter("@ispayment ", ObjAssignJobInput.ispayment);
            objParameter[3] = new SqlParameter("@flg ", ObjAssignJobInput.flg);
            objParameter[4] = new SqlParameter("@ApprovalGivenBy ", ObjAssignJobInput.ApprovalGivenBy);
            objParameter[5] = new SqlParameter("@MgmRemark ", ObjAssignJobInput.MgmRemark);
            objParameter[6] = new SqlParameter("@LiveProductImg ", ObjAssignJobInput.LiveProductImg);
            objParameter[7] = new SqlParameter("@Out", SqlDbType.Int, 10); 
            objParameter[7].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("updateemaildesignsubmitbymanagement", objParameter));
        }
        public int LiveProductjobsReopen(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@slno ", ObjAssignJobInput.slno);

            objParameter[1] = new SqlParameter("@createuid ", ObjAssignJobInput.createuid);

            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("LiveProductjobsReopen", objParameter));
        }

        public int LiveProductjobsAccept(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@slno ", ObjAssignJobInput.slno);

            objParameter[1] = new SqlParameter("@createuid ", ObjAssignJobInput.createuid);

            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("LiveProductjobsAccept", objParameter));
        }
        public int UpdateDisapprovalbymanagement(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            
            objParameter[0] = new SqlParameter("@slno ", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@ApprovalGivenBy ", ObjAssignJobInput.ApprovalGivenBy);
            objParameter[2] = new SqlParameter("@MgmRemark ", ObjAssignJobInput.MgmRemark);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;

            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("updateemaildesignsubmitbymanagement_Disapproval", objParameter));
        }

        public int ApproveByParty(DesignSubmit.DesignSubmitProperty ObjAssignJobInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno ", ObjAssignJobInput.slno);
            objParameter[1] = new SqlParameter("@uplodepartyimg ", ObjAssignJobInput.uplodepartyimg);
            objParameter[2] = new SqlParameter("@link ", ObjAssignJobInput.link);
            objParameter[3] = new SqlParameter("@Remark ", ObjAssignJobInput.remark);
            objParameter[4] = new SqlParameter("@Action ", ObjAssignJobInput.Action);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("approvedesignsubmitbyparty", objParameter));
        }

        public int PermanentDeletepr(DesignSubmit.DesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeletehardPrinter", objParameter));
        }

        public int ApprovePrintJobDA(long Designslno, string filename, string filelink, int UserID,string Approvejobremark, int SendForPrintQty)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@UserID", UserID);
            objParameter[1] = new SqlParameter("@Designslno", Designslno);
            objParameter[2] = new SqlParameter("@filename", filename);
            objParameter[3] = new SqlParameter("@filelink", filelink);
            objParameter[4] = new SqlParameter("@Approvejobremark", Approvejobremark);
            objParameter[5] = new SqlParameter("@SendForPrintQty", SendForPrintQty);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UploadApprovePrintJobFile", objParameter));
        }

        public DataTable GetUploadPrintFileDA(long Designslno)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Designslno", Designslno);
            return (objDataAccess.ReturnDataTableWithParameters("GetUploadPrintFile", objParameter));
        }

    }
}