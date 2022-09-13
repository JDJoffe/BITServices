using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using BitServicesDesktopApp.DAL;

namespace BitServicesDesktopApp.Models
{
    class Job
    {
        #region Priv Var
        private int _jobId;
        private int _clientId;
        private string _clientName;
        private int _contractorId;
        private string _contractorName;
        private DateTime _date;
        private string _priority;
        private string _skill;
        private string _street;
        private string _suburb;
        private string _postcode;
        private string _description;
        private int _distance;
        private string _status;

        private SQLDAL _db;
        #endregion
        #region Pub Var
        public int JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
                OnPropertyChanged("ClientId");
            }
        }
        public string ClientName
        {
            get { return _clientName; }
            set
            {
                _clientName = value;
                OnPropertyChanged("ClientName");
            }
        }
        public int ContractorId
        {
            get { return _contractorId; }
            set
            {
                _contractorId = value;
                OnPropertyChanged("ContractorId");
            }
        }
        public string ContractorName
        {
            get { return _contractorName; }
            set
            {
                _contractorName = value;
                OnPropertyChanged("ContractorName");
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged("Priority");
            }
        }
        public string Skill
        {
            get { return _skill; }
            set
            {
                _skill = value;
                OnPropertyChanged("Skill");
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                OnPropertyChanged("Postcode");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public int Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged("Distance");
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Constructors
        public Job()
        {
            _db = new SQLDAL();
        }

        public Job(DataRow dr)
        {
            JobId = Convert.ToInt32(dr["Job_Id"].ToString());
            ClientId = Convert.ToInt32(dr["Client_Id"].ToString());
            ClientName = dr["Client_Name"].ToString();
            if (!dr.IsNull("Contractor_Id") )
            {
                ContractorId = Convert.ToInt32(dr["Contractor_Id"].ToString());
            }
            if (!dr.IsNull("Contractor_Name"))
            {
                ContractorName = dr["Contractor_Name"].ToString();
            }
            Date = Convert.ToDateTime(dr["Date"].ToString());
            Priority = dr["Priority"].ToString();
            Skill = dr["Skill"].ToString();
            Description = dr["Description"].ToString();
            Street = dr["Street"].ToString();
            Suburb = dr["Suburb"].ToString();
            Postcode = dr["Postcode"].ToString();
            Distance = Convert.ToInt32(dr["Distance"].ToString());
            Status = dr["Status"].ToString();
            _db = new SQLDAL();
        }
        #endregion

        #region Pub Methods

        public int ApproveJob()
        {
            string sql = "UPDATE JOB SET status = 'PaymentPending' WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = JobId };
            int returnVal = _db.ExecuteNonQuery(sql, objparams);
            return returnVal; // payment status
        }
        public int SetJobSkill()
        {
            string sql = "UPDATE JOB SET skill = @skill WHERE Job_Id = @Job_Id";
            SqlParameter[] objparams = new SqlParameter[2];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = JobId };
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
            objparams[1] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = ContractorId };
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

        public int InsertJobReq()
        {
            string sql = $"INSERT INTO JOB (Client_Id,Date,Priority,Status,Description,Street,Suburb,Postcode) " +
                          "VALUES (@Client_Id,@Date,@Priority,'Unassigned',@Description,@Street,@Suburb,@Postcode) ";
            SqlParameter[] objparams = new SqlParameter[7];
            objparams[0] = new SqlParameter("@Client_Id", DbType.Int32) { Value = ClientId };
            objparams[1] = new SqlParameter("@Date", DbType.Date) { Value = Date };
            objparams[2] = new SqlParameter("@Priority", DbType.String) { Value = Priority };
            objparams[3] = new SqlParameter("@Description", DbType.String) { Value = Description };
            objparams[4] = new SqlParameter("@Street", DbType.String) { Value = Street };
            objparams[5] = new SqlParameter("@Suburb", DbType.String) { Value = Suburb };
            objparams[6] = new SqlParameter("@Postcode", DbType.String) { Value = Postcode };
            int returnVal = _db.ExecuteNonQuery(sql, objparams);
            return returnVal;


        }

        private string ChkExperience(string Priority)
        {
            string sql = string.Empty;
            switch (Priority)
            {
                case "Urgent":
                    sql = "AND c.Experience IN ('Expert') ";
                    break;
                case "High":
                    sql = "AND c.Experience IN ('Expert','Advanced') ";
                    break;
                case "Medium":
                    sql = "AND c.Experience IN ('Expert','Advanced','Intermediate') ";
                    break;
                case "Low":
                    sql = "AND c.Experience IN ('Expert','Advanced','Intermediate','Beginner') ";
                    break;
            }
            return sql;
            // DataTable Contractors = _db.ExecuteSQL(sql);
            // return Contractors;
        }
        public DataTable SuitableForJob()
        {
            string sql = "SELECT c.Contractor_Id Contractor_Id" +
                         "FROM Contractor c" +
                         "INNER JOIN Locations l ON c.Contractor_Id = l.Contractor_Id" +
                         "INNER JOIN CONTRACTOR_SKILL cs ON c.Contractor_Id = cs.Contractor_Id" +
                         "INNER JOIN[AVAILABILITY] a ON c.Contractor_Id = a.Contractor_Id" +
                         "WHERE(@Suburb)  IN(l.Suburb)" +
                         "AND(@Postcode) IN(l.postcode)" +
                         "AND cs.Skill = @Skill" +
                         "AND a.[Date] = @Date " +
                         $"{ChkExperience(Priority)}";
            SqlParameter[] objparams = new SqlParameter[5];
            objparams[0] = new SqlParameter("@Suburb", DbType.String) { Value = Suburb };
            objparams[1] = new SqlParameter("@Postcode", DbType.String) { Value = Postcode };
            objparams[2] = new SqlParameter("@Skill", DbType.String) { Value = Skill };
            objparams[3] = new SqlParameter("@Date", DbType.Date) { Value = Date };
            objparams[4] = new SqlParameter("@Priority", DbType.String) { Value = Priority };
            DataTable Contractors = _db.ExecuteSQL(sql, objparams);
            return Contractors;
        }
        public DataTable FilterRejJobs(DataTable contractors)
        {
            foreach (DataRow dr in contractors.Rows)
            {
                int currcontractor = Convert.ToInt32(dr["Contractor_Id"].ToString());
                DateTime Date = Convert.ToDateTime(dr["Date"].ToString());

                string sql1 = "DECLARE @Result NVARCHAR(11) " +
                                "EXEC usp_ChkDoubleJob @Date , @Contractor_Id, @Result OUTPUT; " +
                                "PRINT @Result";
                SqlParameter[] objparams1 = new SqlParameter[2];
                objparams1[0] = new SqlParameter("@Date", DbType.Date) { Value = Date };
                objparams1[1] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = currcontractor };
                var filtered = _db.ExecuteSQLScalar(sql1, objparams1);

                if (filtered.ToString() == "Unavailable")
                {
                    contractors.Rows.Remove(dr);
                }
            }

            string sql = "SELECT Contractor_Id, CONVERT(date,j.Date) [Date] " +
                         "FROM AVAILABILITY " +
                         " WHERE Date = @Date";
            SqlParameter[] objparams = new SqlParameter[1];
            objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = JobId };
            objparams[1] = new SqlParameter("@Date", DbType.Date) { Value = Date };
            DataTable Jobs = _db.ExecuteSQL(sql, objparams);
            return Jobs;
        }

        //public int AssignContractor()
        //{
        //    //bruh just make stored procs and call in query below bruh
        //    if (ChkDoubleJob().Rows.Count > 0)
        //    {
        //        return 0;
        //    }
        //    if (ChkLocation().Rows.Count == 0)
        //    {
        //        return 0;
        //    }
        //    Availability Avail = new Availability();
        //    if (Avail.DateAvailability(Date) != null)
        //    {
        //        string sql = "UPDATE JOB j " +
        //                     "SET j.Contractor_Id = @Contractor_Id, j.status = 'Assigned' " +
        //                     "WHERE Job_Id = @Job_Id ";
        //        SqlParameter[] objparams = new SqlParameter[2];
        //        objparams[0] = new SqlParameter("@Job_Id", DbType.Int32) { Value = Job_Id };
        //        objparams[1] = new SqlParameter("@Contractor_Id", DbType.Int32) { Value = Contractor_Id };
        //        int returnVal = _db.ExecuteNonQuery(sql, objparams);
        //        return returnVal;
        //    }
        //    return 0;
        //}
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        #endregion
    }
}