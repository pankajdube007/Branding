namespace GoldMedal.Branding.Data.Fabricator
{
    public partial class FabricatorModel
    {
        public class FabricatorInsert
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public int area { get; set; }
            public string emailid { get; set; }

            public string contactno { get; set; }

            public string mobile { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
            public int materialid { get; set; }
            public int childslno { get; set; }
            public int refid { get; set; }

            public decimal RatePerJOb { get; set; }
            public int fabricatorid { get; set; }
            public int unitid { get; set; }

            public string branch { get; set; }

            public string usernm { get; set; }
            public string password { get; set; }
            public int SupplierID { get; set; }
            public int BranchID { get; set; }
            public bool Status { get; set; }

            public string Address { get; set; }
            public string Pincode { get; set; }
            public string Gstno { get; set; }

            public string ContactPerson { get; set; }
            public string ShortName { get; set; }
            public int Modeofdispatch { get; set; }
        }

        public class FabricatorDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }
        }

        public class FabricatorLogin
        {
            public string usernm { get; set; }
            public string password { get; set; }
        }

        public class FabricatorPricingInsert
        {
            public long slno { get; set; }
            public long FabricatorID { get; set; }
            public long MaterialID { get; set; }
            public long UnitID { get; set; }
            public decimal Rate { get; set; }
            public string EffectiveFromDate { get; set; }
            public long Createuid { get; set; }
            public long Createlogno { get; set; }
            public string pagename { get; set; }
            public int BranchID { get; set; }
        }
    }
}