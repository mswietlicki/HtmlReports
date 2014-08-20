namespace HtmlReports.Core
{
    public interface IReport
    {
        string Body { get; }
        string Title { get; }

        ReportSettings Settings { get; }
    }

    public class ReportSettings
    {
        public double Margin { get; set; }

        public static ReportSettings Default
        {
            get
            {
                return new ReportSettings
                {
                    Margin = 1.375
                };
            }
        }
    }
}