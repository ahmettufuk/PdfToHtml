using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Factories
{
    public interface IGetExtensionFactory
    {
        IDictionary<string, IPdfConverter> GetExtension();
    }
}
