using System.ComponentModel.DataAnnotations;

namespace ProyectoObra.Web.Models
{
    public partial class ProductoViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;
        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [Required]
        [Display(Name = "Rubro")]
        public int RubroId { get; set; }
    }
}
