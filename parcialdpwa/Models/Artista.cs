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
        [DisplayName("Apellido del artista")]
        [Required(AllowEmptyStrings = true,ErrorMessage = "Este campo es necesario")]
        public string Apellido { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Error, Este campo es requerido",AllowEmptyStrings = true)]
        public DateTime FechaDeNacimiento { get; set; }
        [DisplayName("Lugar de nacimiento")]
        [Required(ErrorMessage = "Error, Este campo es requerido" ,AllowEmptyStrings = true)]
        public string LugarDeNacimiento { get; set; }
        public virtual ICollection<Disco> Discos { get; set; }
    }
}