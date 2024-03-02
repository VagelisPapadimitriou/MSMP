using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MSMP.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
 
        //xrisimopoiw to akoloutho wste na grapsw lamda expression (x => x.Id == id) sto FirstOrDefault
        T Get(Expression<Func<T, bool>> filter);

    }
}
