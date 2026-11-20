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
    public partial class Lab_Reports : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadReports();
        }

        private void LoadReports()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var patient = conn.QueryFirstOrDefault(
                    "SELECT PatientID FROM tbl_Patient WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var reports = conn.Query<ReportRow>(
                    @"SELECT r.TestName, l.Name AS LabName, lr.UploadDate, lr.ReportFilePath
                      FROM tbl_LabReport lr
                      JOIN tbl_LabTestRequest r ON lr.RequestID = r.RequestID
                      JOIN tbl_Lab l ON r.LabID = l.LabID
                      WHERE r.PatientID = @PatientID
                      ORDER BY lr.UploadDate DESC",
                    new { PatientID = patient.PatientID }).ToList();

                if (reports.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    rptReports.DataSource = reports;
                    rptReports.DataBind();
                }
            }
        }
    }
    public class ReportRow
    {
        public string TestName { get; set; }
        public string LabName { get; set; }
        public DateTime UploadDate { get; set; }
        public string ReportFilePath { get; set; }
    }
}