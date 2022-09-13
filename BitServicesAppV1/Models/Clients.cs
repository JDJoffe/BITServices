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
   public class Clients : List<Client>
    {
        private SQLDAL _db;

       public Clients()
        {
            _db = new SQLDAL();

            string sql = "SELECT c.Client_Id, c.Name, c.Phone, c.Email, c.Password, c.IsActive " +
                         "FROM CLIENT c";
            DataTable datatable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in datatable.Rows)
            {
                Client newClient = new Client(dr);
                Add(newClient);
            }
        }
    }
}
