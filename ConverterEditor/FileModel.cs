using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor
{
    public class FileModel
    {
        public string FilePathWithoutFileName { get; set; }
        public string FileNameWithExtension { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileData { get; set; }
    }
}
