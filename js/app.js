/**
 * CareBridge - Frontend Application Engine & Interactive State Manager
 * Synchronizes Patient, Doctor, Hospital Admin, Lab, and Medical Store workflows in real time.
 */

(function () {
    // 1. Core Data Structures & Master Dictionaries
    const SPECIALIZATIONS = {
        1: { id: 1, name: "General Physician" },
        2: { id: 2, name: "Cardiologist" },
        3: { id: 3, name: "Dermatologist" },
        4: { id: 4, name: "Orthopedic" },
        5: { id: 5, name: "ENT Specialist" },
        6: { id: 6, name: "Neurologist" },
        7: { id: 7, name: "Gastroenterologist" },
        8: { id: 8, name: "Pulmonologist" },
        9: { id: 9, name: "Ophthalmologist" },
        10: { id: 10, name: "Dentist" },
        11: { id: 11, name: "Psychiatrist" },
        12: { id: 12, name: "Urologist" },
        13: { id: 13, name: "Gynecologist" }
    };

    const DOCTORS = [
        { id: 1, name: "Dr. Ravi Sharma", specId: 1, specName: "General Physician", hospital: "City General Hospital", contact: "9811111111", email: "ravi.sharma@carebridge.com", days: "Mon-Sat", time: "9:00 AM - 5:00 PM" },
        { id: 2, name: "Dr. Anjali Mehta", specId: 2, specName: "Cardiologist", hospital: "City General Hospital", contact: "9811111112", email: "anjali.mehta@carebridge.com", days: "Mon-Fri", time: "10:00 AM - 4:00 PM" },
        { id: 3, name: "Dr. Sameer Kapoor", specId: 3, specName: "Dermatologist", hospital: "City General Hospital", contact: "9811111113", email: "sameer.kapoor@carebridge.com", days: "Tue-Sat", time: "11:00 AM - 3:00 PM" },
        { id: 4, name: "Dr. Priya Nair", specId: 4, specName: "Orthopedic", hospital: "City General Hospital", contact: "9811111114", email: "priya.nair@carebridge.com", days: "Mon-Sat", time: "9:00 AM - 1:00 PM" },
        { id: 5, name: "Dr. Karthik Iyer", specId: 5, specName: "ENT Specialist", hospital: "City General Hospital", contact: "9811111115", email: "karthik.iyer@carebridge.com", days: "Mon-Fri", time: "10:00 AM - 2:00 PM" },
        { id: 6, name: "Dr. Neha Verma", specId: 6, specName: "Neurologist", hospital: "City General Hospital", contact: "9811111116", email: "neha.verma@carebridge.com", days: "Mon-Thu", time: "9:00 AM - 12:00 PM" },
        { id: 7, name: "Dr. Suresh Rao", specId: 7, specName: "Gastroenterologist", hospital: "City General Hospital", contact: "9811111117", email: "suresh.rao@carebridge.com", days: "Tue-Sat", time: "10:00 AM - 4:00 PM" },
        { id: 8, name: "Dr. Rohit Gupta", specId: 8, specName: "Pulmonologist", hospital: "City General Hospital", contact: "9811111118", email: "rohit.gupta@carebridge.com", days: "Mon-Fri", time: "9:00 AM - 1:00 PM" },
        { id: 9, name: "Dr. Kavita Desai", specId: 9, specName: "Ophthalmologist", hospital: "City General Hospital", contact: "9811111119", email: "kavita.desai@carebridge.com", days: "Mon-Sat", time: "11:00 AM - 5:00 PM" },
        { id: 10, name: "Dr. Amit Joshi", specId: 10, specName: "Dentist", hospital: "City General Hospital", contact: "9811111120", email: "amit.joshi@carebridge.com", days: "Mon-Sat", time: "10:00 AM - 6:00 PM" },
        { id: 11, name: "Dr. Pooja Reddy", specId: 11, specName: "Psychiatrist", hospital: "City General Hospital", contact: "9811111121", email: "pooja.reddy@carebridge.com", days: "Mon-Fri", time: "2:00 PM - 6:00 PM" },
        { id: 12, name: "Dr. Vikram Singh", specId: 12, specName: "Urologist", hospital: "City General Hospital", contact: "9811111122", email: "vikram.singh@carebridge.com", days: "Tue-Sat", time: "11:00 AM - 3:00 PM" },
        { id: 13, name: "Dr. Deepa Pillai", specId: 13, specName: "Gynecologist", hospital: "City General Hospital", contact: "9811111123", email: "deepa.pillai@carebridge.com", days: "Mon-Fri", time: "9:00 AM - 1:00 PM" }
    ];

    const SYMPTOM_MAP = {
        "fever": 1, "cold": 1, "cough": 1, "fatigue": 1, "body ache": 1,
        "chest pain": 2, "palpitations": 2, "breathlessness": 2,
        "rash": 3, "itching": 3, "acne": 3, "hair fall": 3,
        "joint pain": 4, "back pain": 4, "muscle pain": 4, "fracture": 4,
        "ear pain": 5, "sore throat": 5, "sinus": 5, "hearing loss": 5,
        "headache": 6, "migraine": 6, "dizziness": 6, "numbness": 6,
        "stomach pain": 7, "acidity": 7, "vomiting": 7, "diarrhea": 7,
        "wheezing": 8, "chronic cough": 8,
        "eye pain": 9, "blurred vision": 9, "red eyes": 9,
        "tooth pain": 10, "gum bleeding": 10,
        "anxiety": 11, "insomnia": 11,
        "frequent urination": 12, "urinary pain": 12, "excessive thirst": 12,
        "irregular periods": 13, "pelvic pain": 13
    };

    // 2. Storage Initialization
    function initStore() {
        if (!localStorage.getItem("cb_initialized")) {
            const initialAppointments = [
                { id: 101, patientName: "Roshan Budh", doctorId: 1, doctorName: "Dr. Ravi Sharma", date: "2026-11-20", time: "10:30 AM", symptoms: "Fever, Cold, Cough", status: "Confirmed" },
                { id: 102, patientName: "Swaraj Chandurkar", doctorId: 2, doctorName: "Dr. Anjali Mehta", date: "2026-11-20", time: "11:15 AM", symptoms: "Fever, Chest pain", status: "Pending" }
            ];

            const initialPrescriptions = [
                {
                    id: 201, appointmentId: 101, patientName: "Roshan Budh", doctorName: "Dr. Ravi Sharma", date: "2026-11-20",
                    items: [
                        { name: "Paracetamol 500mg", dosage: "1-0-1", qty: 10, instructions: "After food" },
                        { name: "Cetirizine 10mg", dosage: "0-0-1", qty: 5, instructions: "At bedtime" }
                    ],
                    billed: false
                }
            ];

            const initialLabRequests = [
                { id: 301, appointmentId: 102, patientName: "Swaraj Chandurkar", doctorName: "Dr. Anjali Mehta", testName: "ECG & Lipid Profile", status: "Pending", reportUrl: null, date: "2026-11-20" }
            ];

            const initialBills = [];

            localStorage.setItem("cb_appointments", JSON.stringify(initialAppointments));
            localStorage.setItem("cb_prescriptions", JSON.stringify(initialPrescriptions));
            localStorage.setItem("cb_lab_requests", JSON.stringify(initialLabRequests));
            localStorage.setItem("cb_bills", JSON.stringify(initialBills));
            localStorage.setItem("cb_initialized", "true");
        }
    }

    initStore();

    window.CareBridge = {
        getSpecializations: () => SPECIALIZATIONS,
        getDoctors: () => DOCTORS,
        getSymptomMap: () => SYMPTOM_MAP,

        // Deterministic Majority-Voting Algorithm
        recommendSpecialization: function (selectedSymptoms) {
            if (!selectedSymptoms || selectedSymptoms.length === 0) {
                return SPECIALIZATIONS[1]; // General Physician fallback
            }

            const voteCounts = {};
            selectedSymptoms.forEach(s => {
                const specId = SYMPTOM_MAP[s.toLowerCase().trim()];
                if (specId) {
                    voteCounts[specId] = (voteCounts[specId] || 0) + 1;
                }
            });

            let topSpecId = 1;
            let maxVotes = 0;

            for (const [specId, count] of Object.entries(voteCounts)) {
                if (count > maxVotes) {
                    maxVotes = count;
                    topSpecId = parseInt(specId);
                }
            }

            return SPECIALIZATIONS[topSpecId] || SPECIALIZATIONS[1];
        },

        // Data Access Helpers
        getAppointments: () => JSON.parse(localStorage.getItem("cb_appointments") || "[]"),
        saveAppointments: (data) => localStorage.setItem("cb_appointments", JSON.stringify(data)),

        getPrescriptions: () => JSON.parse(localStorage.getItem("cb_prescriptions") || "[]"),
        savePrescriptions: (data) => localStorage.setItem("cb_prescriptions", JSON.stringify(data)),

        getLabRequests: () => JSON.parse(localStorage.getItem("cb_lab_requests") || "[]"),
        saveLabRequests: (data) => localStorage.setItem("cb_lab_requests", JSON.stringify(data)),

        getBills: () => JSON.parse(localStorage.getItem("cb_bills") || "[]"),
        saveBills: (data) => localStorage.setItem("cb_bills", JSON.stringify(data)),

        // Business Actions
        addAppointment: function (patientName, doctorId, date, time, symptoms) {
            const list = this.getAppointments();
            const doc = DOCTORS.find(d => d.id == doctorId) || DOCTORS[0];
            const newAppt = {
                id: Date.now() % 100000,
                patientName: patientName || "Guest Patient",
                doctorId: doc.id,
                doctorName: doc.name,
                date: date,
                time: time,
                symptoms: symptoms,
                status: "Pending"
            };
            list.unshift(newAppt);
            this.saveAppointments(list);
            return newAppt;
        },

        confirmAppointment: function (id) {
            const list = this.getAppointments();
            const item = list.find(a => a.id == id);
            if (item) {
                item.status = "Confirmed";
                this.saveAppointments(list);
            }
        },

        addPrescription: function (appointmentId, items) {
            const appts = this.getAppointments();
            const appt = appts.find(a => a.id == appointmentId);
            if (!appt) return null;

            appt.status = "Completed";
            this.saveAppointments(appts);

            const rxList = this.getPrescriptions();
            const newRx = {
                id: Date.now() % 100000,
                appointmentId: appt.id,
                patientName: appt.patientName,
                doctorName: appt.doctorName,
                date: new Date().toISOString().split("T")[0],
                items: items,
                billed: false
            };
            rxList.unshift(newRx);
            this.savePrescriptions(rxList);
            return newRx;
        },

        addLabRequest: function (appointmentId, testName) {
            const appts = this.getAppointments();
            const appt = appts.find(a => a.id == appointmentId);
            if (!appt) return null;

            const list = this.getLabRequests();
            const newReq = {
                id: Date.now() % 100000,
                appointmentId: appt.id,
                patientName: appt.patientName,
                doctorName: appt.doctorName,
                testName: testName || "Routine Blood Work",
                status: "Pending",
                reportUrl: null,
                date: new Date().toISOString().split("T")[0]
            };
            list.unshift(newReq);
            this.saveLabRequests(list);
            return newReq;
        },

        startLabTest: function (id) {
            const list = this.getLabRequests();
            const item = list.find(r => r.id == id);
            if (item) {
                item.status = "In Progress";
                this.saveLabRequests(list);
            }
        },

        uploadLabReport: function (id, fileName) {
            const list = this.getLabRequests();
            const item = list.find(r => r.id == id);
            if (item) {
                item.status = "Completed";
                item.reportUrl = fileName || "Lab_Report_" + id + ".pdf";
                this.saveLabRequests(list);
            }
        },

        billPrescription: function (rxId, itemPrices) {
            const rxList = this.getPrescriptions();
            const rx = rxList.find(r => r.id == rxId);
            if (!rx) return null;

            rx.billed = true;
            this.savePrescriptions(rxList);

            let total = 0;
            const billItems = rx.items.map((item, idx) => {
                const price = parseFloat(itemPrices[idx]) || 15.0;
                total += price;
                return { name: item.name, qty: item.qty, price: price };
            });

            const bills = this.getBills();
            const newBill = {
                id: Date.now() % 100000,
                prescriptionId: rx.id,
                patientName: rx.patientName,
                doctorName: rx.doctorName,
                date: new Date().toISOString().split("T")[0],
                items: billItems,
                totalAmount: total.toFixed(2)
            };
            bills.unshift(newBill);
            this.saveBills(bills);
            return newBill;
        },

        resetDemoData: function () {
            localStorage.removeItem("cb_initialized");
            initStore();
        }
    };
})();
