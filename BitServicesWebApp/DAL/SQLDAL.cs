using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace BitServicesWebApp.DAL
{
    public class SQLDAL
    {
        #region Priv Var
        private string _connection; 
        #endregion

        #region Constructors
        // Having multiple versions of Constructors is allowed due to overloading
        // as long as your methods have different signatures (parameters) 
        // and because a constructor in a class is a special method,
        // constructors can also be overloaded

        // default constructor
        // reading the connection string from the App.Config
        public SQLDAL() { _connection = ConfigurationManager.ConnectionStrings["BIT"].ConnectionString; }
        // parameterised constructor
        public SQLDAL(string connection) { _connection = ConfigurationManager.ConnectionStrings[connection].ConnectionString; }
        #endregion

        #region Public Methods
        public DataTable ExecuteSQL(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            DataTable dataTable = new DataTable();
            SqlConnection dbConnection = new SqlConnection(_connection);
            // open the Db connection
            dbConnection.Open();
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
            // decide if we are executing a stored procedure
            if (storedProcedure)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            // parameters
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }

            // try to run command
            try
            {
                // execute sql and return the reader
                SqlDataReader drResults = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                // load datatable with query results
                dataTable.Load(drResults);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dataTable;
        }

        // Microsoft - ExecuteReader - execution of a query (select)
        // ExecuteNonQuery - NonQuery - any query that will change the state of the Database - Insert, Update, Delete
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            int returnValue = -1;
            SqlConnection dbConnection = new SqlConnection(_connection);
            // open the Db connection

            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
            // decide if we are executing a stored procedure
            if (storedProcedure)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            // parameters
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }

            // try to run command
            try
            {
                dbConnection.Open();
                // execute sql and return the value
                returnValue = dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return returnValue;
        }

        // Scalar queries - count, max, min. queries that return one value
        public object ExecuteSQLScalar(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            object returnValue = null;
            SqlConnection dbConnection = new SqlConnection(_connection);
            // open the Db connection

            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
            // decide if we are executing a stored procedure
            if (storedProcedure)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            // parameters
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }

            // try to run command
            try
            {
                dbConnection.Open();
                // execute sql and return the value
                returnValue = dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return returnValue;
        }
        #endregion

        // pass by value
        // pass by reference : Arrays or any other objects are always pass by reference
        #region Private Methods
        private void AddParameters(SqlCommand objCommand, SqlParameter[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                objCommand.Parameters.Add(parameters[i]);
            }
        }
        #endregion

    }
}