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
    public partial class View_Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadAppointments();
        }

        private void LoadAppointments()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var hospital = conn.QueryFirstOrDefault(
                    "SELECT HospitalID FROM tbl_Hospital WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var appointments = conn.Query<AppointmentRow>(
                    @"SELECT p.Name AS PatientName, d.Name AS DoctorName, a.AppointmentDate, a.AppointmentTime, a.Status
                      FROM tbl_Appointment a
                      JOIN tbl_Patient p ON a.PatientID = p.PatientID
                      JOIN tbl_Doctor d ON a.DoctorID = d.DoctorID
                      WHERE a.HospitalID = @HospitalID
                      ORDER BY a.AppointmentDate DESC",
                    new { HospitalID = hospital.HospitalID }).ToList();

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
    }
    public class AppointmentRow
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Status { get; set; }
    }
}