using System.ComponentModel.DataAnnotations;

namespace ProyectoObra.Web.Models
{
    public partial class EmpresaViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;
    }
}
