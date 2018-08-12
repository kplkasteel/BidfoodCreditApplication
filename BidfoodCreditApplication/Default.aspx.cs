using System;
using System.Web;
using System.Web.UI;

namespace BidfoodCreditApplication
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
        }

        protected void BidfoodImage_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/NewCustomer.aspx");
        }
    }
}