using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WordToHtml
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

            var bytes = File.ReadAllBytes(filePath + "\\example03.docx");

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);
                using (WordprocessingDocument doc = WordprocessingDocument.Open(ms,true))
                {
                    HtmlConverterSettings settings = new HtmlConverterSettings()
                    {
                        PageTitle = ""
                    };

                    XElement html = HtmlConverter.ConvertToHtml(doc, settings);

                    File.WriteAllText(filePath + "\\example03_html.html", html.ToStringNewLineOnAttributes());

                }
            }


        }
    }
}
