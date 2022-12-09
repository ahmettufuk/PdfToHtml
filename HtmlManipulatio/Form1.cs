using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace HtmlManipulatio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            var doc = new HtmlDocument();
            doc.Load("C:\\Users\\Netix-61\\Desktop\\Signed\\test.html");

            var node =new HtmlNode(HtmlNodeType.Document , doc , 1);
            var result1 = node.SelectNodes("//span[@class='ssdspan cs3']");
            var result2 = node.SelectNodes("//span[@class='ssdspan cs4']");
            var result3 = node.SelectNodes("//span[@class='ssdspan cs5']");
            foreach (var item in result1)
            {
                list.Add(item.ParentNode.InnerText);
            }
            foreach (var item in result2)
            {
                list.Add(item.ParentNode.InnerText);
            }
            foreach (var item in result3)
            {
                list.Add(item.ParentNode.InnerText);
            }




            var web = new HtmlWeb();


        }
    }
}
