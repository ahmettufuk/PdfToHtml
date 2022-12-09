using ConverterEditor.Pattern.Strategy.FileConverter.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Factories
{
    public class GetExtensionFactory : IGetExtensionFactory
    {
        public IDictionary<string, IPdfConverter> GetExtension()
        {
            return new Dictionary<string, IPdfConverter>()
            {
                {".pdf" , new PdfToPdfStrategy() },
                { ".docx" , new WordToPdfStrategy() },
                {".doc" , new WordToPdfStrategy() },
                { ".xls" , new ExcelToPdfStrategy() },
                { ".xlsx" , new ExcelToPdfStrategy() },
                { ".png" , new ImageToPdfStrategy() },
                { ".jpg" , new ImageToPdfStrategy() },
                { ".html" , new HtmlToPdfStrategy() }
            };
        }
    }
}
