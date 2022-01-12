namespace GoldMedal.Branding.Data.AssignFabricator
{
    public class AssignToFabricator
    {
        public class AssigntoFabricatorProperty
        {
            public int slno { get; set; }
            public long designsubmitid { get; set; }
            public long tofabricator { get; set; }
            public string Remark { get; set; }
            public long assignprinterslno { get; set; }
            public string reqno { get; set; }
            public string jobreqno { get; set; }
            public string finyear { get; set; }
            public long createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public string editusercat { get; set; }
            public int userid { get; set; }

            public decimal FabricationCost { get; set; }
        }

        public class GenarateFabricatorPO
        {
            public string slno { get; set; }
            public string finYear { get; set; }
            public int createuid { get; set; }

            public int branchid { get; set; }
            public long createlogno { get; set; }
            public long AssignFabricatorSlno { get; set; }
            public long POChildslno { get; set; }
            public long PoHeadslno { get; set; }
        }
        public class GetGenarateFabricatorPO
        {
            public int slno { get; set; }
            public string PoNumber { get; set; }
            public string Podt { get; set; }
            public string name { get; set; }
            public string partyadd { get; set; }
            public string billingadd { get; set; }
            public string dispatchadd { get; set; }
            public string DelivryDate { get; set; }
            public string LastDelivryDate { get; set; }
            public string TotalQty { get; set; }
            public string TotalCost { get; set; }

            public int userid { get; set; }
        }
    }
}