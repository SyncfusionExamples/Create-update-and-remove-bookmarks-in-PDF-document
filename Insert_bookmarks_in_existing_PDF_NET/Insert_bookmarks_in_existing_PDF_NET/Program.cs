// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document.
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Inserts a new bookmark in the existing bookmark collection.
PdfBookmark bookmark = document.Bookmarks.Insert(0, "Title Page");
//Sets the destination page and location.
bookmark.Destination = new PdfDestination(document.Pages[0]);
bookmark.Destination.Location = new PointF(0, 0);
//Sets the text style and color.
bookmark.TextStyle = PdfTextStyle.Bold;
bookmark.Color = Color.Green;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);

