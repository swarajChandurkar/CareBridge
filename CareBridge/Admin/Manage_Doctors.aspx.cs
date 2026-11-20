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
    public partial class Manage_Doctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadDoctors();
        }

        private int GetHospitalId(Dapper.SqlMapper.IDynamicParameters conn = null)
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);
            using (var c = DBHelper.GetConnection())
            {
                c.Open();
                var hospital = c.QueryFirstOrDefault(
                    "SELECT HospitalID FROM tbl_Hospital WHERE LoginID = @LoginID",
                    new { LoginID = loginId });
                return hospital.HospitalID;
            }
        }

        private void LoadDoctors()
        {
            int hospitalId = GetHospitalId();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                var doctors = conn.Query<DoctorRow>(
                    "SELECT DoctorID, Name, Specialization, Contact FROM tbl_Doctor WHERE HospitalID = @Id",
                    new { Id = hospitalId }).ToList();

                rptDoctors.DataSource = doctors;
                rptDoctors.DataBind();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                lblMessage.CssClass = "text-danger d-block mb-3";
                lblMessage.Text = "Username and password are required.";
                return;
            }

            int hospitalId = GetHospitalId();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                int exists = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Login WHERE Username = @Username",
                    new { Username = txtUsername.Text.Trim() });

                if (exists > 0)
                {
                    lblMessage.CssClass = "text-danger d-block mb-3";
                    lblMessage.Text = "That username is already taken.";
                    return;
                }

                int newLoginId = conn.ExecuteScalar<int>(
                    @"INSERT INTO tbl_Login (Username, Password, Role)
                      OUTPUT INSERTED.LoginID
                      VALUES (@Username, @Password, 'Doctor')",
                    new { Username = txtUsername.Text.Trim(), Password = txtPassword.Text.Trim() });

                conn.Execute(
                    @"INSERT INTO tbl_Doctor (LoginID, HospitalID, Name, Specialization, Contact, Email)
                      VALUES (@LoginID, @HospitalID, @Name, @Specialization, @Contact, @Email)",
                    new
                    {
                        LoginID = newLoginId,
                        HospitalID = hospitalId,
                        Name = txtName.Text,
                        Specialization = txtSpecialization.Text,
                        Contact = txtContact.Text,
                        Email = txtEmail.Text
                    });
            }

            lblMessage.CssClass = "text-success d-block mb-3";
            lblMessage.Text = "Doctor added.";
            txtName.Text = ""; txtSpecialization.Text = ""; txtUsername.Text = "";
            txtPassword.Text = ""; txtContact.Text = ""; txtEmail.Text = "";

            LoadDoctors();
        }

        protected void rptDoctors_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int doctorId = Convert.ToInt32(e.CommandArgument);
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    conn.Execute("DELETE FROM tbl_Doctor WHERE DoctorID = @Id", new { Id = doctorId });
                }
                LoadDoctors();
            }
        }
    }

    public class DoctorRow
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Contact { get; set; }
    }
}