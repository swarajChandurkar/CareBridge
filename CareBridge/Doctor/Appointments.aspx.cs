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
    public partial class Appointments : System.Web.UI.Page
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
                var doctor = conn.QueryFirstOrDefault(
                    "SELECT DoctorID FROM tbl_Doctor WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var appointments = conn.Query<AppointmentRow>(
                    @"SELECT a.AppointmentID, p.Name AS PatientName, a.AppointmentDate, 
                             a.AppointmentTime, a.Symptoms, a.Status
                      FROM tbl_Appointment a
                      JOIN tbl_Patient p ON a.PatientID = p.PatientID
                      WHERE a.DoctorID = @DoctorID
                      ORDER BY a.AppointmentDate DESC",
                    new { DoctorID = doctor.DoctorID }).ToList();

                if (appointments.Count == 0)
                {
                    pnlEmpty.Visible = true;
                }
                else
                {
                    rptAppointments.DataSource = appointments;
                    rptAppointments.DataBind();
                }
            }
        }
       
        protected void rptAppointments_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Confirm")
            {
                int appointmentId = Convert.ToInt32(e.CommandArgument);
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    conn.Execute(
                        "UPDATE tbl_Appointment SET Status = 'Confirmed' WHERE AppointmentID = @Id",
                        new { Id = appointmentId });
                }
                LoadAppointments();
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
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Symptoms { get; set; }
        public string Status { get; set; }

        public string PatientInitial
        {
            get
            {
                if (string.IsNullOrEmpty(PatientName))
                    return "?";

                string name = PatientName.Trim();

                if (name.Length == 0)
                    return "?";

                return name.Substring(0, 1).ToUpper();
            }
        }
    }
}