using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using HtmlReports.Core;
using TuesPechkin;

namespace HtmlReports.Exports
{
    public class PdfReport
    {
        private readonly IReport _report;
        public PdfReport(IReport report)
        {
            _report = report;
        }

        public void SaveToFile(string path)
        {
            Debug.Print(Directory.GetCurrentDirectory());
            var converter = TuesPechkin.Factory.Create();
            converter.Error += (pechkin, text) => Debug.Print("Error: " + text);
            converter.Warning += (pechkin, text) => Debug.Print("Warring: " + text);

            var document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    DocumentTitle = _report.Title,
                    ProduceOutline = true,
                    PaperSize = PaperKind.A4,
                    Margins =
                    {
                        All = 1.375,
                        Unit = Unit.Centimeters
                    }
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        HtmlText = _report.Body
                    }
                }
            };

            var pdfBuf = converter.Convert(document);

            using (var file = File.Create(path, pdfBuf.Length))
            {
                file.Write(pdfBuf, 0, pdfBuf.Length);
            }
        }
    }
}
