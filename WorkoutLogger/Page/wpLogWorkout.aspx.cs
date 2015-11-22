using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLogger.Model;

namespace WorkoutLogger.Page
{
    public partial class wpLogWorkout : System.Web.UI.Page
    {
        Database.dbWorkout dbWorkout;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbWorkout = new Database.dbWorkout();
        }

        protected void Date_Change(object sender, EventArgs e)
        {
            ddlWorkoutName.Items.Clear();
            DateTime date;
            DateTime.TryParse(tbxWorkoutDate.Value, out date);
            {
                if (date != null)
                {
                    try
                    {
                        foreach (string s in dbWorkout.GetWorkouts(date, ((Account)Session["Account"]).AccountID))
                        {
                            ddlWorkoutName.Items.Add(s);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    ddlWorkoutName.Items.Add("Create New Workout");
                }
            }
        }
    }
}