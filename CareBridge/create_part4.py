import os

part4_cs = r'''using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

public static class SectionPart4 {
    public static void BuildSections12To16(Document doc) {
        // Section 12
        DocStyles.AddH1(doc, "12", "DATABASE ARCHITECTURE");
        DocStyles.AddP(doc, "The CareBridge relational database schema comprises fifteen normalized tables engineered in Microsoft SQL Server. The database enforces strict entity integrity via IDENTITY(1,1) clustered primary keys, domain integrity via column constraints, and referential integrity via twenty-five explicit foreign key relationships.");

        DocStyles.AddH2(doc, "12.1", "Complete Data Dictionary");
        DocStyles.AddP(doc, "The structural definition of all fifteen tables in the CareBridge database schema is detailed below:");

        // tbl_Login
        DocStyles.AddH3(doc, "Table 12.1: Structure of tbl_Login (Authentication & User Role Master)");
        var tLogin = new List<string[]> {
            new string[] { "LoginID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for user account" },
            new string[] { "Username", "varchar(50)", "No", "UNIQUE NONCLUSTERED", "Unique login credential identifier" },
            new string[] { "Password", "varchar(50)", "No", "None", "Account authentication password (plain text)" },
            new string[] { "Role", "varchar(20)", "No", "None", "Role: Patient, Hospital, Doctor, Lab, MedicalStore" },
            new string[] { "CreatedDate", "datetime", "Yes", "DEFAULT (getdate())", "Timestamp of account provisioning" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tLogin);

        // tbl_Patient
        DocStyles.AddH3(doc, "Table 12.2: Structure of tbl_Patient (Patient Master Profile)");
        var tPatient = new List<string[]> {
            new string[] { "PatientID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for patient" },
            new string[] { "LoginID", "int", "Yes", "FK -> tbl_Login", "Foreign key linking user login credentials" },
            new string[] { "Name", "varchar(100)", "Yes", "None", "Full legal name of patient" },
            new string[] { "Contact", "varchar(15)", "Yes", "None", "Primary mobile telephone number" },
            new string[] { "Email", "varchar(100)", "Yes", "None", "Electronic mail address" },
            new string[] { "Address", "varchar(200)", "Yes", "None", "Residential postal address" },
            new string[] { "DOB", "date", "Yes", "None", "Date of birth" },
            new string[] { "Gender", "varchar(10)", "Yes", "None", "Patient gender designation" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tPatient);

        // tbl_Hospital
        DocStyles.AddH3(doc, "Table 12.3: Structure of tbl_Hospital (Institutional Facility Master)");
        var tHospital = new List<string[]> {
            new string[] { "HospitalID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for hospital" },
            new string[] { "LoginID", "int", "Yes", "FK -> tbl_Login", "Foreign key linking hospital administrator login" },
            new string[] { "Name", "varchar(100)", "Yes", "None", "Institutional healthcare facility name" },
            new string[] { "Address", "varchar(200)", "Yes", "None", "Physical hospital campus address" },
            new string[] { "Contact", "varchar(15)", "Yes", "None", "Institutional telephone contact number" },
            new string[] { "Email", "varchar(100)", "Yes", "None", "Official facility email address" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tHospital);

        // tbl_Doctor
        DocStyles.AddH3(doc, "Table 12.4: Structure of tbl_Doctor (Practicing Clinician Profile)");
        var tDoctor = new List<string[]> {
            new string[] { "DoctorID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for doctor" },
            new string[] { "LoginID", "int", "Yes", "FK -> tbl_Login", "Foreign key linking clinician login credentials" },
            new string[] { "HospitalID", "int", "Yes", "FK -> tbl_Hospital", "Foreign key linking employing hospital facility" },
            new string[] { "Name", "varchar(100)", "Yes", "None", "Doctor's professional name with title" },
            new string[] { "Specialization", "varchar(100)", "Yes", "None", "Clinical specialty (e.g. Cardiologist)" },
            new string[] { "Contact", "varchar(15)", "Yes", "None", "Direct professional contact telephone number" },
            new string[] { "Email", "varchar(100)", "Yes", "None", "Professional clinician email address" },
            new string[] { "AvailableDays", "varchar(50)", "Yes", "None", "Weekly consulting days schedule (e.g. Mon-Sat)" },
            new string[] { "AvailableTime", "varchar(50)", "Yes", "None", "Daily consultation hours (e.g. 9:00 AM - 5:00 PM)" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tDoctor);

        // tbl_Lab
        DocStyles.AddH3(doc, "Table 12.5: Structure of tbl_Lab (Diagnostic Facility Master)");
        var tLab = new List<string[]> {
            new string[] { "LabID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for diagnostic lab" },
            new string[] { "LoginID", "int", "Yes", "FK -> tbl_Login", "Foreign key linking laboratory staff login" },
            new string[] { "HospitalID", "int", "Yes", "FK -> tbl_Hospital", "Foreign key linking parent hospital facility" },
            new string[] { "Name", "varchar(100)", "Yes", "None", "Laboratory facility / center name" },
            new string[] { "Contact", "varchar(15)", "Yes", "None", "Laboratory contact telephone number" },
            new string[] { "Address", "varchar(200)", "Yes", "None", "Physical laboratory location address" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tLab);

        // tbl_MedicalStore
        DocStyles.AddH3(doc, "Table 12.6: Structure of tbl_MedicalStore (Pharmacy Dispensary Master)");
        var tStore = new List<string[]> {
            new string[] { "StoreID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for medical store" },
            new string[] { "LoginID", "int", "Yes", "FK -> tbl_Login", "Foreign key linking pharmacy staff login" },
            new string[] { "Name", "varchar(100)", "Yes", "None", "Pharmacy dispensary commercial name" },
            new string[] { "Contact", "varchar(15)", "Yes", "None", "Dispensary contact phone number" },
            new string[] { "Address", "varchar(200)", "Yes", "None", "Physical medical store location address" },
            new string[] { "HospitalID", "int", "Yes", "FK -> tbl_Hospital", "Foreign key linking parent hospital facility" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tStore);

        // tbl_Appointment
        DocStyles.AddH3(doc, "Table 12.7: Structure of tbl_Appointment (Clinical Outpatient Appointment)");
        var tAppt = new List<string[]> {
            new string[] { "AppointmentID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for appointment" },
            new string[] { "PatientID", "int", "Yes", "FK -> tbl_Patient", "Foreign key linking consulting patient" },
            new string[] { "DoctorID", "int", "Yes", "FK -> tbl_Doctor", "Foreign key linking consulting physician" },
            new string[] { "HospitalID", "int", "Yes", "FK -> tbl_Hospital", "Foreign key linking hospital facility" },
            new string[] { "AppointmentDate", "date", "Yes", "None", "Scheduled consultation calendar date" },
            new string[] { "AppointmentTime", "varchar(20)", "Yes", "None", "Scheduled consultation time string (e.g. 18:38)" },
            new string[] { "Symptoms", "varchar(300)", "Yes", "None", "Patient-recorded presenting complaints" },
            new string[] { "Status", "varchar(20)", "Yes", "DEFAULT ('Pending')", "Status lifecycle: Pending, Confirmed, Completed" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tAppt);

        // tbl_Prescription & tbl_PrescriptionItem
        DocStyles.AddH3(doc, "Table 12.8: Structure of tbl_Prescription (Electronic Prescription Header)");
        var tPresc = new List<string[]> {
            new string[] { "PrescriptionID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for prescription" },
            new string[] { "AppointmentID", "int", "Yes", "FK -> tbl_Appointment", "Foreign key linking consultation visit" },
            new string[] { "PatientID", "int", "Yes", "FK -> tbl_Patient", "Foreign key linking patient (denormalized)" },
            new string[] { "DoctorID", "int", "Yes", "FK -> tbl_Doctor", "Foreign key linking prescribing clinician" },
            new string[] { "PrescriptionDate", "datetime", "Yes", "DEFAULT (getdate())", "Timestamp when prescription was authored" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tPresc);

        DocStyles.AddH3(doc, "Table 12.9: Structure of tbl_PrescriptionItem (Prescribed Pharmaceutical Line)");
        var tPrescItem = new List<string[]> {
            new string[] { "ItemID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for medicine line" },
            new string[] { "PrescriptionID", "int", "Yes", "FK -> tbl_Prescription", "Foreign key linking parent prescription header" },
            new string[] { "MedicineName", "varchar(100)", "Yes", "None", "Name of prescribed drug (e.g. parcitmol)" },
            new string[] { "Dosage", "varchar(50)", "Yes", "None", "Pharmaceutical dosage strength (e.g. 500mg)" },
            new string[] { "Instructions", "varchar(200)", "Yes", "None", "Usage directions (e.g. morning, after food)" },
            new string[] { "Quantity", "int", "Yes", "None", "Total number of dosage units prescribed" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tPrescItem);

        // tbl_LabTestRequest & tbl_LabReport
        DocStyles.AddH3(doc, "Table 12.10: Structure of tbl_LabTestRequest (Diagnostic Investigation Order)");
        var tTestReq = new List<string[]> {
            new string[] { "RequestID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for test request" },
            new string[] { "AppointmentID", "int", "Yes", "FK -> tbl_Appointment", "Foreign key linking consultation visit" },
            new string[] { "PatientID", "int", "Yes", "FK -> tbl_Patient", "Foreign key linking patient" },
            new string[] { "DoctorID", "int", "Yes", "FK -> tbl_Doctor", "Foreign key linking ordering physician" },
            new string[] { "LabID", "int", "Yes", "FK -> tbl_Lab", "Foreign key linking assigned diagnostic laboratory" },
            new string[] { "TestName", "varchar(100)", "Yes", "None", "Clinical investigation title (e.g. blood test)" },
            new string[] { "Status", "varchar(20)", "Yes", "DEFAULT ('Pending')", "Status lifecycle: Pending, In Progress, Completed" },
            new string[] { "RequestDate", "datetime", "Yes", "DEFAULT (getdate())", "Timestamp when investigation was ordered" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tTestReq);

        DocStyles.AddH3(doc, "Table 12.11: Structure of tbl_LabReport (Diagnostic Report File Upload)");
        var tReport = new List<string[]> {
            new string[] { "ReportID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for report upload" },
            new string[] { "RequestID", "int", "Yes", "FK -> tbl_LabTestRequest", "Foreign key linking test request" },
            new string[] { "ReportFilePath", "varchar(300)", "Yes", "None", "Relative web path to uploaded PDF report" },
            new string[] { "UploadDate", "datetime", "Yes", "DEFAULT (getdate())", "Timestamp when report was uploaded" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tReport);

        // tbl_Bill & tbl_BillItem
        DocStyles.AddH3(doc, "Table 12.12: Structure of tbl_Bill (Pharmacy Financial Bill Header)");
        var tBill = new List<string[]> {
            new string[] { "BillID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for bill" },
            new string[] { "PrescriptionID", "int", "Yes", "FK -> tbl_Prescription", "Foreign key linking dispensed prescription" },
            new string[] { "PatientID", "int", "Yes", "FK -> tbl_Patient", "Foreign key linking billed patient" },
            new string[] { "StoreID", "int", "Yes", "FK -> tbl_MedicalStore", "Foreign key linking dispensing medical store" },
            new string[] { "TotalAmount", "decimal(10,2)", "Yes", "None", "Grand financial total amount billed (INR)" },
            new string[] { "BillDate", "datetime", "Yes", "DEFAULT (getdate())", "Timestamp when bill was generated" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tBill);

        DocStyles.AddH3(doc, "Table 12.13: Structure of tbl_BillItem (Dispensary Item Line)");
        var tBillItem = new List<string[]> {
            new string[] { "BillItemID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for bill item" },
            new string[] { "BillID", "int", "Yes", "FK -> tbl_Bill", "Foreign key linking parent bill header" },
            new string[] { "MedicineName", "varchar(100)", "Yes", "None", "Name of dispensed drug line" },
            new string[] { "Quantity", "int", "Yes", "None", "Dispensed unit quantity" },
            new string[] { "Price", "decimal(10,2)", "Yes", "None", "Line amount charged for medicine" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tBillItem);

        // tbl_Specialization & tbl_SymptomMapping
        DocStyles.AddH3(doc, "Table 12.14: Structure of tbl_Specialization (Medical Specialization Master)");
        var tSpec = new List<string[]> {
            new string[] { "SpecializationID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for specialization" },
            new string[] { "Name", "varchar(100)", "Yes", "None", "Specialization designation (e.g. Cardiologist)" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tSpec);

        DocStyles.AddH3(doc, "Table 12.15: Structure of tbl_SymptomMapping (Symptom-to-Specialization Rule Table)");
        var tMap = new List<string[]> {
            new string[] { "MappingID", "int", "No", "PK, IDENTITY(1,1)", "Unique surrogate primary key for mapping" },
            new string[] { "Symptom", "varchar(100)", "Yes", "None", "Clinical symptom keyword in lower case" },
            new string[] { "SpecializationID", "int", "Yes", "FK -> tbl_Specialization", "Foreign key linking treating medical specialization" }
        };
        DocStyles.AddTable(doc, new string[] { "Column Name", "Data Type", "Nullable", "Constraint / Key", "Functional Description" }, new float[] { 22, 18, 12, 24, 24 }, tMap);

        DocStyles.AddH2(doc, "12.2", "Relational Integrity & Normalisation Analysis");
        DocStyles.AddP(doc, "The database architecture is designed in conformance with Third Normal Form (3NF) principles as defined by Codd and Elmasri & Navathe:");
        DocStyles.AddBullet(doc, "First Normal Form (1NF)", "All table attributes represent atomic values; repeating groups (such as prescription medicine lines and bill lines) are extracted into distinct child relations (tbl_PrescriptionItem and tbl_BillItem).");
        DocStyles.AddBullet(doc, "Second Normal Form (2NF)", "Every table utilizes a single-column surrogate primary key (IDENTITY), ensuring all non-key attributes are fully functionally dependent on the entire primary key.");
        DocStyles.AddBullet(doc, "Third Normal Form (3NF) & Controlled Redundancy", "Transitive dependencies are eliminated. User profile attributes are strictly separated from authentication credentials in tbl_Login. Controlled redundancy is intentionally introduced in tbl_Prescription and tbl_LabTestRequest (which store PatientID and DoctorID directly in addition to AppointmentID). This avoids expensive multi-table joins during high-frequency patient and doctor dashboard loading without compromising transactional integrity.");
        DocStyles.AddBullet(doc, "Complete Episode Auditability", "A pharmacy bill record in tbl_Bill can be deterministically traced through PrescriptionID -> AppointmentID -> PatientID / DoctorID / HospitalID, establishing a complete, legally auditable clinical chain of custody.");

        // Section 13
        DocStyles.AddH1(doc, "13", "DATA FLOW AND SYSTEM WORKFLOW");
        DocStyles.AddP(doc, "The propagation of healthcare information across CareBridge is modeled through three progressive levels of Data Flow Diagrams (DFDs), state transition models, and sequence workflows.");

        DocStyles.AddH2(doc, "13.1", "Data Flow Modeling");
        DocStyles.AddBullet(doc, "Level 0 DFD (Context Diagram)", "Treats the CareBridge system as a central processing entity (Process 0) interacting with five external entities: Patient, Doctor, Hospital Admin, Diagnostic Laboratory, and Medical Store. Patients submit credentials, symptom sets, and booking requests, receiving specialization suggestions, appointment confirmations, prescriptions, and lab reports. Doctors receive appointment queues and patient histories, issuing appointment confirmations, prescriptions, and test requests. Laboratories receive test requests, returning test status updates and PDF report files. Medical stores receive unbilled prescriptions, submitting drug prices and receiving printable bills. Administrators submit staff credentials, receiving institutional reports.");
        DocStyles.AddBullet(doc, "Level 1 DFD (Decomposed Subsystems)", "Decomposes the core system into seven distinct processes: Process 1.0 (Authenticate User -> D1 tbl_Login); Process 2.0 (Suggest Specialization -> D2 tbl_SymptomMapping, D8 tbl_Specialization); Process 3.0 (Manage Appointment -> D3 tbl_Appointment); Process 4.0 (Prescribe Medicines -> D4 tbl_Prescription, tbl_PrescriptionItem); Process 5.0 (Process Lab Tests -> D5 tbl_LabTestRequest, tbl_LabReport); Process 6.0 (Generate Billing -> D6 tbl_Bill, tbl_BillItem); and Process 7.0 (Administer Facility -> D7 tbl_Doctor, tbl_Lab, tbl_MedicalStore).");
        DocStyles.AddBullet(doc, "Level 2 DFD (Suggestion & Booking Subsystem)", "Elaborates the patient journey from symptom selection (Process 2.1), frequency aggregation (Process 2.2), fallback to General Physician (Process 2.3), clinician listing (Process 2.4), pending appointment insertion (Process 3.1), and doctor confirmation (Process 3.2).");

        DocStyles.AddH2(doc, "13.2", "State Transition Lifecycles");
        DocStyles.AddP(doc, "Two primary transactional entities in CareBridge maintain well-defined finite state machine lifecycles:");
        DocStyles.AddBullet(doc, "Appointment State Machine", "Pending -> Confirmed -> Completed. When a patient schedules a visit, the appointment is created in the 'Pending' state. Upon doctor review in Appointments.aspx, clicking 'Confirm' transitions the state to 'Confirmed'. When the doctor concludes the consultation and saves a digital prescription in WritePrescription.aspx, the state advances to 'Completed'. (If a doctor prescribes directly without prior confirmation, the state transitions directly from Pending to Completed).");
        DocStyles.AddBullet(doc, "Diagnostic Request State Machine", "Pending -> In Progress -> Completed. Created as 'Pending' when ordered by the doctor. Advances to 'In Progress' when the laboratory technician begins specimen processing. Advances to 'Completed' upon successful file upload of the PDF report.");

        DocStyles.AddH2(doc, "13.3", "End-to-End Episode of Care Sequence");
        DocStyles.AddP(doc, "The complete workflow execution was empirically verified against Appointment 2 in the test dataset at City General Hospital on 26 September 2026. The chronological execution sequence demonstrates seamless digital hand-offs without physical paperwork:");
        DocStyles.AddBullet(doc, "12:36 PM (Booking)", "Patient Roshan selects symptoms 'Fever, Chest pain'. System suggests Dr. Anjali Mehta (Cardiologist). Appointment 2 inserted with Status='Pending'.");
        DocStyles.AddBullet(doc, "12:41 PM (Prescribing)", "Dr. Mehta examines patient, enters paracetamol 500mg (qty 10), and commits Prescription 2. Appointment 2 automatically updated to Status='Completed'.");
        DocStyles.AddBullet(doc, "12:43 PM (Billing)", "City Medical opens Prescription 2 in unbilled queue, enters price 30.00, and generates Bill 2 for 30.00 with itemised printable receipt.");
        DocStyles.AddBullet(doc, "12:59 PM (Lab Ordering)", "Dr. Mehta orders a blood test at City Diagnostic. LabTestRequest 2 created with Status='Pending'.");
        DocStyles.AddBullet(doc, "13:01 PM (Report Upload)", "City Diagnostic processes sample and uploads 2_DeadStockRegister.pdf. LabReport 1 created; LabTestRequest 2 updated to 'Completed'.");
        DocStyles.AddP(doc, "Total elapsed duration: 25 minutes. No physical paper documents were transported between departments.");

        // Section 14
        DocStyles.AddH1(doc, "14", "SOFTWARE IMPLEMENTATION DETAILS");
        DocStyles.AddP(doc, "CareBridge implements distinct software engineering patterns to ensure maintainability, data security, and efficient resource utilization:");
        DocStyles.AddBullet(doc, "Centralized Database Helper Pattern", "All data access routes through DBHelper.cs, which retrieves the connection string from Web.config and instantiates a SqlConnection. By wrapping connections in using (var conn = DBHelper.GetConnection()) blocks, the CLR guarantees deterministic disposal and connection pooling.");
        DocStyles.AddBullet(doc, "SQL Injection Immunity via Dapper", "All database operations employ parameterized queries executed through Dapper extension methods (Query, QueryFirstOrDefault, Execute, ExecuteScalar). Even dynamic lists (e.g. IN @Symptoms in symptom matching) are automatically expanded by Dapper into safe individual parameter primitives (@Symptoms1, @Symptoms2), neutralizing SQL injection vectors.");
        DocStyles.AddBullet(doc, "Master Page Security Interception", "Rather than repeating role verification code across individual web forms, authorization logic is centralized in the Page_Load handler of each module's Master Page. Content pages inherit this security boundary automatically.");
        DocStyles.AddBullet(doc, "ViewState State Management", "In WritePrescription.aspx, the multi-item prescription is maintained across HTTP postbacks in ViewState using a [Serializable] class contract, preventing uncommitted database writes until the entire consultation order is completed.");

        // Section 15
        DocStyles.AddH1(doc, "15", "ORIGINAL SOFTWARE COMPONENTS AND CONTRIBUTIONS");
        DocStyles.AddP(doc, "In compliance with Indian copyright standards, this technical document clearly delineates the original authored creative work of the project developers from standard open-source and runtime components:");

        var origList = new List<string[]> {
            new string[] { "Original C# Code-Behind (.cs)", "High", "Authored C# logic across 25 code-behind files managing state, algorithmic counting, role routing, and Dapper queries." },
            new string[] { "Original Web Forms Markup (.aspx)", "High", "Authored ASP.NET presentation templates, responsive sidebars, repeater structures, and form layouts." },
            new string[] { "Relational Database Schema (T-SQL)", "High", "Original 15-table relational schema (CareBridge.txt), constraints, primary/foreign keys, and seed datasets." },
            new string[] { "Symptom Matching Algorithm", "High", "Original mathematical formulation and Dapper implementation of majority-voting doctor guidance." },
            new string[] { "Master Page Role Architecture", "High", "Role-segregated master layout architecture enforcing session-level security per directory." },
            new string[] { "Custom Site Stylesheet (Site.css)", "Medium", "Authored CSS styling defining cb-badge-* status classes, card designs, and layout aesthetics." },
            new string[] { "Third-Party Libraries & Frameworks", "Excluded", "Standard external packages (ASP.NET, Bootstrap, jQuery, Dapper, iText, Modernizr) disclaimed from copyright." }
        };
        DocStyles.AddTable(doc, new string[] { "Software Component", "Originality Level", "Scope of Original Creative Expression" }, new float[] { 26, 20, 54 }, origList);

        // Section 16
        DocStyles.AddH1(doc, "16", "SOURCE CODE STRUCTURE AND FILE ORGANISATION");
        DocStyles.AddP(doc, "The CareBridge web application solution is organized into modular directory structures reflecting architectural boundaries. The comprehensive file inventory is detailed below:");

        var fileList = new List<string[]> {
            new string[] { "Default.aspx / .cs", "Root (Common)", "Public institutional landing page with operational statistics" },
            new string[] { "About.aspx / .cs", "Root (Common)", "Institutional background and healthcare platform description" },
            new string[] { "Login.aspx / .cs", "Root (Common)", "Centralized 5-role authentication gateway and role router" },
            new string[] { "Register.aspx / .cs", "Root (Common)", "Self-service onboarding form for Patients and Hospitals" },
            new string[] { "Logout.aspx / .cs", "Root (Common)", "Session destruction and authentication teardown handler" },
            new string[] { "Web.config", "Root (Config)", "Runtime settings, compiler options, and CareBridgeDB connection string" },
            new string[] { "CareBridge.txt", "Root (Data)", "Complete 637-line T-SQL database creation and sample data script" },
            new string[] { "App_Code/DBHelper.cs", "App_Code", "Static database connection manager abstracting ADO.NET pooling" },
            new string[] { "Patient/*.aspx / .cs (8 files)", "Patient Portal", "Symptom entry, suggestions, booking, history, prescriptions, lab reports" },
            new string[] { "Doctor/*.aspx / .cs (6 files)", "Doctor Portal", "Appointments queue, patient history, prescribing, lab ordering, availability" },
            new string[] { "Lab/*.aspx / .cs (3 files)", "Lab Portal", "Test request tracking, progress management, and PDF report uploading" },
            new string[] { "MedicalStore/*.aspx / .cs (4 files)", "Pharmacy Portal", "Unbilled prescription queue, drug pricing, bill generation, printing" },
            new string[] { "Admin/*.aspx / .cs (6 files)", "Admin Portal", "Staff provisioning (Doctors, Labs, Stores), appointments, reports" }
        };
        DocStyles.AddTable(doc, new string[] { "Source File / Module", "Directory Location", "Functional Role in CareBridge Solution" }, new float[] { 26, 22, 52 }, fileList);
    }
}
'''

with open("pdf_builder/SectionPart4.cs", "w", encoding="utf-8") as f:
    f.write(part4_cs)

print("SectionPart4.cs written successfully.")
