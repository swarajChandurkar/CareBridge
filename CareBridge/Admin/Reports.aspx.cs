using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Admin
{
    public partial class Reports : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadReports();
        }

        private void LoadReports()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var hospital = conn.QueryFirstOrDefault(
                    "SELECT HospitalID FROM tbl_Hospital WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                int hospitalId = hospital.HospitalID;

                litTotalAppointments.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE HospitalID = @Id", new { Id = hospitalId }).ToString();

                litCompletedAppointments.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE HospitalID = @Id AND Status = 'Completed'",
                    new { Id = hospitalId }).ToString();

                litPrescriptions.Text = conn.ExecuteScalar<int>(
                    @"SELECT COUNT(*) FROM tbl_Prescription p
                      JOIN tbl_Appointment a ON p.AppointmentID = a.AppointmentID
                      WHERE a.HospitalID = @Id", new { Id = hospitalId }).ToString();

                litLabTests.Text = conn.ExecuteScalar<int>(
                    @"SELECT COUNT(*) FROM tbl_LabTestRequest r
                      JOIN tbl_Appointment a ON r.AppointmentID = a.AppointmentID
                      WHERE a.HospitalID = @Id", new { Id = hospitalId }).ToString();

                litBills.Text = conn.ExecuteScalar<int>(
                    @"SELECT COUNT(*) FROM tbl_Bill b
                      JOIN tbl_Prescription p ON b.PrescriptionID = p.PrescriptionID
                      JOIN tbl_Appointment a ON p.AppointmentID = a.AppointmentID
                      WHERE a.HospitalID = @Id", new { Id = hospitalId }).ToString();
            }
        }
    }
}