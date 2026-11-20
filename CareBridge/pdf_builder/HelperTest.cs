using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

class HelperTest {
    static PdfFont fontRegular;
    static PdfFont fontBold;
    static PdfFont fontMono;
    static Color cPrimary = new DeviceRgb(0, 91, 130);
    static Color cDark = new DeviceRgb(30, 41, 59);
    static Color cLightBg = new DeviceRgb(245, 249, 252);
    static Color cCodeBg = new DeviceRgb(244, 246, 248);
    static Color cBorder = new DeviceRgb(203, 213, 225);

    static void Main() {
        fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        fontMono = PdfFontFactory.CreateFont(StandardFonts.COURIER);

        using (var writer = new PdfWriter("test_helper.pdf"))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(36, 36, 36, 36);
            
            var p = new Paragraph("Helper Test").SetFont(fontBold).SetFontSize(16).SetFontColor(cPrimary);
            doc.Add(p);

            var code = new Paragraph("string x = \"hello\";\nint y = 42;").SetFont(fontMono).SetFontSize(8).SetBackgroundColor(cCodeBg).SetPadding(6);
            doc.Add(code);
        }
        Console.WriteLine("Helper test passed!");
    }
}
