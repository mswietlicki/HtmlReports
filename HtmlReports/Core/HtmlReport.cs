namespace HtmlReports.Core
{
    public class HtmlReport : IReport
    {
        private readonly string _title;
        private readonly string _html;
        private readonly ReportSettings _settings;

        public HtmlReport(string title, string html, ReportSettings settings)
        {
            _title = title;
            _html = html;
            _settings = settings;
        }

        public string Body
        {
            get { return _html; }
        }

        public string Title
        {
            get { return _title; }
        }

        public ReportSettings Settings
        {
            get { return _settings; }
        }
    }
}