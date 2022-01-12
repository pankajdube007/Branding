using System;

namespace GoldMedal.Branding.Data.JobType
{
    public partial class JobTypeModel
    {
        public class JobTypeInsert
        {
            public string Name { get; set; }

            public bool isimgreq { get; set; }
            public bool isaprreq { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
            public string Jobtypeimage { get; set; }
            public DateTime ImageValidFromDate { get; set; }
            public DateTime ImageValidToDate { get; set; }
        }

        public class JobTypeDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }

       
    }
}