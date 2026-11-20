using System;
using System.Collections.Generic;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

public class SingleSlideDocBuilder {
    public static void Main() {
        string rawPdf = "temp_slide_raw.pdf";
        string finalPdf = @"..\CareBridge_5Minute_Slide_Presentation_Script.pdf";

        DocStyles.Init();

        using (var writer = new PdfWriter(rawPdf))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(34, 34, 34, 34);

            BuildHeader(doc);
            BuildPart1_Speech(doc);
            BuildPart2_PlainEnglish(doc);
            BuildPart3_WorkflowStory(doc);
            BuildPart4_ExaminerQnA(doc);
        }

        // Pass 2: Stamp Running Headers and Footers
        using (var reader = new PdfReader(rawPdf))
        using (var writer = new PdfWriter(finalPdf))
        using (var pdf = new PdfDocument(reader, writer))
        using (var doc = new Document(pdf)) {
            int totalPages = pdf.GetNumberOfPages();
            var fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            for (int i = 1; i <= totalPages; i++) {
                var page = pdf.GetPage(i);
                var size = page.GetPageSize();

                // Running Header
                doc.ShowTextAligned(
                    new Paragraph("CAREBRIDGE • SYSTEM IMPLEMENTATION SLIDE DEFENSE GUIDE (5-MIN SCRIPT)")
                        .SetFont(fontBold).SetFontSize(7.5f).SetFontColor(DocStyles.Primary),
                    34, size.GetTop() - 22, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);

                var canvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(page);
                canvas.SetStrokeColor(DocStyles.BorderLight).SetLineWidth(0.5f)
                    .MoveTo(34, size.GetTop() - 26)
                    .LineTo(size.GetWidth() - 34, size.GetTop() - 26)
                    .Stroke();

                canvas.SetStrokeColor(DocStyles.BorderLight).SetLineWidth(0.5f)
                    .MoveTo(34, 28)
                    .LineTo(size.GetWidth() - 34, 28)
                    .Stroke();

                doc.ShowTextAligned(
                    new Paragraph("Confidence & Speaking Guide • Slide: System Implementation")
                        .SetFont(fontRegular).SetFontSize(7.0f).SetFontColor(DocStyles.TextMuted),
                    34, 16, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);

                string pageStr = string.Format("Page {0} of {1}", i, totalPages);
                doc.ShowTextAligned(
                    new Paragraph(pageStr)
                        .SetFont(fontBold).SetFontSize(7.5f).SetFontColor(DocStyles.Secondary),
                    size.GetWidth() - 34, 16, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
            }
        }

        // Copy to workspace root
        string rootDest = @"..\..\CareBridge_5Minute_Slide_Presentation_Script.pdf";
        try { File.Copy(finalPdf, rootDest, true); } catch {}
        if (File.Exists(rawPdf)) { try { File.Delete(rawPdf); } catch {} }

        Console.WriteLine("Single Slide Presentation PDF created at: " + finalPdf);
    }

    private static void BuildHeader(Document doc) {
        var table = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        table.SetMarginBottom(10);

        var cell = new Cell().SetBackgroundColor(DocStyles.Primary).SetPadding(12);
        cell.SetBorder(Border.NO_BORDER);

        cell.Add(new Paragraph("INDIVIDUAL SLIDE DEFENSE • 5-MINUTE CONFIDENCE SCRIPT")
            .SetFont(DocStyles.FontBold).SetFontSize(8.0f).SetFontColor(DocStyles.AccentTeal).SetMarginBottom(2));

        cell.Add(new Paragraph("SYSTEM IMPLEMENTATION SLIDE: EXACT WORD-FOR-WORD SCRIPT")
            .SetFont(DocStyles.FontBold).SetFontSize(15.0f).SetFontColor(ColorConstants.WHITE).SetMarginBottom(4));

        cell.Add(new Paragraph("Tailored for non-technical speakers presenting to experienced evaluators. Includes plain-English explanations, story workflow, and bulletproof viva answers.")
            .SetFont(DocStyles.FontRegular).SetFontSize(9.0f).SetFontColor(new DeviceRgb(220, 235, 245)).SetMarginBottom(0));

        table.AddCell(cell);
        doc.Add(table);
    }

    private static void BuildPart1_Speech(Document doc) {
        DocStyles.AddH1(doc, "1", "Word-for-Word 5-Minute Speaking Script");
        DocStyles.AddP(doc, "Read this at a steady, confident pace (approx. 110-120 words per minute). Practice looking up at the evaluator after every key sentence.");

        DocStyles.AddCallout(doc, "[0:00 - 0:45] Opening & Purpose of the Slide",
            "\"Good morning / afternoon respected examiners and evaluators.\n\n" +
            "I will be explaining the System Implementation of CareBridge. This slide is the core technical engine of our project—it shows how all theoretical ideas were translated into real, functional software.\n\n" +
            "Our primary objective was to replace slow, error-prone paper handoffs with an end-to-end digital pipeline that links five distinct healthcare participants—Patients, Hospitals, Doctors, Diagnostic Labs, and Medical Stores—all operating seamlessly on a single, synchronized platform.\"", false);

        DocStyles.AddCallout(doc, "[0:45 - 2:15] Explaining the Tech Stack Table (Left Side of Slide)",
            "\"Looking at the table on the left, we selected an enterprise-grade technology stack based on stability, speed, and security:\n\n" +
            "1. Framework — ASP.NET Web Forms: We used ASP.NET Web Forms on Microsoft .NET Framework 4.8. It gives us an event-driven model and Master Pages, which allowed us to create role-guarded security templates for each department.\n\n" +
            "2. Programming Language — C#: All backend business logic, validation rules, and calculations are written in C#. C# gives us strong type safety and robust memory management.\n\n" +
            "3. Frontend — HTML, CSS, and JavaScript: For the user interface, HTML structures the content, CSS styled with Bootstrap 3.4.1 ensures a clean, responsive layout across all screens, and JavaScript with jQuery handles client-side dynamic controls.\n\n" +
            "4. Backend & Runtime — .NET Framework 4.8: This runtime environment hosts our application on IIS Express, managing connection pooling, server lifecycle, and cryptographic security.\n\n" +
            "5. Database & Management — Microsoft SQL Server & SSMS: We used Microsoft SQL Server as our relational database engine to store 15 normalized tables with 25 foreign key constraints, ensuring full ACID compliance and zero data corruption. SQL Server Management Studio (SSMS) was used to design schemas, write optimized T-SQL queries, and manage database security.\n\n" +
            "Key Technical Detail: For data access, we used Dapper 2.1 Micro-ORM. Instead of heavy ORMs that slow down queries, Dapper executes high-speed parameterized SQL commands that completely protect the application from SQL injection attacks.\"", false);

        DocStyles.AddCallout(doc, "[2:15 - 3:15] Explaining the 5 Major Modules (Top Right of Slide)",
            "\"Moving to the top right of the slide, the system is segregated into five dedicated modules based on user roles:\n\n" +
            "• Patient Module: Self-registration, symptom checklist, doctor recommendation, appointment booking, and viewing electronic prescriptions and lab reports.\n" +
            "• Hospital Module: The administrator dashboard that provisions staff accounts for doctors, labs, and pharmacies with strict relational integrity.\n" +
            "• Doctor Module: Outpatient queue management, patient history examination, digital prescribing, and ordering lab investigations.\n" +
            "• Laboratory Module: Processing incoming test requisitions and uploading verified PDF diagnostic reports.\n" +
            "• Medical Store Module: Live queue of unbilled prescriptions, line-item pricing, and instant receipt generation.\n\n" +
            "Each module has its own Master Page that evaluates session roles. If someone tries to change the URL to access another role's page, the system immediately blocks them and redirects to Login.\"", false);

        DocStyles.AddCallout(doc, "[3:15 - 4:30] Explaining the System Workflow (Bottom Right of Slide)",
            "\"Now, let us walk through the System Workflow at the bottom right. This represents a complete, real-world episode of care:\n\n" +
            "1. Patient Registration & Symptom Entry: The patient logs in and selects symptoms from a 42-symptom checklist.\n" +
            "2. Doctor Recommendation: Instead of a black-box AI, our system executes a transparent, deterministic majority-voting algorithm against our database mapping table, matching the symptoms to the most relevant medical specialization—with a safe fallback to General Physician.\n" +
            "3. Appointment Booking: The patient selects a matching doctor, pick a date and time, and the appointment is created with status 'Pending'.\n" +
            "4. Doctor Consultation: The doctor sees the patient in the queue, confirms the visit, and reviews past medical records.\n" +
            "5. Prescription & Lab Request: The doctor writes a digital prescription—storing multiple medicines dynamically using ViewState—and, if needed, orders a diagnostic lab test. The appointment moves to 'Completed'.\n" +
            "6. Lab Report Upload: The laboratory sees the order, updates status to 'In Progress', tests the sample, and uploads the verified PDF report. The patient can immediately view and download it.\n" +
            "7. Medical Store Billing: The hospital pharmacy's queue uses an optimized SQL query to pull only unbilled prescriptions. The pharmacist enters prices, generates the bill, and prints the invoice.\"", false);

        DocStyles.AddCallout(doc, "[4:30 - 5:00] Conclusion & Hand-off",
            "\"In conclusion, this implementation connects the entire healthcare journey—from first symptom to medicine dispensing—in approximately 25 minutes with zero physical paper exchange, eliminating lost records and transcription errors.\n\n" +
            "Thank you. I am now glad to answer any questions on the implementation.\"", false);
    }

    private static void BuildPart2_PlainEnglish(Document doc) {
        DocStyles.AddH1(doc, "2", "Plain-English Dictionary (What Each Term Actually Means)");
        DocStyles.AddP(doc, "If the evaluator asks you to define anything on your slide, use these simple real-world analogies:");

        string[] headers = new string[] { "Slide Item", "Simple Everyday Analogy", "What It Actually Does in Code", "Impressive Technical Phrase to Use" };
        float[] widths = new float[] { 20, 24, 30, 26 };
        List<string[]> rows = new List<string[]>();

        rows.Add(new string[] { "Framework (ASP.NET Web Forms)", "The Construction Blueprint", "A Microsoft web system where buttons and textboxes on web pages are connected directly to C# backend events.", "\"Event-driven web model with Master Page authorization guards.\"" });
        rows.Add(new string[] { "Language (C#)", "The Brain / Executive", "The programming language where all rules, checks, validations, and calculations are written.", "\"Type-safe, object-oriented language running on the CLR.\"" });
        rows.Add(new string[] { "Frontend (HTML/CSS/JS)", "The Skin & Decorator", "HTML is the skeleton, CSS (Bootstrap) makes it look attractive and mobile-friendly, and JavaScript handles dynamic button actions.", "\"Responsive 12-column grid with jQuery DOM interactions.\"" });
        rows.Add(new string[] { "Backend (.NET 4.8)", "The Engine Room", "The underlying Microsoft software platform that runs the website, controls memory, manages security, and connects to databases.", "\"Enterprise Windows CLR runtime hosting the application on IIS.\"" });
        rows.Add(new string[] { "Database (SQL Server)", "The Digital Bank Vault", "The database engine that stores all tables (patients, doctors, bills) safely without losing data even during power loss.", "\"ACID-compliant RDBMS with 25 foreign key constraints.\"" });
        rows.Add(new string[] { "Database Mgmt (SSMS)", "The Workbench / Tool", "The desktop software program developers open to visually create tables, run test queries, and manage SQL Server.", "\"Administrative GUI client used to design and execute T-SQL scripts.\"" });
        rows.Add(new string[] { "Micro-ORM (Dapper)", "The Superfast Courier", "A lightweight tool that takes data from C# and carries it into SQL Server safely, preventing hackers from tampering with queries.", "\"High-performance Micro-ORM executing parameterized SQL queries.\"" });

        DocStyles.AddTable(doc, headers, widths, rows);
    }

    private static void BuildPart3_WorkflowStory(Document doc) {
        DocStyles.AddH1(doc, "3", "How to Explain the System Workflow Like a Story");
        DocStyles.AddP(doc, "Evaluators love storytelling because it shows you understand practical software operations. Memorize this sequence:");

        DocStyles.AddBullet(doc, "Step 1: Patient Enters Symptoms", "Patient logs in and checks: 'Chest Pain' + 'Shortness of breath'.");
        DocStyles.AddBullet(doc, "Step 2: Recommendation (Majority Voting)", "The database counts mappings. Cardiologist gets 2 votes, General Physician gets 0. The system recommends a Cardiologist. If no match exists, it safely defaults to General Physician.");
        DocStyles.AddBullet(doc, "Step 3: Booking", "Patient selects Dr. Anjali Mehta. Appointment is saved with status = 'Pending'.");
        DocStyles.AddBullet(doc, "Step 4: Doctor Consultation", "Dr. Mehta sees patient in queue, clicks 'Confirm'. Examines patient, types Paracetamol 500mg, and clicks 'Finish'. Status becomes 'Completed'.");
        DocStyles.AddBullet(doc, "Step 5: Lab Ordering & PDF Upload", "Dr. Mehta orders a Blood Test. Diagnostic Lab sees order in queue, changes status to 'In Progress', performs test, and uploads the PDF report. Status becomes 'Completed'.");
        DocStyles.AddBullet(doc, "Step 6: Pharmacy Billing", "Hospital pharmacy sees the prescription in their queue. Pharmacist enters prices for the medicine lines, generates the bill, and clicks print. Transaction complete!");
    }

    private static void BuildPart4_ExaminerQnA(Document doc) {
        DocStyles.AddH1(doc, "4", "Top 5 'Trap' Questions & Bulletproof Answers");
        DocStyles.AddP(doc, "Evaluators test whether you understand the implementation. Use these ready-made answers:");

        DocStyles.AddCallout(doc, "Trap Q1: \"Is your doctor recommendation an Artificial Intelligence / Machine Learning model?\"",
            "Your Bulletproof Answer:\n" +
            "\"No, sir/ma'am, and that was an intentional design decision. In clinical healthcare, triage advice must be transparent, deterministic, and auditable. We implemented a deterministic majority-voting frequency count algorithm on our relational database mapping table. This allows doctors and medical boards to inspect, calibrate, and update symptom mappings directly in the database without touching or recompiling the code.\"", false);

        DocStyles.AddCallout(doc, "Trap Q2: \"Why did you choose Dapper instead of Entity Framework?\"",
            "Your Bulletproof Answer:\n" +
            "\"Entity Framework is a heavy ORM that introduces query-generation overhead, memory tracking bloat, and slower execution. Dapper is a lightweight micro-ORM that extends IDbConnection directly. It executes fast parameterized queries with speeds nearly identical to raw ADO.NET DataReaders, while protecting us 100% against SQL injection.\"", false);

        DocStyles.AddCallout(doc, "Trap Q3: \"What is the difference between SQL Server and SSMS on your slide?\"",
            "Your Bulletproof Answer:\n" +
            "\"Microsoft SQL Server is the actual database engine that runs as a background service and stores all 15 tables securely on disk. SQL Server Management Studio (SSMS) is simply the management tool and graphical interface used by developers to configure the server, design tables, and test SQL queries.\"", false);

        DocStyles.AddCallout(doc, "Trap Q4: \"What happens if an unauthorized user types /Doctor/Appointments.aspx in the browser?\"",
            "Your Bulletproof Answer:\n" +
            "\"They are blocked immediately. Every module is protected by a Master Page role guard. During the Page_Load event, the Master Page checks if Session['Role'] equals 'Doctor'. If it is null or a Patient, the server redirects them straight to Login.aspx before any page data is loaded.\"", false);

        DocStyles.AddCallout(doc, "Trap Q5: \"How does the pharmacy know which prescriptions to bill?\"",
            "Your Bulletproof Answer:\n" +
            "\"We use a correlated SQL subquery: WHERE NOT EXISTS (SELECT 1 FROM tbl_Bill WHERE tbl_Bill.PrescriptionID = tbl_Prescription.PrescriptionID). This dynamically filters out all prescriptions that have already been billed, preventing duplicate dispensing.\"", false);
    }
}
