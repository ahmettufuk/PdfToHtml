using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Strategies
{
    public class HtmlToPdfStrategy : IPdfConverter
    {
        public string GetPdfPath(FileModel model)
        {
            var pdfPath = $"{model.FilePathWithoutFileName}\\{model.FileNameWithoutExtension}.pdf";
            string htmlText = File.ReadAllText($"{model.FilePathWithoutFileName}\\{model.FileNameWithExtension}");
            StringReader stringReader = new StringReader(htmlText.ToString());
            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlParser = new HTMLWorker(document);
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                htmlParser.StartDocument();
                htmlParser.Parse(stringReader);
                htmlParser.EndDocument();
                document.Close();
                var datas = ms.ToArray();
                File.WriteAllBytes(pdfPath, datas);
                ms.Close();

            }

            return pdfPath;

        }
    }
}
