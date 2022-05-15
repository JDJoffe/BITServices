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
    public class CompletedJobs
    {
        private SQLDAL _Db;
        public CompletedJobs()
        {
            _Db = new SQLDAL();
        }
        public DataTable AllCompletedJobs()
        {
            string sql = "select b.bookingId, c.firstname +' '+ c.lastname as [Customer Name], b.pickupaddress, b.suburb, b.postcode, b.state, i.firstname + ' ' + i.lastname [Instructor Name] FROM CUSTOMER c, BOOKING b, AVAILABILITY a, INSTRUCTOR i where b.availabilityId = a.availabilityId AND a.instructorID = i.instructorID AND c.customerId = b.customerId AND b.bookingstatusId = 4 AND b.paymentstatusid = 1";
            DataTable jobs = _Db.ExecuteSQL(sql);
            return jobs;
        }
    }
}