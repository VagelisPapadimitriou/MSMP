using Microsoft.EntityFrameworkCore;
using MSMP.DataAccess.Data;
using MSMP.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MSMP.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //IQueryable<T> query = dbSet;
            //query= query.Where(filter);
            //return query.FirstOrDefault();
            return null;
        }
    }
}
