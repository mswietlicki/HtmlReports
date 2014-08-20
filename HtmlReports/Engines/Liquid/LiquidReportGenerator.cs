using DotLiquid;
using HtmlReports.Core;
using HtmlReports.Core.Template;

namespace HtmlReports.Engines.Liquid
{
    public class LiquidReportGenerator
    {
        public IReport Generate(IReportTemplate template, object reportData)
        {
            Template.RegisterTag<RootDir>("RootDir");
            
            var engine = Template.Parse(template.Body);

            var hash = Hash.FromAnonymousObject(reportData);
            return new HtmlReport(template.Title, engine.Render(hash), template.Settings);
        }
    }
}
