using System;
using System.Data;
using System.Data.SqlClient;
using GoldMedal.Branding.Data.DCGeneration;

namespace GoldMedal.Branding.Data.DCGenerationDesignSubmit
{
    public class DCGenerationDesignSubmitDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable ApprovedJobsForDCDA(DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty ObjDesignSubmitsingle)

        {
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@branchid", ObjDesignSubmitsingle.branchid);
            objParameter[1] = new SqlParameter("@uid", ObjDesignSubmitsingle.uid);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfApprovedJobsForDC", objParameter));
        }

        public int UpdateSentQtybyDCGenerationDA(GoldMedal.Branding.Data.DCGeneration.DCGeneration.DCGenerationSend objSendDC)
        {
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@QtySentByDc", objSendDC.QtySentByDC);
            objParameter[1] = new SqlParameter("@slno", objSendDC.slno);
            objParameter[2] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[2].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("UpdateSentQtybyDC", objParameter));
        }
        public int SendByDCGenerationDA(GoldMedal.Branding.Data.DCGeneration.DCGeneration.DCGenerationSend objSendDC)
        {
            SqlParameter[] objParameter = new SqlParameter[14];
            objParameter[0] = new SqlParameter("@Allslno", objSendDC.Allslno);           
            objParameter[1] = new SqlParameter("@LRNumber", objSendDC.LRNumber);
            objParameter[2] = new SqlParameter("@LRDate", objSendDC.LRDate);
            objParameter[3] = new SqlParameter("@TranspoterName", objSendDC.TranspoterName);
            objParameter[4] = new SqlParameter("@jobrecvdate", objSendDC.JobReceiveDate);           
            objParameter[5] = new SqlParameter("@pagename", objSendDC.pagename);
            //objParameter[9] = new SqlParameter("@pagename", objJobSend.pagename);
            objParameter[6] = new SqlParameter("@TransportMode", objSendDC.TransportMode);
            objParameter[7] = new SqlParameter("@InvoiceNumber", objSendDC.InvoiceNumber);
            objParameter[8] = new SqlParameter("@InvoiceDate", objSendDC.InvoiceDate);
            objParameter[9] = new SqlParameter("@NoofPackages", objSendDC.NoofPackages);
            objParameter[10] = new SqlParameter("@DCgenerationRemark", objSendDC.PrinterDcRemark);
            objParameter[11] = new SqlParameter("@creatuid", objSendDC.createuid);
            objParameter[12] = new SqlParameter("@Fabfinyear", objSendDC.Fabfinyear);
            objParameter[13] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[13].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("DCgenerationJobSendDC", objParameter));
        }
        public DataTable ApprovedJobsForViewDCDA(DCGenerationDesignSubmit.DCGenerationDesignSubmitProperty ObjDesignSubmitsingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@JobSendBy", ObjDesignSubmitsingle.JobSendBy);
            return (objDataAccess.ReturnDataTableWithParameters("ListOfApprovedJobsForViewDC", objParameter));
        }
    }
}
