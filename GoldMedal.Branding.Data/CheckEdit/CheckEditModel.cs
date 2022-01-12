namespace GoldMedal.Branding.Data.CheckEdit
{
    public partial class CheckEditModel
    {
        public class CheckEditInsert
        {
            public string slno { get; set; }
            public string TableNm { get; set; }
            public int adminid { get; set; }

            public string usercat { get; set; }
            public string PageNm { get; set; }
            public int overwritetime { get; set; }
            public int maxtime { get; set; }
        }
    }
}