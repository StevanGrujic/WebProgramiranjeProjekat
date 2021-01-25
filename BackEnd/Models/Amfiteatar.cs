using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjekatBackend.Models
{
    [Table("Amfiteatar")]
    public class Amfiteatar
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }
        
        [Column("Kapacitet")]
        public int Kapacitet { get; set; }

        [Column("Color")]
        public string Color { get; set; }

        [JsonIgnore]

        public Ispit Ispit { get; set; }
    }
}