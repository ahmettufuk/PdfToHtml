using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Strategies
{
    public class ImageToPdfStrategy : IPdfConverter
    {
        public string GetPdfPath(FileModel model)
        {
            var pdfPath = $"{model.FilePathWithoutFileName}\\{model.FileNameWithoutExtension}.pdf";
            var imagePath = $"{model.FilePathWithoutFileName}\\{model.FileNameWithExtension}";

            iTextSharp.text.Rectangle pageSize = null;

            using (var srcImage = new Bitmap(imagePath))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(imagePath);
                document.Add(image);
                document.Close();

                File.WriteAllBytes(pdfPath, ms.ToArray());
            }



            return pdfPath;
        }
    }
}
