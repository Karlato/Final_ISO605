    using Final_ISO605.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Final_ISO605.Infrastructure.Interfaces
    {
        public interface ITipoIngresoRepository
        {
            Task<IEnumerable<TipoIngreso>> GetAll();
            Task<TipoIngreso> GetById(int ID);
            Task Add(TipoIngreso model);
            Task Update(TipoIngreso model);
            Task Delete(int ID);
        }
    }
