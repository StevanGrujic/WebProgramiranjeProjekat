using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjekatBackend.Models
{
    [Table("Ispit")]
    public class Ispit
    {
        [Column("Sifra")]
        [Key]
        public int Sifra { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        public virtual List<Student> listaStudenata { get; set; }

        [JsonIgnore]
        public virtual IspitniRok IspitniRok { get; set; }

        public virtual List<Amfiteatar> Amfiteatri {get; set;}
    }
}