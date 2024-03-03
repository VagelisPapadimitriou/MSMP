using Microsoft.EntityFrameworkCore;
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
        private ApplicationDbContext _context;
        public IMovieRepository Movie { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movie = new MovieRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
