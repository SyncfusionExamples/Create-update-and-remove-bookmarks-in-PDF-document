// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Drawing;

//Load the PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Gets all the bookmarks
PdfBookmarkBase bookmarks = document.Bookmarks;
//Gets the first bookmark and changes the properties of the bookmark
PdfLoadedBookmark bookmark = bookmarks[0] as PdfLoadedBookmark;
bookmark.Destination = new PdfDestination(document.Pages[2]);
bookmark.Color = Color.Green;
bookmark.TextStyle = PdfTextStyle.Bold;
bookmark.Title = "Chapter2";

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

