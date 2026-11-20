import os

part1_cs = r'''using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

public static class SectionPart1 {
    public static void BuildCoverPage(Document doc) {
        // Outer decorative border table
        var outerTable = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        outerTable.SetBorder(new SolidBorder(DocStyles.Primary, 2.0f));
        outerTable.SetBackgroundColor(ColorConstants.WHITE);
        outerTable.SetPadding(20);

        var cell = new Cell().SetBorder(Border.NO_BORDER).SetPadding(15);

        // Header Category banner
        var pCat = new Paragraph("GOVERNMENT OF INDIA • COPYRIGHT REGISTRATION DOCUMENTATION\n[FORM XIV • LITERARY WORK: COMPUTER PROGRAMME / COMPUTER SOFTWARE]")
            .SetFont(DocStyles.FontBold)
            .SetFontSize(8.5f)
            .SetFontColor(DocStyles.Secondary)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetMarginBottom(18);
        cell.Add(pCat);

        // Institutional Affiliation
        var pInst = new Paragraph("DEPARTMENT OF COMPUTER SCIENCE & ENGINEERING\nPROF. RAM MEGHE INSTITUTE OF TECHNOLOGY & RESEARCH (PRMIT&R)\n(An Autonomous Institute Affiliated to Sant Gadge Baba Amravati University, Amravati, Maharashtra, India)")
            .SetFont(DocStyles.FontRegular)
            .SetFontSize(8.0f)
            .SetFontColor(DocStyles.TextMuted)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetMarginBottom(25);
        cell.Add(pInst);

        // Main Title Box
        var titleBox = new Table(UnitValue.CreatePercentArray(new float[] { 100 })).UseAllAvailableWidth();
        titleBox.SetBackgroundColor(DocStyles.Primary).SetPadding(16);
        titleBox.SetMarginBottom(20);

        var cellTitle = new Cell().SetBorder(Border.NO_BORDER).SetPadding(10).SetTextAlignment(TextAlignment.CENTER);
        var pMainTitle = new Paragraph("CAREBRIDGE")
            .SetFont(DocStyles.FontBold)
            .SetFontSize(24)
            .SetFontColor(ColorConstants.WHITE)
            .SetMarginBottom(6);
        var pSubTitle = new Paragraph("A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM")
            .SetFont(DocStyles.FontBold)
            .SetFontSize(11.5f)
            .SetFontColor(new DeviceRgb(224, 242, 254))
            .SetMarginBottom(4);
        var pDocType = new Paragraph("COMPUTER SOFTWARE COPYRIGHT TECHNICAL DOCUMENTATION\nTECHNICAL SPECIFICATION & SOURCE CODE ARCHITECTURE")
            .SetFont(DocStyles.FontRegular)
            .SetFontSize(9.0f)
            .SetFontColor(new DeviceRgb(178, 235, 242));
        cellTitle.Add(pMainTitle);
        cellTitle.Add(pSubTitle);
        cellTitle.Add(pDocType);
        titleBox.AddCell(cellTitle);
        cell.Add(titleBox);

        // Statutory Metadata Table
        var metaTable = new Table(UnitValue.CreatePercentArray(new float[] { 35, 65 })).UseAllAvailableWidth();
        metaTable.SetMarginBottom(20);

        Action<string, string> addMeta = (k, v) => {
            var cK = new Cell().Add(new Paragraph(k).SetFont(DocStyles.FontBold).SetFontSize(8.0f).SetFontColor(DocStyles.Secondary))
                .SetBackgroundColor(DocStyles.ZebraBg).SetPadding(4).SetBorder(new SolidBorder(DocStyles.BorderLight, 0.5f));
            var cV = new Cell().Add(new Paragraph(v).SetFont(DocStyles.FontRegular).SetFontSize(8.0f).SetFontColor(DocStyles.TextDark))
                .SetPadding(4).SetBorder(new SolidBorder(DocStyles.BorderLight, 0.5f));
            metaTable.AddCell(cK);
            metaTable.AddCell(cV);
        };

        addMeta("Statutory Work Category", "Computer Software / Computer Programme [Sec 2(o), Copyright Act, 1957]");
        addMeta("Software Name & Identifier", "CareBridge (AssemblyTitle: CareBridge; Guid: 167e8261-78da-40ce-94ee-8ccee7df7e4d)");
        addMeta("Current Release Version", "Version 1.0.0.0 (Target Framework: .NET Framework 4.8)");
        addMeta("Implementation Languages", "C# (Back-End Logic), T-SQL (Database Schemas), HTML5 / CSS3 / JavaScript");
        addMeta("Core Technologies", "ASP.NET Web Forms, Dapper 2.1 Micro-ORM, Microsoft SQL Server");
        addMeta("Date & Year of Creation", "September 2026 / Academic Year 2026–2027 (AssemblyCopyright: © 2026)");
        addMeta("Publication Status", "Unpublished Technical Computer Programme (Confidential Commercial / Academic Submission)");
        addMeta("Primary Target Beneficiary", "Small & Mid-Sized Hospitals, Outpatient Clinics, Diagnostic Centers, Pharmacies");
        addMeta("Competent Authority", "Office of the Registrar of Copyrights, Copyright Office, New Delhi, India");

        cell.Add(metaTable);

        // Applicant & Author Notice Block
        var pAppNotice = new Paragraph("APPLICANT / AUTHOR / OWNERSHIP PLACEHOLDER SPECIFICATION:\nThis technical documentation is submitted in support of an application for Indian Copyright Registration of a Computer Programme. Author and Applicant details, including student project team members, faculty guidance, and institutional ownership deeds, are structured as formal legal placeholders in Part 4 of this document, awaiting final attestation and signing by the designated claimants.")
            .SetFont(DocStyles.FontItalic)
            .SetFontSize(7.5f)
            .SetFontColor(DocStyles.TextMuted)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetMarginBottom(10);
        cell.Add(pAppNotice);

        outerTable.AddCell(cell);
        doc.Add(outerTable);
        doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
    }

    public static void BuildTableOfContents(Document doc) {
        DocStyles.AddH1(doc, "TABLE OF CONTENTS", "TECHNICAL DOCUMENTATION INDEX");
        DocStyles.AddP(doc, "This technical document contains twenty comprehensive sections detailing the computer programme architecture, database structure, algorithmic logic, and source code implementation of the CareBridge Healthcare Management System, followed by statutory Indian Copyright Application Particulars and the Applicant Filing Checklist.");

        var tocList = new List<string[]> {
            new string[] { "Section 1", "Title of the Computer Software", "Official software identity, assembly metadata, versioning, GUID" },
            new string[] { "Section 2", "Software Overview", "Executive technical summary of the CareBridge multi-portal platform" },
            new string[] { "Section 3", "Abstract", "Academic and technical abstract of the complete software system" },
            new string[] { "Section 4", "Purpose of the Software", "Clinical, administrative, and operational objectives" },
            new string[] { "Section 5", "Problem Statement", "Critical limitations of paper-based healthcare coordination in India" },
            new string[] { "Section 6", "Description of the Software", "Architectural model across five primary user roles and shared data tier" },
            new string[] { "Section 7", "Detailed Functionalities", "Exhaustive functional breakdown for Patients, Doctors, Labs, Stores, Admins" },
            new string[] { "Section 8", "Software Architecture", "Three-tier architecture, session state model, Master Page role guards" },
            new string[] { "Section 9", "Technology Stack", "Exhaustive stack: C#, ASP.NET Web Forms, .NET 4.8, Dapper 2.1, SQL Server" },
            new string[] { "Section 10", "Module-wise Technical Description", "In-depth code walkthrough across all 7 functional modules & WhatsApp status" },
            new string[] { "Section 11", "Algorithms and Programming Logic", "Symptom matching rule, prescription assembly, billing accumulation, ties" },
            new string[] { "Section 12", "Database Architecture", "15 interrelated tables, complete Data Dictionary, 25 Foreign Keys, 3NF" },
            new string[] { "Section 13", "Data Flow and System Workflow", "DFD Levels 0/1/2, Appointment & Lab lifecycles, Episode of Care sequence" },
            new string[] { "Section 14", "Software Implementation Details", "DBHelper, parameterised SQL via Dapper, security controls, ViewState" },
            new string[] { "Section 15", "Original Software Components", "Segregation of original authored intellectual property vs open source" },
            new string[] { "Section 16", "Source Code Structure", "File inventory, directory organization, byte sizes, lines of code" },
            new string[] { "Section 17", "Software Requirements", "Server, development, and client runtime hardware/software specifications" },
            new string[] { "Section 18", "Third-Party Dependencies", "Detailed inventory of NuGet packages, versions, and license types" },
            new string[] { "Section 19", "Software Execution and Operation", "Step-by-step setup, database deployment, Web.config, user walkthrough" },
            new string[] { "Section 20", "Conclusion and Technical Roadmap", "Technical accomplishments, transparent limitations, ABDM integration" },
            new string[] { "Part 4", "Indian Copyright Application Particulars", "Form XIV Statement of Particulars & Further Particulars placeholders" },
            new string[] { "Part 5", "Copyright Registration Checklist", "Checklist of mandatory applicant materials, NOCs, source code dump" }
        };

        DocStyles.AddTable(doc, new string[] { "Section", "Title / Content Area", "Technical Scope & Purpose" }, new float[] { 16, 38, 46 }, tocList);
        doc.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
    }

    public static void BuildSections1To5(Document doc) {
        // Section 1
        DocStyles.AddH1(doc, "1", "TITLE OF THE COMPUTER SOFTWARE");
        DocStyles.AddP(doc, "The official registered title of the computer software work submitted for copyright protection under the Indian Copyright Act, 1957 is:");
        DocStyles.AddCallout(doc, "OFFICIAL TITLE OF WORK", "CAREBRIDGE: A UNIFIED WEB-BASED HEALTHCARE MANAGEMENT SYSTEM", false);
        DocStyles.AddP(doc, "In internal source code repositories, deployment packages, and solution manifests, the software is identified by the title 'CareBridge'. The software assembly is identified by the following verifiable metadata attributes recorded in Properties/AssemblyInfo.cs:");
        
        var asmMeta = new List<string[]> {
            new string[] { "Assembly Title", "CareBridge", "Root assembly title attribute [assembly: AssemblyTitle(\"CareBridge\")]" },
            new string[] { "Assembly Product", "CareBridge", "Product identifier [assembly: AssemblyProduct(\"CareBridge\")]" },
            new string[] { "Copyright Notice", "Copyright © 2026", "Authored copyright declaration [assembly: AssemblyCopyright(\"Copyright © 2026\")]" },
            new string[] { "Unique GUID", "167e8261-78da-40ce-94ee-8ccee7df7e4d", "Globally Unique Identifier for COM / Type Library binding" },
            new string[] { "Assembly Version", "1.0.0.0", "Release assembly version [assembly: AssemblyVersion(\"1.0.0.0\")]" },
            new string[] { "Assembly File Version", "1.0.0.0", "File build version [assembly: AssemblyFileVersion(\"1.0.0.0\")]" },
            new string[] { "Target Namespace", "CareBridge", "Root C# code-behind namespace across all portals and web forms" }
        };
        DocStyles.AddTable(doc, new string[] { "Assembly Attribute", "Configured Value", "Technical & Legal Description" }, new float[] { 26, 34, 40 }, asmMeta);

        // Section 2
        DocStyles.AddH1(doc, "2", "SOFTWARE OVERVIEW");
        DocStyles.AddP(doc, "CareBridge is a comprehensive, multi-role web-based healthcare coordination computer programme engineered to digitise and unify the clinical, diagnostic, and administrative workflows of small and mid-sized healthcare institutions. The software interconnects five interdependent operational categories of users within an institutional healthcare delivery network:");
        DocStyles.AddBullet(doc, "Patients", "End-users seeking medical consultation who record symptoms, receive deterministic specialization guidance, schedule appointments, and access digital prescriptions and diagnostic reports.");
        DocStyles.AddBullet(doc, "Hospital Administrators", "Institutional managers who administer facility infrastructure, provision and configure medical staff, laboratory, and pharmacy accounts, and monitor operational analytics.");
        DocStyles.AddBullet(doc, "Doctors", "Consulting clinicians who manage outpatient appointment queues, examine longitudinal patient medical records, formulate structured electronic prescriptions, and place computerized diagnostic test orders.");
        DocStyles.AddBullet(doc, "Diagnostic Laboratories", "Pathology and diagnostic units that ingest computerized test orders, record processing states, and upload validated diagnostic reports.");
        DocStyles.AddBullet(doc, "Medical Stores (Pharmacies)", "Dispensaries that receive authorized electronic prescriptions directly from the consultation room, price pharmaceutical lines, and issue itemised financial bills.");
        DocStyles.AddP(doc, "The foundational architectural premise of CareBridge is the complete elimination of physical paper hand-offs. In conventional care delivery, clinical information is transcribed onto physical paper chits carried by the patient between disconnected desks. CareBridge establishes an end-to-end digital lifecycle on a unified relational database schema, ensuring that every record—from initial booking to dispensary settlement—maintains relational integrity, auditability, and immediate cross-departmental availability.");

        // Section 3
        DocStyles.AddH1(doc, "3", "ABSTRACT");
        DocStyles.AddP(doc, "Patients, doctors, diagnostic laboratories, and medical stores typically operate with fragmented information systems or manual paper records, transferring medical data through handwritten slips carried physically by the patient. This structural disconnect produces frequent department misdirection, lost clinical prescriptions, transcription errors, and delayed diagnostic evaluations. CareBridge is a web-based healthcare coordination computer programme built to integrate these healthcare participants onto a unified, normalized relational database.");
        DocStyles.AddP(doc, "Developed using ASP.NET Web Forms on the Microsoft .NET Framework 4.8 with C# as the server-side language, Microsoft SQL Server as the relational database engine, and the Dapper 2.1 micro-ORM for high-performance parameterized data access, CareBridge delivers five specialized role-based portals. A patient selects symptoms from an expansive checklist, whereupon the system executes a deterministic majority-voting algorithm across a relational symptom-to-specialization mapping table, recommending the most appropriate clinical specialization and listing matching active practitioners for online scheduling. Consulting doctors confirm appointments, review longitudinal patient histories, generate multi-medicine digital prescriptions, and route electronic diagnostic test requests. Attached diagnostic laboratories update processing milestones and upload electronic reports directly accessible within the patient portal. Medical stores ingest unbilled electronic prescriptions, apply unit pricing, and generate itemised bills.");
        DocStyles.AddP(doc, "The database architecture comprises fifteen normalized tables enforcing primary, unique, and foreign key constraints across all transactional entities. Empirical verification conducted against a production-representative dataset of one hospital, thirteen doctors across thirteen distinct specializations, and forty-two symptom mappings confirmed that a complete episode of care executes end-to-end in twenty-five minutes without physical documentation hand-offs, with the symptom matching algorithm yielding expected specializations in 90.5% of test scenarios.");

        // Section 4
        DocStyles.AddH1(doc, "4", "PURPOSE OF THE SOFTWARE");
        DocStyles.AddP(doc, "The primary objective of the CareBridge computer programme is to provide an affordable, maintainable, and unified software platform capable of bridging the information gap across independent healthcare participants in municipal and suburban hospital settings. Specifically, the software achieves the following operational purposes:");
        DocStyles.AddBullet(doc, "Unification of Clinical Information", "Establishing a single source of clinical truth where patient appointments, clinical notes, prescriptions, laboratory requests, test reports, and pharmacy bills are relationally linked to eliminate duplicate manual data entry.");
        DocStyles.AddBullet(doc, "Transparent Specialty Guidance", "Empowering patients to make informed decisions regarding medical departments through an explainable, rule-based symptom matching algorithm, mitigating misdirected initial consultations.");
        DocStyles.AddBullet(doc, "Eradication of Prescription Ambiguity", "Replacing handwritten prescriptions with structured, multi-item digital records storing distinct medicine names, dosages, durations, and clinical instructions to avoid dispensing hazards.");
        DocStyles.AddBullet(doc, "Direct Laboratory Order & Result Pipeline", "Automating the flow of diagnostic investigations from doctor ordering to lab queueing, result uploading, and patient access, eliminating lost paper requisition slips.");
        DocStyles.AddBullet(doc, "Pharmacy Dispensing Synchronization", "Connecting consulting physicians directly to hospital pharmacies so that unbilled prescriptions appear instantaneously in dispensary queues without retyping.");
        DocStyles.AddBullet(doc, "Cost-Effective Institutional Governance", "Enabling small and mid-sized healthcare facilities to deploy an enterprise-grade coordination system without the prohibitive licensing, infrastructure, and administrative overhead of legacy Hospital Information Systems (HIS).");

        // Section 5
        DocStyles.AddH1(doc, "5", "PROBLEM STATEMENT");
        DocStyles.AddP(doc, "Outpatient healthcare administration across small and mid-sized healthcare institutions in India continues to rely overwhelmingly on physical paper hand-offs. The manual workflow presents acute vulnerabilities across five distinct touchpoints:");
        DocStyles.AddBullet(doc, "Department Misdirection & Diagnostic Delay", "Patients suffering from unfamiliar symptom complexes frequently self-refer to inappropriate medical departments or rely on informal advice at reception counters. A patient with neurological vertigo often consults an ENT specialist or general practitioner, incurring redundant fees and delaying definitive treatment.");
        DocStyles.AddBullet(doc, "Handwritten Prescription Hazards", "Handwritten prescriptions are notoriously susceptible to illegibility, leading to dispensing errors at medical stores. Furthermore, patients frequently misplace paper slips, leaving treating clinicians without longitudinal medication histories during subsequent emergencies.");
        DocStyles.AddBullet(doc, "Diagnostic Information Decay", "Diagnostic test requisitions are given to patients on paper slips. Patients must physically carry the slip to a laboratory, wait for specimen collection, and make a separate physical return journey days later to retrieve printed reports before re-queuing to show the doctor.");
        DocStyles.AddBullet(doc, "Dispensary Retyping & Inventory Disconnect", "Medical store pharmacists must manually decipher and re-enter prescribed drug lines into local accounting systems, introducing data transcription errors and billing delays.");
        DocStyles.AddBullet(doc, "Monolithic Software Complexity & Cost", "Existing enterprise Hospital Information Systems (e.g. NIC e-Hospital, OpenMRS, Bahmni) require dedicated Linux server infrastructure, database administrators, and complex multi-module configuration, rendering them unviable for small private healthcare centers in tier-2 and tier-3 Indian cities.");
        DocStyles.AddP(doc, "CareBridge directly resolves these challenges by providing a unified, lightweight, role-guarded web platform deployed on standard Windows IIS environments with SQL Server, linking all five participants through direct digital transactions.");
    }
}
'''

with open("pdf_builder/SectionPart1.cs", "w", encoding="utf-8") as f:
    f.write(part1_cs)

print("SectionPart1.cs written successfully.")
