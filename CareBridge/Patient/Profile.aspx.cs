using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Patient
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadProfile();
        }

        private void LoadProfile()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var patient = conn.QueryFirstOrDefault(
                    "SELECT Name, Contact, Email, Address, DOB, Gender FROM tbl_Patient WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                if (patient == null) return;

                txtName.Text = patient.Name;
                txtContact.Text = patient.Contact;
                txtEmail.Text = patient.Email;
                txtAddress.Text = patient.Address;

                if (patient.DOB != null)
                    txtDob.Text = ((DateTime)patient.DOB).ToString("yyyy-MM-dd");

                if (patient.Gender != null)
                    ddlGender.SelectedValue = patient.Gender;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                DateTime? dob = null;
                if (!string.IsNullOrEmpty(txtDob.Text))
                    dob = Convert.ToDateTime(txtDob.Text);

                conn.Execute(
                    @"UPDATE tbl_Patient SET Name = @Name, Contact = @Contact, Email = @Email,
                      Address = @Address, DOB = @Dob, Gender = @Gender
                      WHERE LoginID = @LoginID",
                    new
                    {
                        Name = txtName.Text,
                        Contact = txtContact.Text,
                        Email = txtEmail.Text,
                        Address = txtAddress.Text,
                        Dob = dob,
                        Gender = ddlGender.SelectedValue,
                        LoginID = loginId
                    });
            }

            lblMessage.Text = "Profile updated.";
        }
    }
}