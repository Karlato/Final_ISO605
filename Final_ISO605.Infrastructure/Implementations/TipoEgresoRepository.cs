using Final_ISO605.Core;
using Final_ISO605.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Infrastructure.Implementations
{
    public class TipoEgresoRepository : ITipoEgresoRepository
    {

        private readonly AppDbContext _context;

        public TipoEgresoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoEgreso>> GetAll()
        {
            var tiposEgresos = await _context.TiposEgresos.ToListAsync();
            return tiposEgresos;
        }

        public async Task<TipoEgreso> GetById(int ID)
        {
            return await _context.TiposEgresos.FindAsync(ID);
        }

        public async Task Add(TipoEgreso model)
        {
            await _context.TiposEgresos.AddAsync(model);
            await Save();
        }

        public async Task Update(TipoEgreso model)
        {
            var tipoEgreso = await _context.TiposEgresos.FindAsync(model.ID);
            if(tipoEgreso != null)
            {
                tipoEgreso.Descripcion = model.Descripcion;
                tipoEgreso.Estado = model.Estado;
                _context.Update(tipoEgreso);
                await Save();
            }
        }

        public async Task Delete(int ID)
        {
            var tipoEgreso = await _context.TiposEgresos.FindAsync(ID);
            if (tipoEgreso != null)
            {
                _context.TiposEgresos.Remove(tipoEgreso);
                await Save();
            }
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
