using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public enum Formato
    {
        CDROM,CDR,CDRW,CDDA
    }
    public class Disco
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La fecha es necesaria")]
        [DisplayName("Fecha de lanzamiento")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Formato es necesario, Seleccione una opción, por favor")]
        [DisplayName("Formato del disco")]
        public Formato Formato { get; set; }
        [DisplayName("Numero de tracks (Canciones)")]
        [Range(1,int.MaxValue,ErrorMessage = "Error, por lo menos debe de tener un track este disco")]
        public int Ncanciones { get; set; }
        [DisplayName("Precio de venta")]
        [Required(ErrorMessage = "Error, el campo es necesario")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Precio { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Observaciones { get; set; }
        [DisplayName("Album Cover")]
        [Required(AllowEmptyStrings = true)]
        public string Imagen { get; set; }
        public int ArtistaID { get; set; }
        public virtual Artista Artista { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Cancion> Canciones { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}