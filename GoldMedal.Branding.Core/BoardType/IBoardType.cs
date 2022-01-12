using System.Data;

namespace GoldMedal.Branding.Core.BoardType
{
    public interface IBoardType
    {
        int BoardTypeInsertMethod(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dti);

        int BoardTypeDelete(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeDelete dti);

        DataTable GetBoardTypeAll();

        DataTable GetBoardTypeSingle(GoldMedal.Branding.Data.BoardType.BoardTypeModel.BoardTypeInsertUpdate dtsingle);
    }
}