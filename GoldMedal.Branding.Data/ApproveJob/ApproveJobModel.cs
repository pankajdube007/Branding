namespace GoldMedal.Branding.Data.ApproveJob
{
    public class ApproveJobModel
    {
        public class ApproveProperties
        {
            public long slno { get; set; }
            public int branchid { get; set; }
            public int uid { get; set; }
            public string tableNm { get; set; }
            public int moduleid { get; set; }
            public string apdisapremarks { get; set; }
            public int apdprinterlocation { get; set; }
            public int apdfabricatorlocation { get; set; }
            public string apdimageName { get; set; }
            public string fromdate { get; set; }
            public string todate { get; set; }
        }

        public class OverdueJobsCancel
        {
            public string slno { get; set; }
            
            public int uid { get; set; }
            
        }


    }
}