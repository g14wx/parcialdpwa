using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        [DisplayName("Titulo Categoria")]
        [Required(ErrorMessage ="Error, este campo es necesario",AllowEmptyStrings =false)]
        [MinLength(1, ErrorMessage ="Este campo por lo menos debe de tener un caractér")]
        public string Cat { get; set; }
        public virtual ICollection<Disco> Discos { get; set; }
    }
}