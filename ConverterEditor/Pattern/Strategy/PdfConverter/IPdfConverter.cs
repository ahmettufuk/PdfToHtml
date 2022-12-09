using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter
{
    public interface IPdfConverter
    {
        string GetPdfPath(FileModel model);
    }
}
