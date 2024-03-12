using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Diagnostics;

namespace CallBaseCRM.Shared.DataAccess.Helper
{
    public class DAHelper : DBUtilities
    {

                private string _Provider = "";

        #region Constructor

        public DAHelper()
        {
            this.Provider = GetProviderName(GetCurrentConnectionString());
        }

        private string Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
        }

        #endregion

        #region Connection Procedures

        private DbConnection OpenConnection()
        {
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            Connection.ConnectionString = GetConnectionString(GetCurrentConnectionString());
            Connection.Open();
            return Connection;
        }

        private void CloseConnection(ref DbConnection Connection)
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
        #endregion

        #region Command Procedures
        private DbCommand CreateCommand(string sqlStatement, CommandType CmdType, DbConnection Connection)
        {
            DbCommand Command = Connection.CreateCommand();
            Command.CommandType = CmdType;
            Command.CommandText = sqlStatement;
            return Command;
        }

        private DbCommand CreateCommand(string sqlStatement, CommandType CmdType, DbParameter[] Parameters, DbConnection Connection)
        {
            DbCommand Command = CreateCommand(sqlStatement, CmdType, Connection);

            foreach (DbParameter Parameter in Parameters)
            {
                Command.Parameters.Add(Parameter);
            }
            return Command;

        }
        protected void DisposeCommand(ref DbCommand Command)
        {
            if (Command != null)
            {
                // RB - 20131022 - added parameters clear to allow the parameters to be reused for multiple queries. 
                Command.Parameters.Clear();
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

            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                DataSet dtsData = new DataSet();
                DbDataAdapter adpAdapter = Factory.CreateDataAdapter();
                adpAdapter.InsertCommand = Command;
                adpAdapter.SelectCommand = Command;
                adpAdapter.UpdateCommand = Command;
                adpAdapter.Fill(dtsData);
                adpAdapter.Dispose();
                dtsData.Dispose();

                return dtsData;
            }
            catch (DbException)
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
        /// <param name="Parameters">An array System.Data.Common.DBParameter</param>
        /// <returns>System.Data.DataSet</returns>
        public DataSet Execute(string sqlStatement, CommandType cmdType, DbParameter[] Parameters)
        {
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                DataSet dtsData = new DataSet();
                DbDataAdapter adpAdapter = Factory.CreateDataAdapter();
                adpAdapter.InsertCommand = Command;
                adpAdapter.SelectCommand = Command;
                adpAdapter.UpdateCommand = Command;
                adpAdapter.Fill(dtsData);
                adpAdapter.Dispose();

                return dtsData;
            }
            catch (DbException)
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
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                int intAffectedRow = Command.ExecuteNonQuery();

                return intAffectedRow;
            }
            catch (DbException)
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
        /// <param name="Parameters">An array System.Data.Common.DBParameter</param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType, DbParameter[] Parameters)
        {
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                int intAffectedRow = Command.ExecuteNonQuery();
                return intAffectedRow;
            }
            catch (DbException)
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
        /// <author>Dave Christie</author>
        /// <creation_date>1/19/2010</creation_date>
        /// <summary>
        /// Executes a SQL statement with a list of parameters and returns the number of rows affected.
        /// </summary>
        /// <param name="sqlStatement">Contain SQL Query, the store procedure name or table name</param>
        /// <param name="cmdType">Specify the CommandType;Text, StoreProcedure or TableDirect</param>
        /// <param name="Parameters">An array System.Data.Common.DBParameter</param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType, DbParameter[] Parameters,
                                    out DbCommand cmdOut)
        {
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                cmdOut = Command;
                int intAffectedRow = Command.ExecuteNonQuery();
                return intAffectedRow;
            }
            catch (DbException)
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
        /// <returns>System.Data.Common.DbDataReader</returns>
        public DbDataReader ExecuteReader(string sqlStatement, CommandType cmdType)
        {
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Connection);
                DbDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);

                return dtReader;
            }
            catch (DbException)
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
        /// <param name="Parameters">An array System.Data.Common.DBParameter</param>
        /// <returns>System.Data.Common.DbDataReader</returns>
        public DbDataReader ExecuteReader(string sqlStatement, CommandType cmdType, DbParameter[] Parameters)
        {
            DbProviderFactory Factory = DbProviderFactories.GetFactory(this.Provider);
            DbConnection Connection = Factory.CreateConnection();
            DbCommand Command = Factory.CreateCommand();

            try
            {
                Connection = OpenConnection();
                Command = CreateCommand(sqlStatement, cmdType, Parameters, Connection);
                DbDataReader dtReader = Command.ExecuteReader(CommandBehavior.CloseConnection);

                return dtReader;
            }
            catch (DbException)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected object ValueOrNull(
            object value)
        {
            return (value != null) ? value : DBNull.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        protected object ValueOrDefault(
            object value,
            object defaultValue)
        {
            return (value != null) ? value : defaultValue;
        }
    }
}
