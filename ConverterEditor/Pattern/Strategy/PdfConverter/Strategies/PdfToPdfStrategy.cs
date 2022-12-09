using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Strategies
{
    public class PdfToPdfStrategy : IPdfConverter
    {
        public string GetPdfPath(FileModel model)
        {
            return $"{model.FilePathWithoutFileName}\\{model.FileNameWithExtension}";
        }
    }
}
