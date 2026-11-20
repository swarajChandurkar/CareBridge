using System;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Event;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

class HeaderFooterHandler : IEventHandler {
    public void HandleEvent(Event currentEvent) {
        PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
        PdfDocument pdfDoc = docEvent.GetDocument();
        PdfPage page = docEvent.GetPage();
        int pageNumber = pdfDoc.GetPageNumber(page);
        
        // Skip cover page
        if (pageNumber == 1) return;
        
        Rectangle pageSize = page.GetPageSize();
        var canvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        
        canvas.BeginText().SetFontAndSize(font, 8)
            .MoveText(40, pageSize.GetTop() - 25)
            .ShowText("CAREBRIDGE - TECHNICAL DOCUMENTATION FOR COPYRIGHT REGISTRATION")
            .EndText();
            
        canvas.BeginText().SetFontAndSize(font, 8)
            .MoveText(pageSize.GetWidth() - 100, 25)
            .ShowText("Page " + pageNumber)
            .EndText();
    }
}

class TestHandler {
    static void Main() {
        string dest = "test_handler.pdf";
        using (var writer = new PdfWriter(dest))
        using (var pdf = new PdfDocument(writer)) {
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new HeaderFooterHandler());
            using (var doc = new Document(pdf, PageSize.A4)) {
                doc.SetMargins(40, 40, 40, 40);
                doc.Add(new Paragraph("Cover Page Content"));
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(new Paragraph("Page 2 Content"));
                doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                doc.Add(new Paragraph("Page 3 Content"));
            }
        }
        Console.WriteLine("Handler test succeeded!");
    }
}
