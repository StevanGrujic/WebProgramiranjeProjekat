using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjekatBackend.Models
{
    public class Student
    {

        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("Ime")]
        [MaxLength(20)]
        public string Ime { get; set; }
        
        [Column("Prezime")]
        [MaxLength(20)]
        public string Prezime { get; set; }

        [Column("BrojIndeksa")]
        public int BrojIndeksa { get; set; }

        [Column("Godina studija")]
        public int GodinaStudija { get; set; }

        [JsonIgnore]
        public virtual Ispit Ispit { get; set; }
    }
}