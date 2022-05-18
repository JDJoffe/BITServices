using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add
using System.Data;
using System.Data.SqlClient;
using BitServicesWebApp.DAL;

namespace BitServicesWebApp.BLL
{
    public class CompletedJobs
    {
        private SQLDAL _Db;
        public CompletedJobs()
        {
            _Db = new SQLDAL();
        }
        public DataTable AllCompletedJobs()
        {
            string sql = "SELECT cl.Name, J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
            "FROM JOB j " +
            "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
            "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
            "INNER JOIN JOB_STATUS js ON j.Job_Id = js.Job_Id " +
            "WHERE js.Status = 'completed'";
            DataTable jobs = _Db.ExecuteSQL(sql);
            return jobs;
        }
    }
}