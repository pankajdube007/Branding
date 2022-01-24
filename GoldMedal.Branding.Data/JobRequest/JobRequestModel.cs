using System;

namespace GoldMedal.Branding.Data.JobRequest
{
    public class JobRequestModel
    {
        public class JobRequestProperties
        {
            public string reqno { get; set; }
            public string refid { get; set; }
            public int NameTypeId { get; set; }
            public int NameId { get; set; }
            public int Address { get; set; }
            public string ContactPerson { get; set; }
            public string Email { get; set; }
            public string ContactNumber { get; set; }
            public DateTime RequestDate { get; set; }
            public int SubNameId { get; set; }
            public string SubAddress { get; set; }
            public string SubContact { get; set; }
            public string subemail { get; set; }
            public string approvedby { get; set; }
            public string submittedby { get; set; }
            public string approvto { get; set; }

            public string approvalmail { get; set; }

            public string GivenBy { get; set; }

            public int GivenByID { get; set; }

            public int Priority { get; set; }

            public int BoardTypeID { get; set; }

            public int PrintLocation { get; set; }
            public int FabricatorLocation { get; set; }

            public int headstatus { get; set; }
            public int TaskId { get; set; }
            public decimal Width { get; set; }
            public decimal Height { get; set; }
            public int JobTypeId { get; set; }
            public int SubJobTypeId { get; set; }
            public int SubSubJobTypeId { get; set; }
            public int DesignTypeId { get; set; }
            public int ProductTypeId { get; set; }
            public int Qty { get; set; }
            public string installaddress { get; set; }
            public bool NeedApproval { get; set; }

            public bool ispalce { get; set; }
            public string ImageName { get; set; }
            public string VisitingCardImg { get; set; }
            public string Shopphoto { get; set; }
            
            public string ReferSheet { get; set; }
            public string Remark { get; set; }
            public int childstatus { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public long slno { get; set; }
            public string editusercat { get; set; }
            public int flag { get; set; }
            public int nametype { get; set; }
            public int nameid { get; set; }
            public int addressid { get; set; }
            public bool DeleteFlag { get; set; }
            public int childslno { get; set; }

            public string Link { get; set; }
            public string GstNo { get; set; }

            public string CdrFile { get; set; }

            public string finyear { get; set; }

            public int userid { get; set; }

            public int userbranchid { get; set; }

            public int UnitID { get; set; }

            public int UseAddressType { get; set; }


            public bool Statecheck { get; set; }

            public bool IsWallSize { get; set; }
            public int Wallsizejobheadid { get; set; }
            public string WallsizejobheadReqNo { get; set; }

        }

        public class getrequest
        {
            public int stateid { get; set; }
            public string comman { get; set; }
            public int isstate { get; set; }
        }


        public class orginsert
        {
            public string name { get; set; }
            public string compname { get; set; }
            public int categoryid { get; set; }
            public string regaddress { get; set; }
            public string regcontactno { get; set; }
            public int desigid { get; set; }
            public int areaid { get; set; }
            public int crtuid1 { get; set; }
            public int logon1 { get; set; }
        }


        public class DhbApproveStatus
        {
            public long slno { get; set; }
            public string ApprovalStatus { get; set; }
           
        }
    }
}