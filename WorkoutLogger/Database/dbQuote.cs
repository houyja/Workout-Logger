using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WorkoutLogger.Model;

namespace WorkoutLogger.Database
{
    public class dbQuote
    {
        String location = @"Data Source=(LocalDB)\v11.0;Initial Catalog=dbWorkoutLogger;Integrated Security=True;Pooling=False";
        dbStoredProc db;

        public dbQuote()
        {
            db = new dbStoredProc(new SqlConnection(location));
        }

        public Quote RandomQuote(string page)
        {
            db.Set_CONNECTION(new SqlConnection(location));
            db.Set_COMMAND("spGetRandomQuote");

            db.ADD_INPUT_PARAMATER("@prPage", System.Data.SqlDbType.VarChar, page, -1);
            db.ADD_OUTPUT_PARAMATER("@prQuote", System.Data.SqlDbType.VarChar, null, -1);
            db.ADD_OUTPUT_PARAMATER("@prAuthor", System.Data.SqlDbType.VarChar, null, -1);

            db.EXECUTE_COMMAND();


            try
            {
                string qt = (string)db.GET_PARAMATER("@prQUote");
                string at;

                try
                {
                    at = (String)db.GET_PARAMATER("@prAuthor");
                }
                catch
                {
                    at = "unknown";
                }

                Quote quote = new Quote(qt, at);

                return quote;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}