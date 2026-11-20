using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;
namespace CareBridge.Lab
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

                var lab = conn.QueryFirstOrDefault(
                    "SELECT LabID FROM tbl_Lab WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                if (lab == null) return;

                litPending.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_LabTestRequest WHERE LabID = @LabID AND Status = 'Pending'",
                    new { LabID = lab.LabID }).ToString();

                litInProgress.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_LabTestRequest WHERE LabID = @LabID AND Status = 'In Progress'",
                    new { LabID = lab.LabID }).ToString();

                litCompleted.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_LabTestRequest WHERE LabID = @LabID AND Status = 'Completed'",
                    new { LabID = lab.LabID }).ToString();
            }
        }
    }
}