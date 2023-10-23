 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
     public class CompanyJobSkillRepository : IDataRepository<CompanyJobSkillPoco>

    {
        private readonly string connectionString = string.Empty;

        private SQLCommandBuilder<CompanyJobSkillPoco> SQLCommander;

        private SQLCommandRunner<CompanyJobSkillPoco> SQLRunner;


        public CompanyJobSkillRepository()
        {
            connectionString = DatabaseConnectionParameters.ConnectionString;

            string[] pkColumns = { "Id" };

            string[] columns = { "Importance", "Job", "Skill", "Skill_Level", "Time_Stamp" };

            string[] properties = { "Importance", "Job", "Skill", "SkillLevel", "TimeStamp" };

            SQLCommander = new SQLCommandBuilder<CompanyJobSkillPoco>("[dbo].[Company_Job_Skills]", pkColumns, columns, properties);

            SQLRunner = new SQLCommandRunner<CompanyJobSkillPoco>(pkColumns, columns, properties);

        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {

            using (var conn = new SqlConnection(connectionString))

            {

                conn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = conn;
                SQLCommander.SetSelectCommand(cmd);

                var RecordsList = SQLRunner.ExtractDataFromSQLReader(cmd);

                conn.Close();



                return RecordsList;
            }
        }

        public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Add(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;

                    SQLCommander.SetInsertCommand(cmd, item);

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }

        }

        public void Update(params CompanyJobSkillPoco[] items)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;

                    SQLCommander.SetUpdateCommand(cmd, item);

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }

        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    SQLCommander.SetDeleteCommand(cmd, item);


                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

    }

}
