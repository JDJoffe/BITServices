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
    public class Feedback
    {
        private SQLDAL _Db;

        public int Job_Id { get; set; }
        public int FeedBack_Id { get; set; }
        public string FeedBack { get; set; }
        public Feedback()
        {
            _Db = new SQLDAL();
        }
        public Feedback(DataRow dr)
        {
            Job_Id = Convert.ToInt32(dr["Job_Id"].ToString());
            FeedBack_Id = Convert.ToInt32(dr["FeedBack_Id"].ToString());
            FeedBack = dr["FeedBack"].ToString();
        }
       
        public DataTable JobFeedBack()
        {
            string sql = "SELECT Feedback " +
            "FROM FEEDBACK f " +
            "INNER JOIN JOB j ON f.job_Id = j.job_Id " +
            "WHERE j.Job_Id = '@Job_Id'";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            DataTable feedback = _Db.ExecuteSQL(sql, objparams);
            
            return feedback;
        }
    }
}