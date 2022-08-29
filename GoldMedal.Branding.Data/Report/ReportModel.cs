namespace GoldMedal.Branding.Data.Report
{
    public partial class ReportModel
    {
        public class ReportInsert
        {
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
            public int BranchID { get; set; }
            public int Type { get; set; }
            public int TypeNameID { get; set; }
            public string DCNumber { get; set; }
            public string FileNm { get; set; }
            public bool Status { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
        }     
    }
}