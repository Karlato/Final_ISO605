using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ISO605.Core
{
    public enum SexoEnum
    {
        Masculino,
        Femenino
    }
    public class Usuario
    {
        [Key] 
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Ocupacion { get; set; }
        public string Nacionalidad { get; set; }
        public string EmailAfiliado { get; set; }
        public string Ciudad { get; set; }
        public string NivelAcademico { get; set; }
        public string Estado { get; set; }
    }
}
