using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.BoardType
{
    public class BoardTypeDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public int AddUpdateBoardTypeDA(BoardTypeModel.BoardTypeInsertUpdate objInsertUpdate)
        {
            SqlParameter[] objParameter = new SqlParameter[10];
            objParameter[0] = new SqlParameter("@slno", objInsertUpdate.slno);
            objParameter[1] = new SqlParameter("@BoardType", objInsertUpdate.BoardType);
            objParameter[2] = new SqlParameter("@JobTypes", objInsertUpdate.JobTypes);
            objParameter[3] = new SqlParameter("@IsPrintLocationReq", objInsertUpdate.IsPrintLocationReq);
            objParameter[4] = new SqlParameter("@IsFabricatorLocationReq", objInsertUpdate.IsFabricatorLocationReq);
            objParameter[5] = new SqlParameter("@Createuid", objInsertUpdate.createuid);
            objParameter[6] = new SqlParameter("@Createlogno", objInsertUpdate.createlogno);
            objParameter[7] = new SqlParameter("@pagename", objInsertUpdate.pagename);
            objParameter[8] = new SqlParameter("@editusercat", objInsertUpdate.editusercat);
            objParameter[9] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[9].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BoardTypeAddUpdate", objParameter));
        }

        public int DeleteBoardTypeDA(BoardTypeModel.BoardTypeDelete objDelete)
        {
            SqlParameter[] objParameter = new SqlParameter[4];
            objParameter[0] = new SqlParameter("@slno", objDelete.slno);
            objParameter[1] = new SqlParameter("@Createlogno", objDelete.createlogno);
            objParameter[2] = new SqlParameter("@Createuid", objDelete.Createuid);
            objParameter[3] = new SqlParameter("@Out", SqlDbType.Int, 10);
            objParameter[3].Direction = ParameterDirection.Output;
            return Convert.ToInt32(objDataAccess.ExecuteNonQueryWithOutputParameters("BoardTypeDelete", objParameter));
        }

        public DataTable AllBoardTypeDA()
        {
            return (objDataAccess.ReturnDataTable("BoardTypeList"));
        }

        public DataTable SingleBoardTypeDA(BoardTypeModel.BoardTypeInsertUpdate objSingle)
        {
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@slno", objSingle.slno);
            return (objDataAccess.ReturnDataTableWithParameters("BoardTypeSelectParticular", objParameter));
        }

        
    }
}