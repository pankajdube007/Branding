using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.FabricatorDesignSubmit
{
    public class FabricatorDesignSubmitDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllAssignedJobForFabricatorDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@fabricator", ObjDesignSubmitsingle.fabricator);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfJobForfabricator", objParameter));
        }

        public DataTable GetPendingJobsdetailsReportFabricatorDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("GetPendingJobsdetailsReportFabricator", objParameter));
        }

        public DataTable AllAssignedJobForFabricatorPODA(string Fromdate, string ToDate, int BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfJobForfabricatorForPOGeneration", objParameter));
        }

        public int UpdateRecord(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno ", ObjInput.slno);
            objParameter[1] = new SqlParameter("@status ", ObjInput.status);
            objParameter[2] = new SqlParameter("@slno ", ObjInput.sumbmitimg);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("submitdesignbyfabricator", objParameter));
        }

        public DataTable DetailSingleDesignSubmitByFabricator(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitparticularforfabricatordesignsubmit", objParameter));
        }

        public int SubmitDetailByFabricatorDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@submitimg", ObjDesignTypeInput.sumbmitimg);
            objParameter[2] = new SqlParameter("@link", ObjDesignTypeInput.link);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubmitDetailByFabricator", objParameter));
        }
        public DataTable ApprovedJobsForDCDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)

        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@fabricator", ObjDesignSubmitsingle.fabricator);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfApprovedJobsForFabricatorDC", objParameter));
        }

        public DataTable RejectedAndShortJobsForFabricatorReportDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)

        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@fabricator", ObjDesignSubmitsingle.fabricator);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfRejectedAndShortJobsForFabricatorReport", objParameter));
        }
        public DataTable SingleApprovedJobForDCDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            objParameter[1] = new SqlParameter("@fabricator", ObjDesignSubmitsingle.fabricator);
            return (objDataAccess.ReturnDataTableWithParameters("SingleApprovedJobForFabricatorDC", objParameter));
        }

        public int IsFabricatorPoGeneratedDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@Allslno", ObjDesignSubmitsingle.Allslno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("GetIsFabricatorPOgenerated", objParameter));
        }
        public int UpdateSentQtybyFabricatorDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@QtySentByFabricator", objJobSend.QtySentByFabricator);
            objParameter[1] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UpdateSentQtybyFabricator", objParameter));
        }
        public int JobSendByFabricatorDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[13];
            objParameter[0] = new SqlParameter("@Allslno", objJobSend.Allslno);
            objParameter[1] = new SqlParameter("@fabricator", objJobSend.fabricator);
            
            objParameter[2] = new SqlParameter("@LRNumber", objJobSend.LRNumber);
            objParameter[3] = new SqlParameter("@LRDate", objJobSend.LRDate);
            objParameter[4] = new SqlParameter("@TranspoterName", objJobSend.TranspoterName);
            
            objParameter[5] = new SqlParameter("@Fabfinyear", objJobSend.Fabfinyear);
            objParameter[6] = new SqlParameter("@pagename", objJobSend.pagename);
            
            objParameter[7] = new SqlParameter("@TransportMode", objJobSend.TransportMode);
            objParameter[8] = new SqlParameter("@InvoiceNumber", objJobSend.InvoiceNumber);
            objParameter[9] = new SqlParameter("@InvoiceDate", objJobSend.InvoiceDate);
            objParameter[10] = new SqlParameter("@NoofPackages", objJobSend.NoofPackages);
            objParameter[11] = new SqlParameter("@FabricatorDcRemark", objJobSend.PrinterDcRemark);
            objParameter[12] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[12].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorJobSendDC", objParameter));
        }
        public DataTable ApprovedJobsForViewDCDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@fabricator", ObjDesignSubmitsingle.fabricator);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfApprovedJobsForViewFabricatorDC", objParameter));
        }

        public DataTable FabricatorDCReportBranchDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorDCReportBranch", objParameter));
        }
        public DataTable FabricatorAccountReportHODA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorAccountReportHO", objParameter));
        }
        public DataTable FabricatorAccountReportAuditDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorAccountReportAudit", objParameter));
        }
        public DataTable FabricatorSupplierReportDA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorSuppliersReport", objParameter));
        }
        public DataTable FabricatorDCReportHODA(FabricatorDesignSubmit.FabricatorDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorDCReportHO", objParameter));
        }
        public int JobReceiveDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@JobReceiveDate", objJobSend.JobReceiveDate);
            objParameter[2] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[3] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[4] = new SqlParameter("@Actiontobetakentype", objJobSend.Actiontobetakentype);
            objParameter[5] = new SqlParameter("@RecievedQty", objJobSend.RecievedQty);
            objParameter[6] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[6].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ReceiveJobSendByFabricator", objParameter));
        }
        public int UpdateFabricatorCreditDebitJobApprove1DA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[2] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorCreditDebitJobApprove1", objParameter));
        }

        public int UpdateFabricatorCreditDebitJobApprove2DA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[2] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FabricatorCreditDebitJobApprove2", objParameter));
        }

        public int JobRejectDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.FabricatorJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@JobRejectDate", objJobSend.JobRejectDate);
            objParameter[2] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[3] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("RejectJobSendByFabricator", objParameter));
        }
    }
}