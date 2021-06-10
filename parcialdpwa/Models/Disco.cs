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
        [Required(ErrorMessage = "El titulo del disco es necesario")]
        [DisplayName("Titulo del disco")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La fecha es necesaria")]
        [DisplayName("Fecha de lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Formato es necesario, Seleccione una opción, por favor")]
        [DisplayName("Formato del disco")]
        public Formato Formato { get; set; }
        [DisplayName("Numero de tracks (Canciones)")]
        [Range(1,int.MaxValue,ErrorMessage = "Error, por lo menos debe de tener un track este disco")]
        [Required(ErrorMessage = "Esta campo es necesario")]
        public int Ncanciones { get; set; }
        [DisplayName("Precio de venta")]
        [Required(ErrorMessage = "Error, el campo es necesario")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$",ErrorMessage = "El precio debe de ser unidad 'punto' decenas ejem: 10.02")]
        public decimal Precio { get; set; }
        public string Observaciones { get; set; }
        [DisplayName("Album Cover")]
        public string Imagen { get; set; }
        [DisplayName("Artista")]
        [Required(ErrorMessage = "Este campo es necesario")]
        public int ArtistaID { get; set; }
        public virtual Artista Artista { get; set; }
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Este campo es necesario")]
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Cancion> Canciones { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}