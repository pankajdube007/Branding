namespace GoldMedal.Branding.Data.BoardType
{
    public partial class BoardTypeModel
    {
        public class BoardTypeInsertUpdate
        {
            public string BoardType { get; set; }
            public string JobTypes { get; set; }
            public bool IsPrintLocationReq { get; set; }
            public bool IsFabricatorLocationReq { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class BoardTypeDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }
        }
    }
}