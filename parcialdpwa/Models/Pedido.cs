using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace parcialdpwa.Models
{
    public enum Estado
    {
        Entregado,
        EnProceso
    }

    public class Pedido
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Error, Este campo es requerido")]
        [DisplayName("Fecha en la que se realizo el pedido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "Error este campo es necesario", AllowEmptyStrings = false)]
        [MinLength(1, ErrorMessage = "Al menos este campo debe de poseer un caractér")]
        [DisplayName("Dirección de la entrega")]
        public string DireccionEntrega { get; set; }

        public Estado Estado { get; set; }
        [DisplayName("Cliente")]
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        [DisplayName("Empleado")]
        public int EmpleadoID { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}