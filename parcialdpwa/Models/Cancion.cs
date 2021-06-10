using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace parcialdpwa.Models
{
    public class Cancion
    {
        public int ID { get; set; }
        [DisplayName("Pista Nº")]
        [Range(1,int.MaxValue,ErrorMessage ="Esta pista debe de tener por lo menos un indice mayor a 0")]
        public int Numero { get; set; }
        [DisplayName("Duración de la canción")]
        [Required(ErrorMessage ="La duración de la canción es necesaria")]
        [TimeSpanValidator(MinValueString = "0:0:30",
            MaxValueString = "23:00:0",
            ExcludeRange = false)]
        public TimeSpan Tiempo { get; set; }
        [DisplayName("Titulo de la canción")]
        [Required(ErrorMessage ="Error, este campo es necesario",AllowEmptyStrings =false)]
        [MinLength(1,ErrorMessage ="Error por lo menos el titulo debe de contener un caractér")]
        public string cancion { get; set; }
        public int DiscoID { get; set; }
        public virtual Disco Disco { get; set; }
    }
}