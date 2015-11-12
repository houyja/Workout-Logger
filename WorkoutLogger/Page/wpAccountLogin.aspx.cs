using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLogger.Model;

namespace WorkoutLogger.Page
{
    public partial class wpAccountLogin : System.Web.UI.Page
    {
        Database.dbAccount dbAccounts = new Database.dbAccount();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Quotes();
            }
        }

        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            Session["Account"] = dbAccounts.Login(txtUsername.Value, txtPassword.Value);
            
            if (Session["Account"] != null)
                Response.Redirect("/default.aspx");
            else
            {
                divError.InnerText = "*Invalid Login. Please Try Again";
                divError.Style["display"] = "block";
            }
        }

        public void Load_Quotes()
        {
            Database.dbQuote quotes = new Database.dbQuote();
            Quote quote = quotes.RandomQuote("");


            try
            {
                divQuote.InnerHtml = quote.QUOTE + " <br/> " + "-" + quote.AUTHOR;
            }
            catch
            {
                try
                {
                    divQuote.InnerText = quote.QUOTE;
                }
                catch
                {
                    divQuote.InnerText = "Quote Not Found";
                }
            }

        }
    }
}