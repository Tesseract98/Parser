
namespace парсер_HTML_на_Cshp_ExtremeCode.Core.Habra
{
    class HabraSettings : IparserSettings
    {
        public HabraSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public int StartPoint { get; set; } 

        public int EndPoint { get; set; }

        public string Prefix { get; set; } = "page{CurrentId}";

        public string BaseUrl { get; set; } = "https://habr.com/all/";
    }
}
