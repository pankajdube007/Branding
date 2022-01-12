namespace GoldMedal.Branding.Data.SubSubJobType
{
    public partial class SubSubJobTypeModel
    {
        public class SubSubJobTypeInsert
        {
            public string Name { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }

            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class SubSubJobTypeDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}