namespace GoldMedal.Branding.Data.Unit
{
    public partial class UnitModel
    {
        public class UnitInsert
        {
            public string Name { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
        }

        public class UnitDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}