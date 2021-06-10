using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public class Artista
    {
        public int ID { get; set; }
        [DisplayName("Nombre del artista")]
        [Required(ErrorMessage = "Error, Este campo es requerido", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Error este campo necesita al menos un caracter")]
        public string Nombre { get; set; }
        [DiplayName("Apellido del artista")]
        [Required(AllowEmptyStrings = true)]
        public string Apellido { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required(AllowEmptyStrings = true)]
        public DateTime FechaDeNacimiento { get; set; }
        [DisplayName("Lugar de nacimiento")]
        [Required(AllowEmptyStrings = true)]
        public string LugarDeNacimiento { get; set; }
        public virtual ICollection<Disco> Discos { get; set; }
    }
}