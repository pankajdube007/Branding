namespace GoldMedal.Branding.Data.DesignType
{
    public partial class DesignTypeModel
    {
        public class DesignTypeInsert
        {
            public string Name { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class DesignTypeDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}