﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//add
using System.Data;
using System.Data.SqlClient;
using BitServicesWebApp.DAL;

namespace BitServicesWebApp.BLL
{
    public class Client
    {
        #region Priv Var
        private SQLDAL _Db;
        #endregion

        #region Pub Var
        public int Client_Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructors
        public Client()
        {
            _Db = new SQLDAL();
        }
        #endregion

        #region Pub Methods

        public DataTable AllBookings()
        {
            string sql = "select * from JOB where Client_Id = @Client_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Client_Id", DbType.Int32) { Value = Client_Id };
            DataTable bookings = _Db.ExecuteSQL(sql, objparams);
            return bookings;
        }
        #endregion

        #region Priv Methods

        #endregion
    }
}