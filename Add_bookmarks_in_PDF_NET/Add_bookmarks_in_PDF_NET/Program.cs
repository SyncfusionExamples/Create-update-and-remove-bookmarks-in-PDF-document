// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load an existing PDF document
FileStream docStream = new FileStream(Path.GetFullPath("../../../Input.pdf"), FileMode.Open, FileAccess.Read);
PdfLoadedDocument document = new PdfLoadedDocument(docStream);

//Creates parent bookmark
PdfBookmark bookmark = document.Bookmarks.Add("Chapter 1");
//Sets the destination page
bookmark.Destination = new PdfDestination(document.Pages[1]);
//Sets the text style and color for parent bookmark 
bookmark.TextStyle = PdfTextStyle.Bold;
bookmark.Color = Color.Red;
//Sets the destination location for parent bookmark 
bookmark.Destination.Location = new PointF(20, 20);

//Adds the child bookmark
PdfBookmark childBookmark = bookmark.Insert(0, "Section 1");
//Sets the destination location for child bookmark 
childBookmark.Destination = new PdfDestination(document.Pages[1]);
childBookmark.Destination.Location = new PointF(0, 200);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}

//Close the document.
document.Close(true);