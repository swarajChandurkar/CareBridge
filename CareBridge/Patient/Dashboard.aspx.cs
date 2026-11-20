using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Patient
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboard();
            }
        }
        private void LoadDashboard()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var patient = conn.QueryFirstOrDefault(
                    "SELECT PatientID, Name FROM tbl_Patient WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                if (patient == null) return;

                litPatientName.Text = patient.Name;
                int patientId = patient.PatientID;

                litUpcoming.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE PatientID = @PatientID AND Status IN ('Pending','Confirmed')",
                    new { PatientID = patientId }).ToString();

                litPrescriptions.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Prescription WHERE PatientID = @PatientID",
                    new { PatientID = patientId }).ToString();

                litReports.Text = conn.ExecuteScalar<int>(
                    @"SELECT COUNT(*) FROM tbl_LabReport lr
                      JOIN tbl_LabTestRequest r ON lr.RequestID = r.RequestID
                      WHERE r.PatientID = @PatientID",
                    new { PatientID = patientId }).ToString();

                litTotalVisits.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE PatientID = @PatientID AND Status = 'Completed'",
                    new { PatientID = patientId }).ToString();
            }
        }
    }
}