using AngleSharp.Dom.Html;

namespace парсер_HTML_на_Cshp_ExtremeCode.Core
{
    interface IParser<T> where T:class // Обобщённый интерфейс
    {
        T Parse(IHtmlDocument document);
    }
}
