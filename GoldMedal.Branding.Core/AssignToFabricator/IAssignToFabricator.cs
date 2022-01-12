using System.Data;

namespace GoldMedal.Branding.Core.AssignToFabricator
{
    internal interface IAssignToFabricator
    {
        DataTable ListOfJobForAssignToFabricator(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle);

        DataTable ListOfJobForAssignToFabricatorSendByPrinter(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle);

        DataTable DetailOfJobDoneByFabricatorForApproval(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle);

        int AssignFabricatorInsertMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti);

        int ApproveDesignSubmitByFabricatorMethod(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dti);

        DataTable AllAssignedfabricatorDACore();

        DataTable GetAllApprovedFabricatorJobs(GoldMedal.Branding.Data.AssignFabricator.AssignToFabricator.AssigntoFabricatorProperty dtsingle);
    }
}