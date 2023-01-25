using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWProvincias_Tribulo.Models
{
    [Table("Provincia")]
    public class Provincia
    {

        [Key]
        public int IdProvincia { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public List<Ciudad> Ciudad { get; set; }

    }
}
