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

public class PresentationDocBuilder {
    public static void Main() {
        string rawPdf = "temp_presentation_raw.pdf";
        string finalPdf = @"..\CareBridge_Technical_Implementation_and_Presentation_Guide.pdf";

        Console.WriteLine("Step 1: Initializing styles...");
        DocStyles.Init();

        Console.WriteLine("Step 2: Building document content...");
        using (var writer = new PdfWriter(rawPdf))
        using (var pdf = new PdfDocument(writer))
        using (var doc = new Document(pdf, PageSize.A4)) {
            doc.SetMargins(36, 36, 36, 36);

            // Title Banner
            BuildHeaderBanner(doc);

            // Section 1: Executive Overview & Architecture
            BuildSection1(doc);

            // Section 2: Technology Stack & Justification
            BuildSection2(doc);

            // Section 3: Security & Session Architecture
            BuildSection3(doc);

            // Section 4: Module-Wise Implementation
            BuildSection4(doc);

            // Section 5: Database Architecture & Schema
            BuildSection5(doc);

            // Section 6: State Machine Workflows
            BuildSection6(doc);

            // Section 7: Viva / Technical Examination Q&A
            BuildSection7(doc);

            // Section 8: Slide-by-Slide Presentation Deck Outline
            BuildSection8(doc);
        }

        Console.WriteLine("Step 3: Stamping Running Headers and Footers...");
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
                    new Paragraph("CAREBRIDGE: TECHNICAL IMPLEMENTATION & PRESENTATION HANDBOOK")
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

                // Running Footer Left
                doc.ShowTextAligned(
                    new Paragraph("CareBridge • Multi-Module Healthcare Management System • Technical Defense Reference")
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

        // Copy to workspace root also
        string rootDest = @"..\..\CareBridge_Technical_Implementation_and_Presentation_Guide.pdf";
        try {
            File.Copy(finalPdf, rootDest, true);
        } catch {}

        if (File.Exists(rawPdf)) {
            try { File.Delete(rawPdf); } catch {}
        }

        Console.WriteLine("PDF successfully generated at: " + finalPdf);
    }

    private static void BuildHeaderBanner(Document doc) {
        var table = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        table.SetMarginBottom(12);

        var cell = new Cell().SetBackgroundColor(DocStyles.Primary).SetPadding(14);
        cell.SetBorder(Border.NO_BORDER);

        var pTag = new Paragraph("TECHNICAL SEMINAR & PROJECT PRESENTATION HANDBOOK")
            .SetFont(DocStyles.FontBold).SetFontSize(8.5f).SetFontColor(DocStyles.AccentTeal).SetMarginBottom(3);
        cell.Add(pTag);

        var pTitle = new Paragraph("CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE SYSTEM")
            .SetFont(DocStyles.FontBold).SetFontSize(16f).SetFontColor(ColorConstants.WHITE).SetMarginBottom(4);
        cell.Add(pTitle);

        var pSub = new Paragraph("Comprehensive Technical Architecture, Module-Wise Implementation Details, Relational Schemas, and Viva Defense Reference")
            .SetFont(DocStyles.FontRegular).SetFontSize(9.5f).SetFontColor(new DeviceRgb(220, 235, 245)).SetMarginBottom(8);
        cell.Add(pSub);

        var pMeta = new Paragraph("Architecture: 3-Tier Enterprise • Framework: ASP.NET Web Forms (.NET 4.8) • Language: C# • Micro-ORM: Dapper 2.1 • Database: Microsoft SQL Server")
            .SetFont(DocStyles.FontBold).SetFontSize(7.8f).SetFontColor(new DeviceRgb(200, 225, 240)).SetMarginBottom(0);
        cell.Add(pMeta);

        table.AddCell(cell);
        doc.Add(table);
    }

    private static void BuildSection1(Document doc) {
        DocStyles.AddH1(doc, "1", "Executive Overview & System Architecture");
        DocStyles.AddP(doc, "CareBridge is an enterprise-grade, multi-role web application engineered to coordinate outpatient clinical workflows across municipal and private healthcare institutions. The application eliminates fragmented physical paper records by establishing a unified digital conduit connecting five key stakeholders: Patients, Hospital Administrators, Doctors, Diagnostic Laboratories, and Medical Stores (Pharmacies).");

        DocStyles.AddH2(doc, "1.1", "Three-Tier Architectural Model");
        DocStyles.AddP(doc, "CareBridge enforces a strict Three-Tier separation of concerns to maximize modularity, maintainability, and scalability:");
        
        DocStyles.AddBullet(doc, "Presentation Tier", "Web browser interface composed of ASP.NET Web Forms controls, responsive Bootstrap 3.4.1 grid layout, jQuery 3.7.1 client DOM manipulation, and custom responsive styling.");
        DocStyles.AddBullet(doc, "Application Tier (Business Logic)", "Hosted on Microsoft IIS / IIS Express using the Microsoft .NET Framework 4.8 runtime. Implements C# code-behind event handling, Master Page session role guards, deterministic symptom-matching algorithms, and ViewState transaction management.");
        DocStyles.AddBullet(doc, "Data Tier & Storage", "Normalized Microsoft SQL Server database managing 15 relational tables with 25 foreign key constraints, coupled with an IIS virtual file repository for diagnostic PDF reports.");

        DocStyles.AddCode(doc, 
            "+-------------------------------------------------------------------------+\n" +
            "|                            PRESENTATION TIER                            |\n" +
            "|        (HTML5, CSS3, Bootstrap 3.4.1, jQuery 3.7.1, Site.css)          |\n" +
            "|  Patient Portal | Doctor Portal | Admin Portal | Lab Portal | Store     |\n" +
            "+-------------------------------------------------------------------------+\n" +
            "                                   |  HTTP / HTTPS\n" +
            "                                   v\n" +
            "+-------------------------------------------------------------------------+\n" +
            "|                            APPLICATION TIER                             |\n" +
            "|                 (Microsoft IIS / .NET Framework 4.8 / C#)               |\n" +
            "|  * Master Page Session Role Guards (RBAC via Session State)             |\n" +
            "|  * Deterministic Majority-Voting Symptom Recommendation Engine          |\n" +
            "|  * ViewState-Backed In-Memory Prescription Assembly                     |\n" +
            "|  * Centralized Connection Pooling (DBHelper) & Dapper 2.1 Micro-ORM     |\n" +
            "+-------------------------------------------------------------------------+\n" +
            "                        |                         |\n" +
            "           ADO.NET / SQL|                         | Server File I/O\n" +
            "                        v                         v\n" +
            "+-------------------------------+  +--------------------------------------+\n" +
            "|           DATA TIER           |  |           FILE REPOSITORY            |\n" +
            "|     Microsoft SQL Server      |  |  * /UploadedReports/ (PDF Reports)   |\n" +
            "|   CareBridge DB (15 Tables)   |  |  * /UploadedImages/ (Test Assets)    |\n" +
            "+-------------------------------+  +--------------------------------------+"
        );
    }

    private static void BuildSection2(Document doc) {
        DocStyles.AddH1(doc, "2", "Technology Stack Justification Matrix");
        DocStyles.AddP(doc, "Every tool and library in the CareBridge architecture was selected based on enterprise performance, reliability, and technical justification:");

        string[] headers = new string[] { "Layer", "Selected Technology", "Role in System", "Technical Justification" };
        float[] widths = new float[] { 18, 22, 28, 32 };
        List<string[]> rows = new List<string[]>();

        rows.Add(new string[] { "Language", "C# (C-Sharp)", "Server-side business logic, algorithms, event handlers", "Strong type safety, enterprise CLR garbage collection, native multi-threading, and robust object-oriented patterns." });
        rows.Add(new string[] { "Framework", "ASP.NET Web Forms (.NET 4.8)", "Web application platform, page lifecycle, Master Pages", "Event-driven programming model, built-in postback lifecycle, ViewState state management, and unified Master Page layouts." });
        rows.Add(new string[] { "Micro-ORM", "Dapper 2.1.79", "Data access layer, parameterized SQL execution", "Extends IDbConnection directly; offers near C/C++ execution speed comparable to raw ADO.NET DataReaders without Entity Framework overhead." });
        rows.Add(new string[] { "Database", "Microsoft SQL Server", "15 normalized tables, 25 foreign keys, clustered PKs", "Full ACID compliance, high-throughput T-SQL query engine, reliable declarative referential integrity, and enterprise security." });
        rows.Add(new string[] { "Frontend UI", "Bootstrap 3.4.1 & Site.css", "12-column responsive grid, form styling, custom badges", "Consistent rendering across desktop and mobile browsers, rapid UI assembly, and responsive table layouts." });
        rows.Add(new string[] { "Client Scripting", "jQuery 3.7.1 & Modernizr", "DOM manipulation, client validation, event listening", "Standardized cross-browser JavaScript execution, light footprint, and HTML5/CSS3 feature detection." });
        rows.Add(new string[] { "PDF Engine", "iText 7 (9.7.0)", "Diagnostic lab reporting and document compilation", "Industry-standard programmatic PDF layout, digital typography, and document security." });

        DocStyles.AddTable(doc, headers, widths, rows);
    }

    private static void BuildSection3(Document doc) {
        DocStyles.AddH1(doc, "3", "Security, Authentication & Session Architecture");
        DocStyles.AddP(doc, "CareBridge implements defense-in-depth across the presentation, application, and database tiers.");

        DocStyles.AddH2(doc, "3.1", "Role-Based Access Control (RBAC) via Master Page Guards");
        DocStyles.AddP(doc, "Rather than duplicating authorization checks on 25 individual pages, security boundaries are enforced centrally at the Master Page layer. Each portal folder (/Patient/, /Doctor/, /Admin/, /Lab/, /MedicalStore/) is bounded by its own Master Page file.");
        DocStyles.AddCode(doc,
            "// Master Page Session Security Guard (Doctor.Master.cs)\n" +
            "protected void Page_Load(object sender, EventArgs e) {\n" +
            "    if (Session[\"Role\"] == null || Session[\"Role\"].ToString() != \"Doctor\") {\n" +
            "        Response.Redirect(\"~/Login.aspx\");\n" +
            "    }\n" +
            "}"
        );
        DocStyles.AddP(doc, "If an unauthorized user attempts URL tampering (e.g., a patient manually typing /Doctor/WritePrescription.aspx in the browser address bar), the Master Page intercepts the HTTP request during the Page_Load event and redirects the session to Login.aspx prior to executing any page logic.");

        DocStyles.AddH2(doc, "3.2", "SQL Injection Immunity via Dapper Parameterization");
        DocStyles.AddP(doc, "All database queries use parameterized SQL executed through Dapper. Input values are never concatenated directly into query strings:");
        DocStyles.AddCode(doc,
            "using (var conn = DBHelper.GetConnection()) {\n" +
            "    conn.Open();\n" +
            "    string query = \"SELECT * FROM tbl_Login WHERE Username = @Username AND Password = @Password\";\n" +
            "    var user = conn.QueryFirstOrDefault(query, new { Username = username, Password = password });\n" +
            "}"
        );
        DocStyles.AddP(doc, "Dapper maps strongly-typed parameters directly to the SQL command object. Malicious payload characters (such as ' OR 1=1 --) are strictly evaluated as literal parameter data, completely preventing SQL injection attacks.");

        DocStyles.AddH2(doc, "3.3", "Stateful vs Stateless Handling: Session vs ViewState");
        DocStyles.AddBullet(doc, "Session State", "Stores persistent cross-page user identity (Session[\"LoginID\"], Session[\"Role\"]) across the entire browser session.");
        DocStyles.AddBullet(doc, "ViewState", "Used within single pages (e.g. WritePrescription.aspx) to maintain in-memory lists of medications across multiple postbacks without making repeated database calls.");
    }

    private static void BuildSection4(Document doc) {
        DocStyles.AddH1(doc, "4", "Module-Wise Technical Implementation");
        DocStyles.AddP(doc, "The CareBridge solution is decomposed into five specialized operational modules:");

        DocStyles.AddH2(doc, "4.1", "Patient Portal Module (/Patient/)");
        DocStyles.AddP(doc, "Provides self-registration, algorithmic doctor triage, appointment booking, and instant record retrieval.");
        DocStyles.AddBullet(doc, "Deterministic Majority-Voting Algorithm", "Patients select presenting complaints from a 42-symptom checklist. Instead of using non-deterministic AI models, CareBridge executes a rule-based majority-voting frequency count against tbl_SymptomMapping.");
        
        DocStyles.AddCallout(doc, "Algorithmic Mathematical Formulation", 
            "Let S = {s1, s2, ..., sn} be the set of symptoms checked by the patient. For each candidate specialization k, the voting weight V(k) is the count of mappings matching the patient's symptoms:\n" +
            "V(k) = Count({ m in tbl_SymptomMapping : m.Symptom in S and m.SpecializationID = k })\n" +
            "The recommended specialty k* is the argument that maximizes V(k): k* = argmax V(k).", false);

        DocStyles.AddCode(doc,
            "// Enter_Symptoms.aspx.cs\n" +
            "var specId = conn.QueryFirstOrDefault<int?>(\n" +
            "    @\"SELECT TOP 1 SpecializationID FROM tbl_SymptomMapping\n" +
            "      WHERE Symptom IN @Symptoms\n" +
            "      GROUP BY SpecializationID\n" +
            "      ORDER BY COUNT(*) DESC\",\n" +
            "    new { Symptoms = selectedValues });\n\n" +
            "// Safe primary care fallback if no symptom matches\n" +
            "if (specId == null) {\n" +
            "    specId = conn.QueryFirstOrDefault<int?>(\n" +
            "        \"SELECT SpecializationID FROM tbl_Specialization WHERE Name = 'General Physician'\");\n" +
            "}"
        );

        DocStyles.AddH2(doc, "4.2", "Doctor Consultation Module (/Doctor/)");
        DocStyles.AddP(doc, "Enables clinicians to manage daily queues, examine longitudinal patient history, assemble multi-item digital prescriptions, and order computerized diagnostic investigations.");
        DocStyles.AddBullet(doc, "Multi-Item Prescription Staging", "Medicines are staged in an in-memory serializable collection: [Serializable] public class MedItem { MedicineName, Dosage, Quantity, Instructions; }, maintained across postbacks in ViewState[\"Medicines\"].");
        DocStyles.AddBullet(doc, "Atomic Transaction Commit", "Upon clicking 'Finish', the system executes an INSERT into tbl_Prescription using OUTPUT INSERTED.PrescriptionID, loops through the MedItem collection inserting rows into tbl_PrescriptionItem, and updates tbl_Appointment.Status to 'Completed'.");

        DocStyles.AddH2(doc, "4.3", "Diagnostic Laboratory Module (/Lab/)");
        DocStyles.AddP(doc, "Handles diagnostic test orders from doctors, processing state transitions, and electronic report uploads.");
        DocStyles.AddBullet(doc, "Test State Machine", "Incoming requests arrive with Status = 'Pending'. Clicking 'Start' transitions the status to 'In Progress'.");
        DocStyles.AddBullet(doc, "Secure File Upload Pipeline", "Upload_Report.aspx validates MIME types, prefixes the filename with the unique RequestID (requestId + '_' + fileName), writes the PDF to /UploadedReports/, inserts a record in tbl_LabReport, and advances the request status to 'Completed'.");

        DocStyles.AddH2(doc, "4.4", "Medical Store / Pharmacy Module (/MedicalStore/)");
        DocStyles.AddP(doc, "Ingests unbilled prescriptions, facilitates line-item drug pricing, and generates printable financial bills.");
        DocStyles.AddBullet(doc, "Unbilled Queue Subquery", "Prescription_Queue.aspx displays only active prescriptions awaiting billing using an optimized SQL correlated subquery:");
        DocStyles.AddCode(doc,
            "SELECT p.*, pt.Name AS PatientName, d.Name AS DoctorName\n" +
            "FROM tbl_Prescription p\n" +
            "JOIN tbl_Patient pt ON p.PatientID = pt.PatientID\n" +
            "JOIN tbl_Doctor d ON p.DoctorID = d.DoctorID\n" +
            "WHERE NOT EXISTS (\n" +
            "    SELECT 1 FROM tbl_Bill b WHERE b.PrescriptionID = p.PrescriptionID\n" +
            ")"
        );
        DocStyles.AddBullet(doc, "Invoice Printing", "PrintBill.aspx formats the financial bill into a standard thermal receipt layout and triggers window.print() for physical customer handover.");

        DocStyles.AddH2(doc, "4.5", "Hospital Administration Module (/Admin/)");
        DocStyles.AddP(doc, "Enables hospital executives to provision staff accounts (Doctors, Labs, Medical Stores) with cross-table foreign key linkage, monitor facility-wide outpatient queues, and inspect aggregated operational reports.");
    }

    private static void BuildSection5(Document doc) {
        DocStyles.AddH1(doc, "5", "Relational Database Architecture");
        DocStyles.AddP(doc, "The CareBridge database contains 15 normalized tables designed to maintain complete clinical data integrity across the care continuum:");

        string[] headers = new string[] { "Table Name", "Primary Key", "Foreign Keys", "Entity Purpose" };
        float[] widths = new float[] { 22, 20, 28, 30 };
        List<string[]> rows = new List<string[]>();

        rows.Add(new string[] { "tbl_Login", "LoginID (Identity)", "None (Parent)", "Stores authentication credentials, username, password, role." });
        rows.Add(new string[] { "tbl_Patient", "PatientID (Identity)", "LoginID -> tbl_Login", "Stores patient demographics, DOB, gender, contact number." });
        rows.Add(new string[] { "tbl_Hospital", "HospitalID (Identity)", "LoginID -> tbl_Login", "Stores healthcare institution profile, address, contact." });
        rows.Add(new string[] { "tbl_Doctor", "DoctorID (Identity)", "LoginID, HospitalID", "Stores clinician specialty, consulting hours, contact." });
        rows.Add(new string[] { "tbl_Lab", "LabID (Identity)", "LoginID, HospitalID", "Stores diagnostic laboratory profiles and facility linkage." });
        rows.Add(new string[] { "tbl_MedicalStore", "StoreID (Identity)", "LoginID, HospitalID", "Stores pharmacy dispensary records and facility linkage." });
        rows.Add(new string[] { "tbl_Appointment", "AppointmentID (Identity)", "PatientID, DoctorID, HospitalID", "Records appointment bookings, symptoms, date, and status." });
        rows.Add(new string[] { "tbl_Prescription", "PrescriptionID (Identity)", "AppointmentID, PatientID, DoctorID", "Electronic prescription header authored during consultation." });
        rows.Add(new string[] { "tbl_PrescriptionItem", "ItemID (Identity)", "PrescriptionID", "Individual prescribed drug lines (dosage, quantity, instructions)." });
        rows.Add(new string[] { "tbl_LabTestRequest", "RequestID (Identity)", "AppointmentID, PatientID, DoctorID, LabID", "Diagnostic test orders dispatched to laboratories." });
        rows.Add(new string[] { "tbl_LabReport", "ReportID (Identity)", "RequestID", "Stores metadata and relative server path for PDF lab reports." });
        rows.Add(new string[] { "tbl_Bill", "BillID (Identity)", "PrescriptionID, PatientID, StoreID", "Financial invoice header capturing total billing amount." });
        rows.Add(new string[] { "tbl_BillItem", "BillItemID (Identity)", "BillID", "Billed drug line items with medicine name, quantity, price." });
        rows.Add(new string[] { "tbl_Specialization", "SpecializationID (Identity)", "None (Lookup)", "Master catalog of 13 medical specializations." });
        rows.Add(new string[] { "tbl_SymptomMapping", "MappingID (Identity)", "SpecializationID", "Relational mapping linking 42 symptoms to specializations." });

        DocStyles.AddTable(doc, headers, widths, rows);
        DocStyles.AddP(doc, "Referential Integrity: The schema enforces 25 explicit Foreign Key relationships guaranteeing that no medical record (prescription, test, or bill) can be orphaned or dissociated from its clinical consultation.");
    }

    private static void BuildSection6(Document doc) {
        DocStyles.AddH1(doc, "6", "State Machine Workflows");
        DocStyles.AddP(doc, "CareBridge automates clinical state transitions across departments through clear state machine lifecycles:");

        DocStyles.AddH2(doc, "6.1", "Outpatient Appointment State Machine");
        DocStyles.AddCode(doc,
            "[ Patient Books Online ]  -->  Status: 'Pending'\n" +
            "         |\n" +
            "         v  (Doctor confirms visit)\n" +
            "[ Outpatient Consultation Queue ]  -->  Status: 'Confirmed'\n" +
            "         |\n" +
            "         v  (Doctor commits electronic prescription)\n" +
            "[ Consultation Concluded ]  -->  Status: 'Completed'"
        );

        DocStyles.AddH2(doc, "6.2", "Diagnostic Laboratory Test State Machine");
        DocStyles.AddCode(doc,
            "[ Doctor Orders Investigation ]  -->  Status: 'Pending'\n" +
            "         |\n" +
            "         v  (Technician accepts sample and begins test)\n" +
            "[ In Processing Queue ]  -->  Status: 'In Progress'\n" +
            "         |\n" +
            "         v  (Technician uploads validated PDF report)\n" +
            "[ Report Available to Patient ]  -->  Status: 'Completed'"
        );

        DocStyles.AddH2(doc, "6.3", "Pharmacy Prescription & Billing Lifecycle");
        DocStyles.AddCode(doc,
            "[ Doctor Signs Prescription ]  -->  Appears in Pharmacy Queue (NOT EXISTS in tbl_Bill)\n" +
            "         |\n" +
            "         v  (Pharmacist inputs item unit prices)\n" +
            "[ Bill Committed in Database ]  -->  tbl_Bill & tbl_BillItem Created\n" +
            "         |\n" +
            "         v  (Receipt printed via window.print())\n" +
            "[ Medicine Dispensed to Patient ]"
        );
    }

    private static void BuildSection7(Document doc) {
        DocStyles.AddH1(doc, "7", "Examiner Viva Q&A Cheat Sheet");
        DocStyles.AddP(doc, "High-yield technical questions and authoritative model answers for project evaluation:");

        DocStyles.AddCallout(doc, "Q1: Why did you choose Dapper Micro-ORM over Entity Framework?",
            "Answer: Entity Framework introduces significant overhead due to automated query generation, change tracking, and runtime reflection caching. Dapper is a lightweight micro-ORM extending IDbConnection. It executes raw, highly optimized parameterized SQL queries with performance virtually identical to native ADO.NET DataReaders, while providing clean object mapping and full query visibility.", false);

        DocStyles.AddCallout(doc, "Q2: Is your symptom recommendation engine based on AI/ML?",
            "Answer: No, and intentionally so. In clinical healthcare triage, recommendations must be transparent, deterministic, and auditable. We implemented a deterministic majority-voting frequency count algorithm operating across tbl_SymptomMapping. This allows medical boards to inspect, calibrate, or expand mappings directly in the database without recompiling the codebase.", false);

        DocStyles.AddCallout(doc, "Q3: How do you prevent unauthorized users from accessing role-specific pages via direct URL entry?",
            "Answer: Through Master Page security guards. Each role folder has a designated Master Page (e.g. Doctor.Master.cs). During the early Page_Load event, the Master Page verifies that Session[\"Role\"] matches the designated role. If unauthorized, the request is immediately redirected to Login.aspx before any content page logic is executed.", false);

        DocStyles.AddCallout(doc, "Q4: How do you handle maintaining multiple medicine rows across postbacks before saving a prescription?",
            "Answer: We utilize ASP.NET ViewState. The medication lines are kept in an in-memory serializable List<MedItem> inside ViewState[\"Medicines\"]. Each 'Add Medicine' click triggers a postback that appends to this collection and re-binds the Repeater. When the doctor clicks 'Finish', the entire collection is committed in a single database transaction.", false);

        DocStyles.AddCallout(doc, "Q5: How does the pharmacy identify unbilled prescriptions in real time?",
            "Answer: Using an optimized SQL correlated subquery with WHERE NOT EXISTS against tbl_Bill. This ensures only prescriptions without an associated financial bill appear in the active dispensary queue, preventing duplicate billing.", false);
    }

    private static void BuildSection8(Document doc) {
        DocStyles.AddH1(doc, "8", "Slide-by-Slide Presentation Deck Outline");
        DocStyles.AddP(doc, "Recommended 10-slide structure for presenting CareBridge in front of the examination committee:");

        DocStyles.AddBullet(doc, "Slide 1: Title & Introduction", "Project title, team members, supervisor, and institution name.");
        DocStyles.AddBullet(doc, "Slide 2: Problem Statement", "Manual paper handoffs, illegible prescriptions, lost lab slips, pharmacy transcription errors, and lack of affordable coordination systems.");
        DocStyles.AddBullet(doc, "Slide 3: Proposed Solution", "CareBridge: A unified 5-portal web coordination platform connecting Patients, Hospitals, Doctors, Labs, and Pharmacies.");
        DocStyles.AddBullet(doc, "Slide 4: System Architecture", "Three-Tier Architecture diagram showing Presentation, Application, and Data tiers.");
        DocStyles.AddBullet(doc, "Slide 5: Technology Stack", "C#, ASP.NET Web Forms (.NET 4.8), Dapper 2.1 Micro-ORM, Microsoft SQL Server, Bootstrap, iText 7.");
        DocStyles.AddBullet(doc, "Slide 6: Module Breakdown", "Functionalities of the 5 modules: Patient, Doctor, Admin, Diagnostic Lab, Medical Store.");
        DocStyles.AddBullet(doc, "Slide 7: Algorithms & Programming Logic", "Deterministic majority-voting symptom matching algorithm (formula + code) and ViewState prescription staging.");
        DocStyles.AddBullet(doc, "Slide 8: Database Architecture", "15 normalized tables, 25 foreign key constraints, and clustered identity primary keys.");
        DocStyles.AddBullet(doc, "Slide 9: End-to-End Workflow Demonstration", "Step-by-step trace of a 25-minute care episode from symptom selection to lab report and pharmacy billing.");
        DocStyles.AddBullet(doc, "Slide 10: Conclusion & Future Scope", "Elimination of physical paper records, transparent triage, and roadmap (ABDM/ABHA integration, HL7 FHIR compliance).");
    }
}
