using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CareBridge.App_Code;
using Dapper;
namespace CareBridge.Patient
{
    public partial class Prescriptions : System.Web.UI.Page
    {
        private List<PrescriptionItemRow> _allItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadPrescriptions();
        }

        private void LoadPrescriptions()
        {
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var patient = conn.QueryFirstOrDefault(
                    "SELECT PatientID FROM tbl_Patient WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                var prescriptions = conn.Query<PrescriptionRow>(
                    @"SELECT p.PrescriptionID, d.Name AS DoctorName, p.PrescriptionDate
                      FROM tbl_Prescription p
                      JOIN tbl_Doctor d ON p.DoctorID = d.DoctorID
                      WHERE p.PatientID = @PatientID
                      ORDER BY p.PrescriptionDate DESC",
                    new { PatientID = patient.PatientID }).ToList();

                _allItems = conn.Query<PrescriptionItemRow>(
                    @"SELECT pi.PrescriptionID, pi.MedicineName, pi.Dosage, pi.Quantity, pi.Instructions
                      FROM tbl_PrescriptionItem pi
                      JOIN tbl_Prescription p ON pi.PrescriptionID = p.PrescriptionID
                      WHERE p.PatientID = @PatientID",
                    new { PatientID = patient.PatientID }).ToList();

                if (prescriptions.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    rptPrescriptions.DataSource = prescriptions;
                    rptPrescriptions.DataBind();
                }
            }
        }

        protected string GetMedicineRows(object prescriptionId)
        {
            int id = Convert.ToInt32(prescriptionId);
            var items = _allItems.Where(i => i.PrescriptionID == id);

            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + item.MedicineName + "</td>");
                sb.Append("<td>" + item.Dosage + "</td>");
                sb.Append("<td>" + item.Quantity + "</td>");
                sb.Append("<td>" + item.Instructions + "</td>");
                sb.Append("</tr>");
            }
            return sb.ToString();
        }
    }

    public class PrescriptionRow
    {
        public int PrescriptionID { get; set; }
        public string DoctorName { get; set; }
        public DateTime PrescriptionDate { get; set; }
    }

    public class PrescriptionItemRow
    {
        public int PrescriptionID { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public string Instructions { get; set; }
    }
}