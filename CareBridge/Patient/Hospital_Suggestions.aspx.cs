using System;
using System.Collections.Generic;
using System.Linq;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Patient
{
    public partial class Hospital_Suggestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctors();
            }
        }

        private void LoadDoctors()
        {
            int specId = Convert.ToInt32(Request.QueryString["spec"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var doctors = conn.Query<DoctorSuggestion>(
                    @"SELECT d.DoctorID, d.Name AS DoctorName, sp.Name AS Specialization,
                             h.Name AS HospitalName, d.AvailableDays, d.AvailableTime
                      FROM tbl_Doctor d
                      JOIN tbl_Specialization sp ON LTRIM(RTRIM(d.Specialization)) = LTRIM(RTRIM(sp.Name))
                      JOIN tbl_Hospital h ON d.HospitalID = h.HospitalID
                      WHERE sp.SpecializationID = @SpecId",
                    new { SpecId = specId }).ToList();

                if (doctors.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    rptDoctors.DataSource = doctors;
                    rptDoctors.DataBind();
                }
            }
        }

        protected string GetBookLink(object doctorId)
        {
            string symptoms = Request.QueryString["symptoms"] ?? "";
            return "~/Patient/Book_Appointment.aspx?doctorId=" + doctorId + "&symptoms=" + symptoms;
        }
        public class DoctorSuggestion
        {
            public int DoctorID { get; set; }
            public string DoctorName { get; set; }
            public string Specialization { get; set; }
            public string HospitalName { get; set; }
            public string AvailableDays { get; set; }
            public string AvailableTime { get; set; }
        }
    }
}