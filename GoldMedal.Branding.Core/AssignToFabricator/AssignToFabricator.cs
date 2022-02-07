using GoldMedal.Branding.Service.AssignToFabricator;
using System.Data;

namespace GoldMedal.Branding.Core.AssignToFabricator
{
    public class AssignToFabricator : IAssignToFabricator
    {
        public DataTable ListOfJobForAssignToFabricator(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.ListOfJobForAssignToFabricatorServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetGenarateFabricatorPO(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetGenarateFabricatorPOServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetGenarateFabricatorPOForCancelList(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetGenarateFabricatorPOForCancelListServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorPOwithValueAudit(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetFabricatorPOwithValueAuditServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorPOwithoutValueHO(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetFabricatorPOwithoutValueHOServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetFabricatorPOAgingReport(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GetGenarateFabricatorPO dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetFabricatorPOAgingReportServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable ListOfJobForAssignToFabricatorSendByPrinter(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.ListOfJobForAssignToFabricatorSendByPrinterServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int AssignFabricatorInsertMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti)
        {
            int recid = 0;

            recid = AssignToFabricatorServiceCall.AssignFabricatorInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int GenerateFabricatorPOInsertMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO dti)
        {
            int recid = 0;

            recid = AssignToFabricatorServiceCall.GenerateFabricatorPOInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public int CancelFabricatorPo(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.GenarateFabricatorPO dti)
        {
            int recid = 0;

            recid = AssignToFabricatorServiceCall.CancelFabricatorPoServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int AssignedfabricatorDeleteMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti)
        {
            int recid = 0;

            recid = AssignToFabricatorServiceCall.AssignedfabricatorDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable AllAssignedfabricatorDACore()
        {
            DataTable result = new DataTable();
            result = AssignToFabricatorServiceCall.AllAssignedfabricatorServiceMethod("MSSQLSERVER");
            return result;
        }
        public DataTable AllAssignedfabricatorDACoreUser(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti)
        {
            DataTable result = new DataTable();
            result = AssignToFabricatorServiceCall.AllAssignedfabricatorServiceMethodUser(dti,"MSSQLSERVER");
           // result = AssignToFabricatorServiceCall.AllAssignedfabricatorServiceMethod( "MSSQLSERVER");
            return result;
        }

        public DataTable DetailOfJobDoneByFabricatorForApproval(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.DetailOfJobDoneByFabricatorForApprovalUserServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetAllApprovedFabricatorJobs(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetAllApprovedFabricatorJobsServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public int ApproveDesignSubmitByFabricatorMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti)
        {
            int recid = 0;

            recid = AssignToFabricatorServiceCall.ApproveDesignSubmitByFabricatorServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetJobSentByFabricatorToReceive(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.JobSentByFabricatorToReceiveServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorCreditDebitJobsToApprove1(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetFabricatorCreditDebitJobsToApprove1ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetFabricatorCreditDebitJobsToApprove2(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.GetFabricatorCreditDebitJobsToApprove2ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSingleForReceiveDC(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.SingleJobForReceiveServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetSingleFabricatorCreditDebitJobForApprove1(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.SingleFabricatorCreditDebitJobForApprove1ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
        public DataTable GetSingleFabricatorCreditDebitJobForApprove2(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle)
        {
            DataTable recid = new DataTable();
            recid = AssignToFabricatorServiceCall.SingleFabricatorCreditDebitJobForApprove2ServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    } 
}