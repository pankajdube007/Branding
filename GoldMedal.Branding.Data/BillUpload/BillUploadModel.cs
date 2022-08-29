namespace GoldMedal.Branding.Data.BillUpload
{
    public partial class BillUploadModel
    {
        public class BillUploadInsert
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
        public class BillUploadDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }
        }
        
    }
}