using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldMedal.Branding.Data.RegionalLang
{
    public class RegionalLangModel
    {
        public class RegionalLangInsert
        {
            public int jobtypeid { get; set; }

            public int subjobtypeid { get; set; }
            public int createuid { get; set; }
            public long createlogno { get; set; }
            public string pagename { get; set; }
            public int slno { get; set; }
            public string editusercat { get; set; }
            public string branch { get; set; }
            public bool isactive { get; set; }
            public int BranchID { get; set; }
        }

        public class RegionalLangDelete
        {
            public int slno { get; set; }
            public int Createuid { get; set; }

            public long createlogno { get; set; }
        }
    }
}
