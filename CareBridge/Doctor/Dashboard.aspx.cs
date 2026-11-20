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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadDashboard();
        }

        private void LoadDashboard()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var doctor = conn.QueryFirstOrDefault(
                    "SELECT DoctorID, Name FROM tbl_Doctor WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                if (doctor == null) return;

                litDoctorName.Text = doctor.Name;
                int doctorId = doctor.DoctorID;

                litToday.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE DoctorID = @DoctorID AND AppointmentDate = CAST(GETDATE() AS DATE)",
                    new { DoctorID = doctorId }).ToString();

                litPending.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE DoctorID = @DoctorID AND Status = 'Pending'",
                    new { DoctorID = doctorId }).ToString();

                litCompleted.Text = conn.ExecuteScalar<int>(
                    @"SELECT COUNT(*) FROM tbl_Appointment 
                      WHERE DoctorID = @DoctorID AND Status = 'Completed' 
                      AND MONTH(AppointmentDate) = MONTH(GETDATE())",
                    new { DoctorID = doctorId }).ToString();
            }
        }
    }
}