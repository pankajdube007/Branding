using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.JobRequest
{
    public class JobRequestDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        #region Get

        public DataTable AllJobRequestHeadDA()
        {
            return (objDataAccess.ReturnDataTable("JobRequestList"));
        }

        public DataTable AllSalesExecutive()
        {
            return (objDataAccess.ReturnDataTable("GetAllSalesExecutive"));
        }

        public DataTable AllJobRequestHeadDABranch(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@userbranchid", ObjDesignTypesingle.userbranchid);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestList", objParameter));
        }

        public DataTable AllName(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@userbranchid", ObjDesignTypesingle.userbranchid);
            objParameter[2] = new SqlParameter("@userid", ObjDesignTypesingle.userid);
            objParameter[3] = new SqlParameter("@Statecheck", ObjDesignTypesingle.Statecheck);
            return (objDataAccess.ReturnDataTableWithParameters("getnamefornametype", objParameter));
        }

        public DataTable AllSubName(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@nameid", ObjDesignTypesingle.nameid);
            objParameter[2] = new SqlParameter("@Statecheck", ObjDesignTypesingle.Statecheck);
            objParameter[3] = new SqlParameter("@userid", ObjDesignTypesingle.userid);
            return (objDataAccess.ReturnDataTableWithParameters("getsubnamefornametypeandname", objParameter));
        }
        public DataTable GetDealerJobHistoryDA(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
           
            objParameter[0] = new SqlParameter("@NameId", ObjDesignTypesingle.nameid);
            return (objDataAccess.ReturnDataTableWithParameters("GetDealerJobHistory", objParameter));
        }
        public DataTable GetRetailerJobHistoryDA(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];

            objParameter[0] = new SqlParameter("@SubNameId", ObjDesignTypesingle.SubNameId);
            return (objDataAccess.ReturnDataTableWithParameters("GetRetailerJobHistory", objParameter));
        }

        public DataTable AllAddressContact(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@nameid", ObjDesignTypesingle.nameid);
            return (objDataAccess.ReturnDataTableWithParameters("getaddressforname", objParameter));
        }

        public int SavePageLog(string PageValue, string PageName)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@PageValue", PageValue);
            objParameter[1] = new SqlParameter("@LineNo", PageName);
            return Convert.ToInt16(objDataAccess.ExecuteNonQueryWithParameters("CreatePageLog", objParameter));
        }

        public DataTable AllSubAddress(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@SubNameId", ObjDesignTypesingle.SubNameId);

            return (objDataAccess.ReturnDataTableWithParameters("getsubaddressforsubname", objParameter));
        }

        public DataTable AllSubEmail(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@SubNameId", ObjDesignTypesingle.SubNameId);

            return (objDataAccess.ReturnDataTableWithParameters("getsubemailforsubname", objParameter));
        }

        public DataTable AllSubmittedby(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            return (objDataAccess.ReturnDataTable("SalesExecutiveList"));
        }

        public DataTable AllBranch(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            return (objDataAccess.ReturnDataTable("BranchList"));
        }

        public DataSet SelectedBranch(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@UserId", ObjDesignTypesingle.userid);
            return (objDataAccess.ReturnDatasetWithParameters("SelectedBranch", objParameter));
           
        }

        public DataTable AllSubContact(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@SubNameId", ObjDesignTypesingle.SubNameId);
            return (objDataAccess.ReturnDataTableWithParameters("getsubcontactforsubname", objParameter));
        }

        public DataTable AllEmail(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@addressid", ObjDesignTypesingle.addressid);
            return (objDataAccess.ReturnDataTableWithParameters("getemailforaddress", objParameter));
        }

        public DataTable AllContactDetail(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@nameid", ObjDesignTypesingle.nameid);
            return (objDataAccess.ReturnDataTableWithParameters("getcontactdetailname", objParameter));
        }
        public DataTable AllGstNo(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@nameid", ObjDesignTypesingle.nameid);
            return (objDataAccess.ReturnDataTableWithParameters("getgstno", objParameter));
        }
        public DataTable JobRequestHeadSelectParticular(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestHeadSelectParticular", objParameter));
        }

        public DataTable JobRequestChildSelectParticular(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestChildSelectParticular", objParameter));
        }

        public DataTable JobRequestChildOnly(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@childslno", ObjDesignTypesingle.childslno);
            return (objDataAccess.ReturnDataTableWithParameters("JobRequestonlyChilddeatild", objParameter));
        }

        public DataTable JobRequestChildFilesDA(JobRequestModel.JobRequestProperties ObjJobTypeMappingsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypeMappingsingle.slno);
            objParameter[1] = new SqlParameter("@Flag", ObjJobTypeMappingsingle.flag);
            return (objDataAccess.ReturnDataTableWithParameters("GetJobRequestFiles", objParameter));
        }

        public DataTable LiveProductFilesDA(JobRequestModel.JobRequestProperties ObjJobTypeMappingsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypeMappingsingle.slno);
            objParameter[1] = new SqlParameter("@Flag", ObjJobTypeMappingsingle.flag);
            return (objDataAccess.ReturnDataTableWithParameters("GetLiveProductFiles", objParameter));
        }

        

        #endregion Get

        #region Add

        public int AddUpdateJobRequesHeadtDA(JobRequestModel.JobRequestProperties ObjJobRequestInput)
        {
            SqlParameter[] objParameter = new SqlParameter[28];
          //  objParameter[0] = new SqlParameter("@reqno", ObjJobRequestInput.reqno);
            objParameter[0] = new SqlParameter("@NameTypeId", ObjJobRequestInput.NameTypeId);
            objParameter[1] = new SqlParameter("@NameId", ObjJobRequestInput.NameId);
            objParameter[2] = new SqlParameter("@Address", ObjJobRequestInput.Address);
            objParameter[3] = new SqlParameter("@ContactPerson", ObjJobRequestInput.ContactPerson);
            objParameter[4] = new SqlParameter("@Email", ObjJobRequestInput.Email);
            objParameter[5] = new SqlParameter("@ContactNumber", ObjJobRequestInput.ContactNumber);
            objParameter[6] = new SqlParameter("@RequestDate", ObjJobRequestInput.RequestDate);
            objParameter[7] = new SqlParameter("@SubNameId", ObjJobRequestInput.SubNameId);
            objParameter[8] = new SqlParameter("@SubAddress", ObjJobRequestInput.SubAddress);
            objParameter[9] = new SqlParameter("@SubContact", ObjJobRequestInput.SubContact);
            objParameter[10] = new SqlParameter("@GivenBy", ObjJobRequestInput.GivenBy);
            objParameter[11] = new SqlParameter("@visitingcardimg", ObjJobRequestInput.VisitingCardImg);
            objParameter[12] = new SqlParameter("@shopphoto", ObjJobRequestInput.Shopphoto);
            objParameter[13] = new SqlParameter("@refersheet", ObjJobRequestInput.ReferSheet);
            objParameter[14] = new SqlParameter("@headstatus", ObjJobRequestInput.headstatus);
            objParameter[15] = new SqlParameter("@Createuid", ObjJobRequestInput.createuid);
            objParameter[16] = new SqlParameter("@Createlogno", ObjJobRequestInput.createlogno);
            objParameter[17] = new SqlParameter("@pagename", ObjJobRequestInput.pagename);
            objParameter[18] = new SqlParameter("@slno", ObjJobRequestInput.slno);
            objParameter[19] = new SqlParameter("@editusercat", ObjJobRequestInput.editusercat);
            objParameter[20] = new SqlParameter("@subemail", ObjJobRequestInput.subemail);
            objParameter[21] = new SqlParameter("@submittedby", ObjJobRequestInput.submittedby);
            objParameter[22] = new SqlParameter("@approvedby", ObjJobRequestInput.approvedby);
            objParameter[23] = new SqlParameter("@gstno", ObjJobRequestInput.GstNo);
            objParameter[24] = new SqlParameter("@finyear", ObjJobRequestInput.finyear);
            objParameter[25] = new SqlParameter("@GivenByID", ObjJobRequestInput.GivenByID);
            objParameter[26] = new SqlParameter("@IsSubnameIdstaterightswise", ObjJobRequestInput.Statecheck);
            objParameter[27] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[27].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobRequestHeadAddUpdate", objParameter));
        }


        public DataTable AllPartCatDA()
        {
            return (objDataAccess.ReturnDataTable("partycatselect"));
        }

        public DataTable AllAreaDA()
        {
            return (objDataAccess.ReturnDataTable("SelectArea"));
        }
        public int AddUpdateJobRequestChildDA(JobRequestModel.JobRequestProperties ObjJobRequestInput)
        {
            SqlParameter[] objParameter = new SqlParameter[33];
            objParameter[0] = new SqlParameter("@taskid", ObjJobRequestInput.TaskId);
            objParameter[1] = new SqlParameter("@width", ObjJobRequestInput.Width);
            objParameter[2] = new SqlParameter("@height", ObjJobRequestInput.Height);
            objParameter[3] = new SqlParameter("@jobtypeid", ObjJobRequestInput.JobTypeId);
            objParameter[4] = new SqlParameter("@subjobtypeid", ObjJobRequestInput.SubJobTypeId);
            objParameter[5] = new SqlParameter("@subsubjobtypeid", ObjJobRequestInput.SubSubJobTypeId);
            objParameter[6] = new SqlParameter("@designtypeid", ObjJobRequestInput.DesignTypeId);
            objParameter[7] = new SqlParameter("@producttypeid", ObjJobRequestInput.ProductTypeId);
            objParameter[8] = new SqlParameter("@qty", ObjJobRequestInput.Qty);
            objParameter[9] = new SqlParameter("@installaddress", ObjJobRequestInput.installaddress);
            objParameter[10] = new SqlParameter("@isplace", ObjJobRequestInput.ispalce);

            objParameter[11] = new SqlParameter("@approvalmail", ObjJobRequestInput.approvalmail);
            objParameter[12] = new SqlParameter("@image", ObjJobRequestInput.ImageName);
            objParameter[13] = new SqlParameter("@remark", ObjJobRequestInput.Remark);
            objParameter[14] = new SqlParameter("@refid", ObjJobRequestInput.refid);
            objParameter[15] = new SqlParameter("@childstatus", ObjJobRequestInput.childstatus);
            objParameter[16] = new SqlParameter("@Createuid", ObjJobRequestInput.createuid);
            objParameter[17] = new SqlParameter("@Createlogno", ObjJobRequestInput.createlogno);
            objParameter[18] = new SqlParameter("@pagename", ObjJobRequestInput.pagename);
            objParameter[19] = new SqlParameter("@slno", ObjJobRequestInput.slno);
            objParameter[20] = new SqlParameter("@editusercat", ObjJobRequestInput.editusercat);
            objParameter[21] = new SqlParameter("@DeleteFlag", ObjJobRequestInput.DeleteFlag);
            objParameter[22] = new SqlParameter("@approvto", ObjJobRequestInput.approvto);
            objParameter[23] = new SqlParameter("@needapproval", ObjJobRequestInput.NeedApproval);
            objParameter[24] = new SqlParameter("@link", ObjJobRequestInput.Link);
            objParameter[25] = new SqlParameter("@cdrfile", ObjJobRequestInput.CdrFile);
            objParameter[26] = new SqlParameter("@UnitID", ObjJobRequestInput.UnitID);
            objParameter[27] = new SqlParameter("@Priority", ObjJobRequestInput.Priority);
            objParameter[28] = new SqlParameter("@BoardTypeID", ObjJobRequestInput.BoardTypeID);
            objParameter[29] = new SqlParameter("@PrintLocation", ObjJobRequestInput.PrintLocation);
            objParameter[30] = new SqlParameter("@FabricatorLocation", ObjJobRequestInput.FabricatorLocation);
            objParameter[31] = new SqlParameter("@UseAddressType", ObjJobRequestInput.UseAddressType);
            objParameter[32] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[32].Direction = ParameterDirection.Output;
           
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobRequestChildAddUpdate", objParameter));
        }
        


              public int AddOrgDA(JobRequestModel.orginsert ObjJobRequestInput)
        {
            SqlParameter[] objParameter = new SqlParameter[10];
            objParameter[0] = new SqlParameter("@name", ObjJobRequestInput.name);
            objParameter[1] = new SqlParameter("@compname", ObjJobRequestInput.compname);
            objParameter[2] = new SqlParameter("@categoryid", ObjJobRequestInput.categoryid);
            objParameter[3] = new SqlParameter("@regaddress", ObjJobRequestInput.regaddress);
            objParameter[4] = new SqlParameter("@regcontactno", ObjJobRequestInput.regcontactno);
            objParameter[5] = new SqlParameter("@desigid", ObjJobRequestInput.desigid);
            objParameter[6] = new SqlParameter("@areaid", ObjJobRequestInput.areaid);
            objParameter[7] = new SqlParameter("@crtuid1", ObjJobRequestInput.crtuid1);
            objParameter[8] = new SqlParameter("@logon1", ObjJobRequestInput.logon1);
            objParameter[9] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[9].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BrandingAddOrgByQuot", objParameter));
        }
        #endregion Add

        #region Delete

        public int DeleteJobRequestHead(JobRequestModel.JobRequestProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[2] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteJobRequestHead", objParameter));
        }

        public int PermanentDeleteJobRequest(JobRequestModel.JobRequestProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[1].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteJobRequest", objParameter));
        }

        public int DeleteJobRequestChild(JobRequestModel.JobRequestProperties ObjDesignTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@refid", ObjDesignTypeInput.refid);
            objParameter[2] = new SqlParameter("@Createuid", ObjDesignTypeInput.createuid);
            objParameter[3] = new SqlParameter("@Createlogno", ObjDesignTypeInput.createlogno);
            objParameter[4] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[4].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteJobRequestChild", objParameter));
        }

        public int DeleteJobRequestFilesDA(JobRequestModel.JobRequestProperties ObjDesignTypeInput)
        {
            int result = 0;
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypeInput.slno);
            objParameter[1] = new SqlParameter("@ImgNm", ObjDesignTypeInput.VisitingCardImg);
            objParameter[2] = new SqlParameter("@flag", ObjDesignTypeInput.flag);
            string alldata = objDataAccess.ExecuteNonQueryWithOutputParameters("DeleteJobRequestFiles", objParameter).ToString();
            if (alldata != string.Empty)
            {
                result = 1;
            }
            return Convert.ToInt32(result);
        }

        public DataTable Reqno(JobRequestModel.getrequest ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@comman", ObjDesignTypesingle.comman);
            objParameter[1] = new SqlParameter("@stateid", ObjDesignTypesingle.stateid);
            objParameter[2] = new SqlParameter("@isstate", ObjDesignTypesingle.isstate);
            return (objDataAccess.ReturnDataTableWithParameters("Getreqno", objParameter));
        }

        #endregion Delete

        public DataTable AllDataForName(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@nameid", ObjDesignTypesingle.nameid);
            return (objDataAccess.ReturnDataTableWithParameters("getalldetailsforname", objParameter));
        }

        public DataTable GetRetailerDetails(int RetailerID)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@RetailerID", RetailerID);
            return (objDataAccess.ReturnDataTableWithParameters("GetRetailerDetails", objParameter));
        }

        public DataTable AllDataForNameNew(JobRequestModel.JobRequestProperties ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@nametype", ObjDesignTypesingle.nametype);
            objParameter[1] = new SqlParameter("@nameid", ObjDesignTypesingle.nameid);
            return (objDataAccess.ReturnDataTableWithParameters("getalldetailsforname", objParameter));
        }

       

        public DataTable StatusOfRetailer(JobRequestModel.DhbApproveStatus Objsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", Objsingle.slno);

            return (objDataAccess.ReturnDataTableWithParameters("getretailerapprovalstatus", objParameter));
        }

        public DataTable GetPrintDCReport(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterDC", objParameter));
        }
        public DataTable Getprintfabrication(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorDC", objParameter));
        }

        public DataTable GetPrintSubFabrication(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorDC_JobDescriptionSummary", objParameter));
        }
        public DataTable GetPrintSubCReport(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterDC_JobDescriptionSummary ", objParameter));
        }

       
        public DataTable GetPrintFabricationPO(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedFabricatorPOHead", objParameter));
        }

        public DataTable GetPrintSubFabricationPO(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedFabricatorPOChild", objParameter));
        }

        public DataTable GetPrintGeneratedPrinterPOHead(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedPrinterPOHead", objParameter));
        }

        public DataTable GetPrintGeneratedPrinterPOChild(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedPrinterPOChild", objParameter));
        }


        public DataTable GetPrinterDC_WithAmount(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterDC_WithAmount", objParameter));
        }
        public DataTable GetPrinterDC_JobDescriptionSummary_WithAmount(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrinterDC_JobDescriptionSummary_WithAmount", objParameter));
        }

        public DataTable GetFabricatorDC_WithAmount(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorDC_WithAmount", objParameter));
        }
        public DataTable GetFabricatorDC_JobDescriptionSummary_WithAmount(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DcNumber", id);
            return (objDataAccess.ReturnDataTableWithParameters("FabricatorDC_JobDescriptionSummary_WithAmount", objParameter));
        }
        public DataTable PrintGeneratedPrinterPOWithoutAmountHead(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedPrinterPOWithoutAmountHead", objParameter));
        }

        public DataTable PrintGeneratedPrinterPOWithoutAmountChild(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedPrinterPOWithoutAmountChild", objParameter));
        }

        public DataTable PrintGeneratedFabricatorPOWithoutAmountHead(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedFabricatorPOWithoutAmountHead", objParameter));
        }

        public DataTable PrintGeneratedFabricatorPOWithoutAmountChild(string id)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", id);
            return (objDataAccess.ReturnDataTableWithParameters("PrintGeneratedFabricatorPOWithoutAmountChild", objParameter));
        }
    }
}