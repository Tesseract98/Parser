using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace парсер_HTML_на_Cshp_ExtremeCode.Core
{
    class ParserWorker<T> where T: class // Обобщённый класс
    {
        IParser<T> parser;
        IparserSettings iparserSettings;

        HtmlLoader loader;

        bool isActive;

        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IparserSettings Settings
        {
            get
            {
                return iparserSettings;
            }
            set
            {
                iparserSettings = value;
                loader = new HtmlLoader(value);
            }
        }


        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IparserSettings iparserSettings):this(parser)
        {
            this.iparserSettings = iparserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker(); // Task.Run(() => Worker());
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for(int i = iparserSettings.StartPoint; i < iparserSettings.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }
                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();
                var document = await domParser.ParseAsync(source);
                var result =  parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
