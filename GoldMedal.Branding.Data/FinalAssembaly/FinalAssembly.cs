namespace GoldMedal.Branding.Data.FinalAssembaly
{
    public class FinalAssembly
    {
        public class FinalAssemblyProperty
        {
            public long slno { get; set; }
            public long designsubmitid { get; set; }
            public long assignfabid { get; set; }
            public string submitdesign { get; set; }
            public string Remark { get; set; }
            public long createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public string editusercat { get; set; }
            public string link { get; set; }
            public string QRCode { get; set; }

            public int userid { get; set; }
            public string Fromdate { get; set; }
            public string ToDate { get; set; }

            public bool SubmitStatus { get; set; }
            public int refid { get; set; }
            public int childslno { get; set; }
            public int qty { get; set; }
            public int itemid { get; set; }

            public int Dispatchedby { get; set; }

            public string Allslno { get; set; }

            public string TransportMode { get; set; }
            public string TranspoterName { get; set; }
            public string InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string LRNumber { get; set; }
            public string LRDate { get; set; }
            public int NoofPackages { get; set; }

            public int TotalBoardQty { get; set; }
            public int uid { get; set; }

            public string InstallationDate { get; set; }

            public string JobCloserImg { get; set; }

            public int branchID { get; set; }

        }
        public class DispatchTeamInsert
        {
           
            public string Name { get; set; }
           
            public string branch { get; set; }
            public string emailid { get; set; }
            
            public string mobile { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }

            public string usernm { get; set; }
            public string password { get; set; }
         

            public bool Status { get; set; }

          
        }

        public class DispatchTeamDelete
        {

            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }


        }

        public class SelfInstallationTeamInsert
        {

            public string Name { get; set; }

            public string branch { get; set; }
            public string emailid { get; set; }

            public string mobile { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }

            public string usernm { get; set; }
            public string password { get; set; }


            public bool Status { get; set; }


        }

        public class SelfInstallationTeamDelete
        {

            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }


        }



        public class VendorTeamInsert
        {

            public string Name { get; set; }

            public string branch { get; set; }
            public string emailid { get; set; }

            public string mobile { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }

            public string usernm { get; set; }
            public string password { get; set; }


            public bool Status { get; set; }


        }

        public class VendorTeamDelete
        {

            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }


        }

        public class TeamsLogin
        {
            public string usernm { get; set; }
            public string password { get; set; }
        }
    }
}