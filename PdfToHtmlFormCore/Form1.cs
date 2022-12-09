using Aspose.Pdf;

namespace PdfToHtmlFormCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\\Users\\Netix-61\\Desktop\\Signed";
            Document document = new Document(filePath + "\\test.pdf");

            document.Save(filePath + "\\test.html", SaveFormat.Html);






        }




    }
}