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

        public DataTable AllAssignedJobs()
        {
            string sql = "SELECT j.job_id, cl.Name, J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
            "FROM JOB j " +
            "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
            "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
            "WHERE co.Contractor_Id = @Contractor_Id " +
            "AND j.Status = 'Assigned'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        // below not complete
        public DataTable AllAcceptedJobs()
        {
            string sql = "SELECT j.job_id, cl.Name, J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
            "FROM JOB j " +
            "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
            "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
            "WHERE co.Contractor_Id = @Contractor_Id " +
            "AND j.Status = 'Accepted'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        public DataTable AllRejectedJobs()
        {
            string sql = "SELECT j.job_id, cl.Name, J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
            "FROM JOB j " +
            "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
            "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
            "WHERE co.Contractor_Id = @Contractor_Id " +
            "AND j.Status = 'Rejected'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        public DataTable AllCompletedJobs()
        {
            string sql = "SELECT j.job_id, cl.Name, J.Priority, J.Skill, J.Description, CONVERT(date,j.Date) [Date], j.street, j.suburb, j.postcode " +
            "FROM JOB j " +
            "INNER JOIN CLIENT cl ON j.Client_Id = cl.Client_Id " +
            "INNER JOIN CONTRACTOR co ON j.Contractor_Id = co.Contractor_Id " +
            "WHERE co.Contractor_Id = @Contractor_Id " +
            "AND j.Status IN ('Complete', 'PaymentPending')";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _Db.ExecuteSQL(sql, objparams);
            return Jobs;
        }
        public int AcceptJob(int Job_Id)
        {
            int returnVal = 0;
            string sql = "UPDATE JOB SET status = 'Accepted' WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }

        public int RejectJob(int Job_Id, int Contractor_Id)
        {
            int returnVal = 0;
            string sql = "UPDATE JOB SET status = 'Unassigned' WHERE Job_Id = @Job_Id " +
                         "INSERT INTO HISTORY (Job_Id, Contractor_Id) VALUES (@Job_Id, @Contractor_Id) ";

            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            objparams[1] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }

        public int CompleteJob(int Job_Id, int Distance)
        {
            int returnVal = 0;
            string sql = "UPDATE JOB SET status = 'Complete', Distance = @Distance " +
                         "WHERE Job_Id = @Job_Id; ";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            objparams[1] = new SqlParameter("@Distance", DbType.Int32) { Value = (int)Distance };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }
        public int SubmitFeedback(int Job_Id, string feedback)
        {
            int returnVal = 0;
            string sql = "INSERT INTO FEEDBACK (@Job_Id @Feedback) ";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            objparams[1] = new SqlParameter("@Feedback", DbType.String) { Value = feedback };
            returnVal = _Db.ExecuteNonQuery(sql, objparams);
            return returnVal;
        }
        #endregion

        #region Priv Methods

        #endregion
    }
}