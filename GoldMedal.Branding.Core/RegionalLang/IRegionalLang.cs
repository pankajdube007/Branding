using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GoldMedal.Branding.Core.RegionalLang
{
    public interface IRegionalLang
    {
        DataTable GetBranchAll();
    }
}
