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
    

    public class Availability
    {
        private SQLDAL _Db;

        public Availability()
        {
            _Db = new SQLDAL();
        }
        //public DataTable CheckAvailability(DateTime date, string time, string suburb, string postcode)
        //{

        //    date.DayOfWeek
        //    string sql = "SELECT contractor_id, weekday, start_time, end_time ";
        //    return _Db.ExecuteSQL(sql);
        //}

    }
}