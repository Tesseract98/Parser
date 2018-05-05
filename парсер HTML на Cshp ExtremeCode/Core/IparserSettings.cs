using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace парсер_HTML_на_Cshp_ExtremeCode.Core
{
    interface IparserSettings
    {
        int StartPoint { get; set; }

        int EndPoint { get; set; }

        string Prefix { get; set; }

        string BaseUrl { get; set; }
    }
}
