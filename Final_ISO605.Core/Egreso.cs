using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Core
{
    public class Egreso
    {
        [Key]
        public int ID { get; set; }
        public int TipoEgresoID { get; set; }
        public int TipoPagoID { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public TipoEgreso TipoEgreso { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
