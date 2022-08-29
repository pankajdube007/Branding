using System.Data;

namespace GoldMedal.Branding.Core.BillUpload
{
    public interface IBillUpload
    {
        int BillUploadInsertMethod(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dti);

        bool BillUploadDelete(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadDelete dti);

        DataTable GetBillUploadAll();

        DataTable GetBranchAll();

        DataTable GetBillUploadSingle(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dtsingle);

        DataTable GetBillUploadTypeName(int TypeId,int BranchId);

        DataTable GetBillUploadDcNumber(int TypeId,int TypeNameId);

        DataTable GetBillUploadFiles(GoldMedal.Branding.Data.BillUpload.BillUploadModel.BillUploadInsert dtsingle);
    }
}