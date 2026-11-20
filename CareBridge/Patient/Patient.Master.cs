using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CareBridge.Patient
{
    public partial class Patient : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Patient")
            {
                Response.Redirect("~/Login.aspx");
            }

            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();

            foreach (HtmlAnchor link in sidebarNav.Controls.OfType<HtmlGenericControl>()
                                                            .SelectMany(li => li.Controls.OfType<HtmlAnchor>()))
            {
                if (link.HRef.ToLower().Contains(currentPage))
                {
                    link.Attributes["class"] = "active";
                }
            }
        }
    }
}