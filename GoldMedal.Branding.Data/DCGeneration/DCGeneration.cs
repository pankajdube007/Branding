using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldMedal.Branding.Data.DCGeneration
{
    public class DCGeneration
    {
        public class DCGenerationSend
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
            public string JobReqNo { get; set; }
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
            public int QtySentByDC { get; set; }
            public string PrinterDcRemark { get; set; }
        }
    }
}
