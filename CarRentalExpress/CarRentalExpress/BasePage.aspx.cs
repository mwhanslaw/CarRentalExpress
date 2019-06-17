// Sofia Dalessandro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRentalExpress
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Context != null && Context.Session != null && null == Session["login"])
                Response.Redirect("~/Login.aspx");
        }
    }
}