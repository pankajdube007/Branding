namespace GoldMedal.Branding.Data.SubJobTypeMaping
{
    public partial class SubJobTypeMapingModel
    {
        public class SubJobTypeMapingInsert
        {
            public int subjobtypeid { get; set; }

            public int subsubjobtypeid { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class SubJobTypeMapingDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}