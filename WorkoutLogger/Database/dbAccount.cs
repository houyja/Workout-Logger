using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WorkoutLogger.Model;

namespace WorkoutLogger.Database
{
    public class dbAccount
    {
        String location = @"Data Source=(LocalDB)\v11.0;Initial Catalog=dbWorkoutLogger;Integrated Security=True;Pooling=False";
        dbStoredProc db;

        public dbAccount()
        {
            db = new dbStoredProc(new SqlConnection(location));
        }

        public Account Login(string username, string password)
        {
            db.Set_CONNECTION(new SqlConnection(location));
            db.Set_COMMAND("spLogin");
            
            //Add Paramaters
            db.ADD_INPUT_PARAMATER("@prUSername", System.Data.SqlDbType.VarChar, username, -1);
            db.ADD_INPUT_PARAMATER("@prPassword", System.Data.SqlDbType.VarChar, password, -1);

            //Add Output Paramaters
            db.ADD_OUTPUT_PARAMATER("@outUsername", System.Data.SqlDbType.VarChar, null, -1);
            db.ADD_OUTPUT_PARAMATER("@outAccountID", System.Data.SqlDbType.VarChar, null, -1);
            db.ADD_OUTPUT_PARAMATER("@outFirstName", System.Data.SqlDbType.VarChar, null, -1);
            db.ADD_OUTPUT_PARAMATER("@outLastName", System.Data.SqlDbType.VarChar, null, -1);
            db.ADD_OUTPUT_PARAMATER("@outBirthday", System.Data.SqlDbType.Date, null);

            db.EXECUTE_COMMAND();


            try
            {
                string id = (string)db.GET_PARAMATER("@outAccountID");

                return new Account(
                    (String)db.GET_PARAMATER("@outUsername"),
                    (String)db.GET_PARAMATER("@outAccountID"),
                    (String)db.GET_PARAMATER("@outFirstName"),
                    (String)db.GET_PARAMATER("@outLastName"),
                    (DateTime)db.GET_PARAMATER("@outBirthday"));
            }
            catch
            {
                return null;
            }
        }

        public Boolean AccountAvailable(string username)
        {
            db.Set_CONNECTION(new SqlConnection(location));
            db.Set_COMMAND("spAccountExists");
            db.ADD_INPUT_PARAMATER("@spUsername", System.Data.SqlDbType.VarChar, username, -1);
            db.ADD_OUTPUT_PARAMATER("@outAccountCount", System.Data.SqlDbType.Int, null);
            db.EXECUTE_COMMAND();

            try
            {
                int count = (int)db.GET_PARAMATER("@outAccountCount");
                return count == 0;
            }
            catch
            {
                return false;
            }
        }

        public int AddAccount(string username, string password, string firstname, string lastname, DateTime Birthday, string gender)
        {
            db.Set_CONNECTION(new SqlConnection(location));
            db.Set_COMMAND("spRegisterAccount");
            db.ADD_INPUT_PARAMATER("@prUsername", System.Data.SqlDbType.VarChar, username, -1);
            db.ADD_INPUT_PARAMATER("@prPassword", System.Data.SqlDbType.VarChar, password, -1);
            db.ADD_INPUT_PARAMATER("@prFirstName", System.Data.SqlDbType.VarChar, firstname, -1);
            db.ADD_INPUT_PARAMATER("@prLastName", System.Data.SqlDbType.VarChar, lastname, -1);
            db.ADD_INPUT_PARAMATER("@prBirthday", System.Data.SqlDbType.Date, Birthday);
            db.ADD_INPUT_PARAMATER("@prGender", System.Data.SqlDbType.VarChar, gender, -1);
            db.ADD_INPUT_PARAMATER("@prAccountType", System.Data.SqlDbType.VarChar, "User", -1);
            db.ADD_INPUT_PARAMATER("@prStatus", System.Data.SqlDbType.VarChar, "Approved", -1);

            db.ADD_OUTPUT_PARAMATER("@outAccountID", System.Data.SqlDbType.VarChar, null, -1);

            db.EXECUTE_COMMAND();

            try
            {
                return int.Parse((String)db.GET_PARAMATER("@outAccountID"));
            }
            catch (Exception e)
            { 
                return 0;
            }
        }
    }
}