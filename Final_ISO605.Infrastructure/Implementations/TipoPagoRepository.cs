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
    public class TipoPagoRepository : ITipoPagoRepository
    {

        private readonly AppDbContext _context;

        public TipoPagoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoPago>> GetAll()
        {
            var tiposPagos = await _context.TiposPagos.ToListAsync();
            return tiposPagos;
        }

        public async Task<TipoPago> GetById(int ID)
        {
            return await _context.TiposPagos.FindAsync(ID);
        }

        public async Task Add(TipoPago model)
        {
            await _context.TiposPagos.AddAsync(model);
            await Save();
        }

        public async Task Update(TipoPago model)
        {
            var tipoPago = await _context.TiposPagos.FindAsync(model.ID);
            if (tipoPago != null)
            {
                tipoPago.Descripcion = model.Descripcion;
                tipoPago.Estado = model.Estado;
                _context.Update(tipoPago);
                await Save();
            }
        }

        public async Task Delete(int ID)
        {
            var tipoPago = await _context.TiposPagos.FindAsync(ID);
            if (tipoPago != null)
            {
                _context.TiposPagos.Remove(tipoPago);
                await Save();
            }
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}