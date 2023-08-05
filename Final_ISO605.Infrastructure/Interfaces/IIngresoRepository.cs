using Final_ISO605.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Infrastructure.Interfaces
{
    public interface IIngresoRepository
    {
        Task<IEnumerable<Ingreso>> GetAll();
        Task<Ingreso> GetById(int ID);
        Task Add(Ingreso model);
        Task Update(Ingreso model);
        Task Delete(int ID);
    }
}
