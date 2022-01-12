namespace GoldMedal.Branding.Data.DesignTypeSubCat
{
    public partial class DesignTypeSubCatModel
    {
        public class DesignTypeSubCatInsert
        {
            public int designtype { get; set; }
            public string Name { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class DesignTypeSubCatDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }
            public long createlogno { get; set; }
        }
    }
}