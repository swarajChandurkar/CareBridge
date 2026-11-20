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
    public partial class PatientRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadRecord();
            string appointmentId = Request.QueryString["appointmentId"];

            if (!string.IsNullOrEmpty(appointmentId))
            {
                lnkWritePrescription.NavigateUrl =
                    "~/Doctor/WritePrescription.aspx?appointmentId=" +
                    Server.UrlEncode(appointmentId);

                lnkRequestLabTest.NavigateUrl =
                    "~/Doctor/RequestLabTest.aspx?appointmentId=" +
                    Server.UrlEncode(appointmentId);
            }
        }

        private void LoadRecord()
        {
            int appointmentId = Convert.ToInt32(Request.QueryString["appointmentId"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var visit = conn.QueryFirstOrDefault(
                    @"SELECT p.PatientID, p.Name AS PatientName, a.AppointmentDate, a.Symptoms
                      FROM tbl_Appointment a
                      JOIN tbl_Patient p ON a.PatientID = p.PatientID
                      WHERE a.AppointmentID = @Id",
                    new { Id = appointmentId });

                if (visit == null) return;

                litPatientName.Text = visit.PatientName;
                litPatientInitial.Text = string.IsNullOrEmpty(visit.PatientName) ? "?" : visit.PatientName.Trim().Substring(0, 1).ToUpper();
                litVisitDate.Text = ((DateTime)visit.AppointmentDate).ToString("dd MMM yyyy");
                litSymptoms.Text = visit.Symptoms;

                var history = conn.Query<HistoryRow>(
                     @"SELECT AppointmentDate, Symptoms, Status FROM tbl_Appointment
                      WHERE PatientID = @PatientID ORDER BY AppointmentDate DESC",
                    new { PatientID = visit.PatientID }).ToList();

                rptHistory.DataSource = history;
                rptHistory.DataBind();
            }
        }

    
    }

    public class HistoryRow
    {
        public DateTime AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public string Status { get; set; }

        public string BadgeClass
        {
            get
            {
                switch (Status)
                {
                    case "Pending":
                        return "cb-badge cb-badge-pending";

                    case "Confirmed":
                        return "cb-badge cb-badge-confirmed";

                    case "Completed":
                        return "cb-badge cb-badge-completed";

                    default:
                        return "cb-badge cb-badge-pending";
                }
            }
        }
    }
}