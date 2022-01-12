namespace GoldMedal.Branding.Data.DesignSubmit
{
    public class DesignSubmit
    {
        public class DesignSubmitProperty
        {
            public int assignslno { get; set; }
            public string sumbmitimg { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
            public int newproducttypeid { get; set; }
            public decimal totalamount { get; set; }
            public int itemid { get; set; }
            public decimal mrp { get; set; }
            public decimal discount { get; set; }
            public string sendemial { get; set; }
            public int qty { get; set; }
            public int sizeslno { get; set; }
            public decimal amount { get; set; }
            public string uniquekey { get; set; }
            public bool needapproval { get; set; }
            public int sizetype { get; set; }
            public int refid { get; set; }
            public int childslno { get; set; }
            public string remark { get; set; }
            public string ispayment { get; set; }
            public decimal boardwidth { get; set; }
            public decimal boardheight { get; set; }

            public decimal NewWidth { get; set; }
            public decimal NewHeight { get; set; }

            public decimal printwidth { get; set; }
            public decimal printheight { get; set; }
            public int flg { get; set; }
            public string status { get; set; }
            public string uplodepartyimg { get; set; }
            public int oldsizetype { get; set; }
            public int newsizetype { get; set; }
            public string link { get; set; }

            public string ApprovalGivenBy { get; set; }
            public string MgmRemark { get; set; }
            public string LiveProductImg { get; set; }

            public int Action { get; set; }

           // public string statuss { get; set; }
            public string disapproveddesignimgs { get; set; }

          
        }

        public class PrinterJobDCSend
        {
             public long slno { get; set; }

            public string Allslno { get; set; }

            public int JobSendType { get; set; }
            public int PartyType { get; set; }
            public long JobSendToID { get; set; }
            public string JobSendToOther { get; set; }
            public string SendToAddress { get; set; }

            public long printer { get; set; }


            public string TransportMode { get; set; }
            public string TranspoterName { get; set; }
            public string InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string LRNumber { get; set; }
            public string LRDate { get; set; }


            public long FabDesignSubmitID { get; set; }
            public string FabRemark { get; set; }
            public string FabJobReqNo { get; set; }
            public string Fabfinyear { get; set; }
            public string pagename { get; set; }


            public int createuid { get; set; }
            public int Actiontobetakentype { get; set; }
            public int RecievedQty { get; set; }
            public long createlogno { get; set; }
            public string JobReceiveDate { get; set; }

            public string JobRejectDate { get; set; }

            public decimal FabricationCost { get; set; }

            public int NoofPackages { get; set; }
            public int QtySentByPrinter { get; set; }

            public string PrinterDcRemark { get; set; }
        }

        public class FabricatorJobDCSend
        {
            public long slno { get; set; }

            public string Allslno { get; set; }

            public int JobSendType { get; set; }
            public int PartyType { get; set; }
            public long JobSendToID { get; set; }
            public string JobSendToOther { get; set; }
            public string SendToAddress { get; set; }

            public long fabricator { get; set; }


            public string TransportMode { get; set; }
            public string TranspoterName { get; set; }
            public string InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string LRNumber { get; set; }
            public string LRDate { get; set; }


            public long FabDesignSubmitID { get; set; }
            public string FabRemark { get; set; }
            public string FabJobReqNo { get; set; }
            public string Fabfinyear { get; set; }
            public string pagename { get; set; }


            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string JobReceiveDate { get; set; }

            public string JobRejectDate { get; set; }

            public int Actiontobetakentype { get; set; }
            public int RecievedQty { get; set; }

            public decimal FabricationCost { get; set; }

            public int NoofPackages { get; set; }
            public int QtySentByFabricator { get; set; }
            public string PrinterDcRemark { get; set; }
        }
    }
}