namespace HtmlReports.Core.Template
{
    public class MemoryReportTemplate : IReportTemplate
    {
        public MemoryReportTemplate()
        {
            Settings = new ReportSettings
            {
                Margin = 1.375
            };
        }
        public MemoryReportTemplate(string title, string htmlBody)
            : this()
        {
            Title = title;
            Body = htmlBody;
        }

        public string Body { get; private set; }
        public string Title { get; private set; }
        public ReportSettings Settings { get; private set; }
    }
}
