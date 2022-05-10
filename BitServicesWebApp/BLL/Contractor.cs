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
    public class Contractor
    {
        #region Priv Var
        private SQLDAL _Db;
        #endregion

        #region Pub Var
        public int Contractor_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructors
        public Contractor()
        {
            _Db = new SQLDAL();
        }
        #endregion

        #region Pub Methods

        public DataTable AllJobs()
        {
            string sql = "select j.Job_Id, cl.Name, J.Priority, J.Skill, J.Description FROM CLIENT cl, JOB j, AVAILABILITY a, CONTRACTOR co, JOB_STATUS js where c.contractor_id = a.contractor_id AND cl.Client_Id = j.Client_Id AND co.contractor_Id = @contractor_id AND js.status = 'Assigned'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        // below not complete
        public DataTable AllAcceptedJobs()
        {
            string sql = "select b.JobId, c.firstname +' '+ c.lastname as [Customer Name], b.pickupaddress, b.suburb, b.postcode, b.state FROM CUSTOMER c, Job b, AVAILABILITY a, INSTRUCTOR i where b.availabilityId = a.availabilityId AND a.instructorID = i.instructorID AND c.customerId = b.customerId AND i.instructorId = @InstructorId AND b.JobstatusId = 3";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }
        public int AcceptJob(int JobId)
        {
            int returnVal = 0;
            string sql = "UPDATE Job SET JobStatusId = 3 WHERE JobId = @JobId";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@JobId", DbType.Int32) { Value = JobId };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }

        public int RejectJob(int JobId)
        {
            int returnVal = 0;
            string sql = "UPDATE Job SET JobStatusId = 2 WHERE JobId = @JobId";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@JobId", DbType.Int32) { Value = JobId };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }

        public int CompleteJob(int JobId, int Kilometres)
        {
            int returnVal = 0;
            string sql = "UPDATE Job SET JobStatusId = 4, Kilometres = @Kilometres WHERE JobId = @JobId";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@JobId", DbType.Int32) { Value = JobId };
            objparams[1] = new SqlParameter("@Kilometres", DbType.Int32) { Value = Kilometres };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }
        #endregion

        #region Priv Methods

        #endregion
    }
}