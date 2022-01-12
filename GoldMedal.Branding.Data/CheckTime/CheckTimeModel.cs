namespace GoldMedal.Branding.Data.CheckTime
{
    public partial class CheckTimeModel
    {
        public class CheckTimeInsert
        {
            public string Node { get; set; }
            public int overwrite { get; set; }
            public int maxtime { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public int editusercat { get; set; }
        }
    }
}