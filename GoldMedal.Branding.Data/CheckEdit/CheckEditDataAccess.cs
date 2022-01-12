using System;
using System.Data;
using System.Data.SqlClient;

namespace GoldMedal.Branding.Data.CheckEdit
{
    public class CheckEditDataAccess
    {
        private DataAccess objDataAccess = new DataAccess();

        public DataTable AllCheckEditDA(CheckEditModel.CheckEditInsert ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[7];
            string overtime = string.Empty, maxtime = string.Empty;
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            objParameter[1] = new SqlParameter("@TableNm", ObjDesignTypesingle.TableNm);
            objParameter[2] = new SqlParameter("@adminid", ObjDesignTypesingle.adminid);
            objParameter[3] = new SqlParameter("@usercat", ObjDesignTypesingle.usercat);
            objParameter[4] = new SqlParameter("@PageNm", ObjDesignTypesingle.PageNm);
            objParameter[5] = new SqlParameter("@overwritetime", ObjDesignTypesingle.overwritetime);
            objParameter[6] = new SqlParameter("@maxtime", ObjDesignTypesingle.maxtime);
            return (objDataAccess.ReturnDataTableWithParameters("ChckePageEditStatus", objParameter));
        }

        public string ResetEditStatus(CheckEditModel.CheckEditInsert ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[2];
            string overtime = string.Empty, maxtime = string.Empty;
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            objParameter[1] = new SqlParameter("@TableNm", ObjDesignTypesingle.TableNm);
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("ResetPageEditStatus", objParameter));
        }

        public string updateeditstatus(CheckEditModel.CheckEditInsert ObjDesignTypesingle)
        {
            SqlParameter[] objParameter = new SqlParameter[5];
            string overtime = string.Empty, maxtime = string.Empty;
            objParameter[0] = new SqlParameter("@slno", ObjDesignTypesingle.slno);
            objParameter[1] = new SqlParameter("@TableNm", ObjDesignTypesingle.TableNm);
            objParameter[2] = new SqlParameter("@adminid", ObjDesignTypesingle.adminid);
            objParameter[3] = new SqlParameter("@usercat", ObjDesignTypesingle.usercat);
            objParameter[4] = new SqlParameter("@PageNm", ObjDesignTypesingle.PageNm);
            return Convert.ToString(objDataAccess.ExecuteNonQueryWithOutputParameters("UpdatePageEditStatus", objParameter));
        }
    }
}