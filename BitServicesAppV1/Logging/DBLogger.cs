using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.Data.SqlClient;
using BitServicesDesktopApp.DAL;

namespace BitServicesDesktopApp.Logging
{
    public class DBLogger : LogBase
    {
        public override void Log(string message)
        {
            /* SQLDAL and then an insert statement to relevant table
             * SQLDAL dal = new SQLDAL()
             * string sql = "INSERT INTO LogTable(message) VALUES(@Message)";
             * SqlParameter[] objparams = new SqlParameter[1];
             * objparams[0] = new SqpParameter("@Message, Dbtype.String") { Value = message };
             * DAL.ExecuteNonQuery(sql, objparams);
             */
        }
    }
}
