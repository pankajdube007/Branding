using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.JobType
{
    public class JobTypeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateJobTypeDA(JobTypeModel.JobTypeInsert ObjJobTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[11];
            objParameter[0] = new SqlParameter("@Name", ObjJobTypeInput.Name);
            objParameter[1] = new SqlParameter("@isimgreq", ObjJobTypeInput.isimgreq);
            objParameter[2] = new SqlParameter("@Createuid", ObjJobTypeInput.createuid);
            objParameter[3] = new SqlParameter("@Createlogno", ObjJobTypeInput.createlogno);
            objParameter[4] = new SqlParameter("@pagename", ObjJobTypeInput.pagename);
            objParameter[5] = new SqlParameter("@slno", ObjJobTypeInput.slno);
            objParameter[6] = new SqlParameter("@editusercat", ObjJobTypeInput.editusercat);
            objParameter[7] = new SqlParameter("@isaprreq", ObjJobTypeInput.isaprreq);
            objParameter[8] = new SqlParameter("@Jobtypeimage", ObjJobTypeInput.Jobtypeimage);
            objParameter[9] = new SqlParameter("@ImageValidFromDate", ObjJobTypeInput.ImageValidFromDate);
           // objParameter[10] = new SqlParameter("@ImageValidToDate", ObjJobTypeInput.ImageValidToDate);
            objParameter[10] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[10].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobTypeAddUpdate", objParameter));
        }

        public int DeleteJobTypeDA(JobTypeModel.JobTypeDelete ObjJobTypeInput)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypeInput.slno);
            objParameter[1] = new SqlParameter("@Createlogno", ObjJobTypeInput.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", ObjJobTypeInput.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("JobTypeDelete", objParameter));
        }

        public DataTable AllJobTypeDA()
        {
            return (objDataAccess.ReturnDataTable("JobTypeList"));
        }
        public DataTable JobTypeActiveImageDA()
        {
            return (objDataAccess.ReturnDataTable("JobTypeActiveImageReport"));
        }

        public DataTable JobTypeInactiveImageDA()
        {
            return (objDataAccess.ReturnDataTable("JobTypeInactiveImageReport"));
        }

        public DataTable SingleJobTypeDA(JobTypeModel.JobTypeInsert ObjJobTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", ObjJobTypesingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("JobTypeSelectParticuler", objParameter));
        }

        public DataTable AllPrinterLocationDA()
        {
            return (objDataAccess.ReturnDataTable("PrinterLocationList"));
        }

        public DataTable AllFabricatorLocationDA()
        {
            return (objDataAccess.ReturnDataTable("FabricatorLocationList"));
        }

        public DataTable AllUnitDA()
        {
            return (objDataAccess.ReturnDataTable("UnitListNew"));
        }

    }
}