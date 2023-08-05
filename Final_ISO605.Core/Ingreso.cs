using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Core
{
    public class Ingreso
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Tipo de Ingreso")]
        public int TipoIngresoID { get; set; }
        public string Descripcion { get; set; }
        public string Institucion { get; set; }
        public string Estado { get; set; }
        [ForeignKey("TipoIngresoID")]
        public TipoIngreso TipoIngreso { get; set; }
    }
}
