


using Aspose.Pdf;

string filePath = @"C:\\Users\\Netix-61\\Desktop\\Signed";
Document document = new Document(filePath + "\\test.pdf");

document.Save(filePath + "\\test.html", SaveFormat.Html);
