using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaPSL.DAL.Repositories.Interfaces;

namespace FifaPSL.BL.Services.Interfaces
{
    public class BaseService: IBaseService
    {

        public IFifaRepository fifaRepository;

        public BaseService(IFifaRepository _fifaRepository) {
            fifaRepository = _fifaRepository;
        }

    }
}
