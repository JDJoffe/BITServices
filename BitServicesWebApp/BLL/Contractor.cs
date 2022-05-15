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
            string sql = "select j.Job_Id, cl.Name, J.Priority, J.Skill, J.Description FROM CLIENT cl, JOB j, AVAILABILITY a, CONTRACTOR co, JOB_STATUS js where c.contractor_id = a.contractor_id AND cl.Client_Id = j.Client_Id AND co.contractor_Id = @Contractor_Id AND js.status = 'Assigned'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        // below not complete
        public DataTable AllAcceptedJobs()
        {
            string sql = "select j.Job_Id, cl.Name, J.Priority, J.Skill, J.Description FROM CLIENT cl, JOB j, AVAILABILITY a, CONTRACTOR co, JOB_STATUS js where c.contractor_id = a.contractor_id AND cl.Client_Id = j.Client_Id AND co.contractor_Id = @Contractor_Id AND js.status = 'Accepted'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }
        public int AcceptJob(int Job_Id)
        {
            int returnVal = 0;
            string sql = "UPDATE JOB_STATUS SET status = 'Accepted' WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }

        public int RejectJob(int Job_Id)
        {
            int returnVal = 0;
            string sql = "UPDATE JOB_STATUS SET status = 'Rejected' WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }

        public int CompleteJob(int Job_Id, int Distance)
        {
            int returnVal = 0;
            string sql = "BEGIN TRANSACTION; " +
                         "UPDATE JOB_STATUS SET status = 'Complete' WHERE Job_Id = @Job_Id; " +
                         "UPDATE JOB SET Distance = @Distance WHERE Job_Id = @Job_Id; " +
                         "COMMIT";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            objparams[1] = new SqlParameter("@Distance", DbType.Int32) { Value = Distance };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }
        #endregion

        #region Priv Methods

        #endregion
    }
}