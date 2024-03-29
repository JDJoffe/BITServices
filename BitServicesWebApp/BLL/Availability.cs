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


    public class Availability
    {
        private SQLDAL _Db;

        public int Contractor_Id { get; set; }
        public int Job_Id { get; set; }
        public DateTime Date { get; set; }

        public Availability()
        {
            _Db = new SQLDAL();
        }

        public DataTable DateAvailability(DataTable contractors)
        {     
            foreach (DataRow dr in contractors.Rows)
            {
                
            }

            string sql = "SELECT Contractor_Id, CONVERT(date,j.Date) [Date] " +
                         "FROM AVAILABILITY " +
                         " WHERE Date = @Date";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Date", DbType.Int32) { Value = Date };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

    }
}