using System;
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
    class AllUnassignedJobs : List<Job>
    {
        private SQLDAL _db;

        public AllUnassignedJobs()
        {
            _db = new SQLDAL();
            string sql = " SELECT j.Job_Id ,j.client_id , cl.name [Client_Name], null contractor_id, null contractor_name, j.Date , j.Priority, j.Skill, j.Status,  j.Street,  j.Suburb, j.Postcode,j.distance, j.Description " +
                         "FROM Job j " +
                         "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
                         "WHERE j.status = 'Unassigned'";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Job newJob = new Job(dr);
                Add(newJob);
            }
        }
    }
}
