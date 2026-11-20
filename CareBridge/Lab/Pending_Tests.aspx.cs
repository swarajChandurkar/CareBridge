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
    public partial class Pending_Tests : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadTests();
        }

        private void LoadTests()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var lab = conn.QueryFirstOrDefault(
                    "SELECT LabID FROM tbl_Lab WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var tests = conn.Query<TestRow>(
                     @"SELECT r.RequestID, p.Name AS PatientName, r.TestName, d.Name AS DoctorName, r.Status
                      FROM tbl_LabTestRequest r
                      JOIN tbl_Patient p ON r.PatientID = p.PatientID
                      JOIN tbl_Doctor d ON r.DoctorID = d.DoctorID
                      WHERE r.LabID = @LabID
                      ORDER BY r.RequestDate DESC",
                    new { LabID = lab.LabID }).ToList();

                if (tests.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    rptTests.DataSource = tests;
                    rptTests.DataBind();
                }
            }
        }

        protected void rptTests_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "StartProgress")
            {
                int requestId = Convert.ToInt32(e.CommandArgument);
                using (var conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    conn.Execute(
                        "UPDATE tbl_LabTestRequest SET Status = 'In Progress' WHERE RequestID = @Id",
                        new { Id = requestId });
                }
                LoadTests();
            }
        }

        protected string GetBadgeClass(string status)
        {
            switch (status)
            {
                case "Pending": return "cb-badge cb-badge-pending";
                case "In Progress": return "cb-badge cb-badge-confirmed";
                case "Completed": return "cb-badge cb-badge-completed";
                default: return "cb-badge cb-badge-pending";
            }
        }
    }

    public class TestRow
    {
        public int RequestID { get; set; }
        public string PatientName { get; set; }
        public string TestName { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }
    }

}