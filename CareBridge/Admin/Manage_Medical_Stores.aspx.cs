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
    public partial class Manage_Medical_Stores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadStores();
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

        private void LoadStores()
        {
            int hospitalId = GetHospitalId();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                var stores = conn.Query<StoresRow>(
                            "SELECT StoreID, Name, Contact, Address FROM tbl_MedicalStore WHERE HospitalID = @Id",
                            new { Id = hospitalId }).ToList();

                rptStores.DataSource = stores;
                rptStores.DataBind();
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
                      VALUES (@Username, @Password, 'MedicalStore')",
                    new { Username = txtUsername.Text.Trim(), Password = txtPassword.Text.Trim() });

                conn.Execute(
                    @"INSERT INTO tbl_MedicalStore (LoginID, HospitalID, Name, Contact, Address)
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
            lblMessage.Text = "Medical store added.";
            txtName.Text = ""; txtUsername.Text = ""; txtPassword.Text = ""; txtContact.Text = ""; txtAddress.Text = "";

            LoadStores();
        }

        protected void rptStores_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int storeId = Convert.ToInt32(e.CommandArgument);
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    conn.Execute("DELETE FROM tbl_MedicalStore WHERE StoreID = @Id", new { Id = storeId });
                }
                LoadStores();
            }
        }
    }

    public class StoresRow
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }


}