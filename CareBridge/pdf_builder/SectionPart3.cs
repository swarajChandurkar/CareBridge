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

public static class SectionPart3 {
    public static void BuildSections10And11(Document doc) {
        // Section 10
        DocStyles.AddH1(doc, "10", "MODULE-WISE TECHNICAL DESCRIPTION");
        DocStyles.AddP(doc, "CareBridge is organized into seven functional modules comprising thirty-five individual web forms, master pages, and shared infrastructure components. The following technical breakdown details the code architecture, data contracts, and server-side processing across each module.");

        DocStyles.AddH2(doc, "10.1", "Common Authentication & Session Module");
        DocStyles.AddP(doc, "The Common Module encompasses the public-facing pages and core authentication lifecycle. Default.aspx serves as the institutional landing page displaying operational metrics. About.aspx outlines facility capabilities. Login.aspx presents a centralized entry point authenticating all five user roles against tbl_Login. Register.aspx enables self-service onboarding for Patients and Hospitals. Logout.aspx terminates the active session, clears authentication keys, and redirects to the landing page.");
        DocStyles.AddP(doc, "In Login.aspx.cs, credentials submitted via txtUsername and txtPassword are sanitized and passed to a parameterized Dapper query. If valid, Session[\"LoginID\"] and Session[\"Role\"] are assigned, and the runtime issues an HTTP 302 redirection to the corresponding dashboard. In Register.aspx.cs, the system checks whether the username exists in tbl_Login. If unique, an INSERT statement utilizing OUTPUT INSERTED.LoginID creates the login record, followed by the insertion of the profile entity in tbl_Patient or tbl_Hospital.");

        DocStyles.AddH2(doc, "10.2", "Patient Portal Module");
        DocStyles.AddP(doc, "The Patient Module delivers eight specialized interfaces located under the /Patient/ virtual path, guarded by Patient.Master:");
        DocStyles.AddBullet(doc, "Dashboard.aspx", "Executes four aggregate COUNT queries determining upcoming appointments (Status in 'Pending', 'Confirmed'), active prescriptions, uploaded lab reports, and completed visits.");
        DocStyles.AddBullet(doc, "Enter_Symptoms.aspx", "Presents forty-two selectable symptoms bound to CheckBoxList cblSymptoms. Upon submission, it queries tbl_SymptomMapping using SQL GROUP BY and ORDER BY COUNT(*) DESC, redirecting to hospital suggestions.");
        DocStyles.AddBullet(doc, "Hospital_Suggestions.aspx", "Extracts the matched specialization ID from the query string, executes an inner join between tbl_Doctor, tbl_Specialization, and tbl_Hospital, and binds matching clinicians to Repeater rptDoctors.");
        DocStyles.AddBullet(doc, "Book_Appointment.aspx", "Pre-populates the selected clinician and symptoms, captures date and time input, resolves the DoctorID and HospitalID, and inserts a new appointment record with Status='Pending'.");
        DocStyles.AddBullet(doc, "Appointment_History.aspx", "Retrieves all appointments for the logged-in patient, mapping status values to styled badge CSS classes via GetBadgeClass.");
        DocStyles.AddBullet(doc, "Prescriptions.aspx", "Executes an optimized single-query fetch of all prescription headers and items for the patient, grouping items in memory using LINQ to eliminate the N+1 query problem.");
        DocStyles.AddBullet(doc, "Lab_Reports.aspx", "Queries tbl_LabReport joined with tbl_LabTestRequest and tbl_Lab, rendering clickable direct download links for uploaded diagnostic PDF reports.");
        DocStyles.AddBullet(doc, "Profile.aspx", "Provides form controls allowing the patient to maintain phone contact, email, residential address, date of birth, and gender in tbl_Patient.");

        DocStyles.AddH2(doc, "10.3", "Doctor Consultation Module");
        DocStyles.AddP(doc, "Located under /Doctor/ and governed by Doctor.Master, this module provides six specialized clinical interfaces:");
        DocStyles.AddBullet(doc, "Dashboard.aspx", "Displays key practitioner metrics including appointments scheduled for today, pending confirmation requests, and completed visits for the current calendar month.");
        DocStyles.AddBullet(doc, "Appointments.aspx", "Lists scheduled outpatient appointments. Pending appointments feature a 'Confirm' button triggering rptAppointments_ItemCommand, which updates tbl_Appointment.Status to 'Confirmed'.");
        DocStyles.AddBullet(doc, "PatientRecord.aspx", "Accepts appointmentId via query string, displays the patient's presenting symptoms and visit date, and renders a historical consultation trail of previous visits.");
        DocStyles.AddBullet(doc, "WritePrescription.aspx", "Maintains an in-memory List<MedItem> in ViewState. Clinicians iteratively add drug lines; upon clicking 'Finish', the header is inserted into tbl_Prescription, items into tbl_PrescriptionItem, and the appointment status is updated to 'Completed'.");
        DocStyles.AddBullet(doc, "RequestLabTest.aspx", "Binds available hospital laboratories to a drop-down control, capturing the requested investigation name and creating a record in tbl_LabTestRequest with Status='Pending'.");
        DocStyles.AddBullet(doc, "SetAvailability.aspx", "Enables consulting practitioners to update their weekly consulting days (e.g. 'Mon-Sat') and hours (e.g. '9:00 AM - 5:00 PM') in tbl_Doctor.");

        DocStyles.AddH2(doc, "10.4", "Diagnostic Laboratory Module");
        DocStyles.AddP(doc, "Located under /Lab/ and governed by Lab.Master, this module delivers three operational screens:");
        DocStyles.AddBullet(doc, "Dashboard.aspx", "Aggregates test order volumes categorized into Pending, In Progress, and Completed states for the authenticated laboratory.");
        DocStyles.AddBullet(doc, "Pending_Tests.aspx", "Lists incoming investigation orders. Technicians click 'Start' to update status from 'Pending' to 'In Progress'.");
        DocStyles.AddBullet(doc, "Upload_Report.aspx", "Accepts report files via ASP.NET FileUpload control. The code-behind sanitizes the file name by prefixing the RequestID, saves the file to ~/UploadedReports/, inserts a record into tbl_LabReport, and advances the request status to 'Completed'.");

        DocStyles.AddH2(doc, "10.5", "Medical Store / Pharmacy Module");
        DocStyles.AddP(doc, "Located under /MedicalStore/ and governed by MedicalStore.Master, this module provides dispensary workflows across four pages:");
        DocStyles.AddBullet(doc, "Dashboard.aspx", "Displays counts of unbilled prescriptions pending dispensation and total financial bills settled today.");
        DocStyles.AddBullet(doc, "Prescription_Queue.aspx", "Filters unbilled orders using a subquery: WHERE NOT EXISTS (SELECT 1 FROM tbl_Bill b WHERE b.PrescriptionID = p.PrescriptionID).");
        DocStyles.AddBullet(doc, "BillPrescription.aspx", "Enumerates prescribed medicines into Repeater rptItems with pricing input textboxes. Calculates total bill amount, inserts header in tbl_Bill, copies items into tbl_BillItem, and redirects to print view.");
        DocStyles.AddBullet(doc, "PrintBill.aspx", "Renders a clean, print-optimized invoice showing patient details, dispensed medicines, quantities, line prices, and grand total, invoking the browser's native window.print() API.");

        DocStyles.AddH2(doc, "10.6", "Hospital Administration Module");
        DocStyles.AddP(doc, "Located under /Admin/ and governed by Admin.Master, this module equips hospital management with administrative oversight across six pages:");
        DocStyles.AddBullet(doc, "Dashboard.aspx", "Displays hospital-level tallies of provisioned doctors, diagnostic laboratories, medical stores, and daily appointments.");
        DocStyles.AddBullet(doc, "Manage_Doctors.aspx", "Provisions doctor credentials in tbl_Login and profile records in tbl_Doctor bound to the hospital's HospitalID. Enables doctor record removal.");
        DocStyles.AddBullet(doc, "Manage_Labs.aspx", "Creates laboratory logins and profiles linked to the facility.");
        DocStyles.AddBullet(doc, "Manage_Medical_Stores.aspx", "Provisions pharmacy dispensary user accounts.");
        DocStyles.AddBullet(doc, "View_Appointments.aspx", "Provides a comprehensive, searchable list of all outpatient consultations booked under the hospital.");
        DocStyles.AddBullet(doc, "Reports.aspx", "Executes hospital-scoped analytics aggregating total consultations, completed consultations, written prescriptions, ordered lab tests, and settled pharmacy bills.");

        DocStyles.AddH2(doc, "10.7", "Messaging Integration Module & Repository Discrepancy Analysis");
        DocStyles.AddP(doc, "The academic project report describes an external patient messaging module designed to interface with the Meta WhatsApp Business API via a third-party gateway (BizMitra). The intended architecture specified three outbound REST endpoints (/send-message, /send-media-message, /send-template-message), a webhook receiver (WebhookReceiver.ashx) logging delivery callbacks to App_Data, and UI pages (SendMessage.aspx, SendApplicationInvite.aspx, WebhookLogViewer.aspx).");
        
        DocStyles.AddCallout(doc, "IMPORTANT STATUTORY DISCREPANCY & REPOSITORY STATUS DISCLOSURE", 
            "SOURCE CODE VERIFICATION FINDING: A comprehensive audit of the uploaded CareBridge workspace repository confirms that the messaging integration source files (WhatsAppService.cs, WebhookReceiver.ashx, SendMessage.aspx, SendApplicationInvite.aspx, WebhookLogViewer.aspx) are NOT present in the active web project directory, nor are they referenced in CareBridge.csproj. However, the UploadedImages/ folder contains residual image artifacts from prior API testing, and Newtonsoft.Json is present in packages.config.\n\n" +
            "LEGAL & COPYRIGHT REGISTRATION IMPLICATION: In accordance with statutory copyright registration requirements in India, copyright protection is claimed exclusively on the actual computer programme code authored and deposited in this submission—namely, the complete five-portal clinical management system, ASP.NET Web Forms, Dapper data access layer, and relational database schema. The WhatsApp messaging integration is documented herein as an external architectural specification and experimental prototype, but does not form part of the deposited source code registration.", true);

        // Section 11
        DocStyles.AddH1(doc, "11", "ALGORITHMS AND PROGRAMMING LOGIC");
        DocStyles.AddP(doc, "CareBridge implements five core algorithms governing user authentication, clinical specialization matching, electronic prescription assembly, laboratory workflow progression, and pharmacy bill calculation.");

        DocStyles.AddH2(doc, "11.1", "Authentication & Role-Based Redirection Algorithm");
        DocStyles.AddP(doc, "The authentication algorithm establishes a centralized, single-table credentials verification gateway. The logic is defined as follows:");
        DocStyles.AddBullet(doc, "Step 1", "Sanitize user input by trimming whitespace from txtUsername and txtPassword.");
        DocStyles.AddBullet(doc, "Step 2", "Execute a parameterized SQL query: SELECT * FROM tbl_Login WHERE Username = @Username AND Password = @Password using Dapper.");
        DocStyles.AddBullet(doc, "Step 3", "If no matching record is found, populate lblMessage with 'Invalid username or password' and terminate.");
        DocStyles.AddBullet(doc, "Step 4", "If a matching record exists, extract LoginID and Role; assign them to Session[\"LoginID\"] and Session[\"Role\"].");
        DocStyles.AddBullet(doc, "Step 5", "Execute a switch-case evaluation on user.Role, issuing an HTTP 302 redirect to the designated dashboard (Patient -> /Patient/Dashboard.aspx; Hospital -> /Admin/Dashboard.aspx; Doctor -> /Doctor/Dashboard.aspx; Lab -> /Lab/Dashboard.aspx; MedicalStore -> /MedicalStore/Dashboard.aspx).");

        DocStyles.AddH2(doc, "11.2", "Symptom-to-Specialization Matching Algorithm");
        DocStyles.AddP(doc, "A critical distinguishing feature of CareBridge is its transparent, explainable symptom-based doctor suggestion mechanism. The system does not attempt clinical diagnosis; instead, it deterministically suggests the most relevant medical specialization to guide the patient to an appropriate first consultation.");

        DocStyles.AddCallout(doc, "STATUTORY DISCLAIMER ON ALGORITHMIC TRANSPARENCY", 
            "The CareBridge doctor suggestion algorithm is a deterministic, rule-based majority-voting frequency count method operating across a relational mapping table. It is strictly NOT artificial intelligence (AI), machine learning, or a neural network. It executes transparent, inspectable SQL aggregation logic that hospital medical staff can audit, calibrate, and tune directly within the database without altering source code.", false);

        DocStyles.AddP(doc, "Mathematical Formulation: Let S = {s1, s2, ..., sn} be the non-empty set of symptoms selected by the patient from the checklist. Let M = {(s, k) : s in Symptoms, k in Specializations} be the set of mapping records defined in tbl_SymptomMapping, where each row maps a symptom string s to a specialization identifier k. For every medical specialization k in K, the voting weight V(k) is defined as the cardinality of mapping rows matching the patient's selected symptoms:");
        DocStyles.AddP(doc, "V(k) = | { m in tbl_SymptomMapping : m.Symptom in S and m.SpecializationID = k } |");
        DocStyles.AddP(doc, "The recommended specialization k* is selected as the argument that maximizes the voting weight across all candidate specializations:");
        DocStyles.AddP(doc, "k* = argmax_{k in K} V(k)");

        DocStyles.AddP(doc, "Implementation Logic in Enter_Symptoms.aspx.cs:");
        DocStyles.AddCode(doc, @"// Symptom Matching Implementation via Dapper
var specId = conn.QueryFirstOrDefault<int?>(
    @""SELECT TOP 1 SpecializationID FROM tbl_SymptomMapping
      WHERE Symptom IN @Symptoms
      GROUP BY SpecializationID
      ORDER BY COUNT(*) DESC"",
    new { Symptoms = selectedValues });

if (specId == null) {
    specId = conn.QueryFirstOrDefault<int?>(
        ""SELECT SpecializationID FROM tbl_Specialization WHERE Name = 'General Physician'"");
}

string symptomText = string.Join("", "", selected);
string encoded = HttpUtility.UrlEncode(symptomText);
Response.Redirect(""~/Patient/Hospital_Suggestions.aspx?spec="" + specId + ""&symptoms="" + encoded);");

        DocStyles.AddP(doc, "Tie Handling and Fallback Behavior: If no selected symptoms match any entry in tbl_SymptomMapping (e.g., unrecognized complaint), specId evaluates to null, triggering an automatic fallback lookup that retrieves the SpecializationID for 'General Physician' as the safest initial contact.");
        DocStyles.AddP(doc, "In scenarios where two or more specializations tie for the highest vote count (e.g., patient selects 'Fever' [General Physician: 1] and 'Chest pain' [Cardiologist: 1]), the query SELECT TOP 1 returns whichever group SQL Server encounters first in its internal scanning order. This behavior is documented in empirical results (Section 5.6.4 of the project report), and deterministic tie-breaking (e.g. prioritizing acute complaints or General Physician) is slated for future releases.");

        DocStyles.AddH2(doc, "11.3", "Multi-Medicine Electronic Prescription Assembly Logic");
        DocStyles.AddP(doc, "In WritePrescription.aspx.cs, doctors construct prescriptions containing an arbitrary number of medicines without premature database writes. The algorithm proceeds as follows:");
        DocStyles.AddBullet(doc, "State Staging", "Medicines are represented by a serializable data contract: [Serializable] public class MedItem { string MedicineName, Dosage, Quantity, Instructions; }. The active collection is stored in ViewState[\"Medicines\"].");
        DocStyles.AddBullet(doc, "Iterative Line Addition", "Clicking btnAddMedicine appends a new MedItem to ViewState and re-binds Repeater rptMedicines, clearing the input textboxes.");
        DocStyles.AddBullet(doc, "Transactional Commitment", "Clicking btnFinish validates that ViewState[\"Medicines\"].Count > 0. It queries PatientID from tbl_Appointment and DoctorID from tbl_Doctor. It executes an INSERT into tbl_Prescription using OUTPUT INSERTED.PrescriptionID to obtain the auto-generated identity.");
        DocStyles.AddBullet(doc, "Child Line Insertion", "Iterates over the MedItem list, executing parameterized INSERT statements into tbl_PrescriptionItem referencing the parent PrescriptionID.");
        DocStyles.AddBullet(doc, "Appointment Completion", "Executes UPDATE tbl_Appointment SET Status = 'Completed' WHERE AppointmentID = @Id, ensuring that prescribing marks consultation completion.");

        DocStyles.AddH2(doc, "11.4", "Laboratory Diagnostic Request & Report Upload Workflow");
        DocStyles.AddP(doc, "The laboratory lifecycle enforces a three-state transition (Pending -> In Progress -> Completed):");
        DocStyles.AddBullet(doc, "Ordering", "Doctor selects a laboratory from ddlLab and inputs txtTestName. An INSERT into tbl_LabTestRequest creates a record with Status='Pending', linking AppointmentID, PatientID, DoctorID, and LabID.");
        DocStyles.AddBullet(doc, "Commencement", "Laboratory technician inspects Pending_Tests.aspx and clicks 'Start', executing UPDATE tbl_LabTestRequest SET Status = 'In Progress'.");
        DocStyles.AddBullet(doc, "Fulfillment & Upload", "On Upload_Report.aspx, technician selects a PDF file. The code-behind generates fileName = requestId + \"_\" + Path.GetFileName(fileUpload.FileName), saves the file to Server.MapPath(\"~/UploadedReports/\"), inserts a record into tbl_LabReport storing the relative path, and updates the request Status to 'Completed'.");

        DocStyles.AddH2(doc, "11.5", "Medical Store Queue Filtration & Bill Generation Logic");
        DocStyles.AddP(doc, "The pharmacy billing engine links dispensing directly to consulting prescriptions:");
        DocStyles.AddBullet(doc, "Queue Filtration", "Prescription_Queue.aspx queries tbl_Prescription using a NOT EXISTS subquery against tbl_Bill, isolating prescriptions awaiting payment.");
        DocStyles.AddBullet(doc, "Line Pricing", "BillPrescription.aspx loads items from tbl_PrescriptionItem into a Repeater with txtPrice input boxes. The pharmacist enters the line price for each medicine.");
        DocStyles.AddBullet(doc, "Billing Accumulation", "The code-behind iterates over RepeaterItem, parsing txtPrice and accumulating line amounts: total += price. It inserts a record into tbl_Bill capturing TotalAmount and retrieving BillID via OUTPUT INSERTED.BillID, then inserts child lines into tbl_BillItem.");
        DocStyles.AddBullet(doc, "Print Redirection", "Redirects to PrintBill.aspx?billId=..., formatting an itemised receipt displaying patient name, date, drug lines, line prices, and grand total.");
    }
}
