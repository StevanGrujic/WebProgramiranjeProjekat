using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatBackend.Models
{
    [Table("Ispitni rok")]
    public class IspitniRok
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }
        public virtual List<Ispit> listaIspita { get; set; }
    }
}