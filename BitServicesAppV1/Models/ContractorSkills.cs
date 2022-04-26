using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.Data;
using System.Data.SqlClient;
using BitServicesDesktopApp.DAL;

namespace BitServicesDesktopApp.Models
{
    class ContractorSkills : List<ContractorSkill>
    {
       public ContractorSkills()
        {
            SQLDAL _db = new SQLDAL();
            string sql = "SELECT DISTINCT Skill FROM Skills";
            DataTable skills = _db.ExecuteSQL(sql);
            foreach (DataRow dr in skills.Rows)
            {
                ContractorSkill skill = new ContractorSkill(dr);
                Add(skill);
            }
        }
        public ContractorSkills(int contractorId)
        {
            SQLDAL _db = new SQLDAL();
            string sql = "SELECT skill FROM CONTRACTORSKILL WHERE contractorId = @contractorId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@contractorId", DbType.String) { Value = contractorId };
            DataTable skills = _db.ExecuteSQL(sql, objParams);
            foreach (DataRow dr in skills.Rows)
            {
                ContractorSkill skill = new ContractorSkill(dr);
                Add(skill);
            }
        }
    }
}
