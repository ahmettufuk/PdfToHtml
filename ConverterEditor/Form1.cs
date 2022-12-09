using ConverterEditor.Pattern.Strategy.FileConverter;
using ConverterEditor.Pattern.Strategy.FileConverter.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConverterEditor
{
    public partial class Form1 : Form
    {
        private readonly IPdfConverter pdfConverter;
        public Form1()
        {
            this.pdfConverter= new PdfConverter(new GetExtensionFactory());
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result =  dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileModel model = GetModelDatas(dialog);
                var pdfPath = pdfConverter.GetPdfPath(model);

                axAcroPDF1.src = pdfPath + "#toolbar=0&navpanes=1&scrollbar=0&statusbar=0";
                

            }
        }


        private FileModel GetModelDatas(OpenFileDialog dialog)
        {
            var data = File.ReadAllBytes(dialog.FileName);
            var extension = Path.GetExtension(dialog.FileName);
            var fileNameWithExtension = Path.GetFileName(dialog.FileName);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(dialog.FileName);
            var filePathWithoutFileName = Path.GetDirectoryName(dialog.FileName);

            return new FileModel { FileData = data, FileExtension = extension, FileNameWithExtension = fileNameWithExtension, FileNameWithoutExtension = fileNameWithoutExtension, FilePathWithoutFileName = filePathWithoutFileName };
        }

    }
}
