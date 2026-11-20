using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CareBridge.App_Code;
using Dapper;
using System.Web;


namespace CareBridge.MedicalStore
{
    public partial class BillPrescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadItems();
        }

        private void LoadItems()
        {
            int prescriptionId = Convert.ToInt32(Request.QueryString["prescriptionId"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var Items = conn.Query<ItemsRow>(
                    "SELECT MedicineName, Dosage, Quantity FROM tbl_PrescriptionItem WHERE PrescriptionID = @Id",
                    new { Id = prescriptionId }).ToList();

                rptItems.DataSource = Items;
                rptItems.DataBind();
            }
        }

        protected void btnGenerateBill_Click(object sender, EventArgs e)
        {
            int prescriptionId = Convert.ToInt32(Request.QueryString["prescriptionId"]);
            int loginId = Convert.ToInt32(Session["LoginID"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var prescription = conn.QueryFirstOrDefault(
                    "SELECT PatientID FROM tbl_Prescription WHERE PrescriptionID = @Id",
                    new { Id = prescriptionId });

                var store = conn.QueryFirstOrDefault(
                    "SELECT StoreID FROM tbl_MedicalStore WHERE LoginID = @LoginID",
                    new { LoginID = loginId });

                decimal total = 0;
                var billItems = new System.Collections.Generic.List<(string Name, int Qty, decimal Price)>();

                foreach (RepeaterItem item in rptItems.Items)
                {
                    var hidMedName = (HiddenField)item.FindControl("hidMedName");
                    var hidQty = (HiddenField)item.FindControl("hidQty");
                    var txtPrice = (TextBox)item.FindControl("txtPrice");

                    decimal price = 0;
                    decimal.TryParse(txtPrice.Text, out price);

                    int qty = 0;
                    int.TryParse(hidQty.Value, out qty);

                    billItems.Add((hidMedName.Value, qty, price));
                    total += price;
                }

                int billId = conn.ExecuteScalar<int>(
                    @"INSERT INTO tbl_Bill (PrescriptionID, PatientID, StoreID, TotalAmount)
                      OUTPUT INSERTED.BillID
                      VALUES (@PrescriptionID, @PatientID, @StoreID, @TotalAmount)",
                    new { PrescriptionID = prescriptionId, PatientID = prescription.PatientID, StoreID = store.StoreID, TotalAmount = total });

                foreach (var b in billItems)
                {
                    conn.Execute(
                        "INSERT INTO tbl_BillItem (BillID, MedicineName, Quantity, Price) VALUES (@BillID, @Name, @Qty, @Price)",
                        new { BillID = billId, b.Name, b.Qty, b.Price });
                }

                Response.Redirect("~/MedicalStore/PrintBill.aspx?billId=" + billId);
            }
        }
    }

    public class ItemsRow
    {

        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Quantity { get; set; }
    }
}