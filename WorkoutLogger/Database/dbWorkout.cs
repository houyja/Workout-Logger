using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WorkoutLogger.Database
{
    public class dbWorkout
    {
        String location = @"Data Source=(LocalDB)\v11.0;Initial Catalog=dbWorkoutLogger;Integrated Security=True;Pooling=False";
        dbStoredProc db;

        public dbWorkout()
        {
            db = new dbStoredProc(new SqlConnection(location));
        }

        public string[] GetWorkouts(DateTime date, string ID)
        {
            db.Set_CONNECTION(new SqlConnection(location));
            db.Set_COMMAND("spGetWorkoutNameByDate");
            db.ADD_INPUT_PARAMATER("@prID", System.Data.SqlDbType.VarChar, ID, -1);
            db.ADD_INPUT_PARAMATER("@prDate", System.Data.SqlDbType.Date, date.ToShortDateString(), -1);
            db.ADD_OUTPUT_PARAMATER("@outWorkouts", System.Data.SqlDbType.VarChar, ID, -1);
            db.EXECUTE_COMMAND();

            string result = (string)db.GET_PARAMATER("@outWorkouts");
            string search = ", ";
            int lastfound = 0;
            List<string> results = new List<string>();

            if (result != null)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (i < result.Length - 1)
                    {
                        if (result.Substring(i, 2) == search)
                        {
                            if (lastfound != 0)
                            {
                                results.Add(result.Substring(lastfound + 1, i - lastfound-1));
                            }
                            else
                            {
                                results.Add(result.Substring(0, i));
                            }

                            lastfound = i + 1;
                        }
                    }
                    else
                    {
                        results.Add(result.Substring(lastfound + 1, i - lastfound));
                    }
                }
            }
            return results.ToArray();
        }
    }
}