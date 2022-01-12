namespace GoldMedal.Branding.Data.AssignJob
{
    public class AssignJobModel
    {
        public class AssignProperties
        {
            public long slno { get; set; }
            public long jobrequestchildidP { get; set; }
            public long Assignto { get; set; }
            public string comman { get; set; }
            public string type { get; set; }
            public int deadline { get; set; }
            public string assignrequestno { get; set; }
            public string Remark { get; set; }
            public long createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public string editusercat { get; set; }

            public string reqno { get; set; }
            public string finyear { get; set; }

            public int userid { get; set; }

            public string DeleteRemark { get; set; }
            
        }
    }
}