﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// add
using System.Data;
using System.Data.SqlClient;
using BitServicesDesktopApp.DAL;

namespace BitServicesDesktopApp.Models
{
    class Jobs : List<Job>
    {
        private SQLDAL _db;

        public Jobs()
        {
            _db = new SQLDAL();
            string sql = " SELECT j.Job_Id ,cl.client_id, cl.name AS [Client_Name], co.contractor_id, CONCAT(co.first_name +' ', co.last_name) AS [Contractor_Name] , j.Date, j.Priority, j.Skill, j.Status, j.Distance,  j.Street,  j.Suburb, j.Postcode, j.Description " +
                         "FROM Job j " +
                         "NNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
                         "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id; ";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Job newJob = new Job(dr);
                Add(newJob);
            }
        }
    }
}
