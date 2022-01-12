using System.Data;

namespace GoldMedal.Branding.Core.DesignSubmit
{
    public interface IDesignSubmit
    {
        DataTable GetAssignedJobForUserAll(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetAssignedJobForUserSingle(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetAllDesignSubmitByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetAllDesignSubmitByUserforapprovel(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetAllSubmitedDesignApprovedByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetAllDesignSubmitByUserforapprovelmanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetAllSubmitedDesignApprovedByMgm(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetDetailOfDesignSubmitByUser(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable JobDetailsForParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetDetailOfItemListForDesignSubmit(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetDetailOfSizeListForDesignSubmit(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dtsingle);

        DataTable GetItemDivisonAll();
        DataTable GetItemTypeAll(int DivisionID);

        int DesignSubmitInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int DesignSubmitUpdateMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int ItemDesignSubmitInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int SizeDesignSubmitInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int UpdateEmail(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int UpdateFinalApr(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int UpdateEmailbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int ApproveByParty(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);

        int PermanentDeleteDesignSubmitCore(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata);

        int DeleteItemForDesignSubmitCore(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata);

        int DeleteSizeForDesignSubmitCore(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata);

        int DesignSubmitTrackInsertMethod(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty alldata);
        int LiveProductjobsReopenbymanagement(GoldMedal.Branding.Data.DesignSubmit.DesignSubmit.DesignSubmitProperty dti);
    }
}