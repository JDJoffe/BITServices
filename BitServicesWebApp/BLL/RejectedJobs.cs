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
    public class RejectedJobs
    {
        private SQLDAL _Db;

        public RejectedJobs()
        {
            _Db = new SQLDAL();
        }
        public DataTable AllRejectedJobs()
        {
            string sql = "select b.bookingId, c.firstname +' '+ c.lastname as [Customer Name]," +
                " b.pickupaddress, b.suburb, b.postcode, b.state, " +
                "i.firstname + ' ' + i.lastname [Instructor Name]," +
                " a.availabledate, t.starttime " +
                "FROM CUSTOMER c, BOOKING b, AVAILABILITY a, INSTRUCTOR i, timeslot t" +
                " where b.availabilityId = a.availabilityId " +
                "AND a.instructorID = i.instructorID " +
                "AND c.customerId = b.customerId " +
                "AND a.timeslotId = t.timeslotId " +
                "AND b.bookingstatusId = 2 " +
                "AND b.paymentstatusid = 1 ";
            DataTable jobs = _Db.ExecuteSQL(sql);
            return jobs;
        }
    }
}