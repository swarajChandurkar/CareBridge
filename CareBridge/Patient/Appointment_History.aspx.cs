using System;
using System.Collections.Generic;
using System.Linq;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Patient
{
    public partial class Appointment_History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var patient = conn.QueryFirstOrDefault(
                    "SELECT PatientID FROM tbl_Patient WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var appointments = conn.Query<AppointmentRow>(
                    @"SELECT a.AppointmentID, d.Name AS DoctorName, h.Name AS HospitalName,
                             a.AppointmentDate, a.AppointmentTime, a.Symptoms, a.Status
                      FROM tbl_Appointment a
                      JOIN tbl_Doctor d ON a.DoctorID = d.DoctorID
                      JOIN tbl_Hospital h ON a.HospitalID = h.HospitalID
                      WHERE a.PatientID = @PatientID
                      ORDER BY a.AppointmentDate DESC",
                    new { PatientID = patient.PatientID }).ToList();

                if (appointments.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    rptAppointments.DataSource = appointments;
                    rptAppointments.DataBind();
                }
            }
        }

        protected string GetBadgeClass(string status)
        {
            switch (status)
            {
                case "Pending": return "cb-badge cb-badge-pending";
                case "Confirmed": return "cb-badge cb-badge-confirmed";
                case "Completed": return "cb-badge cb-badge-completed";
                default: return "cb-badge cb-badge-pending";
            }
        }

        public class AppointmentRow
        {
            public int AppointmentID { get; set; }
            public string DoctorName { get; set; }
            public string HospitalName { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string AppointmentTime { get; set; }
            public string Symptoms { get; set; }
            public string Status { get; set; }
        }
    }
}