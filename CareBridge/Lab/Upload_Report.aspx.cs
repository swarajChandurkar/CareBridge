using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CareBridge.App_Code;
using Dapper;
namespace CareBridge.Lab
{
    public partial class Upload_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile)
            {
                lblMessage.CssClass = "text-danger d-block mb-3";
                lblMessage.Text = "Please choose a file first.";
                return;
            }

            int requestId = Convert.ToInt32(Request.QueryString["requestId"]);

            string fileName = requestId + "_" + Path.GetFileName(fileUpload.FileName);
            string savePath = Server.MapPath("~/UploadedReports/" + fileName);
            fileUpload.SaveAs(savePath);

            string relativePath = "/UploadedReports/" + fileName;

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();

                conn.Execute(
                    "INSERT INTO tbl_LabReport (RequestID, ReportFilePath) VALUES (@RequestID, @Path)",
                    new { RequestID = requestId, Path = relativePath });

                conn.Execute(
                    "UPDATE tbl_LabTestRequest SET Status = 'Completed' WHERE RequestID = @Id",
                    new { Id = requestId });
            }

            lblMessage.Text = "Report uploaded and marked complete.";
        }
    }
}