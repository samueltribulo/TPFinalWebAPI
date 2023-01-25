using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWProvincias_Tribulo.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public virtual Provincia Provincia { get; set; }

    }
}
