using System.IO;
using DotLiquid;

namespace HtmlReports.Engines.Liquid
{
    public class RootDir : Tag
    {
        public override void Render(Context context, TextWriter result)
        {
            result.Write(Directory.GetCurrentDirectory());
        }
    }
}