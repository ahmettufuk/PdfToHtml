using ConverterEditor.Pattern.Strategy.FileConverter.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter
{
    public class PdfConverter : IPdfConverter 
    {
        private readonly IGetExtensionFactory getExtension;

        public PdfConverter(IGetExtensionFactory getExtension)
        {
            this.getExtension = getExtension;
        }

        public string GetPdfPath(FileModel model)
        {
            return getExtension.GetExtension()[model.FileExtension].GetPdfPath(model);
        }
    }
}
