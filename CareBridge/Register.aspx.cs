using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using CareBridge.App_Code;

namespace CareBridge
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string role = ddlRole.SelectedValue;

            if (string.IsNullOrEmpty(role))
            {
                lblMessage.Text = "Please select a role.";
                return;
            }

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                // check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM tbl_Login WHERE Username = @Username";
                int exists = conn.ExecuteScalar<int>(checkQuery, new { Username = txtUsername.Text.Trim() });

                if (exists > 0)
                {
                    lblMessage.Text = "Username already taken. Choose another.";
                    return;
                }

                // insert into tbl_Login and get new LoginID
                string insertLogin = @"INSERT INTO tbl_Login (Username, Password, Role) 
                                        OUTPUT INSERTED.LoginID
                                        VALUES (@Username, @Password, @Role)";

                int newLoginID = conn.ExecuteScalar<int>(insertLogin, new
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = role
                });

                // insert into the correct profile table based on role
                switch (role)
                {
                    case "Patient":
                        conn.Execute(@"INSERT INTO tbl_Patient (LoginID, Name, Contact, Email, Address) 
                       VALUES (@LoginID, @Name, @Contact, @Email, @Address)",
                            new { LoginID = newLoginID, Name = txtName.Text, Contact = txtContact.Text, Email = txtEmail.Text, Address = txtAddress.Text });
                        break;

                    case "Hospital":
                        conn.Execute(@"INSERT INTO tbl_Hospital (LoginID, Name, Address, Contact, Email) 
                       VALUES (@LoginID, @Name, @Address, @Contact, @Email)",
                            new { LoginID = newLoginID, Name = txtName.Text, Address = txtAddress.Text, Contact = txtContact.Text, Email = txtEmail.Text });
                        break;
                }

                lblMessage.CssClass = "text-success";
                lblMessage.Text = "Registration successful! You can now login.";
            }
        }
    }
}