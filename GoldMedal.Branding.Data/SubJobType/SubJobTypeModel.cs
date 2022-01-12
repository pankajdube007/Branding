using System;

namespace GoldMedal.Branding.Data.SubJobType
{
    public partial class SubJobTypeModel
    {
        public class SubJobTypeInsert
        {
            public string Name { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; } 
            public string editusercat { get; set; }
            public string SubJobtypeimage { get; set; }
            public DateTime ImageValidFromDate { get; set; }
            public DateTime ImageValidToDate { get; set; }

            public bool ISActive { get; set; }
        }

        public class SubJobTypeDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}