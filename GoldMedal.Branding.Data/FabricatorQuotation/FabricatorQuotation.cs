using System;

namespace GoldMedal.Branding.Data.FabricatorQuotation
{
    public partial class FabricatorQuotation
    {
        public class FabricatorQuotationInsert
        {
            public int FabricatorId { get; set; }
            public string Quotation { get; set; }
            public DateTime EffDate { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }

            public int branch { get; set; }
        }

        public class FabricatorQuotationDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }
        }
    }
}