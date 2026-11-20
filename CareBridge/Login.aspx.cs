using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM tbl_Login WHERE Username = @Username AND Password = @Password";
                var user = conn.QueryFirstOrDefault(query, new { Username = username, Password = password });

                if (user != null)
                {
                    Session["LoginID"] = user.LoginID;
                    Session["Role"] = user.Role;

                    switch (user.Role.ToString())
                    {
                        case "Patient":
                            Response.Redirect("~/Patient/Dashboard.aspx");
                            break;
                        case "Hospital":
                            Response.Redirect("~/Admin/Dashboard.aspx");
                            break;
                        case "Doctor":
                            Response.Redirect("~/Doctor/Dashboard.aspx");
                            break;
                        case "Lab":
                            Response.Redirect("~/Lab/Dashboard.aspx");
                            break;
                        case "MedicalStore":
                            Response.Redirect("~/MedicalStore/Dashboard.aspx");
                            break;
                        default:
                            lblMessage.Text = "Unknown role. Contact admin.";
                            break;
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
        }
    }
}