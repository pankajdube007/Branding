namespace GoldMedal.Branding.Data.AssigntoPrinter
{
    public class AssigntoPrinter
    {
        public class AssigntoPrinterProperty
        {
            public int slno { get; set; }
            public long designsubmitid { get; set; }
            public long toprinter { get; set; }
            public string type { get; set; }
            public string requestno { get; set; }
            public string comman { get; set; }
            public string Remark { get; set; }
            public long createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public string editusercat { get; set; }

            public string reqno { get; set; }
            public string finyear { get; set; }

            public int userid { get; set; }

            public int newprinterlocation { get; set; }

            public int JobSendType { get; set; }
            public int PartyType { get; set; }
            public long JobSendToID { get; set; }
            public string JobSendToOther { get; set; }

            public string SendToAddress { get; set; }

            public decimal PrintCost { get; set; }


           
        }

        public class GenaratePrinterPO
        {
            public string slno { get; set; }
            public string finYear { get; set; }
            public int createuid { get; set; }

            public int branchid { get; set; }
            public long createlogno { get; set; }
            public long AssignPrinterSlno { get; set; }
            public long POChildslno { get; set; }
            public long PoHeadslno { get; set; }

            public string CancelRemark { get; set; }
        }
        public class GetGenaratePrinterPO
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