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
    public class RejectedJobs
    {
        private SQLDAL _Db;

        public RejectedJobs()
        {
            _Db = new SQLDAL();
        }
        public DataTable AllRejectedJobs()
        {
            string sql = "SELECT cl.Name, co.first_name , J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
                         "FROM JOB j " +
                         "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
                         "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
                         "WHERE j.status = 'Rejected' ";
            DataTable jobs = _Db.ExecuteSQL(sql);
            return jobs;
        }
    }
}