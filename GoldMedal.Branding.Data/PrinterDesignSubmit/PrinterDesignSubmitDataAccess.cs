using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.PrinterDesignSubmit
{
    public class PrinterDesignSubmitDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllAssignedJobForPrinterDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@printer", ObjDesignSubmitsingle.printer);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfJobForPrinter", objParameter));
        }

        public DataTable GetPendingJobReportForPrinterDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("GetPendingJobsdetailsReportPrinter", objParameter));
        }
        public DataTable AllAssignedJobForPrinterPODA(string Fromdate, string ToDate, int BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfJobForPrinterForPOGeneration", objParameter));
        }
       
        public DataTable AllSubmittedJobForPrinterDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@printer", ObjDesignSubmitsingle.printer);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfSubmittedJobForPrinter", objParameter));
        }

        public DataTable ApprovedJobsForDCDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@printer", ObjDesignSubmitsingle.printer);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfApprovedJobsForPrinterDC", objParameter));
        }

        public DataTable RejectedAndShortJobsForPrinterDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@printer", ObjDesignSubmitsingle.printer);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfRejectedAndShortJobsForPrinterReport", objParameter));
        }


        public DataTable ApprovedJobsForViewDCDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@printer", ObjDesignSubmitsingle.printer);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfApprovedJobsForViewPrinterDC", objParameter));
        }

        public DataTable PrinterDCReportBranchDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterDCReportBranch", objParameter));
        }
        public DataTable PrinterSupplierReportDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterSuppliersReport", objParameter));
        }
        public DataTable PrinterDCReportHODA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterDCReportHO", objParameter));
        }
        public DataTable PrinterAccountReportHODA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterAccountReportHO", objParameter));
        }
        public DataTable PrinterAccountReportAuditDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterAccountReportAudit", objParameter));
        }

        public DataTable SingleApprovedJobForDCDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            objParameter[1] = new SqlParameter("@printer", ObjDesignSubmitsingle.printer);
            return (objDataAccess.ReturnDataTableWithParameters("SingleApprovedJobForPrinterDC", objParameter));
        }
        public int IsPrinterPoGeneratedDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@Allslno", ObjInput.Allslno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("GetIsPrinterPOgenerated", objParameter));
        }
        public DataTable SingleJobForReceiveDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SingleJobForReceiveDC", objParameter));
        }

        public DataTable SinglePrinterCreditDebitJobForApprove1DA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SinglePrinterCreditDebitJobForApprove1", objParameter));
        }

        public DataTable SinglePrinterCreditDebitJobForApprove2DA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SinglePrinterCreditDebitJobForApprove2", objParameter));
        }

        public int UpdateRecord(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno ", ObjInput.slno);
            objParameter[1] = new SqlParameter("@status ", ObjInput.status);
            objParameter[2] = new SqlParameter("@slno ", ObjInput.sumbmitimg);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("submitdesignbyprinter", objParameter));
        }

        public DataTable DetailSingleDesignSubmitByPrinter(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignSubmitsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsubmitparticularforprinterdesignsubmit", objParameter));
        }

        public int SubmitDetailByPrinterDA(PrinterDesignSubmit.PrinterDesignSubmitProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@submitimg", ObjDesignTypeInput.sumbmitimg);
            objParameter[2] = new SqlParameter("@link", ObjDesignTypeInput.link);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SubmitDetailByPrinter", objParameter));
        }

        public int JobSendByPrinterDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[14];
            objParameter[0] = new SqlParameter("@Allslno", objJobSend.Allslno);
            objParameter[1] = new SqlParameter("@printer", objJobSend.printer);
           // objParameter[2] = new SqlParameter("@JobSendType", objJobSend.JobSendType);
           // objParameter[3] = new SqlParameter("@PartyType", objJobSend.PartyType);
          //  objParameter[4] = new SqlParameter("@JobSendToID", objJobSend.JobSendToID);
           // objParameter[3] = new SqlParameter("@JobSendToOther", objJobSend.JobSendToOther);
           // objParameter[4] = new SqlParameter("@SendToAddress", objJobSend.SendToAddress);
            objParameter[2] = new SqlParameter("@LRNumber", objJobSend.LRNumber);
            objParameter[3] = new SqlParameter("@LRDate", objJobSend.LRDate);
            objParameter[4] = new SqlParameter("@TranspoterName", objJobSend.TranspoterName);
           // objParameter[5] = new SqlParameter("@FabDesignSubmitID", objJobSend.FabDesignSubmitID);
            //objParameter[9] = new SqlParameter("@FabRemark", objJobSend.FabRemark);
            //objParameter[6] = new SqlParameter("@FabJobReqNo", objJobSend.FabJobReqNo);
            objParameter[5] = new SqlParameter("@Fabfinyear", objJobSend.Fabfinyear);
            objParameter[6] = new SqlParameter("@pagename", objJobSend.pagename);
            objParameter[7] = new SqlParameter("@FabricationCost", objJobSend.FabricationCost);
            objParameter[8] = new SqlParameter("@TransportMode", objJobSend.TransportMode);
            objParameter[9] = new SqlParameter("@InvoiceNumber", objJobSend.InvoiceNumber);
            objParameter[10] = new SqlParameter("@InvoiceDate", objJobSend.InvoiceDate);
            objParameter[11] = new SqlParameter("@NoofPackages", objJobSend.NoofPackages);
            objParameter[12] = new SqlParameter("@PrinterDcRemark", objJobSend.PrinterDcRemark);
            objParameter[13] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[13].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterJobSendDC_New", objParameter));
        }

        public int UpdateSentQtybyPrinterDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@QtySentByPrinter", objJobSend.QtySentByPrinter);
            objParameter[1] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UpdateSentQtybyPrinter", objParameter));
        }
        public int JobReceiveDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend objJobSend)
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
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ReceiveJobSendByPrinter", objParameter));
        }

        public int UpdatePrinterCreditDebitJobApprove1DA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[2] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterCreditDebitJobApprove1", objParameter));
        }

        public int UpdatePrinterCreditDebitJobApprove2DA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[2] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrinterCreditDebitJobApprove2", objParameter));
        }

        public int JobRejectDA(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.PrinterJobDCSend objJobSend)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@slno", objJobSend.slno);
            objParameter[1] = new SqlParameter("@JobRejectDate", objJobSend.JobRejectDate);
            objParameter[2] = new SqlParameter("@createlogno", objJobSend.createlogno);
            objParameter[3] = new SqlParameter("@createuid", objJobSend.createuid);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("RejectJobSendByPrinter", objParameter));
        }
    }
}