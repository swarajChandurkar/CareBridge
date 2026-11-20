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

public static class DocStyles {
    public static PdfFont FontRegular;
    public static PdfFont FontBold;
    public static PdfFont FontItalic;
    public static PdfFont FontMono;

    // Palette
    public static Color Primary = new DeviceRgb(0, 91, 130);       // #005B82 Deep Navy
    public static Color Secondary = new DeviceRgb(33, 62, 85);     // #213E55 Dark Slate
    public static Color AccentTeal = new DeviceRgb(0, 150, 166);    // #009688 Accent Teal
    public static Color TextDark = new DeviceRgb(30, 41, 59);      // #1E293B Charcoal
    public static Color TextMuted = new DeviceRgb(100, 116, 139);  // #64748B Muted Slate
    public static Color TableHeaderBg = new DeviceRgb(0, 91, 130);
    public static Color ZebraBg = new DeviceRgb(245, 249, 252);
    public static Color CodeBg = new DeviceRgb(244, 246, 248);
    public static Color BorderLight = new DeviceRgb(203, 213, 225);
    public static Color CalloutNoteBg = new DeviceRgb(235, 248, 250);
    public static Color CalloutWarnBg = new DeviceRgb(254, 249, 231);
    public static Color WarnBorder = new DeviceRgb(217, 119, 6);   // #D97706 Amber

    public static void Init() {
        FontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        FontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        FontItalic = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);
        FontMono = PdfFontFactory.CreateFont(StandardFonts.COURIER);
    }

    public static void AddH1(Document doc, string num, string text) {
        var p = new Paragraph(string.Format("{0}. {1}", num, text.ToUpper()))
            .SetFont(FontBold)
            .SetFontSize(13)
            .SetFontColor(Primary)
            .SetMarginTop(18)
            .SetMarginBottom(6)
            .SetKeepWithNext(true);
        doc.Add(p);

        // Underline rule
        var table = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        table.SetMarginBottom(8);
        var cell = new Cell().SetHeight(1.5f).SetBackgroundColor(Primary).SetBorder(Border.NO_BORDER);
        table.AddCell(cell);
        doc.Add(table);
    }

    public static void AddH2(Document doc, string num, string text) {
        var p = new Paragraph(string.Format("{0} {1}", num, text))
            .SetFont(FontBold)
            .SetFontSize(11)
            .SetFontColor(Secondary)
            .SetMarginTop(12)
            .SetMarginBottom(4)
            .SetKeepWithNext(true);
        doc.Add(p);
    }

    public static void AddH3(Document doc, string text) {
        var p = new Paragraph(text)
            .SetFont(FontBold)
            .SetFontSize(9.5f)
            .SetFontColor(AccentTeal)
            .SetMarginTop(8)
            .SetMarginBottom(3)
            .SetKeepWithNext(true);
        doc.Add(p);
    }

    public static void AddP(Document doc, string text) {
        var p = new Paragraph(text)
            .SetFont(FontRegular)
            .SetFontSize(8.5f)
            .SetFontColor(TextDark)
            .SetMultipliedLeading(1.25f)
            .SetMarginBottom(5);
        doc.Add(p);
    }

    public static void AddBullet(Document doc, string boldPrefix, string text) {
        var p = new Paragraph()
            .SetFont(FontRegular)
            .SetFontSize(8.5f)
            .SetFontColor(TextDark)
            .SetMultipliedLeading(1.25f)
            .SetMarginLeft(14)
            .SetMarginBottom(3);
        p.Add(new Text("•  ").SetFont(FontBold).SetFontColor(Primary));
        if (!string.IsNullOrEmpty(boldPrefix)) {
            p.Add(new Text(boldPrefix + ": ").SetFont(FontBold).SetFontColor(Secondary));
        }
        p.Add(new Text(text));
        doc.Add(p);
    }

    public static void AddCallout(Document doc, string title, string text, bool isWarning) {
        var table = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        table.SetMarginTop(6).SetMarginBottom(8);
        
        Color bg = isWarning ? CalloutWarnBg : CalloutNoteBg;
        Color borderCol = isWarning ? WarnBorder : AccentTeal;
        
        var cell = new Cell().SetBackgroundColor(bg).SetPadding(8);
        cell.SetBorder(new SolidBorder(BorderLight, 0.5f));
        cell.SetBorderLeft(new SolidBorder(borderCol, 3.0f));

        var pTitle = new Paragraph(title)
            .SetFont(FontBold)
            .SetFontSize(8.5f)
            .SetFontColor(borderCol)
            .SetMarginBottom(3);
        cell.Add(pTitle);

        var pText = new Paragraph(text)
            .SetFont(FontRegular)
            .SetFontSize(8.0f)
            .SetFontColor(TextDark)
            .SetMultipliedLeading(1.2f)
            .SetMarginBottom(0);
        cell.Add(pText);

        table.AddCell(cell);
        doc.Add(table);
    }

    public static void AddCode(Document doc, string codeText) {
        var table = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        table.SetMarginTop(5).SetMarginBottom(7);

        var cell = new Cell().SetBackgroundColor(CodeBg).SetPadding(6);
        cell.SetBorder(new SolidBorder(BorderLight, 0.5f));

        var p = new Paragraph(codeText)
            .SetFont(FontMono)
            .SetFontSize(7.2f)
            .SetFontColor(TextDark)
            .SetMultipliedLeading(1.15f)
            .SetMarginBottom(0);
        cell.Add(p);

        table.AddCell(cell);
        doc.Add(table);
    }

    public static void AddTable(Document doc, string[] headers, float[] colWidths, List<string[]> rows) {
        var table = new Table(UnitValue.CreatePercentArray(colWidths)).UseAllAvailableWidth();
        table.SetMarginTop(6).SetMarginBottom(8);

        // Header
        for (int i = 0; i < headers.Length; i++) {
            var cell = new Cell().Add(new Paragraph(headers[i]).SetFont(FontBold).SetFontSize(8.0f).SetFontColor(ColorConstants.WHITE))
                .SetBackgroundColor(TableHeaderBg)
                .SetPadding(4.5f)
                .SetBorder(new SolidBorder(BorderLight, 0.5f));
            table.AddHeaderCell(cell);
        }

        // Data Rows
        for (int r = 0; r < rows.Count; r++) {
            Color rowBg = (r % 2 == 1) ? ZebraBg : ColorConstants.WHITE;
            string[] rowData = rows[r];
            for (int c = 0; c < rowData.Length; c++) {
                var cell = new Cell().Add(new Paragraph(rowData[c]).SetFont(FontRegular).SetFontSize(7.5f).SetFontColor(TextDark).SetMultipliedLeading(1.15f))
                    .SetBackgroundColor(rowBg)
                    .SetPadding(3.5f)
                    .SetBorder(new SolidBorder(BorderLight, 0.5f));
                table.AddCell(cell);
            }
        }

        doc.Add(table);
    }
}
