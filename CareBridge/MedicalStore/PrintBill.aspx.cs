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
    public partial class PrintBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadBill();
        }

        private void LoadBill()
        {
            int billId = Convert.ToInt32(Request.QueryString["billId"]);

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var bill = conn.QueryFirstOrDefault(
                    @"SELECT b.TotalAmount, b.BillDate, p.Name AS PatientName
                      FROM tbl_Bill b
                      JOIN tbl_Patient p ON b.PatientID = p.PatientID
                      WHERE b.BillID = @Id",
                    new { Id = billId });

                if (bill == null) return;

                litPatientName.Text = bill.PatientName;
                litBillDate.Text = ((DateTime)bill.BillDate).ToString("dd MMM yyyy");
                litTotal.Text = ((decimal)bill.TotalAmount).ToString("0.00");

                var items = conn.Query<BillItemRow>(
                    "SELECT MedicineName, Quantity, Price FROM tbl_BillItem WHERE BillID = @Id",
                    new { Id = billId });

                rptItems.DataSource = items;
                rptItems.DataBind();
            }
        }
    }
    public class BillItemRow
    {
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}