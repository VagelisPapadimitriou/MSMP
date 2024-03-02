using MSMP.DataAccess.Data;
using MSMP.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMP.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IMovieRepository Movie { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Movie = new MovieRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
