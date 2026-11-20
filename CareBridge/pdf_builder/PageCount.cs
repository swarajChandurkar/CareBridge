using System;
using iText.Kernel.Pdf;

class PageCount {
    static void Main() {
        using (var reader = new PdfReader("CAREBRIDGE – COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION.pdf"))
        using (var pdf = new PdfDocument(reader)) {
            Console.WriteLine("Total PDF Pages: " + pdf.GetNumberOfPages());
        }
    }
}
