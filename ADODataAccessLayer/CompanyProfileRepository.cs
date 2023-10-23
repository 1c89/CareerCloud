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

    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>

    {
        private readonly string connectionString = string.Empty;

        private SQLCommandBuilder<CompanyProfilePoco> SQLCommander;

        private SQLCommandRunner<CompanyProfilePoco> SQLRunner;


        public CompanyProfileRepository()
        {
            connectionString = DatabaseConnectionParameters.ConnectionString;

            string[] pkColumns = { "Id" };

            string[] columns = { "Company_Logo", "Company_Website", "Contact_Name", "Contact_Phone", "Registration_Date", "Time_Stamp" };

            string[] properties = { "CompanyLogo", "CompanyWebsite", "ContactName", "ContactPhone", "RegistrationDate", "TimeStamp" };

            SQLCommander = new SQLCommandBuilder<CompanyProfilePoco>("[dbo].[Company_Profiles]", pkColumns, columns, properties);

            SQLRunner = new SQLCommandRunner<CompanyProfilePoco>(pkColumns, columns, properties);

        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
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

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Add(params CompanyProfilePoco[] items)
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

        public void Update(params CompanyProfilePoco[] items)
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

        public void Remove(params CompanyProfilePoco[] items)
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
