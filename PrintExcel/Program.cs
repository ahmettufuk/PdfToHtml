using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

string filePath = "C:\\Users\\Netix-61\\Desktop\\Signed\\file_example_XLS_50.xls";
string filePathPdf = "C:\\Users\\Netix-61\\Desktop\\Signed\\file_example_XLS_50.pdf";

var excel = new Excel.Application();

excel.Visible = false;

Excel.Workbooks books = excel.Workbooks;
Excel.Workbook wb = books.Open(filePath);
wb.Activate();

Excel.Worksheet ws;
wb.SaveAs(filePathPdf);
//wb.PrintOutEx();









