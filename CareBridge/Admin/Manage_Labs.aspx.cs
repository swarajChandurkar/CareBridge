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
    public partial class Manage_Labs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadLabs();
        }

        private int GetHospitalId()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);
            using (var c = DBHelper.GetConnection())
            {
                c.Open();
                var hospital = c.QueryFirstOrDefault(
                    "SELECT HospitalID FROM tbl_Hospital WHERE LoginID = @LoginID", new { LoginID = loginId });
                return hospital.HospitalID;
            }
        }

        private void LoadLabs()
        {
            int hospitalId = GetHospitalId();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                var labs = conn.Query<LabRow>(
                    "SELECT LabID, Name, Contact, Address FROM tbl_Lab WHERE HospitalID = @Id",
                            new { Id = hospitalId }).ToList();
                rptLabs.DataSource = labs;
                rptLabs.DataBind();
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
                      VALUES (@Username, @Password, 'Lab')",
                    new { Username = txtUsername.Text.Trim(), Password = txtPassword.Text.Trim() });

                conn.Execute(
                    @"INSERT INTO tbl_Lab (LoginID, HospitalID, Name, Contact, Address)
                      VALUES (@LoginID, @HospitalID, @Name, @Contact, @Address)",
                    new
                    {
                        LoginID = newLoginId,
                        HospitalID = hospitalId,
                        Name = txtName.Text,
                        Contact = txtContact.Text,
                        Address = txtAddress.Text
                    });
            }

            lblMessage.CssClass = "text-success d-block mb-3";
            lblMessage.Text = "Lab added.";
            txtName.Text = ""; txtUsername.Text = ""; txtPassword.Text = ""; txtContact.Text = ""; txtAddress.Text = "";

            LoadLabs();
        }

        protected void rptLabs_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int labId = Convert.ToInt32(e.CommandArgument);
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    conn.Execute("DELETE FROM tbl_Lab WHERE LabID = @Id", new { Id = labId });
                }
                LoadLabs();
            }
        }
    }

    public class LabRow
    {
        public int LabID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }
}