using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add
using System.Data;
using System.Data.SqlClient;
using BitServicesWebApp.DAL;

namespace BitServicesWebApp.BLL
{
    public class User
    {
        #region Pub Var
        public int userId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private SQLDAL _Db;
        #endregion

        #region Constructor
        public User()
        {
            _Db = new SQLDAL();
        }
        #endregion

        #region Pub Methods
        public int CheckClient()
        {
            string sql = "SELECT client_Id FROM CLIENT WHERE email = @Email AND password = @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String) { Value = Email };
            objParams[1] = new SqlParameter("@Password", DbType.String) { Value = Password };
            DataTable datatable = _Db.ExecuteSQL(sql, objParams);
            int id = -1;
            if (datatable.Rows.Count > 0)
            {
                id = Convert.ToInt32(datatable.Rows[0][0]);
            }
            return id;
        }

        public int CheckContractor()
        {
            string sql = "SELECT Contractor_Id FROM CONTRACTOR WHERE email = @Email AND password = @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String) { Value = Email };
            objParams[1] = new SqlParameter("@Password", DbType.String) { Value = Password };
            DataTable datatable = _Db.ExecuteSQL(sql, objParams);
            int id = -1;
            if (datatable.Rows.Count > 0)
            {
                id = Convert.ToInt32(datatable.Rows[0][0]);
            }
            return id;
        }

        public int CheckCoordinator()
        {
            string sql = "SELECT Coordinator_Id FROM COORDINATOR WHERE email = @Email AND password = @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String) { Value = Email };
            objParams[1] = new SqlParameter("@Password", DbType.String) { Value = Password };
            DataTable datatable = _Db.ExecuteSQL(sql, objParams);
            int id = -1;
            if (datatable.Rows.Count > 0)
            {
                id = Convert.ToInt32(datatable.Rows[0][0]);
            }
            return id;
        } 
        #endregion
    }
}