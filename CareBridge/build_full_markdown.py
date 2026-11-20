import os

artifact_path = r"C:\Users\akxii\.gemini\antigravity\brain\7b3f68ad-c0e8-46b1-845a-77ca90e04aae\CareBridge_Software_Copyright_Documentation.md"

md_content = """# CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM
## COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION
### Submission for Registration of Computer Programme under the Indian Copyright Act, 1957

---

| **Document Parameter** | **Statutory / Technical Specification** |
| :--- | :--- |
| **Statutory Category of Work** | Computer Software / Computer Programme [Literary Work under Section 2(o) of the Indian Copyright Act, 1957] |
| **Official Title of Work** | **CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM** |
| **Software Name / Identifier** | CareBridge (`AssemblyTitle`: CareBridge; `Guid`: `167e8261-78da-40ce-94ee-8ccee7df7e4d`) |
| **Current Software Version** | Version 1.0.0.0 (Target Framework: Microsoft .NET Framework 4.8) |
| **Language(s) of Work** | C# (Back-End Business Logic), Transact-SQL (T-SQL), HTML5, CSS3, JavaScript |
| **Core Technologies** | ASP.NET Web Forms, Dapper 2.1 Micro-ORM, Microsoft SQL Server |
| **Date & Year of Creation** | September 2026 / Academic Year 2026–2027 (`AssemblyCopyright`: © 2026) |
| **Publication Status** | Unpublished Computer Programme (Confidential Institutional Technical Submission) |
| **Institutional Affiliation** | Department of Computer Science & Engineering, Prof. Ram Meghe Institute of Technology & Research (PRMIT&R), Badnera – Amravati |
| **Competent Authority** | Office of the Registrar of Copyrights, Copyright Office, Department for Promotion of Industry and Internal Trade (DPIIT), New Delhi, India |

---

## TABLE OF CONTENTS

- [1. Title of the Computer Software](#1-title-of-the-computer-software)
- [2. Software Overview](#2-software-overview)
- [3. Abstract](#3-abstract)
- [4. Purpose of the Software](#4-purpose-of-the-software)
- [5. Problem Statement](#5-problem-statement)
- [6. Description of the Software](#6-description-of-the-software)
- [7. Detailed Functionalities](#7-detailed-functionalities)
- [8. Software Architecture](#8-software-architecture)
- [9. Technology Stack](#9-technology-stack)
- [10. Module-wise Technical Description](#10-module-wise-technical-description)
- [11. Algorithms and Programming Logic](#11-algorithms-and-programming-logic)
- [12. Database Architecture](#12-database-architecture)
- [13. Data Flow and System Workflow](#13-data-flow-and-system-workflow)
- [14. Software Implementation Details](#14-software-implementation-details)
- [15. Original Software Components and Contributions](#15-original-software-components-and-contributions)
- [16. Source Code Structure and File Organisation](#16-source-code-structure-and-file-organisation)
- [17. Software Requirements and Specifications](#17-software-requirements-and-specifications)
- [18. Third-Party Dependencies and Libraries](#18-third-party-dependencies-and-libraries)
- [19. Software Execution and Operation](#19-software-execution-and-operation)
- [20. Conclusion and Technical Roadmap](#20-conclusion-and-technical-roadmap)
- [PART 4: Indian Copyright Application Information](#part-4-indian-copyright-application-information)
- [PART 5: Copyright Registration Checklist for Applicants](#part-5-copyright-registration-checklist-for-applicants)

---

## 1. TITLE OF THE COMPUTER SOFTWARE

The registered title of the computer software submitted for statutory copyright registration under the Indian Copyright Act, 1957 is:

> **CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM**

In internal codebase manifests, project files, and application deployments, the software is identified by the title **CareBridge**. The compiled binary assembly is uniquely identified by the following verified metadata recorded in `Properties/AssemblyInfo.cs`:

- **Assembly Title**: `CareBridge` (`[assembly: AssemblyTitle("CareBridge")]`)
- **Assembly Product**: `CareBridge` (`[assembly: AssemblyProduct("CareBridge")]`)
- **Copyright Declaration**: `Copyright © 2026` (`[assembly: AssemblyCopyright("Copyright ©  2026")]`)
- **Unique Type Library GUID**: `167e8261-78da-40ce-94ee-8ccee7df7e4d` (`[assembly: Guid("167e8261-78da-40ce-94ee-8ccee7df7e4d")]`)
- **Assembly Version**: `1.0.0.0` (`[assembly: AssemblyVersion("1.0.0.0")]`)
- **Assembly File Version**: `1.0.0.0` (`[assembly: AssemblyFileVersion("1.0.0.0")]`)
- **Root Code Namespace**: `CareBridge`

---

## 2. SOFTWARE OVERVIEW

CareBridge is an enterprise-grade, multi-role web-based healthcare coordination computer programme engineered to digitise and synchronize outpatient clinical workflows across municipal and district-level healthcare centers. The system directly unifies five interdependent categories of healthcare participants:
1. **Patients**: Who self-register, input symptom profiles, obtain deterministic specialization guidance, schedule appointments, and retrieve electronic prescriptions and diagnostic test reports.
2. **Hospital Administrators**: Who administer facility infrastructure, provision staff credentials for doctors, laboratories, and pharmacies, and analyze institutional operational performance.
3. **Doctors**: Who manage outpatient consultation queues, inspect longitudinal patient visit histories, generate structured multi-medicine digital prescriptions, and order computerized diagnostic investigations.
4. **Diagnostic Laboratories**: Pathology and imaging centers that ingest clinical test requests, update processing milestones, and upload validated electronic PDF diagnostic reports.
5. **Medical Stores (Pharmacies)**: Retail dispensaries that ingest authorized electronic prescriptions directly from consultation rooms, price pharmaceutical lines, and issue itemised financial bills.

The fundamental software philosophy of CareBridge is the **complete eradication of physical paper hand-offs**. By persisting all transactional data within a single, normalized Microsoft SQL Server database, CareBridge ensures that clinical decisions, diagnostic findings, and dispensary transactions propagate instantaneously across departments with end-to-end auditability.

---

## 3. ABSTRACT

Healthcare administration in municipal Indian settings remains heavily encumbered by fragmented paper records carried physically by patients between clinics, laboratories, and dispensaries. This manual decentralization induces severe department misdirection, illegible prescription interpretation, lost diagnostic records, and redundant data entry. 

CareBridge is a web-based healthcare coordination platform engineered to unify clinical, diagnostic, and pharmacy workflows on a shared relational database. Built using ASP.NET Web Forms on the Microsoft .NET Framework 4.8 with C# as the server-side language, Microsoft SQL Server as the database management engine, and Dapper 2.1 as the high-performance micro-ORM, CareBridge delivers five role-segregated portals for patients, hospital administrators, doctors, diagnostic laboratories, and medical stores. 

Patients select presenting symptoms from a forty-two symptom checklist, whereupon the system executes a deterministic majority-voting algorithm across a relational symptom-to-specialization mapping table, recommending the most appropriate medical specialty and filtering matching practitioners for appointment booking. Consulting doctors confirm appointments, examine longitudinal patient visit records, author structured multi-drug electronic prescriptions, and dispatch electronic diagnostic test orders. Diagnostic laboratories update investigation statuses and upload PDF report files accessible within the patient portal. Medical stores ingest unbilled electronic prescriptions, apply unit pricing, and render itemised bills. 

The relational database architecture comprises fifteen normalized tables enforcing primary, unique, and foreign key constraints across all clinical entities. Empirical evaluation conducted against a production dataset of one hospital (City General Hospital), thirteen doctors across thirteen medical specializations, and forty-two symptom mappings demonstrated that a complete episode of care—from booking to lab reporting and pharmacy billing—executes in twenty-five minutes without physical documentation hand-offs, with the symptom matching algorithm yielding expected specializations in 90.5% of test scenarios.

---

## 4. PURPOSE OF THE SOFTWARE

The CareBridge software is designed to accomplish the following clinical, administrative, and technical purposes:
- **Eradicate Clinical Paper Hand-offs**: Establish an automated digital pipeline linking outpatient booking, clinician prescribing, diagnostic investigation, and pharmacy dispensing on a single database.
- **Provide Explainable Patient Triage Guidance**: Guide patients from layman clinical complaints to the appropriate medical specialization through an explainable, transparent rule-based counting algorithm, mitigating inappropriate first consultations.
- **Eliminate Medication Dispensing Hazards**: Replace handwritten paper prescriptions with structured, multi-item electronic prescriptions recording distinct medicine names, dosages, unit quantities, and instructions.
- **Synchronize Laboratory Ordering and Reporting**: Streamline diagnostic requests directly to laboratory queues and return digital PDF reports directly to patient and clinician dashboards.
- **Automate Dispensary Billing**: Provide hospital pharmacies with an automated queue of unbilled prescriptions, eliminating manual retyping of prescribed medicines into local billing systems.
- **Deliver Affordable Institutional Governance**: Equip small and mid-sized healthcare centers with an enterprise-grade coordination system without the prohibitive licensing, infrastructure, and administrative overhead of legacy Hospital Information Systems.

---

## 5. PROBLEM STATEMENT

Manual outpatient workflows across small and mid-sized healthcare institutions in India present critical systemic vulnerabilities:
1. **Department Misdirection**: Patients suffering from complex symptoms frequently guess the appropriate medical department or rely on non-clinical reception staff, resulting in wasted consultations, duplicate fees, and delayed medical care.
2. **Illegible Handwritten Prescriptions**: Handwritten prescriptions frequently cause medication misinterpretation at retail pharmacies, endangering patient safety. Furthermore, paper prescriptions are frequently lost by patients, eliminating longitudinal history.
3. **Diagnostic Test Bottlenecks**: Paper laboratory slips carried physically by patients are prone to damage or loss. Patients must physically travel to laboratories for specimen collection and make separate return journeys to collect printed test results before re-queuing to see the clinician.
4. **Pharmacy Transcription Overhead**: Retail pharmacists must manually transcribe handwritten doctor slips into disparate billing software, introducing transcription errors, dispensing discrepancies, and billing latency.
5. **High Software Cost & Maintenance Barrier**: Commercial Hospital Information Systems (HIS) and monolithic open-source distributions (e.g. NIC e-Hospital, Bahmni, OpenMRS) require dedicated Linux servers, extensive database administration, and substantial capital outlay, making them unviable for local private hospitals and clinics.

---

## 6. DESCRIPTION OF THE SOFTWARE

CareBridge is structured as a unified web application delivering five dedicated, role-guarded user portals accessing a common relational database:
- **Patient Portal (`/Patient/`)**: Provides self-registration, symptom checklist selection, specialization recommendation, practitioner discovery, appointment booking, personal visit history tracking, digital prescription retrieval, and laboratory report downloads.
- **Hospital Administration Portal (`/Admin/`)**: Provides hospital executives with interfaces to provision staff accounts (Doctors, Laboratories, Medical Stores), manage facility profiles, review facility-wide outpatient queues, and inspect aggregate operational statistics.
- **Doctor Consultation Portal (`/Doctor/`)**: Enables clinicians to manage outpatient appointment queues, transition appointments from Pending to Confirmed, review historical consultations, assemble multi-item digital prescriptions, order diagnostic tests, and update weekly consulting hours.
- **Diagnostic Laboratory Portal (`/Lab/`)**: Enables pathology staff to track incoming test requisitions, update test processing states from Pending to In Progress, and upload validated electronic PDF diagnostic reports.
- **Medical Store Portal (`/MedicalStore/`)**: Ingests unbilled prescriptions into an active fulfillment queue, provides pricing inputs for each medicine line, generates official bills, and produces print-formatted invoices.

---

## 7. DETAILED FUNCTIONALITIES

CareBridge implements twenty-two functional requirements (FR1–FR22) distributed across its functional modules:

| Requirement ID | Module Scope | Functional Requirement Title | Operational Description & Implementation |
| :--- | :--- | :--- | :--- |
| **FR1** | Common | Self-Registration | Allows new patients and hospitals to register user credentials and profile records. |
| **FR2** | Common | Unique Account Validation | Enforces non-duplicate username constraints in `tbl_Login` via unique nonclustered index. |
| **FR3** | Common | Role-Based Redirection | Authenticates submitted credentials and redirects the HTTP session to the matching portal. |
| **FR4** | Common | Master Page Access Guard | Blocks unauthorized URL tampering by evaluating `Session["Role"]` on every page request. |
| **FR5** | Patient | Dashboard Analytics | Displays aggregate metric cards for upcoming visits, prescriptions, lab reports, and total visits. |
| **FR6** | Patient | Symptom Selection | Presents 42 clinical complaints and executes rule-based majority-voting specialization matching. |
| **FR7** | Patient | Doctor Suggestion Listing | Filters and lists practitioners matching the suggested medical specialization. |
| **FR8** | Patient | Appointment Booking | Captures appointment date, time, and recorded symptoms, inserting a Pending appointment. |
| **FR9** | Patient | Historical Records Access | Provides read-only access to historical visits, electronic prescriptions, and uploaded lab reports. |
| **FR10** | Patient | Profile Maintenance | Enables updating of patient contact, date of birth, gender, and residential address in `tbl_Patient`. |
| **FR11** | Doctor | Appointment Confirmation | Lists outpatient appointments and allows clinicians to transition status to Confirmed. |
| **FR12** | Doctor | Longitudinal Medical History | Displays patient's current symptoms alongside all historical consultation records. |
| **FR13** | Doctor | Digital Prescribing | Assembles multiple pharmaceutical lines in ViewState and commits header/item records. |
| **FR14** | Doctor | Diagnostic Test Ordering | Dispatches electronic test orders to hospital-attached diagnostic laboratories. |
| **FR15** | Doctor | Availability Configuration | Configures weekly consulting days and daily hour ranges in `tbl_Doctor`. |
| **FR16** | Laboratory | Test Queue Management | Lists assigned test orders and allows technicians to transition status to In Progress. |
| **FR17** | Laboratory | Diagnostic Report Upload | Uploads validated PDF report files to the server and marks test requests Completed. |
| **FR18** | Medical Store | Unbilled Prescription Queue | Filters and lists active prescriptions for which no financial bill has yet been generated. |
| **FR19** | Medical Store | Itemised Bill Generation | Captures line-item medicine prices, calculates total bill amount, and renders printable invoices. |
| **FR20** | Hospital Admin | Staff Account Provisioning | Enables hospital administrators to create credentials for Doctors, Labs, and Medical Stores. |
| **FR21** | Hospital Admin | Facility-Wide Reporting | Aggregates facility metrics for total visits, completed visits, prescriptions, tests, and bills. |
| **FR22** | Messaging | Patient Notification Spec | Integrates external messaging client specifications for patient notifications. |

---

## 8. SOFTWARE ARCHITECTURE

CareBridge is built upon an enterprise Three-Tier Architectural Pattern:

```
+--------------------------------------------------------------------------+
|                         PRESENTATION TIER                                |
|        (Web Browser: HTML5, CSS3, Bootstrap 3.4.1, jQuery 3.7.1)        |
|  Patient Portal | Doctor Portal | Admin Portal | Lab Portal | Store Portal|
+--------------------------------------------------------------------------+
                                     |  HTTP / HTTPS
                                     v
+--------------------------------------------------------------------------+
|                         APPLICATION TIER                                 |
|         (Microsoft IIS / IIS Express & .NET Framework 4.8)               |
|  * Master Page Session Role Guards (Doctor.Master, Admin.Master, etc.)   |
|  * ASP.NET Web Forms (.aspx) & C# Code-Behind (.cs) Event Handlers       |
|  * Symptom Matching Majority-Voting Engine                               |
|  * ViewState-Backed Prescription State Manager                           |
|  * DBHelper Connection Pool Manager & Dapper 2.1 Micro-ORM               |
+--------------------------------------------------------------------------+
                         |                       |
            ADO.NET / SQL|                       | Server I/O
                         v                       v
+-----------------------------------+  +-----------------------------------+
|            DATA TIER              |  |        FILE REPOSITORY            |
|       Microsoft SQL Server        |  |  * /UploadedReports/ (PDF Reports)|
|     CareBridge DB (15 Tables)     |  |  * /UploadedImages/ (Test Images) |
+-----------------------------------+  +-----------------------------------+
```

### 8.1 Session State & Role Guard Architecture
Security boundaries are enforced at the Master Page layer. Pages are organized into directory hierarchies: `/Patient/`, `/Doctor/`, `/Admin/`, `/Lab/`, and `/MedicalStore/`. Each directory contains a dedicated Master Page (e.g. `Doctor.Master.cs`) that intercepts requests during `Page_Load`:

```csharp
// Master Page Security Guard (Doctor.Master.cs)
protected void Page_Load(object sender, EventArgs e) {
    if (Session["Role"] == null || Session["Role"].ToString() != "Doctor") {
        Response.Redirect("~/Login.aspx");
    }
}
```

This guarantees that unauthenticated requests or cross-role URL tampering are immediately aborted prior to executing content page logic.

---

## 9. TECHNOLOGY STACK

| Component Layer | Technology / Tool | Version | Operational Function & Usage |
| :--- | :--- | :--- | :--- |
| **Programming Language** | C# (C-Sharp) | C# 5.0 / 7.3 | Server-side business logic, data access, algorithmic voting, and session handling. |
| **Web Framework** | ASP.NET Web Forms | .NET 4.8 | Server controls, postback lifecycle, ViewState state management, and Master Pages. |
| **Runtime Environment** | Microsoft .NET Framework | 4.8.9221.0 | Enterprise Windows CLR, ADO.NET providers, and system cryptography. |
| **Database Management** | Microsoft SQL Server | 2017+ | RDBMS managing 15 relational tables with clustered PKs, unique indexes, and 25 FKs. |
| **Data Access Layer** | Dapper Micro-ORM | 2.1.79 | High-speed object-relational mapping executing parameterized SQL queries on `SqlConnection`. |
| **Front-End Styling** | Bootstrap | 3.4.1 | Responsive 12-column layout grid, form controls, and responsive UI elements. |
| **Client Scripting** | jQuery | 3.7.1 | Client-side DOM manipulation, event handling, and responsive navigation scripts. |
| **Feature Detection** | Modernizr | 2.8.3 | HTML5/CSS3 browser capability detection for cross-browser compatibility. |
| **Serialization** | Newtonsoft.Json | 13.0.1 | JSON data serialization for complex configuration objects and API data structures. |
| **PDF Processing** | iText / itext7 | 9.7.0 | Industrial-grade PDF manipulation library for medical reporting and documentation. |
| **Routing Extension** | Microsoft.AspNet.FriendlyUrls | 1.0.2 | Generates clean, user-friendly extensionless URL routes for ASP.NET Web Forms. |
| **Asset Optimization** | Microsoft.AspNet.Web.Optimization | 1.1.3 | Runtime bundling and minification of CSS stylesheets and client scripts. |
| **Web Server** | Microsoft IIS / IIS Express | 10.0 | Hosts the ASP.NET application pipeline and manages connection pooling. |
| **Development IDE** | Microsoft Visual Studio | 2022 | Primary integrated development environment for compiling and debugging the solution. |

---

## 10. MODULE-WISE TECHNICAL DESCRIPTION

### 10.1 Common Authentication & Session Module
- `Default.aspx / .cs`: Public institutional landing page displaying operational healthcare statistics.
- `About.aspx / .cs`: Outlines clinical capabilities and institutional background.
- `Login.aspx / .cs`: Unified authentication gateway. Sanitizes inputs and executes `SELECT * FROM tbl_Login WHERE Username = @Username AND Password = @Password`. Populates `Session["LoginID"]` and `Session["Role"]`, redirecting by role.
- `Register.aspx / .cs`: Validates username uniqueness in `tbl_Login`. Uses `OUTPUT INSERTED.LoginID` to insert login credentials and profile rows in `tbl_Patient` or `tbl_Hospital`.
- `Logout.aspx / .cs`: Calls `Session.Clear()` and `Session.Abandon()`, terminating the session and redirecting to `Login.aspx`.

### 10.2 Patient Portal Module
- `Dashboard.aspx / .cs`: Runs four aggregate `COUNT` queries computing upcoming visits, active prescriptions, available lab reports, and completed visits.
- `Enter_Symptoms.aspx / .cs`: Captures checked symptoms from `cblSymptoms`, executes majority-voting query on `tbl_SymptomMapping`, and redirects to suggestions.
- `Hospital_Suggestions.aspx / .cs`: Joins `tbl_Doctor`, `tbl_Specialization`, and `tbl_Hospital` on trimmed specialty names, binding matching clinicians to `rptDoctors`.
- `Book_Appointment.aspx / .cs`: Pre-populates selected doctor and symptoms, captures date/time, and inserts `tbl_Appointment` with `Status='Pending'`.
- `Appointment_History.aspx / .cs`: Binds patient visits, applying CSS badge styling via `GetBadgeClass`.
- `Prescriptions.aspx / .cs`: Fetches prescription headers and child items in a single query, grouping items in memory to eliminate N+1 database queries.
- `Lab_Reports.aspx / .cs`: Renders downloadable links to diagnostic report files uploaded by laboratories.
- `Profile.aspx / .cs`: Maintains patient personal profile, contact number, date of birth, and gender in `tbl_Patient`.

### 10.3 Doctor Consultation Module
- `Dashboard.aspx / .cs`: Aggregates doctor's daily appointments, pending consultation confirmations, and monthly completed visits.
- `Appointments.aspx / .cs`: Outpatient queue. Contains Confirm button triggering `rptAppointments_ItemCommand`, updating `tbl_Appointment.Status = 'Confirmed'`.
- `PatientRecord.aspx / .cs`: Displays patient presenting complaints and chronological consultation history.
- `WritePrescription.aspx / .cs`: Maintains `List<MedItem>` in `ViewState`. Appends drug lines and transactionally commits `tbl_Prescription` and `tbl_PrescriptionItem`, updating appointment to `Status='Completed'`.
- `RequestLabTest.aspx / .cs`: Binds hospital laboratories to drop-down list and inserts investigation request into `tbl_LabTestRequest`.
- `SetAvailability.aspx / .cs`: Updates doctor's weekly working days and consulting hours in `tbl_Doctor`.

### 10.4 Diagnostic Laboratory Module
- `Dashboard.aspx / .cs`: Displays aggregate volumes of Pending, In Progress, and Completed diagnostic requests.
- `Pending_Tests.aspx / .cs`: Lists incoming test orders; 'Start' button updates status to 'In Progress'.
- `Upload_Report.aspx / .cs`: Validates uploaded file, prefixes RequestID to file name, saves to `/UploadedReports/`, inserts record in `tbl_LabReport`, and advances request to 'Completed'.

### 10.5 Medical Store / Pharmacy Module
- `Dashboard.aspx / .cs`: Shows unbilled prescription counts and total daily billed receipts.
- `Prescription_Queue.aspx / .cs`: Filters unbilled prescriptions via subquery: `WHERE NOT EXISTS (SELECT 1 FROM tbl_Bill b WHERE b.PrescriptionID = p.PrescriptionID)`.
- `BillPrescription.aspx / .cs`: Ingests prescribed items into Repeater with price inputs, calculates total amount, inserts `tbl_Bill` and `tbl_BillItem`, and redirects to invoice view.
- `PrintBill.aspx / .cs`: Print-formatted receipt invoking `window.print()` for physical customer billing.

### 10.6 Hospital Administration Module
- `Dashboard.aspx / .cs`: High-level facility metrics: total provisioned doctors, labs, medical stores, and daily appointments.
- `Manage_Doctors.aspx / .cs`: Provisions doctor credentials in `tbl_Login` and profiles in `tbl_Doctor` bound to `HospitalID`.
- `Manage_Labs.aspx / .cs`: Provisions laboratory user accounts.
- `Manage_Medical_Stores.aspx / .cs`: Provisions medical store user accounts.
- `View_Appointments.aspx / .cs`: Hospital-wide outpatient appointment inspection.
- `Reports.aspx / .cs`: Institutional reporting aggregating visits, prescriptions, lab tests, and dispensary bills.

### 10.7 Messaging Integration Module & Repository Discrepancy Disclosure
> [!WARNING]
> **STATUTORY REPOSITORY DISCLOSURE**: The academic project report outlines an external patient messaging module interfacing with the Meta WhatsApp Business API via a third-party gateway (BizMitra), detailing `WhatsAppService.cs`, `WebhookReceiver.ashx`, and related UI pages.
> 
> **Source Code Verification Audit**: An exhaustive audit of the uploaded CareBridge workspace repository confirms that the messaging integration source files (`WhatsAppService.cs`, `WebhookReceiver.ashx`, etc.) are **not present in the active web project directory**, nor are they compiled into `CareBridge.csproj`. Residual image artifacts exist in `/UploadedImages/`, and `Newtonsoft.Json` is present in `packages.config`.
> 
> **Scope of Copyright Protection**: In strict compliance with Indian copyright registration principles, statutory protection is claimed **exclusively on the actual computer programme code authored and deposited in this submission**—namely, the complete 5-portal web management system, ASP.NET Web Forms, Dapper data access layer, and relational database schema. The WhatsApp integration is documented as an external architectural specification and experimental prototype, but does not form part of the deposited source code registration.

---

## 11. ALGORITHMS AND PROGRAMMING LOGIC

### 11.1 Authentication & Role Routing Algorithm
1. Sanitize user input by trimming whitespace from `txtUsername` and `txtPassword`.
2. Execute parameterized SQL query: `SELECT * FROM tbl_Login WHERE Username = @Username AND Password = @Password` via Dapper.
3. If no matching record is found, display "Invalid username or password" and terminate.
4. If a matching record is returned, extract `LoginID` and `Role`, assigning them to `Session["LoginID"]` and `Session["Role"]`.
5. Execute switch-case routing on `user.Role`, redirecting to the corresponding portal dashboard (`Patient` -> `/Patient/Dashboard.aspx`, `Hospital` -> `/Admin/Dashboard.aspx`, `Doctor` -> `/Doctor/Dashboard.aspx`, `Lab` -> `/Lab/Dashboard.aspx`, `MedicalStore` -> `/MedicalStore/Dashboard.aspx`).

### 11.2 Symptom-to-Specialization Matching Algorithm
> [!NOTE]
> **STATUTORY CLARIFICATION ON ALGORITHMIC METHODOLOGY**: The CareBridge doctor suggestion algorithm is a **deterministic, rule-based majority-voting frequency count method** operating across a relational mapping table. It is **strictly NOT artificial intelligence (AI), machine learning, or a neural network**. It executes transparent, inspectable SQL aggregation logic that hospital medical staff can audit, calibrate, and tune directly within the database without altering source code.

#### Mathematical Formulation
Let $S = \{s_1, s_2, \dots, s_n\}$ be the set of clinical symptoms selected by the patient. Let $\mathcal{M} = \{(s, k) : s \in \text{Symptoms}, k \in \text{Specializations}\}$ represent the set of mapping rows in `tbl_SymptomMapping`. For each candidate medical specialization $k \in \mathcal{K}$, the voting weight $V(k)$ is defined as the cardinality of mapping rows matching the patient's selected symptoms:

$$V(k) = \left| \{ m \in \mathcal{M} : m.\text{Symptom} \in S \land m.\text{SpecializationID} = k \} \right|$$

The recommended specialization $k^*$ is selected as the argument that maximizes the voting count:

$$k^* = \arg\max_{k \in \mathcal{K}} V(k)$$

#### Implementation in `Enter_Symptoms.aspx.cs`:
```csharp
var specId = conn.QueryFirstOrDefault<int?>(
    @"SELECT TOP 1 SpecializationID FROM tbl_SymptomMapping
      WHERE Symptom IN @Symptoms
      GROUP BY SpecializationID
      ORDER BY COUNT(*) DESC",
    new { Symptoms = selectedValues });

if (specId == null) {
    specId = conn.QueryFirstOrDefault<int?>(
        "SELECT SpecializationID FROM tbl_Specialization WHERE Name = 'General Physician'");
}

string symptomText = string.Join(", ", selected);
string encoded = HttpUtility.UrlEncode(symptomText);
Response.Redirect("~/Patient/Hospital_Suggestions.aspx?spec=" + specId + "&symptoms=" + encoded);
```

#### Tie Handling and Fallback Behavior
- **Zero-Match Fallback**: If none of the selected symptoms match any entry in `tbl_SymptomMapping`, `specId` evaluates to `null`. The algorithm executes a fallback query returning the `SpecializationID` for `'General Physician'` as the safest default first contact.
- **Tie-Breaking Behavior**: In scenarios where two or more specializations tie for the highest vote count (e.g. 'Fever' [General Physician: 1] and 'Chest pain' [Cardiologist: 1]), SQL Server's `SELECT TOP 1` returns whichever group is scanned first according to its physical execution plan. This behavior is documented in empirical results (Section 5.6.4 of the project report), and deterministic tie-breaking (e.g. prioritizing acute complaints or General Physician) is slated for future releases.

### 11.3 Multi-Medicine Electronic Prescription Assembly Logic
1. Clinicians stage medicines in an in-memory serializable collection: `[Serializable] public class MedItem { string MedicineName, Dosage, Quantity, Instructions; }`, persisted across postbacks in `ViewState["Medicines"]`.
2. Clicking 'Add Medicine' appends a new `MedItem` to the collection and re-binds Repeater `rptMedicines`.
3. Clicking 'Finish' validates `ViewState["Medicines"].Count > 0`. It resolves `PatientID` from `tbl_Appointment` and `DoctorID` from `tbl_Doctor`.
4. Executes `INSERT INTO tbl_Prescription ... OUTPUT INSERTED.PrescriptionID` to retrieve the generated identity.
5. Iterates over `MedItem` items, executing parameterized INSERTs into `tbl_PrescriptionItem`.
6. Executes `UPDATE tbl_Appointment SET Status = 'Completed' WHERE AppointmentID = @Id`, completing the consultation.

### 11.4 Laboratory Diagnostic Ordering & Report Upload Workflow
1. Doctor selects laboratory and inputs investigation title. Executes `INSERT INTO tbl_LabTestRequest` with `Status='Pending'`.
2. Laboratory technician reviews incoming queue in `Pending_Tests.aspx` and clicks 'Start', updating status to `'In Progress'`.
3. Upon conclusion of testing, technician uploads PDF file in `Upload_Report.aspx`. The system generates `fileName = requestId + "_" + Path.GetFileName(fileUpload.FileName)`, saves the file to `~/UploadedReports/`, inserts a record into `tbl_LabReport`, and advances the request status to `'Completed'`.

### 11.5 Medical Store Queue Filtration & Bill Generation Logic
1. `Prescription_Queue.aspx` queries `tbl_Prescription` using a `NOT EXISTS` subquery against `tbl_Bill`, filtering unbilled prescriptions.
2. `BillPrescription.aspx` loads prescribed drugs into Repeater `rptItems` with price inputs.
3. The code-behind parses `txtPrice` and accumulates line amounts: `total += price`. It inserts a record into `tbl_Bill` retrieving `BillID` via `OUTPUT INSERTED.BillID`, then copies line items into `tbl_BillItem`.
4. Redirects to `PrintBill.aspx?billId=...`, rendering an itemised invoice.

---

## 12. DATABASE ARCHITECTURE

The database schema comprises fifteen interrelated tables engineered in Microsoft SQL Server, fully defined in `CareBridge.txt`.

### 12.1 Data Dictionary Summary

| Table Name | Primary Key | Foreign Keys | Functional Entity Role in System |
| :--- | :--- | :--- | :--- |
| `tbl_Login` | `LoginID` (Identity) | None (Parent Table) | Stores system credentials, password, role, and creation timestamp. |
| `tbl_Patient` | `PatientID` (Identity) | `LoginID` -> `tbl_Login` | Stores patient demographics, contact details, DOB, and address. |
| `tbl_Hospital` | `HospitalID` (Identity) | `LoginID` -> `tbl_Login` | Stores institutional healthcare facility details. |
| `tbl_Doctor` | `DoctorID` (Identity) | `LoginID` -> `tbl_Login`, `HospitalID` -> `tbl_Hospital` | Stores clinician profile, specialty, contact, and consulting hours. |
| `tbl_Lab` | `LabID` (Identity) | `LoginID` -> `tbl_Login`, `HospitalID` -> `tbl_Hospital` | Stores diagnostic laboratory profile and contact details. |
| `tbl_MedicalStore` | `StoreID` (Identity) | `LoginID` -> `tbl_Login`, `HospitalID` -> `tbl_Hospital` | Stores pharmacy dispensary profile and facility linkage. |
| `tbl_Appointment` | `AppointmentID` (Identity) | `PatientID`, `DoctorID`, `HospitalID` | Records outpatient consultation bookings, symptoms, date, and status. |
| `tbl_Prescription` | `PrescriptionID` (Identity) | `AppointmentID`, `PatientID`, `DoctorID` | Electronic prescription header authored during consultation. |
| `tbl_PrescriptionItem`| `ItemID` (Identity) | `PrescriptionID` -> `tbl_Prescription` | Individual pharmaceutical drug lines (dosage, quantity, instructions). |
| `tbl_LabTestRequest` | `RequestID` (Identity) | `AppointmentID`, `PatientID`, `DoctorID`, `LabID` | Computerized diagnostic investigation order and processing status. |
| `tbl_LabReport` | `ReportID` (Identity) | `RequestID` -> `tbl_LabTestRequest` | File upload record linking PDF report path to test order. |
| `tbl_Bill` | `BillID` (Identity) | `PrescriptionID`, `PatientID`, `StoreID` | Pharmacy financial invoice header capturing total billing amount. |
| `tbl_BillItem` | `BillItemID` (Identity) | `BillID` -> `tbl_Bill` | Dispensed drug line items capturing medicine name, quantity, and price. |
| `tbl_Specialization` | `SpecializationID` (Identity) | None (Lookup Table) | Master list of clinical specializations (13 medical specialties). |
| `tbl_SymptomMapping` | `MappingID` (Identity) | `SpecializationID` -> `tbl_Specialization` | Relational mapping linking symptom keywords to specialization IDs. |

### 12.2 Referential Integrity & 25 Foreign Key Constraints
The schema enforces twenty-five explicit foreign key relationships guaranteeing referential consistency across the care episode:
1. `tbl_Doctor.HospitalID` -> `tbl_Hospital.HospitalID`
2. `tbl_Doctor.LoginID` -> `tbl_Login.LoginID`
3. `tbl_Hospital.LoginID` -> `tbl_Login.LoginID`
4. `tbl_Lab.HospitalID` -> `tbl_Hospital.HospitalID`
5. `tbl_Lab.LoginID` -> `tbl_Login.LoginID`
6. `tbl_MedicalStore.HospitalID` -> `tbl_Hospital.HospitalID`
7. `tbl_MedicalStore.LoginID` -> `tbl_Login.LoginID`
8. `tbl_Patient.LoginID` -> `tbl_Login.LoginID`
9. `tbl_Appointment.DoctorID` -> `tbl_Doctor.DoctorID`
10. `tbl_Appointment.HospitalID` -> `tbl_Hospital.HospitalID`
11. `tbl_Appointment.PatientID` -> `tbl_Patient.PatientID`
12. `tbl_Prescription.AppointmentID` -> `tbl_Appointment.AppointmentID`
13. `tbl_Prescription.DoctorID` -> `tbl_Doctor.DoctorID`
14. `tbl_Prescription.PatientID` -> `tbl_Patient.PatientID`
15. `tbl_PrescriptionItem.PrescriptionID` -> `tbl_Prescription.PrescriptionID`
16. `tbl_LabTestRequest.AppointmentID` -> `tbl_Appointment.AppointmentID`
17. `tbl_LabTestRequest.DoctorID` -> `tbl_Doctor.DoctorID`
18. `tbl_LabTestRequest.LabID` -> `tbl_Lab.LabID`
19. `tbl_LabTestRequest.PatientID` -> `tbl_Patient.PatientID`
20. `tbl_LabReport.RequestID` -> `tbl_LabTestRequest.RequestID`
21. `tbl_Bill.PatientID` -> `tbl_Patient.PatientID`
22. `tbl_Bill.PrescriptionID` -> `tbl_Prescription.PrescriptionID`
23. `tbl_Bill.StoreID` -> `tbl_MedicalStore.StoreID`
24. `tbl_BillItem.BillID` -> `tbl_Bill.BillID`
25. `tbl_SymptomMapping.SpecializationID` -> `tbl_Specialization.SpecializationID`

---

## 13. DATA FLOW AND SYSTEM WORKFLOW

### 13.1 State Machine Lifecycles
- **Appointment Lifecycle**:
  `[Initial: Booking]` -> **`Pending`** -> *(Doctor clicks Confirm)* -> **`Confirmed`** -> *(Doctor commits Prescription)* -> **`Completed`** `[Final]`
- **Diagnostic Test Lifecycle**:
  `[Initial: Doctor Orders]` -> **`Pending`** -> *(Lab clicks Start)* -> **`In Progress`** -> *(Lab uploads PDF Report)* -> **`Completed`** `[Final]`

### 13.2 Trace of Clinical Care Episode (Appointment 2 Empirical Dataset)
The end-to-end integration was empirically validated on 26 September 2026 at City General Hospital:
- **12:36 PM**: Patient Roshan books with symptoms *Fever, Chest pain*. System suggests Dr. Anjali Mehta (Cardiologist). `tbl_Appointment` record #2 created with `Status='Pending'`.
- **12:41 PM**: Dr. Mehta examines patient, enters paracetamol 500mg (quantity 10), and commits prescription. `tbl_Prescription` #2 and `tbl_PrescriptionItem` #2 created; `tbl_Appointment` updated to `Status='Completed'`.
- **12:43 PM**: City Medical opens Prescription 2 in unbilled queue, inputs price 30.00, and commits `tbl_Bill` #2 and `tbl_BillItem` #2, printing itemised bill.
- **12:59 PM**: Dr. Mehta orders a blood test at City Diagnostic. `tbl_LabTestRequest` #2 created with `Status='Pending'`.
- **13:01 PM**: City Diagnostic processes sample and uploads `2_DeadStockRegister.pdf`. `tbl_LabReport` #1 created; `tbl_LabTestRequest` #2 updated to `Status='Completed'`.

**Result**: Total episode duration: 25 minutes. Zero physical paper hand-offs required.

---

## 14. SOFTWARE IMPLEMENTATION DETAILS

### 14.1 Database Access Abstraction
All database operations route through `DBHelper.cs`:
```csharp
public class DBHelper {
    public static string ConnStr = ConfigurationManager.ConnectionStrings["CareBridgeDB"].ConnectionString;
    public static SqlConnection GetConnection() {
        return new SqlConnection(ConnStr);
    }
}
```
By wrapping queries in `using (var conn = DBHelper.GetConnection())` blocks, ADO.NET connection pooling automatically manages connection opening and disposal, preventing connection leaks.

### 14.2 SQL Injection Prevention via Parameterization
All queries employ parameterized SQL executed through Dapper:
```csharp
string query = "SELECT * FROM tbl_Login WHERE Username = @Username AND Password = @Password";
var user = conn.QueryFirstOrDefault(query, new { Username = username, Password = password });
```
Dapper binds inputs as strongly typed parameters, ensuring malicious input strings (e.g. `' OR 1=1 --`) cannot alter query execution logic.

---

## 15. ORIGINAL SOFTWARE COMPONENTS AND CONTRIBUTIONS

| Component Category | Originality Assessment | Description of Authored Creative Contribution |
| :--- | :--- | :--- |
| **C# Code-Behind (.cs)** | **Original Authored Work** | Authored business logic, role verification, state management, and Dapper queries across 25 C# code-behind files. |
| **Web Forms Markup (.aspx)** | **Original Authored Work** | Authored presentation templates, responsive sidebars, repeater layouts, and form bindings. |
| **Relational Database DDL** | **Original Authored Work** | Authored 15-table relational schema (`CareBridge.txt`), constraints, foreign keys, and seed datasets. |
| **Symptom Matching Logic** | **Original Authored Work** | Original mathematical rule-based majority-voting formulation and Dapper query implementation. |
| **Master Page Architecture** | **Original Authored Work** | Role-segregated Master Page architecture enforcing session-level security per directory. |
| **Custom Site Stylesheet** | **Original Authored Work** | Authored CSS classes (`cb-badge-*`, responsive tables, layout structure) in `Site.css`. |
| **Third-Party Libraries** | **Excluded from Claim** | Standard open-source libraries (ASP.NET, Bootstrap, jQuery, Dapper, iText, Modernizr) disclaimed from copyright. |

---

## 16. SOURCE CODE STRUCTURE AND FILE ORGANISATION

The CareBridge solution comprises the following file hierarchy:
- `App_Code/DBHelper.cs`: Static connection pool manager.
- `Admin/` (6 pages): `Admin.Master`, `Dashboard.aspx`, `Manage_Doctors.aspx`, `Manage_Labs.aspx`, `Manage_Medical_Stores.aspx`, `Reports.aspx`, `View_Appointments.aspx`.
- `Doctor/` (6 pages): `Doctor.Master`, `Dashboard.aspx`, `Appointments.aspx`, `PatientRecord.aspx`, `WritePrescription.aspx`, `RequestLabTest.aspx`, `SetAvailability.aspx`.
- `Lab/` (3 pages): `Lab.Master`, `Dashboard.aspx`, `Pending_Tests.aspx`, `Upload_Report.aspx`.
- `MedicalStore/` (4 pages): `MedicalStore.Master`, `Dashboard.aspx`, `Prescription_Queue.aspx`, `BillPrescription.aspx`, `PrintBill.aspx`.
- `Patient/` (8 pages): `Patient.Master`, `Dashboard.aspx`, `Enter_Symptoms.aspx`, `Hospital_Suggestions.aspx`, `Book_Appointment.aspx`, `Appointment_History.aspx`, `Prescriptions.aspx`, `Lab_Reports.aspx`, `Profile.aspx`.
- Root Files: `Default.aspx`, `About.aspx`, `Login.aspx`, `Register.aspx`, `Logout.aspx`, `Web.config`, `CareBridge.txt` (SQL schema), `CareBridge.csproj`.

---

## 17. SOFTWARE REQUIREMENTS AND SPECIFICATIONS

- **Server OS**: Windows 10/11 Professional (64-bit) or Windows Server 2016/2019/2022.
- **Web Server**: Microsoft Internet Information Services (IIS) 10.0 or IIS Express.
- **Runtime Environment**: Microsoft .NET Framework 4.8.
- **Database Engine**: Microsoft SQL Server 2017+ (Express, Developer, or Standard).
- **Server Hardware (Min)**: Intel Core i3 / AMD Ryzen 3, 4 GB RAM, 10 GB SSD, 100 Mbps LAN.
- **Client Requirements**: Modern browser (Chrome 90+, Edge 90+, Firefox 88+), 2 GB RAM.

---

## 18. THIRD-PARTY DEPENDENCIES AND LIBRARIES

| Package Name | Exact Version | License Type | Usage in CareBridge |
| :--- | :--- | :--- | :--- |
| **Dapper** | 2.1.79 | Apache-2.0 | Micro-ORM executing parameterized SQL queries on `SqlConnection`. |
| **Newtonsoft.Json** | 13.0.1 | MIT | High-performance JSON data serialization engine. |
| **itext / itext7** | 9.7.0 | AGPL-3.0 / Commercial | Industrial-grade PDF manipulation and report rendering engine. |
| **BouncyCastle.Cryptography** | 2.6.2 | MIT | Underlying cryptographic algorithms supporting document signing. |
| **Microsoft.AspNet.FriendlyUrls** | 1.0.2 | Apache-2.0 | Extensionless URL routing within ASP.NET Web Forms. |
| **Microsoft.AspNet.Web.Optimization** | 1.1.3 | Apache-2.0 | Runtime CSS and JavaScript bundling and minification. |
| **Bootstrap** | 3.4.1 | MIT | Front-end 12-column responsive layout grid and form controls. |
| **jQuery** | 3.7.1 | MIT | Client-side DOM manipulation, validation, and event handling. |
| **Modernizr** | 2.8.3 | MIT | Client-side browser HTML5/CSS3 feature detection. |
| **Antlr** | 3.5.0.2 | BSD-3-Clause | Lexer and parser generator utilized by Web.Optimization. |
| **WebGrease** | 1.6.0 | Apache-2.0 | Static asset processing and minification pipeline. |

---

## 19. SOFTWARE EXECUTION AND OPERATION

### 19.1 Database Initialization
1. Launch SQL Server Management Studio (SSMS). Connect to local or network SQL Server.
2. Execute `CREATE DATABASE CareBridge;`.
3. Open `CareBridge.txt` and execute the 637-line T-SQL script, generating the 15 tables, constraints, foreign keys, and seed data.

### 19.2 Web Application Hosting
1. Open `CareBridge.sln` in Visual Studio 2022. Restore NuGet dependencies.
2. Calibrate `Web.config` connection string:
   ```xml
   <connectionStrings>
       <add name="CareBridgeDB" 
            connectionString="Data Source=BITBEAST; Initial Catalog=CareBridge; Integrated Security=True;" 
            providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
3. Compile in Release mode. Publish to IIS or launch via IIS Express. Ensure IIS AppPool has Write permissions on `~/UploadedReports/`.

---

## 20. CONCLUSION AND TECHNICAL ROADMAP

The CareBridge software achieves its stated architectural objective: establishing a robust, multi-portal web coordination platform linking Patients, Hospitals, Doctors, Laboratories, and Medical Stores on a shared relational database without physical paper hand-offs.

### 20.1 Technical Limitations Disclosed
- **Plain-Text Passwords**: Passwords in `tbl_Login` currently reside in plain text. Future releases will migrate to salted PBKDF2/bcrypt hashing.
- **Row-Level Ownership Validation**: Pages reading query-string IDs (e.g. `PatientRecord.aspx?appointmentId=...`) currently rely on session authentication without checking whether the record belongs to the user's hospital. Enforcing ownership predicates is planned.
- **Billing Arithmetic**: `BillPrescription.aspx.cs` currently accumulates entered prices directly (`total += price`). Implementing unit price multiplication (`price * quantity`) is scheduled.
- **Symptom Matching Ties**: In cases of equal top vote counts between specializations, SQL Server returns the first record scanned. Deterministic clinical weighting rules represent a future enhancement.

### 20.2 Future Roadmap
- **Ayushman Bharat Digital Mission (ABDM)**: Integrating ABHA health IDs and unified health interface protocols.
- **HL7 FHIR Compliance**: Exposing RESTful FHIR R4 standard resources (`Patient`, `Appointment`, `MedicationRequest`, `DiagnosticReport`).
- **Master Formulary Integration**: Standardized drug database with autocompletion to eradicate spelling errors.

---

## PART 4: STATUTORY INDIAN COPYRIGHT APPLICATION INFORMATION

The following particulars are compiled in accordance with **Form XIV (Application for Registration of Copyright)** under Rule 70 of the Copyright Rules, 2013:

### Statement of Particulars
1. **Name, Address & Nationality of Applicant**:
   - `[LEGAL PLACEHOLDER: Full Name(s), Permanent Address(es), and Nationality (Indian) of Student Applicants OR Institutional Name: Prof. Ram Meghe Institute of Technology & Research, Badnera – Amravati, Maharashtra - 444701]`
2. **Nature of Applicant's Interest in the Copyright**:
   - `[LEGAL PLACEHOLDER: Original Authors / Joint Owners OR Assignee under Institutional Intellectual Property Policy]`
3. **Class and Description of Work**:
   - Computer Software / Computer Programme [Literary Work under Section 2(o) of the Indian Copyright Act, 1957].
4. **Title of the Work**:
   - **CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM**
5. **Language of the Work**:
   - C# (C-Sharp), Transact-SQL (T-SQL), HTML5, CSS3, JavaScript.
6. **Name, Address & Nationality of Author(s)**:
   - `[LEGAL PLACEHOLDER: Student Author 1: <Student Name 1>, Address, Indian]`
   - `[LEGAL PLACEHOLDER: Student Author 2: <Student Name 2>, Address, Indian]`
   - `[LEGAL PLACEHOLDER: Student Author 3: <Student Name 3>, Address, Indian]`
   - `[LEGAL PLACEHOLDER: Student Author 4: <Student Name 4>, Address, Indian]`
7. **Year of Completion of the Work**:
   - 2026 (September 2026; Academic Year 2026–2027).
8. **Whether the Work is Published or Unpublished**:
   - Unpublished Computer Programme.
9. **Year and Country of First Publication**:
   - Not Applicable (Work is Unpublished).
10. **Name, Address and Nationality of Publisher**:
    - Not Applicable (Work is Unpublished).
11. **Name, Address and Nationality of Owners of Various Rights**:
    - `[LEGAL PLACEHOLDER: As per Item 1 / Institutional Assignment Deed]`
12. **Other Persons Authorized to Assign or License Rights**:
    - `[LEGAL PLACEHOLDER: As per Item 1 / Guide / Head of Department]`
13. **Source Code Details**:
    - Source code deposited in printed/optical format (First 10 and Last 10 pages of source code listing plus full optical disc repository).

### Statement of Further Particulars
- **Is the work an original work?**: Yes. The C# code-behind, database schemas, symptom matching algorithm, and web forms are original authored works of the authors.
- **Does the work contain pre-existing / third-party software?**: Yes. Incorporates standard open-source libraries (ASP.NET Web Forms, Dapper 2.1.79, Bootstrap 3.4.1, jQuery 3.7.1, Newtonsoft.Json 13.0.1, iText 9.7.0). Copyright is claimed exclusively on original authored source code.

---

## PART 5: COPYRIGHT REGISTRATION APPLICANT CHECKLIST

Before submitting the formal application on the Indian Copyright Office portal (https://copyright.gov.in), the applicant team must ensure the following requirements are fulfilled:

1. **Applicant & Author Identifiers**:
   - Collect verified legal names, residential addresses, PIN codes, mobile numbers, email addresses, and self-attested Government Photo ID copies (Aadhaar Card / Passport) for all student authors.
2. **Institutional No-Objection Certificate (NOC) / Assignment Deed**:
   - If filing in the names of the student authors: Obtain a formal No-Objection Certificate (NOC) on institutional letterhead signed by the Project Guide and Head of Department (Dr. M. A. Pund) confirming student authorship and authorizing copyright registration.
   - If filing in the name of the Institute: Execute a formal Copyright Assignment Deed from the student authors assigning copyright ownership to Prof. Ram Meghe Institute of Technology and Research.
3. **Source Code Listing Preparation**:
   - Print a clean, formatted listing of the **first 10 pages and last 10 pages** (or first 20 and last 20 pages) of original C# and SQL source code. Ensure all passwords, database connection credentials, and temporary access tokens are completely redacted.
4. **Optical Storage Media (CD-R / DVD-R)**:
   - Burn two identical, uncompiled copies of the complete source code repository, database creation script (`CareBridge.txt`), and this technical documentation onto CD-R or DVD-R media, labelled with the software title and author names.
5. **Statutory Government Filing Fee**:
   - Pay the statutory filing fee of **INR 500** per computer software application via the Bharatkosh online payment gateway integrated with the copyright portal.
6. **Form XIV & Statement of Further Particulars Attestation**:
   - Print, date, and physically sign Form XIV and the Statement of Further Particulars by all co-applicants / co-authors.
7. **Statutory 30-Day Mandatory Waiting Period**:
   - Following online filing and generation of the Diary Number, a mandatory 30-day objection period is observed by the Copyright Office before formal examination and issuance of the Registration Certificate (ROC).
"""

with open(artifact_path, "w", encoding="utf-8") as f:
    f.write(md_content)

print("Markdown artifact created successfully, length:", os.path.getsize(artifact_path))
