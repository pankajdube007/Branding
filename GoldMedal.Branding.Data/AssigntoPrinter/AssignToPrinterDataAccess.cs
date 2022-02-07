using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.AssigntoPrinter
{
    public class AssignToPrinterDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable DetailOfJobToPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        { 
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignlisttoassignprinter", objParameter));
        }
        public int GenaratePrinterPoInsert(AssigntoPrinter.GenaratePrinterPO ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignfabInput.slno);
            objParameter[1] = new SqlParameter("@finYear", ObjAssignfabInput.finYear);
            objParameter[2] = new SqlParameter("@branchid", ObjAssignfabInput.branchid);
            objParameter[3] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[4] = new SqlParameter("@createlogno", ObjAssignfabInput.createlogno);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("GeneratePrinterPo", objParameter));
        }
        public int CancelPrinterPoDA(AssigntoPrinter.GenaratePrinterPO ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@AssignPrinterSlno", ObjAssignfabInput.AssignPrinterSlno);
            objParameter[1] = new SqlParameter("@POChildslno", ObjAssignfabInput.POChildslno);
            objParameter[2] = new SqlParameter("@PoHeadslno", ObjAssignfabInput.PoHeadslno);
            objParameter[3] = new SqlParameter("@createuid", ObjAssignfabInput.createuid);
            objParameter[4] = new SqlParameter("@CancelRemark", ObjAssignfabInput.CancelRemark);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("CancelPrinterPO", objParameter));
        }
        public DataTable GetGenaratePrinterPODA(AssigntoPrinter.GetGenaratePrinterPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetGeneratedPrinterPO", objParameter));
        }

        public DataTable GetOtherBranchGenaratePrinterPODA(AssigntoPrinter.GetGenaratePrinterPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetOtherBranchGeneratedPrinterPO", objParameter));
        }
        public DataTable GetGenaratePrinterForCancelListPODA(AssigntoPrinter.GetGenaratePrinterPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetGeneratedPrinterPOForCancelList", objParameter));
        }

        public DataTable GetPrinterPOwithValueAuditReportDA(AssigntoPrinter.GetGenaratePrinterPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetPrinterPOwithValueAuditReport", objParameter));
        }

        public DataTable GetPrinterPOwithoutValueHoReportDA(AssigntoPrinter.GetGenaratePrinterPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetPrinterPOwithoutValueHOReport", objParameter));
        }

        public DataTable GetPrinterPOAgingReportDA(AssigntoPrinter.GetGenaratePrinterPO Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);

            return (objDataAccess.ReturnDataTableWithParameters("GetPrinterPOAgingReport", objParameter));
        }
        public DataTable DetailOfJobToReopenPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignlisttoreopenassignprinter", objParameter));
        }
        public DataTable DetailOfJobToReassignPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignlisttoreassignprinter", objParameter));
        }
        public DataTable GetApprovalDetailOfJobToPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getApprovaldetailsdesignlisttoassignprinter", objParameter));
        }
        public DataTable ApprovalDetailOfJobToPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getapprovaldesignlisttoassignprinter", objParameter));
        }

        public DataTable DetailOfApprovedDesignJobToPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getapproveddesignlisttoassignprinter", objParameter));
        }
        public DataTable DetailOfApprovedDesignJobToReassignPrinter(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getapproveddesignjoblisttoreassignprinter", objParameter));
        }
        public DataTable DetailOfJobDoneByPrinterForApproval(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getdesignsumitbyprinterforapprove", objParameter));
        }

        public DataTable AllApprovedJobsOfPrinterDA(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetApprovedJobsOfPrinter", objParameter));
        }

        

        public DataTable JobSentByPrinterToReceiveDA(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetJobSentByPrinterToReceive", objParameter));
        }

        public DataTable PrinterCreditDebitJobsToApprove1DA(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetPrinterCreditDebitJobsToApprove1", objParameter));
        }
        public DataTable PrinterCreditDebitJobsToApprove2DA(AssigntoPrinter.AssigntoPrinterProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("GetPrinterCreditDebitJobsToApprove2", objParameter));
        }


        public int ApproveDesignSubmitByPrinter(AssigntoPrinter.AssigntoPrinterProperty ObjAssignPrinterInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@slno", ObjAssignPrinterInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignPrinterInput.createuid);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ApproveDesignSubmitByPrinter", objParameter));
        }

        public int AddAssignPrinter(AssigntoPrinter.AssigntoPrinterProperty ObjAssignPrinterInput,out string PrinterEmail, out string PrinterMobile)
        {
            int success;
            SqlParameter[] objParameter = new SqlParameter[19];
            objParameter[0] = new SqlParameter("@toprinter", ObjAssignPrinterInput.toprinter);
            objParameter[1] = new SqlParameter("@designsubmitid", ObjAssignPrinterInput.designsubmitid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignPrinterInput.Remark);
            objParameter[3] = new SqlParameter("@Createuid", ObjAssignPrinterInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjAssignPrinterInput.createlogno);
            objParameter[5] = new SqlParameter("@pagename", ObjAssignPrinterInput.pagename);
            objParameter[6] = new SqlParameter("@editusercat", ObjAssignPrinterInput.editusercat);
            objParameter[7] = new SqlParameter("@reqno", ObjAssignPrinterInput.reqno);
            objParameter[8] = new SqlParameter("@finyear", ObjAssignPrinterInput.finyear);
            objParameter[9] = new SqlParameter("@JobSendType", ObjAssignPrinterInput.JobSendType);
            objParameter[10] = new SqlParameter("@PartyType", ObjAssignPrinterInput.PartyType);
            objParameter[11] = new SqlParameter("@JobSendToID", ObjAssignPrinterInput.JobSendToID);
            objParameter[12] = new SqlParameter("@JobSendToOther", ObjAssignPrinterInput.JobSendToOther);
            objParameter[13] = new SqlParameter("@SendToAddress", ObjAssignPrinterInput.SendToAddress);
            objParameter[14] = new SqlParameter("@PrintCost", ObjAssignPrinterInput.PrintCost);
            objParameter[15] = new SqlParameter("@Newprinterlocation", ObjAssignPrinterInput.newprinterlocation);
            objParameter[16] = new SqlParameter("@OutEmail", SqlDbType.NVarChar, 200);
            objParameter[16].Direction = ParameterDirection.Output;
            objParameter[17] = new SqlParameter("@OutMobile", SqlDbType.NVarChar, 50);
            objParameter[17].Direction = ParameterDirection.Output;
            objParameter[18] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[18].Direction = ParameterDirection.Output;

            success = Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AddAssignprinter", objParameter));
           
            PrinterEmail = objParameter[16].Value.ToString();
            PrinterMobile = objParameter[17].Value.ToString();
            return success;
        }

        public int ReAssignPrinter(AssigntoPrinter.AssigntoPrinterProperty ObjAssignPrinterInput, out string PrinterEmail, out string PrinterMobile)
        {
            int success;
            SqlParameter[] objParameter = new SqlParameter[19];
            objParameter[0] = new SqlParameter("@toprinter", ObjAssignPrinterInput.toprinter);
            objParameter[1] = new SqlParameter("@designsubmitid", ObjAssignPrinterInput.designsubmitid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignPrinterInput.Remark);
            objParameter[3] = new SqlParameter("@Createuid", ObjAssignPrinterInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjAssignPrinterInput.createlogno);
            objParameter[5] = new SqlParameter("@pagename", ObjAssignPrinterInput.pagename);
            objParameter[6] = new SqlParameter("@editusercat", ObjAssignPrinterInput.editusercat);
            objParameter[7] = new SqlParameter("@reqno", ObjAssignPrinterInput.reqno);
            objParameter[8] = new SqlParameter("@finyear", ObjAssignPrinterInput.finyear);
            objParameter[9] = new SqlParameter("@JobSendType", ObjAssignPrinterInput.JobSendType);
            objParameter[10] = new SqlParameter("@PartyType", ObjAssignPrinterInput.PartyType);
            objParameter[11] = new SqlParameter("@JobSendToID", ObjAssignPrinterInput.JobSendToID);
            objParameter[12] = new SqlParameter("@JobSendToOther", ObjAssignPrinterInput.JobSendToOther);
            objParameter[13] = new SqlParameter("@SendToAddress", ObjAssignPrinterInput.SendToAddress);
            objParameter[14] = new SqlParameter("@PrintCost", ObjAssignPrinterInput.PrintCost);
            objParameter[15] = new SqlParameter("@Newprinterlocation", ObjAssignPrinterInput.newprinterlocation);
            objParameter[16] = new SqlParameter("@OutEmail", SqlDbType.NVarChar, 200);
            objParameter[16].Direction = ParameterDirection.Output;
            objParameter[17] = new SqlParameter("@OutMobile", SqlDbType.NVarChar, 50);
            objParameter[17].Direction = ParameterDirection.Output;
            objParameter[18] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[18].Direction = ParameterDirection.Output;

            success = Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ReAssignprinter", objParameter));

            PrinterEmail = objParameter[16].Value.ToString();
            PrinterMobile = objParameter[17].Value.ToString();
            return success;
        }

        public int DeleteAssignedPrinterForJobDA(AssigntoPrinter.AssigntoPrinterProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AssigenedPrinterForJobDelete", objParameter));
        }

        public DataTable AllAssignedPrinterForJobDA()
        {
            return (objDataAccess.ReturnDataTable("Assighnedjobtoprinter"));
        }
        public DataTable AllAssignedPrinterForJobDAUser(AssigntoPrinter.AssigntoPrinterProperty ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", ObjDesignTypesingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("Assighnedjobtoprinter", objParameter));
        }

        public DataTable PriReqno(AssigntoPrinter.AssigntoPrinterProperty ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@comman", ObjDesignTypesingle.comman);
            objParameter[1] = new SqlParameter("@type", ObjDesignTypesingle.type);
            return (objDataAccess.ReturnDataTableWithParameters("GetPrifabreqno", objParameter));
        }
    }
}