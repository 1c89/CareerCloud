using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private readonly CareerCloudContext _ccContext;
        
        public EFGenericRepository()
        {
            _ccContext = new CareerCloudContext();
        }

        public void Add(params T[] items)
        {  
            //foreach (var item in items)  context.Set<T>().Add(item);

            _ccContext.Set<T>().AddRange(items);
            _ccContext.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties) => 
                _ccContext.Set<T>().ToList();
              
        

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) =>
                 _ccContext.Set<T>().Where(where).ToList();
           
       

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) =>
                    _ccContext.Set<T>().Where(where).FirstOrDefault();

        public void Remove(params T[] items)
        {
                //foreach (var item in items) context.Set<T>().Remove(item);
                _ccContext.Set<T>().RemoveRange(items);
                _ccContext.SaveChanges();
         
        }

        public void Update(params T[] items)
        {
            //foreach (var item in items) context.Set<T>().Update(item);
            _ccContext.Set<T>().UpdateRange(items); 
            _ccContext.SaveChanges();
        }
    }
}
