using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public enum Estado
    {
        Entregado, EnProceso
    }
    public class Pedido
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Error, Este campo es requerido")]
        public DateTime FechaPedido { get; set; }
        [Required(ErrorMessage = "Error este campo es necesario",AllowEmptyStrings = false)]
        [MinLength(1,ErrorMessage = "Al menos este campo debe de poseer un caractér")]
        public string DireccionEntrega { get; set; }
        public Estado Estado { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int EmpleadoID { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}