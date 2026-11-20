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
    public partial class Dashboard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadStats();
        }

        private void LoadStats()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var hospital = conn.QueryFirstOrDefault(
                    "SELECT HospitalID FROM tbl_Hospital WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                if (hospital == null) return;
                int hospitalId = hospital.HospitalID;

                litDoctors.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Doctor WHERE HospitalID = @Id", new { Id = hospitalId }).ToString();

                litLabs.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Lab WHERE HospitalID = @Id", new { Id = hospitalId }).ToString();

                litStores.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_MedicalStore WHERE HospitalID = @Id", new { Id = hospitalId }).ToString();

                litAppointmentsToday.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Appointment WHERE HospitalID = @Id AND AppointmentDate = CAST(GETDATE() AS DATE)",
                    new { Id = hospitalId }).ToString();
            }
        }
    }
}