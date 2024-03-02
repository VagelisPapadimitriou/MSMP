﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMP.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IMovieRepository Movie { get; }

        void Save();
    }
}
