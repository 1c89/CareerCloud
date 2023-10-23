using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : IDataRepository<SecurityLoginsLogPoco>

    {
        private readonly string connectionString = string.Empty;

        private SQLCommandBuilder<SecurityLoginsLogPoco> SQLCommander;

        private SQLCommandRunner<SecurityLoginsLogPoco> SQLRunner;


        public SecurityLoginsLogRepository()
        {
            connectionString = DatabaseConnectionParameters.ConnectionString;

            string[] pkColumns = { "Id" };

            string[] columns = { "Is_Succesful", "Login", "Logon_Date", "Source_IP" };
           
            string[] properties = { "IsSuccesful", "Login", "LogonDate", "SourceIP" };

            SQLCommander = new SQLCommandBuilder<SecurityLoginsLogPoco>("[dbo].[Security_Logins_Log]", pkColumns, columns, properties);

            SQLRunner = new SQLCommandRunner<SecurityLoginsLogPoco>(pkColumns, columns, properties);

        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
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

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Add(params SecurityLoginsLogPoco[] items)
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

        public void Update(params SecurityLoginsLogPoco[] items)
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

        public void Remove(params SecurityLoginsLogPoco[] items)
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
