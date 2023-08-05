using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Core
{
    public class TipoIngreso
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(20)]
        public string Estado { get; set; }
    }
}
