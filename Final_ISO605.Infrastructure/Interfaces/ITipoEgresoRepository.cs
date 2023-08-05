using Final_ISO605.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Infrastructure.Interfaces
{
    public interface ITipoEgresoRepository
    {
        Task<IEnumerable<TipoEgreso>> GetAll();
        Task<TipoEgreso> GetById(int ID);
        Task Add(TipoEgreso model);
        Task Update(TipoEgreso model);
        Task Delete(int ID);
    }
}
