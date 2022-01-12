namespace GoldMedal.Branding.Data.Disapproved
{
    public class DisApproveJobModel
    {
        public class DisapprovedProperties
        {
            public string reqno { get; set; }
            public string refid { get; set; }
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
            public string status { get; set; }
            public string ImageName { get; set; }
            public string approvto { get; set; }

            public string approvalmail { get; set; }
            public string Remark { get; set; }
            public int childstatus { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
            public int flag { get; set; }
            public int nametype { get; set; }
            public int nameid { get; set; }
            public int addressid { get; set; }
            public bool DeleteFlag { get; set; }
            public string Link { get; set; }

            public int Priority { get; set; }

            public int BoardTypeID { get; set; }

            public int PrintLocation { get; set; }
            public int FabricatorLocation { get; set; }

            public int UnitID { get; set; }

            public int userid { get; set; }
        }
    }
}