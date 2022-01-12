using GoldMedal.Branding.Data.BoardType;
using System.Data;

namespace GoldMedal.Branding.Service.BoardTypeService
{
    public static class BoardTypeServiceCall
    {
        public static int BoardTypeInsertServiceMethod(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dti, string DatabaseType)
        {
            int recid = 0;

            BoardTypeDataAccess objinsert = new BoardTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objinsert.AddUpdateBoardTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static int BoardTypeDeleteServiceMethod(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeDelete dti, string DatabaseType)
        {
            int recid = 0;
            BoardTypeDataAccess objdelete = new BoardTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objdelete.DeleteBoardTypeDA(dti);
            }
            else
            {
                recid = 0;
            }
            return recid;
        }

        public static DataTable AllBoardTypeServiceMethod(string DatabaseType)
        {
            DataTable recid = null;
            BoardTypeDataAccess objselectall = new BoardTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objselectall.AllBoardTypeDA();
            }
            else
            {
                recid = null;
            }
            return recid;
        }

        public static DataTable SingleBoardTypeServiceMethod(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dtsingle, string DatabaseType)
        {
            DataTable recid = null;
            BoardTypeDataAccess objsingleJobtype = new BoardTypeDataAccess();
            if (string.Equals(DatabaseType, "MSSQLSERVER"))
            {
                recid = objsingleJobtype.SingleBoardTypeDA(dtsingle);
            }
            else
            {
                recid = null;
            }
            return recid;
        }
    }
}