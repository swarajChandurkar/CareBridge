using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;

namespace CareBridge.Patient
{
    public partial class Enter_Symptoms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnFindDoctor_Click(object sender, EventArgs e)
        {
            var selected = cblSymptoms.Items.Cast<ListItem>()
                                             .Where(i => i.Selected)
                                             .Select(i => i.Text)
                                             .ToList();

            if (!selected.Any())
            {
                lblMessage.Text = "Please select at least one symptom.";
                return;
            }

            var selectedValues = cblSymptoms.Items.Cast<ListItem>()
                                                   .Where(i => i.Selected)
                                                   .Select(i => i.Value)
                                                   .ToList();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var specId = conn.QueryFirstOrDefault<int?>(
                    @"SELECT TOP 1 SpecializationID FROM tbl_SymptomMapping
                      WHERE Symptom IN @Symptoms
                      GROUP BY SpecializationID
                      ORDER BY COUNT(*) DESC",
                    new { Symptoms = selectedValues });

                if (specId == null)
                {
                    specId = conn.QueryFirstOrDefault<int?>(
                        "SELECT SpecializationID FROM tbl_Specialization WHERE Name = 'General Physician'");
                }

                // Build a readable comma-separated string of what the patient selected, e.g. "Fever, Cough"
                string symptomText = string.Join(", ", selected);
                string encoded = HttpUtility.UrlEncode(symptomText);

                Response.Redirect("~/Patient/Hospital_Suggestions.aspx?spec=" + specId + "&symptoms=" + encoded);
            }
        }
    }
}