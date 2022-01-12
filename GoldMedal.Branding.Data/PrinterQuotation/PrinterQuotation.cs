using System;

namespace GoldMedal.Branding.Data.PrinterQuotation
{
    public partial class PrinterQuotation
    {
        public class PrinterQuotationInsert
        {
            public int PrinterId { get; set; }
            public string Quotation { get; set; }
            public DateTime EffDate { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            //  public int branch { get; set; }
            public string branch { get; set; }
        }

        public class PrinterQuotationDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }
        }
    }
}