using System;
using System.Collections.Generic;
using System.Linq;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Patient
{
    public partial class Book_Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctors();

                if (Request.QueryString["doctorId"] != null)
                {
                    ddlDoctor.SelectedValue = Request.QueryString["doctorId"];
                }

                if (!string.IsNullOrEmpty(Request.QueryString["symptoms"]))
                {
                    txtSymptoms.Text = Server.UrlDecode(Request.QueryString["symptoms"]);
                }
            }
        }

        private void LoadDoctors()
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var doctors = conn.Query<DoctorOption>(
                    @"SELECT d.DoctorID, d.Name + ' - ' + d.Specialization AS DisplayName
                      FROM tbl_Doctor d").ToList();

                ddlDoctor.DataSource = doctors;
                ddlDoctor.DataBind();
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            if (ddlDoctor.SelectedValue == "" || txtDate.Text == "" || txtTime.Text == "")
            {
                lblMessage.CssClass = "text-danger d-block mb-3";
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var patient = conn.QueryFirstOrDefault(
                    "SELECT PatientID FROM tbl_Patient WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var doctor = conn.QueryFirstOrDefault(
                    "SELECT HospitalID FROM tbl_Doctor WHERE DoctorID = @DoctorID",
                    new { DoctorID = ddlDoctor.SelectedValue });

                conn.Execute(
                    @"INSERT INTO tbl_Appointment (PatientID, DoctorID, HospitalID, AppointmentDate, AppointmentTime, Symptoms, Status)
                      VALUES (@PatientID, @DoctorID, @HospitalID, @AppointmentDate, @AppointmentTime, @Symptoms, 'Pending')",
                    new
                    {
                        PatientID = patient.PatientID,
                        DoctorID = ddlDoctor.SelectedValue,
                        HospitalID = doctor.HospitalID,
                        AppointmentDate = txtDate.Text,
                        AppointmentTime = txtTime.Text,
                        Symptoms = txtSymptoms.Text
                    });

                lblMessage.CssClass = "text-success d-block mb-3";
                lblMessage.Text = "Appointment booked. You'll see it in your appointment history.";
            }
        }

        public class DoctorOption
        {
            public int DoctorID { get; set; }
            public string DisplayName { get; set; }
        }
    }
}