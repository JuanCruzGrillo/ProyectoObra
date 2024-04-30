using System.ComponentModel.DataAnnotations;

namespace ProyectoObra.Web.Models
{
    public partial class RubroViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;
        [Required]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
    }
}
