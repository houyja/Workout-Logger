using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkoutLogger.Masterpages
{
    public partial class mpDefault : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(Request.Params["Logoff"] == "true")
            {
                Session["Account"] = null;
                Response.Redirect(Request.Url.AbsolutePath);   
            }
             

            if ((Model.Account)Session["Account"] != null)
                lblUsername.Text = ((Model.Account)Session["Account"]).Username;
            else
                lblUsername.Text = "";

        }
    }
}