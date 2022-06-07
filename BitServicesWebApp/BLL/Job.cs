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
        public string Priority { get; set; }
        public string Skill { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
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
            Priority = dr["Priority"].ToString();
            Skill = dr["Skill"].ToString();
            Description = dr["Description"].ToString();
            Street = dr["Street"].ToString();
            Suburb = dr["Suburb"].ToString();
            Postcode = dr["Postcode"].ToString();
            Distance = Convert.ToInt32(dr["Distance"].ToString());
            Status = dr["Status"].ToString();
            Feedback_Id = Convert.ToInt32(dr["Feedback_Id"].ToString());
            Feedback = dr["Feedback"].ToString();
            _db = new SQLDAL();
        }
        #endregion

        #region Pub Methods

        public int ApproveJob()
        {
            string sql = "UPDATE JOB SET status = 'PaymentPending' WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            int returnVal = _db.ExecuteNonQuery(sql, objparams);
            return returnVal; // payment status
        }
        public int SetJobSkill()
        {
            string sql = "UPDATE JOB SET skill = @skill WHERE Job_Id = @Job_Id";
                 SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
            objparams[1] = new SqlParameter("@skill", DbType.String) { Value = Skill };
            int returnVal = _db.ExecuteNonQuery(sql, objparams);
            return returnVal; 
        }
        public DataTable ChkDoubleJob()
        {
            string sql = "SELECT j.Contractor_Id, CONVERT(date,j.Date) [Date] " +
                         "FROM JOB j " +
                         " WHERE j.Date = @Date " +
                         " AND j.Contractor_Id = @Contractor_Id";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Date", DbType.Int32) { Value = Date };
            objparams[1] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
            DataTable Jobs = _db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        public DataTable ChkLocation()
        {
            string sql = "SELECT c.Contractor_Id, c.First_Name, l.Suburb, l.Postcode " +
                         "FROM CONTRACTOR c" +
                         "INNER JOIN LOCATIONS l ON c.Contractor_Id = l.Contractor_Id " +
                         "WHERE(@Suburb)  IN(l.Suburb) " +
                         "AND(@Postcode) IN(l.postcode) ";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Suburb", DbType.String) { Value = Suburb };
            objparams[1] = new SqlParameter("@Postcode", DbType.String) { Value = Postcode };
            DataTable Contractors = _db.ExecuteSQL(sql, objparams);
            return Contractors;
        }
        public DataTable ChkExperience()
        {
            string sql = string.Empty;
            switch (Priority)
            {
                case  "Urgent":
                     sql = "SELECT c.contractor_Id " +
                   "FROM CONTRACTOR c " +
                   "WHERE c.Experience IN ('Expert') ";
                    break;
                case "High":
                     sql = "SELECT c.contractor_Id " +
                   "FROM CONTRACTOR c " +
                   "WHERE c.Experience IN ('Expert','Advanced') ";
                    break;
                case "Medium":
                     sql = "SELECT c.contractor_Id " +
                   "FROM CONTRACTOR c " +
                   "WHERE c.Experience IN ('Expert','Advanced','Intermediate') ";
                    break;
                case "Low":
                     sql = "SELECT c.contractor_Id " +
                   "FROM CONTRACTOR c " +
                   "WHERE c.Experience IN ('Expert','Advanced','Intermediate','Beginner') ";
                    break;                          
            }           
            DataTable Contractors = _db.ExecuteSQL(sql);
            return Contractors;
        }
        public int InsertJobReq()
        {
            string sql = $"INSERT INTO JOB (Client_Id,Date,Priority,Status,Description,Street,Suburb,Postcode) " +
                          "VALUES (@Client_Id,@Date,@Priority,'Unassigned',@Description,@Street,@Suburb,@Postcode) ";                        
            SqlParameter[] objparams = new SqlParameter[7];
            objparams[0] = new SqlParameter("@Client_Id", DbType.Int32) { Value = Client_Id };
            objparams[1] = new SqlParameter("@Date", DbType.Date) { Value = Date };
            objparams[2] = new SqlParameter("@Priority", DbType.String) { Value = Priority };
            objparams[3] = new SqlParameter("@Description", DbType.String) { Value = Description };
            objparams[4] = new SqlParameter("@Street", DbType.String) { Value = Street };
            objparams[5] = new SqlParameter("@Suburb", DbType.String) { Value = Suburb };
            objparams[6] = new SqlParameter("@Postcode", DbType.String) { Value = Postcode };
            int returnVal = _db.ExecuteNonQuery(sql, objparams);
            return returnVal;


        }

        public int AssignContractor()
        {
            //bruh just make stored procs and call in query below bruh
            if (ChkDoubleJob().Rows.Count > 0)
            {
                return 0;
            }
            if (ChkLocation().Rows.Count == 0)
            {
                return 0;
            }
            Availability Avail = new Availability();
            if (Avail.DateAvailability(Date) != null)
            {
                string sql = "UPDATE JOB j " +
                             "SET j.Contractor_Id = @Contractor_Id, j.status = 'Assigned' " +                            
                             "WHERE Job_Id = @Job_Id ";
                SqlParameter[] objparams = new SqlParameter[2];
                objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
                objparams[1] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
                int returnVal = _db.ExecuteNonQuery(sql, objparams);
                return returnVal;
            }
            return 0;
        }



        #endregion
    }
}