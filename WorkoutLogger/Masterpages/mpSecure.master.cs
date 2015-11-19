using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkoutLogger.Masterpages
{
    public partial class mpSecure : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account"] == null)
                Response.Redirect("/Page/wpAccountLogin.aspx");
        }
    }
}