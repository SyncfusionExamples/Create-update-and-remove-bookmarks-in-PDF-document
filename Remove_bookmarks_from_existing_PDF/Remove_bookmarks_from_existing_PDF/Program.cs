// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Gets all the bookmarks.
PdfBookmarkBase bookmarks = document.Bookmarks;

//Remove parent bookmark by index.
bookmarks.RemoveAt(1);

//Remove child bookmark by bookmark name. 
PdfLoadedBookmark parentBookmark = bookmarks[0] as PdfLoadedBookmark;
parentBookmark.Remove("Section 4");

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);
