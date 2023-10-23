using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;
using System.Linq;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository:IDataRepository<ApplicantEducationPoco>

    {
        private readonly string connectionString = string.Empty;

        private SQLCommandBuilder<ApplicantEducationPoco> SQLCommander;

        private SQLCommandRunner<ApplicantEducationPoco> SQLRunner;


        public ApplicantEducationRepository()
        {
            connectionString = DatabaseConnectionParameters.ConnectionString;

            string[] pkColumns = { "Id" };

            string[] columns = { "Applicant", "Major", "Certificate_Diploma", "Start_Date", "Completion_Date", "Completion_Percent", "Time_Stamp" };

            string[] properties = { "Applicant", "Major", "CertificateDiploma", "StartDate", "CompletionDate", "CompletionPercent", "TimeStamp" };

            SQLCommander = new SQLCommandBuilder<ApplicantEducationPoco>("[dbo].[Applicant_Educations]", pkColumns, columns, properties);

            SQLRunner = new SQLCommandRunner<ApplicantEducationPoco>(pkColumns, columns, properties);

        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
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

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }

        public void Add(params ApplicantEducationPoco[] items)
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

        public void Update(params ApplicantEducationPoco[] items)
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

        public void Remove(params ApplicantEducationPoco[] items)
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