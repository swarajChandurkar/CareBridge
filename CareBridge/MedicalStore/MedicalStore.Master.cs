using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareBridge.MedicalStore
{
    public partial class MedicalStore : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "MedicalStore")
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}