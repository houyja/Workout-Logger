using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLogger.Model;
using WorkoutLogger.Database;

namespace WorkoutLogger.Page
{
    public partial class wpAccountRegistration : System.Web.UI.Page
    {
        dbAccount dba = new dbAccount();
        Database.dbQuote quotes = new Database.dbQuote();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dba = new dbAccount();
                ddlGender.Items.Clear();
                ddlGender.Items.Add("Select Gender");
                ddlGender.Items.Add("Male");
                ddlGender.Items.Add("Female");
                ddlGender.Items.Add("Decline to Say");
                Load_Quotes();
                
            }
        }

        public void Load_Quotes()
        {    
            Quote quote = quotes.RandomQuote("");

            try
            {
                divQuote.InnerHtml = quote.QUOTE + " <br/><br/> " + "- " + quote.AUTHOR;
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

        protected void lnkSubmitAccount_ServerClick(object sender, EventArgs e)
        {
            if(dba.AccountAvailable(txtUsername.Value))
            {
                DateTime bday;
                if(DateTime.TryParse(txtBirthday.Value, out bday))
                {
                    if (dba.AddAccount(txtUsername.Value, txtPassword.Value, txtFirstName.Value, txtLastName.Value, bday, ddlGender.SelectedValue) != 0)
                    {
                        Session["Account"] = dba.Login(txtUsername.Value, txtPassword.Value);
                        Response.Redirect("/default.aspx");
                    }
                    else
                    {
                        divError.InnerText = "*An Unexpected Error Occurred";
                        divError.Style.Add("display", "block");
                    }
                }
            }
            else
            {
                divError.InnerText = "*Username Already in Use.";
                divError.Style.Add("display", "block");
            }
        }
    }
}