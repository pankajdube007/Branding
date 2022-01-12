using GoldMedal.Branding.Service.BoardTypeService;
using System.Data;

namespace GoldMedal.Branding.Core.BoardType
{
    public class BoardType : IBoardType
    {
        public int BoardTypeInsertMethod(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dti)
        {
            int recid = 0;

            recid = BoardTypeServiceCall.BoardTypeInsertServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public int BoardTypeDelete(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeDelete dti)
        {
            int recid = 0;

            recid = BoardTypeServiceCall.BoardTypeDeleteServiceMethod(dti, "MSSQLSERVER");
            return recid;
        }

        public DataTable GetBoardTypeAll()
        {
            DataTable recid = new DataTable();
            recid = BoardTypeServiceCall.AllBoardTypeServiceMethod("MSSQLSERVER");
            return recid;
        }

        public DataTable GetBoardTypeSingle(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dtsingle)
        {
            DataTable recid = new DataTable();
            recid = BoardTypeServiceCall.SingleBoardTypeServiceMethod(dtsingle, "MSSQLSERVER");
            return recid;
        }
    }
}