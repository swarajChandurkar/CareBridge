using System;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

class TestApi {
    static void Main() {
        string dest = "test_api.pdf";
        using (var writer = new PdfWriter(dest))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(36, 36, 36, 36);
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            
            var p = new Paragraph("Test Title").SetFont(bold).SetFontSize(16).SetFontColor(new DeviceRgb(0, 91, 130));
            doc.Add(p);

            var table = new Table(UnitValue.CreatePercentArray(new float[] { 30, 70 })).UseAllAvailableWidth();
            table.AddHeaderCell(new Cell().Add(new Paragraph("Header 1").SetFont(bold)).SetBackgroundColor(new DeviceRgb(230, 240, 245)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Header 2").SetFont(bold)).SetBackgroundColor(new DeviceRgb(230, 240, 245)));
            table.AddCell(new Cell().Add(new Paragraph("Row 1 Col 1").SetFont(font)));
            table.AddCell(new Cell().Add(new Paragraph("Row 1 Col 2").SetFont(font)));
            doc.Add(table);
        }
        Console.WriteLine("API Test Succeeded!");
    }
}
