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

public static class SectionPart2 {
    public static void BuildSections6To9(Document doc) {
        // Section 6
        DocStyles.AddH1(doc, "6", "DESCRIPTION OF THE SOFTWARE");
        DocStyles.AddP(doc, "CareBridge is architected as an integrated suite of five role-tailored web portals hosted within a single ASP.NET Web Forms web application application boundary and backed by a single Microsoft SQL Server database. The system design enforces strict segregation of duties while facilitating seamless data propagation across the healthcare delivery chain.");
        DocStyles.AddP(doc, "The software comprises seven structural subsystems:");
        DocStyles.AddBullet(doc, "Common Public & Authentication Subsystem", "Provides public landing, informational overviews, centralized authentication via tbl_Login, self-registration for patients and hospitals, and secure session teardown.");
        DocStyles.AddBullet(doc, "Patient Self-Service Subsystem", "Enables symptom selection, deterministic specialization matching, doctor discovery, appointment scheduling, personal visit history tracking, electronic prescription retrieval, and laboratory report downloads.");
        DocStyles.AddBullet(doc, "Clinical Consultation Subsystem", "Allows medical practitioners to review outpatient appointment queues, transition appointments from Pending to Confirmed, access longitudinal clinical histories, construct digital prescriptions containing multiple pharmaceutical lines, order laboratory tests, and maintain consulting schedules.");
        DocStyles.AddBullet(doc, "Diagnostic Laboratory Subsystem", "Enables pathology and diagnostic facilities to monitor computerized test requisitions, update test processing states (Pending -> In Progress -> Completed), and upload validated PDF diagnostic reports.");
        DocStyles.AddBullet(doc, "Pharmaceutical Dispensary Subsystem", "Provides medical store operators with a real-time queue of unbilled electronic prescriptions, facilitates line-item drug pricing, and generates printable itemised financial bills.");
        DocStyles.AddBullet(doc, "Hospital Governance Subsystem", "Provides hospital administrative leadership with management interfaces to provision and maintain credentialed accounts for doctors, diagnostic laboratories, and medical stores, while providing aggregate operational analytics.");
        DocStyles.AddBullet(doc, "Data Access & Relational Storage Subsystem", "Maintains referential integrity across fifteen normalized tables, abstracting database connectivity through DBHelper and executing optimized parameterized SQL queries via Dapper.");

        // Section 7
        DocStyles.AddH1(doc, "7", "DETAILED FUNCTIONALITIES");
        DocStyles.AddP(doc, "CareBridge establishes twenty-two rigorous functional requirements (FR1–FR22) mapped across its operational user roles. The functional matrix is summarized in the table below:");

        var frList = new List<string[]> {
            new string[] { "FR1", "Common", "Self-Registration", "Allows patients and hospitals to create credentials and initial profile records." },
            new string[] { "FR2", "Common", "Unique Validation", "Enforces non-duplicate username constraints across all system users in tbl_Login." },
            new string[] { "FR3", "Common", "Role Routing", "Authenticates credentials and routes users to role-specific dashboard views." },
            new string[] { "FR4", "Common", "Access Guard", "Blocks unauthorized URL tampering through master-page session role enforcement." },
            new string[] { "FR5", "Patient", "Dashboard Analytics", "Displays metric counts for upcoming visits, prescriptions, reports, and total visits." },
            new string[] { "FR6", "Patient", "Symptom Checklist", "Presents 42 selectable symptoms and executes deterministic majority-voting matching." },
            new string[] { "FR7", "Patient", "Doctor Discovery", "Filters and displays practitioners belonging to the matched specialization." },
            new string[] { "FR8", "Patient", "Appointment Booking", "Schedules consultation slots with preferred date, time, and recorded symptoms." },
            new string[] { "FR9", "Patient", "Records Access", "Provides read-only access to historical appointments, prescriptions, and lab reports." },
            new string[] { "FR10", "Patient", "Profile Maintenance", "Enables updating of patient contact, date of birth, gender, and residential address." },
            new string[] { "FR11", "Doctor", "Queue Confirmation", "Lists scheduled appointments and enables transition from Pending to Confirmed." },
            new string[] { "FR12", "Doctor", "Longitudinal History", "Displays patient's current presenting complaint alongside all historical hospital visits." },
            new string[] { "FR13", "Doctor", "Digital Prescribing", "Builds multi-medicine prescriptions in memory and commits them transactionally." },
            new string[] { "FR14", "Doctor", "Laboratory Ordering", "Dispatches computerized diagnostic test requests to hospital-attached labs." },
            new string[] { "FR15", "Doctor", "Availability Setup", "Configures weekly consulting days and working hour ranges in the doctor profile." },
            new string[] { "FR16", "Laboratory", "Test Queue Tracking", "Presents incoming test requests and transitions status from Pending to In Progress." },
            new string[] { "FR17", "Laboratory", "Report Uploading", "Uploads PDF diagnostic files, saves file paths, and completes test requests." },
            new string[] { "FR18", "Medical Store", "Unbilled Queue", "Filters and lists active prescriptions that have not yet been billed." },
            new string[] { "FR19", "Medical Store", "Itemised Billing", "Captures line-item medicine prices, calculates totals, and renders printable bills." },
            new string[] { "FR20", "Hospital Admin", "Staff Provisioning", "Enables hospitals to create and manage logins for Doctors, Labs, and Stores." },
            new string[] { "FR21", "Hospital Admin", "Facility Analytics", "Aggregates hospital-wide counts of visits, prescriptions, lab tests, and bills." },
            new string[] { "FR22", "Messaging", "Notification Logic", "Integrates external messaging client specifications for patient notifications." }
        };
        DocStyles.AddTable(doc, new string[] { "ID", "Module", "Functional Requirement", "Operational Description & Implementation" }, new float[] { 10, 18, 28, 44 }, frList);

        DocStyles.AddH2(doc, "7.1", "Patient Portal Functionality");
        DocStyles.AddP(doc, "Patients interact with CareBridge through an intuitive, mobile-responsive self-service portal. The workflow begins at Enter_Symptoms.aspx, where forty-two common clinical complaints (e.g. fever, chest pain, rash, blurred vision) are presented as interactive badges. Upon form submission, the system counts mapped specialization frequencies in tbl_SymptomMapping and redirects to Hospital_Suggestions.aspx, displaying practicing specialists. Clicking 'Book' transfers the practitioner ID and URL-encoded symptom string to Book_Appointment.aspx, where date and time are confirmed. The appointment is inserted into tbl_Appointment with Status='Pending'. Patients monitor their care journey via Appointment_History.aspx, Prescriptions.aspx, and Lab_Reports.aspx, downloading uploaded PDF findings directly.");

        DocStyles.AddH2(doc, "7.2", "Doctor Consultation Portal Functionality");
        DocStyles.AddP(doc, "Medical practitioners access Appointments.aspx to inspect their daily outpatient queue. Clicking 'Confirm' triggers an in-place Dapper command updating the appointment status to 'Confirmed'. During consultation, opening PatientRecord.aspx presents the presenting symptoms alongside the complete historical record of the patient's previous consultations. From this screen, clinicians navigate to WritePrescription.aspx to iteratively construct electronic prescriptions. Each drug item (name, dosage, quantity, instructions) is staged in ViewState; clicking 'Finish' commits the prescription header and item rows and marks the appointment 'Completed'. Practitioners can concurrently dispatch diagnostic test orders via RequestLabTest.aspx and maintain consulting hours via SetAvailability.aspx.");

        DocStyles.AddH2(doc, "7.3", "Diagnostic Laboratory Portal Functionality");
        DocStyles.AddP(doc, "Laboratory technicians monitor Pending_Tests.aspx to review test orders routed by consulting clinicians. Clicking 'Start' advances the status to 'In Progress'. When diagnostic testing is concluded, the technician navigates to Upload_Report.aspx, selects the generated PDF document, and submits the form. The system prefixes the file name with the RequestID (e.g. 2_DeadStockRegister.pdf), stores it in the server's /UploadedReports/ physical directory, inserts an entry in tbl_LabReport, and advances the test request status to 'Completed'.");

        DocStyles.AddH2(doc, "7.4", "Medical Store / Pharmacy Portal Functionality");
        DocStyles.AddP(doc, "Pharmacists access Prescription_Queue.aspx, which queries prescriptions where no corresponding record exists in tbl_Bill. Selecting a prescription opens BillPrescription.aspx, which enumerates the prescribed drug lines. The pharmacist inputs the pricing for each item; upon clicking 'Generate Bill', the software transactionally records the bill header in tbl_Bill, copies item lines into tbl_BillItem, and redirects to PrintBill.aspx for browser printing.");

        DocStyles.AddH2(doc, "7.5", "Hospital Administration Portal Functionality");
        DocStyles.AddP(doc, "Hospital administrators administer institutional clinical resources via Manage_Doctors.aspx, Manage_Labs.aspx, and Manage_Medical_Stores.aspx. The portal enforces institutional scoping: the administrator's LoginID is resolved to a HospitalID, and all provisioning and data views are strictly filtered by this identifier. The administrator creates linked user credentials in tbl_Login alongside profile entities in tbl_Doctor, tbl_Lab, and tbl_MedicalStore, and inspects facility-wide operational statistics on Reports.aspx.");

        // Section 8
        DocStyles.AddH1(doc, "8", "SOFTWARE ARCHITECTURE");
        DocStyles.AddP(doc, "CareBridge is built on a classic, robust Three-Tier Architectural Pattern comprising Presentation, Application/Business Logic, and Data Storage tiers, optimized for enterprise healthcare data integrity.");

        DocStyles.AddBullet(doc, "Presentation Tier (Client Browser)", "Renders semantic HTML5 markup styled with Bootstrap 3.4.1 and custom site stylesheets (Site.css). Delivers responsive interfaces compatible with modern desktop and mobile browsers. Uses ASP.NET server controls (Repeater, DropDownList, TextBox, CheckBoxList) managing client-side events and postback state.");
        DocStyles.AddBullet(doc, "Application / Business Logic Tier (IIS & .NET Framework 4.8)", "Hosted on Microsoft Internet Information Services (IIS / IIS Express). Executes C# code-behind logic, manages session state, enforces Master Page authorization guards, serializes in-memory prescription models, executes mathematical majority-voting algorithms, and coordinates data access through the Dapper 2.1 micro-ORM and DBHelper.");
        DocStyles.AddBullet(doc, "Data Tier (Microsoft SQL Server & Physical File Repository)", "Persists structured healthcare records across fifteen normalized relational tables. Enforces declarative referential integrity through twenty-five foreign keys, unique indexes, and default constraints. File assets (diagnostic laboratory reports and uploaded images) are stored in dedicated server-side file directories (/UploadedReports/ and /UploadedImages/).");

        DocStyles.AddH2(doc, "8.1", "Session State and Role Enforcement Architecture");
        DocStyles.AddP(doc, "Security boundaries are established at the web application layer through Master Page session interception. CareBridge organizes pages into five role-segregated directory hierarchies: /Patient/, /Doctor/, /Admin/, /Lab/, and /MedicalStore/. Each folder is bound to a dedicated Master Page (e.g. Doctor.Master.cs). Upon every HTTP request, the Master Page Page_Load event verifies the active session role:");
        
        DocStyles.AddCode(doc, @"// Role Gate Enforcement in Doctor.Master.cs
protected void Page_Load(object sender, EventArgs e) {
    if (Session[""Role""] == null || Session[""Role""].ToString() != ""Doctor"") {
        Response.Redirect(""~/Login.aspx"");
    }
}");
        DocStyles.AddP(doc, "This architectural pattern guarantees that unauthenticated requests or cross-role navigation attempts (e.g. a Patient attempting to open /Doctor/Appointments.aspx) are immediately aborted and redirected to the login gateway prior to executing content page logic.");

        // Section 9
        DocStyles.AddH1(doc, "9", "TECHNOLOGY STACK");
        DocStyles.AddP(doc, "The software stack incorporates mature, industry-standard enterprise frameworks selected for type safety, relational data integrity, and low server operational overhead. The complete technological profile is detailed below:");

        var techList = new List<string[]> {
            new string[] { "Programming Language", "C# (C Sharp)", "Version 5.0 / 7.3 features (.NET Framework 4.8 runtime). Used for all code-behind business logic, database queries, and session management." },
            new string[] { "Web Application Framework", "ASP.NET Web Forms", "Component-based server control model with postback lifecycle, ViewState state preservation, and Master Page layouts." },
            new string[] { "Target Runtime", ".NET Framework 4.8", "Enterprise Windows application runtime providing CLR execution, ADO.NET data providers, and system cryptography." },
            new string[] { "Relational Database Engine", "Microsoft SQL Server", "Enterprise RDBMS managing 15 relational tables with clustered primary keys, identity auto-increment, unique constraints, and 25 foreign keys." },
            new string[] { "Data Access Layer", "Dapper 2.1.79 Micro-ORM", "High-performance object-relational mapping library executing parameterized SQL directly on System.Data.SqlClient connections." },
            new string[] { "Front-End UI Framework", "Bootstrap 3.4.1", "Responsive 12-column grid system, form styling, modal controls, and responsive UI navigation bars." },
            new string[] { "Client Scripting & DOM", "jQuery 3.7.1", "Client-side DOM manipulation, unobtrusive validation, and responsive interface event handling." },
            new string[] { "Client Feature Detection", "Modernizr 2.8.3", "HTML5 and CSS3 browser feature detection library bundled via Web Optimization." },
            new string[] { "JSON Serialization Engine", "Newtonsoft.Json 13.0.1", "High-performance JSON serialization for data structures and API payloads." },
            new string[] { "PDF Generation Library", "iText 9.7.0 / itext7", "Industry-standard PDF manipulation engine referenced for diagnostic document processing and billing outputs." },
            new string[] { "URL Routing Infrastructure", "FriendlyUrls 1.0.2", "Microsoft ASP.NET extension enabling clean, user-friendly extensionless URL routing." },
            new string[] { "Asset Optimization", "WebGrease & Optimization", "Runtime CSS/JS script bundling and minification minimizing HTTP client overhead." },
            new string[] { "Web Server Environment", "IIS / IIS Express", "Microsoft Internet Information Services hosting the ASP.NET pipeline and application pool." },
            new string[] { "Integrated Dev Environment", "Visual Studio 2022", "Microsoft Visual Studio 2022 Community Edition used for solution authoring and debugging." }
        };
        DocStyles.AddTable(doc, new string[] { "Component / Layer", "Technology & Version", "Architectural Function & Project Usage" }, new float[] { 22, 28, 50 }, techList);
    }
}
