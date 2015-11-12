using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WorkoutLogger.Database
{

    public class dbStoredProc
    {
        private SqlConnection CONNECTION;
        private SqlCommand Command;

        public dbStoredProc(SqlConnection con)
        {
            CONNECTION = con;
        }

        public void Set_CONNECTION(SqlConnection con)
        {
            CONNECTION = con;
        }

        public Boolean Set_COMMAND(string proc)
        {
            try
            {
                Command = new SqlCommand(proc, CONNECTION);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean ADD_INPUT_PARAMATER(string proc_variable, System.Data.SqlDbType data_type, object variable_value, int size)
        {
            if (Command != null)
            {
                try
                {
                    Command.Parameters.Add(proc_variable, data_type, size).Value = variable_value;
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Command Not Initialized");
            }
        }

        public Boolean ADD_INPUT_PARAMATER(string proc_variable, System.Data.SqlDbType data_type, object variable_value)
        {
            if (Command != null)
            {
                try
                {
                    Command.Parameters.Add(proc_variable, data_type).Value = variable_value;
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Command Not Initialized");
            }
        }

        public Boolean ADD_OUTPUT_PARAMATER(string proc_variable, System.Data.SqlDbType data_type, object variable_value, int size)
        {
            if (Command != null)
            {
                try
                {
                    Command.Parameters.Add(proc_variable, data_type, size).Value = variable_value;
                    Command.Parameters[proc_variable].Direction = System.Data.ParameterDirection.Output;
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Command Not Initialized");
            }
        }

        public Boolean ADD_OUTPUT_PARAMATER(string proc_variable, System.Data.SqlDbType data_type, object variable_value)
        {
            if (Command != null)
            {
                try
                {
                    Command.Parameters.Add(proc_variable, data_type).Value = variable_value;
                    Command.Parameters[proc_variable].Direction = System.Data.ParameterDirection.Output;
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Command Not Initialized");
            }
        }
    
        public Boolean EXECUTE_COMMAND()
        {
            try
            {
                using(CONNECTION)
                {
                    CONNECTION.Open();
                    Command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }

        public Object GET_PARAMATER(string param)
        {
            try
            {
                return Command.Parameters[param].Value;
            }
            catch
            {
                return null;
            }
        }
    }
}