using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.DAL.Repositories.Interfaces;

namespace FifaPSL.DAL.Repositories.Implementation
{
    public class BaseRepository: IBaseRepository
    {

        protected static FifaDataSource _dbContext;

        public BaseRepository()
        {
            if (_dbContext == null)
            {
                _dbContext = new FifaDataSource();
            }
        }
    }
}
