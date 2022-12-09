using SautinSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterEditor.Pattern.Strategy.FileConverter.Strategies
{
    public class ExcelToPdfStrategy : IPdfConverter
    {
        public string GetPdfPath(FileModel model)
        {
            var excel = new ExcelToPdf();
            excel.OutputFormat = SautinSoft.ExcelToPdf.eOutputFormat.Pdf;

            string  excelFile = $"{model.FilePathWithoutFileName}\\{model.FileNameWithExtension}";
            string pdfFile = Path.ChangeExtension(excelFile, ".pdf");

            try
            {
                excel.ConvertFile(excelFile, pdfFile);
                System.Diagnostics.Process.Start(pdfFile);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            return pdfFile;
        }
    }
}
