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
    public partial class SetAvailability : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadCurrent();
        }

        private void LoadCurrent()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                var doctor = conn.QueryFirstOrDefault(
                    "SELECT AvailableDays, AvailableTime FROM tbl_Doctor WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                if (doctor != null)
                {
                    txtDays.Text = doctor.AvailableDays;
                    txtTime.Text = doctor.AvailableTime;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                conn.Execute(
                    "UPDATE tbl_Doctor SET AvailableDays = @Days, AvailableTime = @Time WHERE LoginID = @LoginID",
                    new { Days = txtDays.Text, Time = txtTime.Text, LoginID = loginId });
            }

            lblMessage.Text = "Availability updated.";
        }
    }
}