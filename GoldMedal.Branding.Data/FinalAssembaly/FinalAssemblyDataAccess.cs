using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.FinalAssembaly
{
    public class FinalAssemblyDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable ListOfJobForFinlaAssembly(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthefinalassembly", objParameter));
        }
        public DataTable ListOfJobForFinlaAssemblyModeUpdateDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthefinalassembalymodeupdate", objParameter));
        }
        public DataTable DispatchListOfJobForFinlaAssemblyModeUpdateDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthefinalassembalymodeDistpatchList", objParameter));
        }
        public DataTable ListOfJobForFinlaAssemblyDispatchModeDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthefinalassembalydispatchmode", objParameter));
        }
        public DataTable ListOfJobForPOGenerationDispatchModeDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", Objsingle.branchID);
            objParameter[1] = new SqlParameter("@Fromdate", Objsingle.Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", Objsingle.ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfJobForDispatchModePOGeneration", objParameter));
        }

        public DataTable ListOfJobForFinlaAssemblySelfInstallationModeDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthefinalassembalyselfinstallationmode", objParameter));
        }

        public DataTable ListOfJobForFinlaAssemblyVendorModeDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthefinalassembalyvendormode", objParameter));
        }
        public DataTable ListOfDispatchModeDA(int Mode)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@Mode", Mode);
           
            return (objDataAccess.ReturnDataTableWithParameters("Getlistofdispatchmode", objParameter));
        }
        public DataTable GetJoblisttoacceptforfinalassemblyDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJoblisttoacceptforfinalassembly", objParameter));
        }

        

        public DataTable ListOfJobForJobCloser(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthejobcloser", objParameter));
        }

        public DataTable ListOfApprovedJobForJobCloser(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getApprovedJobdetailforthejobcloser", objParameter));
        }

        public DataTable ListOfPrintedJobForJobCloser(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getPrintedJobdetailforthejobcloser", objParameter));
        }
        public DataTable DetailOfItemListForFinalAssemblyDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("getitemlistforFinalAssembly", objParameter));
        }

        public int SubmitFinalAssembly(FinalAssembaly.FinalAssembly.FinalAssemblyProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@submitdesign", ObjAssignfabInput.submitdesign);
            objParameter[1] = new SqlParameter("@designsubmitid", ObjAssignfabInput.designsubmitid);
            objParameter[2] = new SqlParameter("@assignfabid", ObjAssignfabInput.assignfabid);
            objParameter[3] = new SqlParameter("@Remark", ObjAssignfabInput.Remark);
            objParameter[4] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[5] = new SqlParameter("@Createlogno", ObjAssignfabInput.createlogno);
            objParameter[6] = new SqlParameter("@pagename", ObjAssignfabInput.pagename);
            objParameter[7] = new SqlParameter("@editusercat", ObjAssignfabInput.editusercat);
            objParameter[8] = new SqlParameter("@link", ObjAssignfabInput.link);
            objParameter[9] = new SqlParameter("@SubmitStatus", ObjAssignfabInput.SubmitStatus);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("AddFinalAssembly", objParameter));
        }
        public DataTable GetDispatchTeamDA()
        {
            return (objDataAccess.ReturnDataTable("DispatchTeamUserList"));

        }
        public int AddDispatchTeamDA(FinalAssembaly.FinalAssembly.DispatchTeamInsert ObjDispatchTeamInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
           
            objParameter[0] = new SqlParameter("@Name", ObjDispatchTeamInput.Name);
            objParameter[1] = new SqlParameter("@emailid", ObjDispatchTeamInput.emailid);
            objParameter[2] = new SqlParameter("@mobile", ObjDispatchTeamInput.mobile);
            objParameter[3] = new SqlParameter("@Createuid", ObjDispatchTeamInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjDispatchTeamInput.createlogno);
            objParameter[5] = new SqlParameter("@slno", ObjDispatchTeamInput.slno);
            objParameter[6] = new SqlParameter("@branch", ObjDispatchTeamInput.branch);
            objParameter[7] = new SqlParameter("@usernm", ObjDispatchTeamInput.usernm);
            objParameter[8] = new SqlParameter("@password", ObjDispatchTeamInput.password);
            objParameter[9] = new SqlParameter("@Status", ObjDispatchTeamInput.Status);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DispatchTeamAddUpdate", objParameter));
        }
        public int DeleteDispatchTeamDA(FinalAssembaly.FinalAssembly.DispatchTeamDelete ObjDispatchTeamInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDispatchTeamInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjDispatchTeamInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjDispatchTeamInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DispatchTeamUserDelete", objParameter));
        }
        public DataTable SingleDispatchTeamUserDA(FinalAssembaly.FinalAssembly.DispatchTeamInsert ObjDispatchTeamsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDispatchTeamsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("DispatchTeamUserSelectParticular", objParameter));
        }

        public DataTable GetSelfInstallationTeamDA()
        {
            return (objDataAccess.ReturnDataTable("SelfInstallationTeamUserList"));

        }
        public int AddSelfInstallationTeamDA(FinalAssembaly.FinalAssembly.SelfInstallationTeamInsert ObjSelfInstallationTeamInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];

            objParameter[0] = new SqlParameter("@Name", ObjSelfInstallationTeamInput.Name);
            objParameter[1] = new SqlParameter("@emailid", ObjSelfInstallationTeamInput.emailid);
            objParameter[2] = new SqlParameter("@mobile", ObjSelfInstallationTeamInput.mobile);
            objParameter[3] = new SqlParameter("@Createuid", ObjSelfInstallationTeamInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjSelfInstallationTeamInput.createlogno);
            objParameter[5] = new SqlParameter("@slno", ObjSelfInstallationTeamInput.slno);
            objParameter[6] = new SqlParameter("@branch", ObjSelfInstallationTeamInput.branch);
            objParameter[7] = new SqlParameter("@usernm", ObjSelfInstallationTeamInput.usernm);
            objParameter[8] = new SqlParameter("@password", ObjSelfInstallationTeamInput.password);
            objParameter[9] = new SqlParameter("@Status", ObjSelfInstallationTeamInput.Status);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SelfInstallationTeamAddUpdate", objParameter));
        }
        public int DeleteSelfInstallationTeamDA(FinalAssembaly.FinalAssembly.SelfInstallationTeamDelete ObjSelfInstallationTeamInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjSelfInstallationTeamInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjSelfInstallationTeamInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjSelfInstallationTeamInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("SelfInstallationTeamUserDelete", objParameter));
        }
        public DataTable SingleSelfInstallationTeamUserDA(FinalAssembaly.FinalAssembly.SelfInstallationTeamInsert ObjSelfInstallationsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjSelfInstallationsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("SelfInstallationTeamUserSelectParticular", objParameter));
        }

        public DataTable GetVendorTeamDA()
        {
            return (objDataAccess.ReturnDataTable("VendorTeamUserList"));

        }
        public int AddVendorTeamDA(FinalAssembaly.FinalAssembly.VendorTeamInsert ObjVendorTeamInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];

            objParameter[0] = new SqlParameter("@Name", ObjVendorTeamInput.Name);
            objParameter[1] = new SqlParameter("@emailid", ObjVendorTeamInput.emailid);
            objParameter[2] = new SqlParameter("@mobile", ObjVendorTeamInput.mobile);
            objParameter[3] = new SqlParameter("@Createuid", ObjVendorTeamInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjVendorTeamInput.createlogno);
            objParameter[5] = new SqlParameter("@slno", ObjVendorTeamInput.slno);
            objParameter[6] = new SqlParameter("@branch", ObjVendorTeamInput.branch);
            objParameter[7] = new SqlParameter("@usernm", ObjVendorTeamInput.usernm);
            objParameter[8] = new SqlParameter("@password", ObjVendorTeamInput.password);
            objParameter[9] = new SqlParameter("@Status", ObjVendorTeamInput.Status);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("VendorTeamAddUpdate", objParameter));
        }
        public int DeleteVendorTeamDA(FinalAssembaly.FinalAssembly.VendorTeamDelete ObjVendorTeamInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjVendorTeamInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjVendorTeamInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjVendorTeamInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("VendorTeamUserDelete", objParameter));
        }
        public DataTable SingleVendorTeamUserDA(FinalAssembaly.FinalAssembly.VendorTeamInsert ObjVendorsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjVendorsingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("VendorTeamUserSelectParticular", objParameter));
        }
        public int AddItemFinalAssemblyDA(FinalAssembly.FinalAssemblyProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Itemid", ObjDesignTypeInput.itemid);
            objParameter[2] = new SqlParameter("@Qty", ObjDesignTypeInput.qty);
            objParameter[3] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[4] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[5] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[6] = new SqlParameter("@editusercat", ObjDesignTypeInput.editusercat);
            objParameter[7] = new SqlParameter("@refid", ObjDesignTypeInput.refid);
            objParameter[8] = new SqlParameter("@childslno", ObjDesignTypeInput.childslno);
            objParameter[9] = new SqlParameter("@assignfabid", ObjDesignTypeInput.assignfabid);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10); 
             objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ItemFinalAssemblyAdd", objParameter));
        }
        public int DeleteItemForFinalAssembly(FinalAssembly.FinalAssemblyProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteItemOfFinalAssembly", objParameter));
        }

        public int UpdateModeOfFinalAssemblyDA(FinalAssembly.FinalAssemblyProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Modeofdispatch", ObjDesignTypeInput.childslno);
            objParameter[2] = new SqlParameter("@Dispatchedby", ObjDesignTypeInput.Dispatchedby);
            objParameter[3] = new SqlParameter("@createuid ", ObjDesignTypeInput.createuid);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UpdateModeOfFinalAssembly", objParameter));
        }

        public int UpdateDispatchDetailsOfFinalAssemblyDA(FinalAssembly.FinalAssemblyProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[13];
            objParameter[0] = new SqlParameter("@Allslno", ObjDesignTypeInput.Allslno);
            objParameter[1] = new SqlParameter("@uid", ObjDesignTypeInput.uid);
            objParameter[2] = new SqlParameter("@LRNumber", ObjDesignTypeInput.LRNumber);
            objParameter[3] = new SqlParameter("@LRDate", ObjDesignTypeInput.LRDate);
            objParameter[4] = new SqlParameter("@TranspoterName", ObjDesignTypeInput.TranspoterName);
            objParameter[5] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[6] = new SqlParameter("@TransportMode", ObjDesignTypeInput.TransportMode);
            objParameter[7] = new SqlParameter("@InvoiceNumber", ObjDesignTypeInput.InvoiceNumber);
            objParameter[8] = new SqlParameter("@InvoiceDate", ObjDesignTypeInput.InvoiceDate);
            objParameter[9] = new SqlParameter("@NoofPackages", ObjDesignTypeInput.NoofPackages);
            objParameter[10] = new SqlParameter("@Remark", ObjDesignTypeInput.Remark);
            objParameter[11] = new SqlParameter("@TotalBoardQty", ObjDesignTypeInput.TotalBoardQty);
            objParameter[12] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[12].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FinalAssembalyDispatchDetailsUpdate", objParameter));
        }

        public int UpdateSelfInstallationDetailsOfFinalAssemblyDA(FinalAssembly.FinalAssemblyProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[13];
            objParameter[0] = new SqlParameter("@Allslno", ObjDesignTypeInput.Allslno);
            objParameter[1] = new SqlParameter("@uid", ObjDesignTypeInput.uid);
            objParameter[2] = new SqlParameter("@LRNumber", ObjDesignTypeInput.LRNumber);
            objParameter[3] = new SqlParameter("@LRDate", ObjDesignTypeInput.LRDate);
            objParameter[4] = new SqlParameter("@TranspoterName", ObjDesignTypeInput.TranspoterName);
            objParameter[5] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[6] = new SqlParameter("@TransportMode", ObjDesignTypeInput.TransportMode);
            objParameter[7] = new SqlParameter("@InvoiceNumber", ObjDesignTypeInput.InvoiceNumber);
            objParameter[8] = new SqlParameter("@InvoiceDate", ObjDesignTypeInput.InvoiceDate);
            objParameter[9] = new SqlParameter("@NoofPackages", ObjDesignTypeInput.NoofPackages);
            objParameter[10] = new SqlParameter("@Remark", ObjDesignTypeInput.Remark);
            objParameter[11] = new SqlParameter("@TotalBoardQty", ObjDesignTypeInput.TotalBoardQty);
            objParameter[12] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[12].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FinalAssembalySelfInstallationDetailsUpdate", objParameter));
        }

        public int UpdateVendorDetailsOfFinalAssemblyDA(FinalAssembly.FinalAssemblyProperty ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[13];
            objParameter[0] = new SqlParameter("@Allslno", ObjDesignTypeInput.Allslno);
            objParameter[1] = new SqlParameter("@uid", ObjDesignTypeInput.uid);
            objParameter[2] = new SqlParameter("@LRNumber", ObjDesignTypeInput.LRNumber);
            objParameter[3] = new SqlParameter("@LRDate", ObjDesignTypeInput.LRDate);
            objParameter[4] = new SqlParameter("@TranspoterName", ObjDesignTypeInput.TranspoterName);
            objParameter[5] = new SqlParameter("@pagename", ObjDesignTypeInput.pagename);
            objParameter[6] = new SqlParameter("@TransportMode", ObjDesignTypeInput.TransportMode);
            objParameter[7] = new SqlParameter("@InvoiceNumber", ObjDesignTypeInput.InvoiceNumber);
            objParameter[8] = new SqlParameter("@InvoiceDate", ObjDesignTypeInput.InvoiceDate);
            objParameter[9] = new SqlParameter("@NoofPackages", ObjDesignTypeInput.NoofPackages);
            objParameter[10] = new SqlParameter("@Remark", ObjDesignTypeInput.Remark);
            objParameter[11] = new SqlParameter("@TotalBoardQty", ObjDesignTypeInput.TotalBoardQty);
            objParameter[12] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[12].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("FinalAssembalyVendorDetailsUpdate", objParameter));
        }
        public int JobsAcceptForFinalAssemblyDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@slno ", ObjAssignfabInput.slno);

            objParameter[1] = new SqlParameter("@createuid ", ObjAssignfabInput.createuid);

            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobsAcceptForFinalAssembly", objParameter));
        }

        public int JobCloser(FinalAssembaly.FinalAssembly.FinalAssemblyProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignfabInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignfabInput.Remark);
            objParameter[3] = new SqlParameter("@InstallationDate", ObjAssignfabInput.InstallationDate);
            objParameter[4] = new SqlParameter("@JobCloserImg", ObjAssignfabInput.JobCloserImg);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobCloser", objParameter));
        }

        public int ApprovedJobCloser(FinalAssembaly.FinalAssembly.FinalAssemblyProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignfabInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignfabInput.Remark);
            objParameter[3] = new SqlParameter("@InstallationDate", ObjAssignfabInput.InstallationDate);
            objParameter[4] = new SqlParameter("@JobCloserImg", ObjAssignfabInput.JobCloserImg);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("ApprovedJobCloser", objParameter));
        }

        public int PrintedJobCloser(FinalAssembaly.FinalAssembly.FinalAssemblyProperty ObjAssignfabInput)
        {
            SqlParameter[] objParameter = new SqlParameter[6];
            objParameter[0] = new SqlParameter("@slno", ObjAssignfabInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjAssignfabInput.createuid);
            objParameter[2] = new SqlParameter("@Remark", ObjAssignfabInput.Remark);
            objParameter[3] = new SqlParameter("@InstallationDate", ObjAssignfabInput.InstallationDate);
            objParameter[4] = new SqlParameter("@JobCloserImg", ObjAssignfabInput.JobCloserImg);
            objParameter[5] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[5].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("PrintedJobCloser", objParameter));
        }
        

        public DataTable ListOfJobForJobHistory(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            objParameter[2] = new SqlParameter("@FromDate", Objsingle.Fromdate);
            objParameter[3] = new SqlParameter("@ToDate", Objsingle.ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("getJobdetailforthejobhistory", objParameter));
        }


        public DataTable ConsolidatedConsumptionRpt(String FromDate , String ToDate)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@FromDate", FromDate);
            objParameter[1] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("ConsolidatedConsumptionRpt", objParameter));
        }

        public DataTable GetJobAgingReportDA(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
           
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            
            return (objDataAccess.ReturnDataTableWithParameters("GetJobAgingReport", objParameter));
        }
        public DataTable ListOfCancelledJobForJobHistory(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);
            objParameter[1] = new SqlParameter("@uid", Objsingle.userid);
            objParameter[2] = new SqlParameter("@FromDate", Objsingle.Fromdate);
            objParameter[3] = new SqlParameter("@ToDate", Objsingle.ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("getCancelledJobdetailforthejobhistory", objParameter));
        }
        public DataTable AllJobCountDA(string Fromdate, string ToDate, string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetAllJobsCount", objParameter));
        }
        
        public DataTable ListOfDisapprovedJobRequestsDA(string Fromdate, string ToDate, string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetListOfDisapprovedJobRequests", objParameter));
        }
        public DataTable ListOfJobRequestForJobReportDA(string Fromdate, string ToDate, string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetListOfJobRequestForJobReport", objParameter));
        }
        public DataTable ListOfAssignToDesignerJobRequestForJobReportDA(string Fromdate, string ToDate, string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetListOfAssignToDesignerJobRequestForJobReport", objParameter));
        }

        public DataTable ListOfAssignToPrinterJobRequestForJobReportDA(string Fromdate, string ToDate, string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetListOfAssignToPrinterJobRequestForJobReport", objParameter));
        }

        public DataTable ListOfAssignToFabricatorJobRequestForJobReportDA(string Fromdate, string ToDate, string BranchIDs)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@BranchIDs", BranchIDs);
            objParameter[1] = new SqlParameter("@Fromdate", Fromdate);
            objParameter[2] = new SqlParameter("@ToDate", ToDate);
            return (objDataAccess.ReturnDataTableWithParameters("GetListOfAssignToFabricatorJobRequestForJobReport", objParameter));
        }

        public DataTable GetJobDetailsByQRCode(long Slno, string QRCode)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@Slno", Slno);
            objParameter[1] = new SqlParameter("@QRCode", QRCode);
            return (objDataAccess.ReturnDataTableWithParameters("GetJobDetailsByQRCode", objParameter));
        }

        public DataTable GetOverdueJobs(FinalAssembaly.FinalAssembly.FinalAssemblyProperty Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
           
            objParameter[0] = new SqlParameter("@uid", Objsingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("OverdueJobsReport", objParameter));
        }

        public DataTable GetUserLoginDetails(string Fromdate)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@FromDate", Fromdate);
            return (objDataAccess.ReturnDataTableWithParameters("UserLoginDetailsReport", objParameter));
        }

        public string DispatchTeamLogin(FinalAssembly.TeamsLogin DispatchTeamLogin)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@usernm", DispatchTeamLogin.usernm);
            objParameter[1] = new SqlParameter("@password", DispatchTeamLogin.password);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.VarChar, 200);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("DispatchTeamLogin", objParameter));
        }

        public string SelfInstallationTeamLogin(FinalAssembly.TeamsLogin SelfInstallationLogin)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@usernm", SelfInstallationLogin.usernm);
            objParameter[1] = new SqlParameter("@password", SelfInstallationLogin.password);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.VarChar, 200);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("SelfInstallationTeamLogin", objParameter));
        }
        public string VendorTeamLogin(FinalAssembly.TeamsLogin VendorLogin)
        {
            SqlParameter[] objParameter = new SqlParameter[3];

            objParameter[0] = new SqlParameter("@usernm", VendorLogin.usernm);
            objParameter[1] = new SqlParameter("@password", VendorLogin.password);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.VarChar, 200);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("VendorTeamLogin", objParameter));
        }


        public DataTable GetPasswordDA(string Username,string NewPassword, int Category)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@Username", Username);
            objParameter[1] = new SqlParameter("@NewPassword", NewPassword);
            objParameter[2] = new SqlParameter("@CategoryID", Category);
            return (objDataAccess.ReturnDataTableWithParameters("GetNewPassword", objParameter));
        }
    }
}