using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HtmlReports.Core.Template
{
    public class EmbeddedEmbededReportTemplate : IReportTemplate
    {
        private readonly string _embeddedPath;
        private readonly Assembly _assembly;
        private ReportSettings _settings;

        public EmbeddedEmbededReportTemplate(string title, string embeddedPath, Assembly assembly)
        {
            _embeddedPath = embeddedPath;
            _assembly = assembly;
            Title = title;
        }

        public string Body
        {
            get
            {
                var resourceName = _assembly.GetManifestResourceNames().FirstOrDefault(_ => _.EndsWith(_embeddedPath));
                if (resourceName == null)
                    throw new KeyNotFoundException(string.Format("Resource named {0} not found.", _embeddedPath));

                using (var stream = _assembly.GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public string Title { get; private set; }

        public ReportSettings Settings
        {
            get { return _settings ?? (_settings = ReportSettings.Default); }
            private set { _settings = value; }
        }
    }
}
