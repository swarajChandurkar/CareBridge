using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

class Program {
    static void Main() {
        string rawPdf = "raw_doc.pdf";
        string finalPdf = "CAREBRIDGE – COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION.pdf";

        Console.WriteLine("Step 1: Initializing iText document and styles...");
        DocStyles.Init();

        Console.WriteLine("Step 2: Generating document content (Pass 1)...");
        using (var writer = new PdfWriter(rawPdf))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(36, 36, 36, 36);

            Console.WriteLine("Building Cover Page...");
            SectionPart1.BuildCoverPage(doc);

            Console.WriteLine("Building Table of Contents...");
            SectionPart1.BuildTableOfContents(doc);

            Console.WriteLine("Building Sections 1 to 5...");
            SectionPart1.BuildSections1To5(doc);

            Console.WriteLine("Building Sections 6 to 9...");
            SectionPart2.BuildSections6To9(doc);

            Console.WriteLine("Building Sections 10 and 11...");
            SectionPart3.BuildSections10And11(doc);

            Console.WriteLine("Building Sections 12 to 16...");
            SectionPart4.BuildSections12To16(doc);

            Console.WriteLine("Building Sections 17 to 20, Part 4 & Part 5...");
            SectionPart5.BuildSections17To20AndPart4Part5(doc);
        }

        Console.WriteLine("Step 3: Stamping Running Headers and Footers (Pass 2)...");
        using (var reader = new PdfReader(rawPdf))
        using (var writer = new PdfWriter(finalPdf))
        using (var pdf = new PdfDocument(reader, writer))
        using (var doc = new Document(pdf)) {
            int totalPages = pdf.GetNumberOfPages();
            var fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            for (int i = 2; i <= totalPages; i++) {
                var page = pdf.GetPage(i);
                var size = page.GetPageSize();

                // Running Header
                doc.ShowTextAligned(
                    new Paragraph("CAREBRIDGE - COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION")
                        .SetFont(fontBold).SetFontSize(7.5f).SetFontColor(DocStyles.Primary),
                    36, size.GetTop() - 24, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);

                // Thin rule below header
                var canvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(page);
                canvas.SetStrokeColor(DocStyles.BorderLight).SetLineWidth(0.5f)
                    .MoveTo(36, size.GetTop() - 28)
                    .LineTo(size.GetWidth() - 36, size.GetTop() - 28)
                    .Stroke();

                // Thin rule above footer
                canvas.SetStrokeColor(DocStyles.BorderLight).SetLineWidth(0.5f)
                    .MoveTo(36, 30)
                    .LineTo(size.GetWidth() - 36, 30)
                    .Stroke();

                // Running Footer Left: Statutory Notice
                doc.ShowTextAligned(
                    new Paragraph("Statutory Copyright Documentation • Form XIV [Literary Work: Computer Programme]")
                        .SetFont(fontRegular).SetFontSize(7.0f).SetFontColor(DocStyles.TextMuted),
                    36, 18, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);

                // Running Footer Right: Page Numbering
                string pageStr = string.Format("Page {0} of {1}", i, totalPages);
                doc.ShowTextAligned(
                    new Paragraph(pageStr)
                        .SetFont(fontBold).SetFontSize(7.5f).SetFontColor(DocStyles.Secondary),
                    size.GetWidth() - 36, 18, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
            }
        }

        // Copy final PDF to workspace root as well
        string rootDest = @"C:\Users\akxii\OneDrive\Desktop\CareBridge\CAREBRIDGE – COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION.pdf";
        File.Copy(finalPdf, rootDest, true);

        Console.WriteLine("Documentation generation complete! Output saved to: " + rootDest);
    }
}
