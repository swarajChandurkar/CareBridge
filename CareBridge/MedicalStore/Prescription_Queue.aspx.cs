using System;
using System.Collections.Generic;
using System.Linq;
using CareBridge.App_Code;
using Dapper;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareBridge.MedicalStore
{
    public partial class Prescription_Queue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadQueue();
        }

        private void LoadQueue()
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                var queue = conn.Query<QueueRow>(
                     @"SELECT p.PrescriptionID, pt.Name AS PatientName, d.Name AS DoctorName, p.PrescriptionDate
                      FROM tbl_Prescription p
                      JOIN tbl_Patient pt ON p.PatientID = pt.PatientID
                      JOIN tbl_Doctor d ON p.DoctorID = d.DoctorID
                      WHERE NOT EXISTS (SELECT 1 FROM tbl_Bill b WHERE b.PrescriptionID = p.PrescriptionID)
                      ORDER BY p.PrescriptionDate DESC").ToList();

                if (queue.Count == 0)
                {
                    lblEmpty.Visible = true;
                }
                else
                {
                    rptQueue.DataSource = queue;
                    rptQueue.DataBind();
                }
            }
        }
    }

    public class QueueRow
    {
        public int PrescriptionID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime PrescriptionDate { get; set; }
    }
}