using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Strategies
{
    public class WordToPdfStrategy : IPdfConverter
    {
        public string GetPdfPath(FileModel model)
        {
            string  pdfPath = $"{model.FilePathWithoutFileName}\\{model.FileNameWithoutExtension}.pdf";
            DocumentCore document = DocumentCore.Load($"{model.FilePathWithoutFileName}\\{model.FileNameWithExtension}");
            document.Save(pdfPath);



            return pdfPath;
        }

        
    }
}
