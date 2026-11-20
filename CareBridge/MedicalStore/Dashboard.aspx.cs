using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;
namespace CareBridge.MedicalStore
{
    public partial class Dashboard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadStats();
        }

        private void LoadStats()
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                litUnbilled.Text = conn.ExecuteScalar<int>(
                    @"SELECT COUNT(*) FROM tbl_Prescription p
                      WHERE NOT EXISTS (SELECT 1 FROM tbl_Bill b WHERE b.PrescriptionID = p.PrescriptionID)").ToString();

                litBilledToday.Text = conn.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM tbl_Bill WHERE CAST(BillDate AS DATE) = CAST(GETDATE() AS DATE)").ToString();
            }
        }
    }
}