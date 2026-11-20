using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

public static class SectionPart5 {
    public static void BuildSections17To20AndPart4Part5(Document doc) {
        // Section 17
        DocStyles.AddH1(doc, "17", "SOFTWARE REQUIREMENTS AND SPECIFICATIONS");
        DocStyles.AddP(doc, "The operational requirements necessary for hosting, maintaining, and accessing the CareBridge web application are defined below:");

        var envList = new List<string[]> {
            new string[] { "Hosting Operating System", "Windows 10 / 11 (64-bit) Professional/Enterprise, or Windows Server 2016/2019/2022" },
            new string[] { "Web Server Infrastructure", "Microsoft Internet Information Services (IIS) 10.0 or IIS Express (integrated pipeline)" },
            new string[] { "Server Runtime Framework", "Microsoft .NET Framework 4.8 runtime environment (WCF/ASP.NET enabled)" },
            new string[] { "Database Management System", "Microsoft SQL Server 2017 / 2019 / 2022 (Express, Developer, or Standard Edition)" },
            new string[] { "Server Hardware (Minimum)", "Intel Core i3 / AMD Ryzen 3, 4 GB RAM, 10 GB available SSD storage, 100 Mbps LAN" },
            new string[] { "Server Hardware (Recommended)", "Intel Core i5 / Xeon, 8 GB RAM, 20 GB SSD storage, Gigabit network interface" },
            new string[] { "Client Computing Hardware", "Any desktop, laptop, tablet, or smartphone device with network connectivity and 2 GB RAM" },
            new string[] { "Client Web Browsers", "Google Chrome (v90+), Microsoft Edge (v90+), Mozilla Firefox (v88+), Safari (v14+)" },
            new string[] { "Development Tools", "Microsoft Visual Studio 2022 Community / Professional, SQL Server Management Studio (SSMS)" }
        };
        DocStyles.AddTable(doc, new string[] { "System Specification Category", "Minimum / Recommended Technical Profile" }, new float[] { 32, 68 }, envList);

        // Section 18
        DocStyles.AddH1(doc, "18", "THIRD-PARTY DEPENDENCIES AND LIBRARIES");
        DocStyles.AddP(doc, "In compliance with copyright disclosure requirements, all third-party open-source components, NuGet packages, and client libraries incorporated into the CareBridge solution are identified below with their version numbers and license types. Copyright protection is disclaimed with respect to these pre-existing components:");

        var depList = new List<string[]> {
            new string[] { "Dapper", "2.1.79", "Apache-2.0", "Micro-ORM executing parameterized SQL queries and mapping results to C# entities" },
            new string[] { "Newtonsoft.Json", "13.0.1", "MIT", "High-performance JSON serialization engine for complex objects and configurations" },
            new string[] { "itext / itext7", "9.7.0", "AGPL-3.0 / Commercial", "Industrial-grade PDF document generation and parsing engine" },
            new string[] { "BouncyCastle.Cryptography", "2.6.2", "MIT", "Underlying cryptographic algorithms supporting digital signatures and document encryption" },
            new string[] { "Microsoft.AspNet.FriendlyUrls", "1.0.2", "Apache-2.0", "Enables clean, extensionless URL routing within ASP.NET Web Forms applications" },
            new string[] { "Microsoft.AspNet.Web.Optimization", "1.1.3", "Apache-2.0", "Performs runtime CSS stylesheet and JavaScript file bundling and minification" },
            new string[] { "Bootstrap", "3.4.1", "MIT", "Responsive front-end layout grid, navigation bars, and UI form components" },
            new string[] { "jQuery", "3.7.1", "MIT", "Client-side DOM manipulation, unobtrusive event wiring, and script execution" },
            new string[] { "Modernizr", "2.8.3", "MIT", "Client-side feature detection library enabling HTML5/CSS3 compatibility" },
            new string[] { "Antlr", "3.5.0.2", "BSD-3-Clause", "Parser generator used by Web.Optimization for bundling and minification" },
            new string[] { "WebGrease", "1.6.0", "Apache-2.0", "Static asset optimization and web asset processing tool" }
        };
        DocStyles.AddTable(doc, new string[] { "Package Identifier", "Version", "License", "Functional Purpose in CareBridge" }, new float[] { 24, 12, 18, 46 }, depList);

        // Section 19
        DocStyles.AddH1(doc, "19", "SOFTWARE EXECUTION AND OPERATION");
        DocStyles.AddP(doc, "The CareBridge application deployment, database setup, and user operational procedures are outlined below:");
        DocStyles.AddH2(doc, "19.1", "Database Deployment Procedure");
        DocStyles.AddBullet(doc, "Step 1", "Launch SQL Server Management Studio (SSMS) and connect to the local or remote SQL Server instance.");
        DocStyles.AddBullet(doc, "Step 2", "Execute the T-SQL command: CREATE DATABASE CareBridge; to initialize the database container.");
        DocStyles.AddBullet(doc, "Step 3", "Open the supplied SQL schema script CareBridge.txt and execute it against the CareBridge database. This creates the fifteen tables, unique constraints, default constraints, twenty-five foreign keys, and baseline seed data.");

        DocStyles.AddH2(doc, "19.2", "Web Application Configuration & Deployment");
        DocStyles.AddBullet(doc, "Step 1", "Open CareBridge.sln in Visual Studio 2022. Verify that all NuGet packages restore successfully.");
        DocStyles.AddBullet(doc, "Step 2", "Inspect Web.config and calibrate the connection string for the target environment. The active configuration uses Windows Integrated Security:");
        DocStyles.AddCode(doc, @"<connectionStrings>
    <add name=""CareBridgeDB"" 
         connectionString=""Data Source=BITBEAST; Initial Catalog=CareBridge; Integrated Security=True;"" 
         providerName=""System.Data.SqlClient"" />
</connectionStrings>");
        DocStyles.AddBullet(doc, "Step 3", "Build the solution in Release mode. Publish the application to the designated IIS physical directory (e.g. C:\\inetpub\\wwwroot\\CareBridge) or execute directly via IIS Express for testing.");
        DocStyles.AddBullet(doc, "Step 4", "Ensure the IIS AppPool identity possesses Write permissions on ~/UploadedReports/ and ~/UploadedImages/.");

        // Section 20
        DocStyles.AddH1(doc, "20", "CONCLUSION AND TECHNICAL ROADMAP");
        DocStyles.AddP(doc, "The CareBridge computer programme successfully accomplishes its architectural and clinical goals: establishing a unified, multi-role web platform that digitises patient consultations, appointments, structured electronic prescriptions, computerized laboratory workflows, and dispensary billing without paper hand-offs.");

        DocStyles.AddH2(doc, "20.1", "Transparent Technical Observations & Limitations");
        DocStyles.AddP(doc, "In accordance with professional engineering ethics, the following technical observations and limitations are documented:");
        DocStyles.AddBullet(doc, "Password Storage Security", "Credentials in tbl_Login currently reside in plain text. Production hardening requires migration to salted, slow cryptographic hashing (PBKDF2 or bcrypt) as specified by OWASP.");
        DocStyles.AddBullet(doc, "Row-Level Ownership Authorization", "Pages accepting query-string parameters (e.g. PatientRecord.aspx?appointmentId=...) rely on session authentication but do not currently evaluate row-level data ownership. Enforcing hospital-scoped and patient-scoped predicates will resolve this.");
        DocStyles.AddBullet(doc, "Pharmacy Arithmetic Formula", "In BillPrescription.aspx.cs, entered prices are accumulated directly as line totals (total += price). Future versions will implement unit price multiplication (price * quantity) and tax breakdowns.");
        DocStyles.AddBullet(doc, "Symptom Matching Tie Resolution", "In cases of equal top vote counts between specializations, SQL Server returns the first record scanned. Deterministic clinical weighting rules represent an immediate enhancement.");

        DocStyles.AddH2(doc, "20.2", "Future Development Roadmap");
        DocStyles.AddBullet(doc, "Ayushman Bharat Digital Mission (ABDM)", "Integration with national Ayushman Bharat Health Account (ABHA) protocols and consent-based health data exchange.");
        DocStyles.AddBullet(doc, "HL7 FHIR Interoperability", "Exposing clinical data through FHIR R4 standard resources (Patient, Appointment, MedicationRequest, DiagnosticReport).");
        DocStyles.AddBullet(doc, "Master Medicine Formulary", "Implementing a standardized national medicine master list with autocompletion to eradicate drug name spelling mistakes.");

        // PART 4
        DocStyles.AddH1(doc, "PART 4", "STATUTORY INDIAN COPYRIGHT APPLICATION INFORMATION");
        DocStyles.AddP(doc, "The following information is compiled specifically for submission with Form XIV (Application for Registration of Copyright) under Rule 70 of the Copyright Rules, 2013, to the Registrar of Copyrights, New Delhi, India:");

        var form14 = new List<string[]> {
            new string[] { "Item 1", "Title of the Work", "CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM" },
            new string[] { "Item 2", "Category / Class of Work", "Computer Software / Computer Programme [Literary Work under Section 2(o)]" },
            new string[] { "Item 3", "Programming Language(s)", "C# (C-Sharp), Transact-SQL (T-SQL), HTML5, CSS3, JavaScript" },
            new string[] { "Item 4", "Description of Software", "A web-based healthcare coordination computer programme linking Patients, Hospital Administrators, Doctors, Diagnostic Laboratories, and Medical Stores on a unified relational SQL Server database." },
            new string[] { "Item 5", "Date / Year of Creation", "September 2026 / Academic Year 2026–2027 (AssemblyCopyright: © 2026)" },
            new string[] { "Item 6", "Publication Status", "Unpublished Technical Computer Programme" },
            new string[] { "Item 7", "Applicant Details", "[LEGAL PLACEHOLDER: Full Name(s), Permanent Residential Address(es), and Nationality (Indian) of Student Applicants OR Name and Registered Address of Institutional Assignee (PRMIT&R, Badnera - Amravati)]" },
            new string[] { "Item 8", "Author Details", "[LEGAL PLACEHOLDER: Full Names, Addresses, and Nationality of the Student Authors (<Student Name 1>, <Student Name 2>, <Student Name 3>, <Student Name 4>)]" },
            new string[] { "Item 9", "Ownership & Assignment", "[LEGAL PLACEHOLDER: Clarify whether copyright is retained jointly by Student Authors or assigned to the College/University under an Institutional Intellectual Property Agreement]" },
            new string[] { "Item 10", "Third-Party / Open Source", "Contains third-party open-source components (ASP.NET Web Forms, Dapper 2.1.79, Bootstrap 3.4.1, jQuery 3.7.1, Newtonsoft.Json 13.0.1, iText 9.7.0). Copyright is claimed exclusively on original authored source code." }
        };
        DocStyles.AddTable(doc, new string[] { "Form XIV Item", "Statutory Field", "Application Details & Placeholders" }, new float[] { 18, 28, 54 }, form14);

        // PART 5
        DocStyles.AddH1(doc, "PART 5", "COPYRIGHT REGISTRATION APPLICANT CHECKLIST");
        DocStyles.AddP(doc, "Prior to filing the formal copyright application on the Indian Copyright Office e-filing portal (https://copyright.gov.in), the applicant team must complete the following mandatory checklist:");

        var chkList = new List<string[]> {
            new string[] { "1", "Applicant & Author Particulars", "Collate full legal names, postal addresses, PIN codes, mobile numbers, email addresses, and copy of Government Photo ID (Aadhaar / Passport) for all student authors." },
            new string[] { "2", "No-Objection Certificate (NOC)", "Prepare and execute an institutional NOC from the College / Guide confirming student authorship and authorizing copyright registration, or an Assignment Deed if ownership is transferred to the Institute." },
            new string[] { "3", "Source Code Printout Materials", "Prepare source code extract printout as prescribed by the Copyright Office: first 10 pages and last 10 pages (or first 20 and last 20 pages) of clean source code listing without confidential passwords or API keys." },
            new string[] { "4", "Optical Storage Media (CD/DVD)", "Burn the complete, uncompiled source code, SQL database creation script (CareBridge.txt), and this technical documentation onto two identical CD-R or DVD-R discs, labelled with title and author names." },
            new string[] { "5", "Statutory Filing Fee", "Submit the statutory government filing fee (INR 500 per application for Literary / Software works) via Bharatkosh payment gateway on the copyright portal." },
            new string[] { "6", "Statement of Further Particulars", "Sign the Statement of Further Particulars attesting to originality and disclosing third-party open-source dependencies." },
            new string[] { "7", "Discrepancy Rectification", "Confirm with institutional advisors whether the WhatsApp messaging prototype should remain segregated or incorporated into a future Version 2.0 registration." }
        };
        DocStyles.AddTable(doc, new string[] { "No.", "Mandatory Checklist Action", "Procedural Requirement & Actionable Instructions" }, new float[] { 8, 28, 64 }, chkList);
    }
}
