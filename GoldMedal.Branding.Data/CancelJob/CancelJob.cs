namespace GoldMedal.Branding.Data.CancelJob
{
   public class CancelJob
    {
        public class CancelJobProperty
        {
            public long slno { get; set; }
            public long designsubmitid { get; set; }
            public string submitdesign { get; set; }
            public string Remark { get; set; }
            public long createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public string editusercat { get; set; }
            public string link { get; set; }

            public int userid { get; set; }
        }
    }
}
