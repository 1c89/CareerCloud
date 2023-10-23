using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>

    {
        private readonly string connectionString = string.Empty;

        private SQLCommandBuilder<SystemCountryCodePoco> SQLCommander;
   
        private SQLCommandRunner<SystemCountryCodePoco> SQLRunner;


        public SystemCountryCodeRepository()
        {
            connectionString = DatabaseConnectionParameters.ConnectionString;

            string[] pkColumns = { "Code" };

            string[] columns = { "Name" };

            SQLCommander = new SQLCommandBuilder<SystemCountryCodePoco>("[dbo].[System_Country_Codes]", pkColumns, columns, columns);
            
            SQLRunner = new SQLCommandRunner<SystemCountryCodePoco>(pkColumns, columns, columns);

        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
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
        
        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }
      
        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }
        
        public void Add(params SystemCountryCodePoco[] items)
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

        public void Update(params SystemCountryCodePoco[] items)
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

        public void Remove(params SystemCountryCodePoco[] items)
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
