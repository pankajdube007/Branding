using System.Collections.Generic;

namespace GoldMedal.Branding.Admin.Models
{
    public class DesignType
    {
        public class DesignTypeAPI
        {
            public string result { get; set; }
            public string message { get; set; }
            public string servertime { get; set; }
            public List<DesignTypeInput> data { get; set; }
        }

        public class DesignTypeInput
        {
            public int slno { get; set; }
            public string Name { get; set; }
            public int logno { get; set; }
            public int UserID { get; set; }
            public string uniquekey { get; set; }
        }

        public class DesignTypeAPIinput
        {
            public string uniquekey { get; set; }
        }
    }
}