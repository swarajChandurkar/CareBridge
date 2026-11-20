using System;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

class TestPages {
    static void Main() {
        string dest = "test_pages.pdf";
        using (var writer = new PdfWriter(dest))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(40, 40, 40, 40);
            for (int i = 0; i < 3; i++) {
                doc.Add(new Paragraph("This is page content " + (i + 1)));
                if (i < 2) doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            }
            
            int total = pdf.GetNumberOfPages();
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            for (int i = 1; i <= total; i++) {
                var page = pdf.GetPage(i);
                var canvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(page);
                var pageSize = page.GetPageSize();
                
                // header
                canvas.BeginText().SetFontAndSize(font, 8)
                    .MoveText(40, pageSize.GetTop() - 25)
                    .ShowText("CAREBRIDGE – SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION")
                    .EndText();
                    
                // footer
                string footer = string.Format("Page {0} of {1}", i, total);
                canvas.BeginText().SetFontAndSize(font, 8)
                    .MoveText(pageSize.GetWidth() - 100, 25)
                    .ShowText(footer)
                    .EndText();
            }
        }
        Console.WriteLine("Pages test succeeded!");
    }
}
