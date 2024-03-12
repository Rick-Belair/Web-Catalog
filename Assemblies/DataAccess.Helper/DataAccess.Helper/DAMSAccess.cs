using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace CallBaseCRM.Shared.DataAccess.Helper
{
    public class DAMSAccess
    {

        #region Connection Procedures

        private OleDbConnection OpenConnection()
        {
            OleDbConnection Connection = new OleDbConnection(GetConnectionString());
            Connection.Open();
            return Connection;
        }

        private void CloseConnection(ref OleDbConnection Connection)
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
        #endregion

        #region Connection String Procedures

        private string GetConnectionString()
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
        private OleDbCommand CreateCommand(string sqlStatement, CommandType CmdType, OleDbConnection Connection)
        {
            OleDbCommand Command = Connection.CreateCommand();
            Command.CommandType = CmdType;
            Command.CommandText = sqlStatement;
            return Command;
        }

        private OleDbCommand CreateCommand(string sqlStatement, CommandType CmdType, OleDbParameter[] Parameters, OleDbConnection Connection)
        {
            OleDbCommand Command = CreateCommand(sqlStatement, CmdType, Connection);

            foreach (OleDbParameter Parameter in Parameters)
            {
                Command.Parameters.Add(Parameter);
            }
            return Command;

        }
        private void DisposeCommand(ref OleDbCommand Command)
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
            OleDbConnection Connection = new OleDbConnection();
            OleDbCommand Command = new OleDbCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                DataSet dtsData = new DataSet();
                OleDbDataAdapter adpAdapter = new OleDbDataAdapter(Command);

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
        /// <param name="Parameters">An array System.Data.OleDb.OleDbParameter</param>
        /// <returns>System.Data.DataSet</returns>
        public DataSet Execute(string sqlStatement, CommandType cmdType, OleDbParameter[] Parameters)
        {
            OleDbConnection Connection = new OleDbConnection();
            OleDbCommand Command = new OleDbCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                DataSet dtsData = new DataSet();
                OleDbDataAdapter adpAdapter = new OleDbDataAdapter(Command);

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
            OleDbConnection Connection = new OleDbConnection();
            OleDbCommand Command = new OleDbCommand();

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
        /// <param name="Parameters">An array System.Data.OleDb.OleDbParameter</param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType, OleDbParameter[] Parameters)
        {
            try
            {
                OleDbConnection Connection = OpenConnection();
                OleDbCommand Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                int intAffectedRow = Command.ExecuteNonQuery();
                DisposeCommand(ref Command);
                CloseConnection(ref Connection);
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
        }

        /// <procedure>ExecuteReader</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>
        /// Executes a SQL statement and returns a DataReader.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <returns>System.Data.OleDb.OleDbDataReader</returns>
        public OleDbDataReader ExecuteReader(string sqlStatement, CommandType cmdType)
        {
            OleDbConnection Connection = new OleDbConnection();
            OleDbCommand Command = new OleDbCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                OleDbDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);

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
        /// <param name="Parameters">An array System.Data.OleDb.OleDbParameter</param>
        /// <returns>System.Data.OleDb.OleDbDataReader</returns>
        public OleDbDataReader ExecuteReader(string sqlStatement, CommandType cmdType, OleDbParameter[] Parameters)
        {
            OleDbConnection Connection = new OleDbConnection();
            OleDbCommand Command = new OleDbCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                OleDbDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);

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
