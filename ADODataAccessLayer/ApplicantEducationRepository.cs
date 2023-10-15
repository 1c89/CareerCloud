using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;
using System.Linq;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository:IDataRepository<ApplicantEducationPoco>

    {
        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties) 
        {
            throw new NotImplementedException();
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
        { }
        public void Update(params ApplicantEducationPoco[] items) 
        { }
        public void Remove(params ApplicantEducationPoco[] items) 
        { }
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters) 
        {
            throw new NotImplementedException();
        }

    }
}