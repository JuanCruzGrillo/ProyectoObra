using System.ComponentModel.DataAnnotations;

namespace ProyectoObra.Web.Models
{
    public partial class EmpleadoViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string FullName { get; set; } = null!;
        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
    }
}
