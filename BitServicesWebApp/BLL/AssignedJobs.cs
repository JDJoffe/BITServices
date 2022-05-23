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
    public class AssignedJobs
    {
        private SQLDAL _Db;

        public AssignedJobs()
        {
            _Db = new SQLDAL();
        }
        public DataTable AllAssignedJobs()
        {

        
        string sql =
           "SELECT j.job_id, cl.Name, J.Priority, J.Skill, J.Description, CONCAT(DATEPART(day,j.date),'/') + CONCAT(DATEPART(month,j.date),'/') + CONVERT(varchar,DATEPART(year,j.date))AS Date, j.street, j.suburb, j.postcode " +
           "FROM JOB j " +
           "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
           "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
           "INNER JOIN JOB_STATUS js ON j.Job_Id = js.Job_Id " +
           "WHERE js.Status = 'Assigned'";
       
        DataTable Jobs = _Db.ExecuteSQL(sql);
            return Jobs;
        }
    }
}