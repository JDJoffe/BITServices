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
    public class Job
    {
        #region Priv Var
        private SQLDAL _db;
        #endregion
        #region Pub Var
        public int Job_Id { get; set; }
        public int Client_Id { get; set; }
        public int Contractor_Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Priority { get; set; }
        public string Skill { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public int Coordinator_Id { get; set; }
        public string Status { get; set; }
        public int Feedback_Id { get; set; }
        public string Feedback { get; set; }
        #endregion
        #region Constructors
        public Job()
        {
            _db = new SQLDAL();
        }

        public Job(DataRow dr)
        {
            Job_Id = Convert.ToInt32(dr["Job_Id"].ToString());
            Client_Id = Convert.ToInt32(dr["Client_Id"].ToString());
            Contractor_Id = Convert.ToInt32(dr["Contractor_Id"].ToString());
            Date = Convert.ToDateTime(dr["Date"].ToString());
            Start_Time = Convert.ToDateTime(dr["Start_Time"].ToString());
            End_Time = Convert.ToDateTime(dr["End_Time"].ToString());
            Priority = dr["Priority"].ToString();
            Skill = dr["Skill"].ToString();
            Description = dr["Description"].ToString();
            Street = dr["Street"].ToString();
            Suburb = dr["Suburb"].ToString();
            Postcode = dr["Postcode"].ToString();
            Distance = Convert.ToInt32(dr["Distance"].ToString());
            Coordinator_Id = Convert.ToInt32(dr["Coordinator_Id"].ToString());
            Status = dr["State"].ToString();
            Feedback_Id = Convert.ToInt32(dr["Feedback_Id"].ToString());
            Feedback = dr["Feedback"].ToString();
            _db = new SQLDAL();
        }
        #endregion

        #region Pub Methods

        public int ApproveJob()
        {
            string sql = "UPDATE JOB_STATUS SET status = 'PaymentPending' WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            int returnVal = _db.ExecuteNonQuery(sql, objparams);
            return returnVal; // payment status
        }

         

       

        #endregion
    }
}