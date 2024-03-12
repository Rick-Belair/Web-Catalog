using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;

namespace CallBaseCRM.Shared.DataAccess.Helper
{
    public class DASQLServer
    {
        #region Connection Procedures

        private SqlConnection OpenConnection()
        {
            SqlConnection Connection = new SqlConnection(GetConnectionString());
            Connection.Open();
            return Connection;
        }

        private void CloseConnection(ref SqlConnection Connection)
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
        #endregion

        #region Connection String Procedures

        public string GetConnectionString()
        {
            string CURRENT_CONNECTION_STRING = ConfigurationManager.AppSettings.Get("CURRENT_CONNECTION_STRING");
            ConnectionStringSettingsCollection ConnectionStrings = ConfigurationManager.ConnectionStrings;

            if (ConnectionStrings.Count > 1)
            {
                if (String.IsNullOrEmpty(CURRENT_CONNECTION_STRING))
                {
                    return ConnectionStrings[1].ConnectionString;
                }
                else
                {
                    return ConnectionStrings[CURRENT_CONNECTION_STRING].ConnectionString;
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Command Procedures
        private SqlCommand CreateCommand(string sqlStatement, CommandType CmdType, SqlConnection Connection)
        {
            SqlCommand Command = Connection.CreateCommand();
            Command.CommandType = CmdType;
            Command.CommandText = sqlStatement;
            return Command;
        }

        private SqlCommand CreateCommand(string sqlStatement, CommandType CmdType, SqlParameter[] Parameters, SqlConnection Connection)
        {
            SqlCommand Command = Connection.CreateCommand();
            Command.CommandType = CmdType;
            Command.CommandText = sqlStatement;

            foreach (SqlParameter Parameter in Parameters)
            {
                Command.Parameters.Add(Parameter);
            }
            return Command;
        }

        private void DisposeCommand(ref SqlCommand Command)
        {
            if (Command != null)
            {
                Command.Dispose();
            }
        }
        #endregion

        /// <procedure>Execute</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement and returns a DataSet.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <returns>System.Data.DataSet</returns>
        public DataSet Execute(string sqlStatement, CommandType cmdType)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                DataSet dtsData = new DataSet();
                SqlDataAdapter adpAdapter = new SqlDataAdapter(Command);

                adpAdapter.Fill(dtsData);
                adpAdapter.Dispose();
                dtsData.Dispose();
                return dtsData;
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
            finally
            {
                DisposeCommand(ref Command);
                CloseConnection(ref Connection);
            }
        }

        /// <procedure>Execute</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement with a list of parameters and returns a DataSet.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <param name="Parameters">An array System.Data.SqlClient.SqlParameter</param>
        /// <returns>System.Data.DataSet</returns>
        public DataSet Execute(string sqlStatement, CommandType cmdType, SqlParameter[] Parameters)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                DataSet dtsData = new DataSet();
                SqlDataAdapter adpAdapter = new SqlDataAdapter(Command);

                adpAdapter.Fill(dtsData);
                adpAdapter.Dispose();
                return dtsData;
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
            finally
            {
                DisposeCommand(ref Command);
                CloseConnection(ref Connection);
            }
        }

        /// <procedure>ExecuteNonQuery</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement and returns the number of rows affected.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                int intAffectedRow = Command.ExecuteNonQuery();
                return intAffectedRow;
            }

            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
            finally
            {
                DisposeCommand(ref Command);
                CloseConnection(ref Connection);
            }
        }

        /// <procedure>ExecuteNonQuery</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement with a list of parameters and returns the number of rows affected.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <param name="Parameters">An array System.Data.SqlClient.SqlParameter</param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType, SqlParameter[] Parameters)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                int intAffectedRow = Command.ExecuteNonQuery();
                return intAffectedRow;
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
            finally
            {
                DisposeCommand(ref Command);
                CloseConnection(ref Connection);
            }
        }

        /// <procedure>ExecuteReader</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement and returns a DataReader.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <returns>System.Data.SqlClient.SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string sqlStatement, CommandType cmdType)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                SqlDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);

                return dtReader;
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
            finally
            {
                DisposeCommand(ref Command);
            }
        }

        /// <procedure>ExecuteReader</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement with a list of parameters and returns a DataReader.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <param name="Parameters">An array System.Data.SqlClient.SqlParameter</param>
        /// <returns>System.Data.SqlClient.SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string sqlStatement, CommandType cmdType, SqlParameter[] Parameters)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                SqlDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);

                return dtReader;
            }
            catch (OleDbException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ConfigurationErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
            finally
            {
                DisposeCommand(ref Command);
            }
        }
    }
}
