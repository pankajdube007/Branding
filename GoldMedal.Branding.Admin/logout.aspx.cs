using System;

namespace GoldMedal.Branding.Admin
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] myCookies = Request.Cookies.AllKeys;

            foreach (string cookie in myCookies)
            {
                if (!string.Equals(cookie, "geoloc") && !string.Equals(cookie, "geoip"))
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
            }
            Session.Clear();
            Session.Abandon();
            Response.Redirect("default.aspx");
        }
    }
}