using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Error, Este campo es requerido",AllowEmptyStrings = false)]
        [MinLength(1,ErrorMessage = "Error este campo necesita al menos un caracter")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Error, Este campo es requerido", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Error este campo necesita al menos un caracter")]
        public string Apellidos { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Direccion { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}