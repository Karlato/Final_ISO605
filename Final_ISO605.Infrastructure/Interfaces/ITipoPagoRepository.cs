using Final_ISO605.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Infrastructure.Interfaces
{
    public interface ITipoPagoRepository
    {
        Task<IEnumerable<TipoPago>> GetAll();
        Task<TipoPago> GetById(int ID);
        Task Add(TipoPago model);
        Task Update(TipoPago model);
        Task Delete(int ID);
    }
}
