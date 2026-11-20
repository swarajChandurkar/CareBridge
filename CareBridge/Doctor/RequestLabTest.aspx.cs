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
    public partial class RequestLabTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadLabs();
        }

        private void LoadLabs()
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                var labs = conn.Query<LabRow>("SELECT LabID, Name FROM tbl_Lab");
                ddlLab.DataSource = labs;
                ddlLab.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtTestName.Text.Trim() == "")
            {
                lblMessage.CssClass = "text-danger d-block mb-3";
                lblMessage.Text = "Enter a test name.";
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

                conn.Execute(
                    @"INSERT INTO tbl_LabTestRequest (AppointmentID, PatientID, DoctorID, LabID, TestName, Status)
                      VALUES (@AppointmentID, @PatientID, @DoctorID, @LabID, @TestName, 'Pending')",
                    new
                    {
                        AppointmentID = appointmentId,
                        PatientID = appt.PatientID,
                        DoctorID = doctor.DoctorID,
                        LabID = ddlLab.SelectedValue,
                        TestName = txtTestName.Text.Trim()
                    });
            }

            lblMessage.Text = "Lab test requested successfully.";
        }
    }
    public class LabRow
    {
        public int LabID { get; set; }
        public string Name { get; set; }

    }
}