using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace CallBaseCRM.Shared.DataAccess.Helper
{
    public class DBUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <procedure>GetProviderName</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>This procedure return the provider name for a specific Connection string
        ///          of the App.config file.
        /// </summary>
        /// <param name="AppSettigsKeyName">The name of the connection string</param>
        /// <returns>The name of the provider a given connection string</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////
        protected string GetProviderName(string AppSettigsKeyName)
        {
            ConnectionStringSettingsCollection ConnectionStrings = ConfigurationManager.ConnectionStrings;
            return ConnectionStrings[AppSettigsKeyName].ProviderName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <procedure>GetCurrentConnectionString</procedure>
        /// <author>Patrick Plouffe</author>
        /// <Creation_date>1/03/2008</Creation_date>
        /// <summary>This procedure return the value of the application setting key
        ///          CURRENT_CONNECTION_STRING of the App.config file.
        /// </summary>
        /// <returns>The current application connection string name</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////
        protected string GetCurrentConnectionString()
        {
            string CURRENT_CONNECTION_STRING = ConfigurationManager.AppSettings.Get("CURRENT_CONNECTION_STRING");
            return CURRENT_CONNECTION_STRING;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <procedure>GetConnectionString</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>This procedure return the connection string for a specified
        ///          connection string name from the App.config file.
        /// </summary>
        /// <param name="AppSettigsKeyName">The name of the connection string </param>
        /// <returns>The connection string</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////
        protected string GetConnectionString(string AppSettigsKeyName)
        {
            ConnectionStringSettingsCollection ConnectionStrings = ConfigurationManager.ConnectionStrings;
            return ConnectionStrings[AppSettigsKeyName].ConnectionString;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <procedure>CreateParameter</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>This procedure create a parameter object</summary>
        /// <param name="Name">The name of the parameter</param>
        /// <param name="DataType">The data type of the parameter</param>
        /// <param name="Value">The value of the parameter</param>
        /// <returns>DBParameter</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////
        public DbParameter CreateParameter(string Name, DbType DataType, object Value)
        {
            try
            {
                DbProviderFactory Factory = DbProviderFactories.GetFactory(GetProviderName(GetCurrentConnectionString()));
                DbParameter Parameter = Factory.CreateParameter();
                Parameter.ParameterName = Name;
                Parameter.DbType = DataType;
                Parameter.Value = Value;
                return Parameter;

            }
            catch (DbException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }

        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <procedure>CreateParameter</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>This procedure create a parameter object</summary>
        /// <param name="Name">The name of the parameter</param>
        /// <param name="DataType">The data type of the parameter</param>
        /// <param name="Direction">The direction of the parameter(input-only, output-only, bidirectional, ...)</param>
        /// <param name="Value">The value of the parameter</param>
        /// <returns>DBParameter</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////
        public DbParameter CreateParameter(string Name, DbType DataType, ParameterDirection Direction, object Value)
        {
            try
            {
                DbParameter Parameter = CreateParameter(Name, DataType, Value);
                Parameter.Direction = Direction;
                return Parameter;
            }
            catch (DbException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// <procedure>CreateParameter</procedure>
        /// <author>Patrick Plouffe</author>
        /// <creation_date>1/03/2008</creation_date>
        /// <summary>This procedure create a parameter object</summary>
        /// <param name="Name">The name of the parameter</param>
        /// <param name="DataType">The data type of the parameter</param>
        /// <param name="Direction">The direction of the parameter(input-only, output-only, bidirectional, ...)</param>
        /// <param name="Value">The value of the parameter</param>
        /// <param name="Size">The maximal size, in bytes, of the data</param>
        /// <returns>DBParameter</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////
        public DbParameter CreateParameter(string Name, DbType DataType, ParameterDirection Direction, int Size, object Value)
        {
            try
            {
                DbParameter Parameter = CreateParameter(Name, DataType, Direction, Value);
                Parameter.Size = Size;
                return Parameter;
            }
            catch (DbException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occur", ex);
            }
        }
    }

}
