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
    public class TipoIngresoRepository : ITipoIngresoRepository
    {

        private readonly AppDbContext _context;

        public TipoIngresoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoIngreso>> GetAll()
        {
            var tiposIngresos = await _context.TiposIngresos.ToListAsync();
            return tiposIngresos;
        }

        public async Task<TipoIngreso> GetById(int ID)
        {
            return await _context.TiposIngresos.FindAsync(ID);
        }

        public async Task Add(TipoIngreso model)
        {
            await _context.TiposIngresos.AddAsync(model);
            await Save();
        }

        public async Task Update(TipoIngreso model)
        {
            var tipoIngreso = await _context.TiposIngresos.FindAsync(model.ID);
            if (tipoIngreso != null)
            {
                tipoIngreso.Descripcion = model.Descripcion;
                tipoIngreso.Estado = model.Estado;
                _context.Update(tipoIngreso);
                await Save();
            }
        }

        public async Task Delete(int ID)
        {
            var tipoIngreso = await _context.TiposIngresos.FindAsync(ID);
            if (tipoIngreso != null)
            {
                _context.TiposIngresos.Remove(tipoIngreso);
                await Save();
            }
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}