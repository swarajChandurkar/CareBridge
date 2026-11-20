using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;


namespace CareBridge.Doctor
{
    public partial class WritePrescription : System.Web.UI.Page
    {
        private List<MedItem> Medicines
        {
            get
            {
                if (ViewState["Medicines"] == null)
                    ViewState["Medicines"] = new List<MedItem>();
                return (List<MedItem>)ViewState["Medicines"];
            }
            set { ViewState["Medicines"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptMedicines.DataSource = Medicines;
                pnlNoMedicines.Visible = Medicines.Count == 0;
            }
        }

        protected void btnAddMedicine_Click(object sender, EventArgs e)
        {
            var list = Medicines;
            list.Add(new MedItem
            {
                MedicineName = txtMedName.Text,
                Dosage = txtDosage.Text,
                Quantity = txtQty.Text,
                Instructions = txtInstructions.Text
            });
            Medicines = list;

            rptMedicines.DataSource = list;
            rptMedicines.DataBind();
            pnlNoMedicines.Visible = false;   // add this line

            txtMedName.Text = ""; txtDosage.Text = ""; txtQty.Text = ""; txtInstructions.Text = "";
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            if (Medicines.Count == 0)
            {
                lblMessage.CssClass = "text-danger d-block mb-3";
                lblMessage.Text = "Add at least one medicine first.";
                return;
            }

            int appointmentId = Convert.ToInt32(Request.QueryString["appointmentId"]);
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var appt = conn.QueryFirstOrDefault(
                    "SELECT PatientID FROM tbl_Appointment WHERE AppointmentID = @Id",
                    new { Id = appointmentId });

                var doctor = conn.QueryFirstOrDefault(
                    "SELECT DoctorID FROM tbl_Doctor WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                int prescriptionId = conn.ExecuteScalar<int>(
                    @"INSERT INTO tbl_Prescription (AppointmentID, PatientID, DoctorID)
                      OUTPUT INSERTED.PrescriptionID
                      VALUES (@AppointmentID, @PatientID, @DoctorID)",
                    new { AppointmentID = appointmentId, PatientID = appt.PatientID, DoctorID = doctor.DoctorID });

                foreach (var med in Medicines)
                {
                    conn.Execute(
                        @"INSERT INTO tbl_PrescriptionItem (PrescriptionID, MedicineName, Dosage, Instructions, Quantity)
                          VALUES (@PrescriptionID, @MedicineName, @Dosage, @Instructions, @Quantity)",
                        new { PrescriptionID = prescriptionId, med.MedicineName, med.Dosage, med.Instructions, Quantity = med.Quantity });
                }

                conn.Execute("UPDATE tbl_Appointment SET Status = 'Completed' WHERE AppointmentID = @Id",
                    new { Id = appointmentId });
            }

            lblMessage.Text = "Prescription saved and sent to the patient.";
            Medicines = new List<MedItem>();
            rptMedicines.DataSource = null;
            rptMedicines.DataBind();
        }
        [Serializable]
        public class MedItem
        {
            public string MedicineName { get; set; }
            public string Dosage { get; set; }
            public string Quantity { get; set; }
            public string Instructions { get; set; }
        }
    }
}