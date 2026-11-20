using System;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

class TestStamp {
    static void Main() {
        string raw = "test_raw.pdf";
        string finalDoc = "test_stamped.pdf";
        
        using (var writer = new PdfWriter(raw))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(40, 40, 40, 40);
            doc.Add(new Paragraph("Page 1 Cover"));
            doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            doc.Add(new Paragraph("Page 2 Content"));
            doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            doc.Add(new Paragraph("Page 3 Content"));
        }

        using (var reader = new PdfReader(raw))
        using (var writer = new PdfWriter(finalDoc))
        using (var pdf = new PdfDocument(reader, writer))
        using (var doc = new Document(pdf)) {
            int total = pdf.GetNumberOfPages();
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            
            for (int i = 2; i <= total; i++) {
                var page = pdf.GetPage(i);
                var size = page.GetPageSize();
                
                // Add header
                doc.ShowTextAligned(new Paragraph("CAREBRIDGE - COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION")
                    .SetFont(font).SetFontSize(8).SetFontColor(iText.Kernel.Colors.ColorConstants.DARK_GRAY),
                    40, size.GetTop() - 25, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);

                // Add footer
                string footerText = string.Format("Page {0} of {1}", i, total);
                doc.ShowTextAligned(new Paragraph(footerText)
                    .SetFont(font).SetFontSize(8).SetFontColor(iText.Kernel.Colors.ColorConstants.DARK_GRAY),
                    size.GetWidth() - 40, 25, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
            }
        }
        Console.WriteLine("Stamping succeeded!");
    }
}
