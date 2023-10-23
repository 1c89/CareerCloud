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
      public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>

    {
        private readonly string connectionString = string.Empty;

        private SQLCommandBuilder<ApplicantWorkHistoryPoco> SQLCommander;

        private SQLCommandRunner<ApplicantWorkHistoryPoco> SQLRunner;


        public ApplicantWorkHistoryRepository()
        {
            connectionString = DatabaseConnectionParameters.ConnectionString;

            string[] pkColumns = { "Id" };

            string[] columns = { "Applicant", "Company_Name", "Country_Code", "End_Month", "End_Year", "Job_Description", "Job_Title", "Location", "Start_Month", "Start_Year", "Time_Stamp" };

            string[] properties = { "Applicant", "CompanyName", "CountryCode", "EndMonth", "EndYear", "JobDescription", "JobTitle", "Location", "StartMonth", "StartYear", "TimeStamp" };

            SQLCommander = new SQLCommandBuilder<ApplicantWorkHistoryPoco>("[dbo].[Applicant_Work_History]", pkColumns, columns, properties);

            SQLRunner = new SQLCommandRunner<ApplicantWorkHistoryPoco>(pkColumns, columns, properties);

        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
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

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Add(params ApplicantWorkHistoryPoco[] items)
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

        public void Update(params ApplicantWorkHistoryPoco[] items)
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

        public void Remove(params ApplicantWorkHistoryPoco[] items)
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
