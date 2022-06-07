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
    public class UnassignedJobs
    {

        private SQLDAL _Db;
        public UnassignedJobs()
        {
            _Db = new SQLDAL();
        }
        public DataTable AllUnassignedJobs()
        {
            string sql = "SELECT cl.Name, J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
            "FROM JOB j " +
            "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
            "WHERE j.Status = 'Unassigned'";
            DataTable jobs = _Db.ExecuteSQL(sql);
            return jobs;
        }
    }
}