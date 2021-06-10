using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public class DetallePedido
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Error, este campo es necesario")]
        [Range(1,int.MaxValue,ErrorMessage = "Error, por lo menos debe de ser 1 la cantidad deseada")]
        public int Cantidad { get; set; }
        [DisplayName("Total de este detalle del pedido $")]
        [Required(ErrorMessage = "Error, el campo es necesario")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal PrecioVenta { get; set; }
        [DisplayName("Direccion del pedido")]
        public int PedidoID { get; set; }
        public virtual Pedido Pedido { get; set; }

        [DisplayName("Disco")]
        public int DiscoID { get; set; }
        public virtual Disco Disco { get; set; }
    }
}