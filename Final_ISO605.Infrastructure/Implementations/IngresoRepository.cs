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
    public class IngresoRepository : IIngresoRepository
    {

        private readonly AppDbContext _context;
        public IngresoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingreso>> GetAll()
        {
            var ingresos = await _context.Ingresos.ToListAsync();
            return ingresos;
        }

        public async Task<Ingreso> GetById(int ID)
        {
            return await _context.Ingresos.FindAsync(ID);
        }

        public async Task Add(Ingreso model)
        {
            await _context.Ingresos.AddAsync(model);
            await Save();
        }

        public async Task Update(Ingreso model)
        {
            var ingreso = await _context.Ingresos.FindAsync(model.ID);
            if (ingreso != null)
            {
                ingreso.Descripcion = model.Descripcion;
                ingreso.Estado = model.Estado;
                ingreso.TipoIngreso = model.TipoIngreso;
                _context.Update(ingreso);
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
