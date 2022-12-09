using SautinSoft;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PdfToHtml
{
    public partial class Form1 : Form
    {
        private readonly Graphics g;
        public Form1()
        {
            InitializeComponent();
            ControlExtension.Draggable(panel1, true);
            pictureBox1.Cursor= Cursors.Hand;
            g = pictureBox1.CreateGraphics();




        }

        float PointX = 0;
        float PointY = 0;

        float LastX = 0;
        float LastY = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose PDF File";
            dialog.Filter = "(*.pdf)|*.pdf";
            var result =dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePathWithName = dialog.FileName;
                string fileDirectory = Path.GetDirectoryName(filePathWithName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePathWithName);

                PdfFocus pdfFocus = new PdfFocus();
                pdfFocus.OpenPdf(filePathWithName);
                if (pdfFocus.PageCount > 0)
                {
                    //Download Html File
                    pdfFocus.ToHtml(fileDirectory + "\\" + fileNameWithoutExtension + ".html");
                }
                string plainText = File.ReadAllText(fileDirectory + "\\" + fileNameWithoutExtension + ".html");
                plainText = RemoveLibraryTextsInHtmlFile(plainText);

                File.WriteAllText(fileDirectory + "\\" + fileNameWithoutExtension + "_NoFooter.html", plainText);

                webBrowser.DocumentText = plainText;
            }

            

        }

        private static string RemoveLibraryTextsInHtmlFile(string plainText)
        {

            //Css Remove
            plainText = plainText.Replace("d=\" M73,736 L563,736 L563,781 L73,781 Z\"", "");
            plainText = plainText.Replace("matrix(1,0,0,1,-407.7059921875,-754.516015625)", "");

            //p Tags Remove
            plainText = plainText.Replace("support@sautinsoft.com", "");
            plainText = plainText.Replace("PDF Focus .Net 8.5.10.20 trial.", "");
            plainText = plainText.Replace(" Have questions? Email us: ", "");
            plainText = plainText.Replace("Discussions, free help and custom examples for you.", "");
            return plainText;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawLine(Pens.Black, PointX, PointY, LastX, LastY);
            LastX = PointX;
            LastY = PointY;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointX = e.X;
                PointY = e.Y;
                pictureBox1_Paint(this, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }
    }
}
