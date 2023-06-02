// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Gets all the bookmarks
PdfBookmarkBase bookmark = document.Bookmarks;
//Get the bookmark page index
int index = bookmark[0].Destination.PageIndex;

Console.WriteLine("Bookmark index: " + index);
document.Close(true);
Console.ReadLine();