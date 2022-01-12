namespace GoldMedal.Branding.Data.JobTypeMaping
{
    public partial class JobTypeMapingModel
    {
        public class JobTypeMapingInsert
        {
            public int jobtypeid { get; set; }

            public int subjobtypeid { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class JobTypeMapingDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}