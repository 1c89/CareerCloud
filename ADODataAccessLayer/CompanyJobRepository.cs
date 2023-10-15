using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
  
    public class  CompanyJobRepository : IDataRepository< CompanyJobPoco>

    {
        public IList< CompanyJobPoco> GetAll(params Expression<Func< CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }
        public IList< CompanyJobPoco> GetList(Expression<Func< CompanyJobPoco, bool>> where, params Expression<Func< CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }
        public  CompanyJobPoco GetSingle(Expression<Func< CompanyJobPoco, bool>> where, params Expression<Func< CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable< CompanyJobPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();

        }
        public void Add(params  CompanyJobPoco[] items)
        { }
        public void Update(params  CompanyJobPoco[] items)
        { }
        public void Remove(params  CompanyJobPoco[] items)
        { }
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

    }

}
