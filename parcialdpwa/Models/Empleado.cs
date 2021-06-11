using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public class SelledDisk { public int ID; public String Titulo; }

    public class Empleado
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Error, Este campo es requerido", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Error este campo necesita al menos un caracter")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Error, Este campo es requerido", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Error este campo necesita al menos un caracter")]
        public string Apellidos { get; set; }
        [Required(AllowEmptyStrings = true)]
        [DisplayName("Direcciòn")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Error, Este campo es requerido", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Error este campo necesita al menos un caracter")]
        [DisplayName("Usuario")]
        public string login { get; set; }

        [Required(ErrorMessage = "Error, Este campo es requerido", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Error este campo necesita al menos un caracter")]

        [DisplayName("Contraseña")]
        public string clave { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public List<SelledDisk> listSelledDisks { get; set; }
    }
}